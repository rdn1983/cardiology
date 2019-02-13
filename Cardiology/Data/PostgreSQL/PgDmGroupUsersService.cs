using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDmGroupUsersService : IDmGroupUsersService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDmGroupUsersService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DmGroupUsers> GetAll()
        {
            IList<DmGroupUsers> list = new List<DmGroupUsers>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_modify_date, r_creation_date, dsid_doctor_id, dss_group_name FROM dm_group_users";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DmGroupUsers obj = new DmGroupUsers();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.DoctorId = reader.GetString(4);
                        obj.GroupName = reader.GetString(5);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
