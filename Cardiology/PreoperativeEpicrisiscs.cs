using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class PreoperativeEpicrisiscs : Form
    {
        private DdtHospital hospitalitySession;
        private string objectId;

        public PreoperativeEpicrisiscs(DdtHospital hospitalitySession, string objectId)
        {
            this.hospitalitySession = hospitalitySession;
            this.objectId = objectId;
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            if (CommonUtils.isNotBlank(objectId))
            {
                DataService service = new DataService();
            }
        }

        private void chooseDiagnosisBtn_Click(object sender, EventArgs e)
        {

        }

        private void chooseAnalysisBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
