using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtSerologyService : IDdtSerologyService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtSerologyService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtSerology> GetAll()
        {
            IList<DdtSerology> list = new List<DdtSerology>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsdt_analysis_date, dss_blood_type, r_creation_date, dss_kell_ag, dss_phenotype, dss_rw, dsid_doctor, dsid_patient, dss_hbs_ag, dss_anti_hcv, dsid_hospitality_session, r_modify_date, dss_hiv, dss_rhesus_factor FROM ddt_serology";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtSerology obj = new DdtSerology();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.BloodType = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.KellAg = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Phenotype = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Rw = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HbsAg = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.AntiHcv = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.HospitalitySession = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.ModifyDate = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                        obj.Hiv = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.RhesusFactor = reader.IsDBNull(14) ? null : reader.GetString(14);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtSerology GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dss_blood_type, r_creation_date, dss_kell_ag, dss_phenotype, dss_rw, dsid_doctor, dsid_patient, dss_hbs_ag, dss_anti_hcv, dsid_hospitality_session, r_modify_date, dss_hiv, dss_rhesus_factor FROM ddt_serology WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtSerology obj = new DdtSerology();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.BloodType = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.KellAg = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Phenotype = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Rw = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HbsAg = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.AntiHcv = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.HospitalitySession = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.ModifyDate = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                        obj.Hiv = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.RhesusFactor = reader.IsDBNull(14) ? null : reader.GetString(14);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtSerology GetByHospitalSession(string hospitalSession)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dss_blood_type, r_creation_date, dss_kell_ag, dss_phenotype, dss_rw, dsid_doctor, dsid_patient, dss_hbs_ag, dss_anti_hcv, dsid_hospitality_session, r_modify_date, dss_hiv, dss_rhesus_factor FROM ddt_serology WHERE dsid_hospitality_session = '{0}'", hospitalSession);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtSerology obj = new DdtSerology();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.BloodType = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.KellAg = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Phenotype = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Rw = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HbsAg = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.AntiHcv = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.HospitalitySession = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.ModifyDate = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                        obj.Hiv = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.RhesusFactor = reader.IsDBNull(14) ? null : reader.GetString(14);
                        return obj;
                    }
                }
            }
            return null;
        }

        public void Save(DdtSerology obj)
        {
            if (string.IsNullOrEmpty(obj.ObjectId))
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
