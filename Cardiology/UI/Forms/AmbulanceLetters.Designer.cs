namespace Cardiology.UI.Forms
{
    partial class AmbulanceLetters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmbulanceLetters));
            this.smpInfo = new System.Windows.Forms.GroupBox();
            this.doctorsBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toTime = new System.Windows.Forms.DateTimePicker();
            this.fromTime = new System.Windows.Forms.DateTimePicker();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gkbBtn = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbUdinaBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gkbBuyanovaBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lrcBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.mschBtn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.gkb52Btn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.smpInfo.SuspendLayout();
            this.gkbBtn.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // smpInfo
            // 
            this.smpInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.smpInfo.Controls.Add(this.doctorsBox);
            this.smpInfo.Controls.Add(this.label5);
            this.smpInfo.Controls.Add(this.toTime);
            this.smpInfo.Controls.Add(this.fromTime);
            this.smpInfo.Controls.Add(this.fromDate);
            this.smpInfo.Controls.Add(this.label4);
            this.smpInfo.Controls.Add(this.label3);
            this.smpInfo.Location = new System.Drawing.Point(419, 25);
            this.smpInfo.Name = "smpInfo";
            this.smpInfo.Size = new System.Drawing.Size(220, 172);
            this.smpInfo.TabIndex = 3;
            this.smpInfo.TabStop = false;
            this.smpInfo.Text = "СМП прибудет:";
            // 
            // doctorsBox
            // 
            this.doctorsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doctorsBox.FormattingEnabled = true;
            this.doctorsBox.Location = new System.Drawing.Point(6, 136);
            this.doctorsBox.Name = "doctorsBox";
            this.doctorsBox.Size = new System.Drawing.Size(208, 21);
            this.doctorsBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Заместитель главного врача: ";
            // 
            // toTime
            // 
            this.toTime.CustomFormat = "HH:mm tt";
            this.toTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toTime.Location = new System.Drawing.Point(131, 93);
            this.toTime.Name = "toTime";
            this.toTime.ShowUpDown = true;
            this.toTime.Size = new System.Drawing.Size(83, 20);
            this.toTime.TabIndex = 4;
            // 
            // fromTime
            // 
            this.fromTime.CustomFormat = "HH:mm tt";
            this.fromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromTime.Location = new System.Drawing.Point(131, 43);
            this.fromTime.Name = "fromTime";
            this.fromTime.ShowUpDown = true;
            this.fromTime.Size = new System.Drawing.Size(83, 20);
            this.fromTime.TabIndex = 3;
            // 
            // fromDate
            // 
            this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDate.Location = new System.Drawing.Point(26, 43);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(81, 20);
            this.fromDate.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "(время)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "(дата)";
            // 
            // gkbBtn
            // 
            this.gkbBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gkbBtn.Controls.Add(this.tabPage1);
            this.gkbBtn.Controls.Add(this.tabPage2);
            this.gkbBtn.Controls.Add(this.tabPage3);
            this.gkbBtn.Controls.Add(this.tabPage4);
            this.gkbBtn.Controls.Add(this.tabPage5);
            this.gkbBtn.Controls.Add(this.tabPage6);
            this.gkbBtn.Location = new System.Drawing.Point(6, 3);
            this.gkbBtn.Name = "gkbBtn";
            this.gkbBtn.SelectedIndex = 0;
            this.gkbBtn.Size = new System.Drawing.Size(392, 198);
            this.gkbBtn.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbUdinaBtn);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(384, 172);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ГКБ Юдина";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbUdinaBtn
            // 
            this.gbUdinaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUdinaBtn.Location = new System.Drawing.Point(250, 143);
            this.gbUdinaBtn.Name = "gbUdinaBtn";
            this.gbUdinaBtn.Size = new System.Drawing.Size(128, 23);
            this.gbUdinaBtn.TabIndex = 2;
            this.gbUdinaBtn.Text = "Открыть в MSWord";
            this.gbUdinaBtn.UseVisualStyleBackColor = true;
            this.gbUdinaBtn.Click += new System.EventHandler(this.gbUdinaBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пациента ожидают в ГБУЗ Городскую клиническую больницу \r\nимени С.С.Юдина К4, расп" +
    "оложенной по адресу: \r\n г. Москва, Коломенский проезд, д.4,  к:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Врачебную бригаду медицинской эвакуации (СМП)\r\n в ГКБ №67 им. Л.А.Ворохобова, в о" +
    "тделение кардиореанимации\r\n(корпус Б, 1 этаж, тел 8(495)530-33-86) ожидаем к ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gkbBuyanovaBtn);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(384, 172);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ГКБ Буянова (12)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gkbBuyanovaBtn
            // 
            this.gkbBuyanovaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gkbBuyanovaBtn.Location = new System.Drawing.Point(247, 142);
            this.gkbBuyanovaBtn.Name = "gkbBuyanovaBtn";
            this.gkbBuyanovaBtn.Size = new System.Drawing.Size(128, 23);
            this.gkbBuyanovaBtn.TabIndex = 5;
            this.gkbBuyanovaBtn.Text = "Открыть в MSWord";
            this.gkbBuyanovaBtn.UseVisualStyleBackColor = true;
            this.gkbBuyanovaBtn.Click += new System.EventHandler(this.gkbBuyanovaBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(321, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Пациента ожидают в ГКБ им. В.М. Буянова ДЗМ (ГКБ №12) к:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(338, 39);
            this.label7.TabIndex = 3;
            this.label7.Text = "Врачебную бригаду медицинской эвакуации (СМП)\r\n в ГКБ №67 им. Л.А.Ворохобова, в о" +
    "тделение кардиореанимации\r\n(корпус Б, 1 этаж, тел 8(495)530-33-86) ожидаем к ";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lrcBtn);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(384, 172);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ЛРЦ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lrcBtn
            // 
            this.lrcBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lrcBtn.Location = new System.Drawing.Point(244, 142);
            this.lrcBtn.Name = "lrcBtn";
            this.lrcBtn.Size = new System.Drawing.Size(128, 23);
            this.lrcBtn.TabIndex = 5;
            this.lrcBtn.Text = "Открыть в MSWord";
            this.lrcBtn.UseVisualStyleBackColor = true;
            this.lrcBtn.Click += new System.EventHandler(this.lrcBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(297, 26);
            this.label8.TabIndex = 4;
            this.label8.Text = "Пациента ожидают в ФГАУ Лечебно-реабилитационном \r\nцентре Минздрава к";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(338, 39);
            this.label9.TabIndex = 3;
            this.label9.Text = "Врачебную бригаду медицинской эвакуации (СМП)\r\n в ГКБ №67 им. Л.А.Ворохобова, в о" +
    "тделение кардиореанимации\r\n(корпус Б, 1 этаж, тел 8(495)530-33-86) ожидаем к ";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(384, 172);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "ГКБ 83";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(245, 142);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Открыть в MSWord";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(297, 39);
            this.label10.TabIndex = 7;
            this.label10.Text = "Пациента ожидают в ФНКЦ специализированных\r\n видов медицинской помощи и медицинск" +
    "их технологий \r\nФМБА России (ГКБ №83) к";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(338, 39);
            this.label11.TabIndex = 6;
            this.label11.Text = "Врачебную бригаду медицинской эвакуации (СМП)\r\n в ГКБ №67 им. Л.А.Ворохобова, в о" +
    "тделение кардиореанимации\r\n(корпус Б, 1 этаж, тел 8(495)530-33-86) ожидаем к ";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.mschBtn);
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(384, 172);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "МСЧ 60";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // mschBtn
            // 
            this.mschBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mschBtn.Location = new System.Drawing.Point(243, 142);
            this.mschBtn.Name = "mschBtn";
            this.mschBtn.Size = new System.Drawing.Size(128, 23);
            this.mschBtn.TabIndex = 8;
            this.mschBtn.Text = "Открыть в MSWord";
            this.mschBtn.UseVisualStyleBackColor = true;
            this.mschBtn.Click += new System.EventHandler(this.mschBtn_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(338, 39);
            this.label13.TabIndex = 6;
            this.label13.Text = "Врачебную бригаду медицинской эвакуации (СМП)\r\n в ГКБ №67 им. Л.А.Ворохобова, в о" +
    "тделение кардиореанимации\r\n(корпус Б, 1 этаж, тел 8(495)530-33-86) ожидаем к ";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.gkb52Btn);
            this.tabPage6.Controls.Add(this.label15);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(384, 172);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "ГКБ 52";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // gkb52Btn
            // 
            this.gkb52Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gkb52Btn.Location = new System.Drawing.Point(245, 142);
            this.gkb52Btn.Name = "gkb52Btn";
            this.gkb52Btn.Size = new System.Drawing.Size(128, 23);
            this.gkb52Btn.TabIndex = 8;
            this.gkb52Btn.Text = "Открыть в MSWord";
            this.gkb52Btn.UseVisualStyleBackColor = true;
            this.gkb52Btn.Click += new System.EventHandler(this.gkb52Btn_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(206, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Перевод запланирован на: ";
            // 
            // AmbulanceLetters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 211);
            this.Controls.Add(this.smpInfo);
            this.Controls.Add(this.gkbBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(664, 250);
            this.Name = "AmbulanceLetters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Письма для скорой";
            this.smpInfo.ResumeLayout(false);
            this.smpInfo.PerformLayout();
            this.gkbBtn.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox smpInfo;
        private System.Windows.Forms.ComboBox doctorsBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker toTime;
        private System.Windows.Forms.DateTimePicker fromTime;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl gkbBtn;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button gbUdinaBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button gkbBuyanovaBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button lrcBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button mschBtn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button gkb52Btn;
        private System.Windows.Forms.Label label15;
    }
}