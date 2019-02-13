using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtAnamnesisService : IDdtAnamnesisService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtAnamnesisService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtAnamnesis> GetAll()
        {
            IList<DdtAnamnesis> list = new List<DdtAnamnesis>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dss_anamnesis_vitae, dss_drugs_intoxication, dss_cardiovascular_system, dsdt_inspection_date, dss_past_surgeries, dss_diagnosis_justification, dsb_template, dss_operation_cause, dss_anamnesis_epid, dss_urinary_system, dss_anamnesis_allergy, dss_digestive_system, dss_nervous_system, dss_diagnosis, r_creation_date, dss_complaints, dss_oks_st, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_respiratory_system, r_modify_date, dss_st_presens, dss_template_name, dss_accompanying_illnesses, dss_anamnesis_morbi FROM ddt_anamnesis";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtAnamnesis obj = new DdtAnamnesis();
                        obj.ObjectId = reader.GetString(1);
                        obj.AnamnesisVitae = reader.GetString(2);
                        obj.DrugsIntoxication = reader.GetString(3);
                        obj.CardiovascularSystem = reader.GetString(4);
                        obj.InspectionDate = reader.GetDateTime(5);
                        obj.PastSurgeries = reader.GetString(6);
                        obj.DiagnosisJustification = reader.GetString(7);
                        obj.Template = reader.GetBoolean(8);
                        obj.OperationCause = reader.GetString(9);
                        obj.AnamnesisEpid = reader.GetString(10);
                        obj.UrinarySystem = reader.GetString(11);
                        obj.AnamnesisAllergy = reader.GetString(12);
                        obj.DigestiveSystem = reader.GetString(13);
                        obj.NervousSystem = reader.GetString(14);
                        obj.Diagnosis = reader.GetString(15);
                        obj.CreationDate = reader.GetDateTime(16);
                        obj.Complaints = reader.GetString(17);
                        obj.OksSt = reader.GetString(18);
                        obj.Doctor = reader.GetString(19);
                        obj.Patient = reader.GetString(20);
                        obj.HospitalitySession = reader.GetString(21);
                        obj.RespiratorySystem = reader.GetString(22);
                        obj.ModifyDate = reader.GetDateTime(23);
                        obj.StPresens = reader.GetString(24);
                        obj.TemplateName = reader.GetString(25);
                        obj.AccompanyingIllnesses = reader.GetString(26);
                        obj.AnamnesisMorbi = reader.GetString(27);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtAnamnesis GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_anamnesis_vitae, dss_drugs_intoxication, dss_cardiovascular_system, dsdt_inspection_date, dss_past_surgeries, dss_diagnosis_justification, dsb_template, dss_operation_cause, dss_anamnesis_epid, dss_urinary_system, dss_anamnesis_allergy, dss_digestive_system, dss_nervous_system, dss_diagnosis, r_creation_date, dss_complaints, dss_oks_st, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_respiratory_system, r_modify_date, dss_st_presens, dss_template_name, dss_accompanying_illnesses, dss_anamnesis_morbi FROM ddt_anamnesis WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtAnamnesis obj = new DdtAnamnesis();
                        obj.ObjectId = reader.GetString(1);
                        obj.AnamnesisVitae = reader.GetString(2);
                        obj.DrugsIntoxication = reader.GetString(3);
                        obj.CardiovascularSystem = reader.GetString(4);
                        obj.InspectionDate = reader.GetDateTime(5);
                        obj.PastSurgeries = reader.GetString(6);
                        obj.DiagnosisJustification = reader.GetString(7);
                        obj.Template = reader.GetBoolean(8);
                        obj.OperationCause = reader.GetString(9);
                        obj.AnamnesisEpid = reader.GetString(10);
                        obj.UrinarySystem = reader.GetString(11);
                        obj.AnamnesisAllergy = reader.GetString(12);
                        obj.DigestiveSystem = reader.GetString(13);
                        obj.NervousSystem = reader.GetString(14);
                        obj.Diagnosis = reader.GetString(15);
                        obj.CreationDate = reader.GetDateTime(16);
                        obj.Complaints = reader.GetString(17);
                        obj.OksSt = reader.GetString(18);
                        obj.Doctor = reader.GetString(19);
                        obj.Patient = reader.GetString(20);
                        obj.HospitalitySession = reader.GetString(21);
                        obj.RespiratorySystem = reader.GetString(22);
                        obj.ModifyDate = reader.GetDateTime(23);
                        obj.StPresens = reader.GetString(24);
                        obj.TemplateName = reader.GetString(25);
                        obj.AccompanyingIllnesses = reader.GetString(26);
                        obj.AnamnesisMorbi = reader.GetString(27);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
