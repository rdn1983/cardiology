using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class UserBlanks : Form
    {
        public UserBlanks()
        {
            InitializeComponent();
        }

        private void printCommonAggrement_Click(object sender, EventArgs e)
        {
            string templatePath = Directory.GetCurrentDirectory() +  "\\Templates\\common_agreement_template.docx";
            Console.Write(templatePath);
            DataService service = new DataService();
            Patient patient = service.GetPatient();

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{patient.full_name}", patient.lastName + " " + patient.name + " " + patient.secondName);
            values.Add(@"{doctor.who}", @"Пупкин И.И.");
            values.Add(@"{patient.initials}", patient.lastName + " " + patient.name.Substring(0,1) + "." + patient.secondName.Substring(0,1));
            values.Add(@"{date}", @"23/05/2018");
            TemplatesUtils.fillTemplate(templatePath, values);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void printVICHAggreement_Click(object sender, EventArgs e)
        {
            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\aid_aggrement_template.docx";
            Console.Write(templatePath);
            DataService service = new DataService();
            Patient patient = service.GetPatient();

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{patient.full_name}", patient.lastName + " " + patient.name + " " + patient.secondName);
            values.Add(@"{date}", @"23/05/2018");
            values.Add(@"{patient.birthdate}", @"23/05/1919");
            TemplatesUtils.fillTemplate(templatePath, values);
        }

        private void pritStentggrement_Click(object sender, EventArgs e)
        {

        }
    }
}
