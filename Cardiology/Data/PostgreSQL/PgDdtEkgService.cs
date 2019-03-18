using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtEkgService : IDdtEkgService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtEkgService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtEkg> GetAll()
        {
            IList<DdtEkg> list = new List<DdtEkg>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dss_ekg, dsid_doctor, dsid_patient FROM ddt_ekg";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtEkg obj = new DdtEkg();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ParentType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Parent = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.AdmissionAnalysis = reader.GetBoolean(7);
                        obj.Ekg = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtEkg> GetListByParentId(string parentId)
        {
            IList<DdtEkg> list = new List<DdtEkg>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dss_ekg, dsid_doctor, dsid_patient FROM ddt_ekg WHERE dsid_parent = '{0}'", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtEkg obj = new DdtEkg();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ParentType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Parent = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.AdmissionAnalysis = reader.GetBoolean(7);
                        obj.Ekg = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public List<DdtEkg> GetByQuery(string sql)
        {
            List<DdtEkg> list = new List<DdtEkg>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtEkg obj = new DdtEkg();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ParentType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Parent = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.AdmissionAnalysis = reader.GetBoolean(7);
                        obj.Ekg = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtEkg GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dss_ekg, dsid_doctor, dsid_patient FROM ddt_ekg WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtEkg obj = new DdtEkg();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ParentType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Parent = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.AdmissionAnalysis = reader.GetBoolean(7);
                        obj.Ekg = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtEkg GetByHospitalSessionAndParentId(string hospitalSession, string parentId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dss_ekg, dsid_doctor, dsid_patient " +
                                           "FROM ddt_ekg WHERE dsid_hospitality_session = '{0}' AND dsid_parent = '{1}'", hospitalSession, parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtEkg obj = new DdtEkg();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ParentType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Parent = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.AdmissionAnalysis = reader.GetBoolean(7);
                        obj.Ekg = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtEkg GetByParentId(string parentId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dss_ekg, dsid_doctor, dsid_patient " +
                                           "FROM ddt_ekg WHERE dsid_hospitality_session = '{0}'", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtEkg obj = new DdtEkg();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ParentType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Parent = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.AdmissionAnalysis = reader.GetBoolean(7);
                        obj.Ekg = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtEkg GetByHospitalSession(string hospitalSession)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dss_ekg, dsid_doctor, dsid_patient " +
                                           "FROM ddt_ekg WHERE dsid_hospitality_session = '{0}' ", hospitalSession);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtEkg obj = new DdtEkg();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ParentType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Parent = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.AdmissionAnalysis = reader.GetBoolean(7);
                        obj.Ekg = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtEkg GetByHospitalSessionAndAdmission(string hospitalSession, bool admissionAnalysis)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dss_ekg, dsid_doctor, dsid_patient " +
                                           "FROM ddt_ekg WHERE dsid_hospitality_session = '{0}' and dsb_admission_analysis='{1}' ", hospitalSession, admissionAnalysis);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtEkg obj = new DdtEkg();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ParentType = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Parent = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.AdmissionAnalysis = reader.GetBoolean(7);
                        obj.Ekg = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtEkg obj)
        {
            throw new NotImplementedException();
        }

        
    }
}
