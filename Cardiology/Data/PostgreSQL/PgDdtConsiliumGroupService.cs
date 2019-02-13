using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtConsiliumGroupService : IDdtConsiliumGroupService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtConsiliumGroupService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtConsiliumGroup> GetAll()
        {
            IList<DdtConsiliumGroup> list = new List<DdtConsiliumGroup>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_modify_date, r_creation_date, dss_name FROM ddt_consilium_group";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtConsiliumGroup obj = new DdtConsiliumGroup();
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

        public DdtConsiliumGroup GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, r_creation_date, dss_name FROM ddt_consilium_group WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtConsiliumGroup obj = new DdtConsiliumGroup();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
