using System;
using System.Collections.Generic;
using System.Reflection;
using Npgsql.Schema;
using System.Collections.ObjectModel;
using System.Text;
using Cardiology.Utils;
using NLog;

namespace Cardiology
{
    internal class DataService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public DataService()
        {

        }

        private Npgsql.NpgsqlConnection getConnection()
        {
            Npgsql.NpgsqlConnection connection = null;
            connection = new Npgsql.NpgsqlConnection();
            connection.ConnectionString = "Server=89.223.91.196;Port=5432;User Id=cardio;Password=AbC123456!ab;Database=cardio;";
            connection.Open();
            return connection;
        }

        public void update(string query)
        {
            Npgsql.NpgsqlConnection connection = null;
            try
            {
                connection = getConnection();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                command.ExecuteScalar();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public string insert(string query)
        {
            Npgsql.NpgsqlConnection connection = null;
            try
            {
                connection = getConnection();
                logger.Debug(query);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                return (string)command.ExecuteScalar();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public string insertObject<T>(T obj, string tableName)
        {
            Npgsql.NpgsqlConnection connection = null;
            try
            {
                connection = getConnection();
                string query = convertObjectFieldsInQuery(obj, tableName);
                logger.Debug(query);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                return (string)command.ExecuteScalar();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void updateObject<T>(T obj, string tableName, string conditionAttrName, string conditionAttrValue)
        {
            Npgsql.NpgsqlConnection connection = null;
            try
            {
                connection = getConnection();
                StringBuilder builder = new StringBuilder();
                builder.Append(@"UPDATE ").Append(tableName).Append(" SET ");

                FieldInfo[] fields = typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                for (int i = 0; i < fields.Length; i++)
                {
                    FieldInfo fieldInfo = fields[i];
                    TableAttribute attrInfo = Attribute.GetCustomAttribute(fieldInfo, typeof(TableAttribute)) as TableAttribute;

                    if (attrInfo != null && attrInfo.CanSetAttr)
                    {
                        object value = fieldInfo.GetValue(obj);
                        builder.Append(attrInfo.AttrName).Append("=").Append(getWrappedValue(value, fieldInfo.FieldType));
                        if (i < fields.Length - 1)
                        {
                            builder.Append(",");
                        }
                    }
                }
                builder.Append(" WHERE ").Append(conditionAttrName).Append("='").Append(conditionAttrValue).Append("'");
                logger.Debug(builder.ToString());

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(builder.ToString(), connection);
                command.ExecuteScalar();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public List<T> queryObjectsCollectionByAttrCond<T>(string tableName, string AttrName, string attrValue, bool isQuoted)
        {
            return queryObjectsCollection<T>(@"SELECT * FROM " + tableName + " WHERE " + AttrName + "=" + (isQuoted ? CommonUtils.toQuotedStr(attrValue) : attrValue));
        }

        public List<T> queryObjectsCollection<T>(string query)
        {
            List<T> result = new List<T>();
            Npgsql.NpgsqlConnection connection = null;
            Npgsql.NpgsqlDataReader reader = null;
            try
            {
                connection = getConnection();
                logger.Debug(query);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    T bean = fillObject<T>(reader);
                    result.Add(bean);
                }
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return result;
        }

        public T queryObjectById<T>(string tableName, string id)
        {
            return queryObject<T>(@"Select * FROM " + tableName + " WHERE r_object_id='" + id + "'");
        }


        public T queryObjectByAttrCond<T>(string tableName, string attrName, string attrValue, bool isQuoted)
        {
            return queryObject<T>(@"Select * FROM " + tableName + " WHERE " + attrName + "=" + (isQuoted ? CommonUtils.toQuotedStr(attrValue) : attrValue));
        }

        public T queryObject<T>(string query)
        {
            Npgsql.NpgsqlConnection connection = null;
            Npgsql.NpgsqlDataReader reader = null;
            try
            {
                connection = getConnection();
                logger.Debug(query);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return fillObject<T>(reader);
                }
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return default(T);
        }

        public string updateOrCreateIfNeedObject<T>(T obj, string tablName, string objId)
        {
            if (CommonUtils.isBlank(objId))
            {
                return insertObject<T>(obj, tablName);
            }
            else
            {
                updateObject<T>(obj, tablName, "r_object_id", objId);
                return objId;
            }
        }

        private T fillObject<T>(Npgsql.NpgsqlDataReader reader)
        {
            T result = (T)Activator.CreateInstance(typeof(T));
            FieldInfo[] fields = typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            ReadOnlyCollection<NpgsqlDbColumn> columns = reader.GetColumnSchema();
            IEnumerator<NpgsqlDbColumn> colsNumerator = columns.GetEnumerator();
            while (colsNumerator.MoveNext())
            {
                string columnName = colsNumerator.Current.ColumnName;
                for (int i = 0; i < fields.Length; i++)
                {
                    FieldInfo fieldInfo = fields[i];
                    TableAttribute attrInfo = Attribute.GetCustomAttribute(fieldInfo, typeof(TableAttribute)) as TableAttribute;
                    if (attrInfo != null && attrInfo.AttrName.Equals(columnName))
                    {
                        object settedVal = reader.GetValue(columns.IndexOf(colsNumerator.Current));
                        if (settedVal.GetType() == typeof(DBNull))
                        {
                            settedVal = null;
                        }
                        fieldInfo.SetValue(result, settedVal);
                    }
                }
            }
            return result;
        }

        private string convertObjectFieldsInQuery<T>(T obj, string tableName)
        {
            StringBuilder valuesBuilder = new StringBuilder("VALUES(");
            StringBuilder builder = new StringBuilder();
            builder.Append(@"INSERT INTO ").Append(tableName).Append("(");

            FieldInfo[] fields = typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo fieldInfo = fields[i];
                TableAttribute attrInfo = Attribute.GetCustomAttribute(fieldInfo, typeof(TableAttribute)) as TableAttribute;

                if (attrInfo != null && attrInfo.CanSetAttr)
                {
                    builder.Append(attrInfo.AttrName);
                    object value = fieldInfo.GetValue(obj);
                    valuesBuilder.Append(getWrappedValue(value, fieldInfo.FieldType));
                    if (i < fields.Length - 1)
                    {
                        builder.Append(",");
                        valuesBuilder.Append(",");
                    }
                }
            }
            valuesBuilder.Append(")");
            builder.Append(")").Append(valuesBuilder).Append(" RETURNING r_object_id;");
            Console.WriteLine(builder.ToString());
            return builder.ToString();
        }

        private string getWrappedValue(object value, Type fieldType)
        {
            if (fieldType == typeof(int) || fieldType == typeof(double))
            {
                return value + "";
            }
            else if (fieldType == typeof(string))
            {
                return "'" + value + "'";
            }
            else if (fieldType == typeof(DateTime))
            {
                return (@"to_timestamp('" + value + "', 'DD.MM.YYYY HH24:mi:ss')");
            }
            else
            {
                return value.ToString();
            }

        }

        public void queryMappedValues(string query, string attrKey, string attrValue, IMappedValueProcessor processor)
        {
            Npgsql.NpgsqlConnection connection = null;
            Npgsql.NpgsqlDataReader reader = null;
            try
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                connection = getConnection();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                reader = command.ExecuteReader();
                ReadOnlyCollection<NpgsqlDbColumn> columns = reader.GetColumnSchema();
                IEnumerator<NpgsqlDbColumn> colsNumerator = columns.GetEnumerator();
                while (reader.Read())
                {
                    string attrKeyValue = null;
                    string attrValValue = null;
                    while (colsNumerator.MoveNext())
                    {
                        if (attrKey.Equals(colsNumerator.Current.ColumnName))
                        {
                            int indx = columns.IndexOf(colsNumerator.Current);
                            attrKeyValue = getWrappedValue(reader.GetValue(indx), reader.GetDataTypeName(indx));
                        }
                        else if (attrValue.Equals(colsNumerator.Current.ColumnName))
                        {
                            int indx = columns.IndexOf(colsNumerator.Current);
                            attrValValue = getWrappedValue(reader.GetValue(indx), reader.GetDataTypeName(indx));
                        }
                    }
                    colsNumerator.Reset();

                    if (attrKeyValue != null)
                    {
                        processor(attrKeyValue, attrValValue);
                    }
                }
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public delegate void IMappedValueProcessor(string key, string value);

        private string getWrappedValue(object value, string typeName)
        {
            if ("timestamp".Equals(typeName))
            {
                DateTime dt = (DateTime)value;
                return dt.ToLongDateString();
            }
            else
            {
                return value.ToString();
            }
        }

        public string querySingleString(string query)
        {
            Npgsql.NpgsqlConnection connection = null;
            Npgsql.NpgsqlDataReader reader = null;
            try
            {
                connection = getConnection();
                logger.Debug(query);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                reader = command.ExecuteReader();
                ReadOnlyCollection<NpgsqlDbColumn> columns = reader.GetColumnSchema();
                if (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return null;
        }

        public DateTime querySingleDateTime(string query)
        {
            Npgsql.NpgsqlConnection connection = null;
            Npgsql.NpgsqlDataReader reader = null;
            try
            {
                connection = getConnection();
                logger.Debug(query);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                reader = command.ExecuteReader();
                ReadOnlyCollection<NpgsqlDbColumn> columns = reader.GetColumnSchema();
                if (reader.Read())
                {
                    return reader.GetDateTime(0);
                }
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return default(DateTime);
        }

        public bool queryDelete(string tableName, string AttrName, string attrValue, bool isQuoted)
        {
            return delete(@"DELETE FROM " + tableName + " WHERE " + AttrName + "=" + (isQuoted ? CommonUtils.toQuotedStr(attrValue) : attrValue));
        }


        public bool delete(string sql)
        {
            Npgsql.NpgsqlConnection connection = null;
            try
            {
                connection = getConnection();
                logger.Warn(sql);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                command.ExecuteScalar();
                return true;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }




    }




}
