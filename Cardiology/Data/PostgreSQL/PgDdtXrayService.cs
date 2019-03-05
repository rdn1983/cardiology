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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.Mskt = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.Kt = reader.GetString(5);
                        obj.Parent = reader.GetString(6);
                        obj.ChestXray = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HospitalitySession = reader.GetString(10);
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.ParentType = reader.GetString(12);
                        obj.Mrt = reader.GetString(13);
                        obj.ControlRadiography = reader.GetString(14);
                        obj.KtDate = reader.GetDateTime(15);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.Mskt = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.Kt = reader.GetString(5);
                        obj.Parent = reader.GetString(6);
                        obj.ChestXray = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HospitalitySession = reader.GetString(10);
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.ParentType = reader.GetString(12);
                        obj.Mrt = reader.GetString(13);
                        obj.ControlRadiography = reader.GetString(14);
                        obj.KtDate = reader.GetDateTime(15);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.Mskt = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.Kt = reader.GetString(5);
                        obj.Parent = reader.GetString(6);
                        obj.ChestXray = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HospitalitySession = reader.GetString(10);
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.ParentType = reader.GetString(12);
                        obj.Mrt = reader.GetString(13);
                        obj.ControlRadiography = reader.GetString(14);
                        obj.KtDate = reader.GetDateTime(15);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.Mskt = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.Kt = reader.GetString(5);
                        obj.Parent = reader.GetString(6);
                        obj.ChestXray = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HospitalitySession = reader.GetString(10);
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.ParentType = reader.GetString(12);
                        obj.Mrt = reader.GetString(13);
                        obj.ControlRadiography = reader.GetString(14);
                        obj.KtDate = reader.GetDateTime(15);
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
