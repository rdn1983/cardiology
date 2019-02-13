using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

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
                        obj.ObjectId = reader.GetString(1);
                        obj.Diagnosis = reader.GetString(2);
                        obj.DutyDoctor = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.ReleaseType = reader.GetInt16(5);
                        obj.AdmissionDate = reader.GetDateTime(6);
                        obj.Patient = reader.GetString(7);
                        obj.CuringDoctor = reader.GetString(8);
                        obj.Active = reader.GetBoolean(9);
                        obj.ModifyDate = reader.GetDateTime(10);
                        obj.RejectCure = reader.GetBoolean(11);
                        obj.RoomCell = reader.GetString(12);
                        obj.Death = reader.GetBoolean(13);
                        obj.DirCardioReanimDoctor = reader.GetString(14);
                        obj.SubstitutionDoctor = reader.GetString(15);
                        obj.AnesthetistDoctor = reader.GetString(16);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.Diagnosis = reader.GetString(2);
                        obj.DutyDoctor = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.ReleaseType = reader.GetInt16(5);
                        obj.AdmissionDate = reader.GetDateTime(6);
                        obj.Patient = reader.GetString(7);
                        obj.CuringDoctor = reader.GetString(8);
                        obj.Active = reader.GetBoolean(9);
                        obj.ModifyDate = reader.GetDateTime(10);
                        obj.RejectCure = reader.GetBoolean(11);
                        obj.RoomCell = reader.GetString(12);
                        obj.Death = reader.GetBoolean(13);
                        obj.DirCardioReanimDoctor = reader.GetString(14);
                        obj.SubstitutionDoctor = reader.GetString(15);
                        obj.AnesthetistDoctor = reader.GetString(16);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
