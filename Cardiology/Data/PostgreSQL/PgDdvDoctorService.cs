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
                String sql = "SELECT dss_full_name, r_object_id, dss_middle_name, dss_first_name, r_modify_date, dss_short_name, r_creation_date, dss_last_name FROM ddv_doctor";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvDoctor obj = new DdvDoctor();
                        obj.FullName = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.MiddleName = reader.GetString(3);
                        obj.FirstName = reader.GetString(4);
                        obj.ModifyDate = reader.GetDateTime(5);
                        obj.ShortName = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.LastName = reader.GetString(8);
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
                String sql = String.Format("SELECT d.r_object_id, d.dss_full_name, d.dss_middle_name, d.dss_first_name, d.r_modify_date, d.dss_short_name, d.r_creation_date, d.dss_last_name FROM ddv_doctor d, dm_group_users g WHERE g.dss_group_name = '{0}' AND d.r_object_id = g.dsid_doctor_id", groupName);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvDoctor obj = new DdvDoctor();
                        obj.ObjectId = reader.GetString(1);
                        obj.FullName = reader.GetString(2);
                        obj.MiddleName = reader.GetString(3);
                        obj.FirstName = reader.GetString(4);
                        obj.ModifyDate = reader.GetDateTime(5);
                        obj.ShortName = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.LastName = reader.GetString(8);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.FullName = reader.GetString(2);
                        obj.MiddleName = reader.GetString(3);
                        obj.FirstName = reader.GetString(4);
                        obj.ModifyDate = reader.GetDateTime(5);
                        obj.ShortName = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.LastName = reader.GetString(8);
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
                String sql = String.Format("SELECT dss_full_name, r_object_id, dss_middle_name, dss_first_name, r_modify_date, dss_short_name, r_creation_date, dss_last_name FROM ddv_doctor WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdvDoctor obj = new DdvDoctor();
                        obj.FullName = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.MiddleName = reader.GetString(3);
                        obj.FirstName = reader.GetString(4);
                        obj.ModifyDate = reader.GetDateTime(5);
                        obj.ShortName = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.LastName = reader.GetString(8);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
