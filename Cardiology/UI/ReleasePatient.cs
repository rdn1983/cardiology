using System;
using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model;

namespace Cardiology.UI
{
    public partial class ReleasePatient : Form
    {
        private DdtReleasePatient releasePatientInfo;
        private DdtHospital hospitalitySession;
        private string epicrisisId;

        public ReleasePatient(DdtHospital hospitalitySession, string epicrisisId)
        {
            this.epicrisisId = epicrisisId;
            this.hospitalitySession = hospitalitySession;
            releasePatientInfo = new DdtReleasePatient();
            releasePatientInfo.DsidHospitalitySession = hospitalitySession.ObjectId;
            releasePatientInfo.DsidDoctor = hospitalitySession.DsidDutyDoctor;
            releasePatientInfo.DsidPatient = hospitalitySession.DsidPatient;
            InitializeComponent();
            DataService service = new DataService();
            DdtPatient patient = service.queryObjectById<DdtPatient>(hospitalitySession.DsidPatient);
            if (patient != null)
            {
                Text += " " + patient.DssInitials;
            }
        }


        private void formTrudBtn_Click(object sender, EventArgs e)
        {
            PatientWorkInfo form = new PatientWorkInfo(releasePatientInfo);
            form.ShowDialog();
            releasePatientInfo = form.ReleasePatientInfo;
            sickListNumTxt.Text = releasePatientInfo.DssOurSicklistNum;
            //sickListStartDateTxt.Value = releasePatientInfo.DsdtOurStartDate;
            //sickListEndDateTxt.Value = releasePatientInfo.DsdtOurEndDate;
        }

        private void releasePatientBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();

            service.insertObject<DdtReleasePatient>(releasePatientInfo, DdtReleasePatient.TABLE_NAME);

            hospitalitySession.DsbActive = false;
            hospitalitySession.DsbRejectCure = refusedBtn.Checked;
            service.updateObject<DdtHospital>(hospitalitySession, DdtHospital.TABLE_NAME, "r_object_id", hospitalitySession.ObjectId);

            DdtEpicrisis epicrisis = service.queryObjectById<DdtEpicrisis>(epicrisisId);
            if (epicrisis == null)
            {
                epicrisis = new DdtEpicrisis();
                epicrisis.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                epicrisis.DsidHospitalitySession = hospitalitySession.ObjectId;
                epicrisis.DsidPatient = hospitalitySession.DsidPatient;
            }
            epicrisis.DssDiagnosis = hospitalitySession.DssDiagnosis;
            epicrisis.DsdtEpicrisisDate = DateTime.Now;
            epicrisis.DsiEpicrisisType = deathBtn.Checked ? (int)DdtEpicrisisDsiType.DEATH : transferBtn.Checked ? (int)DdtEpicrisisDsiType.TRANSFER : (int)DdtEpicrisisDsiType.RELEASE;
            service.updateOrCreateIfNeedObject<DdtEpicrisis>(epicrisis, DdtEpicrisis.TABLE_NAME, epicrisisId);

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
