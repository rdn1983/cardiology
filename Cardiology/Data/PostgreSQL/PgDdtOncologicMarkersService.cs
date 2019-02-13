using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtOncologicMarkersService : IDdtOncologicMarkersService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtOncologicMarkersService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtOncologicMarkers> GetAll()
        {
            IList<DdtOncologicMarkers> list = new List<DdtOncologicMarkers>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dsdt_analysis_date, r_creation_date, dss_cea, dsid_parent, dss_psa_common, dss_psa_free, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_hgch, r_modify_date, dss_parent_type, dss_ca_125, dss_ca_199, dss_ca_153, dss_afr FROM ddt_oncologic_markers";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtOncologicMarkers obj = new DdtOncologicMarkers();
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Cea = reader.GetString(4);
                        obj.Parent = reader.GetString(5);
                        obj.PsaCommon = reader.GetString(6);
                        obj.PsaFree = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HospitalitySession = reader.GetString(10);
                        obj.Hgch = reader.GetString(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.ParentType = reader.GetString(13);
                        obj.Ca125 = reader.GetString(14);
                        obj.Ca199 = reader.GetString(15);
                        obj.Ca153 = reader.GetString(16);
                        obj.Afr = reader.GetString(17);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtOncologicMarkers GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, r_creation_date, dss_cea, dsid_parent, dss_psa_common, dss_psa_free, dsid_doctor, dsid_patient, dsid_hospitality_session, dss_hgch, r_modify_date, dss_parent_type, dss_ca_125, dss_ca_199, dss_ca_153, dss_afr FROM ddt_oncologic_markers WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtOncologicMarkers obj = new DdtOncologicMarkers();
                        obj.ObjectId = reader.GetString(1);
                        obj.AnalysisDate = reader.GetDateTime(2);
                        obj.CreationDate = reader.GetDateTime(3);
                        obj.Cea = reader.GetString(4);
                        obj.Parent = reader.GetString(5);
                        obj.PsaCommon = reader.GetString(6);
                        obj.PsaFree = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HospitalitySession = reader.GetString(10);
                        obj.Hgch = reader.GetString(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.ParentType = reader.GetString(13);
                        obj.Ca125 = reader.GetString(14);
                        obj.Ca199 = reader.GetString(15);
                        obj.Ca153 = reader.GetString(16);
                        obj.Afr = reader.GetString(17);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
