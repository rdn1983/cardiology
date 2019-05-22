using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cardiology.Data.Model2;
using NLog;

namespace Cardiology.Data.PostgreSQL
{
    class PgDdtTransfusionService : IDdtTransfusionService
    {

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtTransfusionService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public DdtTransfusion GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT " +
                    "r_object_id, " +
                    "r_creation_date, " +
                    "r_modify_date, " +
                    "dsid_hospitality_session, " +
                    "dsid_patient, " +
                    "dsid_doctor, " +
                    "dsdt_transfusion_date, " +
                    "dss_consent, " +
                    "dsid_consilium, " +
                    "dsid_blood_analysis, " +
                    "dss_transfusion_medium " +
                    "FROM ddt_transfusion WHERE r_object_id = '{0}'", id);

                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtTransfusion obj = new DdtTransfusion();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.CreationDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
                        obj.ModifyDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.HospitalitySession = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Patient = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Doctor = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.TransfusionDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                        obj.Consent = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Consilium = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.BloodAnalysis = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.TransfusionMedium = reader.IsDBNull(10) ? null : reader.GetString(10);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtTransfusion obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_transfusion SET " +
                                  "dsid_hospitality_session = @HospitalitySession, " +
                                  "dsid_patient = @Patient, " +
                                  "dsid_doctor = @Doctor, " +
                                  "dsdt_transfusion_date = @TransfusionDate, " +
                                  "dss_consent = @Consent, " +
                                  "dsid_consilium = @Consilium, " +
                                  "dsid_blood_analysis = @BloodAnalysis, " +
                                  "dss_transfusion_medium = @TransfusionMedium " +
                                   "WHERE r_object_id = @ObjectId";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@TransfusionDate", obj.TransfusionDate);
                        cmd.Parameters.AddWithValue("@Consent", obj.Consent == null ? (object)DBNull.Value : obj.Consent);
                        cmd.Parameters.AddWithValue("@Consilium", obj.Consilium == null ? (object)DBNull.Value : obj.Consilium);
                        cmd.Parameters.AddWithValue("@BloodAnalysis", obj.BloodAnalysis == null ? (object)DBNull.Value : obj.BloodAnalysis);
                        cmd.Parameters.AddWithValue("@TransfusionMedium", obj.TransfusionMedium == null ? (object)DBNull.Value : obj.TransfusionMedium);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_transfusion(" +
                    "dsid_hospitality_session, " +
                    "dsid_patient, " +
                    "dsid_doctor, " +
                    "dsdt_transfusion_date, " +
                    "dss_consent, " +
                    "dsid_consilium, " +
                    "dsid_blood_analysis, " +
                    "dss_transfusion_medium " +
                     ") " +
                     "VALUES(" +
                     "@HospitalitySession," +
                     "@Patient,@Doctor," +
                     "@TransfusionDate," +
                     "@Consent," +
                     "@Consilium," +
                     "@BloodAnalysis," +
                     "@TransfusionMedium" +
                     ") RETURNING r_object_id";
                    Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@TransfusionDate", obj.TransfusionDate);
                        cmd.Parameters.AddWithValue("@Consent", obj.Consent == null ? (object)DBNull.Value : obj.Consent);
                        cmd.Parameters.AddWithValue("@Consilium", obj.Consilium == null ? (object)DBNull.Value : obj.Consilium);
                        cmd.Parameters.AddWithValue("@BloodAnalysis", obj.BloodAnalysis == null ? (object)DBNull.Value : obj.BloodAnalysis);
                        cmd.Parameters.AddWithValue("@TransfusionMedium", obj.TransfusionMedium == null ? (object)DBNull.Value : obj.TransfusionMedium);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }
    }
}
