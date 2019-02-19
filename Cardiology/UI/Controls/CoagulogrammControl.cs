using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class CoagulogrammControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;

        public CoagulogrammControl() : this(null, false) { }

        public CoagulogrammControl(string objectId, bool isAddit)
        {
            this.objectId = objectId;
            this.isEditable = !isAddit;
            InitializeComponent();
            InitControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        private void InitControls()
        {
            DdtCoagulogram coagulogramm = (DdtCoagulogram)getObject();
            refreshObject(coagulogramm);
            admissionDateTxt.Enabled = isEditable;
            achtvTxt.Enabled = isEditable;
            ddimerTxt.Enabled = isEditable;
            mchoTxt.Enabled = isEditable;
        }

        public string getObjectId()
        {
            return objectId;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isDirty() || isNew && getIsValid()))
            {
                DataService service = new DataService();
                DdtCoagulogram coagulgramm = (DdtCoagulogram)getObject();
                coagulgramm.DsidHospitalitySession = hospitalitySession.ObjectId;
                coagulgramm.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                coagulgramm.DsidPatient = hospitalitySession.DsidPatient;
                objectId = service.updateOrCreateIfNeedObject<DdtCoagulogram>(coagulgramm, DdtCoagulogram.NAME, coagulgramm.ObjectId);
                hasChanges = false;
                isNew = false;
            }
        }

        public bool getIsValid()
        {
            return !string.IsNullOrEmpty(achtvTxt.Text) || !string.IsNullOrEmpty(ddimerTxt.Text) || !string.IsNullOrEmpty(mchoTxt.Text);
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            hasChanges = true;
        }

        private void admissionDateTxt_ValueChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {
            DataService service = new DataService();
            DdtCoagulogram coagulgramm = service.queryObjectById<DdtCoagulogram>(objectId);
            if (coagulgramm == null)
            {
                coagulgramm = new DdtCoagulogram();
            }
            coagulgramm.DsdtAnalysisDate = admissionDateTxt.Value;
            coagulgramm.DssAchtv = achtvTxt.Text;
            coagulgramm.DssDdimer = ddimerTxt.Text;
            coagulgramm.DssMcho = mchoTxt.Text;
            return coagulgramm;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtCoagulogram)
            {
                DdtCoagulogram coagulogramm = (DdtCoagulogram)obj;
                admissionDateTxt.Value = coagulogramm.DsdtAnalysisDate;
                achtvTxt.Text = coagulogramm.DssAchtv;
                ddimerTxt.Text = coagulogramm.DssDdimer;
                mchoTxt.Text = coagulogramm.DssMcho;
                coagulogramPnl.Text = "Коагулограмма за " + coagulogramm.DsdtAnalysisDate.ToShortDateString();
                objectId = coagulogramm.ObjectId;
                isNew = string.IsNullOrEmpty(objectId);
                hasChanges = false;
            }
        }

        public bool isVisible()
        {
            return true;
        }
    }
}
