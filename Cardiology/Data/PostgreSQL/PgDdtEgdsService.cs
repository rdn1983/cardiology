using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtEgdsService : IDdtEgdsService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtEgdsService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtEgds> GetAll()
        {
            IList<DdtEgds> list = new List<DdtEgds>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_egds, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dsid_doctor, dsid_patient FROM ddt_egds";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtEgds obj = new DdtEgds();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Egds = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.AdmissionAnalysis = reader.GetBoolean(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtEgds> GetListByParentId(string parentId)
        {
            IList<DdtEgds> list = new List<DdtEgds>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_egds, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dsid_doctor, dsid_patient FROM ddt_egds WHERE dsid_parent = '{0}'", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtEgds obj = new DdtEgds();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Egds = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.AdmissionAnalysis = reader.GetBoolean(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtEgds GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_egds, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dsid_doctor, dsid_patient FROM ddt_egds WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtEgds obj = new DdtEgds();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Egds = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.AdmissionAnalysis = reader.GetBoolean(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtEgds GetByHospitalSessionAndParentId(string hospitalSession, string parentId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_egds, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dsid_doctor, dsid_patient " +
                                           "FROM ddt_egds WHERE dsid_hospitality_session = '{0}' AND dsid_parent = '{1}'", hospitalSession, parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtEgds obj = new DdtEgds();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Egds = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.AdmissionAnalysis = reader.GetBoolean(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtEgds GetByParentId(string parentId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_egds, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dsid_doctor, dsid_patient " +
                                           "FROM ddt_egds WHERE dsid_parent = '{0}'", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtEgds obj = new DdtEgds();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Egds = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.AdmissionAnalysis = reader.GetBoolean(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtEgds obj)
        {
            throw new NotImplementedException();
        }
    }
}
