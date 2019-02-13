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
                String sql = "SELECT dsid_hospitality_session, r_object_id, dss_goal, r_modify_date, dss_dynamics, dss_diagnosis, dss_duty_admin_name, r_creation_date, dsdt_consilium_date, dss_decision, dsid_doctor, dsid_patient FROM ddt_consilium";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtConsilium obj = new DdtConsilium();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.Goal = reader.GetString(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.Dynamics = reader.GetString(5);
                        obj.Diagnosis = reader.GetString(6);
                        obj.DutyAdminName = reader.GetString(7);
                        obj.CreationDate = reader.GetDateTime(8);
                        obj.ConsiliumDate = reader.GetDateTime(9);
                        obj.Decision = reader.GetString(10);
                        obj.Doctor = reader.GetString(11);
                        obj.Patient = reader.GetString(12);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
