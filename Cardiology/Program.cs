using Cardiology.Data;
using Cardiology.Data.PostgreSQL;
using System;
using System.Windows.Forms;
using Cardiology.UI;
using Cardiology.UI.Forms;

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
            DbDataService.SetService(service);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PatientList(service));
        }
    }
}
