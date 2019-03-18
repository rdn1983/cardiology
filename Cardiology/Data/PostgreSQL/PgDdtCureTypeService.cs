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
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtCureType GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, r_creation_date, dss_name FROM ddt_cure_type WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtCureType obj = new DdtCureType();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
