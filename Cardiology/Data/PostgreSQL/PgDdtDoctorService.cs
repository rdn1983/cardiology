using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtDoctorService : IDdtDoctorService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtDoctorService(IDbConnectionFactory connectionFactory)
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
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.MiddleName = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.FirstName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.CreationDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.LastName = reader.IsDBNull(5) ? null : reader.GetString(5);
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
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.MiddleName = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.FirstName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.CreationDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.LastName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtDoctor obj)
        {
            throw new NotImplementedException();
        }
    }
}
