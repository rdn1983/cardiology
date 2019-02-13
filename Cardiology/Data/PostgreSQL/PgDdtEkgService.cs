using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtEkgService : IDdtEkgService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtEkgService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtEkg> GetAll()
        {
            IList<DdtEkg> list = new List<DdtEkg>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_parent_type, r_creation_date, dsb_admission_analysis, dsid_parent, dss_ekg, dsid_doctor, dsid_patient FROM ddt_ekg";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtEkg obj = new DdtEkg();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.AnalysisDate = reader.GetDateTime(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.ParentType = reader.GetString(5);
                        obj.CreationDate = reader.GetDateTime(6);
                        obj.AdmissionAnalysis = reader.GetBoolean(7);
                        obj.Parent = reader.GetString(8);
                        obj.Ekg = reader.GetString(9);
                        obj.Doctor = reader.GetString(10);
                        obj.Patient = reader.GetString(11);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtEkg GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_parent_type, r_creation_date, dsb_admission_analysis, dsid_parent, dss_ekg, dsid_doctor, dsid_patient FROM ddt_ekg WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtEkg obj = new DdtEkg();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.AnalysisDate = reader.GetDateTime(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.ParentType = reader.GetString(5);
                        obj.CreationDate = reader.GetDateTime(6);
                        obj.AdmissionAnalysis = reader.GetBoolean(7);
                        obj.Parent = reader.GetString(8);
                        obj.Ekg = reader.GetString(9);
                        obj.Doctor = reader.GetString(10);
                        obj.Patient = reader.GetString(11);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
