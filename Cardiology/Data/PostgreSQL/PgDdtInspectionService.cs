using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;

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
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_inspection SET " +
                                          "dsid_hospitality_session = @HospitalitySession, " +
                                            "dsid_patient = @Patient, " +
                                            "dsid_doctor = @Doctor, " +
                                            "dsdt_inspection_date = @InspectionDate, " +
                                            "dss_diagnosis = @Diagnosis, " +
                                            "dss_complaints = @Complaints, " +
                                            "dss_inspection = @Inspection, " +
                                            "dss_kateter_placement = @KateterPlacement, " +
                                            "dss_inspection_result = @InspectionResult " +
                                             "WHERE r_object_id = @ObjectId";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@InspectionDate", obj.InspectionDate);
                        cmd.Parameters.AddWithValue("@Diagnosis", obj.Diagnosis == null ? "" : obj.Diagnosis);
                        cmd.Parameters.AddWithValue("@Complaints", obj.Complaints == null ? "" : obj.Complaints);
                        cmd.Parameters.AddWithValue("@Inspection", obj.Inspection == null ? "" : obj.Inspection);
                        cmd.Parameters.AddWithValue("@KateterPlacement", obj.KateterPlacement == null ? "" : obj.KateterPlacement);
                        cmd.Parameters.AddWithValue("@InspectionResult", obj.InspectionResult == null ? "" : obj.InspectionResult);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_inspection(dsid_hospitality_session,dsid_patient,dsid_doctor,dsdt_inspection_date,dss_diagnosis,dss_complaints,dss_inspection,dss_kateter_placement,dss_inspection_result) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@InspectionDate,@Diagnosis,@Complaints,@Inspection,@KateterPlacement,@InspectionResult) RETURNING r_object_id";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@InspectionDate", obj.InspectionDate);
                        cmd.Parameters.AddWithValue("@Diagnosis", obj.Diagnosis == null ? "" : obj.Diagnosis);
                        cmd.Parameters.AddWithValue("@Complaints", obj.Complaints == null ? "" : obj.Complaints);
                        cmd.Parameters.AddWithValue("@Inspection", obj.Inspection == null ? "" : obj.Inspection);
                        cmd.Parameters.AddWithValue("@KateterPlacement", obj.KateterPlacement == null ? "" : obj.KateterPlacement);
                        cmd.Parameters.AddWithValue("@InspectionResult", obj.InspectionResult == null ? "" : obj.InspectionResult);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
