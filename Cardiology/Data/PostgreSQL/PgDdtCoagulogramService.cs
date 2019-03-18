using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtCoagulogramService : IDdtCoagulogramService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtCoagulogramService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtCoagulogram> GetAll()
        {
            IList<DdtCoagulogram> list = new List<DdtCoagulogram>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dss_ddimer, dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_mcho, r_creation_date, dss_achtv, dsid_doctor, dsid_patient FROM ddt_coagulogram";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCoagulogram obj = new DdtCoagulogram();
                        obj.Ddimer = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.HospitalitySession = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ObjectId = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.AnalysisDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ModifyDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.Mcho = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Achtv = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Doctor = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Patient = reader.IsDBNull(9) ? null : reader.GetString(9);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtCoagulogram GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dss_ddimer, dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_mcho, r_creation_date, dss_achtv, dsid_doctor, dsid_patient FROM ddt_coagulogram WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtCoagulogram obj = new DdtCoagulogram();
                        obj.Ddimer = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.HospitalitySession = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ObjectId = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.AnalysisDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ModifyDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.Mcho = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Achtv = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Doctor = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Patient = reader.IsDBNull(9) ? null : reader.GetString(9);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtCoagulogram obj)
        {
            throw new NotImplementedException();
        }
    }
}
