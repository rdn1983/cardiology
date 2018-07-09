using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class IssuedMedicine : Form
    {
        private DdtHospital hospitalitySession;

        public IssuedMedicine(DdtHospital hospitalitySession)
        {
            this.hospitalitySession = hospitalitySession;
            InitializeComponent();
            DataService service = new DataService();
            initClinicalPharmacologistBox(service);
            CommonUtils.initCureComboboxValues(service, issuedMedicineTxt0, null);
        }

        private void initClinicalPharmacologistBox(DataService service)
        {
            CommonUtils.initDoctorsComboboxValues(service, clinicalPharmacologistBox, "dsi_appointment_type=2");
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
            for (int i=0; i< medicineContainer.Controls.Count; i++)
            {
                ComboBox cb = (ComboBox) medicineContainer.Controls[i];
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
            Close();
        }
    }
}
