using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtConsiliumService : IDdtConsiliumService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtConsiliumService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtConsilium> GetAll()
        {
            IList<DdtConsilium> list = new List<DdtConsilium>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dss_goal, dss_dynamics, r_modify_date, dss_duty_admin_name, dss_diagnosis, r_creation_date, dsdt_consilium_date, dss_decision, dsid_doctor, dsid_patient FROM ddt_consilium";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtConsilium obj = new DdtConsilium();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Goal = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.Dynamics = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.ModifyDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.DutyAdminName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Diagnosis = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.CreationDate = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7);
                        obj.ConsiliumDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.Decision = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Doctor = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Patient = reader.IsDBNull(11) ? null : reader.GetString(11);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtConsilium GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dss_goal, dss_dynamics, r_modify_date, dss_duty_admin_name, dss_diagnosis, r_creation_date, dsdt_consilium_date, dss_decision, dsid_doctor, dsid_patient FROM ddt_consilium WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtConsilium obj = new DdtConsilium();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Goal = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.Dynamics = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.ModifyDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.DutyAdminName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Diagnosis = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.CreationDate = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7);
                        obj.ConsiliumDate = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                        obj.Decision = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Doctor = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Patient = reader.IsDBNull(11) ? null : reader.GetString(11);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtConsilium obj)
        {
            throw new NotImplementedException();
        }
    }
}
