using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdvAllDiagnosisService : IDdvAllDiagnosisService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdvAllDiagnosisService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdvAllDiagnosis> GetAll()
        {
            IList<DdvAllDiagnosis> list = new List<DdvAllDiagnosis>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, object_type, dss_diagnosis FROM ddv_all_diagnosis";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvAllDiagnosis obj = new DdvAllDiagnosis();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.Type = reader.GetString(3);
                        obj.Diagnosis = reader.GetString(4);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
