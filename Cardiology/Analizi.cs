using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class Analizi : Form
    {
        private const int EGDS_TAB_INDX = 1;
        private const int EKG_TAB_INDX = 0;
        private const int SPECIALIST_TAB_INDX = 6;
        private const int HOLTER_TAB_INDX = 5;
        private const int XRAY_TAB_INDX = 4;
        private const int URINE_TAB_INDX = 2;
        private const int UZI_TAB_INDX = 3;
        private const int KAG_TAB_INDX = 7;
        private const string REGULAR_ANALYSIS_QRY_TEMPLATE = @"SELECT * FROM {0} WHERE r_object_id='{1}'";
        private const string FIRST_ANALYSIS_QRY_TEMPLATE = @"SELECT * FROM {0} WHERE dsb_admission_analysis=true and dsid_hospitality_session='{1}'";

        private DdtHospital hospitalitySession;
        private DdtPatientAnalysis patientAnalysis;

        public Analizi(DdtHospital hospitalitySession, DdtPatientAnalysis analysis)
        {
            this.hospitalitySession = hospitalitySession;
            this.patientAnalysis = analysis;
            InitializeComponent();
            

            DdtKag kag = null;

            if (patientAnalysis != null)
            {
                DataService service = new DataService();
                DdtUzi uziObj = service.queryObject<DdtUzi>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtUzi.TABLE_NAME, patientAnalysis.DsisUzi));
                DdtSpecialistConclusion specialistConclusion = service.queryObject<DdtSpecialistConclusion>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtSpecialistConclusion.TABLE_NAME, patientAnalysis.DsidSpecialistConclusion));
                DdtHolter holter = service.queryObject<DdtHolter>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtHolter.TABLE_NAME, patientAnalysis.DsidHolter));
                DdtXRay xRay = service.queryObject<DdtXRay>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtXRay.TABLE_NAME, patientAnalysis.DsidXray));
                DdtUrineAnalysis urineAnalysis = service.queryObject<DdtUrineAnalysis>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtUrineAnalysis.TABLE_NAME, patientAnalysis.DsisUrineAnalysis));
                DdtEgds egds = service.queryObject<DdtEgds>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtEgds.TABLE_NAME, patientAnalysis.DsidEgds));
                kag = service.queryObject<DdtKag>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtKag.TABLE_NAME, patientAnalysis.DsidKag));
                DdtEkg ekg = service.queryObject<DdtEkg>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtEkg.TABLE_NAME, patientAnalysis.DsidEkg));

                initUziTab(uziObj);
                initHolterTab(holter);
                initSpecialistConslusionTab(specialistConclusion);
                initXRay(xRay);
                initUrineAnalysis(urineAnalysis, service);
                initEgdsAnalysis(egds, service);
                initEkgAnalysis(ekg, service);
            }
            initKagAnalysis(kag);
        }

        #region Initialize Tab Code

        private void initUziTab(DdtUzi uziObj)
        {
            if (CommonUtils.isNotBlank(patientAnalysis.DsisUzi) && uziObj != null)
            {
                ehoKgTxt.Text = uziObj.DssEhoKg;
                cdsTxt.Text = uziObj.DssCds;
                pleursUziTxt.Text = uziObj.DssPleursUzi;
                uzdTxt.Text = uziObj.DssUzdBca;
                uziObpTxt.Text = uziObj.DssUziObp;
            }
        }

        private void initSpecialistConslusionTab(DdtSpecialistConclusion specialistConclusion)
        {
            if (CommonUtils.isNotBlank(patientAnalysis.DsidSpecialistConclusion) && specialistConclusion != null)
            {
                neurologTxt.Text = specialistConclusion.DssNeurolog;
                surgeonTxt.Text = specialistConclusion.DssSurgeon;
                neuroSurgeonTxt.Text = specialistConclusion.DssNeuroSurgeon;
                endocrinologistTx.Text = specialistConclusion.DssEndocrinologist;
            }
        }

        private void initHolterTab(DdtHolter holter)
        {
            if (CommonUtils.isNotBlank(patientAnalysis.DsidHolter) && holter != null)
            {
                holterTxt.Text = holter.DssHolter;
                monitoringAdTxt.Text = holter.DssMonitoringAd;
            }
        }

        private void initXRay(DdtXRay xRay)
        {
            if (CommonUtils.isNotBlank(patientAnalysis.DsidXray) && xRay != null)
            {
                chestXRayTxt.Text = xRay.DssChestXray;
                controlRadiographyTxt.Text = xRay.DssControlRadiography;
                ktTxt.Text = xRay.DssKt;
                mrtTxt.Text = xRay.DssMrt;
            }
        }

        private void initUrineAnalysis(DdtUrineAnalysis urineAnalysis, DataService service)
        {
            if (CommonUtils.isNotBlank(patientAnalysis.DsisUrineAnalysis) && urineAnalysis != null)
            {
                colorTxt.Text = urineAnalysis.DssColor;
                erythrocytesTxt.Text = urineAnalysis.DssErythrocytes;
                leukocytesTxt.Text = urineAnalysis.DssLeukocytes;
                proteinTxt.Text = urineAnalysis.DssProtein;
            }

            DdtUrineAnalysis firstAnalysis = service.queryObject<DdtUrineAnalysis>(string.Format(FIRST_ANALYSIS_QRY_TEMPLATE, DdtUrineAnalysis.TABLE_NAME, hospitalitySession.ObjectId));
            if (firstAnalysis != null)
            {
                firstColorTxt.Text = firstAnalysis.DssColor;
                firstErythrocytesTxt.Text = firstAnalysis.DssErythrocytes;
                firstLeucocytesTxt.Text = firstAnalysis.DssLeukocytes;
                firstProteinTxt.Text = firstAnalysis.DssProtein;
            }
        }

        private void initEgdsAnalysis(DdtEgds egds, DataService service)
        {
            if (CommonUtils.isNotBlank(patientAnalysis.DsidEgds) && egds != null)
            {
                regularEgdsTxt.Text = egds.DssEgds;
            }

            DdtEgds firstAnalysis = service.queryObject<DdtEgds>(string.Format(FIRST_ANALYSIS_QRY_TEMPLATE, DdtEgds.TABLE_NAME, hospitalitySession.ObjectId));
            if (firstAnalysis != null)
            {
                firstEgdsTxt.Text = firstAnalysis.DssEgds;
            }
        }

        private void initKagAnalysis(DdtKag kag)
        {
            if (patientAnalysis != null && CommonUtils.isNotBlank(patientAnalysis.DsidKag) && kag != null)
            {
                kagResultsTxt.Text = kag.DssResults;
                kagManipulationTxt.Text = kag.DssKagManipulation;
                DateTime startTime = kag.DsdtStartTime;
                kagDate.Value = startTime;
                kagStartTime.Value = startTime;
                kagEndTime.Value = kag.DsdtEndTime;

            }
            else
            {
                DateTime admissionDate = hospitalitySession.DsdtAdmissionDate;
                kagDate.Value = admissionDate;
                kagStartTime.Value = admissionDate.AddMinutes(30);
            }
        }

        private void initEkgAnalysis(DdtEkg ekg, DataService service)
        {
            if (patientAnalysis != null && CommonUtils.isNotBlank(patientAnalysis.DsidEkg) && ekg != null)
            {
                regularEkgTxt.Text = ekg.DssEkg;
                DdtEkg firstAnalysis = service.queryObject<DdtEkg>(string.Format(FIRST_ANALYSIS_QRY_TEMPLATE, DdtEkg.TABLE_NAME, hospitalitySession.ObjectId));
                if (firstAnalysis != null)
                {
                    firstEkgTxt.Text = firstAnalysis.DssEkg;
                }
            }
        }

        #endregion

        private void showABOFormBtn_Click(object sender, EventArgs e)
        {
            Serology aboForm = new Serology(hospitalitySession);
            aboForm.ShowDialog();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (patientAnalysis == null)
            {
                patientAnalysis = new DdtPatientAnalysis();
                patientAnalysis.DsidHospitalitySession = hospitalitySession.ObjectId;
            }
            DataService service = new DataService();
            saveUziTab(service);
            saveSpecialistConslusionTab(service);
            saveHolterTab(service);
            saveXRayTab(service);
            saveEgdsAnalysisTab(service);
            saveKagAnalysisTab(service);
            saveEkgAnalysisTab(service);

            updateObject<DdtPatientAnalysis>(service, patientAnalysis, DdtPatientAnalysis.TABLE_NAME, patientAnalysis.ObjectId);
            Close();

        }

        #region Save tabs Code

        private void saveUziTab(DataService service)
        {
            if (isNeedSaveTab(UZI_TAB_INDX))
            {
                DdtUzi uziObj = service.queryObject<DdtUzi>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtUzi.TABLE_NAME, patientAnalysis.DsisUzi));
                if (uziObj == null)
                {
                    uziObj = new DdtUzi();
                    uziObj.DsidHospitalitySession = hospitalitySession.ObjectId;
                    uziObj.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    uziObj.DsidPatient = hospitalitySession.DsidPatient;
                }
                uziObj.DssCds = cdsTxt.Text;
                uziObj.DssEhoKg = ehoKgTxt.Text;
                uziObj.DssPleursUzi = pleursUziTxt.Text;
                uziObj.DssUzdBca = uzdTxt.Text;
                uziObj.DssUziObp = uziObpTxt.Text;
                string id = updateObject<DdtUzi>(service, uziObj, DdtUzi.TABLE_NAME, uziObj.ObjectId);
                patientAnalysis.DsisUzi = id;
            }
        }

        private void saveSpecialistConslusionTab(DataService service)
        {
            if (isNeedSaveTab(SPECIALIST_TAB_INDX))
            {
                DdtSpecialistConclusion specialistConclusion = service.queryObject<DdtSpecialistConclusion>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtSpecialistConclusion.TABLE_NAME, patientAnalysis.DsidSpecialistConclusion));
                if (specialistConclusion == null)
                {
                    specialistConclusion = new DdtSpecialistConclusion();
                    specialistConclusion.DsidHospitalitySession = hospitalitySession.ObjectId;
                    specialistConclusion.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    specialistConclusion.DsidPatient = hospitalitySession.DsidPatient;
                }
                specialistConclusion.DssEndocrinologist = endocrinologistTx.Text;
                specialistConclusion.DssNeurolog = neurologTxt.Text;
                specialistConclusion.DssNeuroSurgeon = neuroSurgeonTxt.Text;
                specialistConclusion.DssSurgeon = surgeonTxt.Text;
                string id = updateObject<DdtSpecialistConclusion>(service, specialistConclusion, DdtSpecialistConclusion.TABLE_NAME, specialistConclusion.ObjectId);
                patientAnalysis.DsidSpecialistConclusion = id;
            }
        }

        private void saveHolterTab(DataService service)
        {
            if (isNeedSaveTab(HOLTER_TAB_INDX))
            {
                DdtHolter holter = service.queryObject<DdtHolter>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtHolter.TABLE_NAME, patientAnalysis.DsidHolter));
                if (holter == null)
                {
                    holter = new DdtHolter();
                    holter.DsidHospitalitySession = hospitalitySession.ObjectId;
                    holter.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    holter.DsidPatient = hospitalitySession.DsidPatient;
                }
                holter.DssHolter = holterTxt.Text;
                holter.DssMonitoringAd = monitoringAdTxt.Text;
                string id = updateObject<DdtHolter>(service, holter, DdtHolter.TABLE_NAME, holter.ObjectId);
                patientAnalysis.DsidHolter = id;
            }
        }

        private void saveXRayTab(DataService service)
        {
            if (isNeedSaveTab(XRAY_TAB_INDX))
            {
                DdtXRay xRay = service.queryObject<DdtXRay>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtXRay.TABLE_NAME, patientAnalysis.DsidXray));
                if (xRay == null)
                {
                    xRay = new DdtXRay();
                    xRay.DsidHospitalitySession = hospitalitySession.ObjectId;
                    xRay.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    xRay.DsidPatient = hospitalitySession.DsidPatient;
                }
                xRay.DssChestXray = chestXRayTxt.Text;
                xRay.DssControlRadiography = controlRadiographyTxt.Text;
                xRay.DssKt = ktTxt.Text;
                xRay.DssMrt = mrtTxt.Text;
                string id = updateObject<DdtXRay>(service, xRay, DdtXRay.TABLE_NAME, xRay.ObjectId);
                patientAnalysis.DsidXray = id;
            }
        }

        private void saveUrineAnalysisTab(DataService service)
        {
            if (isNeedSaveTab(URINE_TAB_INDX))
            {
                DdtUrineAnalysis urineAnalysis = service.queryObject<DdtUrineAnalysis>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtUrineAnalysis.TABLE_NAME, patientAnalysis.DsisUrineAnalysis));
                if (urineAnalysis == null)
                {
                    urineAnalysis = new DdtUrineAnalysis();
                    urineAnalysis.DsidHospitalitySession = hospitalitySession.ObjectId;
                    urineAnalysis.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    urineAnalysis.DsidPatient = hospitalitySession.DsidPatient;
                }
                urineAnalysis.DssColor = colorTxt.Text;
                urineAnalysis.DssErythrocytes = erythrocytesTxt.Text;
                urineAnalysis.DssLeukocytes = leukocytesTxt.Text;
                urineAnalysis.DssProtein = proteinTxt.Text;
                string id = updateObject<DdtUrineAnalysis>(service, urineAnalysis, DdtUrineAnalysis.TABLE_NAME, urineAnalysis.ObjectId);
                patientAnalysis.DsisUrineAnalysis = id;
            }
        }

        private void saveEgdsAnalysisTab(DataService service)
        {
            if (isNeedSaveTab(EGDS_TAB_INDX))
            {
                DdtEgds egds = service.queryObject<DdtEgds>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtEgds.TABLE_NAME, patientAnalysis.DsidEgds));
                if (egds == null)
                {
                    egds = new DdtEgds();
                    egds.DsidHospitalitySession = hospitalitySession.ObjectId;
                    egds.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    egds.DsidPatient = hospitalitySession.DsidPatient;
                }
                egds.DssEgds = regularEgdsTxt.Text;
                string id = updateObject<DdtEgds>(service, egds, DdtEgds.TABLE_NAME, egds.ObjectId);
                patientAnalysis.DsidEgds = id;
            }
        }

        private void saveKagAnalysisTab(DataService service)
        {
            if (isNeedSaveTab(KAG_TAB_INDX))
            {
                DdtKag kag = service.queryObject<DdtKag>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtKag.TABLE_NAME, patientAnalysis.DsidKag));
                if (kag == null)
                {
                    kag = new DdtKag();
                    kag.DsidHospitalitySession = hospitalitySession.ObjectId;
                    kag.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    kag.DsidPatient = hospitalitySession.DsidPatient;
                }
                kag.DssKagManipulation = kagManipulationTxt.Text;
                kag.DssResults = kagResultsTxt.Text;
                kag.DsdtStartTime = constructDateWIthTime(kagDate.Value, kagStartTime.Value);
                kag.DsdtEndTime = constructDateWIthTime(kagDate.Value, kagEndTime.Value);

                string id = updateObject<DdtKag>(service, kag, DdtKag.TABLE_NAME, kag.ObjectId);
                patientAnalysis.DsidKag = id;
            }
        }

        private void saveEkgAnalysisTab(DataService service)
        {
            if (isNeedSaveTab(EKG_TAB_INDX))
            {
                DdtEkg ekg = service.queryObject<DdtEkg>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtEkg.TABLE_NAME, patientAnalysis.DsidEkg));
                if (ekg == null)
                {
                    ekg = new DdtEkg();
                    ekg.DsidHospitalitySession = hospitalitySession.ObjectId;
                    ekg.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    ekg.DsidPatient = hospitalitySession.DsidPatient;
                }
                ekg.DssEkg = regularEkgTxt.Text;
                string id = updateObject<DdtEkg>(service, ekg, DdtEkg.TABLE_NAME, ekg.ObjectId);
                patientAnalysis.DsidEkg = id;
            }
        }

        #endregion

        private DateTime constructDateWIthTime(DateTime dateSource, DateTime timeSource)
        {
            return new DateTime(dateSource.Year, dateSource.Month, dateSource.Day, timeSource.Hour, timeSource.Minute, 0);
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

        private bool isNeedSaveTab(int tabindex)
        {
            switch (tabindex)
            {
                case URINE_TAB_INDX:
                    return CommonUtils.isNotBlank(colorTxt.Text) || CommonUtils.isNotBlank(erythrocytesTxt.Text) || 
                        CommonUtils.isNotBlank(leukocytesTxt.Text) || CommonUtils.isNotBlank(proteinTxt.Text);
                case UZI_TAB_INDX:
                    return CommonUtils.isNotBlank(ehoKgTxt.Text) || CommonUtils.isNotBlank(cdsTxt.Text) ||
                        CommonUtils.isNotBlank(pleursUziTxt.Text) || CommonUtils.isNotBlank(uzdTxt.Text) || CommonUtils.isNotBlank(uziObpTxt.Text);
                case XRAY_TAB_INDX:
                    return CommonUtils.isNotBlank(chestXRayTxt.Text) || CommonUtils.isNotBlank(controlRadiographyTxt.Text) ||
                        CommonUtils.isNotBlank(ktTxt.Text) || CommonUtils.isNotBlank(mrtTxt.Text);
                case HOLTER_TAB_INDX:
                    return CommonUtils.isNotBlank(holterTxt.Text) || CommonUtils.isNotBlank(monitoringAdTxt.Text);
                case SPECIALIST_TAB_INDX:
                    return CommonUtils.isNotBlank(endocrinologistTx.Text) || CommonUtils.isNotBlank(neurologTxt.Text) ||
                        CommonUtils.isNotBlank(neuroSurgeonTxt.Text) || CommonUtils.isNotBlank(surgeonTxt.Text);
                case EGDS_TAB_INDX:
                    return CommonUtils.isNotBlank(regularEgdsTxt.Text);
                case KAG_TAB_INDX:
                    return CommonUtils.isNotBlank(kagManipulationTxt.Text) || CommonUtils.isNotBlank(kagResultsTxt.Text);
                case EKG_TAB_INDX:
                    return CommonUtils.isNotBlank(regularEkgTxt.Text);
                default: return false;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = "";
        }

        private void spaceBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + " ";
        }

        private void button40_Click(object sender, EventArgs e)
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

        private void button26_Click(object sender, EventArgs e)
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

        private void button39_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "II";
        }

        private void button38_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "III";
        }

        private void button37_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "AVL";
        }

        private void button36_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "AVR";
        }

        private void button35_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "AVF";
        }

        private void button34_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "V1";
        }

        private void button33_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "V2";
        }

        private void button32_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "V3";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "V4";
        }

        private void button30_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "V5";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "V6";
        }

        private void commaBtn_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + ", ";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            regularEkgTxt.Text = regularEkgTxt.Text + "-";
        }

        private void cutMi_Click(object sender, EventArgs e)
        {
            object sourceCtrl = contextMenu.SourceControl;
            if (sourceCtrl.GetType() == typeof(RichTextBox) || sourceCtrl.GetType() == typeof(TextBox))
            {
                TextBoxBase txtCtrl = (TextBoxBase)sourceCtrl;
                string selectedText = txtCtrl.SelectedText;
                if (CommonUtils.isNotBlank(selectedText))
                {
                    Clipboard.SetText(selectedText);
                    txtCtrl.Text = txtCtrl.Text.Remove(txtCtrl.SelectionStart, selectedText.Length);
                }
            }
        }

        private void copyMi_Click(object sender, EventArgs e)
        {
            object sourceCtrl = contextMenu.SourceControl;
            if (sourceCtrl.GetType() == typeof(RichTextBox) || sourceCtrl.GetType() == typeof(TextBox))
            {
                TextBoxBase txtCtrl = (TextBoxBase)sourceCtrl;
                string selectedText = txtCtrl.SelectedText;
                Clipboard.SetText(selectedText);
            }
        }

        private void pasteMi_Click(object sender, EventArgs e)
        {
            object sourceCtrl = contextMenu.SourceControl;
            if (sourceCtrl.GetType() == typeof(RichTextBox) || sourceCtrl.GetType() == typeof(TextBox))
            {
                TextBoxBase txtCtrl = (TextBoxBase)sourceCtrl;
                txtCtrl.Text = txtCtrl.Text + Clipboard.GetText();
            }

        }

        private void kagStartTime_ValueChanged(object sender, EventArgs e)
        {
            DateTime startTime = kagStartTime.Value;
            if (startTime != null)
            {
                kagEndTime.Value = startTime.AddHours(1);
            }

        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.SelectedIndex==3)
            {
                serologyToolTip.Show("bubububu", showABOFormBtn, 5000);
            }
        }
    }
}
