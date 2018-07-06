namespace Cardiology
{
    partial class AdmissionPatient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdmissionPatient));
            this.lordOfTheCotBox = new System.Windows.Forms.GroupBox();
            this.placeBox = new System.Windows.Forms.GroupBox();
            this.bedTxt = new System.Windows.Forms.TextBox();
            this.roomTxt = new System.Windows.Forms.TextBox();
            this.kagInfoBox = new System.Windows.Forms.GroupBox();
            this.hasKagBtn = new System.Windows.Forms.RadioButton();
            this.hasNoKagBtn = new System.Windows.Forms.RadioButton();
            this.admisPatient = new System.Windows.Forms.Button();
            this.admissionDateBox = new System.Windows.Forms.GroupBox();
            this.patientReceiptDateTime = new System.Windows.Forms.DateTimePicker();
            this.medCodeBox = new System.Windows.Forms.GroupBox();
            this.medCodeTxt = new System.Windows.Forms.TextBox();
            this.directorDepartmentBox = new System.Windows.Forms.GroupBox();
            this.subDoctorBox = new System.Windows.Forms.ComboBox();
            this.cardioSurgeryBox = new System.Windows.Forms.GroupBox();
            this.cardioDocBox = new System.Windows.Forms.ComboBox();
            this.cardioReanimBox = new System.Windows.Forms.GroupBox();
            this.dutyCardioBox = new System.Windows.Forms.ComboBox();
            this.patientBaseInfoBox = new System.Windows.Forms.GroupBox();
            this.weightTxt = new System.Windows.Forms.TextBox();
            this.highTxt = new System.Windows.Forms.TextBox();
            this.phoneTxt = new System.Windows.Forms.TextBox();
            this.addressTxt = new System.Windows.Forms.RichTextBox();
            this.birthDateLbl = new System.Windows.Forms.Label();
            this.weightLbl = new System.Windows.Forms.Label();
            this.highLbl = new System.Windows.Forms.Label();
            this.phoneLbl = new System.Windows.Forms.Label();
            this.addressLbl = new System.Windows.Forms.Label();
            this.patientBirthDate = new System.Windows.Forms.DateTimePicker();
            this.sexGroup = new System.Windows.Forms.GroupBox();
            this.femaleChb = new System.Windows.Forms.RadioButton();
            this.maleChb = new System.Windows.Forms.RadioButton();
            this.patientSecondName = new System.Windows.Forms.TextBox();
            this.secondNameLbl = new System.Windows.Forms.Label();
            this.patientFirstName = new System.Windows.Forms.TextBox();
            this.firstNameLbl = new System.Windows.Forms.Label();
            this.patientLastName = new System.Windows.Forms.TextBox();
            this.lastNameLbl = new System.Windows.Forms.Label();
            this.lordOfTheCotBox.SuspendLayout();
            this.placeBox.SuspendLayout();
            this.kagInfoBox.SuspendLayout();
            this.admissionDateBox.SuspendLayout();
            this.medCodeBox.SuspendLayout();
            this.directorDepartmentBox.SuspendLayout();
            this.cardioSurgeryBox.SuspendLayout();
            this.cardioReanimBox.SuspendLayout();
            this.patientBaseInfoBox.SuspendLayout();
            this.sexGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // lordOfTheCotBox
            // 
            this.lordOfTheCotBox.Controls.Add(this.placeBox);
            this.lordOfTheCotBox.Controls.Add(this.kagInfoBox);
            this.lordOfTheCotBox.Controls.Add(this.admisPatient);
            this.lordOfTheCotBox.Controls.Add(this.admissionDateBox);
            this.lordOfTheCotBox.Controls.Add(this.medCodeBox);
            this.lordOfTheCotBox.Controls.Add(this.directorDepartmentBox);
            this.lordOfTheCotBox.Controls.Add(this.cardioSurgeryBox);
            this.lordOfTheCotBox.Controls.Add(this.cardioReanimBox);
            this.lordOfTheCotBox.Location = new System.Drawing.Point(260, 12);
            this.lordOfTheCotBox.Name = "lordOfTheCotBox";
            this.lordOfTheCotBox.Size = new System.Drawing.Size(305, 416);
            this.lordOfTheCotBox.TabIndex = 3;
            this.lordOfTheCotBox.TabStop = false;
            this.lordOfTheCotBox.Text = "Дежурная бригада";
            // 
            // placeBox
            // 
            this.placeBox.Controls.Add(this.bedTxt);
            this.placeBox.Controls.Add(this.roomTxt);
            this.placeBox.Location = new System.Drawing.Point(6, 327);
            this.placeBox.Name = "placeBox";
            this.placeBox.Size = new System.Drawing.Size(287, 42);
            this.placeBox.TabIndex = 10;
            this.placeBox.TabStop = false;
            this.placeBox.Text = "Палата/Койка";
            // 
            // bedTxt
            // 
            this.bedTxt.Location = new System.Drawing.Point(77, 16);
            this.bedTxt.Name = "bedTxt";
            this.bedTxt.Size = new System.Drawing.Size(64, 20);
            this.bedTxt.TabIndex = 1;
            this.bedTxt.KeyPress += OnlyDigits_KeyPress;
            // 
            // roomTxt
            // 
            this.roomTxt.Location = new System.Drawing.Point(7, 16);
            this.roomTxt.Name = "roomTxt";
            this.roomTxt.Size = new System.Drawing.Size(64, 20);
            this.roomTxt.TabIndex = 0;
            this.roomTxt.KeyPress += OnlyDigits_KeyPress;
            // 
            // kagInfoBox
            // 
            this.kagInfoBox.Controls.Add(this.hasKagBtn);
            this.kagInfoBox.Controls.Add(this.hasNoKagBtn);
            this.kagInfoBox.Location = new System.Drawing.Point(6, 281);
            this.kagInfoBox.Name = "kagInfoBox";
            this.kagInfoBox.Size = new System.Drawing.Size(287, 40);
            this.kagInfoBox.TabIndex = 9;
            this.kagInfoBox.TabStop = false;
            // 
            // hasKagBtn
            // 
            this.hasKagBtn.AutoSize = true;
            this.hasKagBtn.Location = new System.Drawing.Point(98, 17);
            this.hasKagBtn.Name = "hasKagBtn";
            this.hasKagBtn.Size = new System.Drawing.Size(75, 17);
            this.hasKagBtn.TabIndex = 1;
            this.hasKagBtn.Text = "Было КАГ";
            this.hasKagBtn.UseVisualStyleBackColor = true;
            // 
            // hasNoKagBtn
            // 
            this.hasNoKagBtn.AutoSize = true;
            this.hasNoKagBtn.Checked = true;
            this.hasNoKagBtn.Location = new System.Drawing.Point(7, 17);
            this.hasNoKagBtn.Name = "hasNoKagBtn";
            this.hasNoKagBtn.Size = new System.Drawing.Size(91, 17);
            this.hasNoKagBtn.TabIndex = 0;
            this.hasNoKagBtn.TabStop = true;
            this.hasNoKagBtn.Text = "Не было КАГ";
            this.hasNoKagBtn.UseVisualStyleBackColor = true;
            // 
            // admisPatient
            // 
            this.admisPatient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.admisPatient.Location = new System.Drawing.Point(159, 387);
            this.admisPatient.Name = "admisPatient";
            this.admisPatient.Size = new System.Drawing.Size(137, 23);
            this.admisPatient.TabIndex = 1;
            this.admisPatient.Text = "Сохранить изменения";
            this.admisPatient.UseVisualStyleBackColor = true;
            this.admisPatient.Click += new System.EventHandler(this.admisPatient_Click);
            // 
            // admissionDateBox
            // 
            this.admissionDateBox.Controls.Add(this.patientReceiptDateTime);
            this.admissionDateBox.Location = new System.Drawing.Point(6, 231);
            this.admissionDateBox.Name = "admissionDateBox";
            this.admissionDateBox.Size = new System.Drawing.Size(287, 48);
            this.admissionDateBox.TabIndex = 7;
            this.admissionDateBox.TabStop = false;
            this.admissionDateBox.Text = "Дата и время поступления";
            // 
            // patientReceiptDateTime
            // 
            this.patientReceiptDateTime.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.patientReceiptDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.patientReceiptDateTime.Location = new System.Drawing.Point(7, 20);
            this.patientReceiptDateTime.Name = "patientReceiptDateTime";
            this.patientReceiptDateTime.Size = new System.Drawing.Size(122, 20);
            this.patientReceiptDateTime.TabIndex = 0;
            // 
            // medCodeBox
            // 
            this.medCodeBox.Controls.Add(this.medCodeTxt);
            this.medCodeBox.Location = new System.Drawing.Point(6, 176);
            this.medCodeBox.Name = "medCodeBox";
            this.medCodeBox.Size = new System.Drawing.Size(287, 50);
            this.medCodeBox.TabIndex = 8;
            this.medCodeBox.TabStop = false;
            this.medCodeBox.Text = "Номер истории болезни";
            // 
            // medCodeTxt
            // 
            this.medCodeTxt.Location = new System.Drawing.Point(7, 20);
            this.medCodeTxt.Name = "medCodeTxt";
            this.medCodeTxt.Size = new System.Drawing.Size(222, 20);
            this.medCodeTxt.TabIndex = 0;
            // 
            // directorDepartmentBox
            // 
            this.directorDepartmentBox.Controls.Add(this.subDoctorBox);
            this.directorDepartmentBox.Location = new System.Drawing.Point(6, 125);
            this.directorDepartmentBox.Name = "directorDepartmentBox";
            this.directorDepartmentBox.Size = new System.Drawing.Size(289, 48);
            this.directorDepartmentBox.TabIndex = 2;
            this.directorDepartmentBox.TabStop = false;
            this.directorDepartmentBox.Text = "зав. отделения РХМДиЛ";
            // 
            // subDoctorBox
            // 
            this.subDoctorBox.FormattingEnabled = true;
            this.subDoctorBox.Location = new System.Drawing.Point(6, 19);
            this.subDoctorBox.Name = "subDoctorBox";
            this.subDoctorBox.Size = new System.Drawing.Size(276, 21);
            this.subDoctorBox.TabIndex = 0;
            // 
            // cardioSurgeryBox
            // 
            this.cardioSurgeryBox.Controls.Add(this.cardioDocBox);
            this.cardioSurgeryBox.Location = new System.Drawing.Point(6, 70);
            this.cardioSurgeryBox.Name = "cardioSurgeryBox";
            this.cardioSurgeryBox.Size = new System.Drawing.Size(289, 52);
            this.cardioSurgeryBox.TabIndex = 1;
            this.cardioSurgeryBox.TabStop = false;
            this.cardioSurgeryBox.Text = "Рентгеноваскулярный хирург";
            // 
            // cardioDocBox
            // 
            this.cardioDocBox.FormattingEnabled = true;
            this.cardioDocBox.Location = new System.Drawing.Point(7, 20);
            this.cardioDocBox.Name = "cardioDocBox";
            this.cardioDocBox.Size = new System.Drawing.Size(276, 21);
            this.cardioDocBox.TabIndex = 0;
            // 
            // cardioReanimBox
            // 
            this.cardioReanimBox.Controls.Add(this.dutyCardioBox);
            this.cardioReanimBox.Location = new System.Drawing.Point(6, 16);
            this.cardioReanimBox.Name = "cardioReanimBox";
            this.cardioReanimBox.Size = new System.Drawing.Size(289, 51);
            this.cardioReanimBox.TabIndex = 0;
            this.cardioReanimBox.TabStop = false;
            this.cardioReanimBox.Text = "Дежурный кардиореаниматолог";
            // 
            // dutyCardioBox
            // 
            this.dutyCardioBox.FormattingEnabled = true;
            this.dutyCardioBox.Location = new System.Drawing.Point(7, 20);
            this.dutyCardioBox.Name = "dutyCardioBox";
            this.dutyCardioBox.Size = new System.Drawing.Size(276, 21);
            this.dutyCardioBox.TabIndex = 0;
            // 
            // patientBaseInfoBox
            // 
            this.patientBaseInfoBox.Controls.Add(this.weightTxt);
            this.patientBaseInfoBox.Controls.Add(this.highTxt);
            this.patientBaseInfoBox.Controls.Add(this.phoneTxt);
            this.patientBaseInfoBox.Controls.Add(this.addressTxt);
            this.patientBaseInfoBox.Controls.Add(this.birthDateLbl);
            this.patientBaseInfoBox.Controls.Add(this.weightLbl);
            this.patientBaseInfoBox.Controls.Add(this.highLbl);
            this.patientBaseInfoBox.Controls.Add(this.phoneLbl);
            this.patientBaseInfoBox.Controls.Add(this.addressLbl);
            this.patientBaseInfoBox.Controls.Add(this.patientBirthDate);
            this.patientBaseInfoBox.Controls.Add(this.sexGroup);
            this.patientBaseInfoBox.Controls.Add(this.patientSecondName);
            this.patientBaseInfoBox.Controls.Add(this.secondNameLbl);
            this.patientBaseInfoBox.Controls.Add(this.patientFirstName);
            this.patientBaseInfoBox.Controls.Add(this.firstNameLbl);
            this.patientBaseInfoBox.Controls.Add(this.patientLastName);
            this.patientBaseInfoBox.Controls.Add(this.lastNameLbl);
            this.patientBaseInfoBox.Location = new System.Drawing.Point(12, 12);
            this.patientBaseInfoBox.Name = "patientBaseInfoBox";
            this.patientBaseInfoBox.Size = new System.Drawing.Size(242, 416);
            this.patientBaseInfoBox.TabIndex = 2;
            this.patientBaseInfoBox.TabStop = false;
            this.patientBaseInfoBox.Text = "Пациент";
            // 
            // weightTxt
            // 
            this.weightTxt.Location = new System.Drawing.Point(121, 337);
            this.weightTxt.Name = "weightTxt";
            this.weightTxt.Size = new System.Drawing.Size(100, 20);
            this.weightTxt.TabIndex = 15;
            this.weightTxt.KeyPress += OnlyDigits_KeyPress;
            // 
            // highTxt
            // 
            this.highTxt.Location = new System.Drawing.Point(9, 337);
            this.highTxt.Name = "highTxt";
            this.highTxt.Size = new System.Drawing.Size(100, 20);
            this.highTxt.TabIndex = 14;
            this.highTxt.KeyPress += OnlyDigits_KeyPress;
            // 
            // phoneTxt
            // 
            this.phoneTxt.Location = new System.Drawing.Point(9, 279);
            this.phoneTxt.Name = "phoneTxt";
            this.phoneTxt.Size = new System.Drawing.Size(218, 20);
            this.phoneTxt.TabIndex = 13;
            // 
            // addressTxt
            // 
            this.addressTxt.Location = new System.Drawing.Point(9, 187);
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.Size = new System.Drawing.Size(218, 57);
            this.addressTxt.TabIndex = 12;
            this.addressTxt.Text = "";
            // 
            // birthDateLbl
            // 
            this.birthDateLbl.AutoSize = true;
            this.birthDateLbl.Location = new System.Drawing.Point(15, 370);
            this.birthDateLbl.Name = "birthDateLbl";
            this.birthDateLbl.Size = new System.Drawing.Size(86, 13);
            this.birthDateLbl.TabIndex = 11;
            this.birthDateLbl.Text = "Дата рождения";
            // 
            // weightLbl
            // 
            this.weightLbl.AutoSize = true;
            this.weightLbl.Location = new System.Drawing.Point(121, 320);
            this.weightLbl.Name = "weightLbl";
            this.weightLbl.Size = new System.Drawing.Size(43, 13);
            this.weightLbl.TabIndex = 10;
            this.weightLbl.Text = "Вес(кг)";
            // 
            // highLbl
            // 
            this.highLbl.AutoSize = true;
            this.highLbl.Location = new System.Drawing.Point(11, 320);
            this.highLbl.Name = "highLbl";
            this.highLbl.Size = new System.Drawing.Size(51, 13);
            this.highLbl.TabIndex = 9;
            this.highLbl.Text = "Рост(см)";
            // 
            // phoneLbl
            // 
            this.phoneLbl.AutoSize = true;
            this.phoneLbl.Location = new System.Drawing.Point(10, 263);
            this.phoneLbl.Name = "phoneLbl";
            this.phoneLbl.Size = new System.Drawing.Size(52, 13);
            this.phoneLbl.TabIndex = 8;
            this.phoneLbl.Text = "Телефон";
            // 
            // addressLbl
            // 
            this.addressLbl.AutoSize = true;
            this.addressLbl.Location = new System.Drawing.Point(9, 171);
            this.addressLbl.Name = "addressLbl";
            this.addressLbl.Size = new System.Drawing.Size(38, 13);
            this.addressLbl.TabIndex = 7;
            this.addressLbl.Text = "Адрес";
            // 
            // patientBirthDate
            // 
            this.patientBirthDate.CustomFormat = "dd.MM.yyyy";
            this.patientBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.patientBirthDate.Location = new System.Drawing.Point(15, 386);
            this.patientBirthDate.Name = "patientBirthDate";
            this.patientBirthDate.Size = new System.Drawing.Size(122, 20);
            this.patientBirthDate.TabIndex = 0;
            // 
            // sexGroup
            // 
            this.sexGroup.Controls.Add(this.femaleChb);
            this.sexGroup.Controls.Add(this.maleChb);
            this.sexGroup.Location = new System.Drawing.Point(12, 105);
            this.sexGroup.Name = "sexGroup";
            this.sexGroup.Size = new System.Drawing.Size(215, 51);
            this.sexGroup.TabIndex = 6;
            this.sexGroup.TabStop = false;
            this.sexGroup.Text = "Пол";
            // 
            // femaleChb
            // 
            this.femaleChb.AutoSize = true;
            this.femaleChb.Location = new System.Drawing.Point(91, 22);
            this.femaleChb.Name = "femaleChb";
            this.femaleChb.Size = new System.Drawing.Size(69, 17);
            this.femaleChb.TabIndex = 1;
            this.femaleChb.Text = "женский";
            this.femaleChb.UseVisualStyleBackColor = true;
            // 
            // maleChb
            // 
            this.maleChb.AutoSize = true;
            this.maleChb.Checked = true;
            this.maleChb.Location = new System.Drawing.Point(15, 22);
            this.maleChb.Name = "maleChb";
            this.maleChb.Size = new System.Drawing.Size(70, 17);
            this.maleChb.TabIndex = 0;
            this.maleChb.TabStop = true;
            this.maleChb.Text = "мужской";
            this.maleChb.UseVisualStyleBackColor = true;
            // 
            // patientSecondName
            // 
            this.patientSecondName.Location = new System.Drawing.Point(27, 70);
            this.patientSecondName.Multiline = true;
            this.patientSecondName.Name = "patientSecondName";
            this.patientSecondName.Size = new System.Drawing.Size(200, 20);
            this.patientSecondName.TabIndex = 5;
            // 
            // secondNameLbl
            // 
            this.secondNameLbl.AutoSize = true;
            this.secondNameLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.secondNameLbl.Location = new System.Drawing.Point(9, 73);
            this.secondNameLbl.Name = "secondNameLbl";
            this.secondNameLbl.Size = new System.Drawing.Size(18, 13);
            this.secondNameLbl.TabIndex = 4;
            this.secondNameLbl.Text = "О.";
            // 
            // patientFirstName
            // 
            this.patientFirstName.Location = new System.Drawing.Point(27, 44);
            this.patientFirstName.Name = "patientFirstName";
            this.patientFirstName.Size = new System.Drawing.Size(200, 20);
            this.patientFirstName.TabIndex = 3;
            // 
            // firstNameLbl
            // 
            this.firstNameLbl.AutoSize = true;
            this.firstNameLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.firstNameLbl.Location = new System.Drawing.Point(9, 47);
            this.firstNameLbl.Name = "firstNameLbl";
            this.firstNameLbl.Size = new System.Drawing.Size(18, 13);
            this.firstNameLbl.TabIndex = 2;
            this.firstNameLbl.Text = "И.";
            // 
            // patientLastName
            // 
            this.patientLastName.Location = new System.Drawing.Point(27, 19);
            this.patientLastName.Name = "patientLastName";
            this.patientLastName.Size = new System.Drawing.Size(200, 20);
            this.patientLastName.TabIndex = 1;
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.AutoSize = true;
            this.lastNameLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lastNameLbl.Location = new System.Drawing.Point(6, 22);
            this.lastNameLbl.Name = "lastNameLbl";
            this.lastNameLbl.Size = new System.Drawing.Size(21, 13);
            this.lastNameLbl.TabIndex = 0;
            this.lastNameLbl.Text = "Ф.";
            // 
            // AdmissionPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 437);
            this.Controls.Add(this.lordOfTheCotBox);
            this.Controls.Add(this.patientBaseInfoBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdmissionPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поступление пациента";
            this.lordOfTheCotBox.ResumeLayout(false);
            this.placeBox.ResumeLayout(false);
            this.placeBox.PerformLayout();
            this.kagInfoBox.ResumeLayout(false);
            this.kagInfoBox.PerformLayout();
            this.admissionDateBox.ResumeLayout(false);
            this.medCodeBox.ResumeLayout(false);
            this.medCodeBox.PerformLayout();
            this.directorDepartmentBox.ResumeLayout(false);
            this.cardioSurgeryBox.ResumeLayout(false);
            this.cardioReanimBox.ResumeLayout(false);
            this.patientBaseInfoBox.ResumeLayout(false);
            this.patientBaseInfoBox.PerformLayout();
            this.sexGroup.ResumeLayout(false);
            this.sexGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox lordOfTheCotBox;
        private System.Windows.Forms.GroupBox directorDepartmentBox;
        private System.Windows.Forms.ComboBox subDoctorBox;
        private System.Windows.Forms.GroupBox cardioSurgeryBox;
        private System.Windows.Forms.ComboBox cardioDocBox;
        private System.Windows.Forms.GroupBox cardioReanimBox;
        private System.Windows.Forms.ComboBox dutyCardioBox;
        private System.Windows.Forms.GroupBox patientBaseInfoBox;
        private System.Windows.Forms.GroupBox medCodeBox;
        private System.Windows.Forms.TextBox medCodeTxt;
        private System.Windows.Forms.GroupBox admissionDateBox;
        private System.Windows.Forms.DateTimePicker patientReceiptDateTime;
        private System.Windows.Forms.GroupBox sexGroup;
        private System.Windows.Forms.Button admisPatient;
        private System.Windows.Forms.DateTimePicker patientBirthDate;
        private System.Windows.Forms.TextBox patientSecondName;
        private System.Windows.Forms.Label secondNameLbl;
        private System.Windows.Forms.TextBox patientFirstName;
        private System.Windows.Forms.Label firstNameLbl;
        private System.Windows.Forms.TextBox patientLastName;
        private System.Windows.Forms.Label lastNameLbl;
        private System.Windows.Forms.TextBox weightTxt;
        private System.Windows.Forms.TextBox highTxt;
        private System.Windows.Forms.TextBox phoneTxt;
        private System.Windows.Forms.RichTextBox addressTxt;
        private System.Windows.Forms.Label birthDateLbl;
        private System.Windows.Forms.Label weightLbl;
        private System.Windows.Forms.Label highLbl;
        private System.Windows.Forms.Label phoneLbl;
        private System.Windows.Forms.Label addressLbl;
        private System.Windows.Forms.RadioButton femaleChb;
        private System.Windows.Forms.RadioButton maleChb;
        private System.Windows.Forms.GroupBox kagInfoBox;
        private System.Windows.Forms.RadioButton hasKagBtn;
        private System.Windows.Forms.RadioButton hasNoKagBtn;
        private System.Windows.Forms.GroupBox placeBox;
        private System.Windows.Forms.TextBox bedTxt;
        private System.Windows.Forms.TextBox roomTxt;
    }
}