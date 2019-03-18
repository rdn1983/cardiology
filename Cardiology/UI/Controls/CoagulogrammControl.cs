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
                DdtCoagulogram coagulgramm = (DdtCoagulogram)getObject();
                coagulgramm.HospitalitySession = hospitalitySession.ObjectId;
                coagulgramm.Doctor = hospitalitySession.CuringDoctor;
                coagulgramm.Patient = hospitalitySession.Patient;
                objectId = DbDataService.GetService().GetDdtCoagulogramService().Save(coagulgramm);
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
            DdtCoagulogram coagulgramm = DbDataService.GetService().GetDdtCoagulogramService().GetById(objectId);
            if (coagulgramm == null)
            {
                coagulgramm = new DdtCoagulogram();
            }
            coagulgramm.AnalysisDate = admissionDateTxt.Value;
            coagulgramm.Achtv = achtvTxt.Text;
            coagulgramm.Ddimer = ddimerTxt.Text;
            coagulgramm.Mcho = mchoTxt.Text;
            return coagulgramm;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtCoagulogram)
            {
                DdtCoagulogram coagulogramm = (DdtCoagulogram)obj;
                admissionDateTxt.Value = coagulogramm.AnalysisDate;
                achtvTxt.Text = coagulogramm.Achtv;
                ddimerTxt.Text = coagulogramm.Ddimer;
                mchoTxt.Text = coagulogramm.Mcho;
                coagulogramPnl.Text = "Коагулограмма за " + coagulogramm.AnalysisDate.ToShortDateString();
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
