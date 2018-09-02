using System.Windows.Forms;
using Cardiology.Model;

namespace Cardiology
{
    public partial class UziAnalysisControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;

        public UziAnalysisControl(string objectId, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtUzi uzi = service.queryObjectById<DdtUzi>(DdtUzi.TABLE_NAME, objectId);
            if (uzi != null)
            {
                ehoKgTxt.Text = uzi.DssEhoKg;
                uzdTxt.Text = uzi.DssUzdBca;
                cdsTxt.Text = uzi.DssCds;
                uziObpTxt.Text = uzi.DssUziObp;
                pleursUziTxt.Text = uzi.DssPleursUzi;
                title.Text = "Анализы за " + uzi.RCreationDate.ToShortDateString();
            }
            ehoKgTxt.Enabled = isEditable;
            uzdTxt.Enabled = isEditable;
            cdsTxt.Enabled = isEditable;
            uziObpTxt.Enabled = isEditable;
            pleursUziTxt.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable)
            {
                DataService service = new DataService();
                DdtUzi uziObj = service.queryObjectById<DdtUzi>(DdtUzi.TABLE_NAME, objectId);
                if (uziObj == null)
                {
                    uziObj = new DdtUzi();
                    uziObj.DsidHospitalitySession = hospitalitySession.ObjectId;
                    uziObj.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    uziObj.DsidPatient = hospitalitySession.DsidPatient;
                }
                uziObj.DssEhoKg = ehoKgTxt.Text;
                uziObj.DssUzdBca = uzdTxt.Text;
                uziObj.DssCds = cdsTxt.Text;
                uziObj.DssUziObp = uziObpTxt.Text;
                uziObj.DssPleursUzi = pleursUziTxt.Text;
                uziObj.DssParentType = parentType;
                uziObj.DsidParent = parentId;
                objectId = service.updateOrCreateIfNeedObject<DdtUzi>(uziObj, DdtUzi.TABLE_NAME, uziObj.ObjectId);
            }
        }

        public string getObjectId()
        {
            return objectId;
        }
    }
}
