using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model;

namespace Cardiology.UI.Controls
{
    public partial class KagAnalysisControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private string hospitalSessionId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;

        public KagAnalysisControl(string objectId, bool additional, string hospitalSessionId)
        {
            this.objectId = objectId;
            this.hospitalSessionId = hospitalSessionId;
            this.isEditable = !additional;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = CommonUtils.isBlank(objectId);
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtKag kag = service.queryObjectById<DdtKag>(objectId);
            refreshObject(kag);
            kagResultsTxt.Enabled = isEditable;
            kagManipulationTxt.Enabled = isEditable;
            kagActionsTxt.Enabled = isEditable;
            kagDate.Enabled = isEditable;
            kagStartTime.Enabled = isEditable;
            kagEndTime.Enabled = isEditable;
            showBlanksBtn.Visible = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isNew || isDirty()))
            {
                DataService service = new DataService();
                DdtKag kag = (DdtKag)getObject();
                kag.DsidHospitalitySession = hospitalitySession.ObjectId;
                kag.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                kag.DsidPatient = hospitalitySession.DsidPatient;
                if (parentId != null)
                {
                    kag.DsidParent = parentId;
                }
                if (parentType != null)
                {
                    kag.DssParentType = parentType;
                }

                objectId = service.updateOrCreateIfNeedObject<DdtKag>(kag, DdtKag.TABLE_NAME, kag.ObjectId);
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
            return CommonUtils.isNotBlank(kagResultsTxt.Text) || CommonUtils.isNotBlank(kagManipulationTxt.Text) || CommonUtils.isNotBlank(kagActionsTxt.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {
            DataService service = new DataService();
            DdtKag kag = service.queryObjectById<DdtKag>(objectId);
            if (kag == null)
            {
                kag = new DdtKag();
            }
            kag.DssKagManipulation = kagManipulationTxt.Text;
            kag.DssResults = kagResultsTxt.Text;
            kag.DssKagAction = kagActionsTxt.Text;
            kag.DsdtStartTime = CommonUtils.constructDateWIthTime(kagDate.Value, kagStartTime.Value);
            kag.DsdtAnalysisDate = CommonUtils.constructDateWIthTime(kagDate.Value, kagStartTime.Value);
            kag.DsdtEndTime = CommonUtils.constructDateWIthTime(kagDate.Value, kagEndTime.Value);
            return kag;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtKag)
            {
                DdtKag kag = (DdtKag)obj;
                kagResultsTxt.Text = kag.DssResults;
                kagManipulationTxt.Text = kag.DssKagManipulation;
                kagActionsTxt.Text = kag.DssKagAction;
                DateTime startTime = kag.DsdtStartTime == default(DateTime) ? DateTime.Now : kag.DsdtStartTime;
                kagDate.Value = startTime;
                kagStartTime.Value = startTime;
                kagEndTime.Value = kag.DsdtEndTime == default(DateTime) ? startTime.AddHours(1) : kag.DsdtEndTime;
                title.Text = "Анализы за " + kag.RCreationDate.ToShortDateString();
                objectId = kag.ObjectId;
                isNew = CommonUtils.isBlank(objectId);
                hasChanges = false;
            }
            else
            {
                DataService service = new DataService();
                DdtHospital hospitalitySession = service.queryObjectById<DdtHospital>(hospitalSessionId);
                DateTime admissionDate = hospitalitySession.DsdtAdmissionDate;
                kagDate.Value = admissionDate;
                kagStartTime.Value = admissionDate.AddMinutes(30);
                kagEndTime.Value = kagStartTime.Value.AddHours(1);
            }
        }

        public bool isVisible()
        {
            return true;
        }

        #region controls_behaviour

        private void kagStartTime_ValueChanged(object sender, EventArgs e)
        {
            if (kagStartTime.Value != default(DateTime))
            {
                kagEndTime.Value = kagStartTime.Value.AddHours(1);
                hasChanges = true;
            }
        }

        private void showBlanksBtn_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseArgs = e as MouseEventArgs;
            blanksMenu.Show(showBlanksBtn, mouseArgs.Location);
        }

        private void procedureConsentBlank_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            TemplatesUtils.fillBlankTemplate("blank_kag_template.doc", hospitalSessionId, values);
        }

        private void dataProcessingBlank_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            TemplatesUtils.fillBlankTemplate("blank_common_consent_template.doc", hospitalSessionId, values);
        }

        private void anesthesiaBlank_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("{time}", DateTime.Now.ToShortTimeString());
            TemplatesUtils.fillBlankTemplate("blank_anastesia_template.doc", hospitalSessionId, values);
        }

        private void kagDate_ValueChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        private void ControlTxt_TextChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }
        #endregion
    }
}
