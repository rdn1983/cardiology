using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtTransferService : IDdtTransferService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtTransferService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtTransfer> GetAll()
        {
            IList<DdtTransfer> list = new List<DdtTransfer>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_hospitality_session, r_object_id, dsdt_end_date, r_modify_date, dss_destination, r_creation_date, dss_transfer_justification, dsdt_start_date, dsid_doctor, dsi_type, dss_contacts, dsid_patient FROM ddt_transfer";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtTransfer obj = new DdtTransfer();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.EndDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Destination = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.TransferJustification = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.StartDate = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7);
                        obj.Doctor = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Type = reader.IsDBNull(9) ? -1 : reader.GetInt16(9);
                        obj.Contacts = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Patient = reader.IsDBNull(11) ? null : reader.GetString(11);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtTransfer GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_end_date, r_modify_date, dss_destination, r_creation_date, dss_transfer_justification, dsdt_start_date, dsid_doctor, dsi_type, dss_contacts, dsid_patient FROM ddt_transfer WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtTransfer obj = new DdtTransfer();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.EndDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Destination = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.TransferJustification = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.StartDate = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7);
                        obj.Doctor = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Type = reader.IsDBNull(9) ? -1 : reader.GetInt16(9);
                        obj.Contacts = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Patient = reader.IsDBNull(11) ? null : reader.GetString(11);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtTransfer GetByHospitalSession(string hospitalSession)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_end_date, r_modify_date, dss_destination, r_creation_date, dss_transfer_justification, dsdt_start_date, dsid_doctor, dsi_type, dss_contacts, dsid_patient FROM ddt_transfer WHERE dsid_hospitality_session = '{0}'", hospitalSession);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtTransfer obj = new DdtTransfer();
                        obj.HospitalitySession = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.ObjectId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.EndDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        obj.ModifyDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                        obj.Destination = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.TransferJustification = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.StartDate = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7);
                        obj.Doctor = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Type = reader.IsDBNull(9) ? -1 : reader.GetInt16(9);
                        obj.Contacts = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Patient = reader.IsDBNull(11) ? null : reader.GetString(11);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtTransfer obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_transfer SET " +
                                          "dsid_hospitality_session = @HospitalitySession, " +
                                        "dsid_patient = @Patient, " +
                                        "dsid_doctor = @Doctor, " +
                                        "dsdt_start_date = @StartDate, " +
                                        "dsdt_end_date = @EndDate, " +
                                        "dss_destination = @Destination, " +
                                        "dss_contacts = @Contacts, " +
                                        "dss_transfer_justification = @TransferJustification, " +
                                        "dsi_type = @Type " +
                                         "WHERE r_object_id = @ObjectId";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
                        cmd.Parameters.AddWithValue("@Destination", obj.Destination == null ? "" : obj.Destination);
                        cmd.Parameters.AddWithValue("@Contacts", obj.Contacts == null ? "" : obj.Contacts);
                        cmd.Parameters.AddWithValue("@TransferJustification", obj.TransferJustification == null ? "" : obj.TransferJustification);
                        cmd.Parameters.AddWithValue("@Type", obj.Type);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_transfer(dsid_hospitality_session,dsid_patient,dsid_doctor,dsdt_start_date,dsdt_end_date,dss_destination,dss_contacts,dss_transfer_justification,dsi_type) " +
                                                              "VALUES(@HospitalitySession,@Patient,@Doctor,@StartDate,@EndDate,@Destination,@Contacts,@TransferJustification,@Type) RETURNING r_object_id";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Patient", obj.Patient);
                        cmd.Parameters.AddWithValue("@Doctor", obj.Doctor);
                        cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
                        cmd.Parameters.AddWithValue("@Destination", obj.Destination == null ? "" : obj.Destination);
                        cmd.Parameters.AddWithValue("@Contacts", obj.Contacts == null ? "" : obj.Contacts);
                        cmd.Parameters.AddWithValue("@TransferJustification", obj.TransferJustification == null ? "" : obj.TransferJustification);
                        cmd.Parameters.AddWithValue("@Type", obj.Type);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
