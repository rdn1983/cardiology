using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtIssuedMedicineListService : IDdtIssuedMedicineListService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtIssuedMedicineListService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtIssuedMedicineList> GetAll()
        {
            IList<DdtIssuedMedicineList> list = new List<DdtIssuedMedicineList>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dss_has_kag, dsid_parent_id, dsid_pharmacologist, dss_diagnosis, r_creation_date, dsid_director, " +
                    "dsid_doctor, dsid_patient, dsid_hospitality_session, dsid_nurse, r_modify_date, dss_parent_type, dss_template_name, dsdt_issuing_date," +
                    " dsb_skip_print FROM ddt_issued_medicine_list";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtIssuedMedicineList obj = new DdtIssuedMedicineList();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.HasKag = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ParentId = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.Pharmacologist = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Diagnosis = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Director = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Nurse = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.ParentType = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.TemplateName = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.IssuingDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        obj.SkipPrint = reader.GetBoolean(15);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtIssuedMedicineList GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_has_kag, dsid_parent_id, dsid_pharmacologist, dss_diagnosis, r_creation_date, dsid_director, " +
                    "dsid_doctor, dsid_patient, dsid_hospitality_session, dsid_nurse, r_modify_date, dss_parent_type, dss_template_name," +
                    " dsdt_issuing_date, dsb_skip_print FROM ddt_issued_medicine_list WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtIssuedMedicineList obj = new DdtIssuedMedicineList();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.HasKag = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ParentId = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.Pharmacologist = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Diagnosis = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Director = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Nurse = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.ParentType = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.TemplateName = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.IssuingDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        obj.SkipPrint = reader.GetBoolean(15);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtIssuedMedicineList obj)
        {
            if (string.IsNullOrEmpty(obj.ObjectId))
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public DdtIssuedMedicineList GetListByHospitalIdAndParentType(string parentType, string hospitalSession)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_has_kag, dsid_parent_id, dsid_pharmacologist, dss_diagnosis, r_creation_date, dsid_director," +
                    " dsid_doctor, dsid_patient, dsid_hospitality_session, dsid_nurse, r_modify_date, dss_parent_type, dss_template_name, dsdt_issuing_date," +
                    " dsb_skip_print FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='{0}' AND dss_parent_type = '{1}'", hospitalSession, parentType);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtIssuedMedicineList obj = new DdtIssuedMedicineList();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.HasKag = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ParentId = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.Pharmacologist = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Diagnosis = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Director = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Nurse = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.ParentType = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.TemplateName = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.IssuingDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        obj.SkipPrint = reader.GetBoolean(15);

                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtIssuedMedicineList GetListByHospitalId(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_has_kag, dsid_parent_id, dsid_pharmacologist, dss_diagnosis, r_creation_date, " +
                    "dsid_director, dsid_doctor, dsid_patient, dsid_hospitality_session, dsid_nurse, r_modify_date, dss_parent_type, dss_template_name, " +
                    "dsdt_issuing_date, dsb_skip_print FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtIssuedMedicineList obj = new DdtIssuedMedicineList();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.HasKag = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.ParentId = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.Pharmacologist = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Diagnosis = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.CreationDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        obj.Director = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Doctor = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Patient = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.HospitalitySession = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Nurse = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.ModifyDate = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                        obj.ParentType = reader.IsDBNull(12) ? null : reader.GetString(12);
                        obj.TemplateName = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.IssuingDate = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);
                        obj.SkipPrint = reader.GetBoolean(15);

                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
