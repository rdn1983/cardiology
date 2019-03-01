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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.BloodType = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.KellAg = reader.GetString(5);
                        obj.Phenotype = reader.GetString(6);
                        obj.Rw = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HbsAg = reader.GetString(10);
                        obj.AntiHcv = reader.GetString(11);
                        obj.HospitalitySession = reader.GetString(12);
                        obj.ModifyDate = reader.GetDateTime(13);
                        obj.Hiv = reader.GetString(14);
                        obj.RhesusFactor = reader.GetString(15);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.BloodType = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.KellAg = reader.GetString(5);
                        obj.Phenotype = reader.GetString(6);
                        obj.Rw = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HbsAg = reader.GetString(10);
                        obj.AntiHcv = reader.GetString(11);
                        obj.HospitalitySession = reader.GetString(12);
                        obj.ModifyDate = reader.GetDateTime(13);
                        obj.Hiv = reader.GetString(14);
                        obj.RhesusFactor = reader.GetString(15);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.BloodType = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.KellAg = reader.GetString(5);
                        obj.Phenotype = reader.GetString(6);
                        obj.Rw = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HbsAg = reader.GetString(10);
                        obj.AntiHcv = reader.GetString(11);
                        obj.HospitalitySession = reader.GetString(12);
                        obj.ModifyDate = reader.GetDateTime(13);
                        obj.Hiv = reader.GetString(14);
                        obj.RhesusFactor = reader.GetString(15);
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
