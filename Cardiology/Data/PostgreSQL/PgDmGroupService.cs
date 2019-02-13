using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDmGroupService : IDmGroupService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDmGroupService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DmGroup> GetAll()
        {
            IList<DmGroup> list = new List<DmGroup>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_modify_date, dss_description, r_creation_date, dss_name FROM dm_group";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DmGroup obj = new DmGroup();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.Description = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.Name = reader.GetString(5);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
