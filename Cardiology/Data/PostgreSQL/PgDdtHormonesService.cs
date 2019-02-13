using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtHormonesService : IDdtHormonesService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtHormonesService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtHormones> GetAll()
        {
            IList<DdtHormones> list = new List<DdtHormones>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dss_ttg, dsdt_analysis_date, dss_t3, r_modify_date, dss_t4, r_creation_date, dsid_doctor, dsid_patient FROM ddt_hormones";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtHormones obj = new DdtHormones();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.Ttg = reader.GetString(3);
                        obj.AnalysisDate = reader.GetDateTime(4);
                        obj.T3 = reader.GetString(5);
                        obj.ModifyDate = reader.GetDateTime(6);
                        obj.T4 = reader.GetString(7);
                        obj.CreationDate = reader.GetDateTime(8);
                        obj.Doctor = reader.GetString(9);
                        obj.Patient = reader.GetString(10);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
