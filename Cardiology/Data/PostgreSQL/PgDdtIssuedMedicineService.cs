using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtIssuedMedicineService : IDdtIssuedMedicineService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtIssuedMedicineService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtIssuedMedicine> GetAll()
        {
            IList<DdtIssuedMedicine> list = new List<DdtIssuedMedicine>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT dsid_med_list, r_object_id, dsid_cure, r_modify_date, r_creation_date FROM ddt_issued_medicine";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtIssuedMedicine obj = new DdtIssuedMedicine();
                        obj.MedList = reader.GetString(1);
                        obj.ObjectId = reader.GetString(2);
                        obj.Cure = reader.GetString(3);
                        obj.ModifyDate = reader.GetDateTime(4);
                        obj.CreationDate = reader.GetDateTime(5);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
    }
}
