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
    public class PgDdtOncologicMarkersService : IDdtOncologicMarkersService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtOncologicMarkersService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtOncologicMarkers> GetAll()
        {
            IList<DdtOncologicMarkers> list = new List<DdtOncologicMarkers>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsdt_analysis_date, r_creation_date, dss_cea, dsid_parent, dss_psa_common, dss_psa_free, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_hgch, r_modify_date, dss_parent_type, dss_ca_125, dss_ca_199, dss_ca_153, dss_afr FROM ddt_oncologic_markers";

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtOncologicMarkers obj = new DdtOncologicMarkers();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Cea = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Parent = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.PsaCommon = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.PsaFree = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Hgch = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.ParentType = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.Ca125 = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Ca199 = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.Ca153 = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.Afr = reader.IsDBNull(16) ? null : reader.GetString(16);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtOncologicMarkers GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, r_creation_date, dss_cea, dsid_parent, dss_psa_common, dss_psa_free, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_hgch, r_modify_date, dss_parent_type, dss_ca_125, dss_ca_199, dss_ca_153, dss_afr FROM ddt_oncologic_markers WHERE r_object_id = '{0}'", id);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtOncologicMarkers obj = new DdtOncologicMarkers();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Cea = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Parent = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.PsaCommon = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.PsaFree = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Hgch = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.ParentType = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.Ca125 = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Ca199 = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.Ca153 = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.Afr = reader.IsDBNull(16) ? null : reader.GetString(16);
                        return obj;
                    }
                }
            }
            return null;
        }

        public IList<DdtOncologicMarkers> GetByParentId(string parentId)
        {
            IList<DdtOncologicMarkers> list = new List<DdtOncologicMarkers>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT ma.r_object_id, dsdt_analysis_date, r_creation_date, dss_cea, rel.dsid_parent, dss_psa_common, dss_psa_free, dsid_doctor, " +
                    "dsid_patient, dsid_hospitality_session, dss_hgch, r_modify_date, ma.dss_parent_type, dss_ca_125, dss_ca_199, dss_ca_153, dss_afr " +
                    "FROM ddt_oncologic_markers ma, ddt_relation rel WHERE rel.dsid_parent = '{0}' AND rel.dsid_child=ma.r_object_id", parentId);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtOncologicMarkers obj = new DdtOncologicMarkers();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Cea = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Parent = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.PsaCommon = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.PsaFree = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Hgch = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.ParentType = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.Ca125 = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Ca199 = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.Ca153 = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.Afr = reader.IsDBNull(16) ? null : reader.GetString(16);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public string Save(DdtOncologicMarkers obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_oncologic_markers SET " +
                                          "dsid_doctor = @Doctor, " +
                                        "dsid_patient = @Patient, " +
                                        "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsdt_analysis_date = @AnalysisDate, " +
                                        "dsid_parent = @Parent, " +
                                        "dss_parent_type = @ParentType, " +
                                        "dss_psa_common = @PsaCommon, " +
                                        "dss_psa_free = @PsaFree, " +
                                        "dss_ca_199 = @Ca199, " +
                                        "dss_ca_125 = @Ca125, " +
                                        "dss_ca_153 = @Ca153, " +
                                        "dss_cea = @Cea, " +
                                        "dss_hgch = @Hgch, " +
                                        "dss_afr = @Afr " +
                                         "WHERE r_object_id = @ObjectId";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@PsaCommon", obj.PsaCommon == null ? "" : obj.PsaCommon);
                        cmd.Parameters.AddWithValue("@PsaFree", obj.PsaFree == null ? "" : obj.PsaFree);
                        cmd.Parameters.AddWithValue("@Ca199", obj.Ca199 == null ? "" : obj.Ca199);
                        cmd.Parameters.AddWithValue("@Ca125", obj.Ca125 == null ? "" : obj.Ca125);
                        cmd.Parameters.AddWithValue("@Ca153", obj.Ca153 == null ? "" : obj.Ca153);
                        cmd.Parameters.AddWithValue("@Cea", obj.Cea == null ? "" : obj.Cea);
                        cmd.Parameters.AddWithValue("@Hgch", obj.Hgch == null ? "" : obj.Hgch);
                        cmd.Parameters.AddWithValue("@Afr", obj.Afr == null ? "" : obj.Afr);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_oncologic_markers(dsid_doctor,dsid_patient,dsid_hospitality_session,dsdt_analysis_date,dsid_parent,dss_parent_type,dss_psa_common,dss_psa_free,dss_ca_199,dss_ca_125,dss_ca_153,dss_cea,dss_hgch,dss_afr) " +
                                                              "VALUES(@Doctor,@Patient,@HospitalitySession,@AnalysisDate,@Parent,@ParentType,@PsaCommon,@PsaFree,@Ca199,@Ca125,@Ca153,@Cea,@Hgch,@Afr) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@PsaCommon", obj.PsaCommon == null ? "" : obj.PsaCommon);
                        cmd.Parameters.AddWithValue("@PsaFree", obj.PsaFree == null ? "" : obj.PsaFree);
                        cmd.Parameters.AddWithValue("@Ca199", obj.Ca199 == null ? "" : obj.Ca199);
                        cmd.Parameters.AddWithValue("@Ca125", obj.Ca125 == null ? "" : obj.Ca125);
                        cmd.Parameters.AddWithValue("@Ca153", obj.Ca153 == null ? "" : obj.Ca153);
                        cmd.Parameters.AddWithValue("@Cea", obj.Cea == null ? "" : obj.Cea);
                        cmd.Parameters.AddWithValue("@Hgch", obj.Hgch == null ? "" : obj.Hgch);
                        cmd.Parameters.AddWithValue("@Afr", obj.Afr == null ? "" : obj.Afr);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
