using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cardiology.Data.Model2;

namespace Cardiology.Data.PostgreSQL
{
    public class PgCureService : IDbCureService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgCureService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtCureTypeV2> GetAllTypes()
        {
            IList<DdtCureTypeV2> list = new List<DdtCureTypeV2>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_creation_date, r_modify_date, dss_name FROM ddt_cure_type";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCureTypeV2 obj = new DdtCureTypeV2();
                        obj.Id = reader.GetString(0);
                        obj.Created = reader.GetDateTime(1);
                        obj.Modified = reader.GetDateTime(2);
                        obj.Name = reader.GetString(3);

                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
