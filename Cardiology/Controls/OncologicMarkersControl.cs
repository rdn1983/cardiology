using System;
using System.Windows.Forms;
using Cardiology.Utils;
using Cardiology.Model;

namespace Cardiology.Controls
{
    public partial class OncologicMarkersControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private string hospitalSessionId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;

        public OncologicMarkersControl(string objectId, bool additional, string hospitalSessionId)
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
            DdtOncologicMarkers markers = service.queryObjectById<DdtOncologicMarkers>(objectId);
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
                DataService service = new DataService();
                DdtOncologicMarkers kag = (DdtOncologicMarkers)getObject();
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

                objectId = service.updateOrCreateIfNeedObject<DdtOncologicMarkers>(kag, DdtOncologicMarkers.TABLE_NAME, kag.RObjectId);
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
            return CommonUtils.isNotBlank(psaCommonTxt.Text) || CommonUtils.isNotBlank(psaFreeTxt.Text)
                || CommonUtils.isNotBlank(ca125Txt.Text) || CommonUtils.isNotBlank(ca153Txt.Text) || CommonUtils.isNotBlank(ca199Txt.Text)
                || CommonUtils.isNotBlank(ceaTxt.Text) || CommonUtils.isNotBlank(hgchTxt.Text) || CommonUtils.isNotBlank(afrTxt.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {
            DataService service = new DataService();
            DdtOncologicMarkers markerObj = service.queryObjectById<DdtOncologicMarkers>(objectId);
            if (markerObj == null)
            {
                markerObj = new DdtOncologicMarkers();
            }
            markerObj.DssCea = ceaTxt.Text;
            markerObj.DssPsaCommon = psaCommonTxt.Text;
            markerObj.DssPsaFree = psaFreeTxt.Text;
            markerObj.DssCa125 = ca125Txt.Text;
            markerObj.DssCa153 = ca153Txt.Text;
            markerObj.DssCa199 = ca199Txt.Text;
            markerObj.DssHgch = hgchTxt.Text;
            markerObj.DssAfr = afrTxt.Text;
            markerObj.DsdtAnalysisDate = CommonUtils.constructDateWIthTime(admissionDateTxt.Value, admissionTimeTxt.Value);
            return markerObj;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtOncologicMarkers)
            {
                DdtOncologicMarkers marker = (DdtOncologicMarkers)obj;
                ceaTxt.Text = marker.DssCea;
                psaCommonTxt.Text = marker.DssPsaCommon;
                psaFreeTxt.Text = marker.DssPsaFree;
                ca125Txt.Text = marker.DssCa125;
                ca153Txt.Text = marker.DssCa153;
                ca199Txt.Text = marker.DssCa199;
                hgchTxt.Text = marker.DssHgch;
                afrTxt.Text = marker.DssAfr;
                DateTime startTime = marker.DsdtAnalysisDate == default(DateTime) ? DateTime.Now : marker.DsdtAnalysisDate;
                admissionDateTxt.Value = startTime;
                admissionTimeTxt.Value = startTime;
                cntr.Text = "Онкомаркеры за " + marker.RCreationDate.ToShortDateString();
                objectId = marker.RObjectId;
                isNew = CommonUtils.isBlank(objectId);
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
    }
}
