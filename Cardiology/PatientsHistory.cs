using Cardiology.Model;
using System;
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
            loadPatientsHistoryGrid();
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
            IssuedMedicine form = new IssuedMedicine(hospitalitySession);
            form.ShowDialog();
        }

        private void morningInspectationMenuItem_Click(object sender, EventArgs e)
        {
            Obhod form = new Obhod();
            form.ShowDialog();
        }

        private void journalBeforeKAGMeniItem_Click(object sender, EventArgs e)
        {
            DB1 form = new DB1();
            form.ShowDialog();
        }

        private void journalAfterKAGMnuItem_Click(object sender, EventArgs e)
        {
            JournalAfterKAG form = new JournalAfterKAG();
            form.ShowDialog();
        }

        private void journalWithoutKAGMenuItem_Click(object sender, EventArgs e)
        {
            DB3 form = new DB3();
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
    }
}
