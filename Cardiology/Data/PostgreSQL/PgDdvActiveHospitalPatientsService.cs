using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using NLog;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdvActiveHospitalPatientsService : IDdvActiveHospitalPatientsService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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
                        obj.PatientId = reader.GetString(0);
                        obj.Active = reader.GetBoolean(1);
                        obj.HospitalSession = reader.GetString(2);
                        obj.DocName = reader.GetString(3);
                        obj.Diagnosis = reader.GetString(4);
                        obj.PatientName = reader.GetString(5);
                        obj.RoomCell = reader.GetString(6);
                        obj.DoctorId = reader.GetString(7);
                        obj.MedCode = reader.GetString(8);
                        obj.AdmissionDate = reader.GetDateTime(9);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdvActiveHospitalPatients> GetList(bool onlyActive)
        {
            try
            {
                IList<DdvActiveHospitalPatients> list = new List<DdvActiveHospitalPatients>();
                using (dynamic connection = connectionFactory.GetConnection())
                {
                    String sql = String.Format(
                        "SELECT dsid_patient_id, dsb_active, dsid_hospital_session, dss_doc_name, dss_diagnosis, dss_patient_name, dss_room_cell, dsid_doctor_id, dsdt_admission_date, dss_med_code FROM ddv_active_hospital_patients WHERE dsb_active = {0}",
                        onlyActive);
                    Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DdvActiveHospitalPatients obj = new DdvActiveHospitalPatients();
                            obj.PatientId = reader.GetString(0);
                            obj.Active = reader.GetBoolean(1);
                            obj.HospitalSession = reader.GetString(2);
                            obj.DocName = reader.GetString(3);

                            if(!reader.IsDBNull(4)) { 
                                obj.Diagnosis = reader.GetString(4);
                            }
                            obj.PatientName = reader.GetString(5);
                            obj.RoomCell = reader.GetString(6);
                            obj.DoctorId = reader.GetString(7);
                            obj.AdmissionDate = reader.GetDateTime(8);
                            obj.MedCode = reader.GetString(9);
                            list.Add(obj);
                        }
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw ex;
            }
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
                        obj.PatientId = reader.GetString(0);
                        obj.Active = reader.GetBoolean(1);
                        obj.HospitalSession = reader.GetString(2);
                        obj.DocName = reader.GetString(3);
                        obj.Diagnosis = reader.GetString(4);
                        obj.PatientName = reader.GetString(5);
                        obj.RoomCell = reader.GetString(6);
                        obj.DoctorId = reader.GetString(7);
                        obj.MedCode = reader.GetString(8);
                        obj.AdmissionDate = reader.GetDateTime(9);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
