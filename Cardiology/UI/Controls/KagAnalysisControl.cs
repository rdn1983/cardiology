using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

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
            InitControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        private void InitControls()
        {
            DdtKag kag = DbDataService.GetInstance().GetDdtKagService().GetById(objectId);
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
    
                DdtKag kag = (DdtKag)getObject();
                kag.HospitalitySession = hospitalitySession.ObjectId;
                kag.Doctor = hospitalitySession.CuringDoctor;
                kag.Patient = hospitalitySession.Patient;
                if (parentId != null)
                {
                    kag.Parent = parentId;
                }
                if (parentType != null)
                {
                    kag.ParentType = parentType;
                }

                objectId = DbDataService.GetInstance().GetDdtKagService().Save(kag);
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
            return !string.IsNullOrEmpty(kagResultsTxt.Text) || !string.IsNullOrEmpty(kagManipulationTxt.Text) || !string.IsNullOrEmpty(kagActionsTxt.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {

            DdtKag kag = DbDataService.GetInstance().GetDdtKagService().GetById(objectId);
            if (kag == null)
            {
                kag = new DdtKag();
            }
            kag.KagManipulation = kagManipulationTxt.Text;
            kag.Results = kagResultsTxt.Text;
            kag.KagAction = kagActionsTxt.Text;
            kag.StartTime = CommonUtils.ConstructDateWIthTime(kagDate.Value, kagStartTime.Value);
            kag.AnalysisDate = CommonUtils.ConstructDateWIthTime(kagDate.Value, kagStartTime.Value);
            kag.EndTime = CommonUtils.ConstructDateWIthTime(kagDate.Value, kagEndTime.Value);
            return kag;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtKag)
            {
                DdtKag kag = (DdtKag)obj;
                kagResultsTxt.Text = kag.Results;
                kagManipulationTxt.Text = kag.KagManipulation;
                kagActionsTxt.Text = kag.KagAction;
                DateTime startTime = kag.StartTime == default(DateTime) ? DateTime.Now : kag.StartTime;
                kagDate.Value = startTime;
                kagStartTime.Value = startTime;
                kagEndTime.Value = kag.EndTime == default(DateTime) ? startTime.AddHours(1) : kag.EndTime;
                title.Text = "Анализы за " + kag.CreationDate.ToShortDateString();
                objectId = kag.ObjectId;
                isNew = string.IsNullOrEmpty(objectId);
                hasChanges = false;
            }
            else
            {
    
                DdtHospital hospitalitySession = DbDataService.GetInstance().GetDdtHospitalService().GetById(hospitalSessionId);
                DateTime admissionDate = hospitalitySession.AdmissionDate;
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
            TemplatesUtils.fillBlankTemplate(DbDataService.GetInstance(), "blank_kag_template.doc", hospitalSessionId, values);
        }

        private void dataProcessingBlank_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            TemplatesUtils.fillBlankTemplate(DbDataService.GetInstance(), "blank_common_consent_template.doc", hospitalSessionId, values);
        }

        private void anesthesiaBlank_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("{time}", DateTime.Now.ToShortTimeString());
            TemplatesUtils.fillBlankTemplate(DbDataService.GetInstance(), "blank_anastesia_template.doc", hospitalSessionId, values);
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
