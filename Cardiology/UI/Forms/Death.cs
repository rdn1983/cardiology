using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Cardiology.UI.Forms
{
    public partial class Death : Form
    {
        private readonly DdvPatient patient;

        public Death(DdvPatient patient)
        {
            this.patient = patient;
            InitializeComponent();

            CommonUtils.InitDoctorsComboboxValues(DbDataService.GetInstance(), doctorsBox, null);
        }

        private bool getIsNotValid()
        {
            return doctorsBox.SelectedIndex < 0;
        }

        private void OpenDeathProtocol(object sender, EventArgs e)
        {
            if (getIsNotValid())
            {
                MessageBox.Show("Введены не все данные на форме!", "Предупреждение!", MessageBoxButtons.OK);
                return;
            }

            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\death_template.doc";

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{date}", deathDateTxt.Text);

            values.Add(@"{time}", deathTimeCtrl.Text);

            DdvDoctor doc = (DdvDoctor) doctorsBox.SelectedItem;

            values.Add(@"{doctor.who.short}", doc != null ? doc.ShortName: "");
            values.Add(@"{doctor.appointment_name}", "");
            values.Add(@"{patient.full_name}", patient.ShortName);
            values.Add(@"{patient.birthdate}", patient.Birthdate!=null ? patient.Birthdate.ToShortDateString(): "");
            values.Add(@"{patient.sex}", "");
            values.Add(@"{patient.medcode}", patient.MedCode);
            values.Add(@"{doctor.who}", doc!=null? doc.FullName: "");
            TemplatesUtils.FillTemplateAndShow(templatePath, values);
        }
    }
}
