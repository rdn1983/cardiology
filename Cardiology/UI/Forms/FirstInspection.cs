using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;
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

            anamnesis = service.GetDdtAnamnesisService().GetByHospitalSessionId(hospitalSession.ObjectId);

            InitializeAnamnesis(anamnesis);
            initIssuedMedicine();
            initIssuedActions(anamnesis);
            InitDiagnosis();
            InitAdmissionAnalysis();
            InitDoctorComboBox();
            InitPatientInfo();
        }

        private void InitPatientInfo()
        {
            DdvPatient patient = service.GetDdvPatientService().GetById(hospitalSession.Patient);
            if (patient != null)
            {
                patientInitialsLbl.Text = patient.ShortName;
                if (anamnesis == null)
                {
                    IList<DdtCure> medicineTemplates = service.GetDdtCureService().GetListByTemplate("sd");
                    issuedMedicineContainer.RefreshData(service, medicineTemplates);
                    if (patient.Sd)
                    {
                        accompanyingIllnessesTxt.Text += "Сахарный диабет 2 типа, среднетяжелого течения, субкомпенсация. \n";
                        diagnosisTxt.Text += "Сахарный диабет 2 типа, среднетяжелого течения, субкомпенсация. \n";
                    }
                }
            }
        }

        private void InitDoctorComboBox()
        {
            String id = anamnesis == null ? hospitalSession.CuringDoctor : anamnesis.Doctor;
            ControlUtils.InitDoctors(this.service.GetDdvDoctorService(), docBox, id);
        }

        private void InitAdmissionAnalysis()
        {
            DdtUrineAnalysis firstAnalysis = service.GetDdtUrineAnalysisService().GetByHospitalSessionAndParentId(hospitalSession.ObjectId, anamnesis?.ObjectId);
            urineAnalysisControl.refreshObject(firstAnalysis);

            DdtEgds firstEgdsAnalysis = service.GetDdtEgdsService().GetByHospitalSessionAndParentId(hospitalSession.ObjectId, anamnesis?.ObjectId);
            egdsAnalysisControl1.refreshObject(firstEgdsAnalysis);

            DdtBloodAnalysis blood = service.GetDdtBloodAnalysisService()
                .GetByHospitalSessionAndParentId(hospitalSession.ObjectId, anamnesis?.ObjectId);
            bloodAnalysisControl.refreshObject(blood);

            DdtEkg ekg = service.GetDdtEkgService().GetByHospitalSessionAndParentId(hospitalSession.ObjectId, anamnesis?.ObjectId);
            ekgAnalysisControlcs.refreshObject(ekg);
        }

        private void InitDiagnosis()
        {
            diagnosisTxt.Text = hospitalSession.Diagnosis;
        }

        private void InitializeAnamnesis(DdtAnamnesis anamnesis)
        {
            if (anamnesis != null)
            {
                acceptTemplate = true;
                if (!anamnesis.Template)
                {
                    accompanyingIllnessesTxt.Text = anamnesis.AccompanyingIllnesses;
                    anamnesisVitaeTxt.Text = anamnesis.AnamnesisVitae;
                    pastSurgeriesTxt.Text = anamnesis.PastSurgeries;
                }
                digestiveSystemTxt.Text = anamnesis.DigestiveSystem;
                urinarySystemTxt.Text = anamnesis.UrinarySystem;
                justificationTxt.Text = anamnesis.DiagnosisJustification;
                anamnesisMorbiTxt.Text = anamnesis.AnamnesisMorbi;
                complaintsTxt.Text = anamnesis.Complaints;
                drugsTxt.Text = anamnesis.DrugsIntoxication;
                stPresensTxt.Text = anamnesis.StPresens;
                cardiovascularSystemTxt.Text = anamnesis.CardiovascularSystem;
                respiratorySystemTxt.Text = anamnesis.RespiratorySystem;
                nervousSystemTxt.Text = anamnesis.NervousSystem;
                anamnesisEpidTxt.Text = anamnesis.AnamnesisEpid;
                diagnosisTxt.Text = anamnesis.Diagnosis;
                anamnesisAllergyTxt.Text = anamnesis.AnamnesisAllergy;
                operationCauseTxt.Text = anamnesis.OperationCause;
            }
        }

        private void initIssuedMedicine()
        {
            DdtIssuedMedicineList medList =
                service.GetDdtIssuedMedicineListService().GetListByParentId(anamnesis?.ObjectId);
            if (medList != null)
            {
                issuedMedicineContainer.Init(medList);
                templateName = medList.TemplateName;
            }
        }

        private void initIssuedActions(DdtAnamnesis parent)
        {
            if (parent != null)
            {
                IList<DdtIssuedAction> allActions =
                    service.GetDdtIssuedActionService().GetListByParentId(parent.ObjectId);
                issuedActionContainer.init(allActions);
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


            saveAnamnesis(service);
            saveIssuedMedicine(service);
            saveIssuedAction(service);

            ekgAnalysisControlcs.saveObject(hospitalSession, anamnesis.ObjectId, DdtAnamnesis.NAME);
            urineAnalysisControl.saveObject(hospitalSession, anamnesis.ObjectId, DdtAnamnesis.NAME);
            bloodAnalysisControl.saveObject(hospitalSession, anamnesis.ObjectId, DdtAnamnesis.NAME);
            egdsAnalysisControl1.saveObject(hospitalSession, anamnesis.ObjectId, DdtAnamnesis.NAME);

            hospitalSession.Diagnosis = diagnosisTxt.Text;
            service.GetDdtHospitalService().Save(hospitalSession);
            return true;
        }

        private void saveAnamnesis(IDbDataService service)
        {
            if (anamnesis == null)
            {
                anamnesis = new DdtAnamnesis();
                anamnesis.HospitalitySession = hospitalSession.ObjectId;
                anamnesis.Patient = hospitalSession.Patient;
                anamnesis.InspectionDate = DateTime.Now;
            }
            DdvDoctor doc = getSafeObjectValueUni<DdvDoctor>(docBox, new getValue<DdvDoctor>((ctrl) => (DdvDoctor)((ComboBox)ctrl).SelectedItem));
            anamnesis.Doctor = doc.ObjectId;

            anamnesis.AccompanyingIllnesses = getSafeStringValue(accompanyingIllnessesTxt);
            anamnesis.AnamnesisAllergy = getSafeStringValue(anamnesisAllergyTxt);
            anamnesis.AnamnesisEpid = getSafeStringValue(anamnesisEpidTxt);
            anamnesis.AnamnesisMorbi = getSafeStringValue(anamnesisMorbiTxt);
            anamnesis.AnamnesisVitae = getSafeStringValue(anamnesisVitaeTxt);
            anamnesis.CardiovascularSystem = getSafeStringValue(cardiovascularSystemTxt);
            anamnesis.Complaints = getSafeStringValue(complaintsTxt);
            anamnesis.DiagnosisJustification = getSafeStringValue(justificationTxt);
            anamnesis.DigestiveSystem = getSafeStringValue(digestiveSystemTxt);
            anamnesis.DrugsIntoxication = getSafeStringValue(drugsTxt);
            anamnesis.NervousSystem = getSafeStringValue(nervousSystemTxt);
            anamnesis.PastSurgeries = getSafeStringValue(pastSurgeriesTxt);
            anamnesis.RespiratorySystem = getSafeStringValue(respiratorySystemTxt);
            anamnesis.StPresens = getSafeStringValue(stPresensTxt);
            anamnesis.UrinarySystem = getSafeStringValue(urinarySystemTxt);
            anamnesis.Diagnosis = getSafeStringValue(diagnosisTxt);
            anamnesis.OperationCause = getSafeStringValue(operationCauseTxt);
            anamnesis.DiagnosisJustification = getSafeStringValue(justificationTxt);

            string id = service.GetDdtAnamnesisService().Save(anamnesis);
            anamnesis.ObjectId = id;
        }

        private void saveIssuedMedicine(IDbDataService service)
        {
            List<DdtIssuedMedicine> meds = getSafeObjectValueUni(issuedMedicineContainer,
                new getValue<List<DdtIssuedMedicine>>((ctrl) => ((IssuedMedicineContainer)ctrl).getIssuedMedicines(service)));

            List<DdtIssuedMedicine> meds2 = new List<DdtIssuedMedicine>();
            foreach (DdtIssuedMedicine med in meds)
            {
                if (med.Cure != null)
                {
                    meds2.Add(med);
                }
            }

            if (meds2.Count > 0)
            {
                DdtIssuedMedicineList medList = service.GetDdtIssuedMedicineListService().GetListByParentId(anamnesis.ObjectId);
                if (medList == null)
                {
                    medList = new DdtIssuedMedicineList();
                    medList.Doctor = hospitalSession.DutyDoctor;
                    medList.HospitalitySession = hospitalSession.ObjectId;
                    medList.Patient = hospitalSession.Patient;
                    medList.ParentType = "ddt_anamnesis";
                    medList.ParentId = anamnesis.ObjectId;
                    medList.IssuingDate = DateTime.Now;
                }
                medList.TemplateName = templateName;
                string id = service.GetDdtIssuedMedicineListService().Save(medList);
                medList.ObjectId = id;
                foreach (DdtIssuedMedicine med in meds2)
                {
                    med.MedList = id;
                    service.GetDdtIssuedMedicineService().Save(med);
                }
            }

        }

        private void saveIssuedAction(IDbDataService service)
        {
            List<DdtIssuedAction> meds = getSafeObjectValueUni(issuedActionContainer,
               new getValue<List<DdtIssuedAction>>((ctrl) => ((IssuedActionContainer)ctrl).getIssuedMedicines(service)));
            if (meds.Count > 0)
            {
                foreach (DdtIssuedAction med in meds)
                {
                    if (string.IsNullOrEmpty(med.ObjectId) || string.IsNullOrEmpty(med.Doctor))
                    {
                        med.ParentId = anamnesis.ObjectId;
                        med.Doctor = hospitalSession.CuringDoctor;
                        med.Patient = hospitalSession.Patient;
                        med.HospitalitySession = hospitalSession.ObjectId;
                        med.IssuingDate = DateTime.Now;
                    }

                    med.ObjectId = service.GetDdtIssuedActionService().Save(med);
                }
                issuedActionContainer.init(meds);
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
            IList<DdtCure> medicineTemplates = service.GetDdtCureService().GetListByTemplate(template);
            clearOldMedList(service);
            issuedMedicineContainer.RefreshData(service, medicineTemplates);
        }

        private void clearOldMedList(IDbDataService service)
        {
            DdtIssuedMedicineList medList = service.GetDdtIssuedMedicineListService().GetListByHospitalId(hospitalSession.ObjectId);
            if (medList != null)
            {
                service.Delete(DdtIssuedMedicine.NAME, medList.ObjectId);
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

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(OKSUP_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
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

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(OKSDOWN_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
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

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(KAG_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
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

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(AORTA_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
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

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(GB_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
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

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(PIKS_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
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

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(PIKVIK_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
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

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(DEP_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
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

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(DEATH_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
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
            issuedMedicineContainer.addMedicineBox(service);
        }

        private void alcoholProtocolBtn_Click(object sender, EventArgs e)
        {
            AlcoIntoxication form = new AlcoIntoxication(service, hospitalSession);
            form.ShowDialog();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (save())
            {
                ITemplateProcessor te = TemplateProcessorManager.getProcessorByObjectType(DdtAnamnesis.NAME);
                if (te != null)
                {
                    string path = te.processTemplate(service, hospitalSession.ObjectId, anamnesis.ObjectId, null);
                    TemplatesUtils.ShowDocument(path);
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
            issuedActionContainer.addMedicineBox(service);
        }

        private void FirstInspection_FormClosing(object sender, FormClosingEventArgs e)
        {
            SilentSaver.clearForm();
        }

        #endregion

    }
}
