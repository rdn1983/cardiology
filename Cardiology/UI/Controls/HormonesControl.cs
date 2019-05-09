using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class HormonesControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;
        private IAnalysisContainer acontainer;

        public HormonesControl(string objectId, bool additional) : this(objectId, null, additional) { }

        public HormonesControl(string objectId, IAnalysisContainer container, bool isAddit)
        {
            this.objectId = objectId;
            this.isEditable = !isAddit;
            this.acontainer = container;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        private void initControls()
        {
            DdtHormones hormones = DbDataService.GetInstance().GetDdtHormonesService().GetById(objectId);
            refreshObject(hormones);
            admissionDateTxt.Enabled = isEditable;
            t4Txt.Enabled = isEditable;
            ttgTxt.Enabled = isEditable;
            t3Txt.Enabled = isEditable;
        }

        public string getObjectId()
        {
            return objectId;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isNew && getIsValid() || isDirty()))
            {
    
                DdtHormones hormones = (DdtHormones) getObject();
                hormones.HospitalitySession = hospitalitySession.ObjectId;
                hormones.Doctor = hospitalitySession.CuringDoctor;
                hormones.Patient = hospitalitySession.Patient;
                objectId = DbDataService.GetInstance().GetDdtHormonesService().Save(hormones);
                isNew = false;
                hasChanges = false;
            }
        }

        public bool getIsValid()
        {
            return !string.IsNullOrEmpty(t3Txt.Text) || !string.IsNullOrEmpty(t4Txt.Text) || !string.IsNullOrEmpty(ttgTxt.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {

            DdtHormones hormones = DbDataService.GetInstance().GetDdtHormonesService().GetById(objectId);
            if (hormones == null)
            {
                hormones = new DdtHormones();
            }
            hormones.AnalysisDate = admissionDateTxt.Value;
            hormones.T3 = t3Txt.Text;
            hormones.T4 = t4Txt.Text;
            hormones.Ttg = ttgTxt.Text;
            return hormones;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtHormones)
            {
                DdtHormones hormones = (DdtHormones)obj;
                admissionDateTxt.Value = hormones.AnalysisDate;
                t4Txt.Text = hormones.T4;
                ttgTxt.Text = hormones.Ttg;
                t3Txt.Text = hormones.T3;
                hormonesPnl.Text = "Гормоны за " + hormones.AnalysisDate.ToShortDateString();
                objectId = hormones.ObjectId;
                isNew = string.IsNullOrEmpty(objectId);
                hasChanges = false;
            }
        }

        public bool isVisible()
        {
            return true;
        }

        private void controlTxt_TextChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        private void admissionDateTxt_ValueChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        private void hide_Click(object sender, System.EventArgs e)
        {
            acontainer?.RemoveControl(this, DdtHormones.NAME);
        }
    }
}
