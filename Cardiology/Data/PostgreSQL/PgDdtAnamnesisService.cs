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
                String sql = "SELECT r_object_id, dss_anamnesis_vitae, dss_drugs_intoxication, dss_cardiovascular_system, dsdt_inspection_date, " +
                    "dss_past_surgeries, dss_diagnosis_justification, dsb_template, dss_operation_cause, dss_anamnesis_epid, dss_urinary_system," +
                    " dss_anamnesis_allergy, dss_digestive_system, dss_nervous_system, dss_diagnosis, r_creation_date, dss_complaints, dss_oks_st, " +
                    "dsid_doctor, dsid_patient, dsid_hospitality_session, dss_respiratory_system, r_modify_date, dss_st_presens, dss_template_name," +
                    " dss_accompanying_illnesses, dss_anamnesis_morbi FROM ddt_anamnesis";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtAnamnesis obj = new DdtAnamnesis();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnamnesisVitae = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.DrugsIntoxication = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CardiovascularSystem = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.InspectionDate = reader.GetDateTime(4);
                        obj.PastSurgeries = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.DiagnosisJustification = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Template = reader.GetBoolean(7);
                        obj.OperationCause = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.AnamnesisEpid = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.UrinarySystem = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.AnamnesisAllergy = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.DigestiveSystem = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.NervousSystem = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Diagnosis = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.CreationDate = reader.GetDateTime(15);
                        obj.Complaints = reader.IsDBNull(16) ? null : reader.GetString(16);
                        obj.OksSt = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.Doctor = reader.IsDBNull(18) ? null : reader.GetString(18);
                        obj.Patient = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.HospitalitySession = reader.IsDBNull(20) ? null : reader.GetString(20);
                        obj.RespiratorySystem = reader.IsDBNull(21) ? null : reader.GetString(21);
                        obj.ModifyDate = reader.GetDateTime(22);
                        obj.StPresens = reader.IsDBNull(23) ? null : reader.GetString(23);
                        obj.TemplateName = reader.IsDBNull(24) ? null : reader.GetString(24);
                        obj.AccompanyingIllnesses = reader.IsDBNull(25) ? null : reader.GetString(25);
                        obj.AnamnesisMorbi = reader.IsDBNull(26) ? null : reader.GetString(26);
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
                String sql = String.Format("SELECT r_object_id, dss_anamnesis_vitae, dss_drugs_intoxication, dss_cardiovascular_system, dsdt_inspection_date," +
                    " dss_past_surgeries, dss_diagnosis_justification, dsb_template, dss_operation_cause, dss_anamnesis_epid, dss_urinary_system, " +
                    "dss_anamnesis_allergy, dss_digestive_system, dss_nervous_system, dss_diagnosis, r_creation_date, dss_complaints, dss_oks_st, dsid_doctor, " +
                    "dsid_patient, dsid_hospitality_session, dss_respiratory_system, r_modify_date, dss_st_presens, dss_template_name, dss_accompanying_illnesses, " +
                    "dss_anamnesis_morbi FROM ddt_anamnesis WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtAnamnesis obj = new DdtAnamnesis();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnamnesisVitae = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.DrugsIntoxication = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CardiovascularSystem = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.InspectionDate = reader.GetDateTime(4);
                        obj.PastSurgeries = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.DiagnosisJustification = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Template = reader.GetBoolean(7);
                        obj.OperationCause = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.AnamnesisEpid = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.UrinarySystem = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.AnamnesisAllergy = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.DigestiveSystem = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.NervousSystem = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Diagnosis = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.CreationDate = reader.GetDateTime(15);
                        obj.Complaints = reader.IsDBNull(16) ? null : reader.GetString(16);
                        obj.OksSt = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.Doctor = reader.IsDBNull(18) ? null : reader.GetString(18);
                        obj.Patient = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.HospitalitySession = reader.IsDBNull(20) ? null : reader.GetString(20);
                        obj.RespiratorySystem = reader.IsDBNull(21) ? null : reader.GetString(21);
                        obj.ModifyDate = reader.GetDateTime(22);
                        obj.StPresens = reader.IsDBNull(23) ? null : reader.GetString(23);
                        obj.TemplateName = reader.IsDBNull(24) ? null : reader.GetString(24);
                        obj.AccompanyingIllnesses = reader.IsDBNull(25) ? null : reader.GetString(25);
                        obj.AnamnesisMorbi = reader.IsDBNull(26) ? null : reader.GetString(26);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtAnamnesis GetByHospitalSessionId(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_anamnesis_vitae, dss_drugs_intoxication, dss_cardiovascular_system, dsdt_inspection_date, " +
                    "dss_past_surgeries, dss_diagnosis_justification, dsb_template, dss_operation_cause, dss_anamnesis_epid, dss_urinary_system," +
                    " dss_anamnesis_allergy, dss_digestive_system, dss_nervous_system, dss_diagnosis, r_creation_date, dss_complaints, dss_oks_st, dsid_doctor," +
                    " dsid_patient, dsid_hospitality_session, dss_respiratory_system, r_modify_date, dss_st_presens, dss_template_name, dss_accompanying_illnesses," +
                    " dss_anamnesis_morbi FROM ddt_anamnesis WHERE dsid_hospitality_session = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtAnamnesis obj = new DdtAnamnesis();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnamnesisVitae = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.DrugsIntoxication = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CardiovascularSystem = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.InspectionDate = reader.GetDateTime(4);
                        obj.PastSurgeries = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.DiagnosisJustification = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Template = reader.GetBoolean(7);
                        obj.OperationCause = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.AnamnesisEpid = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.UrinarySystem = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.AnamnesisAllergy = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.DigestiveSystem = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.NervousSystem = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Diagnosis = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.CreationDate = reader.GetDateTime(15);
                        obj.Complaints = reader.IsDBNull(16) ? null : reader.GetString(16);
                        obj.OksSt = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.Doctor = reader.IsDBNull(18) ? null : reader.GetString(18);
                        obj.Patient = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.HospitalitySession = reader.IsDBNull(20) ? null : reader.GetString(20);
                        obj.RespiratorySystem = reader.IsDBNull(21) ? null : reader.GetString(21);
                        obj.ModifyDate = reader.GetDateTime(22);
                        obj.StPresens = reader.IsDBNull(23) ? null : reader.GetString(23);
                        obj.TemplateName = reader.IsDBNull(24) ? null : reader.GetString(24);
                        obj.AccompanyingIllnesses = reader.IsDBNull(25) ? null : reader.GetString(25);
                        obj.AnamnesisMorbi = reader.IsDBNull(26) ? null : reader.GetString(26);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtAnamnesis GetByTemplateName(string templateName)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_anamnesis_vitae, dss_drugs_intoxication, dss_cardiovascular_system, dsdt_inspection_date," +
                    " dss_past_surgeries, dss_diagnosis_justification, dsb_template, dss_operation_cause, dss_anamnesis_epid, dss_urinary_system, " +
                    "dss_anamnesis_allergy, dss_digestive_system, dss_nervous_system, dss_diagnosis, r_creation_date, dss_complaints, dss_oks_st, " +
                    "dsid_doctor, dsid_patient, dsid_hospitality_session, dss_respiratory_system, r_modify_date, dss_st_presens, dss_template_name," +
                    " dss_accompanying_illnesses, dss_anamnesis_morbi FROM ddt_anamnesis WHERE dss_template_name = '{0}'", templateName);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtAnamnesis obj = new DdtAnamnesis();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnamnesisVitae = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.DrugsIntoxication = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CardiovascularSystem = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.InspectionDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.PastSurgeries = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.DiagnosisJustification = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Template = reader.GetBoolean(7);
                        obj.OperationCause = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.AnamnesisEpid = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.UrinarySystem = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.AnamnesisAllergy = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.DigestiveSystem = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.NervousSystem = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Diagnosis = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.CreationDate = reader.IsDBNull(15) ? DateTime.MinValue : reader.GetDateTime(15);
                        obj.Complaints = reader.IsDBNull(16) ? null : reader.GetString(16);
                        obj.OksSt = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.Doctor = reader.IsDBNull(18) ? null : reader.GetString(18);
                        obj.Patient = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.HospitalitySession = reader.IsDBNull(20) ? null : reader.GetString(20);
                        obj.RespiratorySystem = reader.IsDBNull(21) ? null : reader.GetString(21);
                        obj.ModifyDate = reader.IsDBNull(22) ? DateTime.MinValue : reader.GetDateTime(22);
                        obj.StPresens = reader.IsDBNull(23) ? null : reader.GetString(23);
                        obj.TemplateName = reader.IsDBNull(24) ? null : reader.GetString(24);
                        obj.AccompanyingIllnesses = reader.IsDBNull(25) ? null : reader.GetString(25);
                        obj.AnamnesisMorbi = reader.IsDBNull(26) ? null : reader.GetString(26);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtAnamnesis obj)
        {
            throw new NotImplementedException();
        }
    }
}
