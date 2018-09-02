using System.Windows.Forms;
using Cardiology.Model;

namespace Cardiology.Controls
{
    public partial class CoagulogrammControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;

        public CoagulogrammControl(string objectId, bool isAddit)
        {
            this.objectId = objectId;
            this.isEditable = !isAddit;
            InitializeComponent();
            initControls();
        }

        public string getObjectId()
        {
            return objectId;
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtCoagulogram coagulogramm = service.queryObjectById<DdtCoagulogram>(DdtCoagulogram.TABLE_NAME, objectId);
            if (coagulogramm != null)
            {
                admissionDateTxt.Value = coagulogramm.DsdtAnalysisDate;
                achtvTxt.Text = coagulogramm.DssAchtv;
                ddimerTxt.Text = coagulogramm.DssDdimer;
                mchoTxt.Text = coagulogramm.DssMcho;
            }
            admissionDateTxt.Enabled = isEditable;
            achtvTxt.Enabled = isEditable;
            ddimerTxt.Enabled = isEditable;
            mchoTxt.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable)
            {
                DataService service = new DataService();
                DdtCoagulogram coagulgramm = service.queryObjectById<DdtCoagulogram>(DdtCoagulogram.TABLE_NAME, objectId);
                if (coagulgramm == null)
                {
                    coagulgramm = new DdtCoagulogram();
                    coagulgramm.DsidHospitalitySession = hospitalitySession.ObjectId;
                    coagulgramm.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    coagulgramm.DsidPatient = hospitalitySession.DsidPatient;
                }
                coagulgramm.DsdtAnalysisDate = admissionDateTxt.Value;
                coagulgramm.DssAchtv = achtvTxt.Text;
                coagulgramm.DssDdimer = ddimerTxt.Text;
                coagulgramm.DssMcho = mchoTxt.Text;
                objectId = service.updateOrCreateIfNeedObject<DdtCoagulogram>(coagulgramm, DdtCoagulogram.TABLE_NAME, coagulgramm.RObjectId);
            }
        }
    }
}
