using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class PatientsHistory : Form
    {
        private readonly IDbDataService service;
        private DdtHospital hospitalitySession;
        public PatientsHistory(IDbDataService service, DdtHospital hospitalitySession)
        {
            this.service = service;
            this.hospitalitySession = hospitalitySession;
            InitializeComponent();
            this.patientHistoryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DdvPatient patient = service.GetDdvPatientService().GetById(hospitalitySession.Patient);
            if (patient != null)
            {
                Text += " " + patient.ShortName;
            }
        }

        private void LoadPatientsHistoryGrid()
        {
            patientHistoryGrid.Rows.Clear();
            string query = @"SELECT * FROM ddv_history WHERE dsid_hospitality_session='" + hospitalitySession.ObjectId + "' order by dsdt_operation_date";
            List<DdvHistory> allHspitalPatients = service.queryObjectsCollection<DdvHistory>(query);
            for (int i = 0; i < allHspitalPatients.Count(); i++)
            {
                DdvHistory h = allHspitalPatients[i];
                patientHistoryGrid.Rows.Add(false, h.HospitalitySession, h.OperationType, h.OperationId, h.OperationName, h.OperationDate, h.DoctorName, h.Description);
            }

        }


        private void bloodTrunsfusionMenuItem_Click(object sender, EventArgs e)
        {
            Perelivanie form = new Perelivanie();
            form.ShowDialog();
        }

        private void issuingMedicineMenuItem_Click(object sender, EventArgs e)
        {
            IssuedMedicine form = new IssuedMedicine(this.service, hospitalitySession, null);
            form.ShowDialog();
        }

        private void morningInspectationMenuItem_Click(object sender, EventArgs e)
        {
            Inspection form = new Inspection(hospitalitySession, null);
            form.ShowDialog();
        }

        private void journalBeforeKAGMeniItem_Click(object sender, EventArgs e)
        {
            JournalBeforeKag form = new JournalBeforeKag(hospitalitySession, null, (int)DdtJournalDsiType.BEFORE_KAG);
            form.ShowDialog();
        }

        private void journalAfterKAGMnuItem_Click(object sender, EventArgs e)
        {
            JournalAfterKAG form = new JournalAfterKAG(hospitalitySession, null);
            form.ShowDialog();
        }

        private void journalWithoutKAGMenuItem_Click(object sender, EventArgs e)
        {
            JournalBeforeKag form = new JournalBeforeKag(hospitalitySession, null, (int)DdtJournalDsiType.WITHOUT_KAG);
            form.ShowDialog();
        }

        private void konsiliumItem_Click(object sender, EventArgs e)
        {
            Consilium form = new Consilium(service, hospitalitySession, null);
            form.ShowDialog();
        }

        private void PatientHistory_Activated(object sender, EventArgs e)
        {
            LoadPatientsHistoryGrid();
        }

        private void firstInspectationsItem_Click(object sender, EventArgs e)
        {
            FirstInspection form = new FirstInspection(service, hospitalitySession);
            form.ShowDialog();
        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            IEnumerator it = patientHistoryGrid.SelectedRows.GetEnumerator();
            string firstId = null;
            string firstType = null;
            List<string> ids = new List<string>();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[3];
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell) row.Cells[0];
                firstId = cell.Value.ToString();
                firstType = row.Cells[2].Value.ToString();
            }
            DataGridViewRowCollection rows = patientHistoryGrid.Rows;
            for(int i=0; i<rows.Count; i++)
            {
                DataGridViewCell cell = rows[i].Cells[3];
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)rows[i].Cells[0];
                if ((bool) checkBoxCell.Value)
                {
                    ids.Add(cell.Value.ToString());
                }
            }
            if (!ids.Contains(firstId))
            {
                ids.Add(firstId);
            }
            Form form = null;

            if (DdtAnamnesis.TABLE_NAME.Equals(firstType))
            {
                form = new FirstInspection(service, hospitalitySession);
            }
            else if (DdtJournal.TABLE_NAME.Equals(firstType))
            {
                DataService service = new DataService();
                DdtJournal jourmal = service.queryObjectById<DdtJournal>(firstId);
                if (jourmal.DsiJournalType == (int)DdtJournalDsiType.AFTER_KAG)
                {
                    form = new JournalAfterKAG(hospitalitySession, firstId);
                }
                else
                {
                    form = new JournalBeforeKag(hospitalitySession, ids, -1);
                }
            }
            else if (DdtIssuedMedicineList.TABLE_NAME.Equals(firstType))
            {
                form = new IssuedMedicine(this.service, hospitalitySession, firstId);
            }
            else if (DdtEgds.TABLE_NAME.Equals(firstType) || DdtXRay.TABLE_NAME.Equals(firstType)
                || DdtUrineAnalysis.TABLE_NAME.Equals(firstType) || DdtEkg.TABLE_NAME.Equals(firstType)
                || DdtSpecialistConclusion.TABLE_NAME.Equals(firstType) || DdtUzi.TABLE_NAME.Equals(firstType)
                || DdtKag.TABLE_NAME.Equals(firstType) || DdtHolter.TABLE_NAME.Equals(firstType)
                || DdtBloodAnalysis.TABLE_NAME.Equals(firstType) || DdtHormones.TABLE_NAME.Equals(firstType)
                || DdtCoagulogram.TABLE_NAME.Equals(firstType) || DdtOncologicMarkers.TABLE_NAME.Equals(firstType))
            {
                form = new AnalysisContainer(hospitalitySession, firstType, firstId);
            }
            else if (DdtConsilium.TABLE_NAME.Equals(firstType))
            {
                form = new Consilium(service, hospitalitySession, firstId);
            }
            else if (DdtSerology.TABLE_NAME.Equals(firstType))
            {
                form = new Serology(service, hospitalitySession);
            }
            else if (DdtInspection.TABLE_NAME.Equals(firstType))
            {
                form = new Inspection(hospitalitySession, firstId);
            }
            else if (DdtEpicrisis.TABLE_NAME.Equals(firstType))
            {
                form = new PreoperativeEpicrisiscs(hospitalitySession, firstId);
            }
            else if (DdtHospital.TABLE_NAME.Equals(firstType))
            {
                form = new PatientAdmission(service, hospitalitySession);
            }

            if (form != null)
            {
                form.ShowDialog();
            }
        }

        private void ekgItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtEkg.TABLE_NAME, null);
            container.ShowDialog();
        }

        private void bloodItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtBloodAnalysis.TABLE_NAME, null);
            container.ShowDialog();
        }

        private void urineItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtUrineAnalysis.TABLE_NAME, null);
            container.ShowDialog();
        }

        private void holterItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtHolter.TABLE_NAME, null);
            container.ShowDialog();
        }

        private void kagItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtKag.TABLE_NAME, null);
            container.ShowDialog();
        }

        private void egdsItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtEgds.TABLE_NAME, null);
            container.ShowDialog();
        }

        private void specialistItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtSpecialistConclusion.TABLE_NAME, null);
            container.ShowDialog();
        }

        private void uziItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtUzi.TABLE_NAME, null);
            container.ShowDialog();
        }


        private void patientHistoryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bool oldValue = (bool)patientHistoryGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                patientHistoryGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !oldValue;
                patientHistoryGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = oldValue ? Color.Empty : Color.LightSteelBlue;
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            int rowCount = patientHistoryGrid.Rows.Count;
            List<string> paths = new List<string>();
            foreach (DataGridViewRow row in patientHistoryGrid.Rows)
            {
                bool checkd = (bool)row.Cells[0].Value;
                if (checkd)
                {
                    ITemplateProcessor te = TemplateProcessorManager.getProcessorByObjectType((string)row.Cells[2].Value);
                    if (te != null)
                    {
                        string pathFile = te.processTemplate(hospitalitySession.ObjectId, (string)row.Cells[3].Value, null);
                        paths.Add(pathFile);
                    }
                    Console.WriteLine();
                }
            }
            string resultPath = TemplatesUtils.mergeFiles(paths.ToArray(), false);
            TemplatesUtils.showDocument(resultPath);
        }

        private void deleteMenu_Click(object sender, EventArgs e)
        {
            IEnumerator it = patientHistoryGrid.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[3];
                string idsValue = cell.Value.ToString();
                string typeValue = row.Cells[2].Value.ToString();
                if (!DdtHospital.TABLE_NAME.Equals(typeValue))
                {
                    DataService service = new DataService();
                    service.delete(@"delete from " + typeValue + " WHERE r_object_id='" + idsValue + "'");
                    service.delete(@"delete from ddt_history  WHERE dsid_operation_id='" + idsValue + "'");
                    LoadPatientsHistoryGrid();
                }
            }
        }

        private void bloodTypeItem_Click(object sender, EventArgs e)
        {
            Serology form = new Serology(service, hospitalitySession);
            form.ShowDialog();
        }

        private void hormonesItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtHormones.TABLE_NAME, null);
            container.ShowDialog();
        }

        private void koagulogrammItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtCoagulogram.TABLE_NAME, null);
            container.ShowDialog();
        }

        private void beforeOperationItem_Click(object sender, EventArgs e)
        {
            PreoperativeEpicrisiscs container = new PreoperativeEpicrisiscs(hospitalitySession, null);
            container.ShowDialog();
        }

        private void xrayMenuItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtXRay.TABLE_NAME, null);
            container.ShowDialog();
        }

        private void oncologicMarkersItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtOncologicMarkers.TABLE_NAME, null);
            container.ShowDialog();
        }
    }
}
