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

        private readonly IList<DdtIssuedMedicine> medicineList = new List<DdtIssuedMedicine>();

        public IssuedMedicine(IDbDataService service, DdtHospital hospitalitySession, string issuedMedId)
        {
            this.service = service;
            this.hospitalitySession = hospitalitySession;
            this.issuedMedId = issuedMedId;
            InitializeComponent();

            ControlUtils.InitDoctorsByGroupName(service.GetDdvDoctorService(), clinicalPharmacologistBox, "clinical_pharmacologists");
            ControlUtils.InitDoctorsByGroupName(service.GetDdvDoctorService(), nurseBox, "nurses");
            ControlUtils.InitDoctorsByGroupName(service.GetDdvDoctorService(), cardioReanimBox, "cardioreanimation_department");
            ControlUtils.InitDoctorsByGroupNameAndOrder(service.GetDdvDoctorService(), directorBox, "cardioreanimation_department", "default.cardioreanimation_department_head");

            InitIssuedCure();

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

        private void InitIssuedCure()
        {
            DdtIssuedMedicineList medList = service.GetDdtIssuedMedicineListService().GetById(issuedMedId);
            InitDocBoxValue(clinicalPharmacologistBox, medList?.Pharmacologist);
            InitDocBoxValue(nurseBox, medList?.Nurse);
            InitDocBoxValue(cardioReanimBox, medList == null ? hospitalitySession.DutyDoctor : medList.Doctor);
            InitDocBoxValue(directorBox, medList?.Director);
            templateName = medList?.TemplateName;
            markTemplateBtn(templateName);

            InitIssuedMedList(medList);
        }

        private void AddIssuedMedicine(DdtIssuedMedicine med, DdtCure cure)
        {
            medicineList.Add(med);

            FlowLayoutPanel ll = new FlowLayoutPanel();
            ll.FlowDirection = FlowDirection.LeftToRight;
            ll.Width = 700;
            ll.AutoSize = true;

            ComboBox cureTypeControl = new ComboBox();
            cureTypeControl.Width = 250;
            CommonUtils.InitCureTypeComboboxValues(DbDataService.GetInstance(), cureTypeControl);
            if (cure != null && cure.CureType != null)
            {
                for (int index = 0; index < cureTypeControl.Items.Count; index++)
                {
                    DdtCureType ct = (DdtCureType)cureTypeControl.Items[index];
                    if (ct.ObjectId == cure.CureType)
                    {
                        cureTypeControl.SelectedIndex = index;
                        break;
                    }
                }
            }
            ll.Controls.Add(cureTypeControl);

            ComboBox cureControl = new ComboBox();
            cureControl.Width = 350;

            DdtCureType cureType = (DdtCureType)cureTypeControl.SelectedItem;
            if (cureType != null)
            {
                CommonUtils.InitCureComboboxValuesByTypeId(DbDataService.GetInstance(), cureControl, cureType.ObjectId);
            }

            if (cure != null && cure.ObjectId != null)
            {
                for (int index = 0; index < cureControl.Items.Count; index++)
                {
                    DdtCure c = (DdtCure)cureControl.Items[index];
                    if (c.ObjectId == cure.ObjectId)
                    {
                        cureControl.SelectedIndex = index;
                        break;
                    }
                }
            }
            cureControl.SelectedIndexChanged += delegate (object sender2, EventArgs args)
            {
                med.Cure = ((DdtCure)cureControl.SelectedItem).ObjectId;
            };
            ll.Controls.Add(cureControl);

            cureTypeControl.SelectedIndexChanged += delegate (object sender2, EventArgs args)
            {
                DdtCureType selectedVal = (DdtCureType)cureTypeControl.SelectedItem;
                CommonUtils.InitCureComboboxValuesByTypeId(DbDataService.GetInstance(), cureControl, selectedVal.ObjectId);
            };

            Button remove = new Button
            {
                Image = Properties.Resources.remove,
                Size = new Size(25, 25),
                UseVisualStyleBackColor = true
            };
            ll.Controls.Add(remove);

            remove.Click += delegate (object sender2, EventArgs args)
            {
                medicineList.Remove(med);
                layout.Controls.Remove(ll);
            };
            layout.Controls.Add(ll);
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

            List<DdtCure> medicineTemplates = service.GetDdtCureService().GetByQuery(@"Select cure.* from ddt_values vv, ddt_cure cure 
                            where vv.dss_name like '" + template + "%' AND vv.dss_value=cure.dss_name");
            foreach (DdtCure cure in medicineTemplates)
            {
                DdtIssuedMedicine med = new DdtIssuedMedicine
                {
                    Cure = cure.ObjectId
                };
                AddIssuedMedicine(med, cure);
            }
        }

        private void SaveIssuedMedicine()
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

            IList<DdtIssuedMedicine> list = service.GetDdtIssuedMedicineService().GetListByMedicineListId(medList.ObjectId);
            //Добавляем текущий список
            foreach (DdtIssuedMedicine med in medicineList)
            {
                if (med.Cure != null)
                {
                    med.MedList = medList.ObjectId;
                    service.GetDdtIssuedMedicineService().Save(med);
                }
            }

            //Удаляем то, что было в списке, а сейчас нет
            foreach (DdtIssuedMedicine old in list)
            {
                bool found = false;
                foreach (DdtIssuedMedicine med in medicineList)
                {
                    if (old.ObjectId == med.ObjectId)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    service.GetDdtIssuedMedicineService().Delete(old.ObjectId);
                }
            }
        }

        private void InitIssuedMedList(DdtIssuedMedicineList medList)
        {
            if (medList != null)
            {
                diagnosisTxt.Text = medList.Diagnosis;
                shortlyOperationTxt.Text = medList.HasKag;

                IList<DdtIssuedMedicine> list = DbDataService.GetInstance().GetDdtIssuedMedicineService().GetListByMedicineListId(medList.ObjectId);
                foreach (DdtIssuedMedicine med in list)
                {
                    DdtCure cure = DbDataService.GetInstance().GetDdtCureService().GetById(med.Cure);
                    AddIssuedMedicine(med, cure);
                }
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
            AddIssuedMedicine(new DdtIssuedMedicine(), null);
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
            medicineList.Clear();
            layout.Controls.Clear();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveIssuedMedicine();
            Close();
        }

        private void copyFirstMedicineBtn_Click(object sender, EventArgs e)
        {
            DdtIssuedMedicineList medList = service.GetDdtIssuedMedicineListService().GetListByHospitalIdAndParentType(DdtAnamnesis.NAME, hospitalitySession.ObjectId);
            if (medList != null)
            {
                IList<DdtCure> cures = service.GetDdtCureService().GetListByMedicineListId(medList.ObjectId);
                foreach(DdtCure cure in cures)
                {
                    DdtIssuedMedicine med = new DdtIssuedMedicine
                    {
                        Cure = cure.ObjectId
                    };
                    AddIssuedMedicine(med, cure);
                }
            }
        }

        private void copyJournalMedBtn_Click(object sender, EventArgs e)
        {
            String medListId = service.GetString(@"SELECT medlist.* FROM ddt_issued_medicine_list medlist, ddt_inspection ins WHERE ins.dsid_hospitality_session='" +
                   hospitalitySession.ObjectId + "' AND medlist.dsid_parent_id=ins.r_object_id ORDER BY dsdt_inspection_date DESC");
            if (!string.IsNullOrEmpty(medListId))
            {
                IList<DdtCure> cures = service.GetDdtCureService().GetListByMedicineListId(medListId);
                foreach (DdtCure cure in cures)
                {
                    DdtIssuedMedicine med = new DdtIssuedMedicine
                    {
                        Cure = cure.ObjectId
                    };
                    AddIssuedMedicine(med, cure);
                }
            }
        }

        private void copyYesterdayMedBtn_Click(object sender, EventArgs e)
        {

            String medListId = service.GetString(@"SELECT * FROM ddt_issued_medicine_list  WHERE dsid_hospitality_session='" +
                   hospitalitySession.ObjectId + "'   ORDER BY dsdt_issuing_date DESC");
            if (!string.IsNullOrEmpty(medListId))
            {
                List<DdtCure> cures = service.GetDdtCureService().GetByQuery(@"SELECT cures.* FROM " + DdtCure.NAME + " cures, " + DdtIssuedMedicine.NAME +
                    " meds WHERE meds.dsid_med_list='" + medListId + "' AND meds.dsid_cure=cures.r_object_id");
                foreach (DdtCure cure in cures)
                {
                    DdtIssuedMedicine med = new DdtIssuedMedicine
                    {
                        Cure = cure.ObjectId
                    };
                    AddIssuedMedicine(med, cure);
                }
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            SaveIssuedMedicine();

            Dictionary<string, string> values = new Dictionary<string, string>();
            DdtIssuedMedicineList medList = service.GetDdtIssuedMedicineListService().GetById(issuedMedId);
            DdtHospital hospitalSession = service.GetDdtHospitalService().GetById(hospitalitySession.ObjectId);

            DdvDoctor doc = null; 
            DdvDoctor nurse = null; 
            DdvDoctor director = null; 
            DdvDoctor pharma = null; 
            DdvPatient patient = null;

            if( medList != null)
            {
                doc = service.GetDdvDoctorService().GetById(medList.Doctor);
                nurse = service.GetDdvDoctorService().GetById(medList.Nurse);
                director = service.GetDdvDoctorService().GetById(medList.Director);
                pharma = service.GetDdvDoctorService().GetById(medList.Pharmacologist);
                patient = service.GetDdvPatientService().GetById(medList.Patient);
            }

            values.Add(@"{doctor.who.short}", doc?.ShortName);
            values.Add(@"{patient.diagnosis}", diagnosisTxt.Text);
            values.Add(@"{patient.age}", patient != null? DateTime.Now.Year - patient.Birthdate.Year + "": "");
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
            //todo переписать,когда будет время. Сделать добавление в таблицу строчек автоматом
            for (int i = 0; i < 19; i++)
            {
                string value = "";
                if (i < medicineList.Count)
                {
                    DdtCure cure = service.GetDdtCureService().GetById(medicineList[i].Cure);
                    value = cure.Name;
                }
                values.Add(@"{issued_medicine_" + i + "}", value);
            }
            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\issued_medicine_template.doc";
            TemplatesUtils.FillTemplateAndShow(templatePath, values, TemplatesUtils.getTempFileName("Назначения", patient.FullName));
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
