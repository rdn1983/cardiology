using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class Analizi : Form
    {
        private DdtHospital hospitalitySession;
        private DdtPatientAnalysis patientAnalysis;

        private DdtUzi uziObj;
        private DdtSpecialistConclusion specialistConclusion;
        private DdtHolter holter;
        private DdtXRay xRay;
        private DdtUrineAnalysis urineAnalysis;

        public Analizi(DdtHospital hospitalitySession, DdtPatientAnalysis analysis)
        {
            this.hospitalitySession = hospitalitySession;
            this.patientAnalysis = analysis;
            InitializeComponent();

            if (patientAnalysis!=null)
            {
                DataService service = new DataService();
                uziObj = service.queryObject<DdtUzi>(@"select * from " + DdtUzi.TABLE_NAME + " WHERE r_object_id ='" + patientAnalysis.DsisUzi + "'");
                specialistConclusion = service.queryObject<DdtSpecialistConclusion>(@"select * from " + DdtSpecialistConclusion.TABLE_NAME + " WHERE r_object_id ='" + patientAnalysis.DsidSpecialistConclusion + "'");
                holter = service.queryObject<DdtHolter>(@"select * from " + DdtHolter.TABLE_NAME + " WHERE r_object_id ='" + patientAnalysis.DsidHolter + "'");
                xRay = service.queryObject<DdtXRay>(@"select * from " + DdtXRay.TABLE_NAME + " WHERE r_object_id ='" + patientAnalysis.DsidXray + "'");
                urineAnalysis = service.queryObject<DdtUrineAnalysis>(@"select * from " + DdtUrineAnalysis.TABLE_NAME + " WHERE r_object_id ='" + patientAnalysis.DsisUrineAnalysis + "'");

                initUziTab();
                intSpecialistConslusionTab();
                initHolterTab();
                initXRay();
                initUrineAnalysis();
            }
        }

        private void initUziTab()
        {
            if (CommonUtils.isNotBlank(patientAnalysis.DsisUzi))
            {
                ehoKgTxt.Text = uziObj.DssEhoKg;
                cdsTxt.Text = uziObj.DssCds;
                pleursUziTxt.Text = uziObj.DssPleursUzi;
                uzdTxt.Text = uziObj.DssUzdBca;
                uziObpTxt.Text = uziObj.DssUziObp;
            }
        }

        private void intSpecialistConslusionTab()
        {
            if (CommonUtils.isNotBlank(patientAnalysis.DsidSpecialistConclusion))
            {
                neurologTxt.Text = specialistConclusion.DssNeurolog;
                surgeonTxt.Text = specialistConclusion.DssSurgeon;
                neuroSurgeonTxt.Text = specialistConclusion.DssNeuroSurgeon;
                endocrinologistTx.Text = specialistConclusion.DssEndocrinologist;
            }
        }

        private void initHolterTab()
        {
            if (CommonUtils.isNotBlank(patientAnalysis.DsidHolter))
            {
                holterTxt.Text = holter.DssHolter;
                monitoringAdTxt.Text = holter.DssMonitoringAd;
            }
        }

        private void initXRay()
        {
            if (CommonUtils.isNotBlank(patientAnalysis.DsidXray))
            {
                chestXRayTxt.Text = xRay.DssChestXray;
                controlRadiographyTxt.Text = xRay.DssControlRadiography;
                ktTxt.Text = xRay.DssKt;
                mrtTxt.Text = xRay.DssMrt;
                msktTxt.Text = xRay.DssMskt;
            }
        }

        private void initUrineAnalysis()
        {
            if (CommonUtils.isNotBlank(patientAnalysis.DsisUrineAnalysis))
            {
                colorTxt.Text = urineAnalysis.DssColor;
                acidityTxt.Text = urineAnalysis.DssAcidity;
                erythrocytesTxt.Text = urineAnalysis.DssErythrocytes;
                glucoseTxt.Text = urineAnalysis.DssGlucose;
                ketonesTxt.Text = urineAnalysis.DssKetones;
                leukocytesTxt.Text = urineAnalysis.DssLeukocytes;
                proteinTxt.Text = urineAnalysis.DssProtein;
                specGravityTxt.Text = urineAnalysis.DssSpecificGravity;
            }

            DataService servise = new DataService();
            DdtUrineAnalysis firstAnalysis = servise.queryObject<DdtUrineAnalysis>(@"select * from ddt_urine_analysis where dsb_admission_analysis=true 
                        and dsid_hospitality_session='" + hospitalitySession.ObjectId + "'");
            if (firstAnalysis != null)
            {
                firstColorTxt.Text = firstAnalysis.DssColor;
                firstAcidityTxt.Text = firstAnalysis.DssAcidity;
                firstErythrocytesTxt.Text = firstAnalysis.DssErythrocytes;
                firstGlucoseTxt.Text = firstAnalysis.DssGlucose;
                firstKetonesTxt.Text = firstAnalysis.DssKetones;
                firstLeucocytesTxt.Text = firstAnalysis.DssLeukocytes;
                firstProteinTxt.Text = firstAnalysis.DssProtein;
                firstSpecGravityTxt.Text = firstAnalysis.DssSpecificGravity;
            }
        }


        private void showABOFormBtn_Click(object sender, EventArgs e)
        {
            Serology aboForm = new Serology(hospitalitySession);
            aboForm.ShowDialog();
        }



        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (patientAnalysis==null)
            {
                patientAnalysis = new DdtPatientAnalysis();
                patientAnalysis.DsidHospitalitySession = hospitalitySession.ObjectId;
            }
            DataService service = new DataService();
            saveUziTab(service);
            saveSpecialistConslusionTab(service);
            saveHolterTab(service);
            saveXRayTab(service);

            updateObject<DdtPatientAnalysis>(service, patientAnalysis, DdtPatientAnalysis.TABLE_NAME, patientAnalysis.ObjectId);
            Close();

        }

        private void saveUziTab(DataService service)
        {
            if (isNeedSaveTab(3))
            {
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
            if (isNeedSaveTab(6))
            {
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
            if (isNeedSaveTab(5))
            {
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
            if (isNeedSaveTab(4))
            {
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
                xRay.DssMskt = msktTxt.Text;
                string id = updateObject<DdtXRay>(service, xRay, DdtXRay.TABLE_NAME, xRay.ObjectId);
                patientAnalysis.DsidXray = id;
            }
        }

        private void saveUrineAnalysisTab(DataService service)
        {
            if (isNeedSaveTab(2))
            {
                if (urineAnalysis == null)
                {
                    urineAnalysis = new DdtUrineAnalysis();
                    urineAnalysis.DsidHospitalitySession = hospitalitySession.ObjectId;
                    urineAnalysis.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    urineAnalysis.DsidPatient = hospitalitySession.DsidPatient;
                }
                urineAnalysis.DssAcidity = acidityTxt.Text;
                urineAnalysis.DssColor = colorTxt.Text;
                urineAnalysis.DssErythrocytes = erythrocytesTxt.Text;
                urineAnalysis.DssGlucose = glucoseTxt.Text;
                urineAnalysis.DssKetones = ketonesTxt.Text;
                urineAnalysis.DssLeukocytes = leukocytesTxt.Text;
                urineAnalysis.DssProtein = proteinTxt.Text;
                urineAnalysis.DssSpecificGravity = specGravityTxt.Text;
                string id = updateObject<DdtUrineAnalysis>(service, urineAnalysis, DdtUrineAnalysis.TABLE_NAME, urineAnalysis.ObjectId);
                patientAnalysis.DsisUrineAnalysis = id;
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

        private bool isNeedSaveTab(int tabindex)
        {
            switch (tabindex)
            {
                case 2:
                    return CommonUtils.isNotBlank(acidityTxt.Text) || CommonUtils.isNotBlank(colorTxt.Text) ||
                        CommonUtils.isNotBlank(erythrocytesTxt.Text) || CommonUtils.isNotBlank(glucoseTxt.Text) ||
                        CommonUtils.isNotBlank(leukocytesTxt.Text) || CommonUtils.isNotBlank(proteinTxt.Text) ||
                         CommonUtils.isNotBlank(specGravityTxt.Text) || CommonUtils.isNotBlank(ketonesTxt.Text);
                case 3:
                    return CommonUtils.isNotBlank(ehoKgTxt.Text) || CommonUtils.isNotBlank(cdsTxt.Text) ||
                        CommonUtils.isNotBlank(pleursUziTxt.Text) || CommonUtils.isNotBlank(uzdTxt.Text) || CommonUtils.isNotBlank(uziObpTxt.Text);
                case 4:
                    return CommonUtils.isNotBlank(chestXRayTxt.Text) || CommonUtils.isNotBlank(controlRadiographyTxt.Text) ||
                        CommonUtils.isNotBlank(ktTxt.Text) || CommonUtils.isNotBlank(mrtTxt.Text) || CommonUtils.isNotBlank(msktTxt.Text);
                case 5:
                    return CommonUtils.isNotBlank(holterTxt.Text) || CommonUtils.isNotBlank(monitoringAdTxt.Text);
                case 6:
                    return CommonUtils.isNotBlank(endocrinologistTx.Text) || CommonUtils.isNotBlank(neurologTxt.Text) ||
                        CommonUtils.isNotBlank(neuroSurgeonTxt.Text) || CommonUtils.isNotBlank(surgeonTxt.Text);
                default: return false;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
        }

        private void spaceBtn_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + " ";
        }

        private void button40_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "I";
        }

        private void rhytmSinusBtn_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "ритм синусовый";
        }

        private void fibrillationBtn_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "фибрилляция предсердий";
        }

        private void flutterBtn_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "трепетание предсердий";
        }

        private void elevation_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "элевация ST в ";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + ".";
        }

        private void depressionBtn_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "депрессия ST в ";
        }

        private void negativeTBtn_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "отрицательный T";
        }

        private void button39_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "II";
        }

        private void button38_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "III";
        }

        private void button37_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "AVL";
        }

        private void button36_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "AVR";
        }

        private void button35_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "AVF";
        }

        private void button34_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "V1";
        }

        private void button33_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "V2";
        }

        private void button32_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "V3";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "V4";
        }

        private void button30_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "V5";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "V6";
        }

        private void commaBtn_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + ", ";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "-";
        }
    }
}
