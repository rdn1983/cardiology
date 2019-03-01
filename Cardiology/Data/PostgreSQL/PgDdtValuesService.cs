using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtValuesService : IDdtValuesService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtValuesService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtValues> GetAll()
        {
            IList<DdtValues> list = new List<DdtValues>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dss_value FROM ddt_values";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtValues obj = new DdtValues();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.Value = reader.GetString(5);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtValues GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dss_value FROM ddt_values WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtValues obj = new DdtValues();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.Value = reader.GetString(5);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtValues GetByNameLike(string name)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dss_value FROM ddt_values WHERE dss_name LIKE '{0}%'", name);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtValues obj = new DdtValues();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.Value = reader.GetString(5);
                        return obj;
                    }
                }
            }
            return null;
        }

        public IList<DdtValues> GetListByNameLike(string name)
        {
            IList<DdtValues> list = new List<DdtValues>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dss_value FROM ddt_values WHERE dss_name LIKE '{0}%'", name);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtValues obj = new DdtValues();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.Value = reader.GetString(5);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public string Save(DdtValues obj)
        {
            throw new NotImplementedException();
        }
    }
}
