using Cardiology.Data.Commons;
using Cardiology.Data.Model2;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtJournalDayService : IDdtJournalDayService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtJournalDayService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public DdtJournalDay GetById(string id)
        {
            if (id == null)
            {
                return null;
            }
            String sql = String.Format("SELECT r_object_id, r_creation_date, dsdt_admission_date, dsid_doctor, dsid_patient, dsid_hospitality_session, " +
                    "r_modify_date, dss_name, dsi_journal_type, dss_diagnosis FROM ddt_journal_day where r_object_id='{0}'", id);
            IList<DdtJournalDay> list = GetByQuery(sql);
            return list.Count > 0 ? list[0] : null;
        }

        public DdtJournalDay GetForDate(string hopitalSessionId, DateTime date)
        {
            if (date == null)
            {
                return null;
            }
            String sql = String.Format("SELECT r_object_id, r_creation_date, dsdt_admission_date, dsid_doctor, dsid_patient, dsid_hospitality_session, " +
                    "r_modify_date, dss_name, dsi_journal_type, dss_diagnosis FROM ddt_journal_day where dsid_hospitality_session='" + hopitalSessionId + "' AND dsdt_admission_date>=to_timestamp('" +
                   date.ToShortDateString() + " 08:15:00', 'dd.mm.yyyy HH24:mi:ss') AND dsdt_admission_date<=to_timestamp('" + date.ToShortDateString() + " 23:59:59', 'dd.mm.yyyy HH24:mi:ss')");
            IList<DdtJournalDay> list = GetByQuery(sql);
            return list.Count > 0 ? list[0] : null;
        }

        private IList<DdtJournalDay> GetByQuery(string sql)
        {
            IList<DdtJournalDay> list = new List<DdtJournalDay>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtJournalDay obj = new DdtJournalDay();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.CreationDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.AdmissionDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Doctor = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Patient = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.HospitalitySession = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.ModifyDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Name = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.JournalType = reader.IsDBNull(8) ? -1 : reader.GetInt16(8);
                        obj.Diagnosis = reader.IsDBNull(9) ? null : reader.GetString(9);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public string Save(DdtJournalDay obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_journal_day SET " +
                                        "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsid_patient = @Patient, " +
                                        "dsdt_admission_date = @AdmissionDate, " +
                                        "dsid_doctor = @Doctor, " +
                                        "dsi_journal_type = @JournalType, " +
                                        "dss_diagnosis = @Diagnosis, " +
                                        "dss_name = @Name " +
                                         "WHERE r_object_id = @ObjectId";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@AdmissionDate", obj.AdmissionDate);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Name", obj.Name == null ? "" : obj.Name);
                        cmd.Parameters.AddWithValue("@JournalType", obj.JournalType);
                        cmd.Parameters.AddWithValue("@Diagnosis", obj.Diagnosis);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_journal_day(dsid_hospitality_session,dsid_patient,dsdt_admission_date,dsid_doctor,dss_name,dsi_journal_type,dss_diagnosis) " +
                                                              "VALUES(@HospitalitySession,@Patient,@AdmissionDate,@Doctor,@Name,@JournalType,@Diagnosis) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@AdmissionDate", obj.AdmissionDate);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Name", obj.Name == null ? "" : obj.Name);
                        cmd.Parameters.AddWithValue("@JournalType", obj.JournalType);
                        cmd.Parameters.AddWithValue("@Diagnosis", obj.Diagnosis == null ? "" : obj.Diagnosis);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

        public void Delete(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "delete from ddt_journal WHERE dsid_journal_day = '" + id + "' ";
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                command.ExecuteScalar();
                sql = "delete from ddt_journal_day WHERE r_object_id = '" + id + "' ";
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                command.ExecuteScalar();
            }
        }
    }
}
