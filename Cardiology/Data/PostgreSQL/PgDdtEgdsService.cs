using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtEgdsService : IDdtEgdsService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtEgdsService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtEgds> GetAll()
        {
            IList<DdtEgds> list = new List<DdtEgds>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_egds, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dsid_doctor, dsid_patient FROM ddt_egds";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtEgds obj = new DdtEgds();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.AnalysisDate = reader.GetDateTime(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.Egds = reader.GetString(5);
                        obj.ParentType = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.Parent = reader.GetString(8);
                        obj.AdmissionAnalysis = reader.GetBoolean(9);
                        obj.Doctor = reader.GetString(10);
                        obj.Patient = reader.GetString(11);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtEgds> GetListByParentId(string parentId)
        {
            IList<DdtEgds> list = new List<DdtEgds>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_egds, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dsid_doctor, dsid_patient FROM ddt_egds WHERE dsid_parent = '{0}'", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtEgds obj = new DdtEgds();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.AnalysisDate = reader.GetDateTime(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.Egds = reader.GetString(5);
                        obj.ParentType = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.Parent = reader.GetString(8);
                        obj.AdmissionAnalysis = reader.GetBoolean(9);
                        obj.Doctor = reader.GetString(10);
                        obj.Patient = reader.GetString(11);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtEgds GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_egds, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dsid_doctor, dsid_patient FROM ddt_egds WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtEgds obj = new DdtEgds();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.AnalysisDate = reader.GetDateTime(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.Egds = reader.GetString(5);
                        obj.ParentType = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.Parent = reader.GetString(8);
                        obj.AdmissionAnalysis = reader.GetBoolean(9);
                        obj.Doctor = reader.GetString(10);
                        obj.Patient = reader.GetString(11);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtEgds GetByHospitalSessionAndParentId(string hospitalSession, string parentId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_egds, dss_parent_type, r_creation_date, dsid_parent, dsb_admission_analysis, dsid_doctor, dsid_patient " +
                                           "FROM ddt_egds WHERE dsid_hospitality_session = '{0}' AND dsid_parent = '{1}'", hospitalSession, parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtEgds obj = new DdtEgds();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.AnalysisDate = reader.GetDateTime(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.Egds = reader.GetString(5);
                        obj.ParentType = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.Parent = reader.GetString(8);
                        obj.AdmissionAnalysis = reader.GetBoolean(9);
                        obj.Doctor = reader.GetString(10);
                        obj.Patient = reader.GetString(11);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtEgds obj)
        {
            throw new NotImplementedException();
        }
    }
}
