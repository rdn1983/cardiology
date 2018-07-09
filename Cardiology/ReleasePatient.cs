using Cardiology.Model;
using System;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class ReleasePatient : Form
    {
        private DdtReleasePatient releasePatientInfo;
        private DdtHospital hospitalitySession;

        public ReleasePatient(DdtHospital hospitalitySession)
        {
            this.hospitalitySession = hospitalitySession;
            releasePatientInfo = new DdtReleasePatient();
            releasePatientInfo.DsidHospitalitySession = hospitalitySession.ObjectId;
            releasePatientInfo.DsidDoctor = hospitalitySession.DsidDutyDoctor;
            releasePatientInfo.DsidPatient = hospitalitySession.DsidPatient;
            InitializeComponent();
        }


        private void formTrudBtn_Click(object sender, EventArgs e)
        {
            PatientWorkInfo form = new PatientWorkInfo(releasePatientInfo);
            form.ShowDialog();
            releasePatientInfo = form.ReleasePatientInfo;
            sickListNumTxt.Text = releasePatientInfo.DssOurSicklistNum;
            sickListStartDateTxt.Value = releasePatientInfo.DsdtOurStartDate;
            sickListEndDateTxt.Value = releasePatientInfo.DsdtOurEndDate;
        }

        private void releasePatientBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            service.insertObject<DdtReleasePatient>(releasePatientInfo, DdtReleasePatient.TABLE_NAME);

            hospitalitySession.DsbActive = movedToCardioBtn.Checked;
            hospitalitySession.DsbRejectCure = refusedBtn.Checked;
            service.updateObject<DdtHospital>(hospitalitySession, DdtHospital.TABLENAME, "r_object_id", hospitalitySession.ObjectId);
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
