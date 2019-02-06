using Cardiology.Data;
using Cardiology.Data.PostgreSQL;
using NLog;
using System;
using System.Windows.Forms;

namespace Cardiology
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IDbConnectionFactory connectionFactory = new PgConnectionFactory();
            IDbDataService service = new PgDataService(connectionFactory);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PatientList(service));
        }
    }
}
