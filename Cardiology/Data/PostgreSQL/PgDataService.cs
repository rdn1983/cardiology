namespace Cardiology.Data.PostgreSQL
{
    class PgDataService : IDbDataService
    {
        private IDbConnectionFactory connectionFactory;

        public PgDataService(IDbConnectionFactory connectionFactory) {
            this.connectionFactory = connectionFactory;
        }

        public IDbPatientService GetPatientService()
        {
            return new PgPatientList(connectionFactory);
        }
    }
}
