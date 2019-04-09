using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;
using NLog;
using System.Globalization;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtCureService : IDdtCureService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtCureService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtCure> GetAll()
        {
            IList<DdtCure> list = new List<DdtCure>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dsid_cure_type FROM ddt_cure";

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCure obj = new DdtCure();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.CureType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtCure GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dsid_cure_type FROM ddt_cure WHERE r_object_id = '{0}'", id);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtCure obj = new DdtCure();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.CureType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        return obj;
                    }
                }
            }
            return null;
        }

        public IList<DdtCure> GetListByMedicineListId(string id)
        {
            IList<DdtCure> list = new List<DdtCure>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT c.r_object_id, c.r_modify_date, c.r_creation_date, c.dss_name, c.dsid_cure_type FROM ddt_cure c, ddt_issued_medicine m WHERE m.dsid_cure = c.r_object_id AND m.dsid_med_list = '{0}'", id);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCure obj = new DdtCure();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.CureType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtCure> GetListByCureTypeId(string cureTypeId)
        {
            IList<DdtCure> list = new List<DdtCure>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dsid_cure_type FROM ddt_cure WHERE dsid_cure_type = '{0}'", cureTypeId);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCure obj = new DdtCure();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.CureType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtCure> GetListByTemplate(string templateName)
        {
            IList<DdtCure> list = new List<DdtCure>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("Select cure.* from ddt_values vv, ddt_cure cure where vv.dss_name like '{0}%' AND vv.dss_value = cure.dss_name", templateName);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCure obj = new DdtCure();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.CureType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public List<DdtCure> GetByQuery(string sql)
        {
            List<DdtCure> list = new List<DdtCure>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCure obj = new DdtCure();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.CureType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public string Save(DdtCure obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_cure SET " +
                                          "dss_name = @Name, " +
                                    "dsid_cure_type = @CureType " +
                                     "WHERE r_object_id = @ObjectId";

                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Name", obj.Name == null ? "" : obj.Name);
                        cmd.Parameters.AddWithValue("@CureType", obj.CureType);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_cure(dss_name,dsid_cure_type) " +
                                                              "VALUES(@Name,@CureType) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Name", obj.Name == null ? "" : obj.Name);
                        cmd.Parameters.AddWithValue("@CureType", obj.CureType);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
