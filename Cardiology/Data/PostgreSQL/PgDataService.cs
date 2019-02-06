namespace Cardiology.Data.PostgreSQL
{
    class PgDataService : IDbDataService
    {
        private IDbConnectionFactory connectionFactory;

        public PgDataService(IDbConnectionFactory connectionFactory) {
            this.connectionFactory = connectionFactory;
        }

        public IDmGroupService GetGroupService()
        {
            return new PgGroupService(connectionFactory);
        }

        public IDbPatientService GetPatientService()
        {
            return new PgPatientList(connectionFactory);
        }
    }
}
