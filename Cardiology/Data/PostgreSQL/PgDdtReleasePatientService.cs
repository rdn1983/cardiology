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
    public class PgDdtReleasePatientService : IDdtReleasePatientService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtReleasePatientService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtReleasePatient> GetAll()
        {
            IList<DdtReleasePatient> list = new List<DdtReleasePatient>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsdt_our_enddate, dsb_dismissed_less30d, dss_our_sicklist_num, dss_year_disabilities, dsdt_our_startdate, r_creation_date, dss_disability_num, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_profession, dsdt_extr_enddate, dsdt_extr_startdate, r_modify_date, dsb_pensioneer, dsb_is_working, dsb_sicklist_need, dsb_extr_opened_sicklist, dss_occupational_hazard, dsdt_okr_release_date, dss_extr_sicklist_num FROM ddt_release_patient";
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtReleasePatient obj = new DdtReleasePatient();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.OurEnddate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.DismissedLess30d = reader.GetBoolean(2);
                        obj.OurSicklistNum = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.YearDisabilities = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.OurStartdate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.DisabilityNum = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Doctor = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Patient = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.HospitalitySession = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Profession = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.ExtrEnddate = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                        obj.ExtrStartdate = reader.IsDBNull(13) ? DateTime.MinValue : reader.GetDateTime(13);
                        obj.ModifyDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        obj.Pensioneer = reader.GetBoolean(15);
                        obj.IsWorking = reader.GetBoolean(16);
                        obj.SicklistNeed = reader.GetBoolean(17);
                        obj.ExtrOpenedSicklist = reader.GetBoolean(18);
                        obj.OccupationalHazard = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.OkrReleaseDate = reader.IsDBNull(20) ? DateTime.MinValue : reader.GetDateTime(20);
                        obj.ExtrSicklistNum = reader.IsDBNull(21) ? null : reader.GetString(21);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtReleasePatient GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_our_enddate, dsb_dismissed_less30d, dss_our_sicklist_num, dss_year_disabilities, dsdt_our_startdate, r_creation_date, dss_disability_num, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_profession, dsdt_extr_enddate, dsdt_extr_startdate, r_modify_date, dsb_pensioneer, dsb_is_working, dsb_sicklist_need, dsb_extr_opened_sicklist, dss_occupational_hazard, dsdt_okr_release_date, dss_extr_sicklist_num FROM ddt_release_patient WHERE r_object_id = '{0}'", id);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtReleasePatient obj = new DdtReleasePatient();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.OurEnddate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.DismissedLess30d = reader.GetBoolean(2);
                        obj.OurSicklistNum = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.YearDisabilities = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.OurStartdate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.DisabilityNum = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Doctor = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Patient = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.HospitalitySession = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Profession = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.ExtrEnddate = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                        obj.ExtrStartdate = reader.IsDBNull(13) ? DateTime.MinValue : reader.GetDateTime(13);
                        obj.ModifyDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        obj.Pensioneer = reader.GetBoolean(15);
                        obj.IsWorking = reader.GetBoolean(16);
                        obj.SicklistNeed = reader.GetBoolean(17);
                        obj.ExtrOpenedSicklist = reader.GetBoolean(18);
                        obj.OccupationalHazard = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.OkrReleaseDate = reader.IsDBNull(20) ? DateTime.MinValue : reader.GetDateTime(20);
                        obj.ExtrSicklistNum = reader.IsDBNull(21) ? null : reader.GetString(21);
                        return obj;
                    }
                }
            }
            return null;
        }


        public string Save(DdtReleasePatient obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_release_patient SET " +
                                          "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsid_patient = @Patient, " +
                                        "dsid_doctor = @Doctor, " +
                                        "dsdt_okr_release_date = @OkrReleaseDate, " +
                                        "dsb_is_working = @IsWorking, " +
                                        "dsb_dismissed_less30d = @DismissedLess30d, " +
                                        "dss_profession = @Profession, " +
                                        "dss_occupational_hazard = @OccupationalHazard, " +
                                        "dsb_pensioneer = @Pensioneer, " +
                                        "dss_disability_num = @DisabilityNum, " +
                                        "dss_year_disabilities = @YearDisabilities, " +
                                        "dsb_sicklist_need = @SicklistNeed, " +
                                        "dsb_extr_opened_sicklist = @ExtrOpenedSicklist, " +
                                        "dss_extr_sicklist_num = @ExtrSicklistNum, " +
                                        "dsdt_extr_startdate = @ExtrStartdate, " +
                                        "dsdt_extr_enddate = @ExtrEnddate, " +
                                        "dss_our_sicklist_num = @OurSicklistNum, " +
                                        "dsdt_our_startdate = @OurStartdate, " +
                                        "dsdt_our_enddate = @OurEnddate " +
                                         "WHERE r_object_id = @ObjectId";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@OkrReleaseDate", obj.OkrReleaseDate);
                        cmd.Parameters.AddWithValue("@IsWorking", obj.IsWorking);
                        cmd.Parameters.AddWithValue("@DismissedLess30d", obj.DismissedLess30d);
                        cmd.Parameters.AddWithValue("@Profession", obj.Profession == null ? "" : obj.Profession);
                        cmd.Parameters.AddWithValue("@OccupationalHazard", obj.OccupationalHazard == null ? "" : obj.OccupationalHazard);
                        cmd.Parameters.AddWithValue("@Pensioneer", obj.Pensioneer);
                        cmd.Parameters.AddWithValue("@DisabilityNum", obj.DisabilityNum == null ? "" : obj.DisabilityNum);
                        cmd.Parameters.AddWithValue("@YearDisabilities", obj.YearDisabilities == null ? "" : obj.YearDisabilities);
                        cmd.Parameters.AddWithValue("@SicklistNeed", obj.SicklistNeed);
                        cmd.Parameters.AddWithValue("@ExtrOpenedSicklist", obj.ExtrOpenedSicklist);
                        cmd.Parameters.AddWithValue("@ExtrSicklistNum", obj.ExtrSicklistNum == null ? "" : obj.ExtrSicklistNum);
                        cmd.Parameters.AddWithValue("@ExtrStartdate", obj.ExtrStartdate);
                        cmd.Parameters.AddWithValue("@ExtrEnddate", obj.ExtrEnddate);
                        cmd.Parameters.AddWithValue("@OurSicklistNum", obj.OurSicklistNum == null ? "" : obj.OurSicklistNum);
                        cmd.Parameters.AddWithValue("@OurStartdate", obj.OurStartdate);
                        cmd.Parameters.AddWithValue("@OurEnddate", obj.OurEnddate);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_release_patient(dsid_hospitality_session,dsid_patient,dsid_doctor,dsdt_okr_release_date,dsb_is_working,dsb_dismissed_less30d,dss_profession,dss_occupational_hazard,dsb_pensioneer,dss_disability_num,dss_year_disabilities,dsb_sicklist_need,dsb_extr_opened_sicklist,dss_extr_sicklist_num,dsdt_extr_startdate,dsdt_extr_enddate,dss_our_sicklist_num,dsdt_our_startdate,dsdt_our_enddate) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@OkrReleaseDate,@IsWorking,@DismissedLess30d,@Profession,@OccupationalHazard,@Pensioneer,@DisabilityNum,@YearDisabilities,@SicklistNeed,@ExtrOpenedSicklist,@ExtrSicklistNum,@ExtrStartdate,@ExtrEnddate,@OurSicklistNum,@OurStartdate,@OurEnddate) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@OkrReleaseDate", obj.OkrReleaseDate);
                        cmd.Parameters.AddWithValue("@IsWorking", obj.IsWorking);
                        cmd.Parameters.AddWithValue("@DismissedLess30d", obj.DismissedLess30d);
                        cmd.Parameters.AddWithValue("@Profession", obj.Profession == null ? "" : obj.Profession);
                        cmd.Parameters.AddWithValue("@OccupationalHazard", obj.OccupationalHazard == null ? "" : obj.OccupationalHazard);
                        cmd.Parameters.AddWithValue("@Pensioneer", obj.Pensioneer);
                        cmd.Parameters.AddWithValue("@DisabilityNum", obj.DisabilityNum == null ? "" : obj.DisabilityNum);
                        cmd.Parameters.AddWithValue("@YearDisabilities", obj.YearDisabilities == null ? "" : obj.YearDisabilities);
                        cmd.Parameters.AddWithValue("@SicklistNeed", obj.SicklistNeed);
                        cmd.Parameters.AddWithValue("@ExtrOpenedSicklist", obj.ExtrOpenedSicklist);
                        cmd.Parameters.AddWithValue("@ExtrSicklistNum", obj.ExtrSicklistNum == null ? "" : obj.ExtrSicklistNum);
                        cmd.Parameters.AddWithValue("@ExtrStartdate", obj.ExtrStartdate);
                        cmd.Parameters.AddWithValue("@ExtrEnddate", obj.ExtrEnddate);
                        cmd.Parameters.AddWithValue("@OurSicklistNum", obj.OurSicklistNum == null ? "" : obj.OurSicklistNum);
                        cmd.Parameters.AddWithValue("@OurStartdate", obj.OurStartdate);
                        cmd.Parameters.AddWithValue("@OurEnddate", obj.OurEnddate);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }
    }
}
