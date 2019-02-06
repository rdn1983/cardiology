using System.Data;

namespace Cardiology.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
