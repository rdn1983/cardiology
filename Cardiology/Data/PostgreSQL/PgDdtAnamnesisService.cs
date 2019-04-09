using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;
using NLog;
using System.Globalization;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtAnamnesisService : IDdtAnamnesisService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_anamnesis SET " +
                                        "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsid_patient = @Patient, " +
                                        "dsid_doctor = @Doctor, " +
                                        "dsdt_inspection_date = @InspectionDate, " +
                                        "dss_complaints = @Complaints, " +
                                        "dss_anamnesis_morbi = @AnamnesisMorbi, " +
                                        "dss_anamnesis_vitae = @AnamnesisVitae, " +
                                        "dss_anamnesis_allergy = @AnamnesisAllergy, " +
                                        "dss_anamnesis_epid = @AnamnesisEpid, " +
                                        "dss_past_surgeries = @PastSurgeries, " +
                                        "dss_accompanying_illnesses = @AccompanyingIllnesses, " +
                                        "dss_drugs_intoxication = @DrugsIntoxication, " +
                                        "dss_st_presens = @StPresens, " +
                                        "dss_respiratory_system = @RespiratorySystem, " +
                                        "dss_cardiovascular_system = @CardiovascularSystem, " +
                                        "dss_digestive_system = @DigestiveSystem, " +
                                        "dss_urinary_system = @UrinarySystem, " +
                                        "dss_nervous_system = @NervousSystem, " +
                                        "dss_diagnosis_justification = @DiagnosisJustification, " +
                                        "dss_operation_cause = @OperationCause, " +
                                        "dss_template_name = @TemplateName, " +
                                        "dsb_template = @Template, " +
                                        "dss_diagnosis = @Diagnosis, " +
                                        "dss_oks_st = @OksSt " +
                                         "WHERE r_object_id = @ObjectId";

                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@InspectionDate", obj.InspectionDate);
                        cmd.Parameters.AddWithValue("@Complaints", obj.Complaints == null ? "" : obj.Complaints);
                        cmd.Parameters.AddWithValue("@AnamnesisMorbi", obj.AnamnesisMorbi == null ? "" : obj.AnamnesisMorbi);
                        cmd.Parameters.AddWithValue("@AnamnesisVitae", obj.AnamnesisVitae == null ? "" : obj.AnamnesisVitae);
                        cmd.Parameters.AddWithValue("@AnamnesisAllergy", obj.AnamnesisAllergy == null ? "" : obj.AnamnesisAllergy);
                        cmd.Parameters.AddWithValue("@AnamnesisEpid", obj.AnamnesisEpid == null ? "" : obj.AnamnesisEpid);
                        cmd.Parameters.AddWithValue("@PastSurgeries", obj.PastSurgeries == null ? "" : obj.PastSurgeries);
                        cmd.Parameters.AddWithValue("@AccompanyingIllnesses", obj.AccompanyingIllnesses == null ? "" : obj.AccompanyingIllnesses);
                        cmd.Parameters.AddWithValue("@DrugsIntoxication", obj.DrugsIntoxication == null ? "" : obj.DrugsIntoxication);
                        cmd.Parameters.AddWithValue("@StPresens", obj.StPresens == null ? "" : obj.StPresens);
                        cmd.Parameters.AddWithValue("@RespiratorySystem", obj.RespiratorySystem == null ? "" : obj.RespiratorySystem);
                        cmd.Parameters.AddWithValue("@CardiovascularSystem", obj.CardiovascularSystem == null ? "" : obj.CardiovascularSystem);
                        cmd.Parameters.AddWithValue("@DigestiveSystem", obj.DigestiveSystem == null ? "" : obj.DigestiveSystem);
                        cmd.Parameters.AddWithValue("@UrinarySystem", obj.UrinarySystem == null ? "" : obj.UrinarySystem);
                        cmd.Parameters.AddWithValue("@NervousSystem", obj.NervousSystem == null ? "" : obj.NervousSystem);
                        cmd.Parameters.AddWithValue("@DiagnosisJustification", obj.DiagnosisJustification == null ? "" : obj.DiagnosisJustification);
                        cmd.Parameters.AddWithValue("@OperationCause", obj.OperationCause == null ? "" : obj.OperationCause);
                        cmd.Parameters.AddWithValue("@TemplateName", obj.TemplateName == null ? "" : obj.TemplateName);
                        cmd.Parameters.AddWithValue("@Template", obj.Template);
                        cmd.Parameters.AddWithValue("@Diagnosis", obj.Diagnosis == null ? "" : obj.Diagnosis);
                        cmd.Parameters.AddWithValue("@OksSt", obj.OksSt == null ? "" : obj.OksSt);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_anamnesis(dsid_hospitality_session,dsid_patient,dsid_doctor,dsdt_inspection_date,dss_complaints,dss_anamnesis_morbi,dss_anamnesis_vitae,dss_anamnesis_allergy,dss_anamnesis_epid,dss_past_surgeries,dss_accompanying_illnesses,dss_drugs_intoxication,dss_st_presens,dss_respiratory_system,dss_cardiovascular_system,dss_digestive_system,dss_urinary_system,dss_nervous_system,dss_diagnosis_justification,dss_operation_cause,dss_template_name,dsb_template,dss_diagnosis,dss_oks_st) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@InspectionDate,@Complaints,@AnamnesisMorbi,@AnamnesisVitae,@AnamnesisAllergy,@AnamnesisEpid,@PastSurgeries,@AccompanyingIllnesses,@DrugsIntoxication,@StPresens,@RespiratorySystem,@CardiovascularSystem,@DigestiveSystem,@UrinarySystem,@NervousSystem,@DiagnosisJustification,@OperationCause,@TemplateName,@Template,@Diagnosis,@OksSt) RETURNING r_object_id";

                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@InspectionDate", obj.InspectionDate);
                        cmd.Parameters.AddWithValue("@Complaints", obj.Complaints == null ? "" : obj.Complaints);
                        cmd.Parameters.AddWithValue("@AnamnesisMorbi", obj.AnamnesisMorbi == null ? "" : obj.AnamnesisMorbi);
                        cmd.Parameters.AddWithValue("@AnamnesisVitae", obj.AnamnesisVitae == null ? "" : obj.AnamnesisVitae);
                        cmd.Parameters.AddWithValue("@AnamnesisAllergy", obj.AnamnesisAllergy == null ? "" : obj.AnamnesisAllergy);
                        cmd.Parameters.AddWithValue("@AnamnesisEpid", obj.AnamnesisEpid == null ? "" : obj.AnamnesisEpid);
                        cmd.Parameters.AddWithValue("@PastSurgeries", obj.PastSurgeries == null ? "" : obj.PastSurgeries);
                        cmd.Parameters.AddWithValue("@AccompanyingIllnesses", obj.AccompanyingIllnesses == null ? "" : obj.AccompanyingIllnesses);
                        cmd.Parameters.AddWithValue("@DrugsIntoxication", obj.DrugsIntoxication == null ? "" : obj.DrugsIntoxication);
                        cmd.Parameters.AddWithValue("@StPresens", obj.StPresens == null ? "" : obj.StPresens);
                        cmd.Parameters.AddWithValue("@RespiratorySystem", obj.RespiratorySystem == null ? "" : obj.RespiratorySystem);
                        cmd.Parameters.AddWithValue("@CardiovascularSystem", obj.CardiovascularSystem == null ? "" : obj.CardiovascularSystem);
                        cmd.Parameters.AddWithValue("@DigestiveSystem", obj.DigestiveSystem == null ? "" : obj.DigestiveSystem);
                        cmd.Parameters.AddWithValue("@UrinarySystem", obj.UrinarySystem == null ? "" : obj.UrinarySystem);
                        cmd.Parameters.AddWithValue("@NervousSystem", obj.NervousSystem == null ? "" : obj.NervousSystem);
                        cmd.Parameters.AddWithValue("@DiagnosisJustification", obj.DiagnosisJustification == null ? "" : obj.DiagnosisJustification);
                        cmd.Parameters.AddWithValue("@OperationCause", obj.OperationCause == null ? "" : obj.OperationCause);
                        cmd.Parameters.AddWithValue("@TemplateName", obj.TemplateName == null ? "" : obj.TemplateName);
                        cmd.Parameters.AddWithValue("@Template", obj.Template);
                        cmd.Parameters.AddWithValue("@Diagnosis", obj.Diagnosis == null ? "" : obj.Diagnosis);
                        cmd.Parameters.AddWithValue("@OksSt", obj.OksSt == null ? "" : obj.OksSt);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }
    }
}
