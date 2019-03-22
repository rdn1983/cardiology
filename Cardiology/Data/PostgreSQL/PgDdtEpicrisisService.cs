using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtEpicrisisService : IDdtEpicrisisService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtEpicrisisService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtEpicrisis> GetAll()
        {
            IList<DdtEpicrisis> list = new List<DdtEpicrisis>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, r_modify_date, dsdt_epicrisis_date, dss_diagnosis, r_creation_date, dsi_epicrisis_type, dsid_doctor, dsid_patient FROM ddt_epicrisis";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtEpicrisis obj = new DdtEpicrisis();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ModifyDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.EpicrisisDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Diagnosis = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.EpicrisisType = reader.GetInt16(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtEpicrisis GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, r_modify_date, dsdt_epicrisis_date, dss_diagnosis, r_creation_date, dsi_epicrisis_type, dsid_doctor, dsid_patient FROM ddt_epicrisis WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtEpicrisis obj = new DdtEpicrisis();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ModifyDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.EpicrisisDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Diagnosis = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.EpicrisisType = reader.GetInt16(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtEpicrisis obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_epicrisis SET " +
                                          "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsid_patient = @Patient, " +
                                        "dsid_doctor = @Doctor, " +
                                        "dsdt_epicrisis_date = @EpicrisisDate, " +
                                        "dss_diagnosis = @Diagnosis, " +
                                        "dsi_epicrisis_type = @EpicrisisType " +
                                         "WHERE r_object_id = @ObjectId";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@EpicrisisDate", obj.EpicrisisDate);
                        cmd.Parameters.AddWithValue("@Diagnosis", obj.Diagnosis == null ? "" : obj.Diagnosis);
                        cmd.Parameters.AddWithValue("@EpicrisisType", obj.EpicrisisType);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_epicrisis(dsid_hospitality_session,dsid_patient,dsid_doctor,dsdt_epicrisis_date,dss_diagnosis,dsi_epicrisis_type) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@EpicrisisDate,@Diagnosis,@EpicrisisType) RETURNING r_object_id";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@EpicrisisDate", obj.EpicrisisDate);
                        cmd.Parameters.AddWithValue("@Diagnosis", obj.Diagnosis == null ? "" : obj.Diagnosis);
                        cmd.Parameters.AddWithValue("@EpicrisisType", obj.EpicrisisType);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
