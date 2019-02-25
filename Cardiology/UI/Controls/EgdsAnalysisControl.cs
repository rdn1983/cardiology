using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class EgdsAnalysisControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;

        public EgdsAnalysisControl() : this(null, false) { }

        public EgdsAnalysisControl(string objectId, bool additional)
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
            DdtEgds egds = service.queryObjectById<DdtEgds>(objectId);
            refreshObject(egds);
            regularEgdsTxt.Enabled = isEditable;
            analysisDate.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isDirty() || isNew && getIsValid()))
            {
   
                DdtEgds egds = (DdtEgds)getObject();
                egds.HospitalitySession= hospitalitySession.ObjectId;
                egds.Doctor = hospitalitySession.CuringDoctor;
                egds.Patient = hospitalitySession.Patient;
                if (parentId != null)
                {
                    egds.Parent = parentId;
                }
                if (parentType != null)
                {
                    egds.ParentType = parentType;
                }
                objectId = service.updateOrCreateIfNeedObject(egds, DdtEgds.NAME, egds.ObjectId);
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
            return !string.IsNullOrEmpty(regularEgdsTxt.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {
            DdtEgds egds = service.queryObjectById<DdtEgds>(objectId);
            if (egds == null)
            {
                egds = new DdtEgds();
            }
            egds.AnalysisDate = analysisDate.Value;
            egds.Egds = regularEgdsTxt.Text;
            return egds;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtEgds)
            {
                DdtEgds egds = (DdtEgds)obj;
                regularEgdsTxt.Text = egds.Egds;
                analysisTitleLbl.Text = "ЭГДС за " + egds.AnalysisDate.ToShortDateString();
                analysisDate.Value = egds.AnalysisDate;
                objectId = egds.ObjectId;
                isNew = string.IsNullOrEmpty(objectId);
                hasChanges = false;
            }
        }

        public bool isVisible()
        {
            return true;
        }

        private void regularEgdsTxt_TextChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        private void analysisDate_ValueChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }
    }
}
