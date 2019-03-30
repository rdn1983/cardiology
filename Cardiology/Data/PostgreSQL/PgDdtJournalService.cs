using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtJournalService : IDdtJournalService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtJournalService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtJournal> GetAll()
        {
            IList<DdtJournal> list = new List<DdtJournal>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dss_diagnosis, dss_chss, dss_chdd, r_creation_date, dss_complaints, dss_surgeon_exam, " +
                    "dss_ekg, dsdt_admission_date, dss_monitor, dss_rhythm, dsid_doctor, dsid_patient, dss_ps, dss_ad, dsid_hospitality_session, " +
                    "r_modify_date, dss_cardio_exam, dsi_journal_type, dsb_good_rhythm, dsb_release_journal, dss_journal FROM ddt_journal";
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
                        obj.Doctor = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Patient = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.Ps = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Ad = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.HospitalitySession = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.ModifyDate = reader.IsDBNull(16) ? DateTime.MinValue : reader.GetDateTime(16);
                        obj.CardioExam = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.JournalType = reader.IsDBNull(18) ? -1 : reader.GetInt16(18);
                        obj.GoodRhythm = reader.GetBoolean(19);
                        obj.ReleaseJournal = reader.GetBoolean(20);
                        obj.Journal = reader.IsDBNull(21) ? null : reader.GetString(21);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public List<DdtJournal> GetByQuery(string sql)
        {
            List<DdtJournal> list = new List<DdtJournal>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
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
                        obj.Doctor = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Patient = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.Ps = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Ad = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.HospitalitySession = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.ModifyDate = reader.IsDBNull(16) ? DateTime.MinValue : reader.GetDateTime(16);
                        obj.CardioExam = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.JournalType = reader.IsDBNull(18) ? -1 : reader.GetInt16(18);
                        obj.GoodRhythm = reader.GetBoolean(19);
                        obj.ReleaseJournal = reader.GetBoolean(20);
                        obj.Journal = reader.IsDBNull(21) ? null : reader.GetString(21);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtJournal GetObject(string sql)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
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
                        obj.Doctor = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Patient = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.Ps = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Ad = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.HospitalitySession = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.ModifyDate = reader.IsDBNull(16) ? DateTime.MinValue : reader.GetDateTime(16);
                        obj.CardioExam = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.JournalType = reader.IsDBNull(18) ? -1 : reader.GetInt16(18);
                        obj.GoodRhythm = reader.GetBoolean(19);
                        obj.ReleaseJournal = reader.GetBoolean(20);
                        obj.Journal = reader.IsDBNull(21) ? null : reader.GetString(21);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtJournal GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_diagnosis, dss_chss, dss_chdd, r_creation_date, dss_complaints, dss_surgeon_exam, " +
                    "dss_ekg, dsdt_admission_date, dss_monitor, dss_rhythm, dsid_doctor, dsid_patient, dss_ps, dss_ad, dsid_hospitality_session, " +
                    "r_modify_date, dss_cardio_exam, dsi_journal_type, dsb_good_rhythm, dsb_release_journal, dss_journal FROM ddt_journal " +
                    "WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
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
                        obj.Doctor = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Patient = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.Ps = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Ad = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.HospitalitySession = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.ModifyDate = reader.IsDBNull(16) ? DateTime.MinValue : reader.GetDateTime(16);
                        obj.CardioExam = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.JournalType = reader.IsDBNull(18) ? -1 : reader.GetInt16(18);
                        obj.GoodRhythm = reader.GetBoolean(19);
                        obj.ReleaseJournal = reader.GetBoolean(20);
                        obj.Journal = reader.IsDBNull(21) ? null : reader.GetString(21);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtJournal GetByHospitalSessionAndJournalType(string hospitalSession, int jornalType)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_diagnosis, dss_chss, dss_chdd, r_creation_date, dss_complaints, dss_surgeon_exam, " +
                    "dss_ekg, dsdt_admission_date, dss_monitor, dss_rhythm, dsid_doctor, dsid_patient, dss_ps, dss_ad, dsid_hospitality_session, " +
                    "r_modify_date, dss_cardio_exam, dsi_journal_type, dsb_good_rhythm, dsb_release_journal, dss_journal FROM ddt_journal " +
                    "WHERE dsid_hospitality_session = '{0}' AND dsi_journal_type = {1} ", hospitalSession, jornalType);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
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
                        obj.Doctor = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Patient = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.Ps = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Ad = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.HospitalitySession = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.ModifyDate = reader.IsDBNull(16) ? DateTime.MinValue : reader.GetDateTime(16);
                        obj.CardioExam = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.JournalType = reader.IsDBNull(18) ? -1 : reader.GetInt16(18);
                        obj.GoodRhythm = reader.GetBoolean(19);
                        obj.ReleaseJournal = reader.GetBoolean(20);
                        obj.Journal = reader.IsDBNull(21) ? null : reader.GetString(21);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtJournal obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_journal SET " +
                                          "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsid_patient = @Patient, " +
                                        "dsdt_admission_date = @AdmissionDate, " +
                                        "dsid_doctor = @Doctor, " +
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
                                        "dss_diagnosis = @Diagnosis " +
                                         "WHERE r_object_id = @ObjectId";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@AdmissionDate", obj.AdmissionDate);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
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
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_journal(dsid_hospitality_session,dsid_patient,dsdt_admission_date,dsid_doctor,dss_complaints,dss_chdd,dss_chss,dss_ps,dss_ad,dss_monitor,dss_rhythm,dsb_good_rhythm,dss_surgeon_exam,dss_cardio_exam,dss_ekg,dss_journal,dsi_journal_type,dsb_release_journal,dss_diagnosis) " +
                                                              "VALUES(@HospitalitySession,@Patient,@AdmissionDate,@Doctor,@Complaints,@Chdd,@Chss,@Ps,@Ad,@Monitor,@Rhythm,@GoodRhythm,@SurgeonExam,@CardioExam,@Ekg,@Journal,@JournalType,@ReleaseJournal,@Diagnosis) RETURNING r_object_id";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@AdmissionDate", obj.AdmissionDate);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
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
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
