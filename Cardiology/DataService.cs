﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Npgsql.Schema;
using System.Collections.ObjectModel;
using System.Text;

namespace Cardiology
{
    class DataService
    {
        public DataService()
        {

        }

        private Npgsql.NpgsqlConnection getConnection()
        {
            Npgsql.NpgsqlConnection connection = null;
            connection = new Npgsql.NpgsqlConnection();
            connection.ConnectionString = "Server=pellefant.db.elephantsql.com;Port=5432;User Id=sktsxyvg;Password=lb5iKBHwSdjjciRptPjAsT1QQFK_3JAM;Database=sktsxyvg;";
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
                Console.WriteLine(builder.ToString());

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

        public List<T> queryObjectsCollection<T>(String query)
        {
            List<T> result = new List<T>();
            Npgsql.NpgsqlConnection connection = null;
            try
            {
                connection = getConnection();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    T bean = fillObject<T>(reader);
                    result.Add(bean);
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return result;
        }


        public T queryObject<T>(string query)
        {
            Npgsql.NpgsqlConnection connection = null;
            try
            {
                connection = getConnection();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                Npgsql.NpgsqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return fillObject<T>(reader);
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return default(T);
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
                        fieldInfo.SetValue(result, reader.GetValue(columns.IndexOf(colsNumerator.Current)));
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

    }




}
