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
                        obj.Ketones = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.AnalysisDate = reader.GetDateTime(3);
                        obj.SpecificGravity = reader.GetString(4);
                        obj.Erythrocytes = reader.GetString(5);
                        obj.CreationDate = reader.GetDateTime(6);
                        obj.Parent = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HospitalitySession = reader.GetString(10);
                        obj.Acidity = reader.GetString(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.ParentType = reader.GetString(13);
                        obj.Leukocytes = reader.GetString(14);
                        obj.AdmissionAnalysis = reader.GetBoolean(15);
                        obj.Color = reader.GetString(16);
                        obj.DischargeAnalysis = reader.GetBoolean(17);
                        obj.Protein = reader.GetString(18);
                        obj.Glucose = reader.GetString(19);
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
                        obj.Ketones = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.AnalysisDate = reader.GetDateTime(3);
                        obj.SpecificGravity = reader.GetString(4);
                        obj.Erythrocytes = reader.GetString(5);
                        obj.CreationDate = reader.GetDateTime(6);
                        obj.Parent = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HospitalitySession = reader.GetString(10);
                        obj.Acidity = reader.GetString(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.ParentType = reader.GetString(13);
                        obj.Leukocytes = reader.GetString(14);
                        obj.AdmissionAnalysis = reader.GetBoolean(15);
                        obj.Color = reader.GetString(16);
                        obj.DischargeAnalysis = reader.GetBoolean(17);
                        obj.Protein = reader.GetString(18);
                        obj.Glucose = reader.GetString(19);
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
                        obj.Ketones = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.AnalysisDate = reader.GetDateTime(3);
                        obj.SpecificGravity = reader.GetString(4);
                        obj.Erythrocytes = reader.GetString(5);
                        obj.CreationDate = reader.GetDateTime(6);
                        obj.Parent = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HospitalitySession = reader.GetString(10);
                        obj.Acidity = reader.GetString(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.ParentType = reader.GetString(13);
                        obj.Leukocytes = reader.GetString(14);
                        obj.AdmissionAnalysis = reader.GetBoolean(15);
                        obj.Color = reader.GetString(16);
                        obj.DischargeAnalysis = reader.GetBoolean(17);
                        obj.Protein = reader.GetString(18);
                        obj.Glucose = reader.GetString(19);
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
