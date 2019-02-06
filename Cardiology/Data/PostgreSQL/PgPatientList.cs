using Cardiology.Data.Model2;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Cardiology.Data.PostgreSQL
{
    class PgPatientList : IDbPatientService
    {
        private IDbConnectionFactory connectionFactory;

        public PgPatientList(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdvActiveHospitalPatientV2> GetActive()
        {
            IList<DdvActiveHospitalPatientV2> list = new List<DdvActiveHospitalPatientV2>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospital_session, dsid_patient_id, dsdt_admission_date, " +
                    "dsid_doctor_id, dss_diagnosis, dss_room_cell, dss_patient_name, dss_doc_name, dss_med_code " +
                    "FROM ddv_active_hospital_patients WHERE dsb_active=true";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvActiveHospitalPatientV2 obj = new DdvActiveHospitalPatientV2();
                        obj.SessionId = reader.GetString(0);
                        obj.PatientId = reader.GetString(1);
                        obj.AdmissionDate = reader.GetDateTime(2);
                        obj.DoctorId = reader.GetString(3);
                        obj.Diagnosis = reader.GetString(4);
                        obj.RoomCell = reader.GetString(5);
                        obj.PatientName = reader.GetString(6);
                        obj.DocName = reader.GetString(7);
                        obj.MedCode = reader.GetString(8);

                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtPatientV2> GetList()
        {
            IList<DdtPatientV2> list = new List<DdtPatientV2>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_creation_date, r_modify_date, " +

                    "dss_initials, dss_full_name, dsdt_birthdate, " +
                    "dss_phone, " +
                    "dss_address, " +
                    "dsd_weight, " +
                    "dsd_high, " +
                    "dss_med_code, " +
                    "dss_snils, " +
                    "dss_oms, " +
                    "dss_passport_serial, " +
                    "dss_passport_num, dss_passport_date, dss_passport_issue_place, dsb_sd " +
                    "FROM ddt_patient";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtPatientV2 obj = new DdtPatientV2();
                        obj.Id = reader.GetString(0);
                        obj.Created = reader.GetDateTime(1);
                        obj.Modified = reader.GetDateTime(2);
                        obj.Initials = reader.GetString(3);
                        obj.FullName = reader.GetString(4);
                        obj.Birthdate = reader.GetDateTime(5);
                        obj.Phone = reader.GetString(6);
                        obj.Address = reader.GetString(7);
                        obj.Weight = reader.GetDouble(8);
                        obj.High = reader.GetDouble(9);
                        obj.MedCode = reader.GetString(10);
                        obj.Snils = reader.GetString(11);
                        obj.Oms = reader.GetString(12);
                        obj.PassportSerial = reader.GetString(13);
                        obj.PassportNum = reader.GetString(14);
                        obj.PassportDate = reader.GetDateTime(15);
                        obj.PassportIssuePlace = reader.GetString(16);
                        obj.Sd = reader.GetBoolean(17);

                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
