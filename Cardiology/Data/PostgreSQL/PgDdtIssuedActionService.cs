using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtIssuedActionService : IDdtIssuedActionService
    {
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
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtIssuedAction obj = new DdtIssuedAction();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.ParentId = reader.GetString(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.Action = reader.GetString(5);
                        obj.ParentType = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.Doctor = reader.GetString(8);
                        obj.IssuingDate = reader.GetDateTime(9);
                        obj.Patient = reader.GetString(10);
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
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtIssuedAction obj = new DdtIssuedAction();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.ParentId = reader.GetString(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.Action = reader.GetString(5);
                        obj.ParentType = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.Doctor = reader.GetString(8);
                        obj.IssuingDate = reader.GetDateTime(9);
                        obj.Patient = reader.GetString(10);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
