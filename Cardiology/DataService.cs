using Cardiology.Model;
using System;
using System.Reflection;

namespace Cardiology
{
    class DataService
    {
        public DataService() {
            
        }

        public Patient GetPatient()
        {
            Patient patient = new Patient();

            Npgsql.NpgsqlConnection connection = null;

            try {
                connection = new Npgsql.NpgsqlConnection();
                connection.ConnectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=111;Database=postgres;";
                connection.Open();

                string sql = @"SELECT dss_name, dss_value FROM ddt_values WHERE dss_name LIKE 'default.patient.%'";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);

                Npgsql.NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string value = reader.GetString(1);

                    switch (name) {
                        case "default.patient.name":
                            patient.name = value;
                            break;
                        case "default.patient.secondname":
                            patient.secondName = value;
                            break;
                        case "default.patient.lastname":
                            patient.lastName = value;
                            break;
                        case "default.patient.birthday":
                            if (value != null)
                            {
                                patient.birthday = DateTime.Parse(value);
                            }
                            break;
                        case "default.patient.receipttime":
                            if (value != null)
                            {
                                patient.receiptDateTime = DateTime.Parse(value);
                            }
                            break;

                    }
                }
            } finally {
                if(connection != null)
                {
                    connection.Close();
                }
            }


            return patient;
        }

        public Patient GetPatientWithReflection()
        {
            Patient patient = new Patient();

            Npgsql.NpgsqlConnection connection = null;

            try
            {
                connection = new Npgsql.NpgsqlConnection();
                connection.ConnectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=111;Database=postgres;";
                connection.Open();

                string sql = @"SELECT * FROM ddt_patient ";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);

                Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    
                    FieldInfo[] fields = typeof(Patient).GetFields();
                    for (int i=0; i<fields.Length; i++)
                    {
                        string name = reader.GetString(0);
                        object value = reader.GetValue(1);

                        FieldInfo fieldInfo = fields[i];
                        TableAttribute attrInfo = Attribute.GetCustomAttribute(fieldInfo, typeof(TableAttribute)) as TableAttribute;
                        
                        if (attrInfo!=null && attrInfo.AttrName.Equals(name))
                        {
                            Console.WriteLine(fieldInfo.Name);
                            fieldInfo.SetValue(patient, value);
                        }
                    }
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }


            return patient;
        }

    }
}
