using System;
using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Commons;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class BloodAnalysisControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;
        private IAnalysisContainer container;

        public BloodAnalysisControl(string objectId, bool additional) : this(objectId, null, additional) { }

        public BloodAnalysisControl(string objectId, IAnalysisContainer container, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            this.container = container;
            InitializeComponent();
            InitControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        private void InitControls()
        {
            DdtBloodAnalysis blood = DbDataService.GetInstance().GetDdtBloodAnalysisService().GetById(objectId);
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
            regularBloodPnl.Text = blood == null ? "Анализы текущие" : "Анализы промежуточные за " + blood.AnalysisDate.ToShortDateString();
        }

        private void OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
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
                DdtBloodAnalysis bloodObj = (DdtBloodAnalysis)getObject();
                bloodObj.HospitalitySession = hospitalitySession.ObjectId;
                bloodObj.Doctor = hospitalitySession.CuringDoctor;
                bloodObj.Patient = hospitalitySession.Patient;
                bloodObj.ParentType = parentType;
                bloodObj.Parent = parentId;
                objectId = DbDataService.GetInstance().GetDdtBloodAnalysisService().Save(bloodObj);

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
            DdtBloodAnalysis bloodObj = DbDataService.GetInstance().GetDdtBloodAnalysisService().GetById(objectId);
            if (bloodObj == null)
            {
                bloodObj = new DdtBloodAnalysis();
            }
            bloodObj.AnalysisDate = regularBloodDateTxt.Value;
            bloodObj.Alt = regularAltTxt.Text;
            bloodObj.Amylase = regularAmilazaTzt.Text;
            bloodObj.Ast = regularAstTxt.Text;
            bloodObj.Bil = regularBilTxt.Text;
            bloodObj.Chlorine = regularChloriumTxt.Text;
            bloodObj.Cholesterol = regularCholesterolTxt.Text;
            bloodObj.Creatinine = regularKreatininTxt.Text;
            bloodObj.Hemoglobin = regularHemoglobinTxt.Text;
            bloodObj.Iron = regularIronTxt.Text;
            bloodObj.Kfk = regularKfkTxt.Text;
            bloodObj.KfkMv = regularKfkMvTxt.Text;
            bloodObj.Leucocytes = regularBloodLeucoTxt.Text;
            bloodObj.Platelets = regularTrombocytesTxt.Text;
            bloodObj.Potassium = regularPotassiumTxt.Text;
            bloodObj.Protein = regularProreinTxt.Text;
            bloodObj.Schf = regularSchfTxt.Text;
            bloodObj.Sodium = regularSodiumTxt.Text;
            bloodObj.Srp = regularSrbTxt.Text;
            return bloodObj;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtBloodAnalysis)
            {
                DdtBloodAnalysis blood = (DdtBloodAnalysis)obj;
                if (blood.AnalysisDate > DateTime.MinValue)
                {
                    regularBloodDateTxt.Value = blood.AnalysisDate;
                }
                regularAltTxt.Text = blood.Alt;
                regularAmilazaTzt.Text = blood.Amylase;
                regularAstTxt.Text = blood.Ast;
                regularBilTxt.Text = blood.Bil;
                regularChloriumTxt.Text = blood.Chlorine;
                regularCholesterolTxt.Text = blood.Cholesterol;
                regularKreatininTxt.Text = blood.Creatinine;
                regularHemoglobinTxt.Text = blood.Hemoglobin;
                regularIronTxt.Text = blood.Iron;
                regularKfkTxt.Text = blood.Kfk;
                regularKfkMvTxt.Text = blood.KfkMv;
                regularBloodLeucoTxt.Text = blood.Leucocytes;
                regularTrombocytesTxt.Text = blood.Platelets;
                regularPotassiumTxt.Text = blood.Potassium;
                regularProreinTxt.Text = blood.Protein;
                regularSchfTxt.Text = blood.Schf;
                regularSodiumTxt.Text = blood.Sodium;
                regularSrbTxt.Text = blood.Srp;
                objectId = blood.ObjectId;
                isNew = string.IsNullOrEmpty(blood.ObjectId);
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

        private void hide_Click(object sender, EventArgs e)
        {
            container?.RemoveControl(this, DdtBloodAnalysis.NAME);
        }

    }
}
