using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
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
            CommonUtils.initCureComboboxValues(service, issuedMedicineTxt0, null);
            initIssuedCure(service);
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
                List<DdtIssuedMedicine> med = service.queryObjectsCollectionByAttrCond<DdtIssuedMedicine>(DdtIssuedMedicine.TABLE_NAME, "dsid_med_list", medList.ObjectId, true);
                for (int i = 0; i < med.Count; i++)
                {
                    DdtCure cure = service.queryObjectById<DdtCure>(DdtCure.TABLE_NAME, med[i].DsidCure);
                    if (cure != null)
                    {
                        Control container = null;
                        if (medicineContainer.Controls.Count <= i)
                        {
                            container = CommonUtils.copyControl(issuedMedPnl0, medicineContainer.Controls.Count);
                            medicineContainer.Controls.Add(container);
                        }
                        else
                        {
                            container = medicineContainer.Controls[i];
                        }
                        ComboBox box = (ComboBox)CommonUtils.findControl(container, "issuedMedicineTxt" + i);
                        box.SelectedIndex = box.FindStringExact(cure.DssName);
                        Label idLbl = (Label)CommonUtils.findControl(container, "objectIdLbl" + i);
                        idLbl.Text = cure.ObjectId;
                    }

                }
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
            Control c = CommonUtils.copyControl(issuedMedPnl0, medicineContainer.Controls.Count);
            medicineContainer.Controls.Add(c);
        }

        private void oksTemplateMed_Click(object sender, EventArgs e)
        {
            updatemedicineFromTemplate("oks.medicine.");
        }

        private void updatemedicineFromTemplate(string template)
        {
            clearMedicine();
            DataService service = new DataService();
            List<DdtValues> medicineTemplates = service.queryObjectsCollection<DdtValues>(@"Select * from ddt_values where dss_name like '" + template + "%'");
            for (int i = 0; i < medicineTemplates.Count; i++)
            {
                if (medicineContainer.Controls.Count <= i)
                {
                    Control c = CommonUtils.copyControl(issuedMedPnl0, medicineContainer.Controls.Count);
                    medicineContainer.Controls.Add(c);
                }
                ComboBox box = (ComboBox)CommonUtils.findControl(medicineContainer, "issuedMedicineTxt" + i);
                box.SelectedIndex = box.FindStringExact(medicineTemplates[i].DssValue);

            }
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
            clearMedicine();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveIssuedMedicine();
            Close();
        }

        private void saveIssuedMedicine()
        {
            DataService service = new DataService();
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


            for (int i = 0; i < medicineContainer.Controls.Count; i++)
            {
                Control container = medicineContainer.Controls[i];
                Label idLbl = (Label)CommonUtils.findControl(container, "objectIdLbl" + i);
                DdtIssuedMedicine med = null;
                if (CommonUtils.isNotBlank(idLbl.Text))
                {
                    med = service.queryObjectById<DdtIssuedMedicine>(DdtIssuedMedicine.TABLE_NAME, idLbl.Text);
                }
                else
                {
                    med = new DdtIssuedMedicine();
                }
                ComboBox box = (ComboBox)CommonUtils.findControl(container, "issuedMedicineTxt" + i);
                DdtCure cure = (DdtCure)box.SelectedItem;
                if (cure != null && CommonUtils.isNotBlank(box.Text))
                {
                    med.DsidCure = cure.ObjectId;
                    med.DsidMedList = medList.ObjectId;
                    service.updateOrCreateIfNeedObject<DdtIssuedMedicine>(med, DdtIssuedMedicine.TABLE_NAME, med.RObjectId);
                }
            }
        }

        private void copyFirstMedicineBtn_Click(object sender, EventArgs e)
        {
            clearMedicine();
            DataService service = new DataService();
            DdtIssuedMedicineList medList = service.queryObject<DdtIssuedMedicineList>(@"SELECT * FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='" +
                   hospitalitySession.ObjectId + "' AND dss_parent_type='ddt_anamnesis'");
            reinitFromMedList(service, medList);
        }
    }
}
