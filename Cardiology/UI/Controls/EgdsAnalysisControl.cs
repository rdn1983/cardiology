using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Commons;

namespace Cardiology
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
            isNew = CommonUtils.isBlank(objectId);
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtEgds egds = service.queryObjectById<DdtEgds>(objectId);
            refreshObject(egds);
            regularEgdsTxt.Enabled = isEditable;
            analysisDate.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isDirty() || isNew && getIsValid()))
            {
                DataService service = new DataService();
                DdtEgds egds = (DdtEgds)getObject();
                egds.DsidHospitalitySession = hospitalitySession.ObjectId;
                egds.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                egds.DsidPatient = hospitalitySession.DsidPatient;
                if (parentId != null)
                {
                    egds.DsidParent = parentId;
                }
                if (parentType != null)
                {
                    egds.DssParentType = parentType;
                }
                objectId = service.updateOrCreateIfNeedObject<DdtEgds>(egds, DdtEgds.TABLE_NAME, egds.ObjectId);
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
            return CommonUtils.isNotBlank(regularEgdsTxt.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {
            DataService service = new DataService();
            DdtEgds egds = service.queryObjectById<DdtEgds>(objectId);
            if (egds == null)
            {
                egds = new DdtEgds();
            }
            egds.DsdtAnalysisDate = analysisDate.Value;
            egds.DssEgds = regularEgdsTxt.Text;
            return egds;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtEgds)
            {
                DdtEgds egds = (DdtEgds)obj;
                regularEgdsTxt.Text = egds.DssEgds;
                analysisTitleLbl.Text = "ЭГДС за " + egds.DsdtAnalysisDate.ToShortDateString();
                analysisDate.Value = egds.DsdtAnalysisDate;
                objectId = egds.ObjectId;
                isNew = CommonUtils.isBlank(objectId);
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
