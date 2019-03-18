using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtReleasePatientService : IDdtReleasePatientService
    {
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
    }
}
