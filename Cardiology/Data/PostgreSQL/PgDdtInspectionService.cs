using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtInspectionService : IDdtInspectionService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtInspectionService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtInspection> GetAll()
        {
            IList<DdtInspection> list = new List<DdtInspection>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dsdt_inspection_date, r_modify_date, dss_diagnosis, dss_kateter_placement, r_creation_date, dss_complaints, dss_inspection, dsid_doctor, dsid_patient, dss_inspection_result FROM ddt_inspection";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtInspection obj = new DdtInspection();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.InspectionDate = reader.GetDateTime(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.Diagnosis = reader.GetString(5);
                        obj.KateterPlacement = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.Complaints = reader.GetString(8);
                        obj.Inspection = reader.GetString(9);
                        obj.Doctor = reader.GetString(10);
                        obj.Patient = reader.GetString(11);
                        obj.InspectionResult = reader.GetString(12);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
