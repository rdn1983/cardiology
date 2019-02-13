using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtConsiliumMemberLevelService : IDdtConsiliumMemberLevelService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtConsiliumMemberLevelService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtConsiliumMemberLevel> GetAll()
        {
            IList<DdtConsiliumMemberLevel> list = new List<DdtConsiliumMemberLevel>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsi_level, dss_group_name FROM ddt_consilium_member_level";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtConsiliumMemberLevel obj = new DdtConsiliumMemberLevel();
                        obj.ObjectId = reader.GetString(1);
                        obj.Level = reader.GetInt16(2);
                        obj.GroupName = reader.GetString(3);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtConsiliumMemberLevel GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsi_level, dss_group_name FROM ddt_consilium_member_level WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtConsiliumMemberLevel obj = new DdtConsiliumMemberLevel();
                        obj.ObjectId = reader.GetString(1);
                        obj.Level = reader.GetInt16(2);
                        obj.GroupName = reader.GetString(3);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
