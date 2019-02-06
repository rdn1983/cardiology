using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardiology.Data.PostgreSQL
{
    class PgConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["Cardio"].ConnectionString;
            connection.Open();
            return connection;
        }
    }
}
