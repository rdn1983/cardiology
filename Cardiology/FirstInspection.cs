﻿using Cardiology.Model;
using System;
using System.Windows.Forms;
using Cardiology.Utils;
using System.Collections.Generic;
using System.Collections;

namespace Cardiology
{
    public partial class FirstInspection : Form
    {
        private const string FIRST_ANALYSIS_QRY_TEMPLATE = @"SELECT * FROM {0} WHERE dsb_admission_analysis=true and dsid_hospitality_session='{1}'";
        private const int EGDS_TAB_INDX = 1;
        private const int EKG_TAB_INDX = 0;
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

        private DdtHospital hospitalSession;
        private DdtAnamnesis anamnesis;
        private List<DdtIssuedMedicine> issuedMedicine;

        public FirstInspection(DdtHospital hospitalitySession)
        {
            this.hospitalSession = hospitalitySession;
            InitializeComponent();

            DataService service = new DataService();
            initializeAnamnesis(service);
            initIssuedMedicine(service);
            initDiagnosis();
            initAdmissionAnalysis(service);
        }

        private void initAdmissionAnalysis(DataService service)
        {

            DdtUrineAnalysis firstAnalysis = service.queryObject<DdtUrineAnalysis>(string.Format(FIRST_ANALYSIS_QRY_TEMPLATE, DdtUrineAnalysis.TABLE_NAME, hospitalSession.ObjectId));
            if (firstAnalysis != null)
            {
                firstColorTxt.Text = firstAnalysis.DssColor;
                firstErythrocytesTxt.Text = firstAnalysis.DssErythrocytes;
                firstLeucocytesTxt.Text = firstAnalysis.DssLeukocytes;
                firstProteinTxt.Text = firstAnalysis.DssProtein;
            }
            DdtEgds firstEgdsAnalysis = service.queryObject<DdtEgds>(string.Format(FIRST_ANALYSIS_QRY_TEMPLATE, DdtEgds.TABLE_NAME, hospitalSession.ObjectId));
            if (firstEgdsAnalysis != null)
            {
                firstEgdsTxt.Text = firstEgdsAnalysis.DssEgds;
            }

            DdtEkg firstEkgAnalysis = service.queryObject<DdtEkg>(string.Format(FIRST_ANALYSIS_QRY_TEMPLATE, DdtEkg.TABLE_NAME, hospitalSession.ObjectId));
            if (firstEkgAnalysis != null)
            {
                regularEkgTxt.Text = firstEkgAnalysis.DssEkg;
            }
        }

        private void initDiagnosis()
        {
            diagnosisTxt.Text = hospitalSession.DssDiagnosis;
        }

        private void initializeAnamnesis(DataService service)
        {
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

        private void initIssuedMedicine(DataService service)
        {
            DdtIssuedMedicineList medList = service.queryObject<DdtIssuedMedicineList>(@"SELECT * FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='" +
                hospitalSession.ObjectId + "' AND dss_parent_type='ddt_anamnesis'");
            if (medList != null)
            {
                issuedMedicineControl1.Init(service, medList); 
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
            updatemedicineFromTemplate(OKSUP_TYPE + ".medicine");
        }

        private void OKSDownBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(OKSDOWN_TYPE);
            updatemedicineFromTemplate(OKSDOWN_TYPE + ".medicine");
        }

        private void KAGBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(KAG_TYPE);
            updatemedicineFromTemplate(KAG_TYPE + ".medicine");
        }

        private void aorticDissectionBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(AORTA_TYPE);
            updatemedicineFromTemplate(AORTA_TYPE + ".medicine");
        }

        private void GBBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(GB_TYPE);
            updatemedicineFromTemplate(GB_TYPE + ".medicine");
        }

        private void PIKSBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(PIKS_TYPE);
            updatemedicineFromTemplate(PIKS_TYPE + ".medicine");
        }

        private void PIKVIKBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(PIKVIK_TYPE);
            updatemedicineFromTemplate(PIKVIK_TYPE + ".medicine");
        }

        private void DEPBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(DEP_TYPE);
            updatemedicineFromTemplate(DEP_TYPE + ".medicine");
        }

        private void deathBtn_Click(object sender, EventArgs e)
        {
            fillControlsFromTemplate(DEATH_TYPE);
            updatemedicineFromTemplate(DEATH_TYPE + ".medicine");
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
            anamnesisAllergyTxt.Text = getDefaultValueForType(anamnesisAllergyTxt.Name, type);
            anamnesisEpidTxt.Text = getDefaultValueForType(anamnesisEpidTxt.Name, type);
        }

        private void updatemedicineFromTemplate(string template)
        {
            DataService service = new DataService();
            List<DdtCure> medicineTemplates = service.queryObjectsCollection<DdtCure>(@"Select cure.* from ddt_values vv, ddt_cure cure 
                            where vv.dss_name like '" + template + "%' AND vv.dss_value=cure.dss_name");
            issuedMedicineControl1.refreshData(service, medicineTemplates);
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool isNotValid = false;
            for (int i = 0; i < tabsContainer.TabCount; i++)
            {
                isNotValid |= !getIsValid(i);
            }

            if (!isNotValid)
            {
                DataService service = new DataService();

                saveAnamnesis(service);
                saveIssuedMedicine(service);
                saveUrineAnalysisTab(service);
                saveEgdsAnalysisTab(service);
                saveEkgAnalysisTab(service);
                saveBloodAnalysis(service);

                hospitalSession.DssDiagnosis = diagnosisTxt.Text;
                service.updateObject<DdtHospital>(hospitalSession, DdtHospital.TABLENAME, "r_object_id", hospitalSession.ObjectId);
                Close();
            }
        }

        #region saveTabsData

        private void saveBloodAnalysis(DataService service)
        {
            DdtIssuedMedicineList medList = service.queryObject<DdtIssuedMedicineList>(@"SELECT * FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='" +
                   hospitalSession.ObjectId + "' AND dss_parent_type='ddt_anamnesis'");

            if (isNeedSaveTab(BLOOD_TAB_INDX))
            {
                DdtBloodAnalysis bloodObj = service.queryObject<DdtBloodAnalysis>(string.Format(FIRST_ANALYSIS_QRY_TEMPLATE, DdtBloodAnalysis.TABLE_NAME, hospitalSession.ObjectId));
                if (bloodObj == null)
                {
                    bloodObj = new DdtBloodAnalysis();
                    bloodObj.DsidHospitalitySession = hospitalSession.ObjectId;
                    bloodObj.DsidDoctor = hospitalSession.DsidCuringDoctor;
                    bloodObj.DsidPatient = hospitalSession.DsidPatient;
                    bloodObj.DsbAdmissionAnalysis = true;
                }
                bloodObj.DsdAlt = altTxt.Text;
                bloodObj.DsdAmylase = amilazaTxt.Text;
                bloodObj.DsdAst = astTxt.Text;
                bloodObj.DsdBil = bilTxt.Text;
                bloodObj.DsdChlorine = chlorineTxt.Text;
                bloodObj.DsdCholesterolr = cholesterolTxt.Text;
                bloodObj.DsdCreatinine = kreatininTxt.Text;
                bloodObj.DsdHemoglobin = hemoglobinTxt.Text;
                bloodObj.DsdIron = ironTxt.Text;
                bloodObj.DsdKfk = kfkTxt.Text;
                bloodObj.DsdKfkMv = kfkMvTxt.Text;
                bloodObj.DsdLeucocytes = leucocytesTxt.Text;
                bloodObj.DsdPlatelets = plateletsTxt.Text;
                bloodObj.DsdPotassium = potassiumTxt.Text;
                bloodObj.DsdProtein = proteinTxt.Text;
                bloodObj.DsdSchf = schfTxt.Text;
                bloodObj.DsdSodium = sodiumTxt.Text;
                bloodObj.DsdSrp = srbTxt.Text;
                service.updateOrCreateIfNeedObject<DdtBloodAnalysis>(bloodObj, DdtBloodAnalysis.TABLE_NAME, bloodObj.RObjectId);

            }
        }

        private void saveAnamnesis(DataService service)
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

            string id = updateObject<DdtAnamnesis>(service, anamnesis, DdtAnamnesis.TABLE_NAME, anamnesis.ObjectId);
            anamnesis.ObjectId = id;
        }

        private void saveIssuedMedicine(DataService service)
        {
            List<DdtIssuedMedicine> meds = issuedMedicineControl1.getIssuedMedicines();
            if (meds.Count > 0)
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
                    string id = service.insertObject<DdtIssuedMedicineList>(medList, DdtIssuedMedicineList.TABLE_NAME);
                    medList.ObjectId = id;
                }
                foreach (DdtIssuedMedicine med in meds)
                {
                    med.DsidMedList = medList.ObjectId;
                    
                    service.updateOrCreateIfNeedObject<DdtIssuedMedicine>(med, DdtIssuedMedicine.TABLE_NAME, med.RObjectId);
                }
            }

        }

        private void saveUrineAnalysisTab(DataService service)
        {
            if (isNeedSaveTab(URINE_TAB_INDX))
            {
                DdtUrineAnalysis urineAnalysis = service.queryObject<DdtUrineAnalysis>(string.Format(FIRST_ANALYSIS_QRY_TEMPLATE, DdtUrineAnalysis.TABLE_NAME, hospitalSession.ObjectId));
                if (urineAnalysis == null)
                {
                    urineAnalysis = new DdtUrineAnalysis();
                    urineAnalysis.DsidHospitalitySession = hospitalSession.ObjectId;
                    urineAnalysis.DsidDoctor = hospitalSession.DsidCuringDoctor;
                    urineAnalysis.DsidPatient = hospitalSession.DsidPatient;
                    urineAnalysis.DsbAdmissionAnalysis = true;
                }
                urineAnalysis.DssColor = firstColorTxt.Text;
                urineAnalysis.DssErythrocytes = firstErythrocytesTxt.Text;
                urineAnalysis.DssLeukocytes = firstLeucocytesTxt.Text;
                urineAnalysis.DssProtein = firstProteinTxt.Text;

                updateObject<DdtUrineAnalysis>(service, urineAnalysis, DdtUrineAnalysis.TABLE_NAME, urineAnalysis.ObjectId);
            }
        }

        private void saveEgdsAnalysisTab(DataService service)
        {
            if (isNeedSaveTab(EGDS_TAB_INDX))
            {
                DdtEgds egds = service.queryObject<DdtEgds>(string.Format(FIRST_ANALYSIS_QRY_TEMPLATE, DdtEgds.TABLE_NAME, hospitalSession.ObjectId));
                if (egds == null)
                {
                    egds = new DdtEgds();
                    egds.DsidHospitalitySession = hospitalSession.ObjectId;
                    egds.DsidDoctor = hospitalSession.DsidCuringDoctor;
                    egds.DsidPatient = hospitalSession.DsidPatient;
                    egds.DsbAdmissionAnalysis = true;
                }
                egds.DssEgds = firstEgdsTxt.Text;
                updateObject<DdtEgds>(service, egds, DdtEgds.TABLE_NAME, egds.ObjectId);
            }
        }

        private void saveEkgAnalysisTab(DataService service)
        {
            if (isNeedSaveTab(EKG_TAB_INDX))
            {
                DdtEkg ekg = service.queryObject<DdtEkg>(string.Format(FIRST_ANALYSIS_QRY_TEMPLATE, DdtEkg.TABLE_NAME, hospitalSession.ObjectId));
                if (ekg == null)
                {
                    ekg = new DdtEkg();
                    ekg.DsidHospitalitySession = hospitalSession.ObjectId;
                    ekg.DsidDoctor = hospitalSession.DsidCuringDoctor;
                    ekg.DsidPatient = hospitalSession.DsidPatient;
                    ekg.DsbAdmissionAnalysis = true;
                }
                ekg.DssEkg = regularEkgTxt.Text;
                updateObject<DdtEkg>(service, ekg, DdtEkg.TABLE_NAME, ekg.ObjectId);
            }
        }

        private bool isNeedSaveTab(int tabindex)
        {
            switch (tabindex)
            {
                case URINE_TAB_INDX:
                    return CommonUtils.isNotBlank(firstColorTxt.Text) || CommonUtils.isNotBlank(firstErythrocytesTxt.Text) ||
                        CommonUtils.isNotBlank(firstLeucocytesTxt.Text) || CommonUtils.isNotBlank(firstProteinTxt.Text);
                case EGDS_TAB_INDX:
                    return CommonUtils.isNotBlank(firstEgdsTxt.Text);
                case EKG_TAB_INDX:
                    return CommonUtils.isNotBlank(regularEkgTxt.Text);
                case BLOOD_TAB_INDX:
                    return CommonUtils.isNotBlank(plateletsTxt.Text) || CommonUtils.isNotBlank(srbTxt.Text)
                        || CommonUtils.isNotBlank(sodiumTxt.Text) || CommonUtils.isNotBlank(schfTxt.Text)
                        || CommonUtils.isNotBlank(kreatininTxt.Text) || CommonUtils.isNotBlank(kfkTxt.Text)
                        || CommonUtils.isNotBlank(kfkMvTxt.Text) || CommonUtils.isNotBlank(ironTxt.Text)
                        || CommonUtils.isNotBlank(hemoglobinTxt.Text) || CommonUtils.isNotBlank(cholesterolTxt.Text)
                        || CommonUtils.isNotBlank(chlorineTxt.Text) || CommonUtils.isNotBlank(leucocytesTxt.Text)
                        || CommonUtils.isNotBlank(bilTxt.Text) || CommonUtils.isNotBlank(astTxt.Text)
                        || CommonUtils.isNotBlank(altTxt.Text) || CommonUtils.isNotBlank(proteinTxt.Text)
                        || CommonUtils.isNotBlank(potassiumTxt.Text);
                default: return false;
            }
        }

        private string updateObject<T>(DataService service, T obj, string tablName, string objId)
        {
            if (CommonUtils.isBlank(objId))
            {
                return service.insertObject<T>(obj, tablName);
            }
            else
            {
                service.updateObject<T>(obj, tablName, "r_object_id", objId);
                return objId;
            }
        }

        #endregion

        private void AddIssuedMedicine_Click(object sender, EventArgs e)
        {
            issuedMedicineControl1.addMedicineBox();
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

        private void depressionBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "депрессия ST в ";
        }

        private void negativeTBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "отрицательный T";
        }

        private void commaBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + ", ";
        }

        private void IBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "I";
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

        private void dashBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "-";
        }

        private void dotBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + ".";
        }

        private void spaceBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + " ";
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = "";
        }

        private void alcoholProtocolBtn_Click(object sender, EventArgs e)
        {
            AlcoIntoxication form = new AlcoIntoxication(hospitalSession);
            form.ShowDialog();
        }
    }
}
