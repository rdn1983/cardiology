using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class Inspection : Form, IAutoSaveForm
    {
        private readonly IDbDataService service;
        private DdtHospital hospitalitySession;
        private DdtInspection inspectionObj;
        private string kagId;

        public Inspection(IDbDataService service, DdtHospital hospitalitySession, string id)
        {
            this.service = service;
            this.hospitalitySession = hospitalitySession;
            SilentSaver.setForm(this);
            InitializeComponent();
            initControls(id);
            List<string> validTypes = new List<string>() { "ddt_blood_analysis", "ddt_ekg", "ddt_urine_analysis", "ddt_egds", "ddt_xray", "ddt_holter", "ddt_specialist_conclusion", "ddt_uzi" };
            analysisTabControl1.init(hospitalitySession, inspectionObj?.ObjectId, DdtInspection.NAME, validTypes);
        }

        private void initControls(string inspectionObjId)
        {
            kagContainer.Visible = false;

            DdvPatient patient = service.GetDdvPatientService().GetById(hospitalitySession.Patient);
            if (patient != null)
            {
                Text += " " + patient.ShortName;
            }

            inspectionObj = service.GetDdtInspectionService().GetById(inspectionObjId);
            DateTime startDate = inspectionObj == null ? DateTime.Now : inspectionObj.InspectionDate;
            DdtJournal kagJournal = CommonUtils.ResolveKagJournal(service, startDate, hospitalitySession.ObjectId);

            if (inspectionObj != null)
            {
                complaintsTxt.Text = inspectionObj.Complaints;
                diagnosisTxt.Text = inspectionObj.Diagnosis;
                inspectionTxt.Text = inspectionObj.Inspection;
                resultTxt.Text = inspectionObj.InspectionResult;
                kateterPlacementTxt.Text = inspectionObj.KateterPlacement;
            }
            else
            {
                if (kagJournal != null)
                {
                    diagnosisTxt.Text = kagJournal.Diagnosis;
                    DdtVariousSpecConcluson releaseConclusion = service.GetDdtVariousSpecConclusonService().GetByParentId(kagJournal.ObjectId);
                    if (releaseConclusion != null)
                    {
                        inspectionTxt.Text = releaseConclusion.SpecialistConclusion;
                    }
                }
                else
                {
                    diagnosisTxt.Text = hospitalitySession.Diagnosis;
                }


            }

            initKag(service, kagJournal);
        }


        private void initKag(IDbDataService service, DdtJournal kagJournal)
        {
            bool hasKag = false;
            if (kagJournal != null)
            {
                DdtKag kag = service.GetDdtKagService().GetByParentId(kagJournal.ObjectId);
                if (kag != null && inspectionObj!=null)
                {
                    kagId = kag.ObjectId;
                    DdtRelation relation = new DdtRelation();
                    relation.Parent = inspectionObj.ObjectId;
                    relation.Child = kag.ObjectId;
                    relation.ChildType = DdtKag.NAME;

                    DbDataService.GetInstance().GetDdtRelationService().Save(relation);
                    kagContainer.Visible = true;
                    hasKag = true;
                }
            }
        }


        private void saveBtn_Click(object sender, EventArgs e)
        {

            if (Save())
            {
                Close();
            }
        }

        public bool Save()
        {
            if (!getIsValid())
            {
                return false;
            }


            saveInspectionObj(service);
            SaveAnalysis();
            return true;
        }

        private bool getIsValid()
        {
            return true;
        }

        private void saveInspectionObj(IDbDataService service)
        {
            if (inspectionObj == null)
            {
                inspectionObj = new DdtInspection();
                inspectionObj.Doctor = hospitalitySession.CuringDoctor;
                inspectionObj.HospitalitySession = hospitalitySession.ObjectId;
                inspectionObj.Patient = hospitalitySession.Patient;
            }

            inspectionObj.Complaints = getSafeStringValue(complaintsTxt);
            inspectionObj.Diagnosis = getSafeStringValue(diagnosisTxt);
            inspectionObj.Inspection = getSafeStringValue(inspectionTxt);
            inspectionObj.InspectionResult = getSafeStringValue(resultTxt);
            inspectionObj.KateterPlacement = getSafeStringValue(kateterPlacementTxt);
            inspectionObj.InspectionDate = CommonUtils.ConstructDateWIthTime(inspectionDate.Value, inspectionTime.Value);
            string id = service.GetDdtInspectionService().Save(inspectionObj);
            inspectionObj.ObjectId = id;
        }



        private void SaveAnalysis()
        {
            analysisTabControl1.save(inspectionObj.ObjectId, DdtInspection.NAME);
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            Save();

            ITemplateProcessor tp = TemplateProcessorManager.getProcessorByObjectType(DdtInspection.NAME);
            if (tp != null)
            {
                string filled = tp.processTemplate(service, hospitalitySession.ObjectId, inspectionObj.ObjectId, new Dictionary<string, string>());
                TemplatesUtils.ShowDocument(filled);
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

            DateTime startDate = CommonUtils.ConstructDateWIthTime(inspectionDate.Value, inspectionTime.Value);

            DdtJournal kagJournal = CommonUtils.ResolveKagJournal(service, startDate, hospitalitySession.ObjectId);
            initKag(service, kagJournal);
        }

        private void Inspection_FormClosing(object sender, FormClosingEventArgs e)
        {
            SilentSaver.clearForm();
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

    }
}
