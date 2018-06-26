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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.admisPatient = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.patientReceiptDateTime = new System.Windows.Forms.DateTimePicker();
            this.medCodeBox = new System.Windows.Forms.GroupBox();
            this.medCodeTxt = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.subDoctorBox = new System.Windows.Forms.ComboBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cardioDocBox = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dutyCardioBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.label3 = new System.Windows.Forms.Label();
            this.patientFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.patientLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lordOfTheCotBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.medCodeBox.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.sexGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // lordOfTheCotBox
            // 
            this.lordOfTheCotBox.Controls.Add(this.groupBox2);
            this.lordOfTheCotBox.Controls.Add(this.admisPatient);
            this.lordOfTheCotBox.Controls.Add(this.groupBox3);
            this.lordOfTheCotBox.Controls.Add(this.medCodeBox);
            this.lordOfTheCotBox.Controls.Add(this.groupBox10);
            this.lordOfTheCotBox.Controls.Add(this.groupBox9);
            this.lordOfTheCotBox.Controls.Add(this.groupBox8);
            this.lordOfTheCotBox.Location = new System.Drawing.Point(260, 12);
            this.lordOfTheCotBox.Name = "lordOfTheCotBox";
            this.lordOfTheCotBox.Size = new System.Drawing.Size(305, 416);
            this.lordOfTheCotBox.TabIndex = 3;
            this.lordOfTheCotBox.TabStop = false;
            this.lordOfTheCotBox.Text = "Дежурная бригада";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(6, 317);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 40);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(98, 17);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(75, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Было КАГ";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(91, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Не было КАГ";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // admisPatient
            // 
            this.admisPatient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.admisPatient.Location = new System.Drawing.Point(158, 383);
            this.admisPatient.Name = "admisPatient";
            this.admisPatient.Size = new System.Drawing.Size(137, 23);
            this.admisPatient.TabIndex = 1;
            this.admisPatient.Text = "Сохранить изменения";
            this.admisPatient.UseVisualStyleBackColor = true;
            this.admisPatient.Click += new System.EventHandler(this.admisPatient_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.patientReceiptDateTime);
            this.groupBox3.Location = new System.Drawing.Point(6, 250);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 61);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Дата и время поступления";
            // 
            // patientReceiptDateTime
            // 
            this.patientReceiptDateTime.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.patientReceiptDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.patientReceiptDateTime.Location = new System.Drawing.Point(7, 26);
            this.patientReceiptDateTime.Name = "patientReceiptDateTime";
            this.patientReceiptDateTime.Size = new System.Drawing.Size(122, 20);
            this.patientReceiptDateTime.TabIndex = 0;
            // 
            // medCodeBox
            // 
            this.medCodeBox.Controls.Add(this.medCodeTxt);
            this.medCodeBox.Location = new System.Drawing.Point(6, 194);
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
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.subDoctorBox);
            this.groupBox10.Location = new System.Drawing.Point(6, 137);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(289, 48);
            this.groupBox10.TabIndex = 2;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Зав. отделения ангиографии";
            // 
            // subDoctorBox
            // 
            this.subDoctorBox.FormattingEnabled = true;
            this.subDoctorBox.Location = new System.Drawing.Point(6, 19);
            this.subDoctorBox.Name = "subDoctorBox";
            this.subDoctorBox.Size = new System.Drawing.Size(276, 21);
            this.subDoctorBox.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cardioDocBox);
            this.groupBox9.Location = new System.Drawing.Point(6, 79);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(289, 52);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Рентгеноваскулярный хирург";
            // 
            // cardioDocBox
            // 
            this.cardioDocBox.FormattingEnabled = true;
            this.cardioDocBox.Location = new System.Drawing.Point(7, 20);
            this.cardioDocBox.Name = "cardioDocBox";
            this.cardioDocBox.Size = new System.Drawing.Size(276, 21);
            this.cardioDocBox.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dutyCardioBox);
            this.groupBox8.Location = new System.Drawing.Point(6, 22);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(289, 51);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Дежурный кардиореаниматолог";
            // 
            // dutyCardioBox
            // 
            this.dutyCardioBox.FormattingEnabled = true;
            this.dutyCardioBox.Location = new System.Drawing.Point(7, 20);
            this.dutyCardioBox.Name = "dutyCardioBox";
            this.dutyCardioBox.Size = new System.Drawing.Size(276, 21);
            this.dutyCardioBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.weightTxt);
            this.groupBox1.Controls.Add(this.highTxt);
            this.groupBox1.Controls.Add(this.phoneTxt);
            this.groupBox1.Controls.Add(this.addressTxt);
            this.groupBox1.Controls.Add(this.birthDateLbl);
            this.groupBox1.Controls.Add(this.weightLbl);
            this.groupBox1.Controls.Add(this.highLbl);
            this.groupBox1.Controls.Add(this.phoneLbl);
            this.groupBox1.Controls.Add(this.addressLbl);
            this.groupBox1.Controls.Add(this.patientBirthDate);
            this.groupBox1.Controls.Add(this.sexGroup);
            this.groupBox1.Controls.Add(this.patientSecondName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.patientFirstName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.patientLastName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 416);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пациент";
            // 
            // weightTxt
            // 
            this.weightTxt.Location = new System.Drawing.Point(121, 337);
            this.weightTxt.Name = "weightTxt";
            this.weightTxt.Size = new System.Drawing.Size(100, 20);
            this.weightTxt.TabIndex = 15;
            // 
            // highTxt
            // 
            this.highTxt.Location = new System.Drawing.Point(9, 337);
            this.highTxt.Name = "highTxt";
            this.highTxt.Size = new System.Drawing.Size(100, 20);
            this.highTxt.TabIndex = 14;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(9, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "О.";
            // 
            // patientFirstName
            // 
            this.patientFirstName.Location = new System.Drawing.Point(27, 44);
            this.patientFirstName.Name = "patientFirstName";
            this.patientFirstName.Size = new System.Drawing.Size(200, 20);
            this.patientFirstName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "И.";
            // 
            // patientLastName
            // 
            this.patientLastName.Location = new System.Drawing.Point(27, 19);
            this.patientLastName.Name = "patientLastName";
            this.patientLastName.Size = new System.Drawing.Size(200, 20);
            this.patientLastName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ф.";
            // 
            // AdmissionPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 437);
            this.Controls.Add(this.lordOfTheCotBox);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdmissionPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поступление пациента";
            this.lordOfTheCotBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.medCodeBox.ResumeLayout(false);
            this.medCodeBox.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.sexGroup.ResumeLayout(false);
            this.sexGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox lordOfTheCotBox;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox subDoctorBox;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ComboBox cardioDocBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox dutyCardioBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox medCodeBox;
        private System.Windows.Forms.TextBox medCodeTxt;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker patientReceiptDateTime;
        private System.Windows.Forms.GroupBox sexGroup;
        private System.Windows.Forms.Button admisPatient;
        private System.Windows.Forms.DateTimePicker patientBirthDate;
        private System.Windows.Forms.TextBox patientSecondName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox patientFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox patientLastName;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}