using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class ProtocolsManipulation : Form
    {
        public const int KATETER_MANIPULATION = 0;

        private const string KATETER_MANIPULATION_TITLE = "Катетеризация подключичной, яремной вены пациента:";

        private DdtPatient patient;
        private int manipulationType;

        public ProtocolsManipulation(DdtPatient patient, int manipulationType)
        {
            this.patient = patient;
            this.manipulationType = manipulationType;
            InitializeComponent();
            initializeDoctorsBox();
            initializeBody();
        }

        private void initializeDoctorsBox()
        {

            List<DdvDoctor> doctors = service.queryObjectsCollection<DdvDoctor>(@"select * from ddt_doctors");
            for (int i = 0; i < doctors.Count; i++)
            {
                doctorsBox.Items.Add(doctors[i]);
            }
            doctorsBox.ValueMember = "ObjectId";
            doctorsBox.DisplayMember = "DssFullName";

        }

        private void initializeBody()
        {
            switch (manipulationType)
            {
                case KATETER_MANIPULATION:
                    titleLbl.Text = KATETER_MANIPULATION_TITLE + patient.DssFullName;
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
