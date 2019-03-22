using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtVariousSpecConclusonService : IDdtVariousSpecConclusonService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtVariousSpecConclusonService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtVariousSpecConcluson> GetAll()
        {
            IList<DdtVariousSpecConcluson> list = new List<DdtVariousSpecConcluson>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dss_additional_info0, r_object_id, dsb_visible, dss_specialist_type, dss_additional_info2, dss_additional_info1, r_creation_date, dsid_parent, dsdt_admission_date, dss_additional_info4, dss_additional_info3, dss_specialist_conclusion, r_modify_date, dss_parent_type, dsb_additional_bool FROM ddt_various_spec_concluson";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtVariousSpecConcluson obj = new DdtVariousSpecConcluson();
                        obj.AdditionalInfo0 = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Visible = reader.GetBoolean(2);
                        obj.SpecialistType = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.AdditionalInfo2 = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.AdditionalInfo1 = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.AdmissionDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.AdditionalInfo4 = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.AdditionalInfo3 = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.SpecialistConclusion = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.ModifyDate = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                        obj.ParentType = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.AdditionalBool = reader.GetBoolean(14);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtVariousSpecConcluson> GetListByParentId(string parentId)
        {
            IList<DdtVariousSpecConcluson> list = new List<DdtVariousSpecConcluson>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dss_additional_info0, r_object_id, dsb_visible, dss_specialist_type, dss_additional_info2, dss_additional_info1, r_creation_date, dsid_parent, dsdt_admission_date, dss_additional_info4, dss_additional_info3, dss_specialist_conclusion, r_modify_date, dss_parent_type, dsb_additional_bool FROM ddt_various_spec_concluson WHERE dsid_parent = '{0}' AND dsb_additional_bool = false order by dsdt_admission_date", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtVariousSpecConcluson obj = new DdtVariousSpecConcluson();
                        obj.AdditionalInfo0 = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Visible = reader.GetBoolean(2);
                        obj.SpecialistType = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.AdditionalInfo2 = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.AdditionalInfo1 = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.AdmissionDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.AdditionalInfo4 = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.AdditionalInfo3 = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.SpecialistConclusion = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.ModifyDate = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                        obj.ParentType = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.AdditionalBool = reader.GetBoolean(14);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public List<DdtVariousSpecConcluson> GetByQuery(string sql)
        {
            List<DdtVariousSpecConcluson> list = new List<DdtVariousSpecConcluson>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtVariousSpecConcluson obj = new DdtVariousSpecConcluson();
                        obj.AdditionalInfo0 = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Visible = reader.GetBoolean(2);
                        obj.SpecialistType = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.AdditionalInfo2 = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.AdditionalInfo1 = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.AdmissionDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.AdditionalInfo4 = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.AdditionalInfo3 = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.SpecialistConclusion = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.ModifyDate = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                        obj.ParentType = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.AdditionalBool = reader.GetBoolean(14);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtVariousSpecConcluson GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dss_additional_info0, r_object_id, dsb_visible, dss_specialist_type, dss_additional_info2, dss_additional_info1, r_creation_date, dsid_parent, dsdt_admission_date, dss_additional_info4, dss_additional_info3, dss_specialist_conclusion, r_modify_date, dss_parent_type, dsb_additional_bool FROM ddt_various_spec_concluson WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtVariousSpecConcluson obj = new DdtVariousSpecConcluson();
                        obj.AdditionalInfo0 = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Visible = reader.GetBoolean(2);
                        obj.SpecialistType = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.AdditionalInfo2 = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.AdditionalInfo1 = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.AdmissionDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.AdditionalInfo4 = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.AdditionalInfo3 = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.SpecialistConclusion = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.ModifyDate = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                        obj.ParentType = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.AdditionalBool = reader.GetBoolean(14);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtVariousSpecConcluson GetByParentId(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dss_additional_info0, r_object_id, dsb_visible, dss_specialist_type, dss_additional_info2, dss_additional_info1, r_creation_date, dsid_parent, dsdt_admission_date, dss_additional_info4, dss_additional_info3, dss_specialist_conclusion, r_modify_date, dss_parent_type, dsb_additional_bool FROM ddt_various_spec_concluson WHERE dsid_parent = '{0}' AND dsb_additional_bool = true ", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtVariousSpecConcluson obj = new DdtVariousSpecConcluson();
                        obj.AdditionalInfo0 = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Visible = reader.GetBoolean(2);
                        obj.SpecialistType = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.AdditionalInfo2 = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.AdditionalInfo1 = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.AdmissionDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.AdditionalInfo4 = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.AdditionalInfo3 = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.SpecialistConclusion = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.ModifyDate = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                        obj.ParentType = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.AdditionalBool = reader.GetBoolean(14);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtVariousSpecConcluson obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_various_spec_concluson SET " +
                                          "dsid_parent = @Parent, " +
                                        "dss_parent_type = @ParentType, " +
                                        "dsdt_admission_date = @AdmissionDate, " +
                                        "dss_specialist_type = @SpecialistType, " +
                                        "dss_specialist_conclusion = @SpecialistConclusion, " +
                                        "dss_additional_info0 = @AdditionalInfo0, " +
                                        "dss_additional_info1 = @AdditionalInfo1, " +
                                        "dss_additional_info2 = @AdditionalInfo2, " +
                                        "dss_additional_info3 = @AdditionalInfo3, " +
                                        "dss_additional_info4 = @AdditionalInfo4, " +
                                        "dsb_visible = @Visible, " +
                                        "dsb_additional_bool = @AdditionalBool " +
                                         "WHERE r_object_id = @ObjectId";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@AdmissionDate", obj.AdmissionDate);
                        cmd.Parameters.AddWithValue("@SpecialistType", obj.SpecialistType == null ? "" : obj.SpecialistType);
                        cmd.Parameters.AddWithValue("@SpecialistConclusion", obj.SpecialistConclusion == null ? "" : obj.SpecialistConclusion);
                        cmd.Parameters.AddWithValue("@AdditionalInfo0", obj.AdditionalInfo0 == null ? "" : obj.AdditionalInfo0);
                        cmd.Parameters.AddWithValue("@AdditionalInfo1", obj.AdditionalInfo1 == null ? "" : obj.AdditionalInfo1);
                        cmd.Parameters.AddWithValue("@AdditionalInfo2", obj.AdditionalInfo2 == null ? "" : obj.AdditionalInfo2);
                        cmd.Parameters.AddWithValue("@AdditionalInfo3", obj.AdditionalInfo3 == null ? "" : obj.AdditionalInfo3);
                        cmd.Parameters.AddWithValue("@AdditionalInfo4", obj.AdditionalInfo4 == null ? "" : obj.AdditionalInfo4);
                        cmd.Parameters.AddWithValue("@Visible", obj.Visible);
                        cmd.Parameters.AddWithValue("@AdditionalBool", obj.AdditionalBool);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_various_spec_concluson(dsid_parent,dss_parent_type,dsdt_admission_date,dss_specialist_type,dss_specialist_conclusion,dss_additional_info0,dss_additional_info1,dss_additional_info2,dss_additional_info3,dss_additional_info4,dsb_visible,dsb_additional_bool) " +
                                                              "VALUES(@Parent,@ParentType,@AdmissionDate,@SpecialistType,@SpecialistConclusion,@AdditionalInfo0,@AdditionalInfo1,@AdditionalInfo2,@AdditionalInfo3,@AdditionalInfo4,@Visible,@AdditionalBool) RETURNING r_object_id";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Parent", obj.Parent);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@AdmissionDate", obj.AdmissionDate);
                        cmd.Parameters.AddWithValue("@SpecialistType", obj.SpecialistType == null ? "" : obj.SpecialistType);
                        cmd.Parameters.AddWithValue("@SpecialistConclusion", obj.SpecialistConclusion == null ? "" : obj.SpecialistConclusion);
                        cmd.Parameters.AddWithValue("@AdditionalInfo0", obj.AdditionalInfo0 == null ? "" : obj.AdditionalInfo0);
                        cmd.Parameters.AddWithValue("@AdditionalInfo1", obj.AdditionalInfo1 == null ? "" : obj.AdditionalInfo1);
                        cmd.Parameters.AddWithValue("@AdditionalInfo2", obj.AdditionalInfo2 == null ? "" : obj.AdditionalInfo2);
                        cmd.Parameters.AddWithValue("@AdditionalInfo3", obj.AdditionalInfo3 == null ? "" : obj.AdditionalInfo3);
                        cmd.Parameters.AddWithValue("@AdditionalInfo4", obj.AdditionalInfo4 == null ? "" : obj.AdditionalInfo4);
                        cmd.Parameters.AddWithValue("@Visible", obj.Visible);
                        cmd.Parameters.AddWithValue("@AdditionalBool", obj.AdditionalBool);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }


    }
}
