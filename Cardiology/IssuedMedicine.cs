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

            DdtIssuedMedicine med = service.queryObjectById<DdtIssuedMedicine>(DdtIssuedMedicine.TABLE_NAME, issuedMedId);
            if (med != null)
            {
                DdtCure cure = service.queryObjectById<DdtCure>(DdtCure.TABLE_NAME, med.DsidCure);
                if (cure != null)
                {
                    issuedMedicineTxt0.SelectedIndex = issuedMedicineTxt0.FindStringExact(cure.DssName);

                }
            }
            CommonUtils.initDoctorsComboboxValues(service, clinicalPharmacologistBox, "dsi_appointment_type=2");
            CommonUtils.initDoctorsComboboxValues(service, nurseBox, null);
            CommonUtils.initDoctorsComboboxValues(service, cardioReanimBox, null);
            CommonUtils.initDoctorsComboboxValues(service, directorBox, null);
            CommonUtils.initCureComboboxValues(service, issuedMedicineTxt0, null);
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
            CreateCureBox();
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
                ComboBox box = null;
                if (medicineContainer.Controls.Count <= i)
                {
                    box = CreateCureBox();
                }
                else
                {
                    box = (ComboBox)medicineContainer.GetControlFromPosition(0, i);
                }
                box.SelectedIndex = box.FindStringExact(medicineTemplates[i].DssValue);

            }
        }

        private void clearMedicine()
        {
            for (int i = 0; i < medicineContainer.Controls.Count; i++)
            {
                ComboBox cb = (ComboBox)medicineContainer.Controls[i];
                cb.SelectedIndex = -1;
            }
        }

        private ComboBox CreateCureBox()
        {
            ComboBox issuedMedicineBox = new ComboBox();
            issuedMedicineBox.Size = issuedMedicineTxt0.Size;
            issuedMedicineBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CommonUtils.initCureComboboxValues(new DataService(), issuedMedicineBox, null);
            medicineContainer.Controls.Add(issuedMedicineBox);
            return issuedMedicineBox;
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
            int i = 0;
            IEnumerator numerator = medicineContainer.Controls.GetEnumerator();
            while (numerator.MoveNext())
            {
                DdtIssuedMedicine med = null;
                if (i == 0 && CommonUtils.isNotBlank(issuedMedId))
                {
                    med = service.queryObjectById<DdtIssuedMedicine>(DdtIssuedMedicine.TABLE_NAME, issuedMedId);
                }
                else
                {
                    med = new DdtIssuedMedicine();
                    med.DsidDoctor = hospitalitySession.DsidDutyDoctor;
                    med.DsidHospitalitySession = hospitalitySession.ObjectId;
                    med.DsidPatient = hospitalitySession.DsidPatient;
                }
                ComboBox box = (ComboBox)numerator.Current;
                DdtCure cure = (DdtCure)box.SelectedItem;
                if (cure != null && CommonUtils.isNotBlank(box.Text))
                {
                    med.DsidCure = cure.ObjectId;
                    med.DssParentType = DdtAnamnesis.TABLE_NAME;
                    service.updateOrCreateIfNeedObject<DdtIssuedMedicine>(med, DdtIssuedMedicine.TABLE_NAME, med.ObjectId);
                }
                i++;
            }
        }
    }
}
