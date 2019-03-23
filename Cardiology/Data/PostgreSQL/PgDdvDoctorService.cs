using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdvDoctorService : IDdvDoctorService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdvDoctorService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdvDoctor> GetAll()
        {
            IList<DdvDoctor> list = new List<DdvDoctor>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dss_full_name, dss_middle_name, dss_first_name, r_modify_date, dss_short_name, r_creation_date, dss_last_name " +
                    "FROM ddv_doctor";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvDoctor obj = new DdvDoctor();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.FullName = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.MiddleName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.FirstName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.ModifyDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.ShortName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.LastName = reader.IsDBNull(7) ? null : reader.GetString(7);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdvDoctor> GetByGroupName(string groupName)
        {
            IList<DdvDoctor> list = new List<DdvDoctor>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT d.r_object_id, d.dss_full_name, d.dss_middle_name, d.dss_first_name, d.r_modify_date," +
                    " d.dss_short_name, d.r_creation_date, d.dss_last_name FROM ddv_doctor d, dm_group_users g WHERE g.dss_group_name = '{0}'" +
                    " AND d.r_object_id = g.dsid_doctor_id", groupName);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvDoctor obj = new DdvDoctor();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.FullName = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.MiddleName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.FirstName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.ModifyDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.ShortName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.LastName = reader.IsDBNull(7) ? null : reader.GetString(7);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public List<DdvDoctor> GetByQuery(string sql)
        {
            List<DdvDoctor> list = new List<DdvDoctor>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvDoctor obj = new DdvDoctor();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.FullName = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.MiddleName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.FirstName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.ModifyDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.ShortName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.LastName = reader.IsDBNull(7) ? null : reader.GetString(7);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdvDoctor GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_full_name, dss_middle_name, dss_first_name, r_modify_date, dss_short_name, r_creation_date," +
                    " dss_last_name FROM ddv_doctor WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdvDoctor obj = new DdvDoctor();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.FullName = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.MiddleName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.FirstName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.ModifyDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.ShortName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.LastName = reader.IsDBNull(7) ? null : reader.GetString(7);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdvDoctor GetObject(string sql)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdvDoctor obj = new DdvDoctor();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.FullName = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.MiddleName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.FirstName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.ModifyDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.ShortName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.LastName = reader.IsDBNull(7) ? null : reader.GetString(7);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
