using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

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
                String sql = "SELECT r_object_id, dss_diagnosis, dss_chss, dss_chdd, r_creation_date, dss_complaints, dss_surgeon_exam, dss_ekg, dsdt_admission_date, dss_monitor, dss_rhythm, dsid_doctor, dsid_patient, dss_ps, dss_ad, dsid_hospitality_session, r_modify_date, dss_cardio_exam, dsi_journal_type, dsb_good_rhythm, dsb_release_journal, dss_journal FROM ddt_journal";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtJournal obj = new DdtJournal();
                        obj.ObjectId = reader.GetString(1);
                        obj.Diagnosis = reader.GetString(2);
                        obj.Chss = reader.GetString(3);
                        obj.Chdd = reader.GetString(4);
                        obj.CreationDate = reader.GetDateTime(5);
                        obj.Complaints = reader.GetString(6);
                        obj.SurgeonExam = reader.GetString(7);
                        obj.Ekg = reader.GetString(8);
                        obj.AdmissionDate = reader.GetDateTime(9);
                        obj.Monitor = reader.GetString(10);
                        obj.Rhythm = reader.GetString(11);
                        obj.Doctor = reader.GetString(12);
                        obj.Patient = reader.GetString(13);
                        obj.Ps = reader.GetString(14);
                        obj.Ad = reader.GetString(15);
                        obj.HospitalitySession = reader.GetString(16);
                        obj.ModifyDate = reader.GetDateTime(17);
                        obj.CardioExam = reader.GetString(18);
                        obj.JournalType = reader.GetInt16(19);
                        obj.GoodRhythm = reader.GetBoolean(20);
                        obj.ReleaseJournal = reader.GetBoolean(21);
                        obj.Journal = reader.GetString(22);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtJournal GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_diagnosis, dss_chss, dss_chdd, r_creation_date, dss_complaints, dss_surgeon_exam, dss_ekg, dsdt_admission_date, dss_monitor, dss_rhythm, dsid_doctor, dsid_patient, dss_ps, dss_ad, dsid_hospitality_session, r_modify_date, dss_cardio_exam, dsi_journal_type, dsb_good_rhythm, dsb_release_journal, dss_journal FROM ddt_journal WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtJournal obj = new DdtJournal();
                        obj.ObjectId = reader.GetString(1);
                        obj.Diagnosis = reader.GetString(2);
                        obj.Chss = reader.GetString(3);
                        obj.Chdd = reader.GetString(4);
                        obj.CreationDate = reader.GetDateTime(5);
                        obj.Complaints = reader.GetString(6);
                        obj.SurgeonExam = reader.GetString(7);
                        obj.Ekg = reader.GetString(8);
                        obj.AdmissionDate = reader.GetDateTime(9);
                        obj.Monitor = reader.GetString(10);
                        obj.Rhythm = reader.GetString(11);
                        obj.Doctor = reader.GetString(12);
                        obj.Patient = reader.GetString(13);
                        obj.Ps = reader.GetString(14);
                        obj.Ad = reader.GetString(15);
                        obj.HospitalitySession = reader.GetString(16);
                        obj.ModifyDate = reader.GetDateTime(17);
                        obj.CardioExam = reader.GetString(18);
                        obj.JournalType = reader.GetInt16(19);
                        obj.GoodRhythm = reader.GetBoolean(20);
                        obj.ReleaseJournal = reader.GetBoolean(21);
                        obj.Journal = reader.GetString(22);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtJournal obj)
        {
            throw new NotImplementedException();
        }
    }
}
