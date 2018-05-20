using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Data.SQLite;
using Cardiology.Model;

namespace Cardiology
{
    class DataService
    {
        public DataService() {
            if(!File.Exists("cardiology.sqlite"))
            {
                SQLiteConnection connection = null;
                try
                {
                    connection = new SQLiteConnection();
                    connection.ConnectionString = "Data Source=cardiology.sqlite";

                    connection.Open();

                    string sql = @"create table ddt_values(dss_name varchar(100) not null, dss_value varchar(1024))";
                    SQLiteCommand command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();

                    string sql2 = @"create unique index ddt_values_dss_name_uindex on ddt_values (dss_name)";
                    SQLiteCommand command2 = new SQLiteCommand(sql2, connection);
                    command2.ExecuteNonQuery();

                    string sql3 = @"INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.lastname', 'Борисов')";
                    SQLiteCommand command3 = new SQLiteCommand(sql3, connection);
                    command3.ExecuteNonQuery();

                    string sql4 = @"INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.name', 'Эраст')";
                    SQLiteCommand command4 = new SQLiteCommand(sql4, connection);
                    command4.ExecuteNonQuery();

                    string sql5 = @"INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.secondname', 'Петрович')";
                    SQLiteCommand command5 = new SQLiteCommand(sql5, connection);
                    command5.ExecuteNonQuery();
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
            
        }

        public Patient GetPatient()
        {
            Patient patient = new Patient();

            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection();
                connection.ConnectionString = "Data Source=cardiology.sqlite";

                connection.Open();

                string sql = "SELECT dss_value FROM ddt_values WHERE dss_name = 'default.patient.lastname'";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    patient.lastName = (string)reader["dss_value"];
                }
                reader.Close();

                string sql2 = "SELECT dss_value FROM ddt_values WHERE dss_name = 'default.patient.name'";
                SQLiteCommand command2 = new SQLiteCommand(sql2, connection);
                SQLiteDataReader reader2 = command2.ExecuteReader();
                if (reader2.Read())
                {
                    patient.name = (string)reader2["dss_value"];
                }
                reader2.Close();

                string sql3 = "SELECT dss_value FROM ddt_values WHERE dss_name = 'default.patient.secondname'";
                SQLiteCommand command3 = new SQLiteCommand(sql3, connection);
                SQLiteDataReader reader3 = command3.ExecuteReader();
                if (reader3.Read())
                {
                    patient.secondName = (string)reader3["dss_value"];
                }
                reader3.Close();
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
