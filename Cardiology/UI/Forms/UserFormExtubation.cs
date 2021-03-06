﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;

namespace Cardiology.UI.Forms
{
    public partial class UserFormExtubation : Form
    {
        public UserFormExtubation()
        {
            InitializeComponent();
            ControlUtils.InitDoctorsByGroupName(DbDataService.GetInstance().GetDdvDoctorService(), doctorsBox, "cardioreanimation_department");
        }

        private bool getIsNotValid()
        {
            return headerArea.Text == null || headerArea.Text.Length == 0 || doctorsBox.SelectedIndex < 0;
        }


        private void printBtn_Click(object sender, EventArgs e)
        {
            if (getIsNotValid())
            {
                MessageBox.Show("Введены не все данные на форме!", "Предупреждение!", MessageBoxButtons.OK);
                return;
            }

            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\ekstubacia_template.doc";

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{time}", timeCtrl.Text);
            values.Add(@"{body}", "");
            values.Add(@"{header}", headerArea.Text);
            values.Add(@"{doctor.who}", doctorsBox.Text);
            TemplatesUtils.FillTemplateAndShow(templatePath, values, null);
        }
    }
}
