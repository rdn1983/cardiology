using Cardiology.Data;
using Cardiology.Data.PostgreSQL;
using Cardiology.UI.Forms;
using NLog;
using System;
using System.Windows.Forms;

namespace Cardiology
{
    static class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool admin = args != null && args.Length > 0 && "-x".Equals(args[0], StringComparison.Ordinal);

            Logger.Info("START Cardiology");

            IDbDataService service = new PgDataService(new PgConnectionFactory());
            DbDataService.SetInstance(service);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PatientList(service, admin));
        }
    }
}
