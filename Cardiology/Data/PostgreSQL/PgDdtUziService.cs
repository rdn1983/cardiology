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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.EhoKg = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.PleursUzi = reader.GetString(5);
                        obj.Parent = reader.GetString(6);
                        obj.Doctor = reader.GetString(7);
                        obj.Patient = reader.GetString(8);
                        obj.HospitalitySession = reader.GetString(9);
                        obj.UzdBca = reader.GetString(10);
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.ParentType = reader.GetString(12);
                        obj.Cds = reader.GetString(13);
                        obj.UziObp = reader.GetString(14);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.EhoKg = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.PleursUzi = reader.GetString(5);
                        obj.Parent = reader.GetString(6);
                        obj.Doctor = reader.GetString(7);
                        obj.Patient = reader.GetString(8);
                        obj.HospitalitySession = reader.GetString(9);
                        obj.UzdBca = reader.GetString(10);
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.ParentType = reader.GetString(12);
                        obj.Cds = reader.GetString(13);
                        obj.UziObp = reader.GetString(14);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.EhoKg = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.PleursUzi = reader.GetString(5);
                        obj.Parent = reader.GetString(6);
                        obj.Doctor = reader.GetString(7);
                        obj.Patient = reader.GetString(8);
                        obj.HospitalitySession = reader.GetString(9);
                        obj.UzdBca = reader.GetString(10);
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.ParentType = reader.GetString(12);
                        obj.Cds = reader.GetString(13);
                        obj.UziObp = reader.GetString(14);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.EhoKg = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.PleursUzi = reader.GetString(5);
                        obj.Parent = reader.GetString(6);
                        obj.Doctor = reader.GetString(7);
                        obj.Patient = reader.GetString(8);
                        obj.HospitalitySession = reader.GetString(9);
                        obj.UzdBca = reader.GetString(10);
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.ParentType = reader.GetString(12);
                        obj.Cds = reader.GetString(13);
                        obj.UziObp = reader.GetString(14);
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
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.EhoKg = reader.GetString(3);
                        obj.CreationDate = reader.GetDateTime(4);
                        obj.PleursUzi = reader.GetString(5);
                        obj.Parent = reader.GetString(6);
                        obj.Doctor = reader.GetString(7);
                        obj.Patient = reader.GetString(8);
                        obj.HospitalitySession = reader.GetString(9);
                        obj.UzdBca = reader.GetString(10);
                        obj.ModifyDate = reader.GetDateTime(11);
                        obj.ParentType = reader.GetString(12);
                        obj.Cds = reader.GetString(13);
                        obj.UziObp = reader.GetString(14);
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
