using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtBloodAnalysisService : IDdtBloodAnalysisService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtBloodAnalysisService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtBloodAnalysis> GetAll()
        {
            IList<DdtBloodAnalysis> list = new List<DdtBloodAnalysis>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dss_alt, dss_creatinine, dss_platelets, dss_hemoglobin, dss_chlorine, dss_leucocytes, dss_potassium," +
                    " dss_parent_type, dss_kfk, dss_kfk_mv, dss_sodium, dsb_admission_analysis, dss_srp, dsb_discharge_analysis, dss_amylase, dsdt_analysis_date, " +
                    "dss_cholesterol, dss_schf, dss_bil, dss_iron, r_creation_date, dss_ast, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session," +
                    " r_modify_date, dss_protein FROM ddt_blood_analysis";
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

        public DdtBloodAnalysis GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_alt, dss_creatinine, dss_platelets, dss_hemoglobin, dss_chlorine, dss_leucocytes, dss_potassium, dss_parent_type, dss_kfk, dss_kfk_mv, dss_sodium, dsb_admission_analysis, dss_srp, dsb_discharge_analysis, dss_amylase, dsdt_analysis_date, dss_cholesterol, dss_schf, dss_bil, dss_iron, r_creation_date, dss_ast, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, r_modify_date, dss_protein FROM ddt_blood_analysis WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
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
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtBloodAnalysis GetByHospitalSessionAndParentId(string hospitalSession, string parentId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_alt, dss_creatinine, dss_platelets, dss_hemoglobin, dss_chlorine, dss_leucocytes, dss_potassium, dss_parent_type, dss_kfk, dss_kfk_mv, dss_sodium, dsb_admission_analysis, dss_srp, dsb_discharge_analysis, dss_amylase, dsdt_analysis_date, dss_cholesterol, dss_schf, dss_bil, dss_iron, r_creation_date, dss_ast, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, r_modify_date, dss_protein " +
                                           "FROM ddt_blood_analysis WHERE dsid_hospitality_session = '{0}' AND dsid_parent = '{1}'", hospitalSession, parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
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
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtBloodAnalysis GetByParentId(string parentId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_alt, dss_creatinine, dss_platelets, dss_hemoglobin, dss_chlorine, dss_leucocytes, dss_potassium, dss_parent_type, dss_kfk, dss_kfk_mv, dss_sodium, dsb_admission_analysis, dss_srp, dsb_discharge_analysis, dss_amylase, dsdt_analysis_date, dss_cholesterol, dss_schf, dss_bil, dss_iron, r_creation_date, dss_ast, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, r_modify_date, dss_protein " +
                                           "FROM ddt_blood_analysis WHERE dsid_parent = '{0}'", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
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
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtBloodAnalysis GetByHospitalSession(string hospitalSession)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_alt, dss_creatinine, dss_platelets, dss_hemoglobin, dss_chlorine, dss_leucocytes, dss_potassium, dss_parent_type, dss_kfk, dss_kfk_mv, dss_sodium, dsb_admission_analysis, dss_srp, dsb_discharge_analysis, dss_amylase, dsdt_analysis_date, dss_cholesterol, dss_schf, dss_bil, dss_iron, r_creation_date, dss_ast, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, r_modify_date, dss_protein " +
                                           "FROM ddt_blood_analysis WHERE dsid_hospitality_session = '{0}' order by r_creation_date desc ", hospitalSession);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
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
                        return obj;
                    }
                }
            }
            return null;
        }

        public IList<DdtBloodAnalysis> GetListByParenId(string parentId)
        {
            IList<DdtBloodAnalysis> list = new List<DdtBloodAnalysis>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_alt, dss_creatinine, dss_platelets, dss_hemoglobin, dss_chlorine, dss_leucocytes, " +
                    "dss_potassium, dss_parent_type, dss_kfk, dss_kfk_mv, dss_sodium, dsb_admission_analysis, dss_srp, dsb_discharge_analysis, dss_amylase, " +
                    "dsdt_analysis_date, dss_cholesterol, dss_schf, dss_bil, dss_iron, r_creation_date, dss_ast, dsid_parent, dsid_doctor, dsid_patient," +
                    " dsid_hospitality_session, r_modify_date, dss_protein " +
                    "FROM ddt_blood_analysis WHERE dsid_parent = '{0}' order by r_creation_date desc ", parentId);
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
            throw new NotImplementedException();
        }
    }
}
