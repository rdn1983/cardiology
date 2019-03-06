using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtConsiliumGroupMemberService : IDdtConsiliumGroupMemberService
    {
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
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtConsiliumGroupMember obj = new DdtConsiliumGroupMember();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.Doctor = reader.GetString(5);
                        obj.Group = reader.GetString(6);
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
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtConsiliumGroupMember obj = new DdtConsiliumGroupMember();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.Doctor = reader.GetString(5);
                        obj.Group = reader.GetString(6);
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
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtConsiliumGroupMember obj = new DdtConsiliumGroupMember();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.Doctor = reader.GetString(5);
                        obj.Group = reader.GetString(6);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtConsiliumGroupMember GetByDoctorId(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dsid_doctor, dsid_group FROM ddt_consilium_group_member WHERE dsid_doctor = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtConsiliumGroupMember obj = new DdtConsiliumGroupMember();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.Doctor = reader.GetString(5);
                        obj.Group = reader.GetString(6);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtConsiliumGroupMember obj)
        {
            throw new NotImplementedException();
        }
    }
}
