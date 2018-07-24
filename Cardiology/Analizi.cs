﻿using Cardiology.Model;
using Cardiology.Utils;
using System;
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
        private const int COAGULOGRAM_TAB_INDX = 8;
        private const int HORMONES_TAB_INDX = 9;
        private const int BLOOD_TAB_INDX = 10;
        private const string REGULAR_ANALYSIS_QRY_TEMPLATE = @"SELECT * FROM {0} WHERE r_object_id='{1}'";
        private const string FIRST_ANALYSIS_QRY_TEMPLATE = @"SELECT * FROM {0} WHERE dsb_admission_analysis=true and dsid_hospitality_session='{1}'";

        private DdtHospital hospitalitySession;
        private string objectId;

        public Analizi(DdtHospital hospitalitySession, string objectId)
        {
            this.hospitalitySession = hospitalitySession;
            this.objectId = objectId;
            InitializeComponent();


            DataService service = new DataService();
            DdtKag kag = null;
            DdtUrineAnalysis urineAnalysis = null;
            DdtEgds egds = null;
            DdtEkg ekg = null;
            if (CommonUtils.isNotBlank(objectId))
            {
                DdtUzi uziObj = service.queryObject<DdtUzi>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtUzi.TABLE_NAME, objectId));
                DdtSpecialistConclusion specialistConclusion = service.queryObject<DdtSpecialistConclusion>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtSpecialistConclusion.TABLE_NAME, objectId));
                DdtHolter holter = service.queryObject<DdtHolter>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtHolter.TABLE_NAME, objectId));
                DdtXRay xRay = service.queryObject<DdtXRay>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtXRay.TABLE_NAME, objectId));
                urineAnalysis = service.queryObject<DdtUrineAnalysis>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtUrineAnalysis.TABLE_NAME, objectId));
                egds = service.queryObject<DdtEgds>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtEgds.TABLE_NAME, objectId));
                kag = service.queryObject<DdtKag>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtKag.TABLE_NAME, objectId));
                ekg = service.queryObject<DdtEkg>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtEkg.TABLE_NAME, objectId));
                DdtCoagulogram coagulogram = service.queryObject<DdtCoagulogram>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtCoagulogram.TABLE_NAME, objectId));
                DdtHormones hormones = service.queryObject<DdtHormones>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtHormones.TABLE_NAME, objectId));
                DdtBloodAnalysis blood = service.queryObject<DdtBloodAnalysis>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtBloodAnalysis.TABLE_NAME, objectId));

                initUziTab(uziObj);
                initHolterTab(holter);
                initSpecialistConslusionTab(specialistConclusion);
                initXRay(xRay);
                initCoagulogram(coagulogram);
                initHormones(hormones);
                initBloodAnalysis(blood, service);
            }
            initUrineAnalysis(urineAnalysis, service);
            initEgdsAnalysis(egds, service);
            initEkgAnalysis(ekg, service);
            initKagAnalysis(kag);
        }

        #region Initialize Tab Code

        private void initUziTab(DdtUzi uziObj)
        {
            if (uziObj != null)
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
            if (specialistConclusion != null)
            {
                neurologTxt.Text = specialistConclusion.DssNeurolog;
                surgeonTxt.Text = specialistConclusion.DssSurgeon;
                neuroSurgeonTxt.Text = specialistConclusion.DssNeuroSurgeon;
                endocrinologistTx.Text = specialistConclusion.DssEndocrinologist;
            }
        }

        private void initHolterTab(DdtHolter holter)
        {
            if (holter != null)
            {
                holterTxt.Text = holter.DssHolter;
                monitoringAdTxt.Text = holter.DssMonitoringAd;
            }
        }

        private void initXRay(DdtXRay xRay)
        {
            if (xRay != null)
            {
                chestXRayTxt.Text = xRay.DssChestXray;
                controlRadiographyTxt.Text = xRay.DssControlRadiography;
                ktTxt.Text = xRay.DssKt;
                mrtTxt.Text = xRay.DssMrt;
                ktDateTxt.Value = xRay.DsdtKtDate;
                ktTimeTxt.Value = xRay.DsdtKtDate;
            }
        }

        private void initCoagulogram(DdtCoagulogram coagulogram)
        {
            if (coagulogram != null)
            {
                achtvTxt.Text = coagulogram.DssAchtv;
                ddimerTxt.Text = coagulogram.DssDdimer;
                mchoTxt.Text = coagulogram.DssMcho;
            }
        }


        private void initHormones(DdtHormones hormones)
        {
            if (hormones != null)
            {
                t3Txt.Text = hormones.DssT3;
                t4Txt.Text = hormones.DssT4;
                ttgTxt.Text = hormones.DssTtg;
            }
        }

        private void initUrineAnalysis(DdtUrineAnalysis urineAnalysis, DataService service)
        {
            if (urineAnalysis != null)
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

        private void initBloodAnalysis(DdtBloodAnalysis blood, DataService service)
        {
            if (blood != null)
            {
                regularAltTxt.Text = blood.DsdAlt + "";
                regularAmilazaTzt.Text = blood.DsdAmylase + "";
                regularAstTxt.Text = blood.DsdAst + "";
                regularBilTxt.Text = blood.DsdBil + "";
                regularChloriumTxt.Text = blood.DsdChlorine + "";
                regularCholesterolTxt.Text = blood.DsdCholesterolr + "";
                regularKreatininTxt.Text = blood.DsdCreatinine + "";
                regularHemoglobinTxt.Text = blood.DsdHemoglobin + "";
                regularIronTxt.Text = blood.DsdIron + "";
                regularKfkTxt.Text = blood.DsdKfk + "";
                regularKfkMvTxt.Text = blood.DsdKfkMv + "";
                regularBloodLeucoTxt.Text = blood.DsdLeucocytes + "";
                regularTrombocytesTxt.Text = blood.DsdPlatelets + "";
                regularPotassiumTxt.Text = blood.DsdPotassium + "";
                regularProreinTxt.Text = blood.DsdProtein + "";
                regularSchfTxt.Text = blood.DsdSchf + "";
                regularSodiumTxt.Text = blood.DsdSodium + "";
                regularSrbTxt.Text = blood.DsdSrp + "";
            }

            DdtBloodAnalysis firstAnalysis = service.queryObject<DdtBloodAnalysis>(string.Format(FIRST_ANALYSIS_QRY_TEMPLATE, DdtBloodAnalysis.TABLE_NAME, hospitalitySession.ObjectId));
            if (firstAnalysis != null)
            {
                firstAltTxt.Text = firstAnalysis.DsdAlt + "";
                firstAmilazaTxt.Text = firstAnalysis.DsdAmylase + "";
                firstAstTxt.Text = firstAnalysis.DsdAst + "";
                firstBilTxt.Text = firstAnalysis.DsdBil + "";
                firstChlorineTxt.Text = firstAnalysis.DsdChlorine + "";
                firstHolesterolTxt.Text = firstAnalysis.DsdCholesterolr + "";
                firstKreatininTxt.Text = firstAnalysis.DsdCreatinine + "";
                firstHemoglobinTxt.Text = firstAnalysis.DsdHemoglobin + "";
                firstIronTxt.Text = firstAnalysis.DsdIron + "";
                firstKfkTxt.Text = firstAnalysis.DsdKfk + "";
                firstKfkMvTxt.Text = firstAnalysis.DsdKfkMv + "";
                firstBloodLeucoTxt.Text = firstAnalysis.DsdLeucocytes + "";
                firstTrombocytesTxt.Text = firstAnalysis.DsdPlatelets + "";
                firstPotassiumTxt.Text = firstAnalysis.DsdPotassium + "";
                firstProteinTxt.Text = firstAnalysis.DsdProtein + "";
                firstSchfTxt.Text = firstAnalysis.DsdSchf + "";
                firstSodiumTxt.Text = firstAnalysis.DsdSodium + "";
                firstSrbTxt.Text = firstAnalysis.DsdSrp + "";
            }
        }

        private void initEgdsAnalysis(DdtEgds egds, DataService service)
        {
            if (egds != null)
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
            if (kag != null)
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
            if (ekg != null)
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
            DataService service = new DataService();
            saveUziTab(service);
            saveSpecialistConslusionTab(service);
            saveHolterTab(service);
            saveXRayTab(service);
            saveEgdsAnalysisTab(service);
            saveKagAnalysisTab(service);
            saveEkgAnalysisTab(service);
            saveCoagulogram(service);
            saveHormones(service);
            saveBloodAnalysis(service);

            Close();

        }

        #region Save tabs Code

        private void saveUziTab(DataService service)
        {
            if (isNeedSaveTab(UZI_TAB_INDX))
            {
                DdtUzi uziObj = service.queryObject<DdtUzi>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtUzi.TABLE_NAME, objectId));
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
                service.updateOrCreateIfNeedObject<DdtUzi>(uziObj, DdtUzi.TABLE_NAME, uziObj.ObjectId);

            }
        }

        private void saveCoagulogram(DataService service)
        {
            if (isNeedSaveTab(COAGULOGRAM_TAB_INDX))
            {
                DdtCoagulogram coagulogramObj = service.queryObject<DdtCoagulogram>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtCoagulogram.TABLE_NAME, objectId));
                if (coagulogramObj == null)
                {
                    coagulogramObj = new DdtCoagulogram();
                    coagulogramObj.DsidHospitalitySession = hospitalitySession.ObjectId;
                    coagulogramObj.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    coagulogramObj.DsidPatient = hospitalitySession.DsidPatient;
                }
                coagulogramObj.DssAchtv = achtvTxt.Text;
                coagulogramObj.DssDdimer = ddimerTxt.Text;
                coagulogramObj.DssMcho = mchoTxt.Text;
                service.updateOrCreateIfNeedObject<DdtCoagulogram>(coagulogramObj, DdtCoagulogram.TABLE_NAME, coagulogramObj.RObjectId);

            }
        }

        private void saveBloodAnalysis(DataService service)
        {
            if (isNeedSaveTab(BLOOD_TAB_INDX))
            {
                DdtBloodAnalysis bloodObj = service.queryObject<DdtBloodAnalysis>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtBloodAnalysis.TABLE_NAME, objectId));
                if (bloodObj == null)
                {
                    bloodObj = new DdtBloodAnalysis();
                    bloodObj.DsidHospitalitySession = hospitalitySession.ObjectId;
                    bloodObj.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    bloodObj.DsidPatient = hospitalitySession.DsidPatient;
                }
                bloodObj.DsdAlt = regularAltTxt.Text;
                bloodObj.DsdAmylase = regularAmilazaTzt.Text;
                bloodObj.DsdAst = regularAstTxt.Text;
                bloodObj.DsdBil = regularBilTxt.Text;
                bloodObj.DsdChlorine = regularChloriumTxt.Text;
                bloodObj.DsdCholesterolr = regularCholesterolTxt.Text;
                bloodObj.DsdCreatinine = regularKreatininTxt.Text;
                bloodObj.DsdHemoglobin = regularHemoglobinTxt.Text;
                bloodObj.DsdIron = regularIronTxt.Text;
                bloodObj.DsdKfk = regularKfkTxt.Text;
                bloodObj.DsdKfkMv = regularKfkMvTxt.Text;
                bloodObj.DsdLeucocytes = regularBloodLeucoTxt.Text;
                bloodObj.DsdPlatelets = regularTrombocytesTxt.Text;
                bloodObj.DsdPotassium = regularPotassiumTxt.Text;
                bloodObj.DsdProtein = regularProreinTxt.Text;
                bloodObj.DsdSchf = regularSchfTxt.Text;
                bloodObj.DsdSodium = regularSodiumTxt.Text;
                bloodObj.DsdSrp = regularSrbTxt.Text;
                service.updateOrCreateIfNeedObject<DdtBloodAnalysis>(bloodObj, DdtBloodAnalysis.TABLE_NAME, bloodObj.RObjectId);

            }
        }

        private void saveHormones(DataService service)
        {
            if (isNeedSaveTab(HORMONES_TAB_INDX))
            {
                DdtHormones hormonesObj = service.queryObject<DdtHormones>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtHormones.TABLE_NAME, objectId));
                if (hormonesObj == null)
                {
                    hormonesObj = new DdtHormones();
                    hormonesObj.DsidHospitalitySession = hospitalitySession.ObjectId;
                    hormonesObj.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    hormonesObj.DsidPatient = hospitalitySession.DsidPatient;
                }
                hormonesObj.DssT3 = t3Txt.Text;
                hormonesObj.DssT4 = t4Txt.Text;
                hormonesObj.DssTtg = ttgTxt.Text;
                service.updateOrCreateIfNeedObject<DdtHormones>(hormonesObj, DdtHormones.TABLE_NAME, hormonesObj.RObjectId);

            }
        }

        private void saveSpecialistConslusionTab(DataService service)
        {
            if (isNeedSaveTab(SPECIALIST_TAB_INDX))
            {
                DdtSpecialistConclusion specialistConclusion = service.queryObject<DdtSpecialistConclusion>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtSpecialistConclusion.TABLE_NAME, objectId));
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
                service.updateOrCreateIfNeedObject<DdtSpecialistConclusion>(specialistConclusion, DdtSpecialistConclusion.TABLE_NAME, specialistConclusion.ObjectId);

            }
        }

        private void saveHolterTab(DataService service)
        {
            if (isNeedSaveTab(HOLTER_TAB_INDX))
            {
                DdtHolter holter = service.queryObject<DdtHolter>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtHolter.TABLE_NAME, objectId));
                if (holter == null)
                {
                    holter = new DdtHolter();
                    holter.DsidHospitalitySession = hospitalitySession.ObjectId;
                    holter.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    holter.DsidPatient = hospitalitySession.DsidPatient;
                }
                holter.DssHolter = holterTxt.Text;
                holter.DssMonitoringAd = monitoringAdTxt.Text;
                service.updateOrCreateIfNeedObject<DdtHolter>(holter, DdtHolter.TABLE_NAME, holter.ObjectId);

            }
        }

        private void saveXRayTab(DataService service)
        {
            if (isNeedSaveTab(XRAY_TAB_INDX))
            {
                DdtXRay xRay = service.queryObject<DdtXRay>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtXRay.TABLE_NAME, objectId));
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
                xRay.DsdtKtDate = constructDateWIthTime(ktDateTxt.Value, ktTimeTxt.Value);
                service.updateOrCreateIfNeedObject<DdtXRay>(xRay, DdtXRay.TABLE_NAME, xRay.ObjectId);

            }
        }

        private void saveUrineAnalysisTab(DataService service)
        {
            if (isNeedSaveTab(URINE_TAB_INDX))
            {
                DdtUrineAnalysis urineAnalysis = service.queryObject<DdtUrineAnalysis>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtUrineAnalysis.TABLE_NAME, objectId));
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
                service.updateOrCreateIfNeedObject<DdtUrineAnalysis>(urineAnalysis, DdtUrineAnalysis.TABLE_NAME, urineAnalysis.ObjectId);

            }
        }

        private void saveEgdsAnalysisTab(DataService service)
        {
            if (isNeedSaveTab(EGDS_TAB_INDX))
            {
                DdtEgds egds = service.queryObject<DdtEgds>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtEgds.TABLE_NAME, objectId));
                if (egds == null)
                {
                    egds = new DdtEgds();
                    egds.DsidHospitalitySession = hospitalitySession.ObjectId;
                    egds.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    egds.DsidPatient = hospitalitySession.DsidPatient;
                }
                egds.DssEgds = regularEgdsTxt.Text;
                service.updateOrCreateIfNeedObject<DdtEgds>(egds, DdtEgds.TABLE_NAME, egds.ObjectId);

            }
        }

        private void saveKagAnalysisTab(DataService service)
        {
            if (isNeedSaveTab(KAG_TAB_INDX))
            {
                DdtKag kag = service.queryObject<DdtKag>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtKag.TABLE_NAME, objectId));
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

                service.updateOrCreateIfNeedObject<DdtKag>(kag, DdtKag.TABLE_NAME, kag.ObjectId);

            }
        }

        private void saveEkgAnalysisTab(DataService service)
        {
            if (isNeedSaveTab(EKG_TAB_INDX))
            {
                DdtEkg ekg = service.queryObject<DdtEkg>(string.Format(REGULAR_ANALYSIS_QRY_TEMPLATE, DdtEkg.TABLE_NAME, objectId));
                if (ekg == null)
                {
                    ekg = new DdtEkg();
                    ekg.DsidHospitalitySession = hospitalitySession.ObjectId;
                    ekg.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    ekg.DsidPatient = hospitalitySession.DsidPatient;
                }
                ekg.DssEkg = regularEkgTxt.Text;
                service.updateOrCreateIfNeedObject<DdtEkg>(ekg, DdtEkg.TABLE_NAME, ekg.ObjectId);

            }
        }

        #endregion

        private DateTime constructDateWIthTime(DateTime dateSource, DateTime timeSource)
        {
            return new DateTime(dateSource.Year, dateSource.Month, dateSource.Day, timeSource.Hour, timeSource.Minute, 0);
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
                case COAGULOGRAM_TAB_INDX:
                    return CommonUtils.isNotBlank(achtvTxt.Text) || CommonUtils.isNotBlank(ddimerTxt.Text) || CommonUtils.isNotBlank(mchoTxt.Text);
                case HORMONES_TAB_INDX:
                    return CommonUtils.isNotBlank(t3Txt.Text) || CommonUtils.isNotBlank(t4Txt.Text) || CommonUtils.isNotBlank(ttgTxt.Text);
                case BLOOD_TAB_INDX:
                    return CommonUtils.isNotBlank(regularTrombocytesTxt.Text) || CommonUtils.isNotBlank(regularSrbTxt.Text)
                        || CommonUtils.isNotBlank(regularSodiumTxt.Text) || CommonUtils.isNotBlank(regularSchfTxt.Text)
                        || CommonUtils.isNotBlank(regularKreatininTxt.Text) || CommonUtils.isNotBlank(regularKfkTxt.Text)
                        || CommonUtils.isNotBlank(regularKfkMvTxt.Text) || CommonUtils.isNotBlank(regularIronTxt.Text)
                        || CommonUtils.isNotBlank(regularHemoglobinTxt.Text) || CommonUtils.isNotBlank(regularCholesterolTxt.Text)
                        || CommonUtils.isNotBlank(regularChloriumTxt.Text) || CommonUtils.isNotBlank(regularBloodLeucoTxt.Text)
                        || CommonUtils.isNotBlank(regularBilTxt.Text) || CommonUtils.isNotBlank(regularAstTxt.Text)
                        || CommonUtils.isNotBlank(regularAltTxt.Text) || CommonUtils.isNotBlank(regularProreinTxt.Text)
                        || CommonUtils.isNotBlank(regularPotassiumTxt.Text);
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
            if (tabs.SelectedIndex == 3)
            {
                serologyToolTip.Show("bubububu", showABOFormBtn, 5000);
            }
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
            if (mirrorCtrl!=null)
            {
                regularEkgTxt.Text += mirrorCtrl.Text;
            }

        }
    }
}
