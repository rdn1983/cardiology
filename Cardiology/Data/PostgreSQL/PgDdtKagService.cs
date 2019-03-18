using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtKagService : IDdtKagService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtKagService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtKag> GetAll()
        {
            IList<DdtKag> list = new List<DdtKag>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsdt_analysis_date, dsdt_end_time, r_creation_date, dsid_parent, dss_kag_manipulation, dsid_doctor, dsid_patient, dsid_hospitality_session, dsdt_start_time, r_modify_date, dss_parent_type, dss_results, dss_kag_action FROM ddt_kag";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtKag obj = new DdtKag();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EndTime = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Parent = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.KagManipulation = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.StartTime = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Results = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.KagAction = reader.IsDBNull(13) ? null : reader.GetString(13);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtKag GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dsdt_end_time, r_creation_date, dsid_parent, dss_kag_manipulation, dsid_doctor, dsid_patient, dsid_hospitality_session, dsdt_start_time, r_modify_date, dss_parent_type, dss_results, dss_kag_action FROM ddt_kag WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtKag obj = new DdtKag();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EndTime = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Parent = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.KagManipulation = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.StartTime = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Results = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.KagAction = reader.IsDBNull(13) ? null : reader.GetString(13);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtKag GetByParentId(string parentId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dsdt_end_time, r_creation_date, dsid_parent, dss_kag_manipulation, dsid_doctor, dsid_patient, dsid_hospitality_session, dsdt_start_time, r_modify_date, dss_parent_type, dss_results, dss_kag_action FROM ddt_kag WHERE dsid_parent = '{0}'", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtKag obj = new DdtKag();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EndTime = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Parent = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.KagManipulation = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.StartTime = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Results = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.KagAction = reader.IsDBNull(13) ? null : reader.GetString(13);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtKag GetByHospitalSession(string hospitalSession)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dsdt_end_time, r_creation_date, dsid_parent, dss_kag_manipulation, dsid_doctor, dsid_patient, dsid_hospitality_session, dsdt_start_time, r_modify_date, dss_parent_type, dss_results, dss_kag_action FROM ddt_kag WHERE dsid_hospitality_session = '{0}'", hospitalSession);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtKag obj = new DdtKag();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EndTime = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Parent = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.KagManipulation = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.StartTime = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Results = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.KagAction = reader.IsDBNull(13) ? null : reader.GetString(13);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtKag obj)
        {
            throw new NotImplementedException();
        }
    }
}
