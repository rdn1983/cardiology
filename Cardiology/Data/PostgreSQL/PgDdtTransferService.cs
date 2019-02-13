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
                String sql = "SELECT dsid_hospitality_session, r_object_id, dsdt_end_date, r_modify_date, dss_destination, r_creation_date, dss_transfer_justification, dsdt_start_date, dsid_doctor, dsid_patient, dss_contacts, dsi_type FROM ddt_transfer";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtTransfer obj = new DdtTransfer();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.EndDate = reader.GetDateTime(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.Destination = reader.GetString(5);
                        obj.CreationDate = reader.GetDateTime(6);
                        obj.TransferJustification = reader.GetString(7);
                        obj.StartDate = reader.GetDateTime(8);
                        obj.Doctor = reader.GetString(9);
                        obj.Patient = reader.GetString(10);
                        obj.Contacts = reader.GetString(11);
                        obj.Type = reader.GetInt16(12);
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
                String sql = String.Format("SELECT dsid_hospitality_session, r_object_id, dsdt_end_date, r_modify_date, dss_destination, r_creation_date, dss_transfer_justification, dsdt_start_date, dsid_doctor, dsid_patient, dss_contacts, dsi_type FROM ddt_transfer WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtTransfer obj = new DdtTransfer();
                        obj.HospitalitySession = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.EndDate = reader.GetDateTime(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.Destination = reader.GetString(5);
                        obj.CreationDate = reader.GetDateTime(6);
                        obj.TransferJustification = reader.GetString(7);
                        obj.StartDate = reader.GetDateTime(8);
                        obj.Doctor = reader.GetString(9);
                        obj.Patient = reader.GetString(10);
                        obj.Contacts = reader.GetString(11);
                        obj.Type = reader.GetInt16(12);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
