using Cardiology.Model;
using Cardiology.Model.Dictionary;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class Inspection : Form
    {
        private DdtHospital hospitalitySession;
        private DdtInspection inspectionObj;
        private static AnalysisSelector selector;
        private string kagId;

        public Inspection(DdtHospital hospitalitySession, string id)
        {
            this.hospitalitySession = hospitalitySession;
            InitializeComponent();
            initControls(id);
        }

        private void initControls(string inspectionObjId)
        {
            kagContainer.Visible = false;
            DataService service = new DataService();
            DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, hospitalitySession.DsidPatient);
            if (patient != null)
            {
                Text += " " + patient.DssInitials;
            }
            inspectionObj = service.queryObjectById<DdtInspection>(DdtInspection.TABLE_NAME, inspectionObjId);
            DateTime startDate = inspectionObj == null ? DateTime.Now : inspectionObj.DsdtInspectionDate;
            DdtJournal kagJournal = CommonUtils.resolveKagJournal(service, startDate, hospitalitySession.ObjectId);

            if (inspectionObj != null)
            {
                complaintsTxt.Text = inspectionObj.DssComplaints;
                diagnosisTxt.Text = inspectionObj.DssDiagnosis;
                inspectionTxt.Text = inspectionObj.DssInspection;
                resultTxt.Text = inspectionObj.DssInspectionResult;
                kateterPlacementTxt.Text = inspectionObj.DssKateterPlacement;

                initIssuedCure(service);
                initAnalysis(service);
            }
            else
            {
                if (kagJournal != null)
                {
                    diagnosisTxt.Text = kagJournal.DssDiagnosis;
                    DdtVariousSpecConcluson releaseConclusion = service.queryObject<DdtVariousSpecConcluson>("SELECt * FROM " + DdtVariousSpecConcluson.TABLE_NAME +
                       " WHERE dsid_parent='" + kagJournal.RObjectId + "' AND dsb_additional_bool=true");
                    if (releaseConclusion != null)
                    {
                        inspectionTxt.Text = releaseConclusion.DssSpecialistConclusion;
                    }
                }
                else
                {
                    diagnosisTxt.Text = hospitalitySession.DssDiagnosis;
                }


            }

            initKag(service, kagJournal);
        }


        private void initAnalysis(DataService service)
        {
            if (inspectionObj != null)
            {
                List<DdtEkg> ekgAnalysis = service.queryObjectsCollection<DdtEkg>(@"SELECT * FROM " + DdtEkg.TABLE_NAME + " WHERE dsid_parent='" + inspectionObj.RObjectId + "'");
                foreach (DdtEkg ekgObj in ekgAnalysis)
                {
                    TableLayoutPanel container = getTabContainer("ekgTab", "ЭКГ", false);
                    EkgAnalysisControlcs ekg = new EkgAnalysisControlcs(ekgObj.ObjectId, false);
                    container.Controls.Add(ekg);
                }

                List<DdtSpecialistConclusion> specs = service.queryObjectsCollection<DdtSpecialistConclusion>(@"SELECT * FROM " +
                    DdtSpecialistConclusion.TABLE_NAME + " WHERE dsid_parent='" + inspectionObj.RObjectId + "'");
                foreach (DdtSpecialistConclusion obj in specs)
                {
                    TableLayoutPanel container = getTabContainer("specsTab", "Заключения специалистов", true);
                    SpecialistConclusionControl specControl = new SpecialistConclusionControl(obj.ObjectId, false);
                    container.Controls.Add(specControl);
                }

                List<DdtHolter> holters = service.queryObjectsCollection<DdtHolter>(@"SELECT * FROM " + DdtHolter.TABLE_NAME +
                    " WHERE dsid_parent='" + inspectionObj.RObjectId + "'");
                foreach (DdtHolter obj in holters)
                {
                    TableLayoutPanel container = getTabContainer("holterTab", "Холтер", true);
                    HolterControl holt = new HolterControl(obj.ObjectId, false);
                    container.Controls.Add(holt);
                }

                List<DdtBloodAnalysis> bloods = service.queryObjectsCollection<DdtBloodAnalysis>(@"SELECT * FROM " +
                    DdtBloodAnalysis.TABLE_NAME + " WHERE dsid_parent='" + inspectionObj.RObjectId + "'");
                foreach (DdtBloodAnalysis obj in bloods)
                {
                    TableLayoutPanel container = getTabContainer("bloodTab", "Анализы крови", true);
                    BloodAnalysisControl blood = new BloodAnalysisControl(obj.RObjectId, false);
                    container.Controls.Add(blood);
                }

                List<DdtUzi> uzis = service.queryObjectsCollection<DdtUzi>(@"SELECT * FROM " + DdtUzi.TABLE_NAME +
                    " WHERE dsid_parent='" + inspectionObj.RObjectId + "'");
                foreach (DdtUzi obj in uzis)
                {
                    TableLayoutPanel container = getTabContainer("uziTab", "УЗИ", false);
                    UziAnalysisControl control = new UziAnalysisControl(obj.ObjectId, false);
                    container.Controls.Add(control);
                }
            }
        }

        private void initKag(DataService service, DdtJournal kagJournal)
        {
            bool hasKag = false;
            if (kagJournal != null)
            {
                DdtKag kag = service.queryObjectByAttrCond<DdtKag>(DdtKag.TABLE_NAME, "dsid_parent", kagJournal.RObjectId, true);
                if (kag != null)
                {
                    kagId = kag.ObjectId;
                    TableLayoutPanel container = getTabContainer("kagTab", "КАГ", true);
                    KagAnalysisControl specControl = new KagAnalysisControl(kag.ObjectId, true, hospitalitySession.ObjectId);
                    container.Controls.Clear();
                    container.Controls.Add(specControl);
                    kagContainer.Visible = true;
                    hasKag = true;
                }
            }
            if (!hasKag)
            {
                kagId = null;
                kagContainer.Visible = false;
                int index = tabbedAnalysis.TabPages.IndexOfKey("kagTab");
                if (index >= 0)
                {
                    tabbedAnalysis.TabPages.RemoveAt(index);
                }
            }

        }

        private void initIssuedCure(DataService service)
        {
            DdtIssuedMedicineList medList = service.queryObject<DdtIssuedMedicineList>(@"SELECT * FROM " + DdtIssuedMedicineList.TABLE_NAME +
                " WHERE dsid_parent_id='" + inspectionObj.RObjectId + "'");
            if (medList != null)
            {
                skipPrintBtn.Checked = medList.DsbSkipPrint;
                reinitFromMedList(service, medList);
            }
        }

        private void reinitFromMedList(DataService service, DdtIssuedMedicineList medList)
        {
            if (medList != null)
            {
                issuedMedicineContainer.Init(service, medList);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!getIsValid())
            {
                return;
            }

            DataService service = new DataService();
            saveInspectionObj(service);
            saveIssuedMedicine(service);
            saveAnalysis(service);
            Close();
        }

        private bool getIsValid()
        {
            return true;
        }

        private void saveInspectionObj(DataService service)
        {
            if (inspectionObj == null)
            {
                inspectionObj = new DdtInspection();
                inspectionObj.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                inspectionObj.DsidHospitalitySession = hospitalitySession.ObjectId;
                inspectionObj.DsidPatient = hospitalitySession.DsidPatient;
            }

            inspectionObj.DssComplaints = complaintsTxt.Text;
            inspectionObj.DssDiagnosis = diagnosisTxt.Text;
            inspectionObj.DssInspection = inspectionTxt.Text;
            inspectionObj.DssInspectionResult = resultTxt.Text;
            inspectionObj.DssKateterPlacement = kateterPlacementTxt.Text;
            inspectionObj.DsdtInspectionDate = CommonUtils.constructDateWIthTime(inspectionDate.Value, inspectionTime.Value);
            string id = service.updateOrCreateIfNeedObject<DdtInspection>(inspectionObj, DdtInspection.TABLE_NAME, inspectionObj.RObjectId);
            inspectionObj.RObjectId = id;
        }

        private void saveIssuedMedicine(DataService service)
        {
            List<DdtIssuedMedicine> meds = issuedMedicineContainer.getIssuedMedicines();
            if (meds.Count > 0)
            {
                DdtIssuedMedicineList medList = service.queryObject<DdtIssuedMedicineList>(@"SELECT * FROM " + DdtIssuedMedicineList.TABLE_NAME +
                " WHERE dsid_parent_id='" + inspectionObj + "'");
                if (medList == null)
                {
                    medList = new DdtIssuedMedicineList();
                    medList.DsidDoctor = hospitalitySession.DsidDutyDoctor;
                    medList.DsidHospitalitySession = hospitalitySession.ObjectId;
                    medList.DsidPatient = hospitalitySession.DsidPatient;
                    medList.DsidParentId = inspectionObj.RObjectId;
                    medList.DssParentType = DdtInspection.TABLE_NAME;
                    medList.DsdtIssuingDate = CommonUtils.constructDateWIthTime(inspectionDate.Value, inspectionTime.Value);
                }
                medList.DsbSkipPrint = skipPrintBtn.Checked;
                string id = service.updateOrCreateIfNeedObject<DdtIssuedMedicineList>(medList, DdtIssuedMedicineList.TABLE_NAME, medList.ObjectId);
                medList.ObjectId = id;
                foreach (DdtIssuedMedicine med in meds)
                {
                    med.DsidMedList = medList.ObjectId;
                    service.updateOrCreateIfNeedObject<DdtIssuedMedicine>(med, DdtIssuedMedicine.TABLE_NAME, med.RObjectId);
                }
            }
        }

        private void saveAnalysis(DataService service)
        {
            saveTab("uziTab", "УЗИ");
            saveTab("bloodTab", "АНализы крови");
            saveTab("ekgTab", "ЭКГ");
            saveTab("holterTab", "Холтер");
            saveTab("specsTab", "Заключения специалистов");
            saveTab("xRayTab", "Рентген");
        }

        private void saveTab(string name, string title)
        {
            TableLayoutPanel tabCntr = getTabContainer(name, title, false);
            for (int i = 0; i < tabCntr.Controls.Count; i++)
            {
                IDocbaseControl control = (IDocbaseControl)tabCntr.Controls[i];
                control.saveObject(hospitalitySession, inspectionObj.RObjectId, DdtInspection.TABLE_NAME);
            }
        }

        private void addMedicineBtn_Click(object sender, EventArgs e)
        {
            issuedMedicineContainer.addMedicineBox();
        }

        private void addAnalysisBtn_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseArgs = e as MouseEventArgs;
            analysisTypeMenu.Show(addAnalysis, mouseArgs.X, mouseArgs.Y);
        }

        private TableLayoutPanel getTabContainer(string name, string title, bool isVerticalStyle)
        {
            TableLayoutPanel result = null;
            if (!tabbedAnalysis.TabPages.ContainsKey(name))
            {
                TabPage tab = new TabPage();
                tab.Name = name;
                tab.Text = title;
                tab.AutoScroll = true;
                result = new TableLayoutPanel();
                result.ColumnCount = 1;
                result.RowCount = 1;
                result.GrowStyle = isVerticalStyle ? TableLayoutPanelGrowStyle.AddColumns : TableLayoutPanelGrowStyle.AddRows;
                result.AutoSize = true;
                result.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                tab.Controls.Add(result);
                tabbedAnalysis.TabPages.Add(tab);
            }
            else
            {
                int index = tabbedAnalysis.TabPages.IndexOfKey(name);
                TabPage tab = tabbedAnalysis.TabPages[index];
                result = (TableLayoutPanel)tab.Controls[0];
            }
            return result;
        }

        private void uziItem_Click(object sender, EventArgs e)
        {
            TableLayoutPanel container = getTabContainer("uziTab", "УЗИ", false);
            UziAnalysisControl control = new UziAnalysisControl(null, false);
            container.Controls.Add(control);
        }

        private void bloodItem_Click(object sender, EventArgs e)
        {
            TableLayoutPanel container = getTabContainer("bloodTab", "Анализы крови", true);
            BloodAnalysisControl blood = new BloodAnalysisControl(null, false);
            container.Controls.Add(blood);
        }

        private void ekgItem_Click(object sender, EventArgs e)
        {
            TableLayoutPanel container = getTabContainer("ekgTab", "ЭКГ", false);
            EkgAnalysisControlcs ekg = new EkgAnalysisControlcs(null, false);
            container.Controls.Add(ekg);
        }

        private void xRayItem_Click(object sender, EventArgs e)
        {
            TableLayoutPanel page = getTabContainer("xRayTab", "Рентген", false);
        }

        private void holterItem_Click(object sender, EventArgs e)
        {
            TableLayoutPanel container = getTabContainer("holterTab", "Холтер", true);
            HolterControl ekg = new HolterControl(null, false);
            container.Controls.Add(ekg);
        }

        private void specialistItem_Click(object sender, EventArgs e)
        {
            TableLayoutPanel container = getTabContainer("specsTab", "Заключения специалистов", true);
            SpecialistConclusionControl ekg = new SpecialistConclusionControl(null, false);
            container.Controls.Add(ekg);
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            saveInspectionObj(service);
            saveIssuedMedicine(service);
            saveAnalysis(service);

            ITemplateProcessor tp = TemplateProcessorManager.getProcessorByObjectType(DdtInspection.TABLE_NAME);
            if (tp != null)
            {
                string filled = tp.processTemplate(hospitalitySession.ObjectId, inspectionObj.RObjectId, new Dictionary<string, string>());
                TemplatesUtils.showDocument(filled);
            }
        }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            int currentTabIndx = tabbedContainer.SelectedIndex;
            if (currentTabIndx > 0)
            {
                tabbedContainer.SelectTab(--currentTabIndx);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            int currentTabIndx = tabbedContainer.SelectedIndex;
            if (currentTabIndx < tabbedContainer.TabCount - 1)
            {
                tabbedContainer.SelectTab(++currentTabIndx);
            }
        }

        private void inspectionDate_ValueChanged(object sender, EventArgs e)
        {
            DataService service = new DataService();
            DateTime startDate = CommonUtils.constructDateWIthTime(inspectionDate.Value, inspectionTime.Value);

            DdtJournal kagJournal = CommonUtils.resolveKagJournal(service, startDate, hospitalitySession.ObjectId);
            initKag(service, kagJournal);
        }
        //
        private void addFirstInsBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            String meListId = service.querySingleString(@"SELECT * FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='" +
                   hospitalitySession.ObjectId + "' AND dss_parent_type='ddt_anamnesis'");
            if (CommonUtils.isNotBlank(meListId))
            {
                List<DdtCure> cures = service.queryObjectsCollection<DdtCure>(@"SELECT cures.* FROM " + DdtCure.TABLE_NAME + " cures, " + DdtIssuedMedicine.TABLE_NAME +
                    " meds WHERE meds.dsid_med_list='" + meListId + "' AND meds.dsid_cure=cures.r_object_id");
                issuedMedicineContainer.refreshData(service, cures);
            }
        }

        private void selectMedListBtn_Click(object sender, EventArgs e)
        {
            if (selector == null)
            {
                selector = new AnalysisSelector();
            }

            selector.ShowDialog(DdtIssuedMedicineList.TABLE_NAME, "dsid_hospitality_session='" + hospitalitySession.ObjectId + "'", "dsdt_issuing_date", "r_object_id", null);
            if (selector.isSuccess())
            {
                List<string> ids = selector.returnValues();
                if (ids.Count > 0)
                {
                    DataService service = new DataService();
                    string meListId = ids[0];
                    if (CommonUtils.isNotBlank(meListId))
                    {
                        List<DdtCure> cures = service.queryObjectsCollection<DdtCure>(@"SELECT cures.* FROM " + DdtCure.TABLE_NAME + " cures, " + DdtIssuedMedicine.TABLE_NAME +
                            " meds WHERE meds.dsid_med_list='" + meListId + "' AND meds.dsid_cure=cures.r_object_id");
                        issuedMedicineContainer.refreshData(service, cures);
                    }
                }
            }
        }
    }
}
