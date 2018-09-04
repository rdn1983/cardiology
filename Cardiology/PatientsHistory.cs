using Cardiology.Model;
using Cardiology.Model.Dictionary;
using Cardiology.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class PatientsHistory : Form
    {
        private DdtHospital hospitalitySession;
        public PatientsHistory(DdtHospital hospitalitySession)
        {
            this.hospitalitySession = hospitalitySession;
            InitializeComponent();
            this.patientHistoryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void loadPatientsHistoryGrid()
        {
            patientHistoryGrid.Rows.Clear();
            DataService service = new DataService();
            string query = @"SELECT * FROM ddv_history WHERE dsid_hospitality_session='" + hospitalitySession.ObjectId + "' ";
            List<DdvHistory> allHspitalPatients = service.queryObjectsCollection<DdvHistory>(query);
            for (int i = 0; i < allHspitalPatients.Count(); i++)
            {
                DdvHistory h = allHspitalPatients[i];
                patientHistoryGrid.Rows.Add(false, h.DsidHospitalitySession, h.DssOperationType, h.DsidOperationId, h.DssOperationName, h.RCreationDate, h.DssDoctorName, h.DssDescription);
            }

        }


        private void bloodTrunsfusionMenuItem_Click(object sender, EventArgs e)
        {
            Perelivanie form = new Perelivanie();
            form.ShowDialog();
        }

        private void issuingMedicineMenuItem_Click(object sender, EventArgs e)
        {
            IssuedMedicine form = new IssuedMedicine(hospitalitySession, null);
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
            Consilium form = new Consilium(hospitalitySession, null);
            form.ShowDialog();
        }

        private void PatientHistory_Activated(object sender, EventArgs e)
        {
            loadPatientsHistoryGrid();
        }

        private void firstInspectationsItem_Click(object sender, EventArgs e)
        {
            FirstInspection form = new FirstInspection(hospitalitySession);
            form.ShowDialog();
        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            IEnumerator it = patientHistoryGrid.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[3];
                string idsValue = cell.Value.ToString();
                string typeValue = row.Cells[2].Value.ToString();
                List<string> ids = new List<string>();
                ids.Add(idsValue);
                Form form = null;
                if (DdtAnamnesis.TABLE_NAME.Equals(typeValue))
                {
                    form = new FirstInspection(hospitalitySession);
                }
                else if (DdtJournal.TABLE_NAME.Equals(typeValue))
                {
                    DataService service = new DataService();
                    DdtJournal jourmal = service.queryObjectById<DdtJournal>(DdtJournal.TABLE_NAME, idsValue);
                    if (jourmal.DsiJournalType == (int)DdtJournalDsiType.AFTER_KAG)
                    {
                        form = new JournalAfterKAG(hospitalitySession, idsValue);
                    }
                    else
                    {
                        form = new JournalBeforeKag(hospitalitySession, ids, -1);
                    }
                }
                else if (DdtIssuedMedicineList.TABLE_NAME.Equals(typeValue))
                {
                    form = new IssuedMedicine(hospitalitySession, idsValue);
                }
                else if (DdtEgds.TABLE_NAME.Equals(typeValue) || DdtXRay.TABLE_NAME.Equals(typeValue)
                    || DdtUrineAnalysis.TABLE_NAME.Equals(typeValue) || DdtEkg.TABLE_NAME.Equals(typeValue)
                    || DdtSpecialistConclusion.TABLE_NAME.Equals(typeValue) || DdtUzi.TABLE_NAME.Equals(typeValue)
                    || DdtKag.TABLE_NAME.Equals(typeValue) || DdtHolter.TABLE_NAME.Equals(typeValue)
                    || DdtBloodAnalysis.TABLE_NAME.Equals(typeValue) || DdtHormones.TABLE_NAME.Equals(typeValue)
                    || DdtCoagulogram.TABLE_NAME.Equals(typeValue))
                {
                    form = new AnalysisContainer(hospitalitySession, typeValue, idsValue);
                }
                else if (DdtConsilium.TABLE_NAME.Equals(typeValue))
                {
                    form = new Consilium(hospitalitySession, idsValue);
                }
                else if (DdtSerology.TABLE_NAME.Equals(typeValue))
                {
                    form = new Serology(hospitalitySession);
                }
                else if (DdtInspection.TABLE_NAME.Equals(typeValue))
                {
                    form = new Inspection(hospitalitySession, idsValue);
                }
                else if (DdtEpicrisis.TABLE_NAME.Equals(typeValue))
                {
                    form = new PreoperativeEpicrisiscs(hospitalitySession, idsValue);
                }

                if (form != null)
                {
                    form.ShowDialog();
                }
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
                //todo если делать полноценно, то надо еще вносить во все таблицы признак удаления и при открытии первичного осмотра и т.п.
                //селектить с учетом флага. пока так. Чтобы хотя бы чистить историю от хлама.
                DataService service = new DataService();
                service.update(@"update ddt_history set dsb_deleted=true, dsdt_delete_date=now() WHERE dsid_operation_id='" + idsValue + "'");
            }
        }

        private void bloodTypeItem_Click(object sender, EventArgs e)
        {
            Serology form = new Serology(hospitalitySession);
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
    }
}
