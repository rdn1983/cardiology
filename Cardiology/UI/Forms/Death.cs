using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            values.Add(@"{doctor.who.short}", doc == null ? "" : doc.ShortName);
            values.Add(@"{doctor.appointment_name}", "");
            values.Add(@"{patient.full_name}", patient.ShortName);
            values.Add(@"{patient.birthdate}", "");
            values.Add(@"{patient.sex}", "");
            values.Add(@"{patient.medcode}", patient.MedCode);
            values.Add(@"{doctor.who}", doctorsBox.Text);
            TemplatesUtils.FillTemplateAndShow(templatePath, values);
        }
    }
}
