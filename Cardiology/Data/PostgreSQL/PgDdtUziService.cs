using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtUziService : IDdtUziService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtUziService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtUzi> GetAll()
        {
            IList<DdtUzi> list = new List<DdtUzi>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsdt_analysis_date, dss_eho_kg, r_creation_date, dss_pleurs_uzi, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_uzd_bca, r_modify_date, dss_parent_type, dss_cds, dss_uzi_obp FROM ddt_uzi";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtUzi obj = new DdtUzi();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EhoKg = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.PleursUzi = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.UzdBca = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Cds = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.UziObp = reader.IsDBNull(13) ? null : reader.GetString(13);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtUzi GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dss_eho_kg, r_creation_date, dss_pleurs_uzi, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_uzd_bca, r_modify_date, dss_parent_type, dss_cds, dss_uzi_obp FROM ddt_uzi WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtUzi obj = new DdtUzi();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EhoKg = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.PleursUzi = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.UzdBca = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Cds = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.UziObp = reader.IsDBNull(13) ? null : reader.GetString(13);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtUzi GetByParentId(string parentId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dss_eho_kg, r_creation_date, dss_pleurs_uzi, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_uzd_bca, r_modify_date, dss_parent_type, dss_cds, dss_uzi_obp FROM ddt_uzi WHERE dsid_parent = '{0}'", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtUzi obj = new DdtUzi();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EhoKg = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.PleursUzi = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.UzdBca = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Cds = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.UziObp = reader.IsDBNull(13) ? null : reader.GetString(13);
                        return obj;
                    }
                }
            }
            return null;
        }

        public IList<DdtUzi> GetListByParentId(string parentId)
        {
            IList<DdtUzi> list = new List<DdtUzi>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dss_eho_kg, r_creation_date, dss_pleurs_uzi, dsid_parent, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_uzd_bca, r_modify_date, dss_parent_type, dss_cds, dss_uzi_obp FROM ddt_uzi WHERE dsid_patient = '{0}'", parentId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtUzi obj = new DdtUzi();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EhoKg = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.PleursUzi = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.UzdBca = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Cds = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.UziObp = reader.IsDBNull(13) ? null : reader.GetString(13);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public List<DdtUzi> GetByQuery(string sql)
        {
            List<DdtUzi> list = new List<DdtUzi>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtUzi obj = new DdtUzi();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.AnalysisDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.EhoKg = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.CreationDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.PleursUzi = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Parent = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Doctor = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Patient = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.HospitalitySession = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.UzdBca = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.ModifyDate = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10);
                        obj.ParentType = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Cds = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.UziObp = reader.IsDBNull(13) ? null : reader.GetString(13);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public string Save(DdtUzi obj)
        {
            throw new NotImplementedException();
        }
    }
}
