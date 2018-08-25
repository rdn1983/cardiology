using System.Windows.Forms;
using Cardiology.Model;

namespace Cardiology
{
    public partial class EgdsAnalysisControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;

        public EgdsAnalysisControl(string objectId, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtEgds egds = service.queryObjectById<DdtEgds>(DdtEgds.TABLE_NAME, objectId);
            if (egds != null)
            {
                regularEgdsTxt.Text = egds.DssEgds;
                regularEgdsBox.Text = "Контрольное исследование" + egds.RCreationDate.ToShortDateString();
            }
            regularEgdsTxt.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession)
        {
            if (isEditable)
            {
                DataService service = new DataService();
                DdtEgds egds = service.queryObjectById<DdtEgds>(DdtEgds.TABLE_NAME, objectId);
                if (egds == null)
                {
                    egds = new DdtEgds();
                    egds.DsidHospitalitySession = hospitalitySession.ObjectId;
                    egds.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    egds.DsidPatient = hospitalitySession.DsidPatient;
                }
                egds.DssEgds = regularEgdsTxt.Text;
                objectId = service.updateOrCreateIfNeedObject<DdtEgds>(egds, DdtEgds.TABLE_NAME, egds.ObjectId);
            }
        }

        public string getObjectId()
        {
            return objectId;
        }
    }
}
