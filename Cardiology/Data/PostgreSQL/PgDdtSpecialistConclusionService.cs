using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;
using NLog;
using System.Globalization;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtSpecialistConclusionService : IDdtSpecialistConclusionService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, r_creation_date, dsid_parent, " +
                    "dss_neuro_surgeon, dsid_doctor, dsid_patient, dss_endocrinologist, dsid_hospitality_session," +
                    " r_modify_date, dss_parent_type, dss_neurolog, dss_surgeon FROM ddt_specialist_conclusion" +
                    " WHERE dsid_parent = '{0}'", parentId);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, r_creation_date, dsid_parent, " +
                    "dss_neuro_surgeon, dsid_doctor, dsid_patient, dss_endocrinologist, dsid_hospitality_session," +
                    " r_modify_date, dss_parent_type, dss_neurolog, dss_surgeon FROM ddt_specialist_conclusion" +
                    " WHERE r_object_id = '{0}'", id);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_specialist_conclusion SET " +
                                          "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsid_patient = @Patient, " +
                                        "dsid_doctor = @Doctor, " +
                                        "dsdt_analysis_date = @AnalysisDate, " +
                                        "dss_neurolog = @Neurolog, " +
                                        "dss_surgeon = @Surgeon, " +
                                        "dss_neuro_surgeon = @NeuroSurgeon, " +
                                        "dss_endocrinologist = @Endocrinologist, " +
                                        "dsid_parent = @Parent, " +
                                        "dss_parent_type = @ParentType " +
                                         "WHERE r_object_id = @ObjectId";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@Neurolog", obj.Neurolog == null ? "" : obj.Neurolog);
                        cmd.Parameters.AddWithValue("@Surgeon", obj.Surgeon == null ? "" : obj.Surgeon);
                        cmd.Parameters.AddWithValue("@NeuroSurgeon", obj.NeuroSurgeon == null ? "" : obj.NeuroSurgeon);
                        cmd.Parameters.AddWithValue("@Endocrinologist", obj.Endocrinologist == null ? "" : obj.Endocrinologist);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_specialist_conclusion(dsid_hospitality_session,dsid_patient,dsid_doctor,dsdt_analysis_date,dss_neurolog,dss_surgeon,dss_neuro_surgeon,dss_endocrinologist,dsid_parent,dss_parent_type) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@AnalysisDate,@Neurolog,@Surgeon,@NeuroSurgeon,@Endocrinologist,@Parent,@ParentType) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@Neurolog", obj.Neurolog == null ? "" : obj.Neurolog);
                        cmd.Parameters.AddWithValue("@Surgeon", obj.Surgeon == null ? "" : obj.Surgeon);
                        cmd.Parameters.AddWithValue("@NeuroSurgeon", obj.NeuroSurgeon == null ? "" : obj.NeuroSurgeon);
                        cmd.Parameters.AddWithValue("@Endocrinologist", obj.Endocrinologist == null ? "" : obj.Endocrinologist);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }


    }
}
