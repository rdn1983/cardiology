using Cardiology.Model;
using System;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class PatientWorkInfo : Form
    {
        private DdtReleasePatient releasePatientInfo;

        public PatientWorkInfo(DdtReleasePatient releasePatientInfo)
        {
            this.releasePatientInfo = releasePatientInfo;
            InitializeComponent();
        }

        public DdtReleasePatient ReleasePatientInfo { get => releasePatientInfo; }

        private void returnWorkInfo_Click(object sender, EventArgs e)
        {
            if (releasePatientInfo != null)
            {
                releasePatientInfo.DssDisabilityNum = disabilityTxt.Text;
                releasePatientInfo.DssExtrSixklistNum = oldSickListNumTxt.Text;
                releasePatientInfo.DssOccupationalHazard = occupationalHazardTxt.Text;
                releasePatientInfo.DssOurSicklistNum = ourSickListNumTxt.Text;
                releasePatientInfo.DssProfession = professionTxt.Text;
                releasePatientInfo.DssYearDisabilities = yearDisabilitiesTxt.Text;

                releasePatientInfo.DsbDicmissedLess30D = dismissedBtn.Checked;
                releasePatientInfo.DsbExtrOpenedSicklist = hasSickListBtn.Checked;
                releasePatientInfo.DsbIsWorking = worksBtn.Checked;
                releasePatientInfo.DsbPensioneer = pensionerBtn.Checked;
                releasePatientInfo.DsbSicklistNeed = sickListNeedBtn.Checked;

                releasePatientInfo.DsdtExtrEndDate = oldSickListStartDateTxt.Value;
                releasePatientInfo.DsdtExtrStartDate = oldSickListEndDateTxt.Value;
                releasePatientInfo.DsdtOurEndDate = ourSickLIstEndDateTxt.Value;
                releasePatientInfo.DsdtOurStartDate = ourSickListStartDateTxt.Value;
                Close();
            }
        }
    }
}
