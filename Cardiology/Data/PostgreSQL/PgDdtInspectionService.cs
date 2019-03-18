using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtInspectionService : IDdtInspectionService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtInspectionService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtInspection> GetAll()
        {
            IList<DdtInspection> list = new List<DdtInspection>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dsdt_inspection_date, r_modify_date, dss_diagnosis, dss_kateter_placement, r_creation_date, dss_complaints, dss_inspection, dsid_doctor, dss_inspection_result, dsid_patient FROM ddt_inspection";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtInspection obj = new DdtInspection();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.InspectionDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Diagnosis = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.KateterPlacement = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Complaints = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Inspection = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.InspectionResult = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Patient = reader.IsDBNull(11) ? null : reader.GetString(11);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtInspection GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_inspection_date, r_modify_date, dss_diagnosis, dss_kateter_placement, r_creation_date, dss_complaints, dss_inspection, dsid_doctor, dss_inspection_result, dsid_patient FROM ddt_inspection WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtInspection obj = new DdtInspection();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.InspectionDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Diagnosis = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.KateterPlacement = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Complaints = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Inspection = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Doctor = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.InspectionResult = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Patient = reader.IsDBNull(11) ? null : reader.GetString(11);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtInspection obj)
        {
            throw new NotImplementedException();
        }
    }
}
