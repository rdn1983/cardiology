using Cardiology.Data.Commons;
using Cardiology.Data.Model2;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtRelationService : IDdtRelationService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtRelationService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public DdtRelation GetById(string id)
        {
            String sql = String.Format("SELECT r_object_id, dsid_parent, dsid_child, dss_child_type FROM ddt_relation " +
               "WHERE r_object_id='{0}' ", id);
            IList<DdtRelation> result = Select(sql);
            if (result.Count > 0)
            {
                return result[0];
            }
            else
            {
                return null;
            }
        }

        public IList<DdtRelation> GetByParentId(string parentId)
        {
            String sql = String.Format("SELECT r_object_id, dsid_parent, dsid_child, dss_child_type FROM ddt_relation " +
               "WHERE dsid_parent='{0}' ", parentId);
            return Select(sql);
        }

        public DdtRelation GetByParentAndChildIds(string parentId, string childId)
        {
            String sql = String.Format("SELECT r_object_id, dsid_parent, dsid_child, dss_child_type FROM ddt_relation " +
               "WHERE dsid_parent='{0}' AND dsid_child='{1}'", parentId, childId);
            IList<DdtRelation> result = Select(sql);
            if (result.Count > 0)
            {
                return result[0];
            }
            else
            {
                return null;
            }
        }

        public IList<DdtRelation> GetByParentAndChildType(string parentId, string childType)
        {
            String sql = String.Format("SELECT r_object_id, dsid_parent, dsid_child, dss_child_type FROM ddt_relation " +
                "WHERE dsid_parent='{0}' AND dss_child_type='{1}'", parentId, childType);
            return Select(sql);
        }

        private IList<DdtRelation> Select(string query)
        {
            IList<DdtRelation> list = new List<DdtRelation>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", query);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtRelation obj = new DdtRelation();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Parent = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Child = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.ChildType = reader.IsDBNull(3) ? null : reader.GetString(3);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public string Save(DdtRelation relation)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(relation.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_relation SET " +
                                        "dsid_parent = @Parent, " +
                                        "dsid_child = @Child, " +
                                        "dss_child_type = @ChildType " +
                                         "WHERE r_object_id = @ObjectId";

                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Parent", relation.Parent);
                        cmd.Parameters.AddWithValue("@Child", relation.Child);
                        cmd.Parameters.AddWithValue("@ChildType", relation.ChildType);
                        cmd.Parameters.AddWithValue("@ObjectId", relation.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return relation.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_relation(dsid_parent,dsid_child,dss_child_type) " +
                                    "VALUES(@Parent,@Child,@ChildType) RETURNING r_object_id";

                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Parent", relation.Parent);
                        cmd.Parameters.AddWithValue("@Child", relation.Child);
                        cmd.Parameters.AddWithValue("@ChildType", relation.ChildType);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

        public void RemoveConnectionByParentAndChildIds(string parentId, string childId)
        {
            String query = String.Format("DELETE FROM ddt_relation WHERE dsid_parent='{0}' AND dsid_child='{1}'", parentId, childId);
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", query);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                command.ExecuteScalar();
            }
        }

        public void RemoveConnectionById(string id)
        {
            String query = String.Format("DELETE FROM ddt_relation WHERE r_object_id='{0}' ", id);
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", query);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                command.ExecuteScalar();
            }
        }
    }
}
