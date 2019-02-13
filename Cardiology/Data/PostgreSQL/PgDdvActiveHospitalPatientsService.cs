using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdvActiveHospitalPatientsService : IDdvActiveHospitalPatientsService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdvActiveHospitalPatientsService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdvActiveHospitalPatients> GetAll()
        {
            IList<DdvActiveHospitalPatients> list = new List<DdvActiveHospitalPatients>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_patient_id, dsb_active, dsid_hospital_session, dss_doc_name, dss_diagnosis, dss_patient_name, dss_room_cell, dsid_doctor_id, dss_med_code, dsdt_admission_date FROM ddv_active_hospital_patients";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvActiveHospitalPatients obj = new DdvActiveHospitalPatients();
                        obj.PatientId = reader.GetString(1);
                        obj.Active = reader.GetBoolean(2);
                        obj.HospitalSession = reader.GetString(3);
                        obj.DocName = reader.GetString(4);
                        obj.Diagnosis = reader.GetString(5);
                        obj.PatientName = reader.GetString(6);
                        obj.RoomCell = reader.GetString(7);
                        obj.DoctorId = reader.GetString(8);
                        obj.MedCode = reader.GetString(9);
                        obj.AdmissionDate = reader.GetDateTime(10);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdvActiveHospitalPatients> GetList(bool onlyActive)
        {
            IList<DdvActiveHospitalPatients> list = new List<DdvActiveHospitalPatients>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_patient_id, dsb_active, dsid_hospital_session, dss_doc_name, dss_diagnosis, dss_patient_name, dss_room_cell, dsid_doctor_id, dsdt_admission_date, dss_med_code FROM ddv_active_hospital_patients WHERE dsb_active = {0}", onlyActive);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvActiveHospitalPatients obj = new DdvActiveHospitalPatients();
                        obj.PatientId = reader.GetString(1);
                        obj.Active = reader.GetBoolean(2);
                        obj.HospitalSession = reader.GetString(3);
                        obj.DocName = reader.GetString(4);
                        obj.Diagnosis = reader.GetString(5);
                        obj.PatientName = reader.GetString(6);
                        obj.RoomCell = reader.GetString(7);
                        obj.DoctorId = reader.GetString(8);
                        obj.AdmissionDate = reader.GetDateTime(9);
                        obj.MedCode = reader.GetString(10);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdvActiveHospitalPatients GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_patient_id, dsb_active, dsid_hospital_session, dss_doc_name, dss_diagnosis, dss_patient_name, dss_room_cell, dsid_doctor_id, dss_med_code, dsdt_admission_date FROM ddv_active_hospital_patients WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdvActiveHospitalPatients obj = new DdvActiveHospitalPatients();
                        obj.PatientId = reader.GetString(1);
                        obj.Active = reader.GetBoolean(2);
                        obj.HospitalSession = reader.GetString(3);
                        obj.DocName = reader.GetString(4);
                        obj.Diagnosis = reader.GetString(5);
                        obj.PatientName = reader.GetString(6);
                        obj.RoomCell = reader.GetString(7);
                        obj.DoctorId = reader.GetString(8);
                        obj.MedCode = reader.GetString(9);
                        obj.AdmissionDate = reader.GetDateTime(10);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
