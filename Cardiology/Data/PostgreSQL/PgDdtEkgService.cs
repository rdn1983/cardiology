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
    public class PgDdtEkgService : IDdtEkgService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, " +
                    "r_modify_date, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dss_ekg, " +
                    "dsid_doctor, dsid_patient FROM ddt_ekg WHERE dsid_parent = '{0}'", parentId);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

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
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_ekg SET " +
                                          "dsid_hospitality_session = @HospitalitySession, " +
                                            "dsid_patient = @Patient, " +
                                            "dsid_doctor = @Doctor, " +
                                            "dss_ekg = @Ekg, " +
                                            "dsb_admission_analysis = @AdmissionAnalysis, " +
                                            "dsid_parent = @Parent, " +
                                            "dsdt_analysis_date = @AnalysisDate, " +
                                            "dss_parent_type = @ParentType " +
                                             "WHERE r_object_id = @ObjectId";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Ekg", obj.Ekg == null ? "" : obj.Ekg);
                        cmd.Parameters.AddWithValue("@AdmissionAnalysis", obj.AdmissionAnalysis);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_ekg(dsid_hospitality_session,dsid_patient,dsid_doctor,dss_ekg,dsb_admission_analysis,dsid_parent,dsdt_analysis_date,dss_parent_type) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@Ekg,@AdmissionAnalysis,@Parent,@AnalysisDate,@ParentType) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Ekg", obj.Ekg == null ? "" : obj.Ekg);
                        cmd.Parameters.AddWithValue("@AdmissionAnalysis", obj.AdmissionAnalysis);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }



    }
}
