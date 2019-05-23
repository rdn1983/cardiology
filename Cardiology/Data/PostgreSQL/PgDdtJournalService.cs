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
    public class PgDdtJournalService : IDdtJournalService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtJournalService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public List<DdtJournal> GetByQuery(string sql)
        {
            List<DdtJournal> list = new List<DdtJournal>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtJournal obj = new DdtJournal();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Diagnosis = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Chss = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.Chdd = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.CreationDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.Complaints = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.SurgeonExam = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Ekg = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.AdmissionDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.Monitor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Rhythm = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.JournalDayId = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Ps = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.Ad = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.ModifyDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        obj.CardioExam = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.JournalType = reader.IsDBNull(16) ? -1 : reader.GetInt16(16);
                        obj.GoodRhythm = reader.GetBoolean(17);
                        obj.ReleaseJournal = reader.GetBoolean(18);
                        obj.Journal = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.Doctor = reader.GetString(20);
                        obj.Freeze = reader.IsDBNull(21)? false: reader.GetBoolean(21);
                        obj.Weight = reader.IsDBNull(22)? 0 : reader.GetDouble(22);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtJournal> GetAll()
        {
            String sql = "SELECT r_object_id, dss_diagnosis, dss_chss, dss_chdd, r_creation_date, dss_complaints, dss_surgeon_exam, " +
                    "dss_ekg, dsdt_admission_date, dss_monitor, dss_rhythm, dsid_journal_day, dss_ps, dss_ad, r_modify_date, " +
                    "dss_cardio_exam, dsi_journal_type, dsb_good_rhythm, dsb_release_journal, dss_journal, dsid_doctor, dsb_freeze, dsd_weight FROM ddt_journal";
            IList<DdtJournal> list = GetByQuery(sql);
            return list;
        }

        public DdtJournal GetObject(string sql)
        {
            IList<DdtJournal> result = GetByQuery(sql);
            return result.Count > 0 ? result[0] : null;
        }

        public DdtJournal GetById(string id)
        {
            String sql = String.Format("SELECT r_object_id, dss_diagnosis, dss_chss, dss_chdd, r_creation_date, dss_complaints, dss_surgeon_exam, " +
                    "dss_ekg, dsdt_admission_date, dss_monitor, dss_rhythm, dsid_journal_day, dss_ps, dss_ad, r_modify_date, dss_cardio_exam, dsi_journal_type, " +
                    "dsb_good_rhythm, dsb_release_journal, dss_journal, dsid_doctor, dsb_freeze, dsd_weight FROM ddt_journal WHERE r_object_id = '{0}'", id);
            IList<DdtJournal> result = GetByQuery(sql);
            return result.Count > 0 ? result[0] : null;
        }

        public DdtJournal GetByHospitalSessionAndJournalType(string hospitalSession, int jornalType)
        {
            String sql = String.Format("SELECT r_object_id, dss_diagnosis, dss_chss, dss_chdd, r_creation_date, dss_complaints, dss_surgeon_exam, " +
                    "dss_ekg, dsdt_admission_date, dss_monitor, dss_rhythm, dsid_journal_day, dss_ps, dss_ad, r_modify_date, dss_cardio_exam, dsi_journal_type, " +
                    "dsb_good_rhythm, dsb_release_journal, dss_journal, dsid_doctor, dsb_freeze, dsd_weight FROM ddt_journal " +
                    "WHERE dsid_hospitality_session = '{0}' AND dsi_journal_type = {1} ", hospitalSession, jornalType);
            IList<DdtJournal> result = GetByQuery(sql);
            return result.Count > 0 ? result[0] : null;
        }

        public List<DdtJournal> GetByJournalDayId(string id)
        {
            String sql = String.Format("SELECT r_object_id, dss_diagnosis, dss_chss, dss_chdd, r_creation_date, dss_complaints, dss_surgeon_exam, " +
                    "dss_ekg, dsdt_admission_date, dss_monitor, dss_rhythm, dsid_journal_day, dss_ps, dss_ad, r_modify_date, dss_cardio_exam, dsi_journal_type, " +
                    "dsb_good_rhythm, dsb_release_journal, dss_journal, dsid_doctor, dsb_freeze, dsd_weight FROM ddt_journal " +
                    "WHERE dsid_journal_day = '{0}'  ORDER BY dsdt_admission_date asc", id);
            List<DdtJournal> result = GetByQuery(sql);
            return result;
        }

        public string Save(DdtJournal obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_journal SET " +
                                        "dsdt_admission_date = @AdmissionDate, " +
                                        "dsid_journal_day = @JournalDay, " +
                                        "dss_complaints = @Complaints, " +
                                        "dss_chdd = @Chdd, " +
                                        "dss_chss = @Chss, " +
                                        "dss_ps = @Ps, " +
                                        "dss_ad = @Ad, " +
                                        "dss_monitor = @Monitor, " +
                                        "dss_rhythm = @Rhythm, " +
                                        "dsb_good_rhythm = @GoodRhythm, " +
                                        "dss_surgeon_exam = @SurgeonExam, " +
                                        "dss_cardio_exam = @CardioExam, " +
                                        "dss_ekg = @Ekg, " +
                                        "dss_journal = @Journal, " +
                                        "dsi_journal_type = @JournalType, " +
                                        "dsb_release_journal = @ReleaseJournal, " +
                                        "dss_diagnosis = @Diagnosis, " +
                                        "dsid_doctor = @Doctor, " +
                                        "dsb_freeze = @Freeze, " +
                                        "dsd_weight = @Weight " +
                                         "WHERE r_object_id = @ObjectId";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@AdmissionDate", obj.AdmissionDate);
                        cmd.Parameters.AddWithValue("@JournalDay", obj.JournalDayId);
                        cmd.Parameters.AddWithValue("@Complaints", obj.Complaints == null ? "" : obj.Complaints);
                        cmd.Parameters.AddWithValue("@Chdd", obj.Chdd == null ? "" : obj.Chdd);
                        cmd.Parameters.AddWithValue("@Chss", obj.Chss == null ? "" : obj.Chss);
                        cmd.Parameters.AddWithValue("@Ps", obj.Ps == null ? "" : obj.Ps);
                        cmd.Parameters.AddWithValue("@Ad", obj.Ad == null ? "" : obj.Ad);
                        cmd.Parameters.AddWithValue("@Monitor", obj.Monitor == null ? "" : obj.Monitor);
                        cmd.Parameters.AddWithValue("@Rhythm", obj.Rhythm == null ? "" : obj.Rhythm);
                        cmd.Parameters.AddWithValue("@GoodRhythm", obj.GoodRhythm);
                        cmd.Parameters.AddWithValue("@SurgeonExam", obj.SurgeonExam == null ? "" : obj.SurgeonExam);
                        cmd.Parameters.AddWithValue("@CardioExam", obj.CardioExam == null ? "" : obj.CardioExam);
                        cmd.Parameters.AddWithValue("@Ekg", obj.Ekg == null ? "" : obj.Ekg);
                        cmd.Parameters.AddWithValue("@Journal", obj.Journal == null ? "" : obj.Journal);
                        cmd.Parameters.AddWithValue("@JournalType", obj.JournalType);
                        cmd.Parameters.AddWithValue("@ReleaseJournal", obj.ReleaseJournal);
                        cmd.Parameters.AddWithValue("@Diagnosis", obj.Diagnosis == null ? "" : obj.Diagnosis);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Freeze", obj.Freeze);
                        cmd.Parameters.AddWithValue("@Weight", obj.Weight);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_journal(dsdt_admission_date,dsid_journal_day,dss_complaints,dss_chdd,dss_chss,dss_ps,dss_ad,dss_monitor,dss_rhythm," +
                        "dsb_good_rhythm,dss_surgeon_exam,dss_cardio_exam,dss_ekg,dss_journal,dsi_journal_type,dsb_release_journal,dss_diagnosis,dsid_doctor,dsb_freeze," +
                        "dsd_weight) VALUES(@AdmissionDate,@JournalDay,@Complaints,@Chdd,@Chss,@Ps,@Ad,@Monitor,@Rhythm,@GoodRhythm,@SurgeonExam,@CardioExam," +
                        "@Ekg,@Journal,@JournalType,@ReleaseJournal,@Diagnosis,@Doctor,@Freeze,@Weight) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@AdmissionDate", obj.AdmissionDate);
                        cmd.Parameters.AddWithValue("@JournalDay", obj.JournalDayId);
                        cmd.Parameters.AddWithValue("@Complaints", obj.Complaints == null ? "" : obj.Complaints);
                        cmd.Parameters.AddWithValue("@Chdd", obj.Chdd == null ? "" : obj.Chdd);
                        cmd.Parameters.AddWithValue("@Chss", obj.Chss == null ? "" : obj.Chss);
                        cmd.Parameters.AddWithValue("@Ps", obj.Ps == null ? "" : obj.Ps);
                        cmd.Parameters.AddWithValue("@Ad", obj.Ad == null ? "" : obj.Ad);
                        cmd.Parameters.AddWithValue("@Monitor", obj.Monitor == null ? "" : obj.Monitor);
                        cmd.Parameters.AddWithValue("@Rhythm", obj.Rhythm == null ? "" : obj.Rhythm);
                        cmd.Parameters.AddWithValue("@GoodRhythm", obj.GoodRhythm);
                        cmd.Parameters.AddWithValue("@SurgeonExam", obj.SurgeonExam == null ? "" : obj.SurgeonExam);
                        cmd.Parameters.AddWithValue("@CardioExam", obj.CardioExam == null ? "" : obj.CardioExam);
                        cmd.Parameters.AddWithValue("@Ekg", obj.Ekg == null ? "" : obj.Ekg);
                        cmd.Parameters.AddWithValue("@Journal", obj.Journal == null ? "" : obj.Journal);
                        cmd.Parameters.AddWithValue("@JournalType", obj.JournalType);
                        cmd.Parameters.AddWithValue("@ReleaseJournal", obj.ReleaseJournal);
                        cmd.Parameters.AddWithValue("@Diagnosis", obj.Diagnosis == null ? "" : obj.Diagnosis);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Freeze", obj.Freeze);
                        cmd.Parameters.AddWithValue("@Weight", obj.Weight);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
