using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;

namespace Cardiology.UI.Forms
{
    public partial class UserFormIntubation : Form
    {

        public UserFormIntubation()
        {
            InitializeComponent();
            initializeDoctorsBox();
            initializeHeaderArea();
        }

        private void initializeDoctorsBox()
        {
            CommonUtils.InitDoctorsByGroupComboboxValues(DbDataService.GetInstance(), doctorsBox, "cardioreanimation_department");
        }

        private void initializeHeaderArea()
        {
            RichTextBox headerArea = (RichTextBox) CommonUtils.FindControl(this, "headerArea");
            headerArea.Text = "В связи с неэффективностью консервативной терапии, нарастающей дыхательной и сердечно-сосудистой недостаточностью " +
                "принято решение перевести больного на ИВЛ. После предварительной оксигенации лицевой маской больной интубирован с первой попытки трубкой № 9. " +
                "Трубка фиксирована. Дыхание проводится во все отделы, симметрично. Налажена ИВЛ в режиме SIMV, ДО - 550 мл, FIO2- 30%, P ins 15 mbr, PEEP 5 mbr";
        }

        private bool getIsNotValid()
        {
            return headerArea.Text == null || headerArea.Text.Length == 0 || bodyArea.Text == null || bodyArea.Text.Length == 0 ||
                doctorsBox.SelectedIndex < 0;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (getIsNotValid())
            {
                MessageBox.Show("Введены не все данные на форме!", "Предупреждение!", MessageBoxButtons.OK);
                return;
            }

            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\intubation_template.doc";

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{date}", dateCtrl.Text);
            values.Add(@"{time}", timeCtrl.Text);
            values.Add(@"{header}", headerArea.Text);
            values.Add(@"{body}", bodyArea.Text);
            values.Add(@"{doctor.who}", doctorsBox.Text);
            TemplatesUtils.FillTemplateAndShow(templatePath, values);
        }
    }
}
