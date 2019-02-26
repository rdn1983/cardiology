﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class UserFormEIT : Form
    {
        private readonly IDbDataService service;

        public UserFormEIT(IDbDataService service)
        {
            InitializeComponent();
            initializeDoctorsBox();
            this.service = service;
        }

        private void initializeDoctorsBox()
        {
            IList<DdvDoctor> doctors = service.GetDdvDoctorService().GetAll();
            for (int i = 0; i < doctors.Count; i++)
            {
                doctorsBox.Items.Add(doctors[i]);
            }
            doctorsBox.ValueMember = "ObjectId";
            doctorsBox.DisplayMember = "DssFullName";

        }

        private bool getIsNotValid()
        {
            return bodyArea.Text == null || bodyArea.Text.Length == 0 || doctorsBox.SelectedIndex < 0;
        }


        private void printBtn_Click(object sender, EventArgs e)
        {
            if (getIsNotValid())
            {
                MessageBox.Show("Введены не все данные на форме!", "Предупреждение!", MessageBoxButtons.OK);
                return;
            }

            string templatePath = Directory.GetCurrentDirectory() + "\\Templates\\eit_template.doc";

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(@"{body}", bodyArea.Text);
            values.Add(@"{doctor.who}", doctorsBox.Text);
            TemplatesUtils.FillTemplateAndShow(templatePath, values);
        }
    }
}
