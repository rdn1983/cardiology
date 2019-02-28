using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class PreoperativeEpicrisiscs : Form
    {
        private readonly IDbDataService service;
        private DdtHospital hospitalitySession;
        private string objectId;
        private AnalysisSelector selector;

        public PreoperativeEpicrisiscs(IDbDataService service, DdtHospital hospitalitySession, string objectId)
        {
            this.hospitalitySession = hospitalitySession;
            this.objectId = objectId;
            this.service = service;
            selector = new AnalysisSelector();
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            if (!string.IsNullOrEmpty(objectId))
            {
    
                DdvPatient patient = service.queryObjectById<DdvPatient>(hospitalitySession.Patient);
                if (patient != null)
                {
                    Text += " " + patient.ShortName;
                }
                DdtEpicrisis epicrisis = service.queryObjectById<DdtEpicrisis>(objectId);
                if (epicrisis != null)
                {
                    diagnosisTxt.Text = epicrisis.Diagnosis;
                    epicrisisDateTxt.Value = epicrisis.EpicrisisDate;

                    List<DdtEkg> ekg = service.queryObjectsCollection<DdtEkg>(@"SELECT * FROM " + DdtEkg.NAME + " where dsid_parent='" + epicrisis.ObjectId + "'");
                    foreach(DdtEkg e in ekg)
                    {
                        analysisGrid.Rows.Add(e.ObjectId, DdtEkg.NAME, "Анализы: ЭКГ", "", "");
                    }
                    List<DdtEgds> egds = service.queryObjectsCollection<DdtEgds>(@"SELECT * FROM " + DdtEgds.NAME + " where dsid_parent='" + epicrisis.ObjectId + "'");
                    foreach (DdtEgds e in egds)
                    {
                        analysisGrid.Rows.Add(e.ObjectId, DdtEgds.NAME, "Анализы: ЭГДС", "", "");
                    }
                    List<DdtUzi> uzi = service.queryObjectsCollection<DdtUzi>(@"SELECT * FROM " + DdtUzi.NAME + " where dsid_parent='" + epicrisis.ObjectId + "'");
                    foreach (DdtUzi e in uzi)
                    {
                        analysisGrid.Rows.Add(e.ObjectId, DdtUzi.NAME, "Анализы: УЗИ", "", "");
                    }
                    List<DdtXRay> zray = service.queryObjectsCollection<DdtXRay>(@"SELECT * FROM " + DdtXRay.NAME + " where dsid_parent='" + epicrisis.ObjectId + "'");
                    foreach (DdtXRay e in zray)
                    {
                        analysisGrid.Rows.Add(e.ObjectId, DdtXRay.NAME, "Анализы: Рентген", "", "");
                    }
                    List<DdtBloodAnalysis> blood = service.queryObjectsCollection<DdtBloodAnalysis>(@"SELECT * FROM " + DdtBloodAnalysis.NAME + " where dsid_parent='" + epicrisis.ObjectId + "'");
                    foreach (DdtBloodAnalysis e in blood)
                    {
                        analysisGrid.Rows.Add(e.ObjectId, DdtBloodAnalysis.NAME, "Анализы: Кровь", "", "");
                    }
                }
            } else
            {
                diagnosisTxt.Text = hospitalitySession.Diagnosis;
            }
        }

        private void chooseDiagnosisBtn_Click(object sender, EventArgs e)
        {
            selector.ShowDialog("ddv_all_diagnosis", "dsid_hospitality_session='" + hospitalitySession.ObjectId + "'", "dss_diagnosis", "r_object_id", null);
            if (selector.isSuccess())
            {
                List<string> diagnosies = selector.returnLabels();
                StringBuilder str = new StringBuilder();
                foreach (string v in diagnosies)
                {
                    str.Append(v);
                }
                diagnosisTxt.Text = str.ToString();
            }
        }

        private void chooseAnalysisBtn_Click(object sender, EventArgs e)
        {
            string queryCnd = "dsid_hospitality_session='" + hospitalitySession.ObjectId + "' AND dss_operation_type IN ('ddt_ekg', 'ddt_urine_analysis'," +
                " 'ddt_kag', 'ddt_egds', 'ddt_xray', 'ddt_specialist_conclusion', 'ddt_holter', 'ddt_blood_analysis')";
            selector.ShowDialog("ddv_history", queryCnd, "dss_operation_name", "dsid_operation_id", null);
            if (selector.isSuccess())
            {
    
                List<string> diagnosies = selector.returnValues();
                foreach (string v in diagnosies)
                {
                    DdvHistory history = service.queryObject<DdvHistory>(@"SELECT * FROM ddv_history WHERE dsid_operation_id='" + v + "'");
                    analysisGrid.Rows.Add(history.OperationId, history.OperationType, history.OperationName, "", "");
                }
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            saveObject();
            ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtEpicrisis.NAME);
            string path = processor.processTemplate(hospitalitySession.ObjectId, objectId, new Dictionary<string, string>());
            TemplatesUtils.ShowDocument(path);
            Close();
        }

        private void saveObject()
        {

            DdtEpicrisis obj = service.queryObjectById<DdtEpicrisis>(objectId);
            if (obj == null)
            {
                obj = new DdtEpicrisis();
                obj.Doctor = hospitalitySession.CuringDoctor;
                obj.HospitalitySession = hospitalitySession.ObjectId;
                obj.Patient = hospitalitySession.Patient;
            }
            obj.EpicrisisDate = epicrisisDateTxt.Value;
            obj.Diagnosis = diagnosisTxt.Text;
            obj.EpicrisisType = (int)DdtEpicrisisDsiType.BEFORE_OPERATION;
            objectId = service.updateOrCreateIfNeedObject<DdtEpicrisis>(obj, DdtEpicrisis.NAME, objectId);
            obj.ObjectId = objectId;

            DataGridViewRowCollection rows = analysisGrid.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                DataGridViewRow row = rows[i];
                string id = (string)row.Cells[0].Value;
                string type = (string)row.Cells[1].Value;
                service.update(@"update " + type + " set dsid_parent='" + objectId + "' , dss_parent_type='ddt_epicrisis' WHERE r_object_id ='" + id + "'");
            }
        }
    }
}
