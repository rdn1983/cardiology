using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cardiology.Utils;

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
            /*string templatePath = @"Y:\\Justification_expensive.docx";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{patient.name}", @"Petrov V.S.");
            values.Add(@"{patient.age}", @"140");
            values.Add(@"{patient.nameanalysis}", @"Petrov V.S.");
            values.Add(@"{doctor.who}", @"Vavilov B B");
            TemplatesUtils.fillTemplate(templatePath, values);*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Start());
        }
    }
}
