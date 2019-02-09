using System;
using System.Collections.Generic;
using System.Data.Common;
using Cardiology.Data.Model2;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDoctorService : IDbDoctorService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDoctorService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtDoctorV2> GetAll()
        {
            IList<DdtDoctorV2> list = new List<DdtDoctorV2>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_creation_date, r_modify_date, dss_login, " +
                    "dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type FROM ddt_doctors";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtDoctorV2 obj = new DdtDoctorV2();
                        obj.Id = reader.GetString(0);
                        obj.Created = reader.GetDateTime(1);
                        obj.Modified = reader.GetDateTime(2);
                        obj.Login = reader.GetString(3);
                        obj.FullName = reader.GetString(4);
                        obj.Initials = reader.GetString(5);
                        obj.AppointmentName = reader.GetString(6);
                        obj.Phone = reader.GetString(7);
                        obj.AppointmentType = reader.GetInt16(8);

                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtDoctorV2> GetDoctorsByGroupName(string groupName)
        {
            IList<DdtDoctorV2> list = new List<DdtDoctorV2>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT d.r_object_id, d.r_creation_date, d.r_modify_date, d.dss_login, " +
                    "d.dss_full_name, d.dss_initials, d.dss_appointment_name, d.dss_phone, d.dsi_appointment_type " +
                    "FROM ddt_doctors d, dm_group_users g WHERE g.dss_group_name = '{0}' AND g.dss_user_name = d.dss_login", groupName);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtDoctorV2 obj = new DdtDoctorV2();
                        obj.Id = reader.GetString(0);
                        obj.Created = reader.GetDateTime(1);
                        obj.Modified = reader.GetDateTime(2);
                        obj.Login = reader.GetString(3);
                        obj.FullName = reader.GetString(4);
                        obj.Initials = reader.GetString(5);
                        obj.AppointmentName = reader.GetString(6);
                        obj.Phone = reader.GetString(7);
                        obj.AppointmentType = reader.GetInt16(8);

                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
