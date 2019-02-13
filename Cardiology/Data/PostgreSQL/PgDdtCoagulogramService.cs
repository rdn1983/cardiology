using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtCoagulogramService : IDdtCoagulogramService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtCoagulogramService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtCoagulogram> GetAll()
        {
            IList<DdtCoagulogram> list = new List<DdtCoagulogram>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, dss_ddimer, r_object_id, dsdt_analysis_date, r_modify_date, dss_mcho, r_creation_date, dss_achtv, dsid_doctor, dsid_patient FROM ddt_coagulogram";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCoagulogram obj = new DdtCoagulogram();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.Ddimer = reader.GetString(2);
                        obj.ObjectId = reader.GetString(3);
                        obj.AnalysisDate = reader.GetDateTime(4);
                        obj.ModifyDate = reader.GetDateTime(5);
                        obj.Mcho = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.Achtv = reader.GetString(8);
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
