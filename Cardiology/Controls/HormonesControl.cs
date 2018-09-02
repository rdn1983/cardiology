using System.Windows.Forms;
using Cardiology.Model;

namespace Cardiology.Controls
{
    public partial class HormonesControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;

        public HormonesControl(string objectId, bool isAddit)
        {
            this.objectId = objectId;
            this.isEditable = !isAddit;
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtHormones hormones = service.queryObjectById<DdtHormones>(DdtHormones.TABLE_NAME, objectId);
            if (hormones != null)
            {
                admissionDateTxt.Value = hormones.DsdtAnalysisDate;
                t4Txt.Text = hormones.DssT4;
                ttgTxt.Text = hormones.DssTtg;
                t3Txt.Text = hormones.DssT3;
            }
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
            if (isEditable)
            {
                DataService service = new DataService();
                DdtHormones hormones = service.queryObjectById<DdtHormones>(DdtHormones.TABLE_NAME, objectId);
                if (hormones == null)
                {
                    hormones = new DdtHormones();
                    hormones.DsidHospitalitySession = hospitalitySession.ObjectId;
                    hormones.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    hormones.DsidPatient = hospitalitySession.DsidPatient;
                }
                hormones.DsdtAnalysisDate = admissionDateTxt.Value;
                hormones.DssT3 = t3Txt.Text;
                hormones.DssT4 = t4Txt.Text;
                hormones.DssTtg = ttgTxt.Text;
                objectId = service.updateOrCreateIfNeedObject<DdtHormones>(hormones, DdtHormones.TABLE_NAME, hormones.RObjectId);
            }
        }

    }
}
