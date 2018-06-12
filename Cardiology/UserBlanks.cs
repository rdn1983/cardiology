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
            DdtPatient patient = service.fillFromQuery<DdtPatient>(@"Select * from ddt_patient");

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{patient.full_name}", "");
            values.Add(@"{doctor.who}", @"Пупкин И.И.");
            values.Add(@"{patient.initials}", "");
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
            DdtPatient patient = service.fillFromQuery<DdtPatient>(@"Select * from ddt_patient");

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{patient.full_name}", "");
            values.Add(@"{date}", @"23/05/2018");
            values.Add(@"{patient.birthdate}", @"23/05/1919");
            TemplatesUtils.fillTemplate(templatePath, values);
        }

        private void pritStentggrement_Click(object sender, EventArgs e)
        {

        }
    }
}
