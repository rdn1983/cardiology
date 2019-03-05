using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtCureService : IDdtCureService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtCureService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtCure> GetAll()
        {
            IList<DdtCure> list = new List<DdtCure>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dsid_cure_type FROM ddt_cure";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCure obj = new DdtCure();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.CureType = reader.GetString(5);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtCure GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dsid_cure_type FROM ddt_cure WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtCure obj = new DdtCure();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.CureType = reader.GetString(5);
                        return obj;
                    }
                }
            }
            return null;
        }

        public IList<DdtCure> GetListByMedicineListId(string id)
        {
            IList<DdtCure> list = new List<DdtCure>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT c.r_object_id, c.r_modify_date, c.r_creation_date, c.dss_name, c.dsid_cure_type FROM ddt_cure c, ddt_issued_medicine m WHERE m.dsid_cure = c.r_object_id AND m.dsid_med_list = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCure obj = new DdtCure();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.CureType = reader.GetString(5);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtCure> GetListByCureTypeId(string cureTypeId)
        {
            IList<DdtCure> list = new List<DdtCure>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, r_modify_date, r_creation_date, dss_name, dsid_cure_type FROM ddt_cure WHERE dsid_cure_type = '{0}'", cureTypeId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCure obj = new DdtCure();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.CureType = reader.GetString(5);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtCure> GetListByTemplate(string templateName)
        {
            IList<DdtCure> list = new List<DdtCure>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("Select cure.* from ddt_values vv, ddt_cure cure where vv.dss_name like '{0}' AND vv.dss_value = cure.dss_name", templateName);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCure obj = new DdtCure();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.CureType = reader.GetString(5);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public List<DdtCure> GetByQuery(string sql)
        {
            List<DdtCure> list = new List<DdtCure>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCure obj = new DdtCure();
                        obj.ObjectId = reader.GetString(1);
                        obj.ModifyDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Name = reader.GetString(4);
                        obj.CureType = reader.GetString(5);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public string Save(DdtCure obj)
        {
            throw new NotImplementedException();
        }
    }
}
