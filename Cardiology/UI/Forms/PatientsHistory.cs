using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
                patientHistoryGrid.Rows.Add(false, h.HospitalitySession, h.OperationType, h.OperationId, h.OperationName, h.OperationDate, h.DoctorShortName, h.Description);
            }

        }


        private void bloodTrunsfusionMenuItem_Click(object sender, EventArgs e)
        {
            Perelivanie form = new Perelivanie();
            form.ShowDialog();
        }

        private void issuingMedicineMenuItem_Click(object sender, EventArgs e)
        {
            IssuedMedicine form = new IssuedMedicine(service, hospitalitySession, null);
            form.ShowDialog();
        }

        private void morningInspectationMenuItem_Click(object sender, EventArgs e)
        {
            Inspection form = new Inspection(service, hospitalitySession, null);
            form.ShowDialog();
        }

        private void journalBeforeKAGMeniItem_Click(object sender, EventArgs e)
        {
            JournalBeforeKag form = new JournalBeforeKag(service, hospitalitySession, null, (int)DdtJournalDsiType.BeforeKag);
            form.ShowDialog();
        }

        private void journalAfterKAGMnuItem_Click(object sender, EventArgs e)
        {
            JournalAfterKAG form = new JournalAfterKAG(service, hospitalitySession, null);
            form.ShowDialog();
        }

        private void journalWithoutKAGMenuItem_Click(object sender, EventArgs e)
        {
            JournalBeforeKag form = new JournalBeforeKag(service, hospitalitySession, null, (int)DdtJournalDsiType.WithoutKag);
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
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells[0];
                firstId = cell.Value.ToString();
                firstType = row.Cells[2].Value.ToString();
            }
            DataGridViewRowCollection rows = patientHistoryGrid.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                DataGridViewCell cell = rows[i].Cells[3];
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)rows[i].Cells[0];
                if ((bool)checkBoxCell.Value)
                {
                    ids.Add(cell.Value.ToString());
                }
            }
            if (!ids.Contains(firstId))
            {
                ids.Add(firstId);
            }
            Form form = null;

            if (DdtAnamnesis.NAME.Equals(firstType, StringComparison.Ordinal))
            {
                form = new FirstInspection(service, hospitalitySession);
            }
            else if (DdtJournal.NAME.Equals(firstType, StringComparison.Ordinal))
            {
                DdtJournal journal = service.GetDdtJournalService().GetById(firstId);
                if (journal.JournalType == (int)DdtJournalDsiType.AfterKag)
                {
                    form = new JournalAfterKAG(service, hospitalitySession, firstId);
                }
                else
                {
                    form = new JournalBeforeKag(service, hospitalitySession, ids, -1);
                }
            }
            else if (DdtIssuedMedicineList.NAME.Equals(firstType, StringComparison.Ordinal))
            {
                form = new IssuedMedicine(this.service, hospitalitySession, firstId);
            }
            else if (DdtEgds.NAME.Equals(firstType, StringComparison.Ordinal) || DdtXRay.NAME.Equals(firstType, StringComparison.Ordinal)
                || DdtUrineAnalysis.NAME.Equals(firstType, StringComparison.Ordinal) || DdtEkg.NAME.Equals(firstType, StringComparison.Ordinal)
                || DdtSpecialistConclusion.NAME.Equals(firstType, StringComparison.Ordinal) || DdtUzi.NAME.Equals(firstType, StringComparison.Ordinal)
                || DdtKag.NAME.Equals(firstType, StringComparison.Ordinal) || DdtHolter.NAME.Equals(firstType, StringComparison.Ordinal)
                || DdtBloodAnalysis.NAME.Equals(firstType, StringComparison.Ordinal) || DdtHormones.NAME.Equals(firstType, StringComparison.Ordinal)
                || DdtCoagulogram.NAME.Equals(firstType, StringComparison.Ordinal) || DdtOncologicMarkers.NAME.Equals(firstType, StringComparison.Ordinal))
            {
                form = new AnalysisContainer(service, hospitalitySession, firstType, firstId);
            }
            else if (DdtConsilium.NAME.Equals(firstType, StringComparison.Ordinal))
            {
                form = new Consilium(service, hospitalitySession, firstId);
            }
            else if (DdtSerology.NAME.Equals(firstType, StringComparison.Ordinal))
            {
                form = new Serology(service, hospitalitySession);
            }
            else if (DdtInspection.NAME.Equals(firstType, StringComparison.Ordinal))
            {
                form = new Inspection(service, hospitalitySession, firstId);
            }
            else if (DdtEpicrisis.NAME.Equals(firstType, StringComparison.Ordinal))
            {
                form = new PreoperativeEpicrisiscs(service, hospitalitySession, firstId);
            }
            else if (DdtHospital.NAME.Equals(firstType, StringComparison.Ordinal))
            {
                form = new PatientAdmission(service, hospitalitySession);
            }
            else if (DdtAlcoProtocol.NAME.Equals(firstType, StringComparison.Ordinal))
            {
                form = new AlcoIntoxication(service, hospitalitySession);
            }

            if (form != null)
            {
                form.ShowDialog();
            }
        }

        private void ekgItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(service, hospitalitySession, DdtEkg.NAME, null);
            container.ShowDialog();
        }

        private void bloodItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(service, hospitalitySession, DdtBloodAnalysis.NAME, null);
            container.ShowDialog();
        }

        private void urineItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(service, hospitalitySession, DdtUrineAnalysis.NAME, null);
            container.ShowDialog();
        }

        private void holterItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(service, hospitalitySession, DdtHolter.NAME, null);
            container.ShowDialog();
        }

        private void kagItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(service, hospitalitySession, DdtKag.NAME, null);
            container.ShowDialog();
        }

        private void egdsItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(service, hospitalitySession, DdtEgds.NAME, null);
            container.ShowDialog();
        }

        private void specialistItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(service, hospitalitySession, DdtSpecialistConclusion.NAME, null);
            container.ShowDialog();
        }

        private void uziItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(service, hospitalitySession, DdtUzi.NAME, null);
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
            DdvPatient patient = service.GetDdvPatientService().GetById(hospitalitySession.Patient);
            List<string> paths = new List<string>();
            if (printTitlePage.Checked)
            {
                List<string> prePaths = new List<string>();
                Dictionary<string, string> titleDict = new Dictionary<string, string>();
                titleDict.Add("{mednumber}", patient.MedCode);
                titleDict.Add("{admission_date}", hospitalitySession.AdmissionDate.ToShortDateString());
                titleDict.Add("{leaving_date}", DateTime.Now.ToShortDateString());
                titleDict.Add("{med_policy}", patient.Oms);
                titleDict.Add("{room}", hospitalitySession.RoomCell);
                titleDict.Add("{daysinhospital}", (DateTime.Now.Year - hospitalitySession.AdmissionDate.Year) + "");
                DdtSerology serology = service.GetDdtSerologyService().GetByHospitalSession(hospitalitySession.ObjectId);
                titleDict.Add("{blood_n}", serology?.BloodType);
                titleDict.Add("{rhesus}", serology?.RhesusFactor);
                titleDict.Add("{height}", patient.High + "");
                titleDict.Add("{weight}", patient.Weight + "");
                titleDict.Add("{patient_full_name}", patient.FullName);
                titleDict.Add("{sex}", patient.Sex ? "мужской" : "женский");
                titleDict.Add("{passport}", patient.PassportSerial + " " + patient.PassportNum + " " + patient.PassportIssuePlace + " " + patient.PassportDate.ToShortDateString());
                titleDict.Add("{age}", (DateTime.Now.Year - patient.Birthdate.Year) + "");
                titleDict.Add("{birthdate}", patient.Birthdate.ToShortDateString());
                titleDict.Add("{address}", patient.Address);
                DdtAnamnesis firstIspection = service.GetDdtAnamnesisService().GetByHospitalSessionId(hospitalitySession.ObjectId);
                titleDict.Add("{diagnosis_first}", firstIspection?.Diagnosis);
                titleDict.Add("{diagnosis_last}", hospitalitySession.Diagnosis);

                prePaths.Add(TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + "title.docx", titleDict));
                paths.Add(TemplatesUtils.MergeFiles(prePaths.ToArray(), true, null));
            }
            foreach (DataGridViewRow row in patientHistoryGrid.Rows)
            {
                bool checkd = (bool)row.Cells[0].Value;
                if (checkd)
                {
                    ITemplateProcessor te = TemplateProcessorManager.getProcessorByObjectType((string)row.Cells[2].Value);
                    if (te != null)
                    {
                        string pathFile = te.processTemplate(service, hospitalitySession.ObjectId, (string)row.Cells[3].Value, null);
                        paths.Add(pathFile);
                    }
                }
            }
            string resultFileName = TemplatesUtils.getTempFileName("История болезни", patient.FullName);
            string resultPath = TemplatesUtils.MergeFiles(paths.ToArray(), false, resultFileName);
            TemplatesUtils.ShowDocument(resultPath);
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
                if (!DdtHospital.NAME.Equals(typeValue, StringComparison.Ordinal))
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
            AnalysisContainer container = new AnalysisContainer(service, hospitalitySession, DdtHormones.NAME, null);
            container.ShowDialog();
        }

        private void koagulogrammItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(service, hospitalitySession, DdtCoagulogram.NAME, null);
            container.ShowDialog();
        }

        private void beforeOperationItem_Click(object sender, EventArgs e)
        {
            PreoperativeEpicrisiscs container = new PreoperativeEpicrisiscs(service, hospitalitySession, null);
            container.ShowDialog();
        }

        private void xrayMenuItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(service, hospitalitySession, DdtXRay.NAME, null);
            container.ShowDialog();
        }

        private void oncologicMarkersItem_Click(object sender, EventArgs e)
        {
            AnalysisContainer container = new AnalysisContainer(service, hospitalitySession, DdtOncologicMarkers.NAME, null);
            container.ShowDialog();
        }
    }
}
