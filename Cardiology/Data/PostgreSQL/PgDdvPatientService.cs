using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using NLog;
using System.Globalization;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdvPatientService : IDdvPatientService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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
                String sql = "SELECT dss_address, r_object_id, dss_full_name, dss_middle_name, dss_passport_num, " +
                    "dss_first_name, dsd_weight, dss_snils, r_creation_date, dss_last_name, dss_passport_date, " +
                    "r_modify_date, dss_phone, dss_passport_serial, dss_oms, dss_short_name, dsdt_birthdate, " +
                    "dsb_sd, dss_med_code, dss_passport_issue_place, dsd_high, dsi_sex FROM ddv_patient";
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvPatient obj = new DdvPatient();
                        obj.Address = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.FullName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.MiddleName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.PassportNum = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.FirstName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Weight = reader.IsDBNull(6) ? -1 : reader.GetFloat(6);
                        obj.Snils = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.CreationDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.LastName = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.PassportDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.Phone = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.PassportSerial = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Oms = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.ShortName = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.Birthdate = reader.IsDBNull(16) ? DateTime.MinValue : reader.GetDateTime(16);
                        obj.Sd = reader.GetBoolean(17);
                        obj.MedCode = reader.IsDBNull(18) ? null : reader.GetString(18);
                        obj.PassportIssuePlace = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.High = reader.IsDBNull(20) ? -1 : reader.GetFloat(20);
                        obj.Sex = reader.IsDBNull(21) ? -1 : reader.GetInt16(21);
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
                String sql = String.Format("SELECT dss_address, r_object_id, dss_full_name, dss_middle_name, " +
                    "dss_passport_num, dss_first_name, dsd_weight, dss_snils, r_creation_date, dss_last_name, " +
                    "dss_passport_date, r_modify_date, dss_phone, dss_passport_serial, dss_oms, dss_short_name, " +
                    "dsdt_birthdate, dsb_sd, dss_med_code, dss_passport_issue_place, dsd_high, dsi_sex FROM ddv_patient" +
                    " WHERE r_object_id = '{0}'", id);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdvPatient obj = new DdvPatient();
                        obj.Address = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.FullName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.MiddleName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.PassportNum = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.FirstName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Weight = reader.IsDBNull(6) ? -1 : reader.GetFloat(6);
                        obj.Snils = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.CreationDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.LastName = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.PassportDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.Phone = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.PassportSerial = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Oms = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.ShortName = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.Birthdate = reader.IsDBNull(16) ? DateTime.MinValue : reader.GetDateTime(16);
                        obj.Sd = reader.GetBoolean(17);
                        obj.MedCode = reader.IsDBNull(18) ? null : reader.GetString(18);
                        obj.PassportIssuePlace = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.High = reader.IsDBNull(20) ? -1 : reader.GetFloat(20);
                        obj.Sex = reader.IsDBNull(21) ? -1 : reader.GetInt16(21);
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
                String sql = String.Format("SELECT dss_address, r_object_id, dss_full_name, dss_middle_name, " +
                    "dss_passport_num, dss_first_name, dsd_weight, dss_snils, r_creation_date, dss_last_name, " +
                    "dss_passport_date, r_modify_date, dss_phone, dss_passport_serial, dss_oms, dss_short_name, " +
                    "dsdt_birthdate, dsb_sd, dss_med_code, dss_passport_issue_place, dsd_high, dsi_sex FROM ddv_patient" +
                    " WHERE r_object_id = '{0}'", id);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdvPatient obj = new DdvPatient();
                        obj.Address = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.FullName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.MiddleName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.PassportNum = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.FirstName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Weight = reader.IsDBNull(6) ? -1 : reader.GetFloat(6);
                        obj.Snils = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.CreationDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.LastName = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.PassportDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.Phone = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.PassportSerial = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Oms = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.ShortName = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.Birthdate = reader.IsDBNull(16) ? DateTime.MinValue : reader.GetDateTime(16);
                        obj.Sd = reader.GetBoolean(17);
                        obj.MedCode = reader.IsDBNull(18) ? null : reader.GetString(18);
                        obj.PassportIssuePlace = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.High = reader.IsDBNull(20) ? -1 : reader.GetFloat(20);
                        obj.Sex = reader.IsDBNull(21) ? -1 : reader.GetInt16(21);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
