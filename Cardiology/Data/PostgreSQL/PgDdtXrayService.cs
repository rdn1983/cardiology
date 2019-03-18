using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtXrayService : IDdtXrayService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtXrayService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtXRay> GetAll()
        {
            IList<DdtXRay> list = new List<DdtXRay>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsdt_analysis_date, dss_mskt, r_creation_date, dss_kt, dsid_parent, dss_chest_xray, dsid_doctor, dsid_patient, dsid_hospitality_session, r_modify_date, dss_parent_type, dss_mrt, dss_control_radiography, dsdt_kt_date FROM ddt_xray";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtXRay obj = new DdtXRay();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.Mskt = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Kt = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.ChestXray = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Mrt = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.ControlRadiography = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.KtDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public IList<DdtXRay> GetListByParentId(string parentId)
        {
            IList<DdtXRay> list = new List<DdtXRay>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dss_mskt, r_creation_date, dss_kt, dsid_parent, dss_chest_xray, dsid_doctor, dsid_patient, dsid_hospitality_session, r_modify_date, dss_parent_type, dss_mrt, dss_control_radiography, dsdt_kt_date FROM ddt_xray WHERE dsid_parent = '{0}'", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtXRay obj = new DdtXRay();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.Mskt = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Kt = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.ChestXray = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Mrt = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.ControlRadiography = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.KtDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtXRay GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dss_mskt, r_creation_date, dss_kt, dsid_parent, dss_chest_xray, dsid_doctor, dsid_patient, dsid_hospitality_session, r_modify_date, dss_parent_type, dss_mrt, dss_control_radiography, dsdt_kt_date FROM ddt_xray WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtXRay obj = new DdtXRay();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.Mskt = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Kt = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.ChestXray = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Mrt = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.ControlRadiography = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.KtDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtXRay GetByParentId(string parentId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dss_mskt, r_creation_date, dss_kt, dsid_parent, dss_chest_xray, dsid_doctor, dsid_patient, dsid_hospitality_session, r_modify_date, dss_parent_type, dss_mrt, dss_control_radiography, dsdt_kt_date FROM ddt_xray WHERE r_object_id = '{0}'", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtXRay obj = new DdtXRay();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.Mskt = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Kt = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.ChestXray = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Mrt = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.ControlRadiography = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.KtDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtXRay obj)
        {
            throw new NotImplementedException();
        }
    }
}
