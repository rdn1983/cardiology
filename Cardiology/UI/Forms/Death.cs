using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Commons;
using Cardiology.Data.Model2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Cardiology.UI.Forms
{
    public partial class Death : Form
    {
        private readonly DdtHospital hospitalSession;
        private readonly DdvPatient patient;

        public Death(DdtHospital hospitalSession, DdvPatient patient)
        {
            this.hospitalSession = hospitalSession;
            this.patient = patient;
            InitializeComponent();

            IDdvDoctorService service = DbDataService.GetInstance().GetDdvDoctorService(); 
            ControlUtils.InitDoctorsByGroupName(service, doctorsBox, "cardioreanimation_department");
            doctorsBox.SelectedValue = hospitalSession.CuringDoctor;
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
            values.Add(@"{date}", deathDateTxt.Value.ToString("MM.dd.yyyy"));

            values.Add(@"{time}", deathTimeCtrl.Text);

            DdvDoctor doc = (DdvDoctor) doctorsBox.SelectedItem;

            values.Add(@"{doctor.who.short}", doc != null ? doc.ShortName: "");
            values.Add(
                "{patient.passport_info}",
                string.Format(CultureInfo.CurrentCulture, "{0} {1}, выдан {2} {3}", 
                patient.PassportSerial, patient.PassportNum, 
                patient.PassportDate.ToShortDateString(), patient.PassportIssuePlace)
                );
            values.Add(@"{doctor.appointment_name}", "");
            values.Add(@"{patient.full_name}", patient.FullName);
            values.Add(@"{patient.birthdate}", patient.Birthdate!=null ? patient.Birthdate.ToShortDateString(): "");            
            values.Add(@"{patient.sex}", patient.Sex ? "мужской" : "женский");
            values.Add(@"{patient.medcode}", patient.MedCode);
            values.Add(@"{doctor.who}", doc != null ? doc.FullName: "");
            TemplatesUtils.FillTemplateAndShow(templatePath, values, TemplatesUtils.getTempFileName("Констатация смерти", patient.FullName));
        }
    }
}
