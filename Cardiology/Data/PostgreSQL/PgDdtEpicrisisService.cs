using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtEpicrisisService : IDdtEpicrisisService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtEpicrisisService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtEpicrisis> GetAll()
        {
            IList<DdtEpicrisis> list = new List<DdtEpicrisis>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, r_modify_date, dsdt_epicrisis_date, dss_diagnosis, r_creation_date, dsi_epicrisis_type, dsid_doctor, dsid_patient FROM ddt_epicrisis";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtEpicrisis obj = new DdtEpicrisis();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.ModifyDate = reader.GetDateTime(3);
                        obj.EpicrisisDate = reader.GetDateTime(4);
                        obj.Diagnosis = reader.GetString(5);
                        obj.CreationDate = reader.GetDateTime(6);
                        obj.EpicrisisType = reader.GetInt16(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtEpicrisis GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, r_modify_date, dsdt_epicrisis_date, dss_diagnosis, r_creation_date, dsi_epicrisis_type, dsid_doctor, dsid_patient FROM ddt_epicrisis WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtEpicrisis obj = new DdtEpicrisis();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.ModifyDate = reader.GetDateTime(3);
                        obj.EpicrisisDate = reader.GetDateTime(4);
                        obj.Diagnosis = reader.GetString(5);
                        obj.CreationDate = reader.GetDateTime(6);
                        obj.EpicrisisType = reader.GetInt16(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        return obj;
                    }
                }
            }
            return null;
        }

        public void Save(DdtEpicrisis obj)
        {
            throw new NotImplementedException();
        }
    }
}
