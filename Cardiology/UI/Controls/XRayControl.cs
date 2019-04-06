using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class XRayControl : UserControl, IDocbaseControl
    {
        private readonly IDbDataService service;
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;

        public XRayControl(string objectId, bool additional)
        {
            this.service = DbDataService.GetInstance();
            this.objectId = objectId;
            this.isEditable = !additional;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        private void initControls()
        {

            DdtXRay xRay = service.GetDdtXrayService().GetById(objectId);
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
            if (isEditable && (isNew && getIsValid() || isDirty()))
            {

                DdtXRay xRay = (DdtXRay)getObject();
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

                objectId = service.GetDdtXrayService().Save(xRay);
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

            DdtXRay xRay = service.GetDdtXrayService().GetById(objectId);
            if (xRay == null)
            {
                xRay = new DdtXRay();
            }
            xRay.ChestXray = chestXRayTxt.Text;
            xRay.ControlRadiography = controlRadiographyTxt.Text;
            xRay.Kt = ktTxt.Text;
            xRay.Mrt = mrtTxt.Text;
            xRay.AnalysisDate = CommonUtils.ConstructDateWIthTime(ktDateTxt.Value, ktTimeTxt.Value);
            return xRay;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtXRay)
            {
                DdtXRay xRay = (DdtXRay)obj;
                ktDateTxt.Value = xRay.AnalysisDate;
                ktTimeTxt.Value = xRay.AnalysisDate;
                chestXRayTxt.Text = xRay.ChestXray;
                controlRadiographyTxt.Text = xRay.ControlRadiography;
                ktTxt.Text = xRay.Kt;
                mrtTxt.Text = xRay.Mrt;
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
