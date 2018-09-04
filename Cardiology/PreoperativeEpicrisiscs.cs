using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class PreoperativeEpicrisiscs : Form
    {
        private DdtHospital hospitalitySession;
        private string objectId;
        private AnalysisSelector selector; 

        public PreoperativeEpicrisiscs(DdtHospital hospitalitySession, string objectId)
        {
            this.hospitalitySession = hospitalitySession;
            this.objectId = objectId;
            selector = new AnalysisSelector();
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            if (CommonUtils.isNotBlank(objectId))
            {
                DataService service = new DataService();
                DdtEpicrisis epicrisis = service.queryObjectById<DdtEpicrisis>(DdtEpicrisis.TABLE_NAME, objectId);
                if (epicrisis!=null)
                {
                    diagnosisTxt.Text = epicrisis.DssDiagnosis;
                    epicrisisDateTxt.Value = epicrisis.DsdtEpicrisisDate;
                }
            }
        }

        private void chooseDiagnosisBtn_Click(object sender, EventArgs e)
        {
            selector.ShowDialog("ddv_all_diagnosis", "dsid_hospitality_session='"+hospitalitySession.ObjectId+"'", "dss_diagnosis", "r_object_id", null);
            List<string> diagnosies = selector.returnValues();
            StringBuilder str = new StringBuilder();
            foreach (string v in diagnosies)
            {
                str.Append(v);
            }
            diagnosisTxt.Text = str.ToString();
        }

        private void chooseAnalysisBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
