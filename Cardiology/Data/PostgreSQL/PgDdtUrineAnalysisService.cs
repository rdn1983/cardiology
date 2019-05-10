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
    public class PgDdtUrineAnalysisService : IDdtUrineAnalysisService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtUrineAnalysisService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtUrineAnalysis> GetAll()
        {
            IList<DdtUrineAnalysis> list = new List<DdtUrineAnalysis>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dss_ketones, r_object_id, dsdt_analysis_date, dss_specific_gravity, dss_erythrocytes, r_creation_date, " +
                    "dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_acidity, r_modify_date, dss_parent_type, dss_leukocytes, " +
                    "dsb_admission_analysis, dss_color, dsb_discharge_analysis, dss_protein, dss_glucose FROM ddt_urine_analysis";
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtUrineAnalysis obj = new DdtUrineAnalysis();
                        obj.Ketones = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.SpecificGravity = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Erythrocytes = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Parent = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Acidity = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.ParentType = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.Leukocytes = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.AdmissionAnalysis = reader.GetBoolean(14);
                        obj.Color = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.DischargeAnalysis = reader.GetBoolean(16);
                        obj.Protein = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.Glucose = reader.IsDBNull(18) ? null : reader.GetString(18);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtUrineAnalysis GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dss_ketones, r_object_id, dsdt_analysis_date, dss_specific_gravity, dss_erythrocytes, r_creation_date," +
                    " dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_acidity, r_modify_date, dss_parent_type, dss_leukocytes, " +
                    "dsb_admission_analysis, dss_color, dsb_discharge_analysis, dss_protein, dss_glucose FROM ddt_urine_analysis WHERE r_object_id = '{0}'", id);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtUrineAnalysis obj = new DdtUrineAnalysis();
                        obj.Ketones = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.SpecificGravity = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Erythrocytes = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Parent = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Acidity = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.ParentType = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.Leukocytes = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.AdmissionAnalysis = reader.GetBoolean(14);
                        obj.Color = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.DischargeAnalysis = reader.GetBoolean(16);
                        obj.Protein = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.Glucose = reader.IsDBNull(18) ? null : reader.GetString(18);
                        return obj;
                    }
                }
            }
            return null;
        }

        public IList<DdtUrineAnalysis> GetByParentId(string parentId)
        {
            IList<DdtUrineAnalysis> list = new List<DdtUrineAnalysis>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dss_ketones, ur.r_object_id, dsdt_analysis_date, dss_specific_gravity, dss_erythrocytes, r_creation_date, rel.dsid_parent, dsid_doctor, " +
                    "dsid_patient, dsid_hospitality_session, dss_acidity, r_modify_date, ur.dss_parent_type, dss_leukocytes, dsb_admission_analysis, dss_color, dsb_discharge_analysis, " +
                    "dss_protein, dss_glucose FROM ddt_urine_analysis ur, ddt_relation rel WHERE rel.dsid_parent = '{0}' AND rel.dsid_child=ur.r_object_id", parentId);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtUrineAnalysis obj = new DdtUrineAnalysis();
                        obj.Ketones = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.SpecificGravity = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Erythrocytes = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Parent = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Acidity = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.ParentType = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.Leukocytes = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.AdmissionAnalysis = reader.GetBoolean(14);
                        obj.Color = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.DischargeAnalysis = reader.GetBoolean(16);
                        obj.Protein = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.Glucose = reader.IsDBNull(18) ? null : reader.GetString(18);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public string Save(DdtUrineAnalysis obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_urine_analysis SET " +
                                          "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsid_patient = @Patient, " +
                                        "dsid_doctor = @Doctor, " +
                                        "dsdt_analysis_date = @AnalysisDate, " +
                                        "dss_color = @Color, " +
                                        "dss_acidity = @Acidity, " +
                                        "dss_specific_gravity = @SpecificGravity, " +
                                        "dss_leukocytes = @Leukocytes, " +
                                        "dss_erythrocytes = @Erythrocytes, " +
                                        "dss_glucose = @Glucose, " +
                                        "dss_protein = @Protein, " +
                                        "dss_ketones = @Ketones, " +
                                        "dsb_admission_analysis = @AdmissionAnalysis, " +
                                        "dsb_discharge_analysis = @DischargeAnalysis, " +
                                        "dsid_parent = @Parent, " +
                                        "dss_parent_type = @ParentType " +
                                         "WHERE r_object_id = @ObjectId";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@Color", obj.Color == null ? "" : obj.Color);
                        cmd.Parameters.AddWithValue("@Acidity", obj.Acidity == null ? "" : obj.Acidity);
                        cmd.Parameters.AddWithValue("@SpecificGravity", obj.SpecificGravity == null ? "" : obj.SpecificGravity);
                        cmd.Parameters.AddWithValue("@Leukocytes", obj.Leukocytes == null ? "" : obj.Leukocytes);
                        cmd.Parameters.AddWithValue("@Erythrocytes", obj.Erythrocytes == null ? "" : obj.Erythrocytes);
                        cmd.Parameters.AddWithValue("@Glucose", obj.Glucose == null ? "" : obj.Glucose);
                        cmd.Parameters.AddWithValue("@Protein", obj.Protein == null ? "" : obj.Protein);
                        cmd.Parameters.AddWithValue("@Ketones", obj.Ketones == null ? "" : obj.Ketones);
                        cmd.Parameters.AddWithValue("@AdmissionAnalysis", obj.AdmissionAnalysis);
                        cmd.Parameters.AddWithValue("@DischargeAnalysis", obj.DischargeAnalysis);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_urine_analysis(dsid_hospitality_session,dsid_patient,dsid_doctor,dsdt_analysis_date,dss_color,dss_acidity,dss_specific_gravity,dss_leukocytes,dss_erythrocytes,dss_glucose,dss_protein,dss_ketones,dsb_admission_analysis,dsb_discharge_analysis,dsid_parent,dss_parent_type) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@AnalysisDate,@Color,@Acidity,@SpecificGravity,@Leukocytes,@Erythrocytes,@Glucose,@Protein,@Ketones,@AdmissionAnalysis,@DischargeAnalysis,@Parent,@ParentType) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@Color", obj.Color == null ? "" : obj.Color);
                        cmd.Parameters.AddWithValue("@Acidity", obj.Acidity == null ? "" : obj.Acidity);
                        cmd.Parameters.AddWithValue("@SpecificGravity", obj.SpecificGravity == null ? "" : obj.SpecificGravity);
                        cmd.Parameters.AddWithValue("@Leukocytes", obj.Leukocytes == null ? "" : obj.Leukocytes);
                        cmd.Parameters.AddWithValue("@Erythrocytes", obj.Erythrocytes == null ? "" : obj.Erythrocytes);
                        cmd.Parameters.AddWithValue("@Glucose", obj.Glucose == null ? "" : obj.Glucose);
                        cmd.Parameters.AddWithValue("@Protein", obj.Protein == null ? "" : obj.Protein);
                        cmd.Parameters.AddWithValue("@Ketones", obj.Ketones == null ? "" : obj.Ketones);
                        cmd.Parameters.AddWithValue("@AdmissionAnalysis", obj.AdmissionAnalysis);
                        cmd.Parameters.AddWithValue("@DischargeAnalysis", obj.DischargeAnalysis);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
