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
        IList<String> membersToRemove = new List<String>();

        public Consilium(IDbDataService service, DdtHospital hospitalitySession, string consiliumId)
        {
            this.hospitalitySession = hospitalitySession;
            this.consiliumId = consiliumId;
            InitializeComponent();
            InitControls();
            SilentSaver.setForm(this);
        }

        private void InitControls()
        {
            DataService service = new DataService();
            curingDoc = service.queryObjectById<DdvDoctor>(hospitalitySession?.DsidCuringDoctor);
            CommonUtils.InitDoctorsComboboxValues(service, adminTxt, " dsi_appointment_type=3");
            ControlUtils.InitGroupsComboboxValues(this.service.GetDmGroupService(), appointmentTxt0);
            ControlUtils.InitDoctorsByGroupName(this.service.GetDdvDoctorService(), doctorWho0, null);
            DdtPatient patient = service.queryObjectById<DdtPatient>(hospitalitySession.DsidPatient);
            if (patient != null)
            {
                Text += " " + patient.DssInitials;
            }
            diagnosisTxt0.Text = hospitalitySession.DssDiagnosis;
            if (!string.IsNullOrEmpty(consiliumId))
            {
                DdtConsilium consilium = service.queryObjectById<DdtConsilium>(consiliumId);
                if (consilium != null)
                {
                    goalTxt.Text = consilium.DssGoal;
                    dynamicsTxt.Text = consilium.DssDynamics;
                    adminTxt.SelectedIndex = adminTxt.FindStringExact(consilium.DssDutyAdminName);
                    diagnosisTxt0.Text = consilium.DssDiagnosis;
                    decisionTxt.Text = consilium.DssDecision;
                    List<DdtConsiliumMember> members = service.queryObjectsCollectionByAttrCond<DdtConsiliumMember>
                        (DdtConsiliumMember.TABLE_NAME, "dsid_consilium", consilium.ObjectId, true);
                    InitMembers(service, members);
                }
            }
            else
            {
                DdtAnamnesis anamnesis = service.queryObject<DdtAnamnesis>(@"SELECT * FROM ddt_anamnesis WHERE dsid_hospitality_session='" + hospitalitySession.ObjectId + "'");
                if (anamnesis != null)
                {
                    diagnosisTxt0.Text = anamnesis.DssDiagnosis;
                }

                List<DdtConsiliumMember> members = service.queryObjectsCollectionByAttrCond<DdtConsiliumMember>
                   (DdtConsiliumMember.TABLE_NAME, "dss_template_name", "default_consilium", true);
                InitMembers(service, members);
            }

        }

        private void InitMembers(DataService service, List<DdtConsiliumMember> members)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (doctorsContainer.Controls.Count <= i)
                {
                    doctorsContainer.Controls.Add(CommonUtils.CopyControl(dotorInfoPnl0, doctorsContainer.Controls.Count));
                }

                ComboBox cbApp = (ComboBox)CommonUtils.FindControl(doctorsContainer, "appointmentTxt" + i);
                cbApp.SelectedIndexChanged += new System.EventHandler(this.appointmentTxt0_SelectedIndexChanged);
                DmGroup gr = service.queryObjectByAttrCond<DmGroup>(DmGroup.TABLE_NAME, "dss_name", members[i].DssGroupName, true);
                if (gr != null)
                {
                    cbApp.SelectedIndex = cbApp.FindStringExact(gr.DssDescription);
                    ComboBox cb = (ComboBox)CommonUtils.FindControl(doctorsContainer, "doctorWho" + i);
                    cb.SelectedIndex = cb.FindStringExact(members[i].DssDoctorName);
                }
                if (!members[i].DsbTemplate)
                {
                    Control c = CommonUtils.FindControl(doctorsContainer, "objectIdLbl" + i);
                    c.Text = members[i].ObjectId;
                    Button b = (Button)CommonUtils.FindControl(doctorsContainer, "removeBtn" + i);
                    b.Visible = true;
                    b.Click += new System.EventHandler(this.removeBtn0_Click);
                }
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
            if (save())
            {
                Close();
            }
        }

        public bool save()
        {
            if (!getIsValid())
            {
                return false;
            }
            DataService service = new DataService();
            hospitalitySession.DssDiagnosis = getSafeStringValue(diagnosisTxt1);
            service.updateObject<DdtHospital>(hospitalitySession, DdtHospital.TABLE_NAME, "r_object_id", hospitalitySession.ObjectId);

            DdtConsilium consilium = null;
            if (!string.IsNullOrEmpty(consiliumId))
            {
                consilium = service.queryObjectById<DdtConsilium>(consiliumId);
            }
            else
            {
                consilium = new DdtConsilium();
                consilium.DsdtConsiliumDate = DateTime.Now;
                consilium.DsidHospitalitySession = hospitalitySession.ObjectId;
                consilium.DsidPatient = hospitalitySession.DsidPatient;
                consilium.DsidDoctor = hospitalitySession.DsidCuringDoctor;
            }
            consilium.DssDecision = getSafeStringValue(decisionTxt);
            consilium.DssDiagnosis = getSafeStringValue(diagnosisTxt0);
            consilium.DssDutyAdminName = getSafeStringValue(adminTxt);
            consilium.DssDynamics = getSafeStringValue(dynamicsTxt);
            consilium.DssGoal = getSafeStringValue(goalTxt);
            consiliumId = service.updateOrCreateIfNeedObject<DdtConsilium>(consilium, DdtConsilium.TABLE_NAME, consilium.ObjectId);

            foreach (Control doctorInfoPnl in doctorsContainer.Controls)
            {
                DdtConsiliumMember member = null;
                String doctorInfoPnlName = getSafeObjectValueUni<string>(doctorInfoPnl, new getValue<string>((ctrl) => (ctrl.Name)));
                string indexstr = string.Intern(doctorInfoPnlName.Substring(CommonUtils.GetFirstDigitIndex(doctorInfoPnlName)));
                int indx = Int32.Parse(indexstr);

                Control objectIdCtrl = CommonUtils.FindControl(doctorsContainer, "objectIdLbl" + indx);
                ComboBox appointment = (ComboBox)CommonUtils.FindControl(doctorsContainer, "appointmentTxt" + indx);
                if (!string.IsNullOrEmpty(objectIdCtrl.Text))
                {
                    member = service.queryObjectById<DdtConsiliumMember>(objectIdCtrl.Text);
                }
                else
                {
                    if (string.IsNullOrEmpty(appointment.Text))
                    {
                        continue;
                    }

                    member = new DdtConsiliumMember();
                    member.DsidConsilium = consiliumId;
                }
                DmGroup group = getSafeObjectValueUni<DmGroup>(appointment, new getValue<DmGroup>((ctrl) => ((DmGroup)((ComboBox)ctrl).SelectedItem)));
                member.DssGroupName = group.DssName;
                Control docCtrl = CommonUtils.FindControl(doctorsContainer, "doctorWho" + indx);
                member.DssDoctorName = getSafeStringValue(docCtrl);
                objectIdCtrl.Text = service.updateOrCreateIfNeedObject<DdtConsiliumMember>(member, DdtConsiliumMember.TABLE_NAME, member.ObjectId);
            }

            foreach (String memberId in membersToRemove)
            {
                service.queryDelete(DdtConsiliumMember.TABLE_NAME, "r_object_id", memberId, true);
            }
            return true;
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
            DataService service = new DataService();
            if (save())
            {
                ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtConsilium.TABLE_NAME);
                if (processor != null)
                {
                    string path = processor.processTemplate(hospitalitySession.ObjectId, consiliumId, new Dictionary<string, string>());
                    TemplatesUtils.showDocument(path);
                }
            }
        }

        private void appointmentTxt0_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            DmGroup group = (DmGroup)cb.SelectedItem;
            if (group != null)
            {
                string ctrlName = cb.Name;
                int indxPlace = CommonUtils.GetFirstDigitIndex(ctrlName);
                int index = Convert.ToInt32(String.Intern(ctrlName.Substring(indxPlace)));
                ComboBox c = (ComboBox)CommonUtils.FindControl(doctorsContainer, "doctorWho" + index);
                CommonUtils.InitDoctorsByGroupComboboxValues(new DataService(), c, group.DssName);
                if ("duty_cardioreanim".Equals(group.DssName))
                {
                    c.SelectedIndex = c.FindStringExact(curingDoc?.DssInitials);
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
                membersToRemove.Add(objectId);
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
    }
}
