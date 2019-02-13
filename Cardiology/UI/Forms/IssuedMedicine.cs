using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class IssuedMedicine : Form
    {
        private readonly IDbDataService service;
        private DdtHospital hospitalitySession;
        private string issuedMedId;
        private string templateName;
        private bool isAcceptTemplate = false;

        public IssuedMedicine(IDbDataService service, DdtHospital hospitalitySession, string issuedMedId)
        {
            this.service = service;
            this.hospitalitySession = hospitalitySession;
            this.issuedMedId = issuedMedId;
            InitializeComponent();

            CommonUtils.InitDoctorsComboboxValues(new DataService(), clinicalPharmacologistBox, "dsi_appointment_type=2");
            CommonUtils.InitDoctorsComboboxValues(new DataService(), nurseBox, null);
            ControlUtils.InitDoctorsByGroupName(service.GetDdvDoctorService(), cardioReanimBox, "duty_cardioreanim");
            ControlUtils.InitDoctorsByGroupName(service.GetDdvDoctorService(), directorBox, "io_cardio_reanim");
            initIssuedCure();

            DdvPatient patient = service.GetDdvPatientService().GetById(hospitalitySession.Patient);
            if (patient != null)
            {
                Text += " " + patient.ShortName;
                if (patient.Sd && (diagnosisTxt.Text == null || !diagnosisTxt.Text.Contains("СД")))
                {
                    diagnosisTxt.Text += "СД ";
                }
            }
        }

        private void initIssuedCure()
        {
            DdtIssuedMedicineList medList = service.GetDdtIssuedMedicineListService().GetById(issuedMedId);
            InitDocBoxValue(clinicalPharmacologistBox, medList?.Pharmacologist);
            InitDocBoxValue(nurseBox, medList?.Nurse);
            InitDocBoxValue(cardioReanimBox, medList == null ? hospitalitySession.DutyDoctor : medList.Doctor);
            InitDocBoxValue(directorBox, medList?.Director);
            templateName = medList?.TemplateName;
            markTemplateBtn(templateName);

            ReinitFromMedList(medList);
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

        private void InitDocBoxValue(ComboBox cb, string docId)
        {
            if (!string.IsNullOrEmpty(docId))
            {
                DdvDoctor doc = service.GetDdvDoctorService().GetById(docId);
                cb.SelectedIndex = cb.FindStringExact(doc?.ShortName);
            }
        }

        private void UpdateMedicineFromTemplate(string template)
        {
            DataService service = new DataService();
            List<DdtCure> medicineTemplates = service.queryObjectsCollection<DdtCure>(@"Select cure.* from ddt_values vv, ddt_cure cure 
                            where vv.dss_name like '" + template + "%' AND vv.dss_value=cure.dss_name");
            issuedMedicineContainer.RefreshData(this.service, medicineTemplates);
        }

        private void clearMedicine()
        {
            for (int i = 0; i < medicineContainer.Controls.Count; i++)
            {
                ComboBox cb = (ComboBox)CommonUtils.FindControl(medicineContainer, "issuedMedicineTxt" + i);
                cb.SelectedIndex = -1;
            }
        }

        private void saveIssuedMedicine()
        {
            List<DdtIssuedMedicine> meds = issuedMedicineContainer.getIssuedMedicines();
            if (meds.Count > 0)
            {
                DdtIssuedMedicineList medList = service.GetDdtIssuedMedicineListService().GetById(issuedMedId);
                if (medList == null)
                {
                    medList = new DdtIssuedMedicineList();
                    medList.HospitalitySession = hospitalitySession.ObjectId;
                    medList.Patient = hospitalitySession.Patient;
                }
                DdvDoctor dir = (DdvDoctor)directorBox.SelectedItem;
                medList.Director = dir?.ObjectId;

                DdvDoctor pharm = (DdvDoctor)clinicalPharmacologistBox.SelectedItem;
                medList.Pharmacologist = pharm?.ObjectId;

                DdvDoctor nurse = (DdvDoctor)nurseBox.SelectedItem;
                medList.Nurse = nurse?.ObjectId;
                DdvDoctor doc = (DdvDoctor)cardioReanimBox.SelectedItem;

                medList.Doctor = doc == null ? hospitalitySession.DutyDoctor : doc.ObjectId;

                medList.Diagnosis = diagnosisTxt.Text;
                medList.TemplateName = templateName;
                medList.HasKag = shortlyOperationTxt.Text;
                medList.IssuingDate = createDateTxt.Value;

                service.GetDdtIssuedMedicineListService().Save(medList);
                foreach (DdtIssuedMedicine med in meds)
                {
                    med.MedList = medList.ObjectId;
                    service.GetDdtIssuedMedicineService().Save(med);
                }
            }
        }

        private void ReinitFromMedList(DdtIssuedMedicineList medList)
        {
            if (medList != null)
            {
                diagnosisTxt.Text = medList.Diagnosis;
                shortlyOperationTxt.Text = medList.HasKag;
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
                UpdateMedicineFromTemplate(templateName);
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
                UpdateMedicineFromTemplate(templateName);
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
                UpdateMedicineFromTemplate(templateName);
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
                UpdateMedicineFromTemplate(templateName);
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
                UpdateMedicineFromTemplate(templateName);
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
            DdtIssuedMedicineList medList = service.GetDdtIssuedMedicineListService().GetListByHospitalId("ddt_anamnesis", hospitalitySession.ObjectId);
            if (medList != null)
            {
                IList<DdtCure> cures = service.GetDdtCureService().GetListByMedicineListId(medList.ObjectId);
                issuedMedicineContainer.RefreshData(service, cures);
            }
        }

        private void copyJournalMedBtn_Click(object sender, EventArgs e)
        {
            String meListId = service.querySingleString(@"SELECT medlist.* FROM ddt_issued_medicine_list medlist, ddt_inspection ins WHERE ins.dsid_hospitality_session='" +
                   hospitalitySession.ObjectId + "' AND medlist.dsid_parent_id=ins.r_object_id ORDER BY dsdt_inspection_date DESC");
            if (!string.IsNullOrEmpty(meListId))
            {
                List<DdtCure> cures = service.queryObjectsCollection<DdtCure>(@"SELECT cures.* FROM " + DdtCure.TABLE_NAME + " cures, " + DdtIssuedMedicine.TABLE_NAME +
                    " meds WHERE meds.dsid_med_list='" + meListId + "' AND meds.dsid_cure=cures.r_object_id");
                issuedMedicineContainer.RefreshData(service, cures);
            }
        }

        private void copyYesterdayMedBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            String meListId = service.querySingleString(@"SELECT * FROM ddt_issued_medicine_list  WHERE dsid_hospitality_session='" +
                   hospitalitySession.ObjectId + "'   ORDER BY dsdt_issuing_date DESC");
            if (!string.IsNullOrEmpty(meListId))
            {
                List<DdtCure> cures = service.queryObjectsCollection<DdtCure>(@"SELECT cures.* FROM " + DdtCure.TABLE_NAME + " cures, " + DdtIssuedMedicine.TABLE_NAME +
                    " meds WHERE meds.dsid_med_list='" + meListId + "' AND meds.dsid_cure=cures.r_object_id");
                issuedMedicineContainer.RefreshData(service, cures);
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            saveIssuedMedicine();

            Dictionary<string, string> values = new Dictionary<string, string>();
            DdtIssuedMedicineList medList = service.GetDdtIssuedMedicineListService().GetById(issuedMedId);
            DdtHospital hospitalSession = service.GetDdtHospitalService().GetById(hospitalitySession.ObjectId);
            DdvDoctor doc = service.GetDdvDoctorService().GetById(medList.Doctor);
            DdvDoctor nurse = service.GetDdvDoctorService().GetById(medList.Nurse);
            DdvDoctor director = service.GetDdvDoctorService().GetById(medList.Director);
            DdvDoctor pharma = service.GetDdvDoctorService().GetById(medList.Pharmacologist);
            DdvPatient patient = service.GetDdvPatientService().GetById(medList.Patient);

            values.Add(@"{doctor.who.short}", doc?.ShortName);
            values.Add(@"{patient.diagnosis}", diagnosisTxt.Text);
            values.Add(@"{patient.age}", DateTime.Now.Year - patient.Birthdate.Year + "");
            values.Add(@"{admission.date}", hospitalSession.AdmissionDate.ToShortDateString());
            values.Add(@"{patient.historycard}", patient?.MedCode);
            values.Add(@"{patient.fullname}", patient?.FullName);
            values.Add(@"{kag}", kagBtn.Checked ? shortlyOperationTxt.Text : "");
            values.Add(@"{nurse}", nurse?.ShortName);
            values.Add(@"{doctor.pharma}", pharma?.ShortName);
            values.Add(@"{doctor.director}", director?.ShortName);
            values.Add(@"{room}", hospitalitySession.RoomCell);
            values.Add(@"{cell}", "");
            values.Add(@"{diet}", "НКД");
            values.Add(@"{date}", DateTime.Now.ToShortDateString());
            //todo переписать,к огда будет время. Сделать добавление в таблицу строчек автоматом
            List<DdtIssuedMedicine> med = issuedMedicineContainer.getIssuedMedicines();
            for (int i = 0; i < 19; i++)
            {
                string value = "";
                if (i < med.Count)
                {
                    DdtCure cure = service.GetDdtCureService().GetById(med[i].Cure);
                    value = cure.Name;
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
                UpdateMedicineFromTemplate(templateName);
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
                UpdateMedicineFromTemplate(templateName);
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
                UpdateMedicineFromTemplate(templateName);
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
                UpdateMedicineFromTemplate(templateName);
                deathMedBtn.BackColor = Color.LightSkyBlue;
            }
        }

        #endregion
    }
}
