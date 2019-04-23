using System;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class ProtocolsManipulation : Form
    {
        public const int KATETER_MANIPULATION = 0;

        private const string KATETER_MANIPULATION_TITLE = "Катетеризация подключичной, яремной вены пациента:";
        private DdvPatient patient;
        private int manipulationType;

        public ProtocolsManipulation(DdvPatient patient, int manipulationType)
        {
            this.patient = patient;
            this.manipulationType = manipulationType;
            InitializeComponent();
            initializeDoctorsBox();
            initializeBody();
        }

        private void initializeDoctorsBox()
        {
            CommonUtils.InitDoctorsByGroupComboboxValues(DbDataService.GetInstance(), doctorsBox, "cardioreanimation_department");
        }

        private void initializeBody()
        {
            switch (manipulationType)
            {
                case KATETER_MANIPULATION:
                    titleLbl.Text = KATETER_MANIPULATION_TITLE + patient.FullName;
                    veinsKateterInfo.Visible = true;
                    break;
            }

        }

        private void openInWord_Click(object sender, EventArgs e)
        {

        }

        private string getTemplatePath()
        {
            return "";
        }
    }
}
