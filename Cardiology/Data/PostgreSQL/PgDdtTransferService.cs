using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

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
                        obj.Type = reader.GetInt16(9);
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
                        obj.Type = reader.GetInt16(9);
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
                        obj.Type = reader.GetInt16(9);
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
            throw new NotImplementedException();
        }
    }
}
