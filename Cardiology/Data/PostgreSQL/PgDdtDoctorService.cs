using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdvDoctorervice : IDdvDoctorervice
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdvDoctorervice(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtDoctor> GetAll()
        {
            IList<DdtDoctor> list = new List<DdtDoctor>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dss_middle_name, dss_first_name, r_modify_date, r_creation_date, dss_last_name FROM ddt_doctor";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtDoctor obj = new DdtDoctor();
                        obj.ObjectId = reader.GetString(1);
                        obj.MiddleName = reader.GetString(2);
                        obj.FirstName = reader.GetString(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.CreationDate = reader.GetDateTime(5);
                        obj.LastName = reader.GetString(6);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtDoctor GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_middle_name, dss_first_name, r_modify_date, r_creation_date, dss_last_name FROM ddt_doctor WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtDoctor obj = new DdtDoctor();
                        obj.ObjectId = reader.GetString(1);
                        obj.MiddleName = reader.GetString(2);
                        obj.FirstName = reader.GetString(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.CreationDate = reader.GetDateTime(5);
                        obj.LastName = reader.GetString(6);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
