using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class ReanimDEAD : Form
    {
        private DdtPatient patient;

        public ReanimDEAD(DdtPatient patient)
        {
            this.patient = patient;
            InitializeComponent();
            initializeDoctorsBox();
        }

        private void initializeDoctorsBox()
        {
            DataService service = new DataService();
            List<DdtDoctors> doctors = service.queryObjectsCollection<DdtDoctors>(@"select * from ddt_doctors");
            for (int i = 0; i < doctors.Count; i++)
            {
                doctorsBox.Items.Add(doctors[i]);
            }
            doctorsBox.ValueMember = "ObjectId";
            doctorsBox.DisplayMember = "DssFullName";

        }

        private bool getIsNotValid()
        {
            return doctorsBox.SelectedIndex < 0;
        }

        private void button2_Click(object sender, EventArgs e)
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
            DdtDoctors doc = (DdtDoctors)doctorsBox.SelectedItem;
            values.Add(@"{doctor.who.short}", doc == null ? "" : doc.DssInitials);
            values.Add(@"{doctor.appointment_name}", "");
            values.Add(@"{patient.full_name}", patient.DssFullName);
            values.Add(@"{patient.birthdate}", "");
            values.Add(@"{patient.sex}", "");
            values.Add(@"{patient.medcode}", patient.DssMedCode);
            values.Add(@"{doctor.who}", doctorsBox.Text);
            TemplatesUtils.fillTemplateAndShow(templatePath, values);
        }

        private void reanimOperationBtn_Click(object sender, EventArgs e)
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
            DdtDoctors doc = (DdtDoctors)doctorsBox.SelectedItem;
            values.Add(@"{doctor.who.short}", doc == null ? "" : doc.DssInitials);

            DateTime deathTime = CommonUtils.constructDateWIthTime(deathDateTxt.Value, deathTimeCtrl.Value);
            for (int i = 0; i < 10; i++)
            {
                deathTime = deathTime.AddMinutes(-5.0);
                values.Add(@"{time" + i + "}", deathTime.ToShortTimeString());

            }
            TemplatesUtils.fillTemplateAndShow(templatePath, values);
        }
    }
}
