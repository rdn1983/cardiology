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
            IList<DdvHistory> allHspitalPatients = service.GetDdvHistoryService().GetHistoryByHospitalSession(hospitalitySession.ObjectId);
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

            if (DdtAnamnesis.NAME.Equals(firstType))
            {
                form = new FirstInspection(service, hospitalitySession);
            }
            else if (DdtJournal.NAME.Equals(firstType))
            {
                DataService service = new DataService();
                DdtJournal journal = service.queryObjectById<DdtJournal>(firstId);
                if (journal.JournalType == (int)DdtJournalDsiType.AFTER_KAG)
                {
                    form = new JournalAfterKAG(hospitalitySession, firstId);
                }
                else
                {
                    form = new JournalBeforeKag(hospitalitySession, ids, -1);
                }
            }
            else if (DdtIssuedMedicineList.NAME.Equals(firstType))
            {
                form = new IssuedMedicine(this.service, hospitalitySession, firstId);
            }
            else if (DdtEgds.NAME.Equals(firstType) || DdtXRay.NAME.Equals(firstType)
                || DdtUrineAnalysis.NAME.Equals(firstType) || DdtEkg.NAME.Equals(firstType)
                || DdtSpecialistConclusion.NAME.Equals(firstType) || DdtUzi.NAME.Equals(firstType)
                || DdtKag.NAME.Equals(firstType) || DdtHolter.NAME.Equals(firstType)
                || DdtBloodAnalysis.NAME.Equals(firstType) || DdtHormones.NAME.Equals(firstType)
                || DdtCoagulogram.NAME.Equals(firstType) || DdtOncologicMarkers.NAME.Equals(firstType))
            {
                form = new AnalysisContainer(hospitalitySession, firstType, firstId);
            }
            else if (DdtConsilium.NAME.Equals(firstType))
            {
                form = new Consilium(service, hospitalitySession, firstId);
            }
            else if (DdtSerology.NAME.Equals(firstType))
            {
                form = new Serology(service, hospitalitySession);
            }
            else if (DdtInspection.NAME.Equals(firstType))
            {
                form = new Inspection(hospitalitySession, firstId);
            }
            else if (DdtEpicrisis.NAME.Equals(firstType))
            {
                form = new PreoperativeEpicrisiscs(hospitalitySession, firstId);
            }
            else if (DdtHospital.NAME.Equals(firstType))
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
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtEkg.NAME, null);
            container.ShowDialog();
        }

        private void bloodItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtBloodAnalysis.NAME, null);
            container.ShowDialog();
        }

        private void urineItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtUrineAnalysis.NAME, null);
            container.ShowDialog();
        }

        private void holterItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtHolter.NAME, null);
            container.ShowDialog();
        }

        private void kagItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtKag.NAME, null);
            container.ShowDialog();
        }

        private void egdsItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtEgds.NAME, null);
            container.ShowDialog();
        }

        private void specialistItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtSpecialistConclusion.NAME, null);
            container.ShowDialog();
        }

        private void uziItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtUzi.NAME, null);
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
                if (!DdtHospital.NAME.Equals(typeValue))
                {
                    service.Delete(typeValue, idsValue);
                    service.GetDdtHistoryService().DeleteHistoryById(idsValue);
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
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtHormones.NAME, null);
            container.ShowDialog();
        }

        private void koagulogrammItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtCoagulogram.NAME, null);
            container.ShowDialog();
        }

        private void beforeOperationItem_Click(object sender, EventArgs e)
        {
            PreoperativeEpicrisiscs container = new PreoperativeEpicrisiscs(hospitalitySession, null);
            container.ShowDialog();
        }

        private void xrayMenuItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtXRay.NAME, null);
            container.ShowDialog();
        }

        private void oncologicMarkersItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(hospitalitySession, DdtOncologicMarkers.NAME, null);
            container.ShowDialog();
        }
    }
}
