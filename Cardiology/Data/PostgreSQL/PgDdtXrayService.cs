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
    public class PgDdtXrayService : IDdtXrayService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtXrayService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtXRay> GetAll()
        {
            IList<DdtXRay> list = new List<DdtXRay>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsdt_analysis_date, dss_mskt, r_creation_date, dss_kt, dsid_parent, dss_chest_xray, dsid_doctor, dsid_patient, dsid_hospitality_session, r_modify_date, dss_parent_type, dss_mrt, dss_control_radiography, dsdt_kt_date FROM ddt_xray";
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtXRay obj = new DdtXRay();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.Mskt = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Kt = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.ChestXray = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Mrt = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.ControlRadiography = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.KtDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtXRay> GetByParentId(string parentId)
        {
            IList<DdtXRay> list = new List<DdtXRay>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT zr.r_object_id, dsdt_analysis_date, dss_mskt, r_creation_date, dss_kt, rel.dsid_parent, dss_chest_xray, " +
                    "dsid_doctor, dsid_patient, dsid_hospitality_session, r_modify_date, zr.dss_parent_type, dss_mrt, dss_control_radiography, dsdt_kt_date " +
                    "FROM ddt_xray zr, ddt_relation rel WHERE rel.dsid_parent = '{0}' AND rel.dsid_child=zr.r_object_id", parentId);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtXRay obj = new DdtXRay();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.Mskt = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Kt = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.ChestXray = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Mrt = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.ControlRadiography = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.KtDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtXRay GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dss_mskt, r_creation_date, dss_kt, dsid_parent, dss_chest_xray, dsid_doctor, dsid_patient, dsid_hospitality_session, r_modify_date, dss_parent_type, dss_mrt, dss_control_radiography, dsdt_kt_date FROM ddt_xray WHERE r_object_id = '{0}'", id);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtXRay obj = new DdtXRay();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.Mskt = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Kt = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.ChestXray = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Mrt = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.ControlRadiography = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.KtDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        return obj;
                    }
                }
            }
            return null;
        }
        

        public string Save(DdtXRay obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_xray SET " +
                                          "dsid_hospitality_session = @HospitalitySession, " +
                                            "dsid_patient = @Patient, " +
                                            "dsid_doctor = @Doctor, " +
                                            "dsdt_analysis_date = @AnalysisDate, " +
                                            "dss_chest_xray = @ChestXray, " +
                                            "dss_control_radiography = @ControlRadiography, " +
                                            "dss_mskt = @Mskt, " +
                                            "dss_kt = @Kt, " +
                                            "dss_mrt = @Mrt, " +
                                            "dsdt_kt_date = @KtDate, " +
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
                        cmd.Parameters.AddWithValue("@ChestXray", obj.ChestXray == null ? "" : obj.ChestXray);
                        cmd.Parameters.AddWithValue("@ControlRadiography", obj.ControlRadiography == null ? "" : obj.ControlRadiography);
                        cmd.Parameters.AddWithValue("@Mskt", obj.Mskt == null ? "" : obj.Mskt);
                        cmd.Parameters.AddWithValue("@Kt", obj.Kt == null ? "" : obj.Kt);
                        cmd.Parameters.AddWithValue("@Mrt", obj.Mrt == null ? "" : obj.Mrt);
                        cmd.Parameters.AddWithValue("@KtDate", obj.KtDate);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_xray(dsid_hospitality_session,dsid_patient,dsid_doctor,dsdt_analysis_date,dss_chest_xray,dss_control_radiography,dss_mskt,dss_kt,dss_mrt,dsdt_kt_date,dsid_parent,dss_parent_type) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@AnalysisDate,@ChestXray,@ControlRadiography,@Mskt,@Kt,@Mrt,@KtDate,@Parent,@ParentType) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@ChestXray", obj.ChestXray == null ? "" : obj.ChestXray);
                        cmd.Parameters.AddWithValue("@ControlRadiography", obj.ControlRadiography == null ? "" : obj.ControlRadiography);
                        cmd.Parameters.AddWithValue("@Mskt", obj.Mskt == null ? "" : obj.Mskt);
                        cmd.Parameters.AddWithValue("@Kt", obj.Kt == null ? "" : obj.Kt);
                        cmd.Parameters.AddWithValue("@Mrt", obj.Mrt == null ? "" : obj.Mrt);
                        cmd.Parameters.AddWithValue("@KtDate", obj.KtDate);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
