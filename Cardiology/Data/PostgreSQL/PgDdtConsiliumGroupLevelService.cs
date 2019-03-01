using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtConsiliumGroupLevelService : IDdtConsiliumGroupLevelService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtConsiliumGroupLevelService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtConsiliumGroupLevel> GetAll()
        {
            IList<DdtConsiliumGroupLevel> list = new List<DdtConsiliumGroupLevel>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsi_level, dsid_group FROM ddt_consilium_group_level";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtConsiliumGroupLevel obj = new DdtConsiliumGroupLevel();
                        obj.ObjectId = reader.GetString(1);
                        obj.Level = reader.GetInt16(2);
                        obj.Group = reader.GetString(3);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtConsiliumGroupLevel GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsi_level, dsid_group FROM ddt_consilium_group_level WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtConsiliumGroupLevel obj = new DdtConsiliumGroupLevel();
                        obj.ObjectId = reader.GetString(1);
                        obj.Level = reader.GetInt16(2);
                        obj.Group = reader.GetString(3);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtConsiliumGroupLevel obj)
        {
            throw new NotImplementedException();
        }
    }
}
