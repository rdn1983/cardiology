using System;
using System.Drawing;
using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Commons;

namespace Cardiology
{
    public partial class EkgAnalysisControlcs : UserControl, IDocbaseControl
    {
        private static readonly Size FULL_SIZE = new Size(732, 409);
        private static readonly Size READONLY_SIZE = new Size(732, 83);

        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;

        public EkgAnalysisControlcs() : this(null, false) { }

        public EkgAnalysisControlcs(string objectId, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            this.Size = isEditable ? FULL_SIZE : READONLY_SIZE;
            this.MaximumSize = isEditable ? FULL_SIZE : READONLY_SIZE;
            this.MinimumSize = isEditable ? FULL_SIZE : READONLY_SIZE;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = CommonUtils.isBlank(objectId);
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtEkg ekg = service.queryObjectById<DdtEkg>(objectId);
            refreshObject(ekg);
            regularEkgTxt.Enabled = isEditable;
            readonlyEkgTxt.Enabled = isEditable;
            analysisDate.Enabled = isEditable;

            editablePnl.Visible = isEditable;
            readonlyEkgBox.Visible = !isEditable;

            editablePnl.Size = isEditable ? FULL_SIZE : READONLY_SIZE;
        }

        public object getObject()
        {
            DataService service = new DataService();
            DdtEkg ekg = service.queryObjectById<DdtEkg>(objectId);
            if (ekg == null)
            {
                ekg = new DdtEkg();
            }
            ekg.DsdtAnalysisDate = analysisDate.Value;
            ekg.DssEkg = regularEkgTxt.Text;
            return ekg;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isNew && CommonUtils.isNotBlank(regularEkgTxt.Text) || isDirty()))
            {
                DataService service = new DataService();
                DdtEkg ekg = (DdtEkg)getObject();
                ekg.DsidHospitalitySession = hospitalitySession.ObjectId;
                ekg.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                ekg.DsidPatient = hospitalitySession.DsidPatient;
                if (parentId != null)
                {
                    ekg.DsidParent = parentId;
                }
                if (parentType != null)
                {
                    ekg.DssParentType = parentType;
                }
                objectId = service.updateOrCreateIfNeedObject<DdtEkg>(ekg, DdtEkg.TABLE_NAME, ekg.ObjectId);
                isNew = false;
                hasChanges = false;
            }
        }

        public string getObjectId()
        {
            return objectId;
        }

        public void setObjectId(string id)
        {
            this.objectId = id;
        }

        public bool getIsValid()
        {
            return CommonUtils.isNotBlank(regularEkgTxt.Text) || !isEditable;
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtEkg)
            {
                DdtEkg ekg = (DdtEkg)obj;
                readonlyEkgTxt.Text = ekg.DssEkg;
                regularEkgTxt.Text = ekg.DssEkg;
                analysisDate.Value = ekg.DsdtAnalysisDate;
                readonlyEkgBox.Text = "ЭКГ за " + ekg.DsdtAnalysisDate.ToShortDateString();
                objectId = ekg.ObjectId;
                isNew = CommonUtils.isBlank(objectId);
                hasChanges = false;
            }
        }

        public bool isVisible()
        {
            return true;
        }

        #region controls_behavior
        private void clearBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = "";
        }

        private void spaceBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + " ";
        }

        private void IBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "I";
        }

        private void rhytmSinusBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "ритм синусовый";
        }

        private void fibrillationBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "фибрилляция предсердий";
        }

        private void flutterBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "трепетание предсердий";
        }

        private void elevation_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "элевация ST в ";
        }

        private void dotBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + ".";
        }

        private void depressionBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "депрессия ST в ";
        }

        private void negativeTBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "отрицательный T";
        }

        private void IIBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "II";
        }

        private void IIIBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "III";
        }

        private void AvlBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "AVL";
        }

        private void AvrBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "AVR";
        }

        private void AvfBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "AVF";
        }

        private void V1Btn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "V1";
        }

        private void V2Btn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "V2";
        }

        private void V3Btn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "V3";
        }

        private void V4Btn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "V4";
        }

        private void V5Btn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "V5";
        }

        private void V6Btn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "V6";
        }

        private void commaBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + ", ";
        }

        private void dashBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "-";
        }

        private void frontType1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string name = btn.Name;
            string indxStr = String.Intern(name.Substring(CommonUtils.getFirstDigitIndex(name), 1));
            string mirrorCtrlName = null;
            if (name.StartsWith("frontType"))
            {
                mirrorCtrlName = "frontDesc" + indxStr;
            }
            else if (name.StartsWith("frontDesc"))
            {
                mirrorCtrlName = "frontType" + indxStr;
            }
            else if (name.StartsWith("backType"))
            {
                mirrorCtrlName = "backDesc" + indxStr;
            }
            else if (name.StartsWith("backDesc"))
            {
                mirrorCtrlName = "backType" + indxStr;
            }
            Control mirrorCtrl = CommonUtils.findControl(ekgTemplates, mirrorCtrlName);
            if (mirrorCtrl != null)
            {
                regularEkgTxt.Text += mirrorCtrl.Text;
            }

        }

        private void regularEkgTxt_TextChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        private void analysisDate_ValueChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }
        #endregion
    }
}
