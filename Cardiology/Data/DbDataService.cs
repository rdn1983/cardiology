namespace Cardiology.Data
{
    class DbDataService
    {
        private static IDbDataService dbService;

        public static IDbDataService GetService()
        {
            if (dbService == null)
            {
                throw new System.Exception("Connection is null!");
            }
            return dbService;
        }

        public static void SetService(IDbDataService service)
        {
            dbService = service;
        }

        private DbDataService()
        {

        }
    }
}
