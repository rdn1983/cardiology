using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtCureTypeService : IDdtCureTypeService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtCureTypeService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtCureType> GetAll()
        {
            IList<DdtCureType> list = new List<DdtCureType>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_modify_date, r_creation_date, dss_name FROM ddt_cure_type";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCureType obj = new DdtCureType();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
