using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtHolterService : IDdtHolterService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtHolterService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtHolter> GetAll()
        {
            IList<DdtHolter> list = new List<DdtHolter>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_monitoring_ad, dss_parent_type, r_creation_date, dsid_parent, dss_holter, dsid_doctor, dsid_patient FROM ddt_holter";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtHolter obj = new DdtHolter();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.MonitoringAd = reader.IsDBNull(0) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(0) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Holter = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtHolter GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_monitoring_ad, dss_parent_type, r_creation_date, dsid_parent, dss_holter, dsid_doctor, dsid_patient FROM ddt_holter WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtHolter obj = new DdtHolter();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.MonitoringAd = reader.IsDBNull(0) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(0) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Holter = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        return obj;
                    }
                }
            }
            return null;
        }

        public IList<DdtHolter> GetListByParentId(string parentId)
        {
            IList<DdtHolter> list = new List<DdtHolter>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_monitoring_ad, dss_parent_type, r_creation_date, dsid_parent, dss_holter, dsid_doctor, dsid_patient FROM ddt_holter WHERE dsid_parent = '{0}'", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtHolter obj = new DdtHolter();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.AnalysisDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.MonitoringAd = reader.IsDBNull(0) ? null : reader.GetString(4);
                        obj.ParentType = reader.IsDBNull(0) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Parent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Holter = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Patient = reader.IsDBNull(10) ? null : reader.GetString(10);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public string Save(DdtHolter obj)
        {
            throw new NotImplementedException();
        }
    }
}
