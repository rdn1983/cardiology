using Cardiology.Model;
using Cardiology.Utils;
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
    public partial class Konsilium : Form
    {
        private DdtHospital hospitalitySession;
        private string consiliumId;

        public Konsilium(DdtHospital hospitalitySession, string consiliumId)
        {
            this.hospitalitySession = hospitalitySession;
            this.consiliumId = consiliumId;
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            if (CommonUtils.isNotBlank(consiliumId))
            {
                DataService service = new DataService();
                DdtConsilium consilium = service.queryObjectById<DdtConsilium>(DdtConsilium.TABLE_NAME, consiliumId);
                if (consilium != null)
                {
                    goalTxt.Text = consilium.DssGoal;
                    dynamicsTxt.Text = consilium.DssDynamics;
                    adminTxt.Text = consilium.DssDutyAdminName;
                    diagnosisTxt1.Text = consilium.DssDiagnosis;
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
                        c = CommonUtils.findControl(doctorsContainer, "doctorWho" + i);
                        c.Text = cardioConclusions[i].DssDoctorName;
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
            consilium.DssDiagnosis = diagnosisTxt1.Text;
            consilium.DssDutyAdminName = adminTxt.Text;
            consilium.DssDynamics = dynamicsTxt.Text;
            consilium.DssGoal = goalTxt.Text;
            consiliumId = service.updateOrCreateIfNeedObject<DdtConsilium>(consilium, DdtConsilium.TABLE_NAME, consilium.RObjectId);

            for (int i = 0; i < doctorsContainer.Controls.Count; i++)
            {
                DdtConsiliumMember member = null;
                Control c = CommonUtils.findControl(doctorsContainer, "objectIdLbl" + i);
                if (CommonUtils.isNotBlank(c.Text))
                {
                    member = service.queryObjectById<DdtConsiliumMember>(DdtConsiliumMember.TABLE_NAME, c.Text);
                }
                else
                {
                    member = new DdtConsiliumMember();
                    member.DsidConsilium = consiliumId;
                }

                c = CommonUtils.findControl(doctorsContainer, "appointmentTxt" + i);
                member.DssAppointmentName = c.Text;
                c = CommonUtils.findControl(doctorsContainer, "doctorWho" + i);
                member.DssDoctorName = c.Text;
                service.updateOrCreateIfNeedObject<DdtConsiliumMember>(member, DdtConsiliumMember.TABLE_NAME, member.RObjectId);
            }
            Close();
        }
    }
}
