using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;
using NLog;
using System.Globalization;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtConsiliumGroupMemberService : IDdtConsiliumGroupMemberService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtConsiliumGroupMemberService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtConsiliumGroupMember> GetAll()
        {
            IList<DdtConsiliumGroupMember> list = new List<DdtConsiliumGroupMember>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dsid_doctor, dsid_group FROM ddt_consilium_group_member";

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtConsiliumGroupMember obj = new DdtConsiliumGroupMember();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Doctor = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Group = reader.IsDBNull(5) ? null : reader.GetString(5);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtConsiliumGroupMember> GetDefault()
        {
            IList<DdtConsiliumGroupMember> list = new List<DdtConsiliumGroupMember>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dsid_doctor, dsid_group FROM ddt_consilium_group_member WHERE dsb_default = TRUE";

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtConsiliumGroupMember obj = new DdtConsiliumGroupMember();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Doctor = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Group = reader.IsDBNull(5) ? null : reader.GetString(5);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtConsiliumGroupMember GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dsid_doctor, dsid_group FROM ddt_consilium_group_member WHERE r_object_id = '{0}'", id);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtConsiliumGroupMember obj = new DdtConsiliumGroupMember();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Doctor = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Group = reader.IsDBNull(5) ? null : reader.GetString(5);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtConsiliumGroupMember GetByGroupName(string groupName)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dsid_doctor, dsid_group FROM ddt_consilium_group_member WHERE dss_name = '{0}'", groupName);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtConsiliumGroupMember obj = new DdtConsiliumGroupMember();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Doctor = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Group = reader.IsDBNull(5) ? null : reader.GetString(5);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtConsiliumGroupMember GetByDoctorAndGroupId(string doctorId, string groupId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dsid_doctor, dsid_group " +
                    "FROM ddt_consilium_group_member WHERE dsid_doctor = '{0}' AND dsid_group = '{1}'", doctorId, groupId);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtConsiliumGroupMember obj = new DdtConsiliumGroupMember();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ModifyDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.Name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Doctor = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Group = reader.IsDBNull(5) ? null : reader.GetString(5);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtConsiliumGroupMember obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_consilium_group_member SET " +
                                          "dsid_group = @Group, " +
                                        "dss_name = @Name, " +
                                        "dsid_doctor = @Doctor, " +
                                        "dsid_group = @Group " +
                                         "WHERE r_object_id = @ObjectId";

                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Group", obj.Group);
                        cmd.Parameters.AddWithValue("@Name", obj.Name == null ? "" : obj.Name);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Group", obj.Group);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_consilium_group_member(dsid_group,dss_name,dsid_doctor,dsid_group) " +
                                                              "VALUES(@Group,@Name,@Doctor,@Group) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Group", obj.Group);
                        cmd.Parameters.AddWithValue("@Name", obj.Name == null ? "" : obj.Name);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Group", obj.Group);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }
    }
}
