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
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Debug("example debug message!");
            logger.Error("example error message!");
            logger.Warn("example warn message!");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PatientList());
        }
    }
}
