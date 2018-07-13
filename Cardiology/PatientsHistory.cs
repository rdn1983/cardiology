using Cardiology.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void analysisMenuItem_Click(object sender, EventArgs e)
        {
            Analizi form = new Analizi(hospitalitySession, null);
            form.ShowDialog();
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
            Obhod form = new Obhod();
            form.ShowDialog();
        }

        private void journalBeforeKAGMeniItem_Click(object sender, EventArgs e)
        {
            JournalBeforeKag form = new JournalBeforeKag(hospitalitySession, null, true);
            form.ShowDialog();
        }

        private void journalAfterKAGMnuItem_Click(object sender, EventArgs e)
        {
            JournalAfterKAG form = new JournalAfterKAG();
            form.ShowDialog();
        }

        private void journalWithoutKAGMenuItem_Click(object sender, EventArgs e)
        {
            JournalBeforeKag form = new JournalBeforeKag(hospitalitySession, null, false);
            form.ShowDialog();
        }

        private void konsiliumItem_Click(object sender, EventArgs e)
        {
            Konsilium form = new Konsilium();
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
                } else if (DdtJournal.TABLE_NAME.Equals(typeValue))
                {
                    form = new JournalBeforeKag(hospitalitySession, ids, true);
                }
                else if (DdtIssuedMedicine.TABLE_NAME.Equals(typeValue))
                {
                    form = new IssuedMedicine(hospitalitySession, idsValue);
                }
                else if (DdtEgds.TABLE_NAME.Equals(typeValue))
                {

                }
                
                if (form!=null)
                {
                    form.ShowDialog();
                }
            }
        }
    }
}
