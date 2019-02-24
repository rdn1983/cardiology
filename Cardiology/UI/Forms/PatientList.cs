using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class PatientList : Form
    {
        private IDbDataService service;

        public PatientList(IDbDataService service)
        {
            this.service = service;

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.hospitalPatientsTbl.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void loadPatientsGrid(bool idOnlyActive)
        {
            hospitalPatientsTbl.Rows.Clear();
            IList<DdvActiveHospitalPatients> activePatients = service.GetDdvActiveHospitalPatientsService().GetList(idOnlyActive);
            for (int i = 0; i < activePatients.Count(); i++)
            {
                DdvActiveHospitalPatients activePatient = activePatients[i];
                hospitalPatientsTbl.Rows.Add(
                    activePatient.HospitalSession, 
                    activePatient.PatientName, 
                    activePatient.RoomCell, activePatient.AdmissionDate, activePatient.DocName, activePatient.Diagnosis);
            }

        }

        private void patientAdmission_Click(object sender, EventArgs e)
        {
            PatientAdmission st = new PatientAdmission(service, null);
            st.ShowDialog();
        }

        private void kateterItem_Click(object sender, EventArgs e)
        {
            UserFromVena form = new UserFromVena(service);
            form.ShowDialog();
        }

        private void trombolisisItem_Click(object sender, EventArgs e)
        {
            UserFormTrombolizis form = new UserFormTrombolizis(service, null);
            form.ShowDialog();
        }

        private void veksItem_Click(object sender, EventArgs e)
        {
            UserFormVEKS form = new UserFormVEKS(service);
            form.ShowDialog();
        }

        private void toracatezosItem_Click(object sender, EventArgs e)
        {
            UserFormTorCent form = new UserFormTorCent(service);
            form.ShowDialog();
        }

        private void eitItem_Click(object sender, EventArgs e)
        {
            UserFormEIT form = new UserFormEIT(service);
            form.ShowDialog();
        }

        private void intubationItem_Click(object sender, EventArgs e)
        {
            UserFormIntubation form = new UserFormIntubation(service);
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

                DdtHospital hospitalSession = service.GetDdtHospitalService().GetById(value);
                DdvPatient patient = service.GetDdvPatientService().GetById(hospitalSession.Patient);
                ReanimDEAD form = new ReanimDEAD(service, patient);
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

                DdtHospital hospitalSession = service.GetDdtHospitalService().GetById(value);
                DdvPatient patient = service.GetDdvPatientService().GetById(hospitalSession.Patient);
                ReanimDEAD form = new ReanimDEAD(service, patient);
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

                DdtHospital hospitalSession = service.GetDdtHospitalService().GetById(value);
                PatientsHistory form = new PatientsHistory(service, hospitalSession);
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
                DdtHospital hospitalSession = service.GetDdtHospitalService().GetById(value);
                ReleasePatient dialog = new ReleasePatient(service, hospitalSession, null);
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
                DdtAlcoProtocol protocol = service.GetDdtAlcoProtocolService().GetByHospitalSession(value);
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("{patient.behavior}", protocol == null ? "неустойчивое" : protocol.Behavior);
                values.Add("{patient.bio}", protocol == null ? "1,81 ‰" : protocol.Bio);
                values.Add("{patient.breathe}", protocol == null ? "20 дыхательных движений в минуту" : protocol.Breathe);
                values.Add("{patient.cause}", protocol == null ? "медицинская помощь" : protocol.Cause);
                values.Add("{patient.conclusion}", protocol == null ? "" : protocol.Conclusion);
                values.Add("{docs}", protocol == null ? " " : protocol.Docs);
                values.Add("{patient.drunk}", protocol == null ? "0,5 литра водки" : protocol.Drunk);
                values.Add("{patient.vascular}", protocol == null ? "фотореакции живые" : protocol.Eyes);
                values.Add("{patient.illness}", protocol == null ? "отрицает" : protocol.Illness);
                values.Add("{patient.look}", protocol == null ? "опрятен" : protocol.Look);
                values.Add("{patient.mimics}", protocol == null ? "вялая" : protocol.Mimics);
                values.Add("{patient.motions}", protocol == null ? "без патологии" : protocol.Motions);
                values.Add("{patient.nistagm}", protocol == null ? "nistagmTxt" : protocol.Nistagm);
                values.Add("{patient.orientation}", protocol == null ? "ориентирован" : protocol.Orientation);
                values.Add("{patient.pressure}", protocol == null ? "130/90 мм рт.ст." : protocol.Pressure);
                values.Add("{patient.eyes}", protocol == null ? "фотореакции живые" : protocol.Eyes);
                values.Add("{patient.pribor}", protocol == null ? " " : protocol.Pribor);
                values.Add("{patient.pulse}", protocol == null ? "pulseTxt" : protocol.Pulse);
                values.Add("{patient.skin}", protocol == null ? "гиперемия лица" : protocol.Skin);
                values.Add("{patient.smell}", protocol == null ? " " : protocol.Smell);
                values.Add("{patient.talk}", protocol == null ? "смазана" : protocol.Speech);
                values.Add("{patient.touch_nose}", protocol == null ? "с промахиванием" : protocol.TouchNose);
                values.Add("{patient.tremble}", protocol == null ? "да" : protocol.Tremble);
                values.Add("{patient.trub}", protocol == null ? " " : protocol.Trub);
                values.Add("{patient.walk}", protocol == null ? "не проводилась" : protocol.Walk);
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
                DdtHospital hospitalSession = service.GetDdtHospitalService().GetById(value);
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
                DdtHospital hospitalSession = service.GetDdtHospitalService().GetById(value);
                DdtPatient patient = service.GetDdtPatientService().GetById(hospitalSession.Patient);
                string passportInfo = patient.PassportSerial + " " + patient.PassportNum + " выдан "
                    + patient.PassportDate.ToShortDateString() + " " + patient.PassportIssuePlace;
                values.Add("{patient.passport}", passportInfo);
                TemplatesUtils.fillBlankTemplate("blank_dead_constatation_template.doc", value, values);
            }
        }

        private void showReleasedPatients_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            loadPatientsGrid(!box.Checked);
        }

        private void hospitalPatientsTbl_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                DdtHospital hospitalSession = service.GetDdtHospitalService().GetById(cell.Value.ToString());
                PatientAdmission admissionPatient = new PatientAdmission(this.service, hospitalSession);
                admissionPatient.ShowDialog();

            }

        }

        private void lastIssuedMedList_Click(object sender, EventArgs e)
        {
            IEnumerator it = hospitalPatientsTbl.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[0];
                DdtIssuedMedicineList issuedMedicineList = service.GetDdtIssuedMedicineListService().GetListByHospitalId(cell.Value.ToString());
                if (string.IsNullOrEmpty(issuedMedicineList.ObjectId))
                {
                    MessageBox.Show("Для пациента еще не создано ни одного листа назначений", "Предупреждение", MessageBoxButtons.OK);
                }
                else
                {
                    DdtHospital hospitalSession = service.GetDdtHospitalService().GetById(cell.Value.ToString());
                    IssuedMedicine form = new IssuedMedicine(this.service, hospitalSession, issuedMedicineList.ObjectId);
                    form.ShowDialog();
                }
            }
        }
    }
}
