using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model;
using Cardiology.UI.Controls;
using DdtValues = Cardiology.Data.Model2.DdtValues;

namespace Cardiology.UI.Forms
{
    public partial class FirstInspection : Form, IAutoSaveForm
    {
        private const int EGDS_TAB_INDX = 1;
        private const int URINE_TAB_INDX = 2;
        private const int BLOOD_TAB_INDX = 3;

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
        private const string DT_TYPE = "dt";

        private IDbDataService service;
        private DdtHospital hospitalSession;
        private DdtAnamnesis anamnesis;
        private bool acceptTemplate = false;
        private string templateName;

        public FirstInspection(IDbDataService service, DdtHospital hospitalitySession)
        {
            this.service = service;
            this.hospitalSession = hospitalitySession;
            InitializeComponent();
            SilentSaver.setForm(this);

            DataService dataService = new DataService();
            anamnesis = dataService.queryObject<DdtAnamnesis>(@"select * from ddt_anamnesis WHERE dsid_hospitality_session='" + hospitalSession.ObjectId + "'");

            initializeAnamnesis(anamnesis);
            initIssuedMedicine(dataService);
            initIssuedActions(dataService, anamnesis);
            InitDiagnosis();
            initAdmissionAnalysis(dataService);
            InitDoctorComboBox();
            InitPatientInfo(dataService);
        }

        private void InitPatientInfo(DataService service)
        {
            DdtPatient patient = service.queryObjectById<DdtPatient>(hospitalSession.DsidPatient);
            if (patient != null)
            {
                patientInitialsLbl.Text = patient.DssInitials;
                if (anamnesis == null)
                {
                    List<DdtCure> medicineTemplates = service.queryObjectsCollection<DdtCure>(@"Select cure.* from ddt_values vv, ddt_cure cure 
                            where vv.dss_name like 'sd' AND vv.dss_value=cure.dss_name");
                    issuedMedicineContainer.RefreshData(service, medicineTemplates);
                    if (patient.DsbSd)
                    {
                        accompanyingIllnessesTxt.Text += "Сахарный диабет 2 типа, среднетяжелого течения, субкомпенсация. \n";
                        diagnosisTxt.Text += "Сахарный диабет 2 типа, среднетяжелого течения, субкомпенсация. \n";
                    }
                }
            }
        }

        private void InitDoctorComboBox()
        {
            String id = anamnesis == null ? hospitalSession.DsidCuringDoctor : anamnesis.DsidDoctor;
            ControlUtils.InitDoctors(this.service.GetDdvDoctorService(), docBox, id);
        }

        private void initAdmissionAnalysis(DataService service)
        {
            DdtUrineAnalysis firstAnalysis = service.queryObject<DdtUrineAnalysis>("SELECT * FROM " + DdtUrineAnalysis.TABLE_NAME + " WHERE " +
                "dsid_hospitality_session = '" + hospitalSession.ObjectId + "' AND dsid_parent='" + anamnesis?.ObjectId + "'");
            urineAnalysisControl.refreshObject(firstAnalysis);

            DdtEgds firstEgdsAnalysis = service.queryObject<DdtEgds>("SELECT * FROM " + DdtEgds.TABLE_NAME + " WHERE " +
                "dsid_hospitality_session = '" + hospitalSession.ObjectId + "' AND dsid_parent='" + anamnesis?.ObjectId + "'");

            egdsAnalysisControl1.refreshObject(firstEgdsAnalysis);

            DdtBloodAnalysis blood = service.queryObject<DdtBloodAnalysis>("SELECT * FROM " + DdtBloodAnalysis.TABLE_NAME + " WHERE " +
                "dsid_hospitality_session = '" + hospitalSession.ObjectId + "' AND dsid_parent='" + anamnesis?.ObjectId + "'");

            bloodAnalysisControl.refreshObject(blood);

            DdtEkg ekg = service.queryObject<DdtEkg>("SELECT * FROM " + DdtEkg.TABLE_NAME + " WHERE " +
                "dsid_hospitality_session = '" + hospitalSession.ObjectId + "' AND dsid_parent='" + anamnesis?.ObjectId + "'");
            ekgAnalysisControlcs.refreshObject(ekg);
        }

        private void InitDiagnosis()
        {
            diagnosisTxt.Text = hospitalSession.DssDiagnosis;
        }

        private void initializeAnamnesis(DdtAnamnesis anamnesis)
        {
            if (anamnesis != null)
            {
                acceptTemplate = true;
                if (!anamnesis.DsbTemplate)
                {
                    accompanyingIllnessesTxt.Text = anamnesis.DssAccompayingIll;
                    anamnesisVitaeTxt.Text = anamnesis.DssAnamnesisVitae;
                    pastSurgeriesTxt.Text = anamnesis.DssPastSurgeries;
                }
                digestiveSystemTxt.Text = anamnesis.DssDigestiveSystem;
                urinarySystemTxt.Text = anamnesis.DssUrinarySystem;
                justificationTxt.Text = anamnesis.DssDiagnosisJustifies;
                anamnesisMorbiTxt.Text = anamnesis.DssAnamnesisMorbi;
                complaintsTxt.Text = anamnesis.DssComplaints;
                drugsTxt.Text = anamnesis.DssDrugs;
                stPresensTxt.Text = anamnesis.DssStPresens;
                cardiovascularSystemTxt.Text = anamnesis.DssCardioVascular;
                respiratorySystemTxt.Text = anamnesis.DssRespiratorySystem;
                nervousSystemTxt.Text = anamnesis.DssNervousSystem;
                anamnesisEpidTxt.Text = anamnesis.DssAnamnesisEpid;
                diagnosisTxt.Text = anamnesis.DssDiagnosis;
                anamnesisAllergyTxt.Text = anamnesis.DssAnamnesisAllergy;
                operationCauseTxt.Text = anamnesis.DssOperationCause;
            }
        }

        private void initIssuedMedicine(DataService service)
        {
            DdtIssuedMedicineList medList = service.queryObject<DdtIssuedMedicineList>(@"SELECT * FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='" +
                hospitalSession.ObjectId + "' AND dss_parent_type='ddt_anamnesis'");
            if (medList != null)
            {
                issuedMedicineContainer.Init(service, medList);
                templateName = medList.DssTemplateName;
            }
        }

        private void initIssuedActions(DataService service, DdtAnamnesis parent)
        {
            if (parent != null)
            {
                List<DdtIssuedAction> allActions = service.queryObjectsCollection<DdtIssuedAction>(@"SELECT * FROM ddt_issued_action WHERE dsid_parent_id='" + parent.ObjectId + "'");
                issuedActionContainer.init(service, allActions);
            }
        }

        private bool getIsValid(int tabIndex)
        {
            bool result = true;
            if (tabIndex == 0)
            {
                result = !string.IsNullOrEmpty(getSafeStringValue(complaintsTxt)) && !string.IsNullOrEmpty(getSafeStringValue(anamnesisVitaeTxt)) &&
                    !string.IsNullOrEmpty(getSafeStringValue(anamnesisMorbiTxt)) && !string.IsNullOrEmpty(getSafeStringValue(anamnesisAllergyTxt)) &&
                    !string.IsNullOrEmpty(getSafeStringValue(anamnesisEpidTxt)) && !string.IsNullOrEmpty(getSafeStringValue(drugsTxt));
            }
            else if (tabIndex == 1)
            {
                result = !string.IsNullOrEmpty(stPresensTxt.Text);
            }
            else if (tabIndex == 2)
            {
                result = !string.IsNullOrEmpty(diagnosisTxt.Text) && !string.IsNullOrEmpty(justificationTxt.Text);
            }

            if (!result)
            {
                MessageBox.Show("Введены не все данные на форме! Обязательные поля выделены жирным шрифтом!", "Предупреждение!", MessageBoxButtons.OK);
            }
            return result;
        }

        public bool save()
        {
            bool isNotValid = false;
            for (int i = 0; i < tabsContainer.TabCount; i++)
            {
                isNotValid |= !getIsValid(i);
            }

            if (isNotValid)
            {
                return false;
            }
            DataService service = new DataService();

            saveAnamnesis(service);
            saveIssuedMedicine(service);
            saveIssuedAction(service);

            ekgAnalysisControlcs.saveObject(hospitalSession, anamnesis.ObjectId, DdtAnamnesis.TABLE_NAME);
            urineAnalysisControl.saveObject(hospitalSession, anamnesis.ObjectId, DdtAnamnesis.TABLE_NAME);
            bloodAnalysisControl.saveObject(hospitalSession, anamnesis.ObjectId, DdtAnamnesis.TABLE_NAME);
            egdsAnalysisControl1.saveObject(hospitalSession, anamnesis.ObjectId, DdtAnamnesis.TABLE_NAME);

            hospitalSession.DssDiagnosis = diagnosisTxt.Text;
            service.updateObject<DdtHospital>(hospitalSession, DdtHospital.TABLE_NAME, "r_object_id", hospitalSession.ObjectId);
            return true;
        }

        private void saveAnamnesis(DataService service)
        {
            if (anamnesis == null)
            {
                anamnesis = new DdtAnamnesis();
                anamnesis.DsidHospitalitySession = hospitalSession.ObjectId;
                anamnesis.DsidPatient = hospitalSession.DsidPatient;
                anamnesis.DsdtInspectionDate = DateTime.Now;
            }
            DdtDoctors doc = getSafeObjectValueUni<DdtDoctors>(docBox, new getValue<DdtDoctors>((ctrl) => (DdtDoctors)((ComboBox)ctrl).SelectedItem));
            anamnesis.DsidDoctor = doc.ObjectId;

            anamnesis.DssAccompayingIll = getSafeStringValue(accompanyingIllnessesTxt);
            anamnesis.DssAnamnesisAllergy = getSafeStringValue(anamnesisAllergyTxt);
            anamnesis.DssAnamnesisEpid = getSafeStringValue(anamnesisEpidTxt);
            anamnesis.DssAnamnesisMorbi = getSafeStringValue(anamnesisMorbiTxt);
            anamnesis.DssAnamnesisVitae = getSafeStringValue(anamnesisVitaeTxt);
            anamnesis.DssCardioVascular = getSafeStringValue(cardiovascularSystemTxt);
            anamnesis.DssComplaints = getSafeStringValue(complaintsTxt);
            anamnesis.DssDiagnosisJustifies = getSafeStringValue(justificationTxt);
            anamnesis.DssDigestiveSystem = getSafeStringValue(digestiveSystemTxt);
            anamnesis.DssDrugs = getSafeStringValue(drugsTxt);
            anamnesis.DssNervousSystem = getSafeStringValue(nervousSystemTxt);
            anamnesis.DssPastSurgeries = getSafeStringValue(pastSurgeriesTxt);
            anamnesis.DssRespiratorySystem = getSafeStringValue(respiratorySystemTxt);
            anamnesis.DssStPresens = getSafeStringValue(stPresensTxt);
            anamnesis.DssUrinarySystem = getSafeStringValue(urinarySystemTxt);
            anamnesis.DssDiagnosis = getSafeStringValue(diagnosisTxt);
            anamnesis.DssOperationCause = getSafeStringValue(operationCauseTxt);
            anamnesis.DssJustification = getSafeStringValue(justificationTxt);

            string id = service.updateOrCreateIfNeedObject<DdtAnamnesis>(anamnesis, DdtAnamnesis.TABLE_NAME, anamnesis.ObjectId);
            anamnesis.ObjectId = id;
        }

        private void saveIssuedMedicine(DataService service)
        {
            List<DdtIssuedMedicine> meds = getSafeObjectValueUni(issuedMedicineContainer,
                new getValue<List<DdtIssuedMedicine>>((ctrl) => ((IssuedMedicineContainer)ctrl).getIssuedMedicines()));

            List<DdtIssuedMedicine> meds2 = new List<DdtIssuedMedicine>();
            foreach (DdtIssuedMedicine med in meds)
            {
                if(med.DsidCure != null) {
                    meds2.Add(med);
                }                
            }

            if (meds2.Count > 0)
            {
                DdtIssuedMedicineList medList = service.queryObject<DdtIssuedMedicineList>(@"SELECT * FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='" +
                  hospitalSession.ObjectId + "' AND dss_parent_type='ddt_anamnesis'");
                if (medList == null)
                {
                    medList = new DdtIssuedMedicineList();
                    medList.DsidDoctor = hospitalSession.DsidDutyDoctor;
                    medList.DsidHospitalitySession = hospitalSession.ObjectId;
                    medList.DsidPatient = hospitalSession.DsidPatient;
                    medList.DssParentType = "ddt_anamnesis";
                    medList.DsidParentId = anamnesis.ObjectId;
                    medList.DsdtIssuingDate = DateTime.Now;
                }
                medList.DssTemplateName = templateName;
                string id = service.updateOrCreateIfNeedObject<DdtIssuedMedicineList>(medList, DdtIssuedMedicineList.TABLE_NAME, medList.ObjectId);
                medList.ObjectId = id;
                foreach (DdtIssuedMedicine med in meds2)
                {
                    med.DsidMedList = medList.ObjectId;

                    service.updateOrCreateIfNeedObject<DdtIssuedMedicine>(med, DdtIssuedMedicine.TABLE_NAME, med.RObjectId);
                }
            }

        }

        private void saveIssuedAction(DataService service)
        {
            List<DdtIssuedAction> meds = getSafeObjectValueUni(issuedActionContainer,
               new getValue<List<DdtIssuedAction>>((ctrl) => ((IssuedActionContainer)ctrl).getIssuedMedicines()));
            if (meds.Count > 0)
            {
                foreach (DdtIssuedAction med in meds)
                {
                    if (string.IsNullOrEmpty(med.RObjectId) || string.IsNullOrEmpty(med.DsidDoctor))
                    {
                        med.DsidParentId = anamnesis.ObjectId;
                        med.DsidDoctor = hospitalSession.DsidCuringDoctor;
                        med.DsidPatient = hospitalSession.DsidPatient;
                        med.DsidHospitalitySession = hospitalSession.ObjectId;
                        med.DsdtIssuingDate = DateTime.Now;
                    }

                    med.RObjectId = service.updateOrCreateIfNeedObject<DdtIssuedAction>(med, DdtIssuedAction.TABLE_NAME, med.RObjectId);
                }
                issuedActionContainer.init(service, meds);
            }

        }

        private string getSafeStringValue(Control c)
        {
            if (c.InvokeRequired)
            {
                return (string)c.Invoke(new getControlTextValue((ctrl) => ctrl.Text), c);
            }
            return c.Text;
        }

        private T getSafeObjectValueUni<T>(Control c, getValue<T> getter)
        {
            if (c.InvokeRequired)
            {
                return (T)c.Invoke(new getControlObjectValue<T>((ctrl) => getter(ctrl)), c);
            }
            return getter(c);
        }

        delegate T getValue<T>(Control ctrl);

        delegate string getControlTextValue(Control ctrl);
        delegate T getControlObjectValue<T>(Control ctrl);

        private bool isSureChangeTemplate()
        {
            if (acceptTemplate)
            {
                DialogResult result = MessageBox.Show("Уже применен шаблон! Вы уверены, что хотите сменить шаблон?", "Предупреждение", MessageBoxButtons.OKCancel);
                return result == DialogResult.OK;
            }
            return true;
        }

        private void clearSelection()
        {
            OKSUpBtn.BackColor = Color.Empty;
            OKSDownBtn.BackColor = Color.Empty;
            KAGBtn.BackColor = Color.Empty;
            deathBtn.BackColor = Color.Empty;
            DEPBtn.BackColor = Color.Empty;
            PIKVIKBtn.BackColor = Color.Empty;
            PIKSBtn.BackColor = Color.Empty;
            GBBtn.BackColor = Color.Empty;
            aorticDissectionBtn.BackColor = Color.Empty;
        }

        private void updatemedicineFromTemplate(string template)
        {
            DataService service = new DataService();
            List<DdtCure> medicineTemplates = service.queryObjectsCollection<DdtCure>(@"Select cure.* from ddt_values vv, ddt_cure cure 
                            where vv.dss_name like '" + template + "%' AND vv.dss_value=cure.dss_name");
            clearOldMedList(service);
            issuedMedicineContainer.RefreshData(service, medicineTemplates);
        }

        private void clearOldMedList(DataService service)
        {
            DdtIssuedMedicineList medList = service.queryObject<DdtIssuedMedicineList>(@"SELECT * FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='" +
                hospitalSession.ObjectId + "' AND dss_parent_type='ddt_anamnesis'");
            if (medList != null)
            {
                service.update(@"DELETE FROM " + DdtIssuedMedicine.TABLE_NAME + " WHERE dsid_med_list='" + medList.ObjectId + "'");
            }
        }

        private string getDefaultValueForType(string controlName, string baseType)
        {
            DdtValues defaultValue = service.GetDdtValuesService().GetByNameLike(controlName + "." + baseType);
            return defaultValue?.Value;
        }

        #region controls_behavior  

        private void fixComplaintTeplaintBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            MouseEventArgs mouseArgs = e as MouseEventArgs;
            if (isSureChangeTemplate())
            {
                templateChanger.Show(mouseArgs.X, mouseArgs.Y, btn, "dss_complaints", (value) => complaintsTxt.Text = (string)value);
            }
        }

        private void fixMorbiTemplateBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            MouseEventArgs mouseArgs = e as MouseEventArgs;
            if (isSureChangeTemplate())
            {
                templateChanger.Show(mouseArgs.X, mouseArgs.Y, btn, "dss_anamnesis_morbi", (value) => anamnesisMorbiTxt.Text = (string)value);
            }
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

        private void OKSUpBtn_Click(object sender, EventArgs e)
        {
            if (!"oks.medicine.".Equals(templateName) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();
                DataService service = new DataService();
                DdtAnamnesis template = service.queryObject<DdtAnamnesis>(@"SELECT * FROM ddt_anamnesis WHERE dsb_template=true AND dss_template_name='" + OKSUP_TYPE + "'");
                initializeAnamnesis(template);
                initIssuedActions(service, template);
                templateName = "oks.medicine.";
                updatemedicineFromTemplate(templateName);
                OKSUpBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void OKSDownBtn_Click(object sender, EventArgs e)
        {
            if (!"okslongs.medicine.".Equals(templateName) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();
                DataService service = new DataService();
                DdtAnamnesis template = service.queryObject<DdtAnamnesis>(@"SELECT * FROM ddt_anamnesis WHERE dsb_template=true AND dss_template_name='" + OKSDOWN_TYPE + "'");
                initializeAnamnesis(template);
                initIssuedActions(service, template);
                templateName = "okslongs.medicine.";
                updatemedicineFromTemplate(templateName);
                OKSDownBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void KAGBtn_Click(object sender, EventArgs e)
        {
            if (!"kag.medicine.".Equals(templateName) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();
                DataService service = new DataService();
                DdtAnamnesis template = service.queryObject<DdtAnamnesis>(@"SELECT * FROM ddt_anamnesis WHERE dsb_template=true AND dss_template_name='" + KAG_TYPE + "'");
                initializeAnamnesis(template);
                initIssuedActions(service, template);
                templateName = "kag.medicine.";
                updatemedicineFromTemplate(templateName);
                KAGBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void aorticDissectionBtn_Click(object sender, EventArgs e)
        {
            if (!"aorta.medicine.".Equals(templateName) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();
                DataService service = new DataService();
                DdtAnamnesis template = service.queryObject<DdtAnamnesis>(@"SELECT * FROM ddt_anamnesis WHERE dsb_template=true AND dss_template_name='" + AORTA_TYPE + "'");
                initializeAnamnesis(template);
                initIssuedActions(service, template);
                templateName = "aorta.medicine.";
                updatemedicineFromTemplate(templateName);
                aorticDissectionBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void GBBtn_Click(object sender, EventArgs e)
        {
            if (!"gb.medicine.".Equals(templateName) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();
                DataService service = new DataService();
                DdtAnamnesis template = service.queryObject<DdtAnamnesis>(@"SELECT * FROM ddt_anamnesis WHERE dsb_template=true AND dss_template_name='" + GB_TYPE + "'");
                initializeAnamnesis(template);
                initIssuedActions(service, template);
                templateName = "gb.medicine.";
                updatemedicineFromTemplate(templateName);
                GBBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void PIKSBtn_Click(object sender, EventArgs e)
        {
            if (!"nk.medicine.".Equals(templateName) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();
                DataService service = new DataService();
                DdtAnamnesis template = service.queryObject<DdtAnamnesis>(@"SELECT * FROM ddt_anamnesis WHERE dsb_template=true AND dss_template_name='" + PIKS_TYPE + "'");
                initializeAnamnesis(template);
                initIssuedActions(service, template);
                templateName = "nk.medicine.";
                updatemedicineFromTemplate(templateName);
                PIKSBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void PIKVIKBtn_Click(object sender, EventArgs e)
        {
            if (!"hobl.medicine.".Equals(templateName) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();
                DataService service = new DataService();
                DdtAnamnesis template = service.queryObject<DdtAnamnesis>(@"SELECT * FROM ddt_anamnesis WHERE dsb_template=true AND dss_template_name='" + PIKVIK_TYPE + "'");
                initializeAnamnesis(template);
                initIssuedActions(service, template);
                templateName = "hobl.medicine.";
                updatemedicineFromTemplate(templateName);
                PIKVIKBtn.BackColor = Color.LightSkyBlue;

            }
        }

        private void DEPBtn_Click(object sender, EventArgs e)
        {
            if (!"dep.medicine.".Equals(templateName) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();
                DataService service = new DataService();
                DdtAnamnesis template = service.queryObject<DdtAnamnesis>(@"SELECT * FROM ddt_anamnesis WHERE dsb_template=true AND dss_template_name='" + DEP_TYPE + "'");
                initializeAnamnesis(template);
                initIssuedActions(service, template);
                templateName = "dep.medicine.";
                updatemedicineFromTemplate(templateName);
                DEPBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void deathBtn_Click(object sender, EventArgs e)
        {
            if (!"death.medicine.".Equals(templateName) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();
                DataService service = new DataService();
                DdtAnamnesis template = service.queryObject<DdtAnamnesis>(@"SELECT * FROM ddt_anamnesis WHERE dsb_template=true AND dss_template_name='" + DEATH_TYPE + "'");
                initializeAnamnesis(template);
                initIssuedActions(service, template);
                templateName = "death.medicine.";
                updatemedicineFromTemplate(templateName);
                deathBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void chronicMA_Click(object sender, EventArgs e)
        {
            accompanyingIllnessesTxt.Text += getDefaultValueForType(accompanyingIllnessesTxt.Name, MA_TYPE) + " ";
        }

        private void chronicGB3_Click(object sender, EventArgs e)
        {
            accompanyingIllnessesTxt.Text += getDefaultValueForType(accompanyingIllnessesTxt.Name, GB_TYPE) + " ";
        }

        private void chronicDEP3_Click(object sender, EventArgs e)
        {
            accompanyingIllnessesTxt.Text += getDefaultValueForType(accompanyingIllnessesTxt.Name, DEP_TYPE) + " ";
        }

        private void chronicSD_Click(object sender, EventArgs e)
        {
            accompanyingIllnessesTxt.Text += getDefaultValueForType(accompanyingIllnessesTxt.Name, SD_TYPE) + " ";
        }

        private void chronicHOBL_Click(object sender, EventArgs e)
        {
            accompanyingIllnessesTxt.Text += getDefaultValueForType(accompanyingIllnessesTxt.Name, HOBL_TYPE) + " ";
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
            alcoholProtocolBtn.Visible = false;
        }

        private void alcoholBtn_Click(object sender, EventArgs e)
        {
            anamnesisVitaeTxt.Text = getDefaultValueForType(anamnesisVitaeTxt.Name, YES_TYPE);
            alcoholProtocolBtn.Visible = true;
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

        private void depRadio_CheckedChanged(object sender, EventArgs e)
        {
            justificationTxt.Text = getDefaultValueForType(justificationTxt.Name, DT_TYPE);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (save())
            {
                Close();
            }
        }

        private void AddIssuedMedicine_Click(object sender, EventArgs e)
        {
            issuedMedicineContainer.addMedicineBox();
        }

        private void alcoholProtocolBtn_Click(object sender, EventArgs e)
        {
            AlcoIntoxication form = new AlcoIntoxication(hospitalSession);
            form.ShowDialog();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (save())
            {
                ITemplateProcessor te = TemplateProcessorManager.getProcessorByObjectType(DdtAnamnesis.TABLE_NAME);
                if (te != null)
                {
                    string path = te.processTemplate(hospitalSession.ObjectId, anamnesis.ObjectId, null);
                    TemplatesUtils.showDocument(path);
                }
            }

        }

        private void stPresensTemplates_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            MouseEventArgs mouseArgs = e as MouseEventArgs;
            if (isSureChangeTemplate())
            {
                templateChanger.Show(mouseArgs.X, mouseArgs.Y, btn, "dss_st_presens", (value) => stPresensTxt.Text = (string)value);
            }
        }

        private void diagnosisTemplateBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            MouseEventArgs mouseArgs = e as MouseEventArgs;
            if (isSureChangeTemplate())
            {
                templateChanger.Show(mouseArgs.X, mouseArgs.Y, btn, "dss_diagnosis", (value) => diagnosisTxt.Text = (string)value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            MouseEventArgs mouseArgs = e as MouseEventArgs;
            if (isSureChangeTemplate())
            {
                templateChanger.Show(mouseArgs.X, mouseArgs.Y, btn, "dss_template_name", (value) =>
                {
                    if (value != null)
                    {
                        updatemedicineFromTemplate((string)value);
                    }
                });

            }
        }

        private void accompanyingIllnessesTxt_TextChanged(object sender, EventArgs e)
        {
            string illness = string.Intern(accompanyingIllnessesTxt.Text);
            string diagnosis = String.Intern(diagnosisTxt.Text);
            int i = 0;
            StringBuilder str = new StringBuilder();
            while (illness.Length > 0 && i <= illness.Length - 1)
            {
                char c = illness[i];
                str.Append(c);
                if (c == ',' || c == '.' || c == '/' || i == illness.Length - 1)
                {
                    if (diagnosis.IndexOf(str.ToString()) < 0)
                    {
                        diagnosisTxt.Text += str.ToString();
                    }
                    illness = illness.Replace(str.ToString(), "");
                    str.Clear();
                    i = 0;
                }
                i++;
            }
        }

        private void addIssuedAction_Click(object sender, EventArgs e)
        {
            issuedActionContainer.addMedicineBox();
        }

        private void FirstInspection_FormClosing(object sender, FormClosingEventArgs e)
        {
            SilentSaver.clearForm();
        }

        #endregion

    }
}
