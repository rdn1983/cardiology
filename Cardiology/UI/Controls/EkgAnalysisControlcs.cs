using System;
using System.Drawing;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class EkgAnalysisControlcs : UserControl, IDocbaseControl
    {
        private static readonly Size FULL_SIZE = new Size(741, 409);
        private static readonly Size READONLY_SIZE = new Size(741, 83);
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;
        private IAnalysisContainer container;

        public EkgAnalysisControlcs(string objectId, bool additional) : this(objectId, null, additional) { }

        public EkgAnalysisControlcs(string objectId, IAnalysisContainer container, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            this.container = container;
            this.Size = isEditable ? FULL_SIZE : READONLY_SIZE;
            this.MaximumSize = isEditable ? FULL_SIZE : READONLY_SIZE;
            this.MinimumSize = isEditable ? FULL_SIZE : READONLY_SIZE;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        private void initControls()
        {
            DdtEkg ekg = DbDataService.GetInstance().GetDdtEkgService().GetById(objectId);
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
            DdtEkg ekg = DbDataService.GetInstance().GetDdtEkgService().GetById(objectId);
            if (ekg == null)
            {
                ekg = new DdtEkg();
            }
            ekg.AnalysisDate = analysisDate.Value;
            ekg.Ekg = regularEkgTxt.Text;
            return ekg;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isNew && !string.IsNullOrEmpty(regularEkgTxt.Text) || isDirty()))
            {

                DdtEkg ekg = (DdtEkg)getObject();
                ekg.HospitalitySession = hospitalitySession.ObjectId;
                ekg.Doctor = hospitalitySession.CuringDoctor;
                ekg.Patient = hospitalitySession.Patient;
                if (parentId != null)
                {
                    ekg.Parent = parentId;
                }
                if (parentType != null)
                {
                    ekg.ParentType = parentType;
                }

                objectId = DbDataService.GetInstance().GetDdtEkgService().Save(ekg);
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
            return !string.IsNullOrEmpty(regularEkgTxt.Text) || !isEditable;
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
                readonlyEkgTxt.Text = ekg.Ekg;
                regularEkgTxt.Text = ekg.Ekg;
                analysisDate.Value = ekg.AnalysisDate;
                readonlyEkgBox.Text = "ЭКГ за " + ekg.AnalysisDate.ToShortDateString();
                objectId = ekg.ObjectId;
                isNew = string.IsNullOrEmpty(objectId);
                hasChanges = false;
            }
        }

        public bool isVisible()
        {
            return true;
        }


        private void hide_Click(object sender, EventArgs e)
        {
            container?.RemoveControl(this, DdtEkg.NAME);
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
            if(regularEkgTxt.Text !=null && regularEkgTxt.Text.Trim().Length > 0)
            {
                regularEkgTxt.Text = regularEkgTxt.Text + ". ";
            }
            regularEkgTxt.Text = regularEkgTxt.Text + "ритм синусовый";
        }

        private void fibrillationBtn_Click(object sender, EventArgs e)
        {
            if (regularEkgTxt.Text != null && regularEkgTxt.Text.Trim().Length > 0)
            {
                regularEkgTxt.Text = regularEkgTxt.Text + ". ";
            }
            regularEkgTxt.Text = regularEkgTxt.Text + "фибрилляция предсердий";
        }

        private void flutterBtn_Click(object sender, EventArgs e)
        {
            if (regularEkgTxt.Text != null && regularEkgTxt.Text.Trim().Length > 0)
            {
                regularEkgTxt.Text = regularEkgTxt.Text + ". ";
            }
            regularEkgTxt.Text = regularEkgTxt.Text + "трепетание предсердий";
        }

        private void elevation_Click(object sender, EventArgs e)
        {
            if (regularEkgTxt.Text != null && regularEkgTxt.Text.Trim().Length > 0)
            {
                regularEkgTxt.Text = regularEkgTxt.Text + ". ";
            }
            regularEkgTxt.Text = regularEkgTxt.Text + "элевация ST в ";
        }

        private void dotBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + ".";
        }

        private void depressionBtn_Click(object sender, EventArgs e)
        {
            if (regularEkgTxt.Text != null && regularEkgTxt.Text.Trim().Length > 0)
            {
                regularEkgTxt.Text = regularEkgTxt.Text + ". ";
            }
            regularEkgTxt.Text = regularEkgTxt.Text + "депрессия ST в ";
        }

        private void negativeTBtn_Click(object sender, EventArgs e)
        {
            if (regularEkgTxt.Text != null && regularEkgTxt.Text.Trim().Length > 0)
            {
                regularEkgTxt.Text = regularEkgTxt.Text + ". ";
            }
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
            regularEkgTxt.Text = regularEkgTxt.Text + "aVL";
        }

        private void AvrBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "aVR";
        }

        private void AvfBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "aVF";
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
            string indxStr = String.Intern(name.Substring(CommonUtils.GetFirstDigitIndex(name), 1));
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
            Control mirrorCtrl = CommonUtils.FindControl(ekgTemplates, mirrorCtrlName);
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
