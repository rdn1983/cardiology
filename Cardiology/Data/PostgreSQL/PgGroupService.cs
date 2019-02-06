using System;
using System.Collections.Generic;
using System.Data.Common;
using Cardiology.Data.Model2;

namespace Cardiology.Data.PostgreSQL
{
    class PgGroupService : IDmGroupService
    {
        private IDbConnectionFactory connectionFactory;

        public PgGroupService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DmGroupV2> GetList()
        {
            IList<DmGroupV2> list = new List<DmGroupV2>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dss_name, dss_description FROM dm_group ORDER BY 2";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DmGroupV2 obj = new DmGroupV2();
                        obj.Name = reader.GetString(0);
                        obj.Description = reader.GetString(1);

                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
