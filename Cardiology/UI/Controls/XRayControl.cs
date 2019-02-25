using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class XRayControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;

        public XRayControl(string objectId, bool additional)
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

            DdtXRay xRay = service.queryObjectById<DdtXRay>(objectId);
            refreshObject(xRay);
            chestXRayTxt.Enabled = isEditable;
            controlRadiographyTxt.Enabled = isEditable;
            ktTxt.Enabled = isEditable;
            mrtTxt.Enabled = isEditable;
        }

        public string getObjectId()
        {
            return objectId;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isNew && getIsValid()|| isDirty()))
            {
    
                DdtXRay xRay = (DdtXRay) getObject();
                xRay.HospitalitySession = hospitalitySession.ObjectId;
                xRay.Doctor = hospitalitySession.CuringDoctor;
                xRay.Patient = hospitalitySession.Patient;
                if (parentId != null)
                {
                    xRay.Parent = parentId;
                }
                if (parentType != null)
                {
                    xRay.ParentType = parentType;
                }
                objectId = service.updateOrCreateIfNeedObject<DdtXRay>(xRay, DdtXRay.NAME, xRay.ObjectId);
                isNew = false;
                hasChanges = false;
            }
        }

        public bool getIsValid()
        {
            return !string.IsNullOrEmpty(chestXRayTxt.Text) || !string.IsNullOrEmpty(controlRadiographyTxt.Text) ||
                !string.IsNullOrEmpty(ktTxt.Text) || !string.IsNullOrEmpty(mrtTxt.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {

            DdtXRay xRay = service.queryObjectById<DdtXRay>(objectId);
            if (xRay == null)
            {
                xRay = new DdtXRay();
            }
            xRay.DssChestXray = chestXRayTxt.Text;
            xRay.DssControlRadiography = controlRadiographyTxt.Text;
            xRay.DssKt = ktTxt.Text;
            xRay.DssMrt = mrtTxt.Text;
            xRay.DsdtAnalysisDate = CommonUtils.ConstructDateWIthTime(ktDateTxt.Value, ktTimeTxt.Value);
            return xRay;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtXRay)
            {
                DdtXRay xRay = (DdtXRay) obj;
                ktDateTxt.Value = xRay.DsdtAnalysisDate;
                ktTimeTxt.Value = xRay.DsdtAnalysisDate;
                chestXRayTxt.Text = xRay.DssChestXray;
                controlRadiographyTxt.Text = xRay.DssControlRadiography;
                ktTxt.Text = xRay.DssKt;
                mrtTxt.Text = xRay.DssMrt;
                objectId = xRay.ObjectId;
                isNew = string.IsNullOrEmpty(objectId);
                hasChanges = false;
            }
        }

        public bool isVisible()
        {
            return true;
        }

        private void ktDateTxt_ValueChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        private void ControlTxt_TextChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }
    }
}
