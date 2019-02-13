using System;
using System.Data.Common;
using System.Collections.Generic;
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
                String sql = "SELECT r_object_id, dss_address, dss_middle_name, dss_passport_num, dss_first_name, dsd_weight, r_creation_date, dss_snils, dss_last_name, dss_passport_date, r_modify_date, dss_phone, dss_oms, dss_passport_serial, dsdt_birthdate, dsb_sd, dss_med_code, dss_passport_issue_place, dsd_high FROM ddt_patient";
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
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.Phone = reader.GetString(12);
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
                String sql = String.Format("SELECT r_object_id, dss_address, dss_middle_name, dss_passport_num, dss_first_name, dsd_weight, r_creation_date, dss_snils, dss_last_name, dss_passport_date, r_modify_date, dss_phone, dss_oms, dss_passport_serial, dsdt_birthdate, dsb_sd, dss_med_code, dss_passport_issue_place, dsd_high FROM ddt_patient WHERE r_object_id = '{0}'", id);
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
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.Phone = reader.GetString(12);
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
    }
}
