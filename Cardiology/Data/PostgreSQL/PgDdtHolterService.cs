using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtHolterService : IDdtHolterService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtHolterService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtHolter> GetAll()
        {
            IList<DdtHolter> list = new List<DdtHolter>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_monitoring_ad, dss_parent_type, r_creation_date, dsid_parent, dss_holter, dsid_doctor, dsid_patient FROM ddt_holter";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtHolter obj = new DdtHolter();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.AnalysisDate = reader.GetDateTime(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.MonitoringAd = reader.GetString(5);
                        obj.ParentType = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.Parent = reader.GetString(8);
                        obj.Holter = reader.GetString(9);
                        obj.Doctor = reader.GetString(10);
                        obj.Patient = reader.GetString(11);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
