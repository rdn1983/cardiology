using System.Windows.Forms;
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
        private IAnalysisContainer container;

        public UrineAnalysisControl(string objectId, bool additional) : this(objectId, null, additional) { }

        public UrineAnalysisControl(string objectId, IAnalysisContainer container, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            this.container = container;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        private void initControls()
        {
            DdtUrineAnalysis urineAnalysis = DbDataService.GetInstance().GetDdtUrineAnalysisService().GetById(objectId);
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
                urine.HospitalitySession = hospitalitySession.ObjectId;
                urine.Doctor = hospitalitySession.CuringDoctor;
                urine.Patient = hospitalitySession.Patient;
                if (parentId != null)
                {
                    urine.Parent = parentId;
                }
                if (parentType != null)
                {
                    urine.ParentType = parentType;
                }

                objectId = DbDataService.GetInstance().GetDdtUrineAnalysisService().Save(urine);
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

            DdtUrineAnalysis urine = DbDataService.GetInstance().GetDdtUrineAnalysisService().GetById(objectId);
            if (urine == null)
            {
                urine = new DdtUrineAnalysis();
            }
            urine.AnalysisDate = dateUrineAnalysis.Value;
            urine.Color = colorTxt.Text;
            urine.Leukocytes = leukocytesTxt.Text;
            urine.Erythrocytes = erythrocytesTxt.Text;
            urine.Protein = proteinTxt.Text;
            return urine;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtUrineAnalysis)
            {
                DdtUrineAnalysis urineAnalysis = (DdtUrineAnalysis)obj;
                dateUrineAnalysis.Value = urineAnalysis.AnalysisDate;
                colorTxt.Text = urineAnalysis.Color;
                erythrocytesTxt.Text = urineAnalysis.Erythrocytes;
                leukocytesTxt.Text = urineAnalysis.Leukocytes;
                proteinTxt.Text = urineAnalysis.Protein;
                regularAnalysisBox.Text = "Анализы за " + urineAnalysis.AnalysisDate.ToShortDateString();
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

        private void hide_Click(object sender, System.EventArgs e)
        {
            container?.RemoveControl(this, DdtUrineAnalysis.NAME);
        }
    }
}
