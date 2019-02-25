using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class UziAnalysisControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;

        public UziAnalysisControl(string objectId, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        private void initControls()
        {

            DdtUzi uzi = service.queryObjectById<DdtUzi>(objectId);
            refreshObject(uzi);
            ehoKgTxt.Enabled = isEditable;
            uzdTxt.Enabled = isEditable;
            cdsTxt.Enabled = isEditable;
            uziObpTxt.Enabled = isEditable;
            pleursUziTxt.Enabled = isEditable;
            analysisDate.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isNew && getIsValid() || isDirty()))
            {
    
                DdtUzi uziObj = (DdtUzi) getObject();
                uziObj.DsidHospitalitySession = hospitalitySession.ObjectId;
                uziObj.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                uziObj.Patient = hospitalitySession.Patient;
                if (parentId != null)
                {
                    uziObj.DsidParent = parentId;
                }
                if (parentType != null)
                {
                    uziObj.DssParentType = parentType;
                }
                objectId = service.updateOrCreateIfNeedObject<DdtUzi>(uziObj, DdtUzi.NAME, uziObj.ObjectId);
                isNew = false;
                hasChanges = false;
            }
        }

        public string getObjectId()
        {
            return objectId;
        }

        public bool getIsValid()
        {
            return !string.IsNullOrEmpty(ehoKgTxt.Text) || !string.IsNullOrEmpty(uzdTxt.Text) ||
                !string.IsNullOrEmpty(cdsTxt.Text) || !string.IsNullOrEmpty(uziObpTxt.Text) ||
                !string.IsNullOrEmpty(pleursUziTxt.Text);
        }

        private void analysisDate_ValueChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {

            DdtUzi uziObj = service.queryObjectById<DdtUzi>(objectId);
            if (uziObj == null)
            {
                uziObj = new DdtUzi();
            }
            uziObj.DsdtAnalysisDate = analysisDate.Value;
            uziObj.DssEhoKg = ehoKgTxt.Text;
            uziObj.DssUzdBca = uzdTxt.Text;
            uziObj.DssCds = cdsTxt.Text;
            uziObj.DssUziObp = uziObpTxt.Text;
            uziObj.DssPleursUzi = pleursUziTxt.Text;
            return uziObj;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtUzi)
            {
                DdtUzi uzi = (DdtUzi)obj;
                ehoKgTxt.Text = uzi.DssEhoKg;
                uzdTxt.Text = uzi.DssUzdBca;
                cdsTxt.Text = uzi.DssCds;
                uziObpTxt.Text = uzi.DssUziObp;
                pleursUziTxt.Text = uzi.DssPleursUzi;
                title.Text = "УЗИ за " + uzi.DsdtAnalysisDate.ToShortDateString();
                analysisDate.Value = uzi.DsdtAnalysisDate;
                objectId = uzi.ObjectId;
                isNew = string.IsNullOrEmpty(objectId);
                hasChanges = false;
            }
        }

        public bool isVisible()
        {
            return true;
        }

        private void ControlTxt_TextChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }
    }
}
