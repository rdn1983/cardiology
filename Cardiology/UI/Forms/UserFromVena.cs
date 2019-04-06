using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;

namespace Cardiology.UI.Forms
{
    public partial class UserFromVena : Form
    {
        public UserFromVena()
        {
            InitializeComponent();
            InitializeDoctorsBox();
        }

        private void InitializeDoctorsBox()
        {
            CommonUtils.InitDoctorsComboboxValues(DbDataService.GetInstance(), doctorsBox, null);
        }

        private bool getIsNotValid()
        {
            return veinTxt.Text == null || veinTxt.Text.Length == 0 || tryNumTxt.Text == null || tryNumTxt.Text.Length == 0 ||
                columnTxt.Text == null || columnTxt.Text.Length == 0 || doctorsBox.SelectedIndex < 0;
        }

        
        private void openInWord_Click(object sender, EventArgs e)
        {
            if (getIsNotValid())
            {
                MessageBox.Show("Введены не все данные на форме!", "Предупреждение!", MessageBoxButtons.OK);
                return;
            }

            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\kateter_template.doc";
            
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{date}", dateCtrl.Text);
            values.Add(@"{time}", timeCtrl.Text);
            values.Add(@"{vena}", veinTxt.Text); 
            values.Add(@"{try_num}", tryNumTxt.Text);
            values.Add(@"{column}", columnTxt.Text);
            values.Add(@"{doctor.who}", doctorsBox.Text);
            TemplatesUtils.FillTemplateAndShow(templatePath, values);
        }
    }
}
