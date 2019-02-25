using System;
using System.Windows.Forms;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class PatientWorkInfo : Form
    {
        private DdtReleasePatient releasePatientInfo;

        public PatientWorkInfo(DdtReleasePatient releasePatientInfo)
        {
            this.releasePatientInfo = releasePatientInfo;
            InitializeComponent();
            System.Drawing.Size halfScreenSize = new System.Drawing.Size(SystemInformation.PrimaryMonitorSize.Width / 2,
                SystemInformation.PrimaryMonitorSize.Height);
            this.workHistoryBox.MaximumSize = halfScreenSize;
            this.openedSickListDataLbl.MaximumSize = halfScreenSize;
        }

        public DdtReleasePatient ReleasePatientInfo { get => releasePatientInfo; }

        private void returnWorkInfo_Click(object sender, EventArgs e)
        {
            if (releasePatientInfo != null)
            {
                releasePatientInfo.DisabilityNum = disabilityTxt.Text;
                releasePatientInfo.ExtrSicklistNum = oldSickListNumTxt.Text;
                releasePatientInfo.OccupationalHazard = occupationalHazardTxt.Text;
                releasePatientInfo.OurSicklistNum = ourSickListNumTxt.Text;
                releasePatientInfo.Profession = professionTxt.Text;
                releasePatientInfo.YearDisabilities = yearDisabilitiesTxt.Text;

                releasePatientInfo.DismissedLess30d = dismissedBtn.Checked;
                releasePatientInfo.ExtrOpenedSicklist = hasSickListBtn.Checked;
                releasePatientInfo.IsWorking = worksBtn.Checked;
                releasePatientInfo.Pensioneer = pensionerBtn.Checked;
                releasePatientInfo.SicklistNeed = sickListNeedBtn.Checked;

                releasePatientInfo.ExtrEnddate = oldSickListStartDateTxt.Value;
                releasePatientInfo.ExtrStartdate = oldSickListEndDateTxt.Value;
                releasePatientInfo.OurEnddate = ourSickLIstEndDateTxt.Value;
                releasePatientInfo.OurStartdate = ourSickListStartDateTxt.Value;
                Close();
            }
        }

        private void workHistoryBox_Resize(object sender, EventArgs e)
        {
            System.Drawing.Size halfScreenSize = new System.Drawing.Size(this.Size.Width / 2,
               this.Size.Height);
            this.workHistoryBox.Size = halfScreenSize;
            this.openedSickListDataLbl.Size = halfScreenSize;
            System.Drawing.Point startLocation = workHistoryBox.Location;
            openedSickListDataLbl.Location = new System.Drawing.Point(startLocation.X + workHistoryBox.Width, startLocation.Y);
        }
    }
}
