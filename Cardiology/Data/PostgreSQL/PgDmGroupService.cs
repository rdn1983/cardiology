using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using NLog;
using System.Globalization;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDmGroupService : IDmGroupService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDmGroupService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DmGroup> GetAll()
        {
            IList<DmGroup> list = new List<DmGroup>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dss_description, r_modify_date, r_creation_date, dss_name FROM dm_group";
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DmGroup obj = new DmGroup();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Description = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ModifyDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Name = reader.IsDBNull(4) ? null : reader.GetString(4);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DmGroup GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_description, r_modify_date, r_creation_date, dss_name FROM dm_group WHERE r_object_id = '{0}'", id);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DmGroup obj = new DmGroup();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Description = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ModifyDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Name = reader.IsDBNull(4) ? null : reader.GetString(4);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DmGroup GetGroupByName(string groupName)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_description, r_modify_date, r_creation_date, dss_name FROM dm_group WHERE dss_name = '{0}'", groupName);
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DmGroup obj = new DmGroup();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Description = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ModifyDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Name = reader.IsDBNull(4) ? null : reader.GetString(4);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
