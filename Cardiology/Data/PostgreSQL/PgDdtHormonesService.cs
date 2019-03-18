using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtHormonesService : IDdtHormonesService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtHormonesService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtHormones> GetAll()
        {
            IList<DdtHormones> list = new List<DdtHormones>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dss_ttg, dsdt_analysis_date, dss_t3, r_modify_date, dss_t4, r_creation_date, dsid_doctor, dsid_patient FROM ddt_hormones";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtHormones obj = new DdtHormones();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Ttg = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.AnalysisDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.T3 = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.ModifyDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.T4 = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.CreationDate = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7);
                        obj.Doctor = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Patient = reader.IsDBNull(9) ? null : reader.GetString(9);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtHormones GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dss_ttg, dsdt_analysis_date, dss_t3, r_modify_date, dss_t4, r_creation_date, dsid_doctor, dsid_patient FROM ddt_hormones WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtHormones obj = new DdtHormones();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Ttg = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.AnalysisDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.T3 = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.ModifyDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.T4 = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.CreationDate = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7);
                        obj.Doctor = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Patient = reader.IsDBNull(9) ? null : reader.GetString(9);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtHormones obj)
        {
            throw new NotImplementedException();
        }
    }
}
