using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtHistoryService : IDdtHistoryService
    {
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
                String sql = "SELECT r_object_id, dsid_operation_id, dsdt_operation_date, r_creation_date, dsid_doctor, dsid_patient, dss_operation_name, dsid_hospitality_session, dsb_deleted, r_modify_date, dss_description, dsdt_delete_date, dss_operation_type FROM ddt_history";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtHistory obj = new DdtHistory();
                        obj.ObjectId = reader.GetString(1);
                        obj.OperationId = reader.GetString(2);
                        obj.OperationDate = reader.GetDateTime(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.Doctor = reader.GetString(5);
                        obj.Patient = reader.GetString(6);
                        obj.OperationName = reader.GetString(7);
                        obj.HospitalitySession = reader.GetString(8);
                        obj.Deleted = reader.GetBoolean(9);
                        obj.ModifyDate = reader.GetDateTime(10);
                        obj.Description = reader.GetString(11);
                        obj.DeleteDate = reader.GetDateTime(12);
                        obj.OperationType = reader.GetString(13);
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
                String sql = String.Format("SELECT r_object_id, dsid_operation_id, dsdt_operation_date, r_creation_date, dsid_doctor, dsid_patient, dss_operation_name, dsid_hospitality_session, dsb_deleted, r_modify_date, dss_description, dsdt_delete_date, dss_operation_type FROM ddt_history WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtHistory obj = new DdtHistory();
                        obj.ObjectId = reader.GetString(1);
                        obj.OperationId = reader.GetString(2);
                        obj.OperationDate = reader.GetDateTime(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.Doctor = reader.GetString(5);
                        obj.Patient = reader.GetString(6);
                        obj.OperationName = reader.GetString(7);
                        obj.HospitalitySession = reader.GetString(8);
                        obj.Deleted = reader.GetBoolean(9);
                        obj.ModifyDate = reader.GetDateTime(10);
                        obj.Description = reader.GetString(11);
                        obj.DeleteDate = reader.GetDateTime(12);
                        obj.OperationType = reader.GetString(13);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
