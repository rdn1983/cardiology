using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;
using NpgsqlTypes;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtHospitalService : IDdtHospitalService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtHospitalService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtHospital> GetAll()
        {
            IList<DdtHospital> list = new List<DdtHospital>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dss_diagnosis, dsid_duty_doctor, r_creation_date, dsi_release_type, dsdt_admission_date, dsid_patient, dsid_curing_doctor, dsb_active, r_modify_date, dsb_reject_cure, dss_room_cell, dsb_death, dsid_dir_cardio_reanim_doctor, dsid_substitution_doctor, dsid_anesthetist_doctor FROM ddt_hospital";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtHospital obj = new DdtHospital();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Diagnosis = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.DutyDoctor = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ReleaseType = reader.GetInt16(4);
                        obj.AdmissionDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Patient = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.CuringDoctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Active = reader.GetBoolean(8);
                        obj.ModifyDate = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                        obj.RejectCure = reader.GetBoolean(10);
                        obj.RoomCell = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Death = reader.GetBoolean(12);
                        obj.DirCardioReanimDoctor = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.SubstitutionDoctor = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.AnesthetistDoctor = reader.IsDBNull(15) ? null : reader.GetString(15);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtHospital GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_diagnosis, dsid_duty_doctor, r_creation_date, dsi_release_type, dsdt_admission_date, dsid_patient, dsid_curing_doctor, dsb_active, r_modify_date, dsb_reject_cure, dss_room_cell, dsb_death, dsid_dir_cardio_reanim_doctor, dsid_substitution_doctor, dsid_anesthetist_doctor FROM ddt_hospital WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtHospital obj = new DdtHospital();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Diagnosis = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.DutyDoctor = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ReleaseType = reader.GetInt16(4);
                        obj.AdmissionDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Patient = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.CuringDoctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Active = reader.GetBoolean(8);
                        obj.ModifyDate = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                        obj.RejectCure = reader.GetBoolean(10);
                        obj.RoomCell = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Death = reader.GetBoolean(12);
                        obj.DirCardioReanimDoctor = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.SubstitutionDoctor = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.AnesthetistDoctor = reader.IsDBNull(15) ? null : reader.GetString(15);
                        return obj;
                    }
                }
            }
            return null;
        }


        public void Save(DdtHospital hospital)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(hospital.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_hospital SET " +
                                          "dss_diagnosis = @Diagnosis," +
                                          "dsid_duty_doctor = @DutyDoctor," +
                                          "dsi_release_type = @ReleaseType," +
                                          "dsdt_admission_date = @AdmissionDate," +
                                          "dsid_patient = @Patient," +
                                          "dsid_curing_doctor = @CuringDoctor," +
                                          "dsb_active = @Active," +
                                          "dsb_reject_cure = @RejectCure," +
                                          "dss_room_cell = @RoomCell," +
                                          "dsb_death = @Death," +
                                          "dsid_dir_cardio_reanim_doctor = @DirCardioReanimDoctor," +
                                          "dsid_substitution_doctor = @SubstitutionDoctor," +
                                          "dsid_anesthetist_doctor = @AnesthetistDoctor" +
                                          "WHERE r_object_id = @ObjectId ";

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Diagnosis", hospital.Diagnosis);
                        cmd.Parameters.AddWithValue("@DutyDoctor", hospital.DutyDoctor);
                        cmd.Parameters.AddWithValue("@ReleaseType", hospital.ReleaseType);
                        cmd.Parameters.AddWithValue("@AdmissionDate", hospital.AdmissionDate);
                        cmd.Parameters.AddWithValue("@Patient", hospital.Patient);
                        cmd.Parameters.AddWithValue("@CuringDoctor", hospital.CuringDoctor);
                        cmd.Parameters.AddWithValue("@Active", hospital.Active);
                        cmd.Parameters.AddWithValue("@RejectCure", hospital.RejectCure);
                        cmd.Parameters.AddWithValue("@RoomCell", hospital.RoomCell);
                        cmd.Parameters.AddWithValue("@Death", hospital.Death);
                        cmd.Parameters.AddWithValue("@DirCardioReanimDoctor", hospital.DirCardioReanimDoctor);
                        cmd.Parameters.AddWithValue("@SubstitutionDoctor", hospital.SubstitutionDoctor);
                        cmd.Parameters.AddWithValue("@AnesthetistDoctor", hospital.AnesthetistDoctor);
                        cmd.Parameters.AddWithValue("@ObjectId", hospital.ObjectId);

                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string sql = "INSERT INTO ddt_hospital(dss_diagnosis, dsid_duty_doctor, dsi_release_type, " +
                                          "dsdt_admission_date, dsid_patient, dsid_curing_doctor, dsb_active, dsb_reject_cure, " +
                                          "dss_room_cell, dsb_death, dsid_dir_cardio_reanim_doctor, dsid_substitution_doctor, dsid_anesthetist_doctor) " +

                                          "VALUES(@Diagnosis, @DutyDoctor, @ReleaseType, @AdmissionDate, @Patient, @CuringDoctor," +
                                          "@Active, @RejectCure, @RoomCell, @Death, @DirCardioReanimDoctor, @SubstitutionDoctor," +
                                          "@AnesthetistDoctor)";

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        if (hospital.Diagnosis != null)
                        {
                            cmd.Parameters.AddWithValue("@Diagnosis", hospital.Diagnosis);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Diagnosis", NpgsqlDbType.Varchar, DBNull.Value);
                        }

                        cmd.Parameters.AddWithValue("@DutyDoctor", hospital.DutyDoctor);
                        cmd.Parameters.AddWithValue("@ReleaseType", hospital.ReleaseType);
                        cmd.Parameters.AddWithValue("@AdmissionDate", hospital.AdmissionDate);
                        cmd.Parameters.AddWithValue("@Patient", hospital.Patient);
                        cmd.Parameters.AddWithValue("@CuringDoctor", hospital.CuringDoctor);
                        cmd.Parameters.AddWithValue("@Active", hospital.Active);
                        cmd.Parameters.AddWithValue("@RejectCure", hospital.RejectCure);
                        cmd.Parameters.AddWithValue("@RoomCell", hospital.RoomCell);
                        cmd.Parameters.AddWithValue("@Death", hospital.Death);
                        cmd.Parameters.AddWithValue("@DirCardioReanimDoctor", hospital.DirCardioReanimDoctor);
                        cmd.Parameters.AddWithValue("@SubstitutionDoctor", hospital.SubstitutionDoctor);
                        cmd.Parameters.AddWithValue("@AnesthetistDoctor", hospital.AnesthetistDoctor);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
