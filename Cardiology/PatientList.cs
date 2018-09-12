using Cardiology.Model;
using Cardiology.Utils;
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
            this.hospitalPatientsTbl.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void loadPatientsGrid(bool idOnlyActive)
        {
            hospitalPatientsTbl.Rows.Clear();
            DataService service = new DataService();
            string query = @"Select * from ddv_active_hospital_patients " + (idOnlyActive ? " WHERE dsb_active=true":"") ;
            List<DdvActiveHospitalPatients> allHspitalPatients = service.queryObjectsCollection<DdvActiveHospitalPatients>(query);
            for (int i = 0; i < allHspitalPatients.Count(); i++)
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
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                DataService service = new DataService();
                DdtHospital hospitalSession = service.queryObjectById<DdtHospital>(DdtHospital.TABLENAME, value);
                DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, hospitalSession.DsidPatient);
                ReanimDEAD form = new ReanimDEAD(patient);
                form.ShowDialog();
            }
            
        }

        private void deadItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                DataService service = new DataService();
                DdtHospital hospitalSession = service.queryObjectById<DdtHospital>(DdtHospital.TABLENAME, value);
                DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, hospitalSession.DsidPatient);
                ReanimDEAD form = new ReanimDEAD(patient);
                form.ShowDialog();
            }
        }

        private void bloodTrunsfusionMenuItem_Click(object sender, EventArgs e)
        {
            Perelivanie form = new Perelivanie();
            form.ShowDialog();
        }

        

        private void Hospital_Activated(object sender, EventArgs e)
        {
            loadPatientsGrid(!showReleasedPatients.Checked);
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
                ReleasePatient dialog = new ReleasePatient(hospitalSession, null);
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
                TemplatesUtils.fillBlankTemplate("blank_common_consent_template.doc", value, values);
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
                TemplatesUtils.fillBlankTemplate("blank_aid_aggrement_template.doc", value, values);
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
                TemplatesUtils.fillBlankTemplate("blank_stent_template.doc", value, values);
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
                TemplatesUtils.fillBlankTemplate("blank_kag_template.doc", value, values);
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
                TemplatesUtils.fillBlankTemplate("blank_refusal_medical_injure.doc", value, values);
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
                TemplatesUtils.fillBlankTemplate("blank_refusal_of_treatment_template.doc", value, values);
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

                TemplatesUtils.fillBlankTemplate("blank_justification_costly_cure_template.doc", value, values);
            }

        }

        private void alcoExamItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                DataService service = new DataService();
                DdtAlcoProtocol protocol = service.queryObject<DdtAlcoProtocol>(@"SELECT * FROM ddt_alco_protocol WHERE dsid_hospitality_session='" + value + "'");
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("{patient.behavior}", protocol == null ? "неустойчивое" : protocol.DssBehavior);
                values.Add("{patient.bio}", protocol == null ? "1,81 ‰" : protocol.DssBio);
                values.Add("{patient.breathe}", protocol == null ? "20 дыхательных движений в минуту" : protocol.DssBreathe);
                values.Add("{patient.cause}", protocol == null ? "медицинская помощь" : protocol.DssCause);
                values.Add("{patient.conclusion}", protocol == null ? "" : protocol.DssConclusion);
                values.Add("{docs}", protocol == null ? " " : protocol.DssDocs);
                values.Add("{patient.drunk}", protocol == null ? "0,5 литра водки" : protocol.DssDrunk);
                values.Add("{patient.vascular}", protocol == null ? "фотореакции живые" : protocol.DssEyes);
                values.Add("{patient.illness}", protocol == null ? "отрицает" : protocol.DssIllness);
                values.Add("{patient.look}", protocol == null ? "опрятен" : protocol.DssLook);
                values.Add("{patient.mimics}", protocol == null ? "вялая" : protocol.DssMimics);
                values.Add("{patient.motions}", protocol == null ? "без патологии" : protocol.DssMotions);
                values.Add("{patient.nistagm}", protocol == null ? "nistagmTxt" : protocol.DssNistagm);
                values.Add("{patient.orientation}", protocol == null ? "ориентирован" : protocol.DssOrientation);
                values.Add("{patient.pressure}", protocol == null ? "130/90 мм рт.ст." : protocol.DssPressure);
                values.Add("{patient.eyes}", protocol == null ? "фотореакции живые" : protocol.DssEyes);
                values.Add("{patient.pribor}", protocol == null ? " " : protocol.DssPribor);
                values.Add("{patient.pulse}", protocol == null ? "pulseTxt" : protocol.DssPulse);
                values.Add("{patient.skin}", protocol == null ? "гиперемия лица" : protocol.DssSkin);
                values.Add("{patient.smell}", protocol == null ? " " : protocol.DssSmell);
                values.Add("{patient.talk}", protocol == null ? "смазана" : protocol.DssSpeech);
                values.Add("{patient.touch_nose}", protocol == null ? "с промахиванием" : protocol.DssTouchNose);
                values.Add("{patient.tremble}", protocol == null ? "да" : protocol.DssTremble);
                values.Add("{patient.trub}", protocol == null ? " " : protocol.DssTrub);
                values.Add("{patient.walk}", protocol == null ? "не проводилась" : protocol.DssWalk);
                values.Add("{datetime}", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                values.Add("{analysis.date}", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                values.Add("{patient.work}", " ");
                values.Add("{reason}", " ");
                TemplatesUtils.fillBlankTemplate("blank_alco_examination_template.doc", value, values);
            }
        }

        private void kekItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_kek_template.doc", value, values);
            }
        }

        private void narkoItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_narko_template.doc", value, values);
            }
        }

        private void ambulanceLettersItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                DdtHospital hospitalSession = new DataService().queryObjectById<DdtHospital>(DdtHospital.TABLENAME, value);
                AmbulanceLetters form = new AmbulanceLetters(hospitalSession);
                form.ShowDialog();
            }
        }

        private void trunsfusionApprovalItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_trunsfusion_approval_template.doc", value, values);
            }
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_registered_transfusion_template.doc", value, values);
            }
        }

        private void trunsfusionClaimItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_trunsfusion_claim_template.doc", value, values);
            }
        }

        private void skatItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_skat_template.doc", value, values);
            }
        }

        private void transferItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_transfer_template.doc", value, values);
            }
        }

        private void aidItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_aid_template.doc", value, values);
            }
        }

        private void hospitalityRefusalItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_hospitality_refusal_template.doc", value, values);
            }
        }

        private void manipulationAggreementItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                TemplatesUtils.fillBlankTemplate("blank_yes_manipulation_template.doc", value, values);
            }
        }

        private void echoItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("{time}", DateTime.Now.ToShortTimeString());
                TemplatesUtils.fillBlankTemplate("blank_echo_template.doc", value, values);
            }
        }

        private void anastesiaItem_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("{time}", DateTime.Now.ToShortTimeString());
                TemplatesUtils.fillBlankTemplate("blank_anastesia_template.doc", value, values);
            }
        }

        private void refusalDeadInspectionItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            TemplatesUtils.fillBlankTemplate("blank_refusal_dead_inspection_template.doc", null, values);
        }

        private void deadConstatationItem_Click(object sender, EventArgs e)
        {

            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                string value = cell.Value.ToString();
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("{time}", DateTime.Now.ToShortTimeString());
                DataService service = new DataService();
                DdtHospital hospitalSession = service.queryObjectById<DdtHospital>(DdtHospital.TABLENAME, value);
                DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, hospitalSession.DsidPatient);
                string passportInfo = patient.DssPassportSerial + " " + patient.DssPassportNum + " выдан " 
                    + patient.DssPassportDate.ToShortDateString() + " " + patient.DssPassportIssuePlace;
                values.Add("{patient.passport}", passportInfo);
                TemplatesUtils.fillBlankTemplate("blank_dead_constatation_template.doc", value, values);
            }
        }

        private void showReleasedPatients_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox) sender;
            loadPatientsGrid(!box.Checked);
        }
    }
}
