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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.EndTime = reader.GetDateTime(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.Parent = reader.GetString(5);
                        obj.KagManipulation = reader.GetString(6);
                        obj.Doctor = reader.GetString(7);
                        obj.Patient = reader.GetString(8);
                        obj.HospitalitySession = reader.GetString(9);
                        obj.StartTime = reader.GetDateTime(10);
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.ParentType = reader.GetString(12);
                        obj.Results = reader.GetString(13);
                        obj.KagAction = reader.GetString(14);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.EndTime = reader.GetDateTime(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.Parent = reader.GetString(5);
                        obj.KagManipulation = reader.GetString(6);
                        obj.Doctor = reader.GetString(7);
                        obj.Patient = reader.GetString(8);
                        obj.HospitalitySession = reader.GetString(9);
                        obj.StartTime = reader.GetDateTime(10);
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.ParentType = reader.GetString(12);
                        obj.Results = reader.GetString(13);
                        obj.KagAction = reader.GetString(14);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.EndTime = reader.GetDateTime(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.Parent = reader.GetString(5);
                        obj.KagManipulation = reader.GetString(6);
                        obj.Doctor = reader.GetString(7);
                        obj.Patient = reader.GetString(8);
                        obj.HospitalitySession = reader.GetString(9);
                        obj.StartTime = reader.GetDateTime(10);
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.ParentType = reader.GetString(12);
                        obj.Results = reader.GetString(13);
                        obj.KagAction = reader.GetString(14);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.EndTime = reader.GetDateTime(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.Parent = reader.GetString(5);
                        obj.KagManipulation = reader.GetString(6);
                        obj.Doctor = reader.GetString(7);
                        obj.Patient = reader.GetString(8);
                        obj.HospitalitySession = reader.GetString(9);
                        obj.StartTime = reader.GetDateTime(10);
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.ParentType = reader.GetString(12);
                        obj.Results = reader.GetString(13);
                        obj.KagAction = reader.GetString(14);
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
