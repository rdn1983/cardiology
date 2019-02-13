using System;
using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class BloodAnalysisControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;

        public BloodAnalysisControl() : this(null, false)
        {
        }

        public BloodAnalysisControl(string objectId, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtBloodAnalysis blood = service.queryObjectById<DdtBloodAnalysis>(objectId);
            refreshObject(blood);
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

        private void OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                hasChanges = true;
            }
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            
                if (isEditable && (isDirty() || isNew && getIsValid()))
            {
                DataService service = new DataService();
                DdtBloodAnalysis bloodObj = (DdtBloodAnalysis)getObject();
                bloodObj.DsidHospitalitySession = hospitalitySession.ObjectId;
                bloodObj.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                bloodObj.DsidPatient = hospitalitySession.DsidPatient;
                bloodObj.DssParentType = parentType == null ? bloodObj.DssParentType : parentType;
                bloodObj.DsidParent = parentId == null ? bloodObj.DsidParent : parentId;
                objectId = service.updateOrCreateIfNeedObject<DdtBloodAnalysis>(bloodObj, DdtBloodAnalysis.TABLE_NAME, bloodObj.RObjectId);
                hasChanges = false;
                isNew = false;
            }
        }

        public string getObjectId()
        {
            return objectId;
        }

        public bool getIsValid()
        {
            return !string.IsNullOrEmpty(regularTrombocytesTxt.Text) || !string.IsNullOrEmpty(regularAltTxt.Text)
                        || !string.IsNullOrEmpty(regularAmilazaTzt.Text) || !string.IsNullOrEmpty(regularAstTxt.Text)
                        || !string.IsNullOrEmpty(regularBilTxt.Text) || !string.IsNullOrEmpty(regularChloriumTxt.Text)
                        || !string.IsNullOrEmpty(regularCholesterolTxt.Text) || !string.IsNullOrEmpty(regularKreatininTxt.Text)
                        || !string.IsNullOrEmpty(regularHemoglobinTxt.Text) || !string.IsNullOrEmpty(regularIronTxt.Text)
                        || !string.IsNullOrEmpty(regularKfkTxt.Text) || !string.IsNullOrEmpty(regularKfkMvTxt.Text)
                        || !string.IsNullOrEmpty(regularBloodLeucoTxt.Text) || !string.IsNullOrEmpty(regularPotassiumTxt.Text)
                        || !string.IsNullOrEmpty(regularProreinTxt.Text) || !string.IsNullOrEmpty(regularSchfTxt.Text)
                        || !string.IsNullOrEmpty(regularSodiumTxt.Text) || !string.IsNullOrEmpty(regularSrbTxt.Text);
        }

        public object getObject()
        {
            DataService service = new DataService();
            DdtBloodAnalysis bloodObj = service.queryObjectById<DdtBloodAnalysis>(objectId);
            if (bloodObj == null)
            {
                bloodObj = new DdtBloodAnalysis();
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
            return bloodObj;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtBloodAnalysis)
            {
                DdtBloodAnalysis blood = (DdtBloodAnalysis)obj;
                if (blood.DsdtAnalysisDate > DateTime.MinValue)
                {
                    regularBloodDateTxt.Value = blood.DsdtAnalysisDate;
                }
                regularAltTxt.Text = blood.DsdAlt;
                regularAmilazaTzt.Text = blood.DsdAmylase;
                regularAstTxt.Text = blood.DsdAst;
                regularBilTxt.Text = blood.DsdBil;
                regularChloriumTxt.Text = blood.DsdChlorine;
                regularCholesterolTxt.Text = blood.DsdCholesterolr;
                regularKreatininTxt.Text = blood.DsdCreatinine;
                regularHemoglobinTxt.Text = blood.DsdHemoglobin;
                regularIronTxt.Text = blood.DsdIron;
                regularKfkTxt.Text = blood.DsdKfk;
                regularKfkMvTxt.Text = blood.DsdKfkMv;
                regularBloodLeucoTxt.Text = blood.DsdLeucocytes;
                regularTrombocytesTxt.Text = blood.DsdPlatelets;
                regularPotassiumTxt.Text = blood.DsdPotassium;
                regularProreinTxt.Text = blood.DsdProtein;
                regularSchfTxt.Text = blood.DsdSchf;
                regularSodiumTxt.Text = blood.DsdSodium;
                regularSrbTxt.Text = blood.DsdSrp;
                objectId = blood.RObjectId;
                isNew = string.IsNullOrEmpty(blood.RObjectId);
                hasChanges = false;
            }

        }

        public bool isDirty()
        {
            return hasChanges;
        }

        private void regularBloodDateTxt_ValueChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        public bool isVisible()
        {
            return true;
        }

    }
}
