using System;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class OncologicMarkersControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private string hospitalSessionId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;
        private IAnalysisContainer container;

        public OncologicMarkersControl(string objectId, bool additional, string sessionId) : this(objectId, null, additional, sessionId) { }

        public OncologicMarkersControl(string objectId, IAnalysisContainer container, bool additional, string hospitalSessionId)
        {
            this.objectId = objectId;
            this.hospitalSessionId = hospitalSessionId;
            this.isEditable = !additional;
            this.container = container;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        private void initControls()
        {
            DdtOncologicMarkers markers = DbDataService.GetInstance().GetDdtOncologicMarkersService().GetById(objectId);
            refreshObject(markers);
            ceaTxt.Enabled = isEditable;
            psaCommonTxt.Enabled = isEditable;
            psaFreeTxt.Enabled = isEditable;
            ca125Txt.Enabled = isEditable;
            ca153Txt.Enabled = isEditable;
            ca199Txt.Enabled = isEditable;
            ceaTxt.Enabled = isEditable;
            hgchTxt.Enabled = isEditable;
            afrTxt.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isNew || isDirty()))
            {
                DdtOncologicMarkers oncologicMarkers = (DdtOncologicMarkers)getObject();
                oncologicMarkers.HospitalitySession = hospitalitySession.ObjectId;
                oncologicMarkers.Doctor = hospitalitySession.CuringDoctor;
                oncologicMarkers.Patient = hospitalitySession.Patient;
                if (parentId != null)
                {
                    oncologicMarkers.Parent = parentId;
                }
                if (parentType != null)
                {
                    oncologicMarkers.ParentType = parentType;
                }

                objectId = DbDataService.GetInstance().GetDdtOncologicMarkersService().Save(oncologicMarkers);
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
            return !string.IsNullOrEmpty(psaCommonTxt.Text) || !string.IsNullOrEmpty(psaFreeTxt.Text)
                || !string.IsNullOrEmpty(ca125Txt.Text) || !string.IsNullOrEmpty(ca153Txt.Text) || !string.IsNullOrEmpty(ca199Txt.Text)
                || !string.IsNullOrEmpty(ceaTxt.Text) || !string.IsNullOrEmpty(hgchTxt.Text) || !string.IsNullOrEmpty(afrTxt.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {
            DdtOncologicMarkers markerObj = DbDataService.GetInstance().GetDdtOncologicMarkersService().GetById(objectId);
            if (markerObj == null)
            {
                markerObj = new DdtOncologicMarkers();
            }
            markerObj.Cea = ceaTxt.Text;
            markerObj.PsaCommon = psaCommonTxt.Text;
            markerObj.PsaFree = psaFreeTxt.Text;
            markerObj.Ca125 = ca125Txt.Text;
            markerObj.Ca153 = ca153Txt.Text;
            markerObj.Ca199 = ca199Txt.Text;
            markerObj.Hgch = hgchTxt.Text;
            markerObj.Afr = afrTxt.Text;
            markerObj.AnalysisDate = CommonUtils.ConstructDateWIthTime(admissionDateTxt.Value, admissionTimeTxt.Value);
            return markerObj;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtOncologicMarkers)
            {
                DdtOncologicMarkers marker = (DdtOncologicMarkers)obj;
                ceaTxt.Text = marker.Cea;
                psaCommonTxt.Text = marker.PsaCommon;
                psaFreeTxt.Text = marker.PsaFree;
                ca125Txt.Text = marker.Ca125;
                ca153Txt.Text = marker.Ca153;
                ca199Txt.Text = marker.Ca199;
                hgchTxt.Text = marker.Hgch;
                afrTxt.Text = marker.Afr;
                DateTime startTime = marker.AnalysisDate == default(DateTime) ? DateTime.Now : marker.AnalysisDate;
                admissionDateTxt.Value = startTime;
                admissionTimeTxt.Value = startTime;
                cntr.Text = "Онкомаркеры за " + marker.CreationDate.ToShortDateString();
                objectId = marker.ObjectId;
                isNew = string.IsNullOrEmpty(objectId);
                hasChanges = false;
            }
        }

        public bool isVisible()
        {
            return true;
        }

        #region controls_behaviour

        private void ControlTxt_TextChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }
        #endregion

        private void admissionDateTxt_ValueChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        private void hide_Click(object sender, EventArgs e)
        {
            container?.RemoveControl(this, DdtOncologicMarkers.NAME);
        }
    }
}
