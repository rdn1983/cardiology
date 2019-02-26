using System;
using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class ReleasePatient : Form
    {
        private readonly IDbDataService service;
        private DdtReleasePatient releasePatientInfo;
        private DdtHospital hospitalitySession;
        private string epicrisisId;

        public ReleasePatient(IDbDataService service, DdtHospital hospitalitySession, string epicrisisId)
        {
            this.service = service;
            this.epicrisisId = epicrisisId;
            this.hospitalitySession = hospitalitySession;
            releasePatientInfo = new DdtReleasePatient();
            releasePatientInfo.HospitalitySession = hospitalitySession.ObjectId;
            releasePatientInfo.Doctor = hospitalitySession.DutyDoctor;
            releasePatientInfo.Patient = hospitalitySession.Patient;
            InitializeComponent();
            DdvPatient patient = service.GetDdvPatientService().GetById(hospitalitySession.Patient);
            if (patient != null)
            {
                Text += " " + patient.ShortName;
            }
        }


        private void formTrudBtn_Click(object sender, EventArgs e)
        {
            PatientWorkInfo form = new PatientWorkInfo(releasePatientInfo);
            form.ShowDialog();
            releasePatientInfo = form.ReleasePatientInfo;
            sickListNumTxt.Text = releasePatientInfo.OurSicklistNum;
            //sickListStartDateTxt.Value = releasePatientInfo.DsdtOurStartDate;
            //sickListEndDateTxt.Value = releasePatientInfo.DsdtOurEndDate;
        }

        private void releasePatientBtn_Click(object sender, EventArgs e)
        {


            hospitalitySession.Active = false;
            hospitalitySession.RejectCure = refusedBtn.Checked;
            service.GetDdtHospitalService().Save(hospitalitySession);

            DdtEpicrisis epicrisis = service.GetDdtEpicrisisService().GetById(epicrisisId);
            if (epicrisis == null)
            {
                epicrisis = new DdtEpicrisis();
                epicrisis.Doctor = hospitalitySession.CuringDoctor;
                epicrisis.HospitalitySession = hospitalitySession.ObjectId;
                epicrisis.Patient = hospitalitySession.Patient;
            }
            epicrisis.Diagnosis = hospitalitySession.Diagnosis;
            epicrisis.EpicrisisDate = DateTime.Now;
            epicrisis.EpicrisisType = deathBtn.Checked ? (int)DdtEpicrisisDsiType.DEATH : transferBtn.Checked ? (int)DdtEpicrisisDsiType.TRANSFER : (int)DdtEpicrisisDsiType.RELEASE;
            service.GetDdtEpicrisisService().Save(epicrisis);

            if (transferBtn.Checked)
            {
                MessageBox.Show("Необходимо создать письмо в скорую помощь!", "Предупреждение!", MessageBoxButtons.OK);
            } else if (deathBtn.Checked)
            {
                MessageBox.Show("Необходимо констатировать смерть!", "Предупреждение!", MessageBoxButtons.OK);
            }
            Close();
        }


        private void addIssuedMedicineBtn_Click(object sender, EventArgs e)
        {
            TextBox issuedMedicineNext = new TextBox();
            issuedMedicineNext.Size = issuedMedicine0.Size;
            issuedMedicineBox.Controls.Add(issuedMedicineNext);
        }
    }
}
