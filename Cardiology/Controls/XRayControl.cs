using System.Windows.Forms;
using Cardiology.Model;
using Cardiology.Utils;

namespace Cardiology.Controls
{
    public partial class XRayControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;

        public XRayControl(string objectId, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtXRay xRay = service.queryObjectById<DdtXRay>(DdtXRay.TABLE_NAME, objectId);
            if (xRay != null)
            {
                ktDateTxt.Value = xRay.DsdtAnalysisDate;
                ktTimeTxt.Value = xRay.DsdtAnalysisDate;
                chestXRayTxt.Text = xRay.DssChestXray;
                controlRadiographyTxt.Text = xRay.DssControlRadiography;
                ktTxt.Text = xRay.DssKt;
                mrtTxt.Text = xRay.DssMrt;
            }
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
            if (isEditable)
            {
                DataService service = new DataService();
                DdtXRay xRay = service.queryObjectById<DdtXRay>(DdtXRay.TABLE_NAME, objectId);
                if (xRay == null)
                {
                    xRay = new DdtXRay();
                    xRay.DsidHospitalitySession = hospitalitySession.ObjectId;
                    xRay.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    xRay.DsidPatient = hospitalitySession.DsidPatient;
                }
                xRay.DssChestXray = chestXRayTxt.Text;
                xRay.DssControlRadiography = controlRadiographyTxt.Text;
                xRay.DssKt = ktTxt.Text;
                xRay.DssMrt = mrtTxt.Text;
                xRay.DssParentType = parentType;
                xRay.DsidParent = parentId;
                xRay.DsdtAnalysisDate = CommonUtils.constructDateWIthTime(ktDateTxt.Value, ktTimeTxt.Value);
                objectId = service.updateOrCreateIfNeedObject<DdtXRay>(xRay, DdtXRay.TABLE_NAME, xRay.ObjectId);
            }
        }

        public bool getIsValid()
        {
            return true;
        }
    }
}
