using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class UrineAnalysisControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;

        public UrineAnalysisControl() : this(null, false)
        { }

        public UrineAnalysisControl(string objectId, bool additional)
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

            DdtUrineAnalysis urineAnalysis = service.queryObjectById<DdtUrineAnalysis>(objectId);
            refreshObject(urineAnalysis);
            dateUrineAnalysis.Enabled = isEditable;
            colorTxt.ReadOnly = !isEditable;
            erythrocytesTxt.ReadOnly = !isEditable;
            leukocytesTxt.ReadOnly = !isEditable;
            proteinTxt.ReadOnly = !isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isNew && getIsValid() || isDirty()))
            {
    
                DdtUrineAnalysis urine = (DdtUrineAnalysis)getObject();
                urine.DsidHospitalitySession = hospitalitySession.ObjectId;
                urine.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                urine.DsidPatient = hospitalitySession.DsidPatient;
                if (parentId != null)
                {
                    urine.DsidParent = parentId;
                }
                if (parentType != null)
                {
                    urine.DssParentType = parentType;
                }
                objectId = service.updateOrCreateIfNeedObject<DdtUrineAnalysis>(urine, DdtUrineAnalysis.NAME, urine.ObjectId);
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
            return !string.IsNullOrEmpty(proteinTxt.Text) || !string.IsNullOrEmpty(erythrocytesTxt.Text)
                || !string.IsNullOrEmpty(leukocytesTxt.Text) || !string.IsNullOrEmpty(colorTxt.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {

            DdtUrineAnalysis urine = service.queryObjectById<DdtUrineAnalysis>(objectId);
            if (urine == null)
            {
                urine = new DdtUrineAnalysis();
            }
            urine.DsdtAnalysisDate = dateUrineAnalysis.Value;
            urine.DssColor = colorTxt.Text;
            urine.DssLeukocytes = leukocytesTxt.Text;
            urine.DssErythrocytes = erythrocytesTxt.Text;
            urine.DssProtein = proteinTxt.Text;
            return urine;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtUrineAnalysis)
            {
                DdtUrineAnalysis urineAnalysis = (DdtUrineAnalysis)obj;
                dateUrineAnalysis.Value = urineAnalysis.DsdtAnalysisDate;
                colorTxt.Text = urineAnalysis.DssColor;
                erythrocytesTxt.Text = urineAnalysis.DssErythrocytes;
                leukocytesTxt.Text = urineAnalysis.DssLeukocytes;
                proteinTxt.Text = urineAnalysis.DssProtein;
                regularAnalysisBox.Text = "Анализы за " + urineAnalysis.DsdtAnalysisDate.ToShortDateString();
                objectId = urineAnalysis.ObjectId;
                isNew = string.IsNullOrEmpty(urineAnalysis.ObjectId);
                hasChanges = false;
            }
        }

        public bool isVisible()
        {
            return true;
        }

        private void dateUrineAnalysis_ValueChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        private void ControlTxt_TextChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }
    }
}
