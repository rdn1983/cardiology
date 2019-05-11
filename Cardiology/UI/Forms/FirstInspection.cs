using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;
using Cardiology.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using DdtValues = Cardiology.Data.Model2.DdtValues;

namespace Cardiology.UI.Forms
{
    public partial class FirstInspection : Form, IAutoSaveForm
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
        private const string DT_TYPE = "dt";

        private readonly object syncLock = new object();

        private IDbDataService service;
        private DdtHospital hospitalSession;
        private DdtAnamnesis anamnesis;
        private DdvPatient patient;
        private bool acceptTemplate = false;
        private string templateName;

        private readonly IList<DdtIssuedMedicine> medicineList = new List<DdtIssuedMedicine>();

        public FirstInspection(IDbDataService service, DdtHospital hospitalitySession)
        {
            this.service = service;
            this.hospitalSession = hospitalitySession;
            InitializeComponent();
            SilentSaver.setForm(this);

            anamnesis = service.GetDdtAnamnesisService().GetByHospitalSessionId(hospitalSession.ObjectId);

            InitPatientInfo();
            InitDiagnosis();

            InitializeAnamnesis(anamnesis);
            InitIssuedMedicine();
            initIssuedActions(anamnesis);
            InitAdmissionAnalysis();
            InitDoctorComboBox();
            initAlco();

            HighlightChronicButtons();
        }

        private void InitPatientInfo()
        {
            patient = service.GetDdvPatientService().GetById(hospitalSession.Patient);
            if (patient != null)
            {
                patientInitialsLbl.Text = patient.ShortName;
                if (anamnesis == null)
                {
                    if (patient.Sd)
                    {
                        IList<DdtCure> medicineTemplates = service.GetDdtCureService().GetListByTemplate("sd");
                        foreach(DdtCure cure in medicineTemplates) {
                            DdtIssuedMedicine med = new DdtIssuedMedicine();
                            med.Cure = cure.ObjectId;

                            AddIssuedMedicine(med, cure);
                        }
                    }
                }
            }
        }

        private void AddIssuedMedicine(DdtIssuedMedicine med, DdtCure cure)
        {
            medicineList.Add(med);           

            FlowLayoutPanel ll = new FlowLayoutPanel();
            ll.FlowDirection = FlowDirection.LeftToRight;
            ll.Width = 700;
            ll.AutoSize = true;

            ComboBox cureTypeControl = new ComboBox();
            cureTypeControl.Width = 250;
            CommonUtils.InitCureTypeComboboxValues(DbDataService.GetInstance(), cureTypeControl);
            if(cure != null && cure.CureType != null)
            {
                for (int index = 0; index < cureTypeControl.Items.Count; index++)
                {
                    DdtCureType ct = (DdtCureType) cureTypeControl.Items[index];
                    if(ct.ObjectId == cure.CureType)
                    {
                        cureTypeControl.SelectedIndex = index;
                        break;
                    }
                }
            }
            ll.Controls.Add(cureTypeControl);

            ComboBox cureControl = new ComboBox();
            cureControl.Width = 350;

            DdtCureType cureType = (DdtCureType)cureTypeControl.SelectedItem;
            if(cureType != null)
            {
                CommonUtils.InitCureComboboxValuesByTypeId(DbDataService.GetInstance(), cureControl, cureType.ObjectId);
            }

            if (cure != null && cure.ObjectId != null)
            {
                for (int index = 0; index < cureControl.Items.Count; index++)
                {
                    DdtCure c = (DdtCure)cureControl.Items[index];
                    if (c.ObjectId == cure.ObjectId)
                    {
                        cureControl.SelectedIndex = index;
                        break;
                    }
                }
            }
            cureControl.SelectedIndexChanged += delegate (object sender2, EventArgs args)
            {
                med.Cure = ((DdtCure)cureControl.SelectedItem).ObjectId;
            };
            ll.Controls.Add(cureControl);

            cureTypeControl.SelectedIndexChanged += delegate (object sender2, EventArgs args)
            {
                DdtCureType selectedVal = (DdtCureType)cureTypeControl.SelectedItem;
                CommonUtils.InitCureComboboxValuesByTypeId(DbDataService.GetInstance(), cureControl, selectedVal.ObjectId);
            };

            Button remove = new Button
            {
                Image = Properties.Resources.remove,
                Size = new Size(25, 25),
                UseVisualStyleBackColor = true
            };
            ll.Controls.Add(remove);

            remove.Click += delegate (object sender2, EventArgs args)
            {
                medicineList.Remove(med);
                layout.Controls.Remove(ll);
            };
            layout.Controls.Add(ll);
        }

        private void InitDoctorComboBox()
        {
            String id = anamnesis == null ? hospitalSession.CuringDoctor : anamnesis.Doctor;
            ControlUtils.InitDoctorsByGroupName(this.service.GetDdvDoctorService(), docBox, "cardioreanimation_department");
            docBox.SelectedValue = id;
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

            if (patient.Sd)
            {
                if (!accompanyingIllnessesTxt.Text.Contains("Сахарный диабет"))
                {
                    accompanyingIllnessesTxt.Text += "Сахарный диабет 2 типа, среднетяжелого течения, субкомпенсация. \n";
                }
                if (!diagnosisTxt.Text.Contains("Сахарный диабет"))
                {
                    diagnosisTxt.Text += "Сахарный диабет 2 типа, среднетяжелого течения, субкомпенсация. \n";
                }
            }

        }

        private void initAlco()
        {
            String sql = String.Format(CultureInfo.CurrentCulture, "SELECT r_object_id FROM ddt_alco_protocol WHERE dsid_hospitality_session = '{0}'", anamnesis?.HospitalitySession);
            string alcoProtocolId = service.GetString(sql);
            if (alcoProtocolId != null)
            {
                alcoholBtn_Click(null, null);
            }

            UpdateAlcoProtocolVisibility();
        }

        private void InitIssuedMedicine()
        {
            DdtIssuedMedicineList medList =
                service.GetDdtIssuedMedicineListService().GetListByParentId(anamnesis?.ObjectId);
            if (medList != null)
            {
                IList<DdtIssuedMedicine> list = DbDataService.GetInstance().GetDdtIssuedMedicineService().GetListByMedicineListId(medList.ObjectId);
                foreach(DdtIssuedMedicine med in list)
                {
                    DdtCure cure = DbDataService.GetInstance().GetDdtCureService().GetById(med.Cure);
                    AddIssuedMedicine(med, cure);
                }
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

        private void HighlightChronicButtons()
        {
            if (accompanyingIllnessesTxt.Text != null && accompanyingIllnessesTxt.Text.Length > 0)
            {
                string templateValue = getDefaultValueForType(accompanyingIllnessesTxt.Name, MA_TYPE);
                if (accompanyingIllnessesTxt.Text.Contains(templateValue))
                {
                    chronicMA.Font = new Font(chronicMA.Font, FontStyle.Bold);
                }
                else
                {
                    chronicMA.Font = new Font(chronicMA.Font, FontStyle.Regular);
                }

                templateValue = getDefaultValueForType(accompanyingIllnessesTxt.Name, GB_TYPE);
                if (accompanyingIllnessesTxt.Text.Contains(templateValue))
                {
                    chronicGB3.Font = new Font(chronicGB3.Font, FontStyle.Bold);
                }
                else
                {
                    chronicGB3.Font = new Font(chronicGB3.Font, FontStyle.Regular);
                }

                templateValue = getDefaultValueForType(accompanyingIllnessesTxt.Name, DEP_TYPE);
                if (accompanyingIllnessesTxt.Text.Contains(templateValue))
                {
                    chronicDEP3.Font = new Font(chronicDEP3.Font, FontStyle.Bold);
                }
                else
                {
                    chronicDEP3.Font = new Font(chronicDEP3.Font, FontStyle.Regular);
                }

                templateValue = getDefaultValueForType(accompanyingIllnessesTxt.Name, SD_TYPE);
                if (accompanyingIllnessesTxt.Text.Contains(templateValue))
                {
                    chronicSD.Font = new Font(chronicSD.Font, FontStyle.Bold);
                }
                else
                {
                    chronicSD.Font = new Font(chronicSD.Font, FontStyle.Regular);
                }

                templateValue = getDefaultValueForType(accompanyingIllnessesTxt.Name, HOBL_TYPE);
                if (accompanyingIllnessesTxt.Text.Contains(templateValue))
                {
                    chronicHOBL.Font = new Font(chronicHOBL.Font, FontStyle.Bold);
                }
                else
                {
                    chronicHOBL.Font = new Font(chronicHOBL.Font, FontStyle.Regular);
                }
            } else
            {
                chronicMA.Font = new Font(chronicMA.Font, FontStyle.Regular);
                chronicGB3.Font = new Font(chronicGB3.Font, FontStyle.Regular);
                chronicDEP3.Font = new Font(chronicDEP3.Font, FontStyle.Regular);
                chronicSD.Font = new Font(chronicSD.Font, FontStyle.Regular);
                chronicHOBL.Font = new Font(chronicHOBL.Font, FontStyle.Regular);
            }
        }

        private void UpdateAlcoProtocolVisibility()
        {
            string templateName = getDefaultValueForType(anamnesisVitaeTxt.Name, YES_TYPE);
            alcoholProtocolBtn.Visible = anamnesisVitaeTxt.Text != null && anamnesisVitaeTxt.Text.Contains(templateName);
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

        public bool Save()
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
            SaveIssuedMedicine(service);
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

        private void SaveIssuedMedicine(IDbDataService service)
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
            service.GetDdtIssuedMedicineListService().Save(medList);

            IList<DdtIssuedMedicine> list = service.GetDdtIssuedMedicineService().GetListByMedicineListId(medList.ObjectId);
            //Добавляем текущий список
            foreach(DdtIssuedMedicine med in medicineList)
            {
                if(med.Cure != null)
                {
                    med.MedList = medList.ObjectId;
                    service.GetDdtIssuedMedicineService().Save(med);
                }                
            }

            //Удаляем то, что было в списке, а сейчас нет
            foreach(DdtIssuedMedicine old in list)
            {
                bool found = false;
                foreach(DdtIssuedMedicine med in medicineList)
                {
                    if(old.ObjectId == med.ObjectId)
                    {
                        found = true;
                        break;
                    }
                }
                if(!found)
                {
                    service.GetDdtIssuedMedicineService().Delete(old.ObjectId);
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

        private void UpdateIssuedMedicineListFromTemplate(string template)
        {
            IList<DdtCure> medicineTemplates = service.GetDdtCureService().GetListByTemplate(template);
            if (patient != null && patient.Sd)
            {
                IList<DdtCure> sdMedTemplate = service.GetDdtCureService().GetListByTemplate("sd");
                foreach (DdtCure cur in sdMedTemplate)
                {
                    medicineTemplates.Add(cur);
                }
                foreach(DdtCure cur in medicineTemplates)
                {
                    if(cur.Name.Equals("Стол ОВД", StringComparison.Ordinal))
                    {
                        medicineTemplates.Remove(cur);
                        break;
                    }
                }
            }

            medicineList.Clear();
            foreach (DdtCure cure in medicineTemplates)
            {
                DdtIssuedMedicine med = new DdtIssuedMedicine();
                med.Cure = cure.ObjectId;
                AddIssuedMedicine(med, cure);
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
            if (!"oks.medicine.".Equals(templateName, StringComparison.Ordinal) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(OKSUP_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
                templateName = "oks.medicine.";
                UpdateIssuedMedicineListFromTemplate(templateName);
                OKSUpBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void OKSDownBtn_Click(object sender, EventArgs e)
        {
            if (!"okslongs.medicine.".Equals(templateName, StringComparison.Ordinal) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(OKSDOWN_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
                templateName = "okslongs.medicine.";
                UpdateIssuedMedicineListFromTemplate(templateName);
                OKSDownBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void KAGBtn_Click(object sender, EventArgs e)
        {
            if (!"kag.medicine.".Equals(templateName, StringComparison.Ordinal) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(KAG_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
                templateName = "kag.medicine.";
                UpdateIssuedMedicineListFromTemplate(templateName);
                KAGBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void aorticDissectionBtn_Click(object sender, EventArgs e)
        {
            if (!"aorta.medicine.".Equals(templateName, StringComparison.Ordinal) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(AORTA_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
                templateName = "aorta.medicine.";
                UpdateIssuedMedicineListFromTemplate(templateName);
                aorticDissectionBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void GBBtn_Click(object sender, EventArgs e)
        {
            if (!"gb.medicine.".Equals(templateName, StringComparison.Ordinal) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(GB_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
                templateName = "gb.medicine.";
                UpdateIssuedMedicineListFromTemplate(templateName);
                GBBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void PIKSBtn_Click(object sender, EventArgs e)
        {
            if (!"nk.medicine.".Equals(templateName, StringComparison.Ordinal) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(PIKS_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
                templateName = "nk.medicine.";
                UpdateIssuedMedicineListFromTemplate(templateName);
                PIKSBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void PIKVIKBtn_Click(object sender, EventArgs e)
        {
            if (!"hobl.medicine.".Equals(templateName, StringComparison.Ordinal) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(PIKVIK_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
                templateName = "hobl.medicine.";
                UpdateIssuedMedicineListFromTemplate(templateName);
                PIKVIKBtn.BackColor = Color.LightSkyBlue;

            }
        }

        private void DEPBtn_Click(object sender, EventArgs e)
        {
            if (!"dep.medicine.".Equals(templateName, StringComparison.Ordinal) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(DEP_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
                templateName = "dep.medicine.";
                UpdateIssuedMedicineListFromTemplate(templateName);
                DEPBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void deathBtn_Click(object sender, EventArgs e)
        {
            if (!"death.medicine.".Equals(templateName, StringComparison.Ordinal) && isSureChangeTemplate())
            {
                acceptTemplate = true;
                clearSelection();

                DdtAnamnesis template = service.GetDdtAnamnesisService().GetByTemplateName(DEATH_TYPE);
                InitializeAnamnesis(template);
                initIssuedActions(template);
                templateName = "death.medicine.";
                UpdateIssuedMedicineListFromTemplate(templateName);
                deathBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void chronicMA_Click(object sender, EventArgs e)
        {
            string templateValue = getDefaultValueForType(accompanyingIllnessesTxt.Name, MA_TYPE);
            ToggleIllnessText(templateValue, false);
        }

        private void chronicGB3_Click(object sender, EventArgs e)
        {
            string templateValue = getDefaultValueForType(accompanyingIllnessesTxt.Name, GB_TYPE);
            ToggleIllnessText(templateValue, true);
        }

        private void chronicDEP3_Click(object sender, EventArgs e)
        {
            string templateValue = getDefaultValueForType(accompanyingIllnessesTxt.Name, DEP_TYPE);
            ToggleIllnessText(templateValue, true);
        }

        private void chronicSD_Click(object sender, EventArgs e)
        {
            string templateValue = getDefaultValueForType(accompanyingIllnessesTxt.Name, SD_TYPE);
            ToggleIllnessText(templateValue, true);
        }

        private void chronicHOBL_Click(object sender, EventArgs e)
        {
            string templateValue = getDefaultValueForType(accompanyingIllnessesTxt.Name, HOBL_TYPE);
            ToggleIllnessText(templateValue, true);
        }

        private void ToggleIllnessText(string text, Boolean append)
        {
            if (accompanyingIllnessesTxt.Text == null)
            {
                accompanyingIllnessesTxt.Text = text;
            }
            else
            {
                if (accompanyingIllnessesTxt.Text.Contains(text))
                {
                    accompanyingIllnessesTxt.Text = accompanyingIllnessesTxt.Text.Replace(text, "");
                }
                else
                {
                    if (append)
                    {
                        accompanyingIllnessesTxt.Text += text + " ";
                    }
                    else
                    {
                        accompanyingIllnessesTxt.Text = text + " " + accompanyingIllnessesTxt.Text;
                    }
                }
            }

            if (accompanyingIllnessesTxt.Text != null)
            {
                accompanyingIllnessesTxt.Text = accompanyingIllnessesTxt.Text.Trim();
            }

            if(accompanyingIllnessesTxt.Text == null)
            {
                accompanyingIllnessesTxt.Text = "";
            }

            if (diagnosisTxt.Text == null)
            {
                diagnosisTxt.Text = "";
            }

            if (accompanyingIllnessesTxt.Text.Contains(text) && !diagnosisTxt.Text.Contains(text))
            {
                diagnosisTxt.Text += text + " ";
            }
            else if (!accompanyingIllnessesTxt.Text.Contains(text) && diagnosisTxt.Text.Contains(text)) {
                diagnosisTxt.Text = diagnosisTxt.Text.Replace(text, "");
            }
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

        private void depRadio_CheckedChanged(object sender, EventArgs e)
        {
            justificationTxt.Text = getDefaultValueForType(justificationTxt.Name, DT_TYPE);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            lock (syncLock)
            {
                if (Save())
                {
                    Close();
                }
            }
        }

        private void AddIssuedMedicine_Click(object sender, EventArgs e)
        {
            DdtIssuedMedicine med = new DdtIssuedMedicine();
            AddIssuedMedicine(med, null);
        }

        private void alcoholProtocolBtn_Click(object sender, EventArgs e)
        {
            AlcoIntoxication form = new AlcoIntoxication(service, hospitalSession);
            form.ShowDialog();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            lock (syncLock)
            {
                if (Save())
                {
                    ITemplateProcessor te = TemplateProcessorManager.getProcessorByObjectType(DdtAnamnesis.NAME);
                    if (te != null)
                    {
                        string path = te.processTemplate(service, hospitalSession.ObjectId, anamnesis.ObjectId, null);
                        TemplatesUtils.ShowDocument(path);
                    }
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
                       UpdateIssuedMedicineListFromTemplate((string)value);
                   }
               });

            }
        }

        private void accompanyingIllnessesTxt_TextChanged(object sender, EventArgs e)
        {
            HighlightChronicButtons();
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

        private void AnamnesisVitaeTxt_TextChanged(object sender, EventArgs e)
        {
            UpdateAlcoProtocolVisibility();
        }
    }
}
