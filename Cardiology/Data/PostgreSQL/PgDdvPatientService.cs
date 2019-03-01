using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdvPatientService : IDdvPatientService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdvPatientService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdvPatient> GetAll()
        {
            IList<DdvPatient> list = new List<DdvPatient>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dss_address, r_object_id, dss_full_name, dss_middle_name, dss_passport_num, dss_first_name, dsd_weight, dss_snils, r_creation_date, dss_last_name, dss_passport_date, r_modify_date, dss_phone, dss_passport_serial, dss_oms, dss_short_name, dsdt_birthdate, dsb_sd, dss_med_code, dss_passport_issue_place, dsd_high FROM ddv_patient";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvPatient obj = new DdvPatient();
                        obj.Address = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.FullName = reader.GetString(3);
                        obj.MiddleName = reader.GetString(4);
                        obj.PassportNum = reader.GetString(5);
                        obj.FirstName = reader.GetString(6);
                        obj.Weight = reader.GetFloat(7);
                        obj.Snils = reader.GetString(8);
                        obj.CreationDate = reader.GetDateTime(9);
                        obj.LastName = reader.GetString(10);
                        obj.PassportDate = reader.GetDateTime(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.Phone = reader.GetString(13);
                        obj.PassportSerial = reader.GetString(14);
                        obj.Oms = reader.GetString(15);
                        obj.ShortName = reader.GetString(16);
                        obj.Birthdate = reader.GetDateTime(17);
                        obj.Sd = reader.GetBoolean(18);
                        obj.MedCode = reader.GetString(19);
                        obj.PassportIssuePlace = reader.GetString(20);
                        obj.High = reader.GetFloat(21);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdvPatient GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dss_address, r_object_id, dss_full_name, dss_middle_name, dss_passport_num, dss_first_name, dsd_weight, dss_snils, r_creation_date, dss_last_name, dss_passport_date, r_modify_date, dss_phone, dss_passport_serial, dss_oms, dss_short_name, dsdt_birthdate, dsb_sd, dss_med_code, dss_passport_issue_place, dsd_high FROM ddv_patient WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdvPatient obj = new DdvPatient();
                        obj.Address = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.FullName = reader.GetString(3);
                        obj.MiddleName = reader.GetString(4);
                        obj.PassportNum = reader.GetString(5);
                        obj.FirstName = reader.GetString(6);
                        obj.Weight = reader.GetFloat(7);
                        obj.Snils = reader.GetString(8);
                        obj.CreationDate = reader.GetDateTime(9);
                        obj.LastName = reader.GetString(10);
                        obj.PassportDate = reader.GetDateTime(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.Phone = reader.GetString(13);
                        obj.PassportSerial = reader.GetString(14);
                        obj.Oms = reader.GetString(15);
                        obj.ShortName = reader.GetString(16);
                        obj.Birthdate = reader.GetDateTime(17);
                        obj.Sd = reader.GetBoolean(18);
                        obj.MedCode = reader.GetString(19);
                        obj.PassportIssuePlace = reader.GetString(20);
                        obj.High = reader.GetFloat(21);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdvPatient GetByHospitalSession(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dss_address, r_object_id, dss_full_name, dss_middle_name, dss_passport_num, dss_first_name, dsd_weight, dss_snils, r_creation_date, dss_last_name, dss_passport_date, r_modify_date, dss_phone, dss_passport_serial, dss_oms, dss_short_name, dsdt_birthdate, dsb_sd, dss_med_code, dss_passport_issue_place, dsd_high FROM ddv_patient WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdvPatient obj = new DdvPatient();
                        obj.Address = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.FullName = reader.GetString(3);
                        obj.MiddleName = reader.GetString(4);
                        obj.PassportNum = reader.GetString(5);
                        obj.FirstName = reader.GetString(6);
                        obj.Weight = reader.GetFloat(7);
                        obj.Snils = reader.GetString(8);
                        obj.CreationDate = reader.GetDateTime(9);
                        obj.LastName = reader.GetString(10);
                        obj.PassportDate = reader.GetDateTime(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.Phone = reader.GetString(13);
                        obj.PassportSerial = reader.GetString(14);
                        obj.Oms = reader.GetString(15);
                        obj.ShortName = reader.GetString(16);
                        obj.Birthdate = reader.GetDateTime(17);
                        obj.Sd = reader.GetBoolean(18);
                        obj.MedCode = reader.GetString(19);
                        obj.PassportIssuePlace = reader.GetString(20);
                        obj.High = reader.GetFloat(21);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
