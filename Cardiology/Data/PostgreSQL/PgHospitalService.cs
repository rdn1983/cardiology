using Cardiology.Data.Model2;
using System;
using System.Data.Common;

namespace Cardiology.Data.PostgreSQL
{
    public class PgHospitalService : IDbHospitalService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgHospitalService(IDbConnectionFactory connectionFactory) {
            this.connectionFactory = connectionFactory;
        }

        public DdtHospitalV2 GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = $@"SELECT
                                                h.r_object_id,
                                                h.r_creation_date,
                                                h.r_modify_date,
                                                h.dsid_patient,
                                                h.dsdt_admission_date,
                                                h.dsid_duty_doctor,
                                                h.dsid_curing_doctor,
                                                h.dsid_substitution_doctor,
                                                h.dsid_dir_cardio_reanim_doctor,
                                                h.dsid_anesthetist_doctor,
                                                h.dsb_active,
                                                h.dsb_reject_cure,
                                                h.dsb_death,
                                                h.dss_room_cell,
                                                h.dsi_release_type,

                                                p.r_object_id,
                                                p.r_creation_date,
                                                p.r_modify_date,
                                                p.dss_full_name,
                                                p.dss_initials,
                                                p.dss_phone,
                                                p.dss_address,
                                                p.dsdt_birthdate,
                                                p.dsd_weight,
                                                p.dsd_high,
                                                p.dss_snils,
                                                p.dss_oms,
                                                p.dss_med_code,
                                                p.dss_passport_serial,
                                                p.dss_passport_num,
                                                p.dss_passport_date,
                                                p.dss_passport_issue_place,
                                                p.dsb_sd

                                              FROM ddt_hospital h LEFT OUTER JOIN ddt_patient p ON p.r_object_id = h.dsid_patient
                                              WHERE h.r_object_id = '{id}'";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtHospitalV2 obj = new DdtHospitalV2();
                        obj.Id = reader.GetString(0);
                        obj.Created = reader.GetDateTime(1);
                        obj.Modified = reader.GetDateTime(2);
                        obj.PatientId = reader.GetString(3);
                        obj.AdmissionDate = reader.GetDateTime(4);
                        obj.DutyDoctorId = reader.GetString(5);
                        obj.CuringDoctorId = reader.GetString(6);
                        obj.SubstitutionDoctorId = reader.GetString(7);
                        obj.DirCardioReanimDoctorId = reader.GetString(8);
                        obj.AnesthetistDoctorId = reader.GetString(9);
                        obj.Active = reader.GetBoolean(10);
                        obj.RejectCure = reader.GetBoolean(11);
                        obj.Death = reader.GetBoolean(12);
                        obj.RoomCell = reader.GetString(13);
                        obj.Diagnosis = reader.GetString(14);
                        obj.ReleaseType = reader.GetInt16(15);

                        if (obj.PatientId != null)
                        {
                            DdtPatientV2 patient = new DdtPatientV2();
                            patient.Id = reader.GetString(16);
                            patient.Created = reader.GetDateTime(17);
                            patient.Modified = reader.GetDateTime(18);
                            patient.FullName = reader.GetString(19);
                            patient.Initials = reader.GetString(20);
                            patient.Phone = reader.GetString(21);
                            patient.Address = reader.GetString(22);
                            patient.Birthdate = reader.GetDateTime(23);
                            patient.Weight = reader.GetDouble(24);
                            patient.High = reader.GetDouble(25);
                            patient.Snils = reader.GetString(26);
                            patient.Oms = reader.GetString(26);
                            patient.MedCode = reader.GetString(27);
                            patient.PassportSerial = reader.GetString(28);
                            patient.PassportNum = reader.GetString(29);
                            patient.PassportDate = reader.GetDateTime(30);
                            patient.PassportIssuePlace = reader.GetString(31);
                            patient.Sd = reader.GetBoolean(32);

                            obj.Patient = patient;
                        }

                        return obj;
                    }
                }
                return null;
            }
        }

        public void update(DdtHospitalV2 obj)
        {
            throw new NotImplementedException();
        }
    }
}
