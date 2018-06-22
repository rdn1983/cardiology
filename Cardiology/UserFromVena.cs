using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Model;
using System.IO;
using Cardiology.Utils;

namespace Cardiology
{
    public partial class UserFromVena : Form
    {

        public UserFromVena()
        {
            InitializeComponent();
            initializeDoctorsBox();
        }

        private void initializeDoctorsBox()
        {
            DataService service = new DataService();
            List<DdtDoctors> doctors = service.queryObjectsCollection<DdtDoctors>(@"select * from ddt_doctors");
            for (int i = 0; i < doctors.Count; i++)
            {
                doctorsBox.Items.Add(doctors[i]);
            }
            doctorsBox.ValueMember = "ObjectId";
            doctorsBox.DisplayMember = "DssFullName";

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

            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\kateter_template.docx";
            
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{date}", dateCtrl.Text);
            values.Add(@"{time}", timeCtrl.Text);
            values.Add(@"{vena}", veinTxt.Text); 
            values.Add(@"{try_num}", tryNumTxt.Text);
            values.Add(@"{column}", columnTxt.Text);
            values.Add(@"{doctor.who}", doctorsBox.SelectedText);
            TemplatesUtils.fillTemplate(templatePath, values);
        }
    }
}
