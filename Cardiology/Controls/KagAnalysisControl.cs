using System;
using System.Windows.Forms;
using Cardiology.Model;

namespace Cardiology
{
    public partial class KagAnalysisControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private string hospitalSessionId;
        private bool isEditable;

        public KagAnalysisControl(string objectId, bool additional, string hospitalSessionId)
        {
            this.objectId = objectId;
            this.hospitalSessionId = hospitalSessionId;
            this.isEditable = !additional;
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtKag kag = service.queryObjectById<DdtKag>(DdtKag.TABLE_NAME, objectId);
            if (kag != null)
            {
                kagResultsTxt.Text = kag.DssResults;
                kagManipulationTxt.Text = kag.DssKagManipulation;
                kagActionsTxt.Text = kag.DssKagAction;
                DateTime startTime = kag.DsdtStartTime;
                kagDate.Value = startTime == null || startTime.CompareTo(DateTime.MinValue) <= 0 ? DateTime.Now : startTime;
                kagStartTime.Value = startTime == null || startTime.CompareTo(DateTime.MinValue) <= 0 ? DateTime.Now : startTime;
                kagEndTime.Value = kag.DsdtEndTime == null || kag.DsdtEndTime.CompareTo(DateTime.MinValue) <= 0 ? DateTime.Now : kag.DsdtEndTime;
                title.Text = "Анализы за " + kag.RCreationDate.ToShortDateString();
            }
            else
            {
                DdtHospital hospitalitySession = service.queryObjectById<DdtHospital>(DdtHospital.TABLENAME, hospitalSessionId);
                DateTime admissionDate = hospitalitySession.DsdtAdmissionDate;
                kagDate.Value = admissionDate;
                kagStartTime.Value = admissionDate.AddMinutes(30);
            }
            kagResultsTxt.Enabled = isEditable;
            kagManipulationTxt.Enabled = isEditable;
            kagActionsTxt.Enabled = isEditable;
            kagDate.Enabled = isEditable;
            kagStartTime.Enabled = isEditable;
            kagEndTime.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable)
            {
                DataService service = new DataService();
                DdtKag kag = service.queryObjectById<DdtKag>(DdtKag.TABLE_NAME, objectId);
                if (kag == null)
                {
                    kag = new DdtKag();
                    kag.DsidHospitalitySession = hospitalitySession.ObjectId;
                    kag.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    kag.DsidPatient = hospitalitySession.DsidPatient;
                }
                kag.DssKagManipulation = kagManipulationTxt.Text;
                kag.DssResults = kagResultsTxt.Text;
                kag.DssKagAction = kagActionsTxt.Text;
                kag.DsdtStartTime = constructDateWIthTime(kagDate.Value, kagStartTime.Value);
                kag.DsdtAnalysisDate = constructDateWIthTime(kagDate.Value, kagStartTime.Value);
                kag.DsdtEndTime = constructDateWIthTime(kagDate.Value, kagEndTime.Value);

                objectId = service.updateOrCreateIfNeedObject<DdtKag>(kag, DdtKag.TABLE_NAME, kag.ObjectId);
            }
        }

        public string getObjectId()
        {
            return objectId;
        }

        private DateTime constructDateWIthTime(DateTime dateSource, DateTime timeSource)
        {
            return new DateTime(dateSource.Year, dateSource.Month, dateSource.Day, timeSource.Hour, timeSource.Minute, 0);
        }
    }
}
