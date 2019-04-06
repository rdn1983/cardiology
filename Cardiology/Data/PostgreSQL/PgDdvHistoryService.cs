using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using NLog;
using System.Globalization;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdvHistoryService : IDdvHistoryService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdvHistoryService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdvHistory> GetAll()
        {
            String sql = "SELECT dsid_hospitality_session, dsid_operation_id, dsdt_operation_date, dss_description, dss_doctor_name, dss_doctor_short_name, dss_operation_type, dss_operation_name FROM ddv_history";
            return readQuery(sql);

        }

        public DdvHistory GetById(string id)
        {
            String sql = String.Format("SELECT dsid_hospitality_session, dsid_operation_id, dsdt_operation_date, dss_description, dss_doctor_name, dss_doctor_short_name, dss_operation_type, dss_operation_name FROM ddv_history WHERE r_object_id = '{0}'", id);
            IList<DdvHistory> list = readQuery(sql);
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        public IList<DdvHistory> GetHistoryByHospitalSession(string hospitalSessionId)
        {
            String sql = String.Format("SELECT dsid_hospitality_session, dsid_operation_id, dsdt_operation_date, dss_description, dss_doctor_name, dss_doctor_short_name, dss_operation_type, dss_operation_name " +
                                           "FROM ddv_history where dsid_hospitality_session = '{0}'", hospitalSessionId);
            return readQuery(sql);
        }

        public DdvHistory GetHistoryByOperationId(string operationId)
        {
            String sql = String.Format("SELECT dsid_hospitality_session, dsid_operation_id, dsdt_operation_date, dss_description, dss_doctor_name, dss_doctor_short_name, dss_operation_type, dss_operation_name " +
                                           "FROM ddv_history where dsid_operation_id = '{0}'", operationId);
            IList<DdvHistory> list = readQuery(sql);
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        private IList<DdvHistory> readQuery(string query)
        {
            IList<DdvHistory> list = new List<DdvHistory>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", query);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdvHistory obj = new DdvHistory();
                        if (!reader.IsDBNull(0))
                        {
                            obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                            obj.OperationId = reader.IsDBNull(1) ? null : reader.GetString(1);
                            obj.OperationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                            obj.Description = reader.IsDBNull(3) ? null : reader.GetString(3);
                            obj.DoctorName = reader.IsDBNull(4) ? null : reader.GetString(4);
                            obj.DoctorShortName = reader.IsDBNull(5) ? null : reader.GetString(5);
                            obj.OperationType = reader.IsDBNull(6) ? null : reader.GetString(6);
                            obj.OperationName = reader.IsDBNull(7) ? null : reader.GetString(7);
                            list.Add(obj);
                        }
                    }
                }
            }
            return list;
        }
    }
}
