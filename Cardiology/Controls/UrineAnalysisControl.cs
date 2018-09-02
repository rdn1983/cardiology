using System.Windows.Forms;
using Cardiology.Model;

namespace Cardiology
{
    public partial class UrineAnalysisControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;

        public UrineAnalysisControl(string objectId, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            InitializeComponent();
            initControls();

        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtUrineAnalysis urineAnalysis = service.queryObjectById<DdtUrineAnalysis>(DdtUrineAnalysis.TABLE_NAME, objectId);
            if (urineAnalysis != null)
            {
                dateUrineAnalysis.Text = urineAnalysis.DsdtAnalysisDate + "";
                colorTxt.Text = urineAnalysis.DssColor;
                erythrocytesTxt.Text = urineAnalysis.DssErythrocytes;
                leukocytesTxt.Text = urineAnalysis.DssLeukocytes;
                proteinTxt.Text = urineAnalysis.DssProtein;
                regularAnalysisBox.Text = "Анализы за " + urineAnalysis.RCreationDate.ToShortDateString();
            }
            dateUrineAnalysis.Enabled = !isEditable;
            colorTxt.ReadOnly = !isEditable;
            erythrocytesTxt.ReadOnly = !isEditable;
            leukocytesTxt.ReadOnly = !isEditable;
            proteinTxt.ReadOnly = !isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable)
            {
                DataService service = new DataService();
                DdtUrineAnalysis urine = service.queryObjectById<DdtUrineAnalysis>(DdtUrineAnalysis.TABLE_NAME, objectId);
                if (urine == null)
                {
                    urine = new DdtUrineAnalysis();
                    urine.DsidHospitalitySession = hospitalitySession.ObjectId;
                    urine.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    urine.DsidPatient = hospitalitySession.DsidPatient;
                }
                urine.DsdtAnalysisDate = dateUrineAnalysis.Value;
                urine.DssColor = colorTxt.Text;
                urine.DssLeukocytes = leukocytesTxt.Text;
                urine.DssErythrocytes = erythrocytesTxt.Text;
                urine.DssProtein = proteinTxt.Text;
                objectId = service.updateOrCreateIfNeedObject<DdtUrineAnalysis>(urine, DdtUrineAnalysis.TABLE_NAME, urine.ObjectId);
            }
        }

        public string getObjectId()
        {
            return objectId;
        }
    }
}
