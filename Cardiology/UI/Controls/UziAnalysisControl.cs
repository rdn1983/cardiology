using System.Windows.Forms;
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

            DdtUzi uzi = DbDataService.GetService().GetDdtUziService().GetById(objectId);
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

                DdtUzi uziObj = (DdtUzi)getObject();
                uziObj.HospitalitySession = hospitalitySession.ObjectId;
                uziObj.Doctor = hospitalitySession.CuringDoctor;
                uziObj.Patient = hospitalitySession.Patient;
                if (parentId != null)
                {
                    uziObj.Parent = parentId;
                }
                if (parentType != null)
                {
                    uziObj.ParentType = parentType;
                }

                objectId = DbDataService.GetService().GetDdtUziService().Save(uziObj);
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

            DdtUzi uziObj = DbDataService.GetService().GetDdtUziService().GetById(objectId);
            if (uziObj == null)
            {
                uziObj = new DdtUzi();
            }
            uziObj.AnalysisDate = analysisDate.Value;
            uziObj.EhoKg = ehoKgTxt.Text;
            uziObj.UzdBca = uzdTxt.Text;
            uziObj.Cds = cdsTxt.Text;
            uziObj.UziObp = uziObpTxt.Text;
            uziObj.PleursUzi = pleursUziTxt.Text;
            return uziObj;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtUzi)
            {
                DdtUzi uzi = (DdtUzi)obj;
                ehoKgTxt.Text = uzi.EhoKg;
                uzdTxt.Text = uzi.UzdBca;
                cdsTxt.Text = uzi.Cds;
                uziObpTxt.Text = uzi.UziObp;
                pleursUziTxt.Text = uzi.PleursUzi;
                title.Text = "УЗИ за " + uzi.AnalysisDate.ToShortDateString();
                analysisDate.Value = uzi.AnalysisDate;
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
