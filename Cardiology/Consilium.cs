using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class Consilium : Form
    {
        private DdtHospital hospitalitySession;
        private string consiliumId;

        public Consilium(DdtHospital hospitalitySession, string consiliumId)
        {
            this.hospitalitySession = hospitalitySession;
            this.consiliumId = consiliumId;
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            DataService service = new DataService();
            CommonUtils.initDoctorsComboboxValues(service, adminTxt, " dsi_appointment_type=3");
            CommonUtils.initGroupsComboboxValues(service, appointmentTxt0);
            CommonUtils.initDoctorsByGroupComboboxValues(service, doctorWho0, null);
            diagnosisTxt0.Text = hospitalitySession.DssDiagnosis;
            if (CommonUtils.isNotBlank(consiliumId))
            {
                DdtConsilium consilium = service.queryObjectById<DdtConsilium>(DdtConsilium.TABLE_NAME, consiliumId);
                if (consilium != null)
                {
                    goalTxt.Text = consilium.DssGoal;
                    dynamicsTxt.Text = consilium.DssDynamics;
                    adminTxt.SelectedIndex = adminTxt.FindStringExact(consilium.DssDutyAdminName);
                    diagnosisTxt0.Text = consilium.DssDiagnosis;
                    decisionTxt.Text = consilium.DssDecision;
                    List<DdtConsiliumMember> members = service.queryObjectsCollectionByAttrCond<DdtConsiliumMember>
                        (DdtConsiliumMember.TABLE_NAME, "dsid_consilium", consilium.RObjectId, true);
                    initMembers(service, members);
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
                initMembers(service, members);
            }

        }

        private void initMembers(DataService service, List<DdtConsiliumMember> members)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (doctorsContainer.Controls.Count <= i)
                {
                    doctorsContainer.Controls.Add(CommonUtils.copyControl(dotorInfoPnl0, doctorsContainer.Controls.Count));
                }

                ComboBox cbApp = (ComboBox)CommonUtils.findControl(doctorsContainer, "appointmentTxt" + i);
                cbApp.SelectedIndexChanged += new System.EventHandler(this.appointmentTxt0_SelectedIndexChanged);
                DmGroup gr = service.queryObjectByAttrCond<DmGroup>(DmGroup.TABLE_NAME, "dss_name", members[i].DssGroupName, true);
                if (gr != null)
                {
                    cbApp.SelectedIndex = cbApp.FindStringExact(gr.DssDescription);
                    ComboBox cb = (ComboBox)CommonUtils.findControl(doctorsContainer, "doctorWho" + i);
                    cb.SelectedIndex = cb.FindStringExact(members[i].DssDoctorName);
                }
                if (!members[i].DsbTemplate)
                {
                    Control c = CommonUtils.findControl(doctorsContainer, "objectIdLbl" + i);
                    c.Text = members[i].RObjectId;
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
            doctorsContainer.Controls.Add(CommonUtils.copyControl(dotorInfoPnl0, indx));
            ComboBox cbApp = (ComboBox)CommonUtils.findControl(doctorsContainer, "appointmentTxt" + indx);
            cbApp.SelectedIndexChanged += new System.EventHandler(this.appointmentTxt0_SelectedIndexChanged);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            save(service);
            Close();
        }

        private void save(DataService service)
        {
            hospitalitySession.DssDiagnosis = diagnosisTxt1.Text;
            service.updateObject<DdtHospital>(hospitalitySession, DdtHospital.TABLENAME, "r_object_id", hospitalitySession.ObjectId);

            DdtConsilium consilium = null;
            if (CommonUtils.isNotBlank(consiliumId))
            {
                consilium = service.queryObjectById<DdtConsilium>(DdtConsilium.TABLE_NAME, consiliumId);
            }
            else
            {
                consilium = new DdtConsilium();
                consilium.DsidHospitalitySession = hospitalitySession.ObjectId;
                consilium.DsidPatient = hospitalitySession.DsidPatient;
                consilium.DsidDoctor = hospitalitySession.DsidCuringDoctor;
            }
            consilium.DssDecision = decisionTxt.Text;
            consilium.DssDiagnosis = diagnosisTxt0.Text;
            consilium.DssDutyAdminName = adminTxt.Text;
            consilium.DssDynamics = dynamicsTxt.Text;
            consilium.DssGoal = goalTxt.Text;
            consiliumId = service.updateOrCreateIfNeedObject<DdtConsilium>(consilium, DdtConsilium.TABLE_NAME, consilium.RObjectId);

            for (int i = 0; i < doctorsContainer.Controls.Count; i++)
            {
                DdtConsiliumMember member = null;
                Control c = CommonUtils.findControl(doctorsContainer, "objectIdLbl" + i);
                ComboBox appointment = (ComboBox)CommonUtils.findControl(doctorsContainer, "appointmentTxt" + i);
                if (CommonUtils.isNotBlank(c.Text))
                {
                    member = service.queryObjectById<DdtConsiliumMember>(DdtConsiliumMember.TABLE_NAME, c.Text);
                }
                else
                {
                    if (CommonUtils.isBlank(appointment.Text))
                    {
                        continue;
                    }

                    member = new DdtConsiliumMember();
                    member.DsidConsilium = consiliumId;
                }
                DmGroup group = (DmGroup)appointment.SelectedItem;
                member.DssGroupName = group.DssName;
                c = CommonUtils.findControl(doctorsContainer, "doctorWho" + i);
                member.DssDoctorName = c.Text;
                service.updateOrCreateIfNeedObject<DdtConsiliumMember>(member, DdtConsiliumMember.TABLE_NAME, member.RObjectId);
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            save(service);
            ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtConsilium.TABLE_NAME);
            if (processor!=null)
            {
                string path = processor.processTemplate(hospitalitySession.ObjectId, consiliumId, new Dictionary<string, string>());
                TemplatesUtils.showDocument(path);
            }
        }

        private void appointmentTxt0_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            DmGroup group = (DmGroup)cb.SelectedItem;
            if (group != null)
            {
                string ctrlName = cb.Name;
                int indxPlace = CommonUtils.getFirstDigitIndex(ctrlName);
                int index = Convert.ToInt32(String.Intern(ctrlName.Substring(indxPlace)));
                ComboBox c = (ComboBox)CommonUtils.findControl(doctorsContainer, "doctorWho" + index);
                CommonUtils.initDoctorsByGroupComboboxValues(new DataService(), c, group.DssName);
            }
        }

        private void oksWithStBtn_CheckedChanged(object sender, EventArgs e)
        {
            decisionTxt.Text = "У больного с ОКС с подъемом ST";
        }
    }
}
