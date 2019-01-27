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
        private string templateName;
        private bool isAcceptTemplate = false;

        public IssuedMedicine(DdtHospital hospitalitySession, string issuedMedId)
        {
            this.hospitalitySession = hospitalitySession;
            this.issuedMedId = issuedMedId;
            InitializeComponent();
            DataService service = new DataService();
            CommonUtils.initDoctorsComboboxValues(service, clinicalPharmacologistBox, "dsi_appointment_type=2");
            CommonUtils.initDoctorsComboboxValues(service, nurseBox, null);
            CommonUtils.initDoctorsByGroupComboboxValues(service, cardioReanimBox, "duty_cardioreanim");
            CommonUtils.initDoctorsByGroupComboboxValues(service, directorBox, "io_cardio_reanim");
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
            initDocBoxValue(service, clinicalPharmacologistBox, medList?.DsidPharmacologist);
            initDocBoxValue(service, nurseBox, medList?.DsidNurse);
            initDocBoxValue(service, cardioReanimBox, medList == null ? hospitalitySession.DsidDutyDoctor : medList.DsidDoctor);
            initDocBoxValue(service, directorBox, medList?.DsidDirector);
            templateName = medList?.DssTemplateName;
            markTemplateBtn(templateName);

            reinitFromMedList(service, medList);
        }

        private void markTemplateBtn(string name)
        {
            clearSelection();
            switch (name)
            {
                case "okslongs.medicine.":
                    {
                        oksLongsMedBtn.BackColor = Color.LightSkyBlue;
                        isAcceptTemplate = true;
                        break;
                    }
                case "oks.medicine.":
                    {
                        oksTemplateMed.BackColor = Color.LightSkyBlue;
                        isAcceptTemplate = true;
                        break;
                    }
                case "kag.medicine.":
                    {
                        kagMedBtn.BackColor = Color.LightSkyBlue;
                        isAcceptTemplate = true;
                        break;
                    }
                case "aorta.medicine.":
                    {
                        aortaMedBtn.BackColor = Color.LightSkyBlue;
                        isAcceptTemplate = true;
                        break;
                    }
                case "dep.medicine.":
                    {
                        depMedBtn.BackColor = Color.LightSkyBlue;
                        isAcceptTemplate = true;
                        break;
                    }
                case "death.medicine.":
                    {
                        deathMedBtn.BackColor = Color.LightSkyBlue;
                        isAcceptTemplate = true;
                        break;
                    }
                case "gb.medicine.":
                    {
                        gbMedBtn.BackColor = Color.LightSkyBlue;
                        isAcceptTemplate = true;
                        break;
                    }
                case "hobl.medicine.":
                    {
                        hoblMedBtn.BackColor = Color.LightSkyBlue;
                        isAcceptTemplate = true;
                        break;
                    }
                case "nk.medicine.":
                    {
                        nkMedBtn.BackColor = Color.LightSkyBlue;
                        isAcceptTemplate = true;
                        break;
                    }
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

        private void initDocBoxValue(DataService service, ComboBox cb, string docId)
        {
            if (CommonUtils.isNotBlank(docId))
            {
                DdtDoctors doc = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, docId);
                cb.SelectedIndex = cb.FindStringExact(doc?.DssInitials);
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
                    medList.DsidHospitalitySession = hospitalitySession.ObjectId;
                    medList.DsidPatient = hospitalitySession.DsidPatient;
                }
                DdtDoctors dir = (DdtDoctors)directorBox.SelectedItem;
                medList.DsidDirector = dir?.ObjectId;
                DdtDoctors pharm = (DdtDoctors)clinicalPharmacologistBox.SelectedItem;
                medList.DsidPharmacologist = pharm?.ObjectId;
                DdtDoctors nurse = (DdtDoctors)nurseBox.SelectedItem;
                medList.DsidNurse = nurse?.ObjectId;
                DdtDoctors doc = (DdtDoctors)cardioReanimBox.SelectedItem;
                medList.DsidDoctor = doc == null ? hospitalitySession.DsidDutyDoctor : doc.ObjectId;

                medList.DssDiagnosis = diagnosisTxt.Text;
                medList.DssTemplateName = templateName;
                medList.DssHasKag = shortlyOperationTxt.Text;
                medList.DsdtIssuingDate = createDateTxt.Value;
                issuedMedId = service.updateOrCreateIfNeedObject<DdtIssuedMedicineList>(medList, DdtIssuedMedicineList.TABLE_NAME, medList.ObjectId);
                medList.ObjectId = issuedMedId;
                foreach (DdtIssuedMedicine med in meds)
                {
                    med.DsidMedList = medList.ObjectId;
                    service.updateOrCreateIfNeedObject<DdtIssuedMedicine>(med, DdtIssuedMedicine.TABLE_NAME, med.RObjectId);
                }
            }
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

        #region controls_behavior

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
                templateName = "oks.medicine.";
                updatemedicineFromTemplate(templateName);
                oksTemplateMed.BackColor = Color.LightSkyBlue;
            }
        }

        private void oksLongsMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                templateName = "okslongs.medicine.";
                updatemedicineFromTemplate(templateName);
                oksLongsMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void hoblMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                templateName = "hobl.medicine.";
                updatemedicineFromTemplate(templateName);
                hoblMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void nkMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                templateName = "nk.medicine.";
                updatemedicineFromTemplate(templateName);
                nkMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void gbMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                templateName = "gb.medicine.";
                updatemedicineFromTemplate(templateName);
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
            DdtIssuedMedicineList medList = service.queryObjectById<DdtIssuedMedicineList>(DdtIssuedMedicineList.TABLE_NAME, issuedMedId);
            DdtHospital hospitalSession = service.queryObjectById<DdtHospital>(DdtHospital.TABLENAME, hospitalitySession.ObjectId);
            DdtDoctors doc = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, medList.DsidDoctor);
            DdtDoctors nurse = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, medList.DsidNurse);
            DdtDoctors director = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, medList.DsidDirector);
            DdtDoctors pharma = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, medList.DsidPharmacologist);
            DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, medList.DsidPatient);
            values.Add(@"{doctor.who.short}", doc?.DssInitials);
            values.Add(@"{patient.diagnosis}", diagnosisTxt.Text);
            values.Add(@"{patient.age}", DateTime.Now.Year - patient.DsdtBirthdate.Year + "");
            values.Add(@"{admission.date}", hospitalSession.DsdtAdmissionDate.ToShortDateString());
            values.Add(@"{patient.historycard}", patient?.DssMedCode);
            values.Add(@"{patient.fullname}", patient?.DssFullName);
            values.Add(@"{kag}", kagBtn.Checked ? shortlyOperationTxt.Text : "");
            values.Add(@"{nurse}", nurse?.DssInitials);
            values.Add(@"{doctor.pharma}", pharma?.DssInitials);
            values.Add(@"{doctor.director}", director?.DssInitials);
            values.Add(@"{room}", hospitalitySession.DssRoomCell);
            values.Add(@"{cell}", "");
            values.Add(@"{date}", DateTime.Now.ToShortDateString());
            //todo переписать,к огда будет время. Сделать добавление в таблицу строчек автоматом
            List<DdtIssuedMedicine> med = issuedMedicineContainer.getIssuedMedicines();
            for (int i = 0; i < 19; i++)
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
                templateName = "kag.medicine.";
                updatemedicineFromTemplate(templateName);
                kagMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void aortaMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                templateName = "aorta.medicine.";
                updatemedicineFromTemplate(templateName);
                aortaMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void depMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                templateName = "dep.medicine.";
                updatemedicineFromTemplate(templateName);
                depMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        private void deathMedBtn_Click(object sender, EventArgs e)
        {
            if (isSureChangeTemplate())
            {
                isAcceptTemplate = true;
                clearSelection();
                templateName = "death.medicine.";
                updatemedicineFromTemplate(templateName);
                deathMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        #endregion
    }
}
