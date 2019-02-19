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
                String sql = "SELECT r_object_id, dss_has_kag, dsid_parent_id, dsid_pharmacologist, dss_diagnosis, r_creation_date, dsid_director, dsid_doctor, dsid_patient, dsid_hospitality_session, dsid_nurse, r_modify_date, dss_parent_type, dss_template_name, dsdt_issuing_date, dsb_skip_print FROM ddt_issued_medicine_list";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtIssuedMedicineList obj = new DdtIssuedMedicineList();
                        obj.ObjectId = reader.GetString(1);
                        obj.HasKag = reader.GetString(2);
                        obj.ParentId = reader.GetString(3);
                        obj.Pharmacologist = reader.GetString(4);
                        obj.Diagnosis = reader.GetString(5);
                        obj.CreationDate = reader.GetDateTime(6);
                        obj.Director = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HospitalitySession = reader.GetString(10);
                        obj.Nurse = reader.GetString(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.ParentType = reader.GetString(13);
                        obj.TemplateName = reader.GetString(14);
                        obj.IssuingDate = reader.GetDateTime(15);
                        obj.SkipPrint = reader.GetBoolean(16);
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
                String sql = String.Format("SELECT r_object_id, dss_has_kag, dsid_parent_id, dsid_pharmacologist, dss_diagnosis, r_creation_date, dsid_director, dsid_doctor, dsid_patient, dsid_hospitality_session, dsid_nurse, r_modify_date, dss_parent_type, dss_template_name, dsdt_issuing_date, dsb_skip_print FROM ddt_issued_medicine_list WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtIssuedMedicineList obj = new DdtIssuedMedicineList();
                        obj.ObjectId = reader.GetString(1);
                        obj.HasKag = reader.GetString(2);
                        obj.ParentId = reader.GetString(3);
                        obj.Pharmacologist = reader.GetString(4);
                        obj.Diagnosis = reader.GetString(5);
                        obj.CreationDate = reader.GetDateTime(6);
                        obj.Director = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HospitalitySession = reader.GetString(10);
                        obj.Nurse = reader.GetString(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.ParentType = reader.GetString(13);
                        obj.TemplateName = reader.GetString(14);
                        obj.IssuingDate = reader.GetDateTime(15);
                        obj.SkipPrint = reader.GetBoolean(16);
                        return obj;
                    }
                }
            }
            return null;
        }

        public void Save(DdtIssuedMedicineList obj)
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

        public DdtIssuedMedicineList GetListByHospitalId(string parentType, string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_has_kag, dsid_parent_id, dsid_pharmacologist, dss_diagnosis, r_creation_date, dsid_director, dsid_doctor, dsid_patient, dsid_hospitality_session, dsid_nurse, r_modify_date, dss_parent_type, dss_template_name, dsdt_issuing_date, dsb_skip_print FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='{0} AND dss_parent_type = '{1}'", id, parentType);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtIssuedMedicineList obj = new DdtIssuedMedicineList();
                        obj.ObjectId = reader.GetString(1);
                        obj.HasKag = reader.GetString(2);
                        obj.ParentId = reader.GetString(3);
                        obj.Pharmacologist = reader.GetString(4);
                        obj.Diagnosis = reader.GetString(5);
                        obj.CreationDate = reader.GetDateTime(6);
                        obj.Director = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HospitalitySession = reader.GetString(10);
                        obj.Nurse = reader.GetString(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.ParentType = reader.GetString(13);
                        obj.TemplateName = reader.GetString(14);
                        obj.IssuingDate = reader.GetDateTime(15);
                        obj.SkipPrint = reader.GetBoolean(16);

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
                String sql = String.Format("SELECT r_object_id, dss_has_kag, dsid_parent_id, dsid_pharmacologist, dss_diagnosis, r_creation_date, dsid_director, dsid_doctor, dsid_patient, dsid_hospitality_session, dsid_nurse, r_modify_date, dss_parent_type, dss_template_name, dsdt_issuing_date, dsb_skip_print FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='{0}", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtIssuedMedicineList obj = new DdtIssuedMedicineList();
                        obj.ObjectId = reader.GetString(1);
                        obj.HasKag = reader.GetString(2);
                        obj.ParentId = reader.GetString(3);
                        obj.Pharmacologist = reader.GetString(4);
                        obj.Diagnosis = reader.GetString(5);
                        obj.CreationDate = reader.GetDateTime(6);
                        obj.Director = reader.GetString(7);
                        obj.Doctor = reader.GetString(8);
                        obj.Patient = reader.GetString(9);
                        obj.HospitalitySession = reader.GetString(10);
                        obj.Nurse = reader.GetString(11);
                        obj.ModifyDate = reader.GetDateTime(12);
                        obj.ParentType = reader.GetString(13);
                        obj.TemplateName = reader.GetString(14);
                        obj.IssuingDate = reader.GetDateTime(15);
                        obj.SkipPrint = reader.GetBoolean(16);

                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
