using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class PatientList : Form
    {
        public PatientList()
        {
            InitializeComponent();
            this.hospitalPatientsTbl.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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

        private void patientAdmission_Click(object sender, EventArgs e)
        {
            AdmissionPatient st = new AdmissionPatient();
            st.ShowDialog();
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

        private void bloodTrunsfusionMenuItem_Click(object sender, EventArgs e)
        {
            Perelivanie form = new Perelivanie();
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

        private void patientHistoryCardItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                DataService service = new DataService();
                DdtHospital hospitalSession = service.queryObjectById<DdtHospital>(DdtHospital.TABLENAME, value);
                PatientsHistory form = new PatientsHistory(hospitalSession);
                form.ShowDialog();
            }
        }

        private void releasePatient_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                DataService service = new DataService();
                DdtHospital hospitalSession = service.queryObjectById<DdtHospital>(DdtHospital.TABLENAME, value);
                ReleasePatient dialog = new ReleasePatient(hospitalSession);
                dialog.ShowDialog();
            }
        }

        private void commonConsentItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_common_consent_template.docx", value, values);
            }
        }

        private void aidAgreementItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_aid_aggrement_template.docx", value, values);
            }
        }

        private void stentItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_stent_template.docx", value, values);
            }
        }

        private void kagItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_kag_template.docx", value, values);
            }
        }

        private void manipulationRefusalItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_refusal_medical_injure.docx", value, values);
            }
        }

        private void refusalTreatmentItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_refusal_of_treatment_template.docx", value, values);
            }
        }

        private void justificationCostlyCureItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                
                TemplatesUtils.fillBlankTemplate("blank_justification_costly_cure_template.docx", value, values);
            }
            
        }
    }
}
