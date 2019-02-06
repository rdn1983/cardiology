using System.Windows.Forms;
using Cardiology.Model;
using Cardiology.Utils;

namespace Cardiology
{
    public partial class HolterControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;

        public HolterControl(string objectId, bool additional)
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
            DdtHolter holter = service.queryObjectById<DdtHolter>(objectId);
            refreshObject(holter);
            holterTxt.Enabled = isEditable;
            monitoringAdTxt.Enabled = isEditable;
            analysisDate.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isNew && getIsValid()|| isDirty()))
            {
                DataService service = new DataService();
                DdtHolter holter = (DdtHolter) getObject();
                holter.DsidHospitalitySession = hospitalitySession.ObjectId;
                holter.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                holter.DsidPatient = hospitalitySession.DsidPatient;
                if (parentId != null)
                {
                    holter.DsidParent = parentId;
                }
                if (parentType != null)
                {
                    holter.DssParentType = parentType;
                }
                objectId = service.updateOrCreateIfNeedObject<DdtHolter>(holter, DdtHolter.TABLE_NAME, holter.ObjectId);
                hasChanges = false;
                isNew = false;
                hasChanges = false;
            }
        }

        public string getObjectId()
        {
            return objectId;
        }

        public bool getIsValid()
        {
            return CommonUtils.isNotBlank(holterTxt.Text) || CommonUtils.isNotBlank(monitoringAdTxt.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {
            DataService service = new DataService();
            DdtHolter holter = service.queryObjectById<DdtHolter>(objectId);
            if (holter == null)
            {
                holter = new DdtHolter();
            }
            holter.DsdtAnalysisDate = analysisDate.Value;
            holter.DssHolter = holterTxt.Text;
            holter.DssMonitoringAd = monitoringAdTxt.Text;
            return holter;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtHolter)
            {
                DdtHolter holter = (DdtHolter)obj;
                holterTxt.Text = holter.DssHolter;
                monitoringAdTxt.Text = holter.DssMonitoringAd;
                title.Text = "Анализы за " + holter.DsdtAnalysisDate.ToShortDateString();
                analysisDate.Value = holter.DsdtAnalysisDate;
                objectId = holter.ObjectId;
                isNew = CommonUtils.isBlank(objectId);
            }
        }

        public bool isVisible()
        {
            return true;
        }

        private void holterTxt_TextChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        private void monitoringAdTxt_TextChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        private void analysisDate_ValueChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }
    }
}
