using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using NLog;
using System.Globalization;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtHistoryService : IDdtHistoryService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtHistoryService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtHistory> GetAll()
        {
            IList<DdtHistory> list = new List<DdtHistory>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsid_operation_id, dsdt_operation_date, r_creation_date, dsid_doctor, dsid_patient, dss_operation_name, dsid_hospitality_session, dsb_deleted, dss_description, r_modify_date, dsdt_delete_date, dss_operation_type FROM ddt_history";

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtHistory obj = new DdtHistory();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.OperationId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.OperationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Doctor = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Patient = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.OperationName = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.HospitalitySession = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Deleted = reader.GetBoolean(8);
                        obj.Description = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.DeleteDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.OperationType = reader.IsDBNull(12) ? null : reader.GetString(12);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtHistory GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsid_operation_id, dsdt_operation_date, r_creation_date, dsid_doctor, dsid_patient, dss_operation_name, dsid_hospitality_session, dsb_deleted, dss_description, r_modify_date, dsdt_delete_date, dss_operation_type FROM ddt_history WHERE r_object_id = '{0}'", id);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtHistory obj = new DdtHistory();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.OperationId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.OperationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Doctor = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Patient = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.OperationName = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.HospitalitySession = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Deleted = reader.GetBoolean(8);
                        obj.Description = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.DeleteDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.OperationType = reader.IsDBNull(12) ? null : reader.GetString(12);
                        return obj;
                    }
                }
            }
            return null;
        }

        public void DeleteHistoryById(string operationId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("delete from ddt_history  WHERE dsid_operation_id='{0}'", operationId);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                command.ExecuteScalar();
            }
        }
    }
}
