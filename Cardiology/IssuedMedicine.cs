using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class IssuedMedicine : Form
    {
        private DdtHospital hospitalitySession;
        private string issuedMedId;
        private bool isAcceptTemplate = false;

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
                diagnosisTxt.Text = medList.DssDiagnosis;
                shortlyOperationTxt.Text = medList.DssHasKag;
                issuedMedicineContainer.Init(service, medList);
            }
            else
            {
                copyFirstMedicineBtn_Click(null, null);
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
            issuedMedicineContainer.addMedicineBox();
        }

        private void oksTemplateMed_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                updatemedicineFromTemplate("oks.medicine.");
                oksTemplateMed.BackColor = Color.LightSkyBlue;
            }
        }

        private void updatemedicineFromTemplate(string template)
        {
            DataService service = new DataService();
            List<DdtCure> medicineTemplates = service.queryObjectsCollection<DdtCure>(@"Select cure.* from ddt_values vv, ddt_cure cure 
                            where vv.dss_name like '" + template + "%' AND vv.dss_value=cure.dss_name");
            issuedMedicineContainer.refreshData(service, medicineTemplates);
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
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                updatemedicineFromTemplate("okslongs.medicine.");
                oksLongsMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void hoblMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                updatemedicineFromTemplate("hobl.medicine.");
                hoblMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void nkMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                updatemedicineFromTemplate("nk.medicine.");
                nkMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void gbMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                updatemedicineFromTemplate("gb.medicine.");
                gbMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void clearMedBtn_Click(object sender, EventArgs e)
        {
            issuedMedicineContainer.clearMedicine();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveIssuedMedicine();
            Close();
        }

        private void saveIssuedMedicine()
        {
            DataService service = new DataService();
            List<DdtIssuedMedicine> meds = issuedMedicineContainer.getIssuedMedicines();
            if (meds.Count > 0)
            {
                DdtIssuedMedicineList medList = service.queryObjectById<DdtIssuedMedicineList>(DdtIssuedMedicineList.TABLE_NAME, issuedMedId);
                if (medList == null)
                {
                    medList = new DdtIssuedMedicineList();
                    medList.DsidDoctor = hospitalitySession.DsidDutyDoctor;
                    medList.DsidHospitalitySession = hospitalitySession.ObjectId;
                    medList.DsidPatient = hospitalitySession.DsidPatient;
                }
                medList.DssDiagnosis = diagnosisTxt.Text;
                medList.DssHasKag = shortlyOperationTxt.Text;
                medList.DsdtIssuingDate = createDateTxt.Value;
                string id = service.updateOrCreateIfNeedObject<DdtIssuedMedicineList>(medList, DdtIssuedMedicineList.TABLE_NAME, medList.ObjectId);
                medList.ObjectId = id;
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
            String meListId = service.querySingleString(@"SELECT * FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='" +
                   hospitalitySession.ObjectId + "' AND dss_parent_type='ddt_anamnesis'");
            if (CommonUtils.isNotBlank(meListId))
            {
                List<DdtCure> cures = service.queryObjectsCollection<DdtCure>(@"SELECT cures.* FROM " + DdtCure.TABLE_NAME + " cures, " + DdtIssuedMedicine.TABLE_NAME +
                    " meds WHERE meds.dsid_med_list='" + meListId + "' AND meds.dsid_cure=cures.r_object_id");
                issuedMedicineContainer.refreshData(service, cures);
            }
        }

        private void copyJournalMedBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            String meListId = service.querySingleString(@"SELECT medlist.* FROM ddt_issued_medicine_list medlist, ddt_inspection ins WHERE ins.dsid_hospitality_session='" +
                   hospitalitySession.ObjectId + "' AND medlist.dsid_parent_id=ins.r_object_id ORDER BY dsdt_inspection_date DESC");
            if (CommonUtils.isNotBlank(meListId))
            {
                List<DdtCure> cures = service.queryObjectsCollection<DdtCure>(@"SELECT cures.* FROM " + DdtCure.TABLE_NAME + " cures, " + DdtIssuedMedicine.TABLE_NAME +
                    " meds WHERE meds.dsid_med_list='" + meListId + "' AND meds.dsid_cure=cures.r_object_id");
                issuedMedicineContainer.refreshData(service, cures);
            }
        }

        private void copyYesterdayMedBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            String meListId = service.querySingleString(@"SELECT * FROM ddt_issued_medicine_list  WHERE dsid_hospitality_session='" +
                   hospitalitySession.ObjectId + "'   ORDER BY dsdt_issuing_date DESC");
            if (CommonUtils.isNotBlank(meListId))
            {
                List<DdtCure> cures = service.queryObjectsCollection<DdtCure>(@"SELECT cures.* FROM " + DdtCure.TABLE_NAME + " cures, " + DdtIssuedMedicine.TABLE_NAME +
                    " meds WHERE meds.dsid_med_list='" + meListId + "' AND meds.dsid_cure=cures.r_object_id");
                issuedMedicineContainer.refreshData(service, cures);
            }
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
            List<DdtIssuedMedicine> med = issuedMedicineContainer.getIssuedMedicines();
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

        private void kagMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                updatemedicineFromTemplate("kag.medicine.");
                kagMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void aortaMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                updatemedicineFromTemplate("aorta.medicine.");
                aortaMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void depMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                updatemedicineFromTemplate("dep.medicine.");
                depMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void deathMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                updatemedicineFromTemplate("death.medicine.");
                deathMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void clearSelection()
        {
            oksTemplateMed.BackColor = Color.Empty;
            oksLongsMedBtn.BackColor = Color.Empty;
            kagMedBtn.BackColor = Color.Empty;
            deathMedBtn.BackColor = Color.Empty;
            depMedBtn.BackColor = Color.Empty;
            hoblMedBtn.BackColor = Color.Empty;
            nkMedBtn.BackColor = Color.Empty;
            gbMedBtn.BackColor = Color.Empty;
            aortaMedBtn.BackColor = Color.Empty;
        }

        private bool isSureChangeTemplate()
        {
            if (isAcceptTemplate)
            {
                DialogResult result = MessageBox.Show("Уже применен шаблон! Вы уверены, что хотите сменить шаблон?", "Предупреждение", MessageBoxButtons.OKCancel);
                return result == DialogResult.OK;
            }
            return true;
        }
    }
}
