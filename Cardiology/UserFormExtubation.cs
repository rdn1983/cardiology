﻿using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class UserFormExtubation : Form
    {
        public UserFormExtubation()
        {
            InitializeComponent();
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

            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\ekstubacia_template.doc";

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{time}", timeCtrl.Text);
            values.Add(@"{body}", bodyArea.Text);
            values.Add(@"{header}", headerArea.Text);
            values.Add(@"{doctor.who}", doctorsBox.Text);
            TemplatesUtils.fillTemplateAndShow(templatePath, values);
        }
    }
}
