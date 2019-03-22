using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtCoagulogramService : IDdtCoagulogramService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtCoagulogramService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtCoagulogram> GetAll()
        {
            IList<DdtCoagulogram> list = new List<DdtCoagulogram>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dss_ddimer, dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_mcho, r_creation_date, dss_achtv, dsid_doctor, dsid_patient FROM ddt_coagulogram";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtCoagulogram obj = new DdtCoagulogram();
                        obj.Ddimer = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.HospitalitySession = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ObjectId = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.AnalysisDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ModifyDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.Mcho = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Achtv = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Doctor = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Patient = reader.IsDBNull(9) ? null : reader.GetString(9);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtCoagulogram GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dss_ddimer, dsid_hospitality_session, r_object_id, dsdt_analysis_date, r_modify_date, dss_mcho, r_creation_date, dss_achtv, dsid_doctor, dsid_patient FROM ddt_coagulogram WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtCoagulogram obj = new DdtCoagulogram();
                        obj.Ddimer = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.HospitalitySession = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ObjectId = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.AnalysisDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.ModifyDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        obj.Mcho = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.CreationDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Achtv = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Doctor = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Patient = reader.IsDBNull(9) ? null : reader.GetString(9);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtCoagulogram obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_coagulogram SET " +
                                          "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsid_patient = @Patient, " +
                                        "dsid_doctor = @Doctor, " +
                                        "dsdt_analysis_date = @AnalysisDate, " +
                                        "dss_achtv = @Achtv, " +
                                        "dss_mcho = @Mcho, " +
                                        "dss_ddimer = @Ddimer " +
                                         "WHERE r_object_id = @ObjectId";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@Achtv", obj.Achtv == null ? "" : obj.Achtv);
                        cmd.Parameters.AddWithValue("@Mcho", obj.Mcho == null ? "" : obj.Mcho);
                        cmd.Parameters.AddWithValue("@Ddimer", obj.Ddimer == null ? "" : obj.Ddimer);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_coagulogram(dsid_hospitality_session,dsid_patient,dsid_doctor,dsdt_analysis_date,dss_achtv,dss_mcho,dss_ddimer) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@AnalysisDate,@Achtv,@Mcho,@Ddimer) RETURNING r_object_id";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@AnalysisDate", obj.AnalysisDate);
                        cmd.Parameters.AddWithValue("@Achtv", obj.Achtv == null ? "" : obj.Achtv);
                        cmd.Parameters.AddWithValue("@Mcho", obj.Mcho == null ? "" : obj.Mcho);
                        cmd.Parameters.AddWithValue("@Ddimer", obj.Ddimer == null ? "" : obj.Ddimer);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
