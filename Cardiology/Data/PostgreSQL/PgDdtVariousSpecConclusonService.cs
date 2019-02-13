using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtVariousSpecConclusonService : IDdtVariousSpecConclusonService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtVariousSpecConclusonService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtVariousSpecConcluson> GetAll()
        {
            IList<DdtVariousSpecConcluson> list = new List<DdtVariousSpecConcluson>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dss_additional_info0, r_object_id, dsb_visible, dss_specialist_type, dss_additional_info2, dss_additional_info1, r_creation_date, dsid_parent, dsdt_admission_date, dss_additional_info4, dss_additional_info3, dss_specialist_conclusion, r_modify_date, dss_parent_type, dsb_additional_bool FROM ddt_various_spec_concluson";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtVariousSpecConcluson obj = new DdtVariousSpecConcluson();
                        obj.AdditionalInfo0 = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.Visible = reader.GetBoolean(3);
                        obj.SpecialistType = reader.GetString(4);
                        obj.AdditionalInfo2 = reader.GetString(5);
                        obj.AdditionalInfo1 = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.Parent = reader.GetString(8);
                        obj.AdmissionDate = reader.GetDateTime(9);
                        obj.AdditionalInfo4 = reader.GetString(10);
                        obj.AdditionalInfo3 = reader.GetString(11);
                        obj.SpecialistConclusion = reader.GetString(12);
                        obj.ModifyDate = reader.GetDateTime(13);
                        obj.ParentType = reader.GetString(14);
                        obj.AdditionalBool = reader.GetBoolean(15);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtVariousSpecConcluson GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT dss_additional_info0, r_object_id, dsb_visible, dss_specialist_type, dss_additional_info2, dss_additional_info1, r_creation_date, dsid_parent, dsdt_admission_date, dss_additional_info4, dss_additional_info3, dss_specialist_conclusion, r_modify_date, dss_parent_type, dsb_additional_bool FROM ddt_various_spec_concluson WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtVariousSpecConcluson obj = new DdtVariousSpecConcluson();
                        obj.AdditionalInfo0 = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.Visible = reader.GetBoolean(3);
                        obj.SpecialistType = reader.GetString(4);
                        obj.AdditionalInfo2 = reader.GetString(5);
                        obj.AdditionalInfo1 = reader.GetString(6);
                        obj.CreationDate = reader.GetDateTime(7);
                        obj.Parent = reader.GetString(8);
                        obj.AdmissionDate = reader.GetDateTime(9);
                        obj.AdditionalInfo4 = reader.GetString(10);
                        obj.AdditionalInfo3 = reader.GetString(11);
                        obj.SpecialistConclusion = reader.GetString(12);
                        obj.ModifyDate = reader.GetDateTime(13);
                        obj.ParentType = reader.GetString(14);
                        obj.AdditionalBool = reader.GetBoolean(15);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
