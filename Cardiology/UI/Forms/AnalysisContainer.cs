using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model2;
using Cardiology.UI.Controls;

namespace Cardiology.UI.Forms
{
    public partial class AnalysisContainer : Form
    {
        private const string FIRST_ANALYSIS_QRY_TEMPLATE = @"SELECT * FROM {0} WHERE dss_parent_type='ddt_anamnesis' and dsid_hospitality_session='{1}'";

        private string typeName;
        private List<string> selectedIds;
        private string currentId;
        private DdtHospital hospitalitySession;

        private static AnalysisSelector selector;

        public AnalysisContainer(DdtHospital hospitalitySession, string typeName, string objectId)
        {
            this.hospitalitySession = hospitalitySession;
            this.typeName = typeName;
            this.currentId = objectId;
            selectedIds = new List<string>();

            InitializeComponent();
            bool isHorizontalStyle = DdtEkg.TABLE_NAME.Equals(typeName) || DdtEgds.TABLE_NAME.Equals(typeName) || DdtHolter.TABLE_NAME.Equals(typeName);
            combainingContainer.GrowStyle = isHorizontalStyle ? TableLayoutPanelGrowStyle.AddRows : TableLayoutPanelGrowStyle.AddColumns;
            combainingContainer.RowStyles.Clear();
            combainingContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            initControls();
            initTitle();
        }

        private void initControls()
        {
            bool needAdmissionAnalysis = DdtUrineAnalysis.TABLE_NAME.Equals(typeName) || DdtBloodAnalysis.TABLE_NAME.Equals(typeName)
                || DdtEgds.TABLE_NAME.Equals(typeName) || DdtEkg.TABLE_NAME.Equals(typeName);
            DataService service = new DataService();
            if (needAdmissionAnalysis)
            {
                string firstAnalysisId = service.querySingleString(string.Format(FIRST_ANALYSIS_QRY_TEMPLATE, typeName, hospitalitySession.ObjectId));
                if (firstAnalysisId != null && !firstAnalysisId.Equals(currentId))
                {
                    createControl(firstAnalysisId);
                }
            }
            createControl(currentId);
        }

        private void createControl(string objectId)
        {
            selectedIds.Add(objectId);

            if (DdtBloodAnalysis.TABLE_NAME.Equals(typeName))
            {
                combainingContainer.Controls.Add(new BloodAnalysisControl(objectId, objectId != null && !objectId.Equals(currentId)));
            }
            else if (DdtUrineAnalysis.TABLE_NAME.Equals(typeName))
            {
                combainingContainer.Controls.Add(new UrineAnalysisControl(objectId, objectId != null && !objectId.Equals(currentId)));
            }
            else if (DdtEkg.TABLE_NAME.Equals(typeName))
            {
                EkgAnalysisControlcs ekg = new EkgAnalysisControlcs(objectId, objectId != null && !objectId.Equals(currentId));
                combainingContainer.Controls.Add(ekg);
                Console.WriteLine(ekg.Size);
            }
            else if (DdtKag.TABLE_NAME.Equals(typeName))
            {
                combainingContainer.Controls.Add(new KagAnalysisControl(objectId, objectId != null && !objectId.Equals(currentId), hospitalitySession.ObjectId));
            }
            else if (DdtEgds.TABLE_NAME.Equals(typeName))
            {
                combainingContainer.Controls.Add(new EgdsAnalysisControl(objectId, objectId != null && !objectId.Equals(currentId)));
            }
            else if (DdtXRay.TABLE_NAME.Equals(typeName))
            {
                combainingContainer.Controls.Add(new XRayControl(objectId, objectId != null && !objectId.Equals(currentId)));
            }
            else if (DdtHolter.TABLE_NAME.Equals(typeName))
            {
                combainingContainer.Controls.Add(new HolterControl(objectId, objectId != null && !objectId.Equals(currentId)));
            }
            else if (DdtUzi.TABLE_NAME.Equals(typeName))
            {
                combainingContainer.Controls.Add(new UziAnalysisControl(objectId, objectId != null && !objectId.Equals(currentId)));
            }
            else if (DdtSpecialistConclusion.TABLE_NAME.Equals(typeName))
            {
                combainingContainer.Controls.Add(new SpecialistConclusionControl(objectId, objectId != null && !objectId.Equals(currentId)));
            }
            else if (DdtHormones.TABLE_NAME.Equals(typeName))
            {
                combainingContainer.Controls.Add(new HormonesControl(objectId, objectId != null && !objectId.Equals(currentId)));
            }
            else if (DdtCoagulogram.TABLE_NAME.Equals(typeName))
            {
                combainingContainer.Controls.Add(new CoagulogrammControl(objectId, objectId != null && !objectId.Equals(currentId)));
            }
            else if (DdtOncologicMarkers.TABLE_NAME.Equals(typeName))
            {
                combainingContainer.Controls.Add(new OncologicMarkersControl(objectId, objectId != null && !objectId.Equals(currentId), hospitalitySession.ObjectId));
            }
        }

        private void initTitle()
        {
            if (DdtBloodAnalysis.TABLE_NAME.Equals(typeName))
            {
                this.Text = "Клинический анализ крови";
            }
            else if (DdtUrineAnalysis.TABLE_NAME.Equals(typeName))
            {
                this.Text = "Анализ мочи";
            }
            else if (DdtKag.TABLE_NAME.Equals(typeName))
            {
                this.Text = "КАГ";
            }
            else if (DdtEkg.TABLE_NAME.Equals(typeName))
            {
                this.Text = "ЭКГ";
            }
            else if (DdtEgds.TABLE_NAME.Equals(typeName))
            {
                this.Text = "ЭГДС";
            }
            else if (DdtUzi.TABLE_NAME.Equals(typeName))
            {
                this.Text = "УЗИ";
            }
            else if (DdtXRay.TABLE_NAME.Equals(typeName))
            {
                this.Text = "Рентген/КТ";
            }
            else if (DdtHolter.TABLE_NAME.Equals(typeName))
            {
                this.Text = "Холтер/СМАД";
            }
            else if (DdtSpecialistConclusion.TABLE_NAME.Equals(typeName))
            {
                this.Text = "Заключение специалистов";
            }
            else if (DdtCoagulogram.TABLE_NAME.Equals(typeName))
            {
                this.Text = "Коагулограмма";
            }
            else if (DdtHormones.TABLE_NAME.Equals(typeName))
            {
                this.Text = "Гормоны";
            }
            else if (DdtHormones.TABLE_NAME.Equals(typeName))
            {
                this.Text = "Онкомаркеры";
            }
            DataService service = new DataService();
            DdtPatient patient = service.queryObjectById<DdtPatient>(hospitalitySession.DsidPatient);
            if (patient != null)
            {
                this.Text += " " + patient.DssInitials;
            }
        }

        private void selectToContainer_Click(object sender, EventArgs e)
        {
            if (selector == null)
            {
                selector = new AnalysisSelector();
            }
            selector.ShowDialog(typeName, "dsid_hospitality_session='" + hospitalitySession.ObjectId + "'", "dsdt_analysis_date", "r_object_id", selectedIds);
            if (selector.isSuccess())
            {
                List<string> result = selector.returnValues();
                foreach (string id in result)
                {
                    createControl(id);
                }

            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            combainingContainer.Controls.Clear();
            selectedIds.Clear();
            currentId = null;
            hospitalitySession = null;
            typeName = null;
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            foreach (Control c in combainingContainer.Controls)
            {
                IDocbaseControl docbaseControl = (IDocbaseControl)c;
                docbaseControl.saveObject(hospitalitySession, null, null);
            }
            Close();
        }
    }
}
