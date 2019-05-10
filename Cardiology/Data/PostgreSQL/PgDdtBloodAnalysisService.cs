using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;
using NLog;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtBloodAnalysisService : IDdtBloodAnalysisService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtBloodAnalysisService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtBloodAnalysis> GetAll()
        {
            String sql = "SELECT r_object_id, dss_alt, dss_creatinine, dss_platelets, dss_hemoglobin, dss_chlorine, dss_leucocytes, dss_potassium," +
                    " dss_parent_type, dss_kfk, dss_kfk_mv, dss_sodium, dsb_admission_analysis, dss_srp, dsb_discharge_analysis, dss_amylase, dsdt_analysis_date, " +
                    "dss_cholesterol, dss_schf, dss_bil, dss_iron, r_creation_date, dss_ast, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session," +
                    " r_modify_date, dss_protein FROM ddt_blood_analysis";
            IList<DdtBloodAnalysis> result = GetByQuery(sql);
            return result;
        }

        public DdtBloodAnalysis GetById(string id)
        {
            String sql = String.Format("SELECT r_object_id, dss_alt, dss_creatinine, dss_platelets, dss_hemoglobin, dss_chlorine, dss_leucocytes, dss_potassium, " +
                "dss_parent_type, dss_kfk, dss_kfk_mv, dss_sodium, dsb_admission_analysis, dss_srp, dsb_discharge_analysis, dss_amylase, dsdt_analysis_date, " +
                "dss_cholesterol, dss_schf, dss_bil, dss_iron, r_creation_date, dss_ast, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, " +
                "r_modify_date, dss_protein FROM ddt_blood_analysis WHERE r_object_id = '{0}'", id);
            IList<DdtBloodAnalysis> result = GetByQuery(sql);
            return result.Count > 0 ? result[0] : null;
        }

        public IList<DdtBloodAnalysis> GetByParentId(string parentId)
        {
            String sql = String.Format("SELECT an.r_object_id, dss_alt, dss_creatinine, dss_platelets, dss_hemoglobin, dss_chlorine, dss_leucocytes, dss_potassium, " +
                "an.dss_parent_type, dss_kfk, dss_kfk_mv, dss_sodium, dsb_admission_analysis, dss_srp, dsb_discharge_analysis, dss_amylase, dsdt_analysis_date, " +
                "dss_cholesterol, dss_schf, dss_bil, dss_iron, r_creation_date, dss_ast, rel.dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, " +
                "r_modify_date, dss_protein FROM ddt_blood_analysis an, ddt_relation rel WHERE rel.dsid_parent = '{0}' AND rel.dsid_child=an.r_object_id", parentId);
            IList<DdtBloodAnalysis> result = GetByQuery(sql);
            return result;
        }

        public DdtBloodAnalysis GetByHospitalSession(string hospitalSession)
        {
            String sql = String.Format("SELECT r_object_id, dss_alt, dss_creatinine, dss_platelets, dss_hemoglobin, dss_chlorine, dss_leucocytes, dss_potassium, " +
                "dss_parent_type, dss_kfk, dss_kfk_mv, dss_sodium, dsb_admission_analysis, dss_srp, dsb_discharge_analysis, dss_amylase, dsdt_analysis_date, " +
                "dss_cholesterol, dss_schf, dss_bil, dss_iron, r_creation_date, dss_ast, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, " +
                "r_modify_date, dss_protein FROM ddt_blood_analysis WHERE dsid_hospitality_session = '{0}' order by r_creation_date desc ", hospitalSession);
            IList<DdtBloodAnalysis> result = GetByQuery(sql);
            return result.Count > 0 ? result[0] : null;
        }

        public List<DdtBloodAnalysis> GetByQuery(string sql)
        {
            List<DdtBloodAnalysis> list = new List<DdtBloodAnalysis>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtBloodAnalysis obj = new DdtBloodAnalysis();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Alt = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Creatinine = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.Platelets = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Hemoglobin = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Chlorine = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Leucocytes = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Potassium = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.ParentType = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Kfk = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.KfkMv = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Sodium = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.AdmissionAnalysis = reader.GetBoolean(12);
                        obj.Srp = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.DischargeAnalysis = reader.GetBoolean(14);
                        obj.Amylase = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.AnalysisDate = reader.IsDBNull(16) ? DateTime.MinValue : reader.GetDateTime(16);
                        obj.Cholesterol = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.Schf = reader.IsDBNull(18) ? null : reader.GetString(18);
                        obj.Bil = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.Iron = reader.IsDBNull(20) ? null : reader.GetString(20);
                        obj.CreationDate = reader.IsDBNull(21) ? DateTime.MinValue : reader.GetDateTime(21);
                        obj.Ast = reader.IsDBNull(22) ? null : reader.GetString(22);
                        obj.Parent = reader.IsDBNull(23) ? null : reader.GetString(23);
                        obj.Doctor = reader.IsDBNull(24) ? null : reader.GetString(24);
                        obj.Patient = reader.IsDBNull(25) ? null : reader.GetString(25);
                        obj.HospitalitySession = reader.IsDBNull(26) ? null : reader.GetString(26);
                        obj.ModifyDate = reader.IsDBNull(27) ? DateTime.MinValue : reader.GetDateTime(27);
                        obj.Protein = reader.IsDBNull(28) ? null : reader.GetString(28);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public string Save(DdtBloodAnalysis obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_blood_analysis SET " +
                                        "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsid_patient = @Patient, " +
                                        "dsid_doctor = @Doctor, " +
                                        "dss_hemoglobin = @Hemoglobin, " +
                                        "dss_leucocytes = @Leucocytes, " +
                                        "dss_platelets = @Platelets, " +
                                        "dss_protein = @Protein, " +
                                        "dss_creatinine = @Creatinine, " +
                                        "dss_cholesterol = @Cholesterol, " +
                                        "dss_bil = @Bil, " +
                                        "dss_iron = @Iron, " +
                                        "dss_alt = @Alt, " +
                                        "dss_ast = @Ast, " +
                                        "dss_schf = @Schf, " +
                                        "dss_amylase = @Amylase, " +
                                        "dss_kfk = @Kfk, " +
                                        "dss_kfk_mv = @KfkMv, " +
                                        "dss_srp = @Srp, " +
                                        "dss_potassium = @Potassium, " +
                                        "dss_sodium = @Sodium, " +
                                        "dss_chlorine = @Chlorine, " +
                                        "dsb_admission_analysis = @AdmissionAnalysis, " +
                                        "dsb_discharge_analysis = @DischargeAnalysis, " +
                                        "dsdt_analysis_date = @AnalysisDate, " +
                                        "dsid_parent = @Parent, " +
                                        "dss_parent_type = @ParentType " +
                                         "WHERE r_object_id = @ObjectId";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Hemoglobin", obj.Hemoglobin == null ? "" : obj.Hemoglobin);
                        cmd.Parameters.AddWithValue("@Leucocytes", obj.Leucocytes == null ? "" : obj.Leucocytes);
                        cmd.Parameters.AddWithValue("@Platelets", obj.Platelets == null ? "" : obj.Platelets);
                        cmd.Parameters.AddWithValue("@Protein", obj.Protein == null ? "" : obj.Protein);
                        cmd.Parameters.AddWithValue("@Creatinine", obj.Creatinine == null ? "" : obj.Creatinine);
                        cmd.Parameters.AddWithValue("@Cholesterol", obj.Cholesterol == null ? "" : obj.Cholesterol);
                        cmd.Parameters.AddWithValue("@Bil", obj.Bil == null ? "" : obj.Bil);
                        cmd.Parameters.AddWithValue("@Iron", obj.Iron == null ? "" : obj.Iron);
                        cmd.Parameters.AddWithValue("@Alt", obj.Alt == null ? "" : obj.Alt);
                        cmd.Parameters.AddWithValue("@Ast", obj.Ast == null ? "" : obj.Ast);
                        cmd.Parameters.AddWithValue("@Schf", obj.Schf == null ? "" : obj.Schf);
                        cmd.Parameters.AddWithValue("@Amylase", obj.Amylase == null ? "" : obj.Amylase);
                        cmd.Parameters.AddWithValue("@Kfk", obj.Kfk == null ? "" : obj.Kfk);
                        cmd.Parameters.AddWithValue("@KfkMv", obj.KfkMv == null ? "" : obj.KfkMv);
                        cmd.Parameters.AddWithValue("@Srp", obj.Srp == null ? "" : obj.Srp);
                        cmd.Parameters.AddWithValue("@Potassium", obj.Potassium == null ? "" : obj.Potassium);
                        cmd.Parameters.AddWithValue("@Sodium", obj.Sodium == null ? "" : obj.Sodium);
                        cmd.Parameters.AddWithValue("@Chlorine", obj.Chlorine == null ? "" : obj.Chlorine);
                        cmd.Parameters.AddWithValue("@AdmissionAnalysis", obj.AdmissionAnalysis);
                        cmd.Parameters.AddWithValue("@DischargeAnalysis", obj.DischargeAnalysis);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_blood_analysis(dsid_hospitality_session,dsid_patient,dsid_doctor,dss_hemoglobin,dss_leucocytes,dss_platelets,dss_protein,dss_creatinine,dss_cholesterol,dss_bil,dss_iron,dss_alt,dss_ast,dss_schf,dss_amylase,dss_kfk,dss_kfk_mv,dss_srp,dss_potassium,dss_sodium,dss_chlorine,dsb_admission_analysis,dsb_discharge_analysis,dsdt_analysis_date,dsid_parent,dss_parent_type) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@Hemoglobin,@Leucocytes,@Platelets,@Protein,@Creatinine,@Cholesterol,@Bil,@Iron,@Alt,@Ast,@Schf,@Amylase,@Kfk,@KfkMv,@Srp,@Potassium,@Sodium,@Chlorine,@AdmissionAnalysis,@DischargeAnalysis,@AnalysisDate,@Parent,@ParentType) RETURNING r_object_id";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Hemoglobin", obj.Hemoglobin == null ? "" : obj.Hemoglobin);
                        cmd.Parameters.AddWithValue("@Leucocytes", obj.Leucocytes == null ? "" : obj.Leucocytes);
                        cmd.Parameters.AddWithValue("@Platelets", obj.Platelets == null ? "" : obj.Platelets);
                        cmd.Parameters.AddWithValue("@Protein", obj.Protein == null ? "" : obj.Protein);
                        cmd.Parameters.AddWithValue("@Creatinine", obj.Creatinine == null ? "" : obj.Creatinine);
                        cmd.Parameters.AddWithValue("@Cholesterol", obj.Cholesterol == null ? "" : obj.Cholesterol);
                        cmd.Parameters.AddWithValue("@Bil", obj.Bil == null ? "" : obj.Bil);
                        cmd.Parameters.AddWithValue("@Iron", obj.Iron == null ? "" : obj.Iron);
                        cmd.Parameters.AddWithValue("@Alt", obj.Alt == null ? "" : obj.Alt);
                        cmd.Parameters.AddWithValue("@Ast", obj.Ast == null ? "" : obj.Ast);
                        cmd.Parameters.AddWithValue("@Schf", obj.Schf == null ? "" : obj.Schf);
                        cmd.Parameters.AddWithValue("@Amylase", obj.Amylase == null ? "" : obj.Amylase);
                        cmd.Parameters.AddWithValue("@Kfk", obj.Kfk == null ? "" : obj.Kfk);
                        cmd.Parameters.AddWithValue("@KfkMv", obj.KfkMv == null ? "" : obj.KfkMv);
                        cmd.Parameters.AddWithValue("@Srp", obj.Srp == null ? "" : obj.Srp);
                        cmd.Parameters.AddWithValue("@Potassium", obj.Potassium == null ? "" : obj.Potassium);
                        cmd.Parameters.AddWithValue("@Sodium", obj.Sodium == null ? "" : obj.Sodium);
                        cmd.Parameters.AddWithValue("@Chlorine", obj.Chlorine == null ? "" : obj.Chlorine);
                        cmd.Parameters.AddWithValue("@AdmissionAnalysis", obj.AdmissionAnalysis);
                        cmd.Parameters.AddWithValue("@DischargeAnalysis", obj.DischargeAnalysis);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
