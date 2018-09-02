using System.Windows.Forms;
using Cardiology.Model;

namespace Cardiology
{
    public partial class HolterControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;

        public HolterControl(string objectId, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtHolter holter = service.queryObjectById<DdtHolter>(DdtHolter.TABLE_NAME, objectId);
            if (holter != null)
            {
                holterTxt.Text = holter.DssHolter + "";
                monitoringAdTxt.Text = holter.DssMonitoringAd + "";
                title.Text = "Анализы за " + holter.RCreationDate.ToShortDateString();
            }
            holterTxt.Enabled = isEditable;
            monitoringAdTxt.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable)
            {
                DataService service = new DataService();
                DdtHolter holter = service.queryObjectById<DdtHolter>(DdtHolter.TABLE_NAME, objectId);
                if (holter == null)
                {
                    holter = new DdtHolter();
                    holter.DsidHospitalitySession = hospitalitySession.ObjectId;
                    holter.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    holter.DsidPatient = hospitalitySession.DsidPatient;
                }
                holter.DssHolter = holterTxt.Text;
                holter.DssMonitoringAd = monitoringAdTxt.Text;
                holter.DssParentType = parentType;
                holter.DsidParent = parentId;
                objectId = service.updateOrCreateIfNeedObject<DdtHolter>(holter, DdtHolter.TABLE_NAME, holter.ObjectId);
            }
        }

        public string getObjectId()
        {
            return objectId;
        }
    }
}
