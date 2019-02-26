using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtConsiliumMemberService : IDdtConsiliumMemberService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtConsiliumMemberService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtConsiliumMember> GetAll()
        {
            IList<DdtConsiliumMember> list = new List<DdtConsiliumMember>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_modify_date, dsid_consilium, r_creation_date, dsid_doctor FROM ddt_consilium_member";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtConsiliumMember obj = new DdtConsiliumMember();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.Consilium = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.Doctor = reader.GetString(5);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtConsiliumMember GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, dsid_consilium, r_creation_date, dsid_doctor FROM ddt_consilium_member WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtConsiliumMember obj = new DdtConsiliumMember();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.Consilium = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.Doctor = reader.GetString(5);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtConsiliumMember obj)
        {
            throw new NotImplementedException();
        }
    }
}
