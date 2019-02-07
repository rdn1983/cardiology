using System;
using System.Collections.Generic;
using System.Data.Common;
using Cardiology.Data.Model2;

namespace Cardiology.Data.PostgreSQL
{
    class PgGroupService : IDbGroupService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgGroupService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DmGroupV2> GetList()
        {
            IList<DmGroupV2> list = new List<DmGroupV2>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_creation_date, r_modify_date, dss_name, dss_description FROM dm_group ORDER BY 2";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DmGroupV2 obj = new DmGroupV2();
                        obj.Id = reader.GetString(0);
                        obj.Created = reader.GetDateTime(1);
                        obj.Modified = reader.GetDateTime(2);
                        obj.Name = reader.GetString(3);
                        obj.Description = reader.GetString(4);

                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
