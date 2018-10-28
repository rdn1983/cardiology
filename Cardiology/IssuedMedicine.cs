using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class IssuedMedicine : Form
    {
        private DdtHospital hospitalitySession;
        private string issuedMedId;

        public IssuedMedicine(DdtHospital hospitalitySession, string issuedMedId)
        {
            this.hospitalitySession = hospitalitySession;
            this.issuedMedId = issuedMedId;
            InitializeComponent();
            DataService service = new DataService();
            CommonUtils.initDoctorsComboboxValues(service, clinicalPharmacologistBox, "dsi_appointment_type=2");
            CommonUtils.initDoctorsComboboxValues(service, nurseBox, null);
            CommonUtils.initDoctorsComboboxValues(service, cardioReanimBox, null);
            CommonUtils.initDoctorsComboboxValues(service, directorBox, null);
            initIssuedCure(service);
            DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, hospitalitySession.DsidPatient);
            if (patient != null)
            {
                Text += " " + patient.DssInitials;
            }
        }

        private void initIssuedCure(DataService service)
        {
            DdtIssuedMedicineList medList = service.queryObjectById<DdtIssuedMedicineList>(DdtIssuedMedicineList.TABLE_NAME, issuedMedId);
            reinitFromMedList(service, medList);
        }

        private void reinitFromMedList(DataService service, DdtIssuedMedicineList medList)
        {
            if (medList != null)
            {
                issuedMedicineControl1.Init(service, medList);
            }
        }

        private void oksBtn_Click(object sender, EventArgs e)
        {
            diagnosisTxt.Text += "ОКС. ";
        }

        private void piksBtn_Click(object sender, EventArgs e)
        {
            diagnosisTxt.Text += "ПИКС. ";
        }

        private void gbBtn_Click(object sender, EventArgs e)
        {
            diagnosisTxt.Text += "ГБ. ";
        }

        private void nkBtn_Click(object sender, EventArgs e)
        {
            diagnosisTxt.Text += "НК. ";
        }

        private void edemaPulmonaryBtn_Click(object sender, EventArgs e)
        {
            diagnosisTxt.Text += "Отек легких. ";
        }

        private void depBtn_Click(object sender, EventArgs e)
        {
            diagnosisTxt.Text += "ДЭП. ";
        }

        private void pmaBtn_Click(object sender, EventArgs e)
        {
            diagnosisTxt.Text += "ПМА. ";
        }

        private void telaBtn_Click(object sender, EventArgs e)
        {
            diagnosisTxt.Text += "ТЭЛА. ";
        }

        private void anemiaBtn_Click(object sender, EventArgs e)
        {
            diagnosisTxt.Text += "Анемия. ";
        }

        private void sdBtn_Click(object sender, EventArgs e)
        {
            diagnosisTxt.Text += "СД. ";
        }

        private void kagBtn_CheckedChanged(object sender, EventArgs e)
        {
            shortlyOperationTxt.Text = "КАГ. ";
        }

        private void noKagBtn_CheckedChanged(object sender, EventArgs e)
        {
            shortlyOperationTxt.Text = "Без операции. ";
        }

        private void addCureBtn_Click(object sender, EventArgs e)
        {
            issuedMedicineControl1.addMedicineBox();
        }

        private void oksTemplateMed_Click(object sender, EventArgs e)
        {
            updatemedicineFromTemplate("oks.medicine.");
        }

        private void updatemedicineFromTemplate(string template)
        {
            DataService service = new DataService();
            List<DdtCure> medicineTemplates = service.queryObjectsCollection<DdtCure>(@"Select cure.* from ddt_values vv, ddt_cure cure 
                            where vv.dss_name like '" + template + "%' AND vv.dss_value=cure.dss_name");
            issuedMedicineControl1.refreshData(service, medicineTemplates);
        }

        private void clearMedicine()
        {
            for (int i = 0; i < medicineContainer.Controls.Count; i++)
            {
                ComboBox cb = (ComboBox)CommonUtils.findControl(medicineContainer, "issuedMedicineTxt" + i);
                cb.SelectedIndex = -1;
            }
        }

        private void oksLongsMedBtn_Click(object sender, EventArgs e)
        {
            updatemedicineFromTemplate("okslongs.medicine.");
        }

        private void hoblMedBtn_Click(object sender, EventArgs e)
        {
            updatemedicineFromTemplate("hobl.medicine.");
        }

        private void nkMedBtn_Click(object sender, EventArgs e)
        {
            updatemedicineFromTemplate("nk.medicine.");
        }

        private void gbMedBtn_Click(object sender, EventArgs e)
        {
            updatemedicineFromTemplate("gb.medicine.");
        }

        private void clearMedBtn_Click(object sender, EventArgs e)
        {
            issuedMedicineControl1.clearMedicine();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveIssuedMedicine();
            Close();
        }

        private void saveIssuedMedicine()
        {
            DataService service = new DataService();
            List<DdtIssuedMedicine> meds = issuedMedicineControl1.getIssuedMedicines();
            if (meds.Count > 0)
            {
                DdtIssuedMedicineList medList = service.queryObjectById<DdtIssuedMedicineList>(DdtIssuedMedicineList.TABLE_NAME, issuedMedId);
                if (medList == null)
                {
                    medList = new DdtIssuedMedicineList();
                    medList.DsidDoctor = hospitalitySession.DsidDutyDoctor;
                    medList.DsidHospitalitySession = hospitalitySession.ObjectId;
                    medList.DsidPatient = hospitalitySession.DsidPatient;
                    string id = service.insertObject<DdtIssuedMedicineList>(medList, DdtIssuedMedicineList.TABLE_NAME);
                    medList.ObjectId = id;
                }
                foreach (DdtIssuedMedicine med in meds)
                {
                    med.DsidMedList = medList.ObjectId;
                    service.updateOrCreateIfNeedObject<DdtIssuedMedicine>(med, DdtIssuedMedicine.TABLE_NAME, med.RObjectId);
                }
            }
        }

        private void copyFirstMedicineBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            DdtIssuedMedicineList medList = service.queryObject<DdtIssuedMedicineList>(@"SELECT * FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='" +
                   hospitalitySession.ObjectId + "' AND dss_parent_type='ddt_anamnesis'");
            issuedMedicineControl1.Init(service, medList);
        }

        private void copyJournalMedBtn_Click(object sender, EventArgs e)
        {

        }

        private void copyYesterdayMedBtn_Click(object sender, EventArgs e)
        {

        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            saveIssuedMedicine();

            Dictionary<string, string> values = new Dictionary<string, string>();
            DataService service = new DataService();
            DdtHospital hospitalSession = service.queryObjectById<DdtHospital>(DdtHospital.TABLENAME, hospitalitySession.ObjectId);
            DdtDoctors doc = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, hospitalSession.DsidCuringDoctor);
            DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, hospitalSession.DsidPatient);
            values.Add(@"{doctor.who.short}", doc.DssInitials);
            values.Add(@"{patient.diagnosis}", hospitalSession.DssDiagnosis);
            values.Add(@"{patient.age}", DateTime.Now.Year - patient.DsdtBirthdate.Year + "");
            values.Add(@"{admission.date}", hospitalSession.DsdtAdmissionDate.ToShortDateString());
            values.Add(@"{patient.historycard}", patient.DssMedCode);
            values.Add(@"{patient.fullname}", patient.DssFullName);
            values.Add(@"{room}", "");
            values.Add(@"{cell}", "");
            values.Add(@"{date}", DateTime.Now.ToShortDateString());
            //todo переписать,к огда будет время. Сделать добавление в таблицу строчек автоматом
            List<DdtIssuedMedicine> med = issuedMedicineControl1.getIssuedMedicines();
            for (int i = 0; i < 12; i++)
            {
                string value = "";
                if (i < med.Count)
                {
                    DdtCure cure = service.queryObjectById<DdtCure>(DdtCure.TABLE_NAME, med[i].DsidCure);
                    value = cure.DssName;
                }
                values.Add(@"{issued_medicine_" + i + "}", value);
            }
            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\issued_medicine_template.doc";
            TemplatesUtils.fillTemplateAndShow(templatePath, values);
        }
    }
}
