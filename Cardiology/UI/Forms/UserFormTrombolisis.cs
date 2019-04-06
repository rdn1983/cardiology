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
        private DdtPatient patient;

        public UserFormTrombolizis(DdtPatient patient)
        {
            this.patient = patient;
            InitializeComponent();
            initializeDoctorsBox();
        }

        private void initializeDoctorsBox()
        {
            CommonUtils.InitDoctorsByGroupComboboxValues(DbDataService.GetInstance(), doctorOkrCB, "cardioreanimation_department");
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
            DdvPatient patientView = DbDataService.GetInstance().GetDdvPatientService().GetById(patient.ObjectId);
            if (patient!=null)
            {
                values.Add(@"{patient.full_name}", patientView.FullName);
                values.Add(@"{patient.med_code}", patient.MedCode);
                values.Add(@"{patient.initials}", patientView.ShortName);
            }
            values.Add(@"{date}", dateCtrl.Text);
            values.Add(@"{time}", timeCtrl.Text);
            values.Add(@"{doctor.who}", doctorOkrCB.Text);
            TemplatesUtils.FillTemplateAndShow(templatePath, values);
        }
    }
}
