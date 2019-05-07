using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology.UI.Forms
{
    public partial class Transfusion : Form, IAutoSaveForm
    {
        private readonly IDbDataService service;
        private DdtHospital hospitalSession;
        private DdtPatient patient;
        private DdtTransfusion transfusion;
        private DdtBloodAnalysis bloodAnalysis;

        public string ConsiliumId { get; set; }
        public string BloodAnalysisId { get; set; }

        public Transfusion(IDbDataService service, DdtHospital hospitalSession, string transfusionId)
        {
            this.service = service;
            this.hospitalSession = hospitalSession;
            patient = service.GetDdtPatientService().GetById(hospitalSession.Patient);
            if (!String.IsNullOrEmpty(transfusionId))
            {
                transfusion = service.GetDdtTransfusionService().GetById(transfusionId);
                ConsiliumId = transfusion.Consilium;
                BloodAnalysisId = transfusion.BloodAnalysis;
                bloodAnalysis = service.GetDdtBloodAnalysisService().GetById(transfusion.BloodAnalysis);
            }

            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            SetFormText();
            InitDoctorComboBox();
            InitBloodDataControls();
            InitConsentControls();
            InitTransfusionMediumControls();
        }

        private void InitConsentControls()
        {
            string consent = transfusion?.Consent;
            TabControl tabTransfusion = (TabControl)CommonUtils.FindControl(this, "tabTransfusion");
            if (String.IsNullOrEmpty(consent))
            {
                foreach (var controlTabPage in tabTransfusion.TabPages)
                {
                    TabPage tabPage = controlTabPage as TabPage;
                    if (tabPage != null && tabPage.Name.EndsWith("Protocol"))
                    {
                        ((Control)tabPage).Enabled = false;
                    }
                }
                foreach (var control in gbConsent.Controls)
                {
                    Button button = control as Button;
                    if (button != null)
                    {
                        button.Enabled = false;
                    }
                }
                GroupBox groupBox = this.Controls.Find("gbTransfusionMedium", true)[0] as GroupBox;
                groupBox.Enabled = false;
            }
            else
            {
                RadioButton radioButton = GetRadioButtonByName(gbConsent, consent);
                radioButton.Checked = true;

                changeConsentControls(consent, tabTransfusion);
            }
        }

        private void changeConsentControls(string consent, TabControl tabTransfusion)
        {
            if ("NotConsent".ToLower().Equals(consent.ToLower()))
            {
                foreach (var controlTabPage in tabTransfusion.TabPages)
                {
                    TabPage tabPage = controlTabPage as TabPage;
                    if (tabPage != null && tabPage.Name.EndsWith("Protocol"))
                    {
                        ((Control)tabPage).Enabled = false;
                    }
                }
                foreach (var control in gbConsent.Controls)
                {
                    Button button = control as Button;
                    if (button != null)
                    {
                        button.Enabled = false;
                    }
                }
                GroupBox groupBox = this.Controls.Find("gbTransfusionMedium", true)[0] as GroupBox;
                groupBox.Enabled = false;
            }
            else
            {
                foreach (var controlTabPage in tabTransfusion.TabPages)
                {
                    TabPage tabPage = controlTabPage as TabPage;
                    if (tabPage != null && tabPage.Name.EndsWith("Protocol"))
                    {
                        ((Control)tabPage).Enabled = true;
                    }
                }
                foreach (var control in gbConsent.Controls)
                {
                    Button button = control as Button;
                    if (button != null && button.Name.ToLower().EndsWith(consent.ToLower()))
                    {
                        button.Enabled = true;
                    }
                    if (button != null && !button.Name.ToLower().EndsWith(consent.ToLower()))
                    {
                        button.Enabled = false;
                    }
                }
                GroupBox groupBox = this.Controls.Find("gbTransfusionMedium", true)[0] as GroupBox;
                groupBox.Enabled = true;
            }
        }

        private void InitTransfusionMediumControls()
        {
            string transfusionMedium = transfusion?.TransfusionMedium;
            TabControl tabTransfusion = (TabControl)CommonUtils.FindControl(this, "tabTransfusion");
            if (String.IsNullOrEmpty(transfusionMedium))
            {
                foreach (var control in gbTransfusionMedium.Controls)
                {
                    GroupBox groupBox = control as GroupBox;
                    if (groupBox != null)
                    {
                        groupBox.Enabled = false;
                    }

                    TextBox textBox = control as TextBox;
                    if (textBox != null)
                    {
                        textBox.Text = "";

                    }
                    foreach (var controlTabPage in tabTransfusion.TabPages)
                    {
                        TabPage tabPage = controlTabPage as TabPage;
                        if (tabPage != null && tabPage.Name.EndsWith("Protocol"))
                        {
                            ((Control)tabPage).Enabled = false;
                        }
                    }
                }
            }
            else
            {
                String[] transfusionMediumArray = transfusionMedium.Split(',');
                foreach (String mediumWithCount in transfusionMediumArray)
                {
                    String[] mediumArray = mediumWithCount.Split(':');

                    CheckBox cbTransfusionMedium = (CheckBox)CommonUtils.FindControl(gbTransfusionMedium, mediumArray[0]);
                    cbTransfusionMedium.Checked = true;

                    changeTransfusionMeduimControls(mediumArray[0], mediumArray[1], true, tabTransfusion);
                }
            }
        }

        private void changeTransfusionMeduimControls(string transfusionMedium, string transfusionMediumCount, Boolean isChecked, TabControl tabTransfusion)
        {
            foreach (var control in gbTransfusionMedium.Controls)
            {
                GroupBox groupBox = control as GroupBox;
                if (groupBox != null && groupBox.Name.EndsWith(transfusionMedium))
                {
                    groupBox.Enabled = isChecked;

                    setValueFromBloodAnalisis(groupBox, "hemoglobin" + transfusionMedium, bloodAnalysis?.Hemoglobin);
                    setValueFromBloodAnalisis(groupBox, "hematocrit" + transfusionMedium, "");
                    setValueFromBloodAnalisis(groupBox, "aptt" + transfusionMedium, "");
                    setValueFromBloodAnalisis(groupBox, "inr" + transfusionMedium, "");
                    setValueFromBloodAnalisis(groupBox, "protein" + transfusionMedium, bloodAnalysis?.Protein);
                    setValueFromBloodAnalisis(groupBox, "albumin" + transfusionMedium, "");
                    setValueFromBloodAnalisis(groupBox, "platelet" + transfusionMedium, bloodAnalysis?.Platelets);

                    if (groupBox.Controls.ContainsKey("count" + transfusionMedium))
                    {
                        ComboBox comboBox = (ComboBox)groupBox.Controls["count" + transfusionMedium];
                        comboBox.Items.Add("0");
                        comboBox.Items.Add("1");
                        comboBox.Items.Add("2");
                        comboBox.Items.Add("3");
                        comboBox.Items.Add("4");
                        comboBox.Items.Add("5");
                        comboBox.SelectedItem = transfusionMediumCount;
                    }
                }
            }

            foreach (var controlTabPage in tabTransfusion.TabPages)
            {
                TabPage tabPage = controlTabPage as TabPage;
                if (tabPage != null && tabPage.Name.Contains(transfusionMedium))
                {
                    ((Control)tabPage).Enabled = isChecked;
                }
            }
        }

        private static void setValueFromBloodAnalisis(GroupBox groupBox, string tbName, string tbText)
        {
            if (groupBox.Controls.ContainsKey(tbName))
            {
                TextBox textBox = (TextBox)groupBox.Controls[tbName];
                textBox.Text = tbText;
            }
        }

        private void cbTransfusionMediumChanged(object sender, EventArgs e)
        {
            
            TabControl tabTransfusion = (TabControl)CommonUtils.FindControl(this, "tabTransfusion");

            changeTransfusionMeduimControls(((CheckBox)sender).Name, "0", ((CheckBox)sender).Checked, tabTransfusion);
        }

        private void InitBloodDataControls()
        {
            string bloodGroup = patient.BloodGroup;
            if (!String.IsNullOrEmpty(bloodGroup))
            {
                RadioButton rbBloodGroup = GetRadioButtonByText(gbBloodGroup, bloodGroup);
                rbBloodGroup.Checked = true;
            }
            string rHFactor = patient.RHFactor;
            if (!String.IsNullOrEmpty(rHFactor))
            {
                RadioButton rbRHFactor = GetRadioButtonByText(gbRHFactor, rHFactor);
                rbRHFactor.Checked = true;
            }

            TextBox tbKell = (TextBox)CommonUtils.FindControl(gbBloodData, "tbKell");
            tbKell.Text = patient.Kell;

            TextBox tbPhenotype = (TextBox)CommonUtils.FindControl(gbBloodData, "tbPhenotype");
            tbPhenotype.Text = patient.Phenotype;
        }

        private void SetFormText()
        {
            DdvPatient patient = service.GetDdvPatientService().GetById(hospitalSession.Patient);

            if (patient != null)
            {
                Text = "Переливание";
                Text += " " + patient.ShortName;
                if (!String.IsNullOrEmpty(patient.BloodGroup))
                {
                    Text += " Группа крови " + patient.BloodGroup;
                }
                if (!String.IsNullOrEmpty(patient.RHFactor))
                {
                    Text += " Рензус-фактор " + patient.RHFactor;
                }
                if (!String.IsNullOrEmpty(patient.Kell))
                {
                    Text += " Келл " + patient.Kell;
                }
                if (!String.IsNullOrEmpty(patient.Phenotype))
                {
                    Text += " Фенотип " + patient.Phenotype;
                }
            }
        }

        private void InitDoctorComboBox()
        {
            ControlUtils.InitDoctorsByGroupName(this.service.GetDdvDoctorService(), cbDoctor, "cardioreanimation_department");
            String doctorId = transfusion == null ? hospitalSession.CuringDoctor : transfusion.Doctor;
            cbDoctor.SelectedValue = doctorId;
        }

        private void consentBtnClik(object sender, EventArgs e)
        {
            //if (Save())
            //{
            ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType("transfusion_consent");
            if (processor != null)
            {
                string path = processor.processTemplate(service, hospitalSession?.ObjectId, patient?.ObjectId, new Dictionary<string, string>());
                TemplatesUtils.ShowDocument(path);
            }
            //}

        }

        private void btnConsiliumClick(object sender, EventArgs e)
        {
            if (transfusion == null)
            {
                Consilium consilium = new Consilium(service, hospitalSession, ConsiliumId);
                consilium.Owner = this;
                consilium.ShowDialog();
            }
            else
            {
                Consilium consilium = new Consilium(service, hospitalSession, transfusion.Consilium);
                consilium.Owner = this;
                consilium.ShowDialog();
            }
        }

        private void btnBloodAnalysisClick(object sender, EventArgs e)
        {
            if (transfusion == null)
            {
                AnalysisContainer container = new AnalysisContainer(service, hospitalSession, DdtBloodAnalysis.NAME, BloodAnalysisId);
                container.Owner = this;
                container.ShowDialog();
            }
            else
            {
                AnalysisContainer container = new AnalysisContainer(service, hospitalSession, DdtBloodAnalysis.NAME, transfusion.BloodAnalysis);
                container.Owner = this;
                container.ShowDialog();
            }

        }

        RadioButton GetCheckedRadio(Control container)
        {
            foreach (var control in container.Controls)
            {
                RadioButton radio = control as RadioButton;

                if (radio != null && radio.Checked)
                {
                    return radio;
                }
            }

            return null;
        }

        String GetCheckedMediums(Control container)
        {
            String meduims = "";
            foreach (var control in container.Controls)
            {
                CheckBox cbox = control as CheckBox;

                if (cbox != null && cbox.Checked)
                {
                    string name = cbox.Name;
                    GroupBox groupBox = (GroupBox)container.Controls["gb" + name];
                    if (groupBox.Controls.ContainsKey("count" + name))
                    {
                        ComboBox comboBox = (ComboBox)groupBox.Controls["count" + name];
                        name = name + ":" + comboBox.SelectedItem;
                    }

                    meduims += string.IsNullOrEmpty(meduims) ? name : "," + name;
                }
            }
            return meduims;
        }

        private RadioButton GetRadioButtonByText(Control container, string text)
        {
            foreach (var control in container.Controls)
            {
                RadioButton radio = control as RadioButton;
                if (radio != null && (radio.Text.Equals(text)))
                {
                    return radio;
                }
            }
            return null;
        }

        private RadioButton GetRadioButtonByName(Control container, string text)
        {
            foreach (var control in container.Controls)
            {
                RadioButton radio = control as RadioButton;
                if (radio != null && (radio.Name.Equals(text)))
                {
                    return radio;
                }
            }
            return null;
        }

        private void btnSetBloodDataClick(object sender, EventArgs e)
        {
            RadioButton blgr = GetCheckedRadio(gbBloodGroup);
            patient.BloodGroup = blgr.Text;
            RadioButton rhf = GetCheckedRadio(gbRHFactor);
            patient.RHFactor = rhf.Text;
            TextBox tbKell = (TextBox)CommonUtils.FindControl(gbBloodData, "tbKell");
            patient.Kell = tbKell.Text;
            TextBox tbPhenotype = (TextBox)CommonUtils.FindControl(gbBloodData, "tbPhenotype");
            patient.Phenotype = tbPhenotype.Text;

            service.GetDdtPatientService().SetBloodData(patient);
            SetFormText();
        }

        private void requestBtnClik(object sender, EventArgs e)
        {
            Save();
            ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType("request_blood");
            if (processor != null)
            {
                string path = processor.processTemplate(service, hospitalSession?.ObjectId, transfusion?.ObjectId, new Dictionary<string, string>());
                TemplatesUtils.ShowDocument(path);
            }
        }

        private void changeConsent(object sender, EventArgs e)
        {
            TabControl tabTransfusion = (TabControl)CommonUtils.FindControl(this, "tabTransfusion");
            changeConsentControls(((RadioButton)sender).Name, tabTransfusion);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Close();
            }
        }

        public bool Save()
        {
            if (transfusion == null)
            {
                transfusion = new DdtTransfusion();
            }
            transfusion.Patient = patient.ObjectId;
            transfusion.HospitalitySession = hospitalSession.ObjectId;
            transfusion.Doctor = cbDoctor.SelectedValue.ToString();
            transfusion.TransfusionDate = dtTransfusionDate.Value;
            transfusion.Consent = GetCheckedRadio(gbConsent).Name;
            transfusion.Consilium = ConsiliumId;
            transfusion.BloodAnalysis = BloodAnalysisId;
            transfusion.TransfusionMedium = GetCheckedMediums(gbTransfusionMedium);
            service.GetDdtTransfusionService().Save(transfusion);
            return true;
        }
    }
}
