using System.Windows.Forms;
using Cardiology.Model;

namespace Cardiology
{
    public partial class BloodAnalysisControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;

        public BloodAnalysisControl(string objectId, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtBloodAnalysis blood = service.queryObjectById<DdtBloodAnalysis>(DdtBloodAnalysis.TABLE_NAME, objectId);
            if (blood != null)
            {
                regularBloodDateTxt.Text = blood.DsdtAnalysisDate + "";
                regularAltTxt.Text = blood.DsdAlt + "";
                regularAmilazaTzt.Text = blood.DsdAmylase + "";
                regularAstTxt.Text = blood.DsdAst + "";
                regularBilTxt.Text = blood.DsdBil + "";
                regularChloriumTxt.Text = blood.DsdChlorine + "";
                regularCholesterolTxt.Text = blood.DsdCholesterolr + "";
                regularKreatininTxt.Text = blood.DsdCreatinine + "";
                regularHemoglobinTxt.Text = blood.DsdHemoglobin + "";
                regularIronTxt.Text = blood.DsdIron + "";
                regularKfkTxt.Text = blood.DsdKfk + "";
                regularKfkMvTxt.Text = blood.DsdKfkMv + "";
                regularBloodLeucoTxt.Text = blood.DsdLeucocytes + "";
                regularTrombocytesTxt.Text = blood.DsdPlatelets + "";
                regularPotassiumTxt.Text = blood.DsdPotassium + "";
                regularProreinTxt.Text = blood.DsdProtein + "";
                regularSchfTxt.Text = blood.DsdSchf + "";
                regularSodiumTxt.Text = blood.DsdSodium + "";
                regularSrbTxt.Text = blood.DsdSrp + "";
            }
            regularAltTxt.Enabled = isEditable;
            regularAmilazaTzt.Enabled = isEditable;
            regularAstTxt.Enabled = isEditable;
            regularBilTxt.Enabled = isEditable;
            regularChloriumTxt.Enabled = isEditable;
            regularCholesterolTxt.Enabled = isEditable;
            regularKreatininTxt.Enabled = isEditable;
            regularHemoglobinTxt.Enabled = isEditable;
            regularIronTxt.Enabled = isEditable;
            regularKfkTxt.Enabled = isEditable;
            regularKfkMvTxt.Enabled = isEditable;
            regularBloodLeucoTxt.Enabled = isEditable;
            regularTrombocytesTxt.Enabled = isEditable;
            regularPotassiumTxt.Enabled = isEditable;
            regularProreinTxt.Enabled = isEditable;
            regularSchfTxt.Enabled = isEditable;
            regularSodiumTxt.Enabled = isEditable;
            regularSrbTxt.Enabled = isEditable;
            regularBloodDateTxt.Enabled = isEditable;
            regularBloodPnl.Text = blood == null ? "Анализы текущие" : "Анализы промежуточные за " + blood.RCreationDate.ToShortDateString();
        }

        public void saveObject(DdtHospital hospitalitySession)
        {
            if (isEditable)
            {
                DataService service = new DataService();
                DdtBloodAnalysis bloodObj = service.queryObjectById<DdtBloodAnalysis>(DdtBloodAnalysis.TABLE_NAME, objectId);
                if (bloodObj == null)
                {
                    bloodObj = new DdtBloodAnalysis();
                    bloodObj.DsidHospitalitySession = hospitalitySession.ObjectId;
                    bloodObj.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    bloodObj.DsidPatient = hospitalitySession.DsidPatient;
                }
                bloodObj.DsdtAnalysisDate = regularBloodDateTxt.Value;
                bloodObj.DsdAlt = regularAltTxt.Text;
                bloodObj.DsdAmylase = regularAmilazaTzt.Text;
                bloodObj.DsdAst = regularAstTxt.Text;
                bloodObj.DsdBil = regularBilTxt.Text;
                bloodObj.DsdChlorine = regularChloriumTxt.Text;
                bloodObj.DsdCholesterolr = regularCholesterolTxt.Text;
                bloodObj.DsdCreatinine = regularKreatininTxt.Text;
                bloodObj.DsdHemoglobin = regularHemoglobinTxt.Text;
                bloodObj.DsdIron = regularIronTxt.Text;
                bloodObj.DsdKfk = regularKfkTxt.Text;
                bloodObj.DsdKfkMv = regularKfkMvTxt.Text;
                bloodObj.DsdLeucocytes = regularBloodLeucoTxt.Text;
                bloodObj.DsdPlatelets = regularTrombocytesTxt.Text;
                bloodObj.DsdPotassium = regularPotassiumTxt.Text;
                bloodObj.DsdProtein = regularProreinTxt.Text;
                bloodObj.DsdSchf = regularSchfTxt.Text;
                bloodObj.DsdSodium = regularSodiumTxt.Text;
                bloodObj.DsdSrp = regularSrbTxt.Text;
                objectId = service.updateOrCreateIfNeedObject<DdtBloodAnalysis>(bloodObj, DdtBloodAnalysis.TABLE_NAME, bloodObj.RObjectId);
            }
        }

        public string getObjectId()
        {
            return objectId;
        }
    }
}
