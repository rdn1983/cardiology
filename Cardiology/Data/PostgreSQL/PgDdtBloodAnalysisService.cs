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
                String sql = "SELECT r_object_id, dss_alt, dss_creatinine, dss_platelets, dss_hemoglobin, dss_chlorine, dss_leucocytes, dss_potassium, dss_parent_type, dss_kfk, dss_kfk_mv, dss_sodium, dsb_admission_analysis, dss_srp, dsb_discharge_analysis, dss_amylase, dsdt_analysis_date, dss_cholesterol, dss_schf, dss_bil, dss_iron, r_creation_date, dss_ast, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, r_modify_date, dss_protein FROM ddt_blood_analysis";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtBloodAnalysis obj = new DdtBloodAnalysis();
                        obj.ObjectId = reader.GetString(1);
                        obj.Alt = reader.GetString(2);
                        obj.Creatinine = reader.GetString(3);
                        obj.Platelets = reader.GetString(4);
                        obj.Hemoglobin = reader.GetString(5);
                        obj.Chlorine = reader.GetString(6);
                        obj.Leucocytes = reader.GetString(7);
                        obj.Potassium = reader.GetString(8);
                        obj.ParentType = reader.GetString(9);
                        obj.Kfk = reader.GetString(10);
                        obj.KfkMv = reader.GetString(11);
                        obj.Sodium = reader.GetString(12);
                        obj.AdmissionAnalysis = reader.GetBoolean(13);
                        obj.Srp = reader.GetString(14);
                        obj.DischargeAnalysis = reader.GetBoolean(15);
                        obj.Amylase = reader.GetString(16);
                        obj.AnalysisDate = reader.GetDateTime(17);
                        obj.Cholesterol = reader.GetString(18);
                        obj.Schf = reader.GetString(19);
                        obj.Bil = reader.GetString(20);
                        obj.Iron = reader.GetString(21);
                        obj.CreationDate = reader.GetDateTime(22);
                        obj.Ast = reader.GetString(23);
                        obj.Parent = reader.GetString(24);
                        obj.Doctor = reader.GetString(25);
                        obj.Patient = reader.GetString(26);
                        obj.HospitalitySession = reader.GetString(27);
                        obj.ModifyDate = reader.GetDateTime(28);
                        obj.Protein = reader.GetString(29);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.Alt = reader.GetString(2);
                        obj.Creatinine = reader.GetString(3);
                        obj.Platelets = reader.GetString(4);
                        obj.Hemoglobin = reader.GetString(5);
                        obj.Chlorine = reader.GetString(6);
                        obj.Leucocytes = reader.GetString(7);
                        obj.Potassium = reader.GetString(8);
                        obj.ParentType = reader.GetString(9);
                        obj.Kfk = reader.GetString(10);
                        obj.KfkMv = reader.GetString(11);
                        obj.Sodium = reader.GetString(12);
                        obj.AdmissionAnalysis = reader.GetBoolean(13);
                        obj.Srp = reader.GetString(14);
                        obj.DischargeAnalysis = reader.GetBoolean(15);
                        obj.Amylase = reader.GetString(16);
                        obj.AnalysisDate = reader.GetDateTime(17);
                        obj.Cholesterol = reader.GetString(18);
                        obj.Schf = reader.GetString(19);
                        obj.Bil = reader.GetString(20);
                        obj.Iron = reader.GetString(21);
                        obj.CreationDate = reader.GetDateTime(22);
                        obj.Ast = reader.GetString(23);
                        obj.Parent = reader.GetString(24);
                        obj.Doctor = reader.GetString(25);
                        obj.Patient = reader.GetString(26);
                        obj.HospitalitySession = reader.GetString(27);
                        obj.ModifyDate = reader.GetDateTime(28);
                        obj.Protein = reader.GetString(29);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
