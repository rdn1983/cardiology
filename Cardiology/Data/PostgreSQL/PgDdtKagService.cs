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
    public class PgDdtKagService : IDdtKagService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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

        public IList<DdtKag> GetByParentId(string parentId)
        {
            IList<DdtKag> list = new List<DdtKag>();
            if (parentId == null)
            {
                return list;
            }
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT ka.r_object_id, dsdt_analysis_date, dsdt_end_time, r_creation_date, rel.dsid_parent, dss_kag_manipulation, dsid_doctor, " +
                    "dsid_patient, dsid_hospitality_session, dsdt_start_time, r_modify_date, ka.dss_parent_type, dss_results, dss_kag_action " +
                    "FROM ddt_kag ka, ddt_relation rel WHERE rel.dsid_parent = '{0}' AND rel.dsid_child=ka.r_object_id", parentId);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtKag> GetByQuery(string sql)
        {
            IList<DdtKag> list = new List<DdtKag>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtKag GetByHospitalSession2(string hospitalSession)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dsdt_end_time, r_creation_date, dsid_parent, dss_kag_manipulation, dsid_doctor, dsid_patient, dsid_hospitality_session, dsdt_start_time, r_modify_date, dss_parent_type, dss_results, dss_kag_action FROM ddt_kag WHERE dsid_hospitality_session = '{0}'", hospitalSession);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_kag SET " +
                                          "dsid_hospitality_session = @HospitalitySession, " +
                                            "dsid_patient = @Patient, " +
                                            "dsid_doctor = @Doctor, " +
                                            "dsdt_analysis_date = @AnalysisDate, " +
                                            "dss_results = @Results, " +
                                            "dsdt_start_time = @StartTime, " +
                                            "dsdt_end_time = @EndTime, " +
                                            "dss_kag_manipulation = @KagManipulation, " +
                                            "dss_kag_action = @KagAction, " +
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
                        cmd.Parameters.AddWithValue("@Results", obj.Results == null ? "" : obj.Results);
                        cmd.Parameters.AddWithValue("@StartTime", obj.StartTime);
                        cmd.Parameters.AddWithValue("@EndTime", obj.EndTime);
                        cmd.Parameters.AddWithValue("@KagManipulation", obj.KagManipulation == null ? "" : obj.KagManipulation);
                        cmd.Parameters.AddWithValue("@KagAction", obj.KagAction == null ? "" : obj.KagAction);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_kag(dsid_hospitality_session,dsid_patient,dsid_doctor,dsdt_analysis_date,dss_results,dsdt_start_time,dsdt_end_time,dss_kag_manipulation,dss_kag_action,dsid_parent,dss_parent_type) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@AnalysisDate,@Results,@StartTime,@EndTime,@KagManipulation,@KagAction,@Parent,@ParentType) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@Results", obj.Results == null ? "" : obj.Results);
                        cmd.Parameters.AddWithValue("@StartTime", obj.StartTime);
                        cmd.Parameters.AddWithValue("@EndTime", obj.EndTime);
                        cmd.Parameters.AddWithValue("@KagManipulation", obj.KagManipulation == null ? "" : obj.KagManipulation);
                        cmd.Parameters.AddWithValue("@KagAction", obj.KagAction == null ? "" : obj.KagAction);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
