using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Commons;

namespace Cardiology.Controls
{
    public partial class HormonesControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;

        public HormonesControl(string objectId, bool isAddit)
        {
            this.objectId = objectId;
            this.isEditable = !isAddit;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = CommonUtils.isBlank(objectId);
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtHormones hormones = service.queryObjectById<DdtHormones>(objectId);
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
                DataService service = new DataService();
                DdtHormones hormones = (DdtHormones) getObject();
                hormones.DsidHospitalitySession = hospitalitySession.ObjectId;
                hormones.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                hormones.DsidPatient = hospitalitySession.DsidPatient;
                objectId = service.updateOrCreateIfNeedObject<DdtHormones>(hormones, DdtHormones.TABLE_NAME, hormones.RObjectId);
                isNew = false;
                hasChanges = false;
            }
        }

        public bool getIsValid()
        {
            return CommonUtils.isNotBlank(t3Txt.Text) || CommonUtils.isNotBlank(t4Txt.Text) || CommonUtils.isNotBlank(ttgTxt.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {
            DataService service = new DataService();
            DdtHormones hormones = service.queryObjectById<DdtHormones>(objectId);
            if (hormones == null)
            {
                hormones = new DdtHormones();
            }
            hormones.DsdtAnalysisDate = admissionDateTxt.Value;
            hormones.DssT3 = t3Txt.Text;
            hormones.DssT4 = t4Txt.Text;
            hormones.DssTtg = ttgTxt.Text;
            return hormones;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtHormones)
            {
                DdtHormones hormones = (DdtHormones)obj;
                admissionDateTxt.Value = hormones.DsdtAnalysisDate;
                t4Txt.Text = hormones.DssT4;
                ttgTxt.Text = hormones.DssTtg;
                t3Txt.Text = hormones.DssT3;
                hormonesPnl.Text = "Гормоны за " + hormones.DsdtAnalysisDate.ToShortDateString();
                objectId = hormones.RObjectId;
                isNew = CommonUtils.isBlank(objectId);
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
    }
}
