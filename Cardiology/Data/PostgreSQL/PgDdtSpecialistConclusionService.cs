using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtSpecialistConclusionService : IDdtSpecialistConclusionService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtSpecialistConclusionService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtSpecialistConclusion> GetAll()
        {
            IList<DdtSpecialistConclusion> list = new List<DdtSpecialistConclusion>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsdt_analysis_date, r_creation_date, dsid_parent, dss_neuro_surgeon, dsid_doctor, dsid_patient, dss_endocrinologist, dsid_hospitality_session, r_modify_date, dss_parent_type, dss_neurolog, dss_surgeon FROM ddt_specialist_conclusion";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtSpecialistConclusion obj = new DdtSpecialistConclusion();
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Parent = reader.GetString(4);
                        obj.NeuroSurgeon = reader.GetString(5);
                        obj.Doctor = reader.GetString(6);
                        obj.Patient = reader.GetString(7);
                        obj.Endocrinologist = reader.GetString(8);
                        obj.HospitalitySession = reader.GetString(9);
                        obj.ModifyDate = reader.GetDateTime(10);
                        obj.ParentType = reader.GetString(11);
                        obj.Neurolog = reader.GetString(12);
                        obj.Surgeon = reader.GetString(13);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
