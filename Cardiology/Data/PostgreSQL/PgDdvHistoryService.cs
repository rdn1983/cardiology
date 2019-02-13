using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdvHistoryService : IDdvHistoryService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdvHistoryService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdvHistory> GetAll()
        {
            IList<DdvHistory> list = new List<DdvHistory>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, dsid_operation_id, dsdt_operation_date, dss_description, dss_doctor_name, dss_operation_type, dss_operation_name FROM ddv_history";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvHistory obj = new DdvHistory();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.OperationId = reader.GetString(2);
                        obj.OperationDate = reader.GetDateTime(3);
                        obj.Description = reader.GetString(4);
                        obj.DoctorName = reader.GetString(5);
                        obj.OperationType = reader.GetString(6);
                        obj.OperationName = reader.GetString(7);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
