using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtPatientService : IDdtPatientService
    {
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
                String sql = "SELECT r_object_id, dss_address, dss_middle_name, dss_passport_num, dss_first_name, dsd_weight, r_creation_date, dss_snils, dss_last_name, dss_passport_date, dss_phone, r_modify_date, dss_oms, dss_passport_serial, dsdt_birthdate, dsb_sd, dss_med_code, dss_passport_issue_place, dsd_high FROM ddt_patient";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtPatient obj = new DdtPatient();
                        obj.ObjectId = reader.GetString(1);
                        obj.Address = reader.GetString(2);
                        obj.MiddleName = reader.GetString(3);
                        obj.PassportNum = reader.GetString(4);
                        obj.FirstName = reader.GetString(5);
                        obj.Weight = reader.GetFloat(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.Snils = reader.GetString(8);
                        obj.LastName = reader.GetString(9);
                        obj.PassportDate = reader.GetDateTime(10);
                        obj.Phone = reader.GetString(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.Oms = reader.GetString(13);
                        obj.PassportSerial = reader.GetString(14);
                        obj.Birthdate = reader.GetDateTime(15);
                        obj.Sd = reader.GetBoolean(16);
                        obj.MedCode = reader.GetString(17);
                        obj.PassportIssuePlace = reader.GetString(18);
                        obj.High = reader.GetFloat(19);
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
                String sql = String.Format("SELECT r_object_id, dss_address, dss_middle_name, dss_passport_num, dss_first_name, dsd_weight, r_creation_date, dss_snils, dss_last_name, dss_passport_date, dss_phone, r_modify_date, dss_oms, dss_passport_serial, dsdt_birthdate, dsb_sd, dss_med_code, dss_passport_issue_place, dsd_high FROM ddt_patient WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtPatient obj = new DdtPatient();
                        obj.ObjectId = reader.GetString(1);
                        obj.Address = reader.GetString(2);
                        obj.MiddleName = reader.GetString(3);
                        obj.PassportNum = reader.GetString(4);
                        obj.FirstName = reader.GetString(5);
                        obj.Weight = reader.GetFloat(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.Snils = reader.GetString(8);
                        obj.LastName = reader.GetString(9);
                        obj.PassportDate = reader.GetDateTime(10);
                        obj.Phone = reader.GetString(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.Oms = reader.GetString(13);
                        obj.PassportSerial = reader.GetString(14);
                        obj.Birthdate = reader.GetDateTime(15);
                        obj.Sd = reader.GetBoolean(16);
                        obj.MedCode = reader.GetString(17);
                        obj.PassportIssuePlace = reader.GetString(18);
                        obj.High = reader.GetFloat(19);
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
                                            dss_last_name, = @lastName 
                                            dss_passport_date = @passportDate, 
                                            dss_phone = @phone, 
                                            dss_oms = @oms, 
                                            dss_passport_serial = @passportSerial, 
                                            dsdt_birthdate = @birthDate, 
                                            dsb_sd = @sd, 
                                            dss_med_code = @medCode, 
                                            dss_passport_issue_place = @passportIssuePlace, 
                                            dsd_high = @hight 
                                            WHERE r_object_id = @ObjectId";

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
                        cmd.Parameters.AddWithValue("@sd", obj.Sd);
                        cmd.Parameters.AddWithValue("@medCode", obj.MedCode);
                        cmd.Parameters.AddWithValue("@passportIssuePlace", obj.PassportIssuePlace);
                        cmd.Parameters.AddWithValue("@hight", obj.High);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);

                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string sql = @"INSERT INTO ddt_patient (
	                                    dss_address, 
	                                    dss_middle_name, 
	                                    dss_passport_num, 
	                                    dss_first_name, 
	                                    dsd_weight, 
	                                    dss_snils, 
	                                    dss_last_name, 
	                                    dss_passport_date, 
	                                    dss_phone, 
	                                    dss_oms,
	                                    dss_passport_serial, 
	                                    dsdt_birthdate, 
	                                    dsb_sd, 
	                                    dss_med_code, 
	                                    dss_passport_issue_place, 
	                                    dsd_high
                                    ) VALUES (
	                                    @address, 
	                                    @middleName, 
	                                    @passportNum, 
	                                    @firstName, 
	                                    @weight, 
	                                    @snils, 
	                                    @lastName 
	                                    @passportDate, 
	                                    @phone, 
	                                    @oms, 
	                                    @passportSerial, 
	                                    @birthDate, 
	                                    @sd, 
	                                    @medCode, 
	                                    @passportIssuePlace, 
	                                    @hight 
                                    )";

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
                        cmd.Parameters.AddWithValue("@sd", obj.Sd);
                        cmd.Parameters.AddWithValue("@medCode", obj.MedCode);
                        cmd.Parameters.AddWithValue("@passportIssuePlace", obj.PassportIssuePlace);
                        cmd.Parameters.AddWithValue("@hight", obj.High);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);

                        obj.ObjectId = (string) cmd.ExecuteScalar();
                    }
                }

                return obj.ObjectId;
            }
        }
    }
}
