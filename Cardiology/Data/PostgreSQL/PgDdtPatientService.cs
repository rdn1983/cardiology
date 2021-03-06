using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Data;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using NLog;
using System.Globalization;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtPatientService : IDdtPatientService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtPatientService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtPatient> GetAll()
        {
            IList<DdtPatient> list = new List<DdtPatient>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dss_address, dss_middle_name, dss_passport_num, dss_first_name, " +
                    "dsd_weight, r_creation_date, dss_snils, dss_last_name, dss_passport_date, dss_phone," +
                    " r_modify_date, dss_oms, dss_passport_serial, dsdt_birthdate, dsb_sd, dss_med_code, " +
                    "dss_passport_issue_place, dsd_high, dsb_sex, dss_blood_group, dss_rh_factor, dss_kell, dss_phenotype FROM ddt_patient";
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtPatient obj = new DdtPatient();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Address = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.MiddleName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.PassportNum = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.FirstName = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Weight = reader.GetFloat(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Snils = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.LastName = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.PassportDate = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                        obj.Phone = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.Oms = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.PassportSerial = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Birthdate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        obj.Sd = reader.GetBoolean(15);
                        obj.MedCode = reader.IsDBNull(16) ? null : reader.GetString(16);
                        obj.PassportIssuePlace = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.High = reader.IsDBNull(18) ? -1 : reader.GetFloat(18);
                        obj.Sex = reader.GetBoolean(19);
                        obj.BloodGroup = reader.IsDBNull(20) ? null : reader.GetString(20);
                        obj.RHFactor = reader.IsDBNull(21) ? null : reader.GetString(21);
                        obj.Kell = reader.IsDBNull(22) ? null : reader.GetString(22);
                        obj.Phenotype = reader.IsDBNull(23) ? null : reader.GetString(23);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtPatient GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_address, dss_middle_name, dss_passport_num, " +
                    "dss_first_name, dsd_weight, r_creation_date, dss_snils, dss_last_name, dss_passport_date, " +
                    "dss_phone, r_modify_date, dss_oms, dss_passport_serial, dsdt_birthdate, dsb_sd, dss_med_code, " +
                    "dss_passport_issue_place, dsd_high, dsb_sex, dss_blood_group, dss_rh_factor, dss_kell, dss_phenotype FROM ddt_patient WHERE r_object_id = '{0}'", id);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtPatient obj = new DdtPatient();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Address = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.MiddleName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.PassportNum = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.FirstName = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Weight = reader.GetFloat(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Snils = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.LastName = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.PassportDate = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                        obj.Phone = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.Oms = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.PassportSerial = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Birthdate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        obj.Sd = reader.GetBoolean(15);
                        obj.MedCode = reader.IsDBNull(16) ? null : reader.GetString(16);
                        obj.PassportIssuePlace = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.High = reader.IsDBNull(18) ? -1 : reader.GetFloat(18);
                        obj.Sex = reader.GetBoolean(19);
                        obj.BloodGroup = reader.IsDBNull(20) ? null : reader.GetString(20);
                        obj.RHFactor = reader.IsDBNull(21) ? null : reader.GetString(21);
                        obj.Kell = reader.IsDBNull(22) ? null : reader.GetString(22);
                        obj.Phenotype = reader.IsDBNull(23) ? null : reader.GetString(23);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtPatient obj)
        {

            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (obj.ObjectId != null)
                {
                    string sql = @"UPDATE ddt_patient SET 
                                            dss_address = @address, 
                                            dss_middle_name = @middleName, 
                                            dss_passport_num = @passportNum, 
                                            dss_first_name = @firstName, 
                                            dsd_weight = @weight, 
                                            dss_snils = @snils, 
                                            dss_last_name = @lastName, 
                                            dss_passport_date = @passportDate, 
                                            dss_phone = @phone, 
                                            dss_oms = @oms, 
                                            dss_passport_serial = @passportSerial, 
                                            dsdt_birthdate = @birthDate, 
                                            dsb_sd = @sd, 
                                            dss_med_code = @medCode, 
                                            dss_passport_issue_place = @passportIssuePlace, 
                                            dsd_high = @hight,
                                            dsb_sex=@Sex
                                            WHERE r_object_id = @ObjectId";

                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@address", obj.Address);
                        cmd.Parameters.AddWithValue("@middleName", obj.MiddleName);
                        cmd.Parameters.AddWithValue("@passportNum", obj.PassportNum);
                        cmd.Parameters.AddWithValue("@firstName", obj.FirstName);
                        cmd.Parameters.AddWithValue("@weight", obj.Weight);
                        cmd.Parameters.AddWithValue("@snils", obj.Snils);
                        cmd.Parameters.AddWithValue("@lastName", obj.LastName);
                        cmd.Parameters.AddWithValue("@passportDate", obj.PassportDate);
                        cmd.Parameters.AddWithValue("@phone", obj.Phone);
                        cmd.Parameters.AddWithValue("@oms", obj.Oms);
                        cmd.Parameters.AddWithValue("@passportSerial", obj.PassportSerial);
                        cmd.Parameters.AddWithValue("@birthDate", obj.Birthdate);
                        cmd.Parameters.AddWithValue("@sd", obj.Sd);
                        cmd.Parameters.AddWithValue("@medCode", obj.MedCode);
                        cmd.Parameters.AddWithValue("@passportIssuePlace", obj.PassportIssuePlace);
                        cmd.Parameters.AddWithValue("@hight", obj.High);
                        cmd.Parameters.AddWithValue("@Sex", obj.Sex);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);

                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string sql = @"INSERT INTO ddt_patient (dss_address, dss_middle_name, dss_passport_num, 
                        dss_first_name, dsd_weight, dss_snils, dss_last_name, dss_passport_date, dss_phone, dss_oms, 
                        dss_passport_serial, dsdt_birthdate, dsb_sd, dss_med_code, dss_passport_issue_place, dsd_high,
                        dsb_sex) VALUES (@address, @middleName, @passportNum, @firstName, @weight, @snils, @lastName, 
                        @passportDate, @phone, @oms, @passportSerial, @birthDate, @sd, @medCode, @passportIssuePlace,
                        @hight, @Sex)  RETURNING r_object_id";

                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@address", obj.Address);
                        cmd.Parameters.AddWithValue("@middleName", obj.MiddleName);
                        cmd.Parameters.AddWithValue("@passportNum", obj.PassportNum);
                        cmd.Parameters.AddWithValue("@firstName", obj.FirstName);
                        cmd.Parameters.AddWithValue("@weight", obj.Weight);
                        cmd.Parameters.AddWithValue("@snils", obj.Snils);
                        cmd.Parameters.AddWithValue("@lastName", obj.LastName);
                        cmd.Parameters.AddWithValue("@passportDate", obj.PassportDate);
                        cmd.Parameters.AddWithValue("@phone", obj.Phone);
                        cmd.Parameters.AddWithValue("@oms", obj.Oms);
                        cmd.Parameters.AddWithValue("@passportSerial", obj.PassportSerial);
                        cmd.Parameters.AddWithValue("@birthDate", obj.Birthdate);
                        cmd.Parameters.AddWithValue("@sd", obj.Sd);
                        cmd.Parameters.AddWithValue("@medCode", obj.MedCode);
                        cmd.Parameters.AddWithValue("@passportIssuePlace", obj.PassportIssuePlace);
                        cmd.Parameters.AddWithValue("@hight", obj.High);
                        cmd.Parameters.AddWithValue("@Sex", obj.Sex);

                        obj.ObjectId = (string) cmd.ExecuteScalar();
                    }
                }

                return obj.ObjectId;
            }
        }

        public string SetBloodData(DdtPatient obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                    string sql = @"UPDATE ddt_patient SET dss_blood_group=@BloodGroup, dss_rh_factor=@RHFactor, dss_kell=@Kell, dss_phenotype=@Phenotype WHERE r_object_id = @ObjectId";

                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.Parameters.AddWithValue("@BloodGroup", obj.BloodGroup);
                        cmd.Parameters.AddWithValue("@RHFactor", obj.RHFactor);
                        cmd.Parameters.AddWithValue("@Kell", obj.Kell);
                        cmd.Parameters.AddWithValue("@Phenotype", obj.Phenotype);

                        cmd.ExecuteNonQuery();
                    }
                return obj.ObjectId;
            }
        }
    }

}
