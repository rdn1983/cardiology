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

                DdvPatient patient = service.GetDdvPatientService().GetById(hospitalitySession.Patient);
                if (patient != null)
                {
                    Text += " " + patient.ShortName;
                }
                DdtEpicrisis epicrisis = service.GetDdtEpicrisisService().GetById(objectId);
                if (epicrisis != null)
                {
                    diagnosisTxt.Text = epicrisis.Diagnosis;
                    epicrisisDateTxt.Value = epicrisis.EpicrisisDate;
                    refreshGrid();
                }
            }
            else
            {
                diagnosisTxt.Text = hospitalitySession.Diagnosis;
            }
        }

        private void refreshGrid()
        {
            analysisGrid.Rows.Clear();

            IList<DdtEkg> ekg = service.GetDdtEkgService().GetListByParentId(objectId);
            foreach (DdtEkg e in ekg)
            {
                analysisGrid.Rows.Add(e.ObjectId, DdtEkg.NAME, "Анализы: ЭКГ", "Дата проведения:" + e.AnalysisDate.ToLongDateString(), null);
            }

            IList<DdtEgds> egds = service.GetDdtEgdsService().GetListByParentId(objectId);
            foreach (DdtEgds e in egds)
            {
                analysisGrid.Rows.Add(e.ObjectId, DdtEgds.NAME, "Анализы: ЭГДС", "Дата проведения:" + e.AnalysisDate.ToLongDateString(), null);
            }

            IList<DdtUzi> uzi = service.GetDdtUziService().GetListByParentId(objectId);
            foreach (DdtUzi e in uzi)
            {
                analysisGrid.Rows.Add(e.ObjectId, DdtUzi.NAME, "Анализы: УЗИ", "Дата проведения:" + e.AnalysisDate.ToLongDateString(), null);
            }

            IList<DdtXRay> zray = service.GetDdtXrayService().GetListByParentId(objectId);
            foreach (DdtXRay e in zray)
            {
                analysisGrid.Rows.Add(e.ObjectId, DdtXRay.NAME, "Анализы: Рентген", "Дата проведения:" + e.AnalysisDate.ToLongDateString(), null);
            }
            IList<DdtBloodAnalysis> blood = service.GetDdtBloodAnalysisService().GetListByParenId(objectId);
            foreach (DdtBloodAnalysis e in blood)
            {
                analysisGrid.Rows.Add(e.ObjectId, DdtBloodAnalysis.NAME, "Анализы: Кровь", "Дата проведения:" + e.AnalysisDate.ToLongDateString(), null);
            }
            IList<DdtUrineAnalysis> urine = service.GetDdtUrineAnalysisService().getListByParentId(objectId);
            foreach (DdtUrineAnalysis e in urine)
            {
                analysisGrid.Rows.Add(e.ObjectId, DdtUrineAnalysis.NAME, "Анализы: Моча", "Дата проведения:" + e.AnalysisDate.ToLongDateString(), null);
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
                " 'ddt_egds', 'ddt_xray', 'ddt_uzi', 'ddt_blood_analysis')";
            List<string> allAddedAnalysis = getAddedAnalysisIds();
            selector.ShowDialog("ddv_history", queryCnd, "dss_operation_name", "dsid_operation_id", allAddedAnalysis);
            if (selector.isSuccess())
            {

                List<string> diagnosies = selector.returnValues();
                foreach (string v in diagnosies)
                {
                    DdvHistory history = service.GetDdvHistoryService().GetHistoryByOperationId(v);
                    analysisGrid.Rows.Add(history.OperationId, history.OperationType, history.OperationName, "Дата проведения:" + history.OperationDate.ToLongDateString(), null);
                }
            }
        }

        private List<string> getAddedAnalysisIds()
        {
            List<string> result = new List<string>();
            DataGridViewRowCollection rows = analysisGrid.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                DataGridViewRow row = rows[i];
                string id = (string)row.Cells[0].Value;
                result.Add(id);
            }
            return result;
        }

        private void print_Click(object sender, EventArgs e)
        {
            saveObject();
            ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtEpicrisis.NAME);
            string path = processor.processTemplate(service, hospitalitySession.ObjectId, objectId, new Dictionary<string, string>());
            TemplatesUtils.ShowDocument(path);
        }

        private void saveObject()
        {

            DdtEpicrisis obj = service.GetDdtEpicrisisService().GetById(objectId);
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
            objectId = service.GetDdtEpicrisisService().Save(obj);
            obj.ObjectId = objectId;

            DataGridViewRowCollection rows = analysisGrid.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                DataGridViewRow row = rows[i];
                string id = (string)row.Cells[0].Value;
                string type = (string)row.Cells[1].Value;
                service.Execute(@"update " + type + " set dsid_parent='" + objectId + "' , dss_parent_type='ddt_epicrisis' WHERE r_object_id ='" + id + "'");
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            saveObject();
            Close();
        }

        private void analysisGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (analysisGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
            {
                DataGridViewRow row = analysisGrid.Rows[e.RowIndex];
                string id = (string)row.Cells[0].Value;
                string type = (string)row.Cells[1].Value;
                service.Execute(@"update " + type + " set dsid_parent=null , dss_parent_type='ddt_epicrisis' WHERE r_object_id ='" + id + "'");
                refreshGrid();
            }
        }
    }
}
