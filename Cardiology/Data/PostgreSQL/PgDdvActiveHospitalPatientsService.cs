using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using NLog;
using System.Globalization;

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
                String sql = "SELECT dsid_patient_id, dsb_active, dsid_hospital_session, dss_doc_name, dss_diagnosis, dss_patient_name, dss_room_cell, " +
                    "dsid_doctor_id, dss_med_code, dsdt_admission_date FROM ddv_active_hospital_patients";
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvActiveHospitalPatients obj = new DdvActiveHospitalPatients();
                        obj.PatientId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Active = reader.GetBoolean(1);
                        obj.HospitalSession = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.DocName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Diagnosis = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.PatientName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.RoomCell = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.DoctorId = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.MedCode = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.AdmissionDate = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
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
                        "SELECT dsid_patient_id, dsb_active, dsid_hospital_session, dss_doc_name, dss_diagnosis, dss_patient_name, dss_room_cell, dsid_doctor_id, " +
                        "dss_med_code, dsdt_admission_date FROM ddv_active_hospital_patients WHERE dsb_active = {0}",
                        onlyActive);
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DdvActiveHospitalPatients obj = new DdvActiveHospitalPatients();
                            obj.PatientId = reader.IsDBNull(0) ? null : reader.GetString(0);
                            obj.Active = reader.GetBoolean(1);
                            obj.HospitalSession = reader.IsDBNull(2) ? null : reader.GetString(2);
                            obj.DocName = reader.IsDBNull(3) ? null : reader.GetString(3);
                            obj.Diagnosis = reader.IsDBNull(4) ? null : reader.GetString(4);
                            obj.PatientName = reader.IsDBNull(5) ? null : reader.GetString(5);
                            obj.RoomCell = reader.IsDBNull(6) ? null : reader.GetString(6);
                            obj.DoctorId = reader.IsDBNull(7) ? null : reader.GetString(7);
                            obj.MedCode = reader.IsDBNull(8) ? null : reader.GetString(8);
                            obj.AdmissionDate = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                            list.Add(obj);
                        }
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public DdvActiveHospitalPatients GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_patient_id, dsb_active, dsid_hospital_session, dss_doc_name, dss_diagnosis, dss_patient_name, " +
                    "dss_room_cell, dsid_doctor_id, dss_med_code, dsdt_admission_date FROM ddv_active_hospital_patients WHERE r_object_id = '{0}'", id);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdvActiveHospitalPatients obj = new DdvActiveHospitalPatients();
                        obj.PatientId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Active = reader.GetBoolean(1);
                        obj.HospitalSession = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.DocName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Diagnosis = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.PatientName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.RoomCell = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.DoctorId = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.MedCode = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.AdmissionDate = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
