using Cardiology.Model;
using System;
using System.Windows.Forms;
using Cardiology.Utils;

namespace Cardiology
{
    public partial class FirstInspection : Form
    {
        private const string OKSUP_TYPE = "oksup";
        private const string OKSDOWN_TYPE = "oksdown";
        private const string KAG_TYPE = "kag";
        private const string AORTA_TYPE = "aorta";
        private const string GB_TYPE = "gb";
        private const string PIKS_TYPE = "piks";
        private const string PIKVIK_TYPE = "pikvik";
        private const string DEP_TYPE = "dep";
        private const string DEATH_TYPE = "death";

        private const string MA_TYPE = "ma";
        private const string SD_TYPE = "sd";
        private const string HOBL_TYPE = "hobl";
        private const string YES_TYPE = "yes";
        private const string NO_TYPE = "no";

        private const string TELA_TYPE = "tela";
        private const string NK_TYPE = "nk";
        private const string OKSST_TYPE = "oksSt";
        private const string OKS_TYPE = "oks";
        private const string PMA_TYPE = "pma";
        private const string IBS_TYPE = "ibs";

        private DdtHospital hospitalSession;
        private DdtAnamnesis anamnesis;

        public FirstInspection(DdtHospital hospitalitySession)
        {
            this.hospitalSession = hospitalitySession;
            InitializeComponent();
            initializeAnamnesis();
        }

        private void initializeAnamnesis()
        {
            DataService service = new DataService();
            anamnesis = service.queryObject<DdtAnamnesis>(@"select * from ddt_anamnesis WHERE dsid_hospitality_session='" + hospitalSession.ObjectId + "'");
            if (anamnesis != null)
            {
                digestiveSystemTxt.Text = anamnesis.DssDigestiveSystem;
                accompanyingIllnessesTxt.Text = anamnesis.DssAccompayingIll;
                anamnesisAllergyTxt.Text = anamnesis.DssAnamnesisAllergy;
                anamnesisEpidTxt.Text = anamnesis.DssAnamnesisEpid;
                anamnesisMorbiTxt.Text = anamnesis.DssAnamnesisMorbi;
                anamnesisVitaeTxt.Text = anamnesis.DssAnamnesisVitae;
                cardiovascularSystemTxt.Text = anamnesis.DssCardioVascular;
                complaintsTxt.Text = anamnesis.DssComplaints;
                justificationTxt.Text = anamnesis.DssDiagnosisJustifies;
                drugsTxt.Text = anamnesis.DssDrugs;
                nervousSystemTxt.Text = anamnesis.DssNervousSystem;
                pastSurgeriesTxt.Text = anamnesis.DssPastSurgeries;
                respiratorySystemTxt.Text = anamnesis.DssRespiratorySystem;
                stPresensTxt.Text = anamnesis.DssStPresens;
                urinarySystemTxt.Text = anamnesis.DssUrinarySystem;
            }
        }

        private void fixComplaintTeplaintBtn_Click(object sender, EventArgs e)
        {
            ComplaintTemplates templateForm = new ComplaintTemplates();
            templateForm.ShowDialog();
        }

        private void fixMorbiTemplateBtn_Click(object sender, EventArgs e)
        {
            MorbiTemplates templateForm = new MorbiTemplates();
            templateForm.ShowDialog();
        }

        private void FirstInspection_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            int currentTabIndx = tabsContainer.SelectedIndex;
            if (currentTabIndx > 0 && getIsValid(currentTabIndx))
            {
                tabsContainer.SelectTab(--currentTabIndx);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            int currentTabIndx = tabsContainer.SelectedIndex;
            if (currentTabIndx < tabsContainer.TabCount - 1 && getIsValid(currentTabIndx))
            {
                tabsContainer.SelectTab(++currentTabIndx);
            }
        }

        private bool getIsValid(int tabIndex)
        {
            bool result = true;
            if (tabIndex == 0)
            {
                result = CommonUtils.isNotBlank(complaintsTxt.Text) && CommonUtils.isNotBlank(anamnesisVitaeTxt.Text) &&
                    CommonUtils.isNotBlank(anamnesisMorbiTxt.Text) && CommonUtils.isNotBlank(anamnesisAllergyTxt.Text) &&
                    CommonUtils.isNotBlank(anamnesisEpidTxt.Text) && CommonUtils.isNotBlank(drugsTxt.Text);
            }
            else if (tabIndex == 1)
            {
                result = CommonUtils.isNotBlank(stPresensTxt.Text);
            }
            else if (tabIndex == 2)
            {
                result = CommonUtils.isNotBlank(diagnosisTxt.Text) && CommonUtils.isNotBlank(justificationTxt.Text);
            }

            if (!result)
            {
                MessageBox.Show("Введены не все данные на форме! Обязательные поля выделены жирным шрифтом!", "Предупреждение!", MessageBoxButtons.OK);
            }
            return result;
        }

        private void OKSUpBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(OKSUP_TYPE);
        }

        private void OKSDownBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(OKSDOWN_TYPE);
        }

        private void KAGBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(KAG_TYPE);
        }

        private void aorticDissectionBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(AORTA_TYPE);
        }

        private void GBBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(GB_TYPE);
        }

        private void PIKSBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(PIKS_TYPE);
        }

        private void PIKVIKBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(PIKVIK_TYPE);
        }

        private void DEPBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(DEP_TYPE);
        }

        private void deathBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(DEATH_TYPE);
        }

        private void fillControlsFromTemplate(string type)
        {
            diagnosisTxt.Text = getDefaultValueForType(diagnosisTxt.Name, type);
            nervousSystemTxt.Text = getDefaultValueForType(nervousSystemTxt.Name, type);
            cardiovascularSystemTxt.Text = getDefaultValueForType(cardiovascularSystemTxt.Name, type);
            respiratorySystemTxt.Text = getDefaultValueForType(respiratorySystemTxt.Name, type);
            stPresensTxt.Text = getDefaultValueForType(stPresensTxt.Name, type);
            drugsTxt.Text = getDefaultValueForType(drugsTxt.Name, type);
            anamnesisMorbiTxt.Text = getDefaultValueForType(anamnesisMorbiTxt.Name, type);
            complaintsTxt.Text = getDefaultValueForType(complaintsTxt.Name, type);
        }

        private string getDefaultValueForType(string controlName, string baseType)
        {
            string query = @"Select * from ddt_values WHERE dss_name like '" + controlName + "." + baseType + "'";
            DataService service = new DataService();
            DdtValues defaultValue = service.queryObject<DdtValues>(query);
            if (defaultValue != null)
            {
                return defaultValue.DssValue;
            }
            return null;
        }

        private void chronicMA_Click(object sender, EventArgs e)
        {
            accompanyingIllnessesTxt.Text = getDefaultValueForType(accompanyingIllnessesTxt.Name, MA_TYPE);
        }

        private void chronicGB3_Click(object sender, EventArgs e)
        {
            accompanyingIllnessesTxt.Text = getDefaultValueForType(accompanyingIllnessesTxt.Name, GB_TYPE);
        }

        private void chronicDEP3_Click(object sender, EventArgs e)
        {
            accompanyingIllnessesTxt.Text = getDefaultValueForType(accompanyingIllnessesTxt.Name, DEP_TYPE);
        }

        private void chronicSD_Click(object sender, EventArgs e)
        {
            accompanyingIllnessesTxt.Text = getDefaultValueForType(accompanyingIllnessesTxt.Name, SD_TYPE);
        }

        private void chronicHOBL_Click(object sender, EventArgs e)
        {
            accompanyingIllnessesTxt.Text = getDefaultValueForType(accompanyingIllnessesTxt.Name, HOBL_TYPE);
        }

        private void hasDrugsIntoxication_Click(object sender, EventArgs e)
        {
            drugsTxt.Text = getDefaultValueForType(drugsTxt.Name, NO_TYPE);
        }

        private void hasNoDrugsIntoxication_Click(object sender, EventArgs e)
        {
            drugsTxt.Text = getDefaultValueForType(drugsTxt.Name, YES_TYPE);
        }

        private void noAlcoholBtn_Click(object sender, EventArgs e)
        {
            anamnesisVitaeTxt.Text = getDefaultValueForType(anamnesisVitaeTxt.Name, NO_TYPE);
        }

        private void alcoholBtn_Click(object sender, EventArgs e)
        {
            anamnesisVitaeTxt.Text = getDefaultValueForType(anamnesisVitaeTxt.Name, YES_TYPE);
        }

        private void telaRadio_CheckedChanged(object sender, EventArgs e)
        {
            justificationTxt.Text = getDefaultValueForType(justificationTxt.Name, TELA_TYPE);
        }

        private void nkRadio_CheckedChanged(object sender, EventArgs e)
        {
            justificationTxt.Text = getDefaultValueForType(justificationTxt.Name, NK_TYPE);
        }

        private void oksStRadio_CheckedChanged(object sender, EventArgs e)
        {
            justificationTxt.Text = getDefaultValueForType(justificationTxt.Name, OKSST_TYPE);
        }

        private void oksRadio_CheckedChanged(object sender, EventArgs e)
        {
            justificationTxt.Text = getDefaultValueForType(justificationTxt.Name, OKS_TYPE);
        }

        private void pmaRadio_CheckedChanged(object sender, EventArgs e)
        {
            justificationTxt.Text = getDefaultValueForType(justificationTxt.Name, PMA_TYPE);
        }

        private void gbRadio_CheckedChanged(object sender, EventArgs e)
        {
            justificationTxt.Text = getDefaultValueForType(justificationTxt.Name, GB_TYPE);
        }

        private void ibsRadio_CheckedChanged(object sender, EventArgs e)
        {
            justificationTxt.Text = getDefaultValueForType(justificationTxt.Name, IBS_TYPE);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            for (int i = 0; i < tabsContainer.TabCount; i++)
            {
                isValid |= getIsValid(i);
            }

            if (isValid)
            {
                if (anamnesis == null)
                {
                    anamnesis = new DdtAnamnesis();
                    anamnesis.DsidHospitalitySession = hospitalSession.ObjectId;
                    anamnesis.DsidDoctor = hospitalSession.DsidCuringDoctor;
                    anamnesis.DsidPatient = hospitalSession.DsidPatient;
                }

                anamnesis.DssAccompayingIll = accompanyingIllnessesTxt.Text;
                anamnesis.DssAnamnesisAllergy = anamnesisAllergyTxt.Text;
                anamnesis.DssAnamnesisEpid = anamnesisEpidTxt.Text;
                anamnesis.DssAnamnesisMorbi = anamnesisMorbiTxt.Text;
                anamnesis.DssAnamnesisVitae = anamnesisVitaeTxt.Text;
                anamnesis.DssCardioVascular = cardiovascularSystemTxt.Text;
                anamnesis.DssComplaints = complaintsTxt.Text;
                anamnesis.DssDiagnosisJustifies = justificationTxt.Text;
                anamnesis.DssDigestiveSystem = digestiveSystemTxt.Text;
                anamnesis.DssDrugs = drugsTxt.Text;
                anamnesis.DssNervousSystem = nervousSystemTxt.Text;
                anamnesis.DssPastSurgeries = pastSurgeriesTxt.Text;
                anamnesis.DssRespiratorySystem = respiratorySystemTxt.Text;
                anamnesis.DssStPresens = stPresensTxt.Text;
                anamnesis.DssUrinarySystem = urinarySystemTxt.Text;

                DataService service = new DataService();
                if (CommonUtils.isBlank(anamnesis.ObjectId))
                {
                    service.insertObject<DdtAnamnesis>(anamnesis, "ddt_anamnesis");
                }
                else
                {
                    service.updateObject<DdtAnamnesis>(anamnesis, "ddt_anamnesis", "r_object_id", anamnesis.ObjectId);
                }
            }
        }
    }
}
