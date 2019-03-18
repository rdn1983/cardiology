using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtUrineAnalysisService : IDdtUrineAnalysisService
    {
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
                String sql = "SELECT dss_ketones, r_object_id, dsdt_analysis_date, dss_specific_gravity, dss_erythrocytes, r_creation_date, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_acidity, r_modify_date, dss_parent_type, dss_leukocytes, dsb_admission_analysis, dss_color, dsb_discharge_analysis, dss_protein, dss_glucose FROM ddt_urine_analysis";
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
                String sql = String.Format("SELECT dss_ketones, r_object_id, dsdt_analysis_date, dss_specific_gravity, dss_erythrocytes, r_creation_date, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_acidity, r_modify_date, dss_parent_type, dss_leukocytes, dsb_admission_analysis, dss_color, dsb_discharge_analysis, dss_protein, dss_glucose FROM ddt_urine_analysis WHERE r_object_id = '{0}'", id);
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

        public DdtUrineAnalysis GetByHospitalSessionAndParentId(string hospitalSession, string parentId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dss_ketones, r_object_id, dsdt_analysis_date, dss_specific_gravity, dss_erythrocytes, r_creation_date, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_acidity, r_modify_date, dss_parent_type, dss_leukocytes, dsb_admission_analysis, dss_color, dsb_discharge_analysis, dss_protein, dss_glucose " +
                                           "FROM ddt_urine_analysis WHERE dsid_hospitality_session = '{0}' AND dsid_parent = '{1}'", hospitalSession, parentId);
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

        public string Save(DdtUrineAnalysis obj)
        {
            throw new NotImplementedException();
        }
    }
}
