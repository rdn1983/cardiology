using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class UserFormTrombolizis : Form
    {
        private readonly IDbDataService service;
        private DdtPatient patient;

        public UserFormTrombolizis(IDbDataService service, DdtPatient patient)
        {
            this.service = service;
            this.patient = patient;
            InitializeComponent();
            initializeDoctorsBox();
        }

        private void initializeDoctorsBox()
        {
            IList<DdvDoctor> doctors = service.GetDdvDoctorService().GetAll();
            foreach (var obj in doctors)
            {
                doctorOkrCB.Items.Add(obj);
            }
            doctorOkrCB.ValueMember = "ObjectId";
            doctorOkrCB.DisplayMember = "DssFullName";

        }

        private void trombolizisPrintBtn_Click(object sender, EventArgs e)
        {
            if (doctorOkrCB.SelectedIndex<0)
            {
                MessageBox.Show("Введены не все данные на форме!", "Предупреждение!", MessageBoxButtons.OK);
                return;
            }
            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\trombolisis_template.doc";

            Dictionary<string, string> values = new Dictionary<string, string>();
            if (patient!=null)
            {
                values.Add(@"{patient.full_name}", patient.DssFullName);
                values.Add(@"{patient.med_code}", patient.DssMedCode);
                values.Add(@"{patient.initials}", patient.ShortName);
            }
            values.Add(@"{date}", dateCtrl.Text);
            values.Add(@"{time}", timeCtrl.Text);
            values.Add(@"{doctor.who}", doctorOkrCB.Text);
            TemplatesUtils.FillTemplateAndShow(templatePath, values);
        }
    }
}
