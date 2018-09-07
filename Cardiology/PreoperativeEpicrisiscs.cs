using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class PreoperativeEpicrisiscs : Form
    {
        private DdtHospital hospitalitySession;
        private string objectId;
        private AnalysisSelector selector;

        public PreoperativeEpicrisiscs(DdtHospital hospitalitySession, string objectId)
        {
            this.hospitalitySession = hospitalitySession;
            this.objectId = objectId;
            selector = new AnalysisSelector();
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            if (CommonUtils.isNotBlank(objectId))
            {
                DataService service = new DataService();
                DdtEpicrisis epicrisis = service.queryObjectById<DdtEpicrisis>(DdtEpicrisis.TABLE_NAME, objectId);
                if (epicrisis != null)
                {
                    diagnosisTxt.Text = epicrisis.DssDiagnosis;
                    epicrisisDateTxt.Value = epicrisis.DsdtEpicrisisDate;

                    List<DdtEkg> ekg = service.queryObjectsCollection<DdtEkg>(@"SELECT * FROM " + DdtEkg.TABLE_NAME + " where dsid_parent='" + epicrisis.RObjectId + "'");
                    foreach(DdtEkg e in ekg)
                    {
                        analysisGrid.Rows.Add(e.ObjectId, DdtEkg.TABLE_NAME, "Анализы: ЭКГ", "", "");
                    }
                    List<DdtEgds> egds = service.queryObjectsCollection<DdtEgds>(@"SELECT * FROM " + DdtEgds.TABLE_NAME + " where dsid_parent='" + epicrisis.RObjectId + "'");
                    foreach (DdtEgds e in egds)
                    {
                        analysisGrid.Rows.Add(e.ObjectId, DdtEgds.TABLE_NAME, "Анализы: ЭГДС", "", "");
                    }
                    List<DdtUzi> uzi = service.queryObjectsCollection<DdtUzi>(@"SELECT * FROM " + DdtUzi.TABLE_NAME + " where dsid_parent='" + epicrisis.RObjectId + "'");
                    foreach (DdtUzi e in uzi)
                    {
                        analysisGrid.Rows.Add(e.ObjectId, DdtUzi.TABLE_NAME, "Анализы: УЗИ", "", "");
                    }
                    List<DdtXRay> zray = service.queryObjectsCollection<DdtXRay>(@"SELECT * FROM " + DdtXRay.TABLE_NAME + " where dsid_parent='" + epicrisis.RObjectId + "'");
                    foreach (DdtXRay e in zray)
                    {
                        analysisGrid.Rows.Add(e.ObjectId, DdtXRay.TABLE_NAME, "Анализы: Рентген", "", "");
                    }
                    List<DdtBloodAnalysis> blood = service.queryObjectsCollection<DdtBloodAnalysis>(@"SELECT * FROM " + DdtBloodAnalysis.TABLE_NAME + " where dsid_parent='" + epicrisis.RObjectId + "'");
                    foreach (DdtBloodAnalysis e in blood)
                    {
                        analysisGrid.Rows.Add(e.RObjectId, DdtBloodAnalysis.TABLE_NAME, "Анализы: Кровь", "", "");
                    }
                }
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
                DataService service = new DataService();
                List<string> diagnosies = selector.returnValues();
                foreach (string v in diagnosies)
                {
                    DdvHistory history = service.queryObject<DdvHistory>(@"SELECT * FROM ddv_history WHERE dsid_operation_id='" + v + "'");
                    analysisGrid.Rows.Add(history.DsidOperationId, history.DssOperationType, history.DssOperationName, "", "");
                }
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            saveObject();
            ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtEpicrisis.TABLE_NAME);
            string path = processor.processTemplate(hospitalitySession.ObjectId, objectId, new Dictionary<string, string>());
            TemplatesUtils.showDocument(path);
            Close();
        }

        private void saveObject()
        {
            DataService service = new DataService();
            DdtEpicrisis obj = service.queryObjectById<DdtEpicrisis>(DdtEpicrisis.TABLE_NAME, objectId);
            if (obj == null)
            {
                obj = new DdtEpicrisis();
                obj.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                obj.DsidHospitalitySession = hospitalitySession.ObjectId;
                obj.DsidPatient = hospitalitySession.DsidPatient;
            }
            obj.DsdtEpicrisisDate = epicrisisDateTxt.Value;
            obj.DssDiagnosis = diagnosisTxt.Text;
            obj.DsiEpicrisisType = (int)DdtEpicrisisDsiType.BEFORE_OPERATION;
            objectId = service.updateOrCreateIfNeedObject<DdtEpicrisis>(obj, DdtEpicrisis.TABLE_NAME, objectId);
            obj.RObjectId = objectId;

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
