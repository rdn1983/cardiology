using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class Resuscitation : Form
    {
        private DdvPatient patient;

        public Resuscitation(DdvPatient patient)
        {
            this.patient = patient;
            InitializeComponent();
            CommonUtils.InitDoctorsByGroupComboboxValues(DbDataService.GetInstance(), doctorsBox, "cardioreanimation_department");
        }

        private bool getIsNotValid()
        {
            return doctorsBox.SelectedIndex < 0;
        }

        private void OpenReanimationProtocol(object sender, EventArgs e)
        {
            if (getIsNotValid())
            {
                MessageBox.Show("Введены не все данные на форме!", "Предупреждение!", MessageBoxButtons.OK);
                return;
            }

            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\reanim_operations_template.doc";

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{death.date}", deathDateTxt.Text);
            values.Add(@"{death.time}", deathTimeCtrl.Text);

            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            values.Add(@"{doctor.who.short}", doc == null ? "" : doc.ShortName);

            DateTime deathTime = CommonUtils.ConstructDateWIthTime(deathDateTxt.Value, deathTimeCtrl.Value);
            for (int i = 0; i < 10; i++)
            {
                deathTime = deathTime.AddMinutes(-5.0);
                values.Add(@"{time" + i + "}", deathTime.ToShortTimeString());

            }
            TemplatesUtils.FillTemplateAndShow(templatePath, values);
        }
    }
}
