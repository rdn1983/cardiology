using Cardiology.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class PatientList : Form
    {
        public PatientList()
        {
            InitializeComponent();
            loadPatientsGrid();
        }

        private void loadPatientsGrid()
        {
            hospitalPatientsTbl.Rows.Clear();
            DataService service = new DataService();
            string query = @"Select * from ddv_active_hospital_patients ";
            List<DdvActiveHospitalPatients> allHspitalPatients = service.queryObjectsCollection<DdvActiveHospitalPatients>(query);
            for(int i=0; i<allHspitalPatients.Count(); i++)
            {
                DdvActiveHospitalPatients h = allHspitalPatients[i];
                hospitalPatientsTbl.Rows.Add(h.PatientSessionId, h.DssPatientName, h.DssRoomCell, h.DsdtAdmissionDate, h.DssDocName, h.DssDiagnosis);
            }
            
        }

        

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Vypaska dialog = new Vypaska();
            dialog.ShowDialog();
        }

        private void patientAdmission_Click(object sender, EventArgs e)
        {
            AdmissionPatient st = new AdmissionPatient();
            st.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DB1 form = new DB1();
            form.ShowDialog();
        }

        private void konsiliumItem_Click(object sender, EventArgs e)
        {
            Konsilium form = new Konsilium();
            form.ShowDialog();
        }

        private void kateterItem_Click(object sender, EventArgs e)
        {
            UserFromVena form = new UserFromVena();
            form.ShowDialog();
        }

        private void trombolisisItem_Click(object sender, EventArgs e)
        {
            UserFormTrombolizis form = new UserFormTrombolizis(null);
            form.ShowDialog();
        }

        private void veksItem_Click(object sender, EventArgs e)
        {
            UserFormVEKS form = new UserFormVEKS();
            form.ShowDialog();
        }

        private void toracatezosItem_Click(object sender, EventArgs e)
        {
            UserFormTorCent form = new UserFormTorCent();
            form.ShowDialog();
        }

        private void eitItem_Click(object sender, EventArgs e)
        {
            UserFormEIT form = new UserFormEIT();
            form.ShowDialog();
        }

        private void intubationItem_Click(object sender, EventArgs e)
        {
            UserFormIntubation form = new UserFormIntubation();
            form.ShowDialog();
        }

        private void ekstubationItem_Click(object sender, EventArgs e)
        {
            UserFormExtubation form = new UserFormExtubation();
            form.ShowDialog();
        }

        private void reanimItem_Click(object sender, EventArgs e)
        {
            ReanimDEAD form = new ReanimDEAD(null);
            form.ShowDialog();
        }

        private void deadItem_Click(object sender, EventArgs e)
        {
            ReanimDEAD form = new ReanimDEAD(null);
            form.ShowDialog();
        }

        private void firstInspectationItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow) it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                DataService service = new DataService();
                DdtHospital hospitalSession = service.queryObject<DdtHospital>(@"select * from ddt_hospital where r_object_id='" + value + "'");
                FirstInspection form = new FirstInspection(hospitalSession);
                form.ShowDialog();
            }
            
        }

        private void analysisItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                DataService service = new DataService();
                DdtHospital hospitalSession = service.queryObject<DdtHospital>(@"select * from ddt_hospital where r_object_id='" + value + "'");
                AnalysisCabinet form = new AnalysisCabinet(hospitalSession);
                form.ShowDialog();
            }

        }

        private void bloodTrunsfusionMenuItem_Click(object sender, EventArgs e)
        {
            Perelivanie form = new Perelivanie();
            form.ShowDialog();
        }

        private void issuingMedicineItem_Click(object sender, EventArgs e)
        {
            ListNaznachForm form = new ListNaznachForm();
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

        private void morningInspectationMenuItem_Click(object sender, EventArgs e)
        {
            Obhod form = new Obhod();
            form.ShowDialog();
        }

        private void aidBlansMenuItem_Click(object sender, EventArgs e)
        {
            Pisma form = new Pisma();
            form.ShowDialog();
        }

        private void Hospital_Activated(object sender, EventArgs e)
        {
            loadPatientsGrid();
        }
    }
}
