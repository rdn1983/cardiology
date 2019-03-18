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
            throw new NotImplementedException();
        }
    }
}
