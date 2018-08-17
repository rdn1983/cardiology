using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class UserFormTorCent : Form
    {
        public UserFormTorCent()
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
            return arg0.Text == null || arg0.Text.Length == 0 || arg1.Text == null || arg1.Text.Length == 0 ||
                arg2.Text == null || arg2.Text.Length == 0 || arg3.Text == null || arg3.Text.Length == 0 ||
                arg4.Text == null || arg4.Text.Length == 0 || doctorsBox.SelectedIndex < 0;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (getIsNotValid())
            {
                MessageBox.Show("Введены не все данные на форме!", "Предупреждение!", MessageBoxButtons.OK);
                return;
            }

            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\torakacentes_template.doc";

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{date}", dateCtrl.Text);
            values.Add(@"{time}", timeCtrl.Text);
            values.Add(@"{arg0}", arg0.Text);
            values.Add(@"{arg1}", arg1.Text);
            values.Add(@"{arg2}", arg2.Text);
            values.Add(@"{arg3}", arg3.Text);
            values.Add(@"{arg4}", arg4.Text);
            values.Add(@"{doctor.who}", doctorsBox.Text);
            TemplatesUtils.fillTemplateAndShow(templatePath, values);
        }
    }
    
}
