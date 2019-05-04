using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;

namespace Cardiology.UI.Forms
{
    public partial class UserFormVEKS : Form
    {
        public UserFormVEKS()
        {
            InitializeComponent();
            initializeDoctorsBox();
        }

        private void initializeDoctorsBox()
        {
            CommonUtils.InitDoctorsByGroupComboboxValues(DbDataService.GetInstance(), doctorsBox, "cardioreanimation_department");
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (getIsNotValid())
            {
                MessageBox.Show("Введены не все данные на форме!", "Предупреждение!", MessageBoxButtons.OK);
                return;
            }

            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\veks_template.doc";

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{vein}", veinTxt.Text);
            values.Add(@"{body}", bodyArea.Text);
            values.Add(@"{doctor.who}", doctorsBox.Text);
            TemplatesUtils.FillTemplateAndShow(templatePath, values, null);
        }

        private bool getIsNotValid()
        {
            return veinTxt.Text == null || veinTxt.Text.Length == 0 || bodyArea.Text == null || bodyArea.Text.Length == 0
               || doctorsBox.SelectedIndex < 0;
        }

    }
}
