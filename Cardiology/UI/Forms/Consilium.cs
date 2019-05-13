using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class Consilium : Form, IAutoSaveForm
    {
        private readonly IDbDataService service;
        private DdtHospital hospitalitySession;
        private DdvDoctor curingDoc;
        private string consiliumId;
        IList<String> consiliumRelationToRemove = new List<String>();

        public Consilium(IDbDataService service, DdtHospital hospitalitySession, string consiliumId)
        {
            this.service = service;
            this.hospitalitySession = hospitalitySession;
            this.consiliumId = consiliumId;
            InitializeComponent();
            InitControls();
            List<string> validTypes = new List<string>() { "ddt_blood_analysis", "ddt_kag", "ddt_ekg", "ddt_urine_analysis", "ddt_egds", "ddt_xray", "ddt_holter", "ddt_specialist_conclusion", "ddt_uzi" };
            analysisTabControl1.init(hospitalitySession, consiliumId, DdtConsilium.NAME, validTypes);
            SilentSaver.setForm(this);
        }

        private void InitControls()
        {
            curingDoc = service.GetDdvDoctorService().GetById(hospitalitySession?.CuringDoctor);
            ControlUtils.InitDoctorsByGroupName(service.GetDdvDoctorService(), adminTxt, "duty_administrators");
            DdvPatient patient = service.GetDdvPatientService().GetById(hospitalitySession.Patient);
            if (patient != null)
            {
                Text += " " + patient.ShortName;
            }
            diagnosisTxt0.Text = hospitalitySession.Diagnosis;
            if (!string.IsNullOrEmpty(consiliumId))
            {
                DdtConsilium consilium = service.GetDdtConsiliumService().GetById(consiliumId);
                if (consilium != null)
                {
                    goalTxt.Text = consilium.Goal;
                    dynamicsTxt.Text = consilium.Dynamics;
                    adminTxt.SelectedIndex = adminTxt.FindStringExact(consilium.DutyAdminName);
                    diagnosisTxt0.Text = consilium.Diagnosis;
                    decisionTxt.Text = consilium.Decision;
                    IList<DdtConsiliumRelation> consiliumRelations = service.GetDdtConsiliumRelationService().GetConsiliumRelationsByConsiliumId(consilium.ObjectId);
                    InitMembersByRelations(service, consiliumRelations);
                }
            }
            else
            {
                DdtAnamnesis anamnesis = service.GetDdtAnamnesisService().GetByHospitalSessionId(hospitalitySession.ObjectId);
                if (anamnesis != null)
                {
                    diagnosisTxt0.Text = anamnesis.Diagnosis;
                }

                IList<DdtConsiliumGroupMember> defaultGroupMembers = service.GetDdtConsiliumGroupMemberService().GetDefault();
                InitDefaultMembers(service, defaultGroupMembers);
            }

        }

        private void InitDefaultMembers(IDbDataService service, IList<DdtConsiliumGroupMember> defaultGroupMembers)
        {
            for (int i = 0; i < defaultGroupMembers.Count; i++)
            {
                if (doctorsContainer.Controls.Count <= i)
                {
                    doctorsContainer.Controls.Add(CommonUtils.CopyControl(dotorInfoPnl0, doctorsContainer.Controls.Count));
                }

                ComboBox cbApp = (ComboBox)CommonUtils.FindControl(doctorsContainer, "appointmentTxt" + i);
                cbApp.SelectedIndexChanged += new System.EventHandler(this.appointmentTxt0_SelectedIndexChanged);
                ControlUtils.InitConsiliumGroupsComboboxValues(service.GetDdtConsiliumGroupService(), cbApp);

                DdtConsiliumGroup group = service.GetDdtConsiliumGroupService().GetById(defaultGroupMembers[i].Group);
                if (group != null)
                {
                    cbApp.SelectedIndex = cbApp.FindStringExact(group.Name);
                    ComboBox cbDoctor = (ComboBox)CommonUtils.FindControl(doctorsContainer, "doctorWho" + i);
                    ControlUtils.InitDoctorsByConsiliumGroupId(service.GetDdvDoctorService(), cbDoctor, group.ObjectId);
                    cbDoctor.SelectedValue = defaultGroupMembers[i].Doctor;
                }

                //Control c = CommonUtils.FindControl(doctorsContainer, "objectIdLbl" + i);
                //c.Text = defaultMembers[i].ObjectId;
                Button b = (Button)CommonUtils.FindControl(doctorsContainer, "removeBtn" + i);
                b.Visible = true;
                b.Click += new System.EventHandler(this.removeBtn0_Click);
            }
        }

        private void InitMembersByRelations(IDbDataService service, IList<DdtConsiliumRelation> consiliumRelations)
        {
            for (int i = 0; i < consiliumRelations.Count; i++)
            {
                if (doctorsContainer.Controls.Count <= i)
                {
                    doctorsContainer.Controls.Add(CommonUtils.CopyControl(dotorInfoPnl0, doctorsContainer.Controls.Count));
                }

                ComboBox cbApp = (ComboBox)CommonUtils.FindControl(doctorsContainer, "appointmentTxt" + i);
                cbApp.SelectedIndexChanged += new System.EventHandler(this.appointmentTxt0_SelectedIndexChanged);
                ControlUtils.InitConsiliumGroupsComboboxValues(service.GetDdtConsiliumGroupService(), cbApp);

                DdtConsiliumGroupMember groupMember = service.GetDdtConsiliumGroupMemberService().GetById(consiliumRelations[i].Member);
                DdtConsiliumGroup group = service.GetDdtConsiliumGroupService().GetById(groupMember.Group);
                if (group != null)
                {
                    cbApp.SelectedIndex = cbApp.FindStringExact(group.Name);
                    ComboBox cbDoctor = (ComboBox)CommonUtils.FindControl(doctorsContainer, "doctorWho" + i);
                    ControlUtils.InitDoctorsByConsiliumGroupId(service.GetDdvDoctorService(), cbDoctor, group.ObjectId);
                    cbDoctor.SelectedValue = groupMember.Doctor;
                }

                Control c = CommonUtils.FindControl(doctorsContainer, "objectIdLbl" + i);
                c.Text = consiliumRelations[i].ObjectId;
                Button b = (Button)CommonUtils.FindControl(doctorsContainer, "removeBtn" + i);
                b.Visible = true;
                b.Click += new System.EventHandler(this.removeBtn0_Click);
            }
        }

        private void kagBtn_CheckedChanged(object sender, EventArgs e)
        {
            decisionTxt.Text = "Учитывая клинику, данные инструментальных и лабораторных методов исследования, отрицательный" +
                " Т-тропониновый тест, стабильную гемодинамику, отсутствием ангинозных болей, пациенту показано прохождение коронарографии" +
                " с целью оценки коронарного кровотока и последующим решением о необходимости эндоваскулярного вмешательства. Согласие пациента получено.";
        }

        private void oksAcceptBtn_CheckedChanged(object sender, EventArgs e)
        {
            decisionTxt.Text = "В связи с рецидивирующими ангинозными болями, Риск ишемических событий был оценен как высокий (Grace 145), " +
                "отсутствием эффекта консервативной терапии пациенту показано выполнение коронарографии с последующим решением о необходимости" +
                " эндоваскулярного вмешательства. Письменное согласие пациента получено.";
        }

        private void oksDeclineBtn_CheckedChanged(object sender, EventArgs e)
        {
            decisionTxt.Text = "В связи с болевым синдромом, повышенными значениями кардиомаркеров крови пациенту предложено выполнение диагностической" +
                " коронарографии. От проведения которой получен категорический отказ.  Письменное заявление оформлено, вложено в историю болезни. " +
                "Решено продолжить консервативную терапию.";
        }

        private void evaluationGoal_CheckedChanged(object sender, EventArgs e)
        {
            goalTxt.Text = "Оценка коронарного кровотока с последующим решением о необходимости эндоваскулярного вмешательства.";
        }

        private void revaskularizationGoal_CheckedChanged(object sender, EventArgs e)
        {
            goalTxt.Text = "Реваскуляризация миокарда.";
        }

        private void addDoctor_Click(object sender, EventArgs e)
        {
            int indx = doctorsContainer.Controls.Count;
            doctorsContainer.Controls.Add(CommonUtils.CopyControl(dotorInfoPnl0, indx));
            ComboBox cbApp = (ComboBox)CommonUtils.FindControl(doctorsContainer, "appointmentTxt" + indx);
            cbApp.SelectedIndexChanged += new System.EventHandler(this.appointmentTxt0_SelectedIndexChanged);
            Button b = (Button)CommonUtils.FindControl(doctorsContainer, "removeBtn" + indx);
            b.Visible = true;
            b.Click += new System.EventHandler(this.removeBtn0_Click);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Close();
            }
        }

        public bool Save()
        {
            if (!getIsValid())
            {
                return false;
            }
            hospitalitySession.Diagnosis = getSafeStringValue(diagnosisTxt1);
            service.GetDdtHospitalService().Save(hospitalitySession);

            DdtConsilium consilium = null;
            if (!string.IsNullOrEmpty(consiliumId))
            {
                consilium = service.GetDdtConsiliumService().GetById(consiliumId);
            }
            else
            {
                consilium = new DdtConsilium
                {
                    ConsiliumDate = DateTime.Now,
                    HospitalitySession = hospitalitySession.ObjectId,
                    Patient = hospitalitySession.Patient,
                    Doctor = hospitalitySession.CuringDoctor
                };
            }
            consilium.Decision = getSafeStringValue(decisionTxt);
            consilium.Diagnosis = getSafeStringValue(diagnosisTxt0);
            consilium.DutyAdminName = getSafeStringValue(adminTxt);
            consilium.Dynamics = getSafeStringValue(dynamicsTxt);
            consilium.Goal = getSafeStringValue(goalTxt);
            consiliumId = service.GetDdtConsiliumService().Save(consilium);

            foreach (Control doctorInfoPnl in doctorsContainer.Controls)
            {
                DdtConsiliumRelation consiliumRelation = null;
                String doctorInfoPnlName = getSafeObjectValueUni<string>(doctorInfoPnl, new getValue<string>((ctrl) => (ctrl.Name)));
                string indexstr = string.Intern(doctorInfoPnlName.Substring(CommonUtils.GetFirstDigitIndex(doctorInfoPnlName)));
                int indx = Int32.Parse(indexstr);

                Control objectIdCtrl = CommonUtils.FindControl(doctorsContainer, "objectIdLbl" + indx);
                if (!string.IsNullOrEmpty(objectIdCtrl.Text))
                {
                    consiliumRelation = service.GetDdtConsiliumRelationService().GetById(objectIdCtrl.Text);
                }
                else
                {
                    consiliumRelation = new DdtConsiliumRelation();
                    consiliumRelation.Consilium = consiliumId;
                }

                Control appCb = CommonUtils.FindControl(doctorsContainer, "appointmentTxt" + indx);
                DdtConsiliumGroup group = getSafeObjectValueUni<DdtConsiliumGroup>(appCb, (ctrl) => ((DdtConsiliumGroup)((ComboBox)ctrl).SelectedItem));

                Control docCb = CommonUtils.FindControl(doctorsContainer, "doctorWho" + indx);
                DdvDoctor doctor = getSafeObjectValueUni<DdvDoctor>(docCb, (ctrl) => ((DdvDoctor)((ComboBox)ctrl).SelectedItem));

                if (group != null && doctor != null)
                {
                    DdtConsiliumGroupMember consiliumGroupMember = service.GetDdtConsiliumGroupMemberService().GetByDoctorAndGroupId(doctor.ObjectId, group.ObjectId);
                    consiliumRelation.Member = consiliumGroupMember.ObjectId;
                    service.GetDdtConsiliumRelationService().Save(consiliumRelation);
                }
            }

            foreach (String consiliumRelationId in consiliumRelationToRemove)
            {
                service.Delete(DdtConsiliumRelation.NAME, consiliumRelationId);
            }
            analysisTabControl1.save(consiliumId, DdtConsilium.NAME);            SetConsiliumIdToTransfusion();            return true;
        }

        private void SetConsiliumIdToTransfusion()
        {
            Transfusion transfusion = this.Owner as Transfusion;
            if (transfusion != null)
            {
                transfusion.ConsiliumId = consiliumId;
            }
        }

        private bool getIsValid()
        {
            bool result = !string.IsNullOrEmpty(goalTxt.Text) && !string.IsNullOrEmpty(dynamicsTxt.Text)
                && !string.IsNullOrEmpty(diagnosisTxt0.Text) && !string.IsNullOrEmpty(decisionTxt.Text);
            if (!result)
            {
                MessageBox.Show("Заполните обязательные поля: цель консилиума, динамика в отделении, диагноз, решение!", "Внимание!");
            }
            return result;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {

            if (Save())
            {
                ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtConsilium.NAME);
                if (processor != null)
                {
                    string path = processor.processTemplate(service, hospitalitySession.ObjectId, consiliumId, new Dictionary<string, string>());
                    TemplatesUtils.ShowDocument(path);
                }
            }
        }

        private void appointmentTxt0_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            DdtConsiliumGroup group = (DdtConsiliumGroup)cb.SelectedItem;
            if (group != null)
            {
                string ctrlName = cb.Name;
                int indxPlace = CommonUtils.GetFirstDigitIndex(ctrlName);
                int index = Convert.ToInt32(String.Intern(ctrlName.Substring(indxPlace)));
                ComboBox c = (ComboBox)CommonUtils.FindControl(doctorsContainer, "doctorWho" + index);
                ControlUtils.InitDoctorsByConsiliumGroupId(service.GetDdvDoctorService(), c, group.ObjectId);
                if ("duty_cardioreanim".Equals(group.Name, StringComparison.Ordinal))
                {
                    c.SelectedIndex = c.FindStringExact(curingDoc?.ShortName);
                }
            }
        }

        private void oksWithStBtn_CheckedChanged(object sender, EventArgs e)
        {
            decisionTxt.Text = "У пациента с ОКС с подъемом ST. Необходимо выполнить реваскуляризацию в экстренном порядке по жизненным показаниям.";
        }

        private void removeBtn0_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Panel doctorInfoPnl = (Panel)button.Parent;
            string doctorInfoPnlName = doctorInfoPnl.Name;
            string indexstr = string.Intern(doctorInfoPnlName.Substring(CommonUtils.GetFirstDigitIndex(doctorInfoPnlName)));
            int indx = Int32.Parse(indexstr);

            Control objectIdLbl = CommonUtils.FindControl(doctorInfoPnl, "objectIdLbl" + indx);
            String objectId = objectIdLbl.Text;

            if (!string.IsNullOrEmpty(objectId))
            {
                consiliumRelationToRemove.Add(objectId);
            }
            doctorsContainer.Controls.Remove(doctorInfoPnl);
            doctorsContainer.Refresh();
        }

        private string getSafeStringValue(Control c)
        {
            if (c.InvokeRequired)
            {
                return (string)c.Invoke(new getControlTextValue((ctrl) => ctrl.Text), c);
            }
            return c.Text;
        }

        private T getSafeObjectValueUni<T>(Control c, getValue<T> getter)
        {
            if (c.InvokeRequired)
            {
                return (T)c.Invoke(new getControlObjectValue<T>((ctrl) => getter(ctrl)), c);
            }
            return getter(c);
        }

        delegate T getValue<T>(Control ctrl);

        delegate string getControlTextValue(Control ctrl);
        delegate T getControlObjectValue<T>(Control ctrl);

        private void Consilium_FormClosing(object sender, FormClosingEventArgs e)
        {
            SilentSaver.clearForm();
        }

        private void toAnalysisBtn_Click(object sender, EventArgs e)
        {
            int currentTabIndx = tabs.SelectedIndex;
            if (currentTabIndx < tabs.TabCount - 1)
            {
                tabs.SelectTab(++currentTabIndx);
            }
        }

        private void toConsiliumBtn_Click(object sender, EventArgs e)
        {
            int currentTabIndx = tabs.SelectedIndex;
            if (currentTabIndx > 0)
            {
                tabs.SelectTab(--currentTabIndx);
            }
        }
    }
}
