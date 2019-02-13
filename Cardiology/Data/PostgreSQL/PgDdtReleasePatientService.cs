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
                String sql = "SELECT r_object_id, dsb_dismissed_less30d, dsdt_our_enddate, dss_our_sicklist_num, dss_year_disabilities, dsdt_our_startdate, r_creation_date, dss_disability_num, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_profession, dsdt_extr_enddate, dsdt_extr_startdate, r_modify_date, dsb_pensioneer, dsb_is_working, dsb_sicklist_need, dsb_extr_opened_sicklist, dss_occupational_hazard, dsdt_okr_release_date, dss_extr_sicklist_num FROM ddt_release_patient";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtReleasePatient obj = new DdtReleasePatient();
                        obj.ObjectId = reader.GetString(1);
                        obj.DismissedLess30d = reader.GetBoolean(2);
                        obj.OurEnddate = reader.GetDateTime(3);
                        obj.OurSicklistNum = reader.GetString(4);
                        obj.YearDisabilities = reader.GetString(5);
                        obj.OurStartdate = reader.GetDateTime(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.DisabilityNum = reader.GetString(8);
                        obj.Doctor = reader.GetString(9);
                        obj.Patient = reader.GetString(10);
                        obj.HospitalitySession = reader.GetString(11);
                        obj.Profession = reader.GetString(12);
                        obj.ExtrEnddate = reader.GetDateTime(13);
                        obj.ExtrStartdate = reader.GetDateTime(14);
                        obj.ModifyDate = reader.GetDateTime(15);
                        obj.Pensioneer = reader.GetBoolean(16);
                        obj.IsWorking = reader.GetBoolean(17);
                        obj.SicklistNeed = reader.GetBoolean(18);
                        obj.ExtrOpenedSicklist = reader.GetBoolean(19);
                        obj.OccupationalHazard = reader.GetString(20);
                        obj.OkrReleaseDate = reader.GetDateTime(21);
                        obj.ExtrSicklistNum = reader.GetString(22);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
