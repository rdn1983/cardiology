using System;

namespace Cardiology.Data
{
    public static class DbDataService
    {
        private static IDbDataService instance;

        public static IDbDataService GetInstance()
        {
            if (instance == null)
            {
                throw new NullReferenceException("IDbDataService instance is null");
            }
            return instance;
        }

        public static void SetInstance(IDbDataService value)
        {
            instance = value;
        }
    }
}
