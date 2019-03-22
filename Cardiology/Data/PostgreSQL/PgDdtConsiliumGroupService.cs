using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;

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
                String sql = "SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dsi_level FROM ddt_consilium_group";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtConsiliumGroup obj = new DdtConsiliumGroup();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(0) ? null : reader.GetString(3);
                        obj.Level = reader.GetInt16(4);
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
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(0) ? null : reader.GetString(3);
                        obj.Level = reader.GetInt16(4);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtConsiliumGroup obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_consilium_group SET " +
                                          "dss_name = @Name, " +
                                        "dsi_level = @Level " +
                                         "WHERE r_object_id = @ObjectId";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Name", obj.Name == null ? "" : obj.Name);
                        cmd.Parameters.AddWithValue("@Level", obj.Level);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_consilium_group(dss_name,dsi_level) " +
                                                              "VALUES(@Name,@Level) RETURNING r_object_id";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Name", obj.Name == null ? "" : obj.Name);
                        cmd.Parameters.AddWithValue("@Level", obj.Level);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
