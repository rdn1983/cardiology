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
    public class PgDdtUziService : IDdtUziService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtUziService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtUzi> GetAll()
        {
            IList<DdtUzi> list = new List<DdtUzi>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsdt_analysis_date, dss_eho_kg, r_creation_date, dss_pleurs_uzi, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_uzd_bca, r_modify_date, dss_parent_type, dss_cds, dss_uzi_obp FROM ddt_uzi";
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtUzi obj = new DdtUzi();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EhoKg = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.PleursUzi = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.UzdBca = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Cds = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.UziObp = reader.IsDBNull(13) ? null : reader.GetString(13);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtUzi GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dss_eho_kg, r_creation_date, dss_pleurs_uzi, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_uzd_bca, r_modify_date, dss_parent_type, dss_cds, dss_uzi_obp FROM ddt_uzi WHERE r_object_id = '{0}'", id);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtUzi obj = new DdtUzi();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EhoKg = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.PleursUzi = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.UzdBca = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Cds = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.UziObp = reader.IsDBNull(13) ? null : reader.GetString(13);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtUzi GetByParentId(string parentId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dss_eho_kg, r_creation_date, " +
                    "dss_pleurs_uzi, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_uzd_bca," +
                    " r_modify_date, dss_parent_type, dss_cds, dss_uzi_obp FROM ddt_uzi WHERE dsid_parent = '{0}'", parentId);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtUzi obj = new DdtUzi();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EhoKg = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.PleursUzi = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.UzdBca = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Cds = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.UziObp = reader.IsDBNull(13) ? null : reader.GetString(13);
                        return obj;
                    }
                }
            }
            return null;
        }

        public IList<DdtUzi> GetListByParentId(string parentId)
        {
            IList<DdtUzi> list = new List<DdtUzi>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dss_eho_kg, r_creation_date, " +
                    "dss_pleurs_uzi, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_uzd_bca, " +
                    "r_modify_date, dss_parent_type, dss_cds, dss_uzi_obp FROM ddt_uzi WHERE dsid_parent = '{0}'", parentId);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtUzi obj = new DdtUzi();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EhoKg = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.PleursUzi = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.UzdBca = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Cds = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.UziObp = reader.IsDBNull(13) ? null : reader.GetString(13);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public List<DdtUzi> GetByQuery(string sql)
        {
            List<DdtUzi> list = new List<DdtUzi>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtUzi obj = new DdtUzi();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EhoKg = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.PleursUzi = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.UzdBca = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Cds = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.UziObp = reader.IsDBNull(13) ? null : reader.GetString(13);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public string Save(DdtUzi obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_uzi SET " +
                                          "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsid_patient = @Patient, " +
                                        "dsid_doctor = @Doctor, " +
                                        "dsdt_analysis_date = @AnalysisDate, " +
                                        "dss_eho_kg = @EhoKg, " +
                                        "dss_uzd_bca = @UzdBca, " +
                                        "dss_cds = @Cds, " +
                                        "dss_uzi_obp = @UziObp, " +
                                        "dss_pleurs_uzi = @PleursUzi, " +
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
                        cmd.Parameters.AddWithValue("@EhoKg", obj.EhoKg == null ? "" : obj.EhoKg);
                        cmd.Parameters.AddWithValue("@UzdBca", obj.UzdBca == null ? "" : obj.UzdBca);
                        cmd.Parameters.AddWithValue("@Cds", obj.Cds == null ? "" : obj.Cds);
                        cmd.Parameters.AddWithValue("@UziObp", obj.UziObp == null ? "" : obj.UziObp);
                        cmd.Parameters.AddWithValue("@PleursUzi", obj.PleursUzi == null ? "" : obj.PleursUzi);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_uzi(dsid_hospitality_session,dsid_patient,dsid_doctor,dsdt_analysis_date,dss_eho_kg,dss_uzd_bca,dss_cds,dss_uzi_obp,dss_pleurs_uzi,dsid_parent,dss_parent_type) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@AnalysisDate,@EhoKg,@UzdBca,@Cds,@UziObp,@PleursUzi,@Parent,@ParentType) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@EhoKg", obj.EhoKg == null ? "" : obj.EhoKg);
                        cmd.Parameters.AddWithValue("@UzdBca", obj.UzdBca == null ? "" : obj.UzdBca);
                        cmd.Parameters.AddWithValue("@Cds", obj.Cds == null ? "" : obj.Cds);
                        cmd.Parameters.AddWithValue("@UziObp", obj.UziObp == null ? "" : obj.UziObp);
                        cmd.Parameters.AddWithValue("@PleursUzi", obj.PleursUzi == null ? "" : obj.PleursUzi);
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent == null ? "0000000000000000" : obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
