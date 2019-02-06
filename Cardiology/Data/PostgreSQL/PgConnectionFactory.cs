using System.Configuration;
using System.Data;

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
