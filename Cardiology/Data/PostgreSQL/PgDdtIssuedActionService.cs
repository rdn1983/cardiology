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
    public class PgDdtIssuedActionService : IDdtIssuedActionService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtIssuedActionService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtIssuedAction> GetAll()
        {
            IList<DdtIssuedAction> list = new List<DdtIssuedAction>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dsid_parent_id, r_modify_date, dss_action, dss_parent_type, r_creation_date, dsid_doctor, dsdt_issuing_date, dsid_patient FROM ddt_issued_action";

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtIssuedAction obj = new DdtIssuedAction();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ParentId = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Action = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.IssuingDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.Patient = reader.IsDBNull(9) ? null : reader.GetString(9);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtIssuedAction GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsid_parent_id, r_modify_date, dss_action, dss_parent_type, r_creation_date, dsid_doctor, dsdt_issuing_date, dsid_patient FROM ddt_issued_action WHERE r_object_id = '{0}'", id);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtIssuedAction obj = new DdtIssuedAction();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ParentId = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Action = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.IssuingDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.Patient = reader.IsDBNull(9) ? null : reader.GetString(9);
                        return obj;
                    }
                }
            }
            return null;
        }

        public IList<DdtIssuedAction> GetListByParentId(string parentId)
        {
            IList<DdtIssuedAction> list = new List<DdtIssuedAction>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsid_parent_id, r_modify_date, dss_action, dss_parent_type, r_creation_date, dsid_doctor, dsdt_issuing_date, dsid_patient FROM ddt_issued_action WHERE dsid_parent_id = '{0}'", parentId);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtIssuedAction obj = new DdtIssuedAction();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ParentId = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Action = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.IssuingDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.Patient = reader.IsDBNull(9) ? null : reader.GetString(9);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public string Save(DdtIssuedAction obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_issued_action SET " +
                                          "dsid_doctor = @Doctor, " +
                                        "dsid_patient = @Patient, " +
                                        "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsdt_issuing_date = @IssuingDate, " +
                                        "dsid_parent_id = @ParentId, " +
                                        "dss_parent_type = @ParentType, " +
                                        "dss_action = @Action " +
                                         "WHERE r_object_id = @ObjectId";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@IssuingDate", obj.IssuingDate);
                        cmd.Parameters.AddWithValue("@ParentId", obj.ParentId);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@Action", obj.Action == null ? "" : obj.Action);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_issued_action(dsid_doctor,dsid_patient,dsid_hospitality_session,dsdt_issuing_date,dsid_parent_id,dss_parent_type,dss_action) " +
                                                              "VALUES(@Doctor,@Patient,@HospitalitySession,@IssuingDate,@ParentId,@ParentType,@Action) RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@IssuingDate", obj.IssuingDate);
                        cmd.Parameters.AddWithValue("@ParentId", obj.ParentId);
                        cmd.Parameters.AddWithValue("@ParentType", obj.ParentType == null ? "" : obj.ParentType);
                        cmd.Parameters.AddWithValue("@Action", obj.Action == null ? "" : obj.Action);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
