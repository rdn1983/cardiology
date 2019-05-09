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
    public class PgDdtHolterService : IDdtHolterService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtHolterService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtHolter> GetAll()
        {
            IList<DdtHolter> list = new List<DdtHolter>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date," +
                    " dss_monitoring_ad, dss_parent_type, r_creation_date, dsid_parent, dss_holter, dsid_doctor," +
                    " dsid_patient FROM ddt_holter";

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtHolter obj = new DdtHolter();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.MonitoringAd = reader.IsDBNull(0) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(0) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Holter = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtHolter GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, " +
                    "r_modify_date, dss_monitoring_ad, dss_parent_type, r_creation_date, dsid_parent, dss_holter," +
                    " dsid_doctor, dsid_patient FROM ddt_holter WHERE r_object_id = '{0}'", id);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtHolter obj = new DdtHolter();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.MonitoringAd = reader.IsDBNull(0) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(0) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Holter = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        return obj;
                    }
                }
            }
            return null;
        }

        public IList<DdtHolter> GetByParentId(string parentId)
        {
            IList<DdtHolter> list = new List<DdtHolter>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, " +
                    "r_modify_date, dss_monitoring_ad, dss_parent_type, r_creation_date, dsid_parent, dss_holter, " +
                    "dsid_doctor, dsid_patient FROM ddt_holter ho, ddt_relation rel WHERE rel.dsid_parent = '{0}' AND rel.dsid_child=ho.r_object_id", parentId);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtHolter obj = new DdtHolter();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.MonitoringAd = reader.IsDBNull(0) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(0) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Holter = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public string Save(DdtHolter obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_holter SET " +
                                          "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsid_patient = @Patient, " +
                                        "dsid_doctor = @Doctor, " +
                                        "dsid_parent = @Parent, " +
                                        "dss_parent_type = @ParentType, " +
                                        "dsdt_analysis_date = @AnalysisDate, " +
                                        "dss_holter = @Holter, " +
                                        "dss_monitoring_ad = @MonitoringAd " +
                                         "WHERE r_object_id = @ObjectId";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@Holter", obj.Holter == null ? "" : obj.Holter);
                        cmd.Parameters.AddWithValue("@MonitoringAd", obj.MonitoringAd == null ? "" : obj.MonitoringAd);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_holter(dsid_hospitality_session,dsid_patient,dsid_doctor,dsid_parent,dss_parent_type,dsdt_analysis_date,dss_holter,dss_monitoring_ad) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@Parent,@ParentType,@AnalysisDate,@Holter,@MonitoringAd) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@Holter", obj.Holter == null ? "" : obj.Holter);
                        cmd.Parameters.AddWithValue("@MonitoringAd", obj.MonitoringAd == null ? "" : obj.MonitoringAd);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
