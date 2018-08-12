using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            CommonUtils.initDoctorsComboboxValues(service, doctorWho0, null);

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
                    List<DdtConsiliumMember> cardioConclusions = service.queryObjectsCollectionByAttrCond<DdtConsiliumMember>
                        (DdtConsiliumMember.TABLE_NAME, "dsid_consilium", consilium.RObjectId, true);
                    for (int i = 0; i < cardioConclusions.Count; i++)
                    {
                        if (doctorsContainer.Controls.Count <= i)
                        {
                            doctorsContainer.Controls.Add(CommonUtils.copyControl(dotorInfoPnl0, doctorsContainer.Controls.Count));
                        }

                        Control c = CommonUtils.findControl(doctorsContainer, "appointmentTxt" + i);
                        c.Text = cardioConclusions[i].DssAppointmentName;
                        ComboBox cb = (ComboBox) CommonUtils.findControl(doctorsContainer, "doctorWho" + i);
                        cb.SelectedIndex = cb.FindStringExact(cardioConclusions[i].DssDoctorName);
                        c = CommonUtils.findControl(doctorsContainer, "objectIdLbl" + i);
                        c.Text = cardioConclusions[i].RObjectId;
                    }
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
            diagnosisTxt0.Text = "Оценка коронарного кровотока с последующим решением о необходимости эндоваскулярного вмешательства.";
        }

        private void revaskularizationGoal_CheckedChanged(object sender, EventArgs e)
        {
            diagnosisTxt0.Text = "Реваскуляризация миокарда.";
        }

        private void addDoctor_Click(object sender, EventArgs e)
        {
            doctorsContainer.Controls.Add(CommonUtils.copyControl(dotorInfoPnl0, doctorsContainer.Controls.Count));
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
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
                Control appointment = CommonUtils.findControl(doctorsContainer, "appointmentTxt" + i);
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
                member.DssAppointmentName = appointment.Text;
                c = CommonUtils.findControl(doctorsContainer, "doctorWho" + i);
                member.DssDoctorName = c.Text;
                service.updateOrCreateIfNeedObject<DdtConsiliumMember>(member, DdtConsiliumMember.TABLE_NAME, member.RObjectId);
            }
            Close();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{consilium.date}", DateTime.Now.ToString("dd.MM.yyyy"));
            values.Add(@"{consilium.time}", DateTime.Now.ToString("HH:mm"));
            values.Add(@"{consilium.members}", getMembersInString());
            values.Add(@"{consilium.goal}", goalTxt.Text);
            DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, hospitalitySession.DsidPatient);
            values.Add(@"{patient.initials}", patient.DssInitials);
            double age = Math.Floor((DateTime.Now - patient.DsdtBirthdate).TotalDays / 365);
            values.Add(@"{patient.age}", age + "");
            values.Add(@"{patient.diagnosis}", diagnosisTxt0.Text);
            values.Add(@"{consilium.decision}", decisionTxt.Text);
            values.Add(@"{journal}", "");

            DdtXRay xray = service.queryObject<DdtXRay>("Select * from " + DdtXRay.TABLE_NAME +
                " WHERE dsid_hospitality_session='" + hospitalitySession.ObjectId + "' order by  r_creation_date desc");
            values.Add(@"{analysis.xray}", xray == null ? "" : xray.DssControlRadiography);
            values.Add(@"{analysis.blood}", " ");
            DdtEkg ekg = service.queryObject<DdtEkg>("Select * from " + DdtEkg.TABLE_NAME +
                " WHERE dsid_hospitality_session='" + hospitalitySession.ObjectId + "' order by r_creation_date desc");
            values.Add(@"{analysis.ekg}", ekg == null ? "" : ekg.DssEkg);

            DdtDoctors doc = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, hospitalitySession.DsidDutyDoctor);
            values.Add(@"{doctor.who}", doc.DssInitials);
            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\consilium_template.doc";
            TemplatesUtils.fillTemplate(templatePath, values);
        }

        private string getMembersInString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < doctorsContainer.Controls.Count; i++)
            {
                Control c = CommonUtils.findControl(doctorsContainer, "appointmentTxt" + i);
                str.Append(c.Text).Append(" ");
                c = CommonUtils.findControl(doctorsContainer, "doctorWho" + i);
                str.Append(c.Text).Append('\n');
            }
            return str.ToString();
        }

        private void appointmentTxt0_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string ctrlName = ((ComboBox)sender).Name;
            int indxPlace = CommonUtils.getFirstDigitIndex(ctrlName);
            int index = Convert.ToInt32(String.Intern(ctrlName.Substring(indxPlace)));
            ComboBox c = (ComboBox)CommonUtils.findControl(doctorsContainer, "doctorWho" + index);
            CommonUtils.initDoctorsComboboxValues(new DataService(), c, "dsi_appointment_type=0");*/

        }


    }
}
