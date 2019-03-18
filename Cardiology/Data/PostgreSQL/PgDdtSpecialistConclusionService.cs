using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtSpecialistConclusionService : IDdtSpecialistConclusionService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtSpecialistConclusionService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtSpecialistConclusion> GetAll()
        {
            IList<DdtSpecialistConclusion> list = new List<DdtSpecialistConclusion>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsdt_analysis_date, r_creation_date, dsid_parent, dss_neuro_surgeon, dsid_doctor, dsid_patient, dss_endocrinologist, dsid_hospitality_session, r_modify_date, dss_parent_type, dss_neurolog, dss_surgeon FROM ddt_specialist_conclusion";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtSpecialistConclusion obj = new DdtSpecialistConclusion();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Parent = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.NeuroSurgeon = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Doctor = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Patient = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Endocrinologist = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.ModifyDate = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                        obj.ParentType = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Neurolog = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Surgeon = reader.IsDBNull(12) ? null : reader.GetString(12);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtSpecialistConclusion> GetListByParentId(string parentId)
        {
            IList<DdtSpecialistConclusion> list = new List<DdtSpecialistConclusion>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, r_creation_date, dsid_parent, dss_neuro_surgeon, dsid_doctor, dsid_patient, dss_endocrinologist, dsid_hospitality_session, r_modify_date, dss_parent_type, dss_neurolog, dss_surgeon FROM ddt_specialist_conclusion WHERE dsid_patient = '{0}'", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtSpecialistConclusion obj = new DdtSpecialistConclusion();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Parent = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.NeuroSurgeon = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Doctor = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Patient = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Endocrinologist = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.ModifyDate = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                        obj.ParentType = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Neurolog = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Surgeon = reader.IsDBNull(12) ? null : reader.GetString(12);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public List<DdtSpecialistConclusion> GetByQuery(string sql)
        {
            List<DdtSpecialistConclusion> list = new List<DdtSpecialistConclusion>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtSpecialistConclusion obj = new DdtSpecialistConclusion();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Parent = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.NeuroSurgeon = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Doctor = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Patient = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Endocrinologist = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.ModifyDate = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                        obj.ParentType = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Neurolog = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Surgeon = reader.IsDBNull(12) ? null : reader.GetString(12);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtSpecialistConclusion GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, r_creation_date, dsid_parent, dss_neuro_surgeon, dsid_doctor, dsid_patient, dss_endocrinologist, dsid_hospitality_session, r_modify_date, dss_parent_type, dss_neurolog, dss_surgeon FROM ddt_specialist_conclusion WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtSpecialistConclusion obj = new DdtSpecialistConclusion();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Parent = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.NeuroSurgeon = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Doctor = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Patient = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Endocrinologist = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.ModifyDate = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                        obj.ParentType = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Neurolog = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Surgeon = reader.IsDBNull(12) ? null : reader.GetString(12);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtSpecialistConclusion obj)
        {
            throw new NotImplementedException();
        }

    }
}
