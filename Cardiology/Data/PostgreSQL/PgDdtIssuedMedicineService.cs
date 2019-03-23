using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtIssuedMedicineService : IDdtIssuedMedicineService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtIssuedMedicineService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtIssuedMedicine> GetAll()
        {
            IList<DdtIssuedMedicine> list = new List<DdtIssuedMedicine>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_med_list, r_object_id, dsid_cure, r_modify_date, r_creation_date FROM ddt_issued_medicine";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtIssuedMedicine obj = new DdtIssuedMedicine();
                        obj.MedList = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Cure = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.CreationDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtIssuedMedicine> GetListByMedicineListId(string medicineListId)
        {
            IList<DdtIssuedMedicine> list = new List<DdtIssuedMedicine>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_med_list, r_object_id, dsid_cure, r_modify_date, r_creation_date FROM ddt_issued_medicine WHERE dsid_med_list = '{0}'", medicineListId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtIssuedMedicine obj = new DdtIssuedMedicine();
                        obj.MedList = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Cure = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.CreationDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtIssuedMedicine GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_med_list, r_object_id, dsid_cure, r_modify_date, r_creation_date FROM ddt_issued_medicine WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtIssuedMedicine obj = new DdtIssuedMedicine();
                        obj.MedList = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Cure = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.CreationDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtIssuedMedicine obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_issued_medicine SET " +
                                          "dsid_med_list = @MedList, " +
                                                "dsid_cure = @Cure " +
                                                 "WHERE r_object_id = @ObjectId";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@MedList", obj.MedList);
                        cmd.Parameters.AddWithValue("@Cure", obj.Cure);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_issued_medicine(dsid_med_list,dsid_cure) " +
                                                              "VALUES(@MedList,@Cure) RETURNING r_object_id";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@MedList", obj.MedList);
                        cmd.Parameters.AddWithValue("@Cure", obj.Cure);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

        public void Delete(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("DELETE FROM ddt_issued_medicine WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
