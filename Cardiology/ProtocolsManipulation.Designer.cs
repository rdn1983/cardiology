namespace Cardiology
{
    partial class ProtocolsManipulation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtocolsManipulation));
            this.doctorGroupBox = new System.Windows.Forms.GroupBox();
            this.doctorsBox = new System.Windows.Forms.ComboBox();
            this.timeGroupBox = new System.Windows.Forms.GroupBox();
            this.timeCtrl = new System.Windows.Forms.DateTimePicker();
            this.dateGroupBox = new System.Windows.Forms.GroupBox();
            this.dateCtrl = new System.Windows.Forms.DateTimePicker();
            this.veinsKateterInfo = new System.Windows.Forms.GroupBox();
            this.openInWord = new System.Windows.Forms.Button();
            this.value8Lbl = new System.Windows.Forms.Label();
            this.columnTxt = new System.Windows.Forms.TextBox();
            this.value7Lbl = new System.Windows.Forms.Label();
            this.value6Lbl = new System.Windows.Forms.Label();
            this.tryNumTxt = new System.Windows.Forms.TextBox();
            this.value4Lbl = new System.Windows.Forms.Label();
            this.veinTxt = new System.Windows.Forms.TextBox();
            this.value3Lbl = new System.Windows.Forms.Label();
            this.value2Lbl = new System.Windows.Forms.Label();
            this.value1Lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.doctorGroupBox.SuspendLayout();
            this.timeGroupBox.SuspendLayout();
            this.dateGroupBox.SuspendLayout();
            this.veinsKateterInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // doctorGroupBox
            // 
            this.doctorGroupBox.Controls.Add(this.doctorsBox);
            this.doctorGroupBox.Location = new System.Drawing.Point(3, 140);
            this.doctorGroupBox.Name = "doctorGroupBox";
            this.doctorGroupBox.Size = new System.Drawing.Size(211, 51);
            this.doctorGroupBox.TabIndex = 5;
            this.doctorGroupBox.TabStop = false;
            this.doctorGroupBox.Text = "Врач";
            // 
            // doctorsBox
            // 
            this.doctorsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doctorsBox.FormattingEnabled = true;
            this.doctorsBox.Location = new System.Drawing.Point(6, 19);
            this.doctorsBox.Name = "doctorsBox";
            this.doctorsBox.Size = new System.Drawing.Size(199, 21);
            this.doctorsBox.TabIndex = 0;
            // 
            // timeGroupBox
            // 
            this.timeGroupBox.Controls.Add(this.timeCtrl);
            this.timeGroupBox.Location = new System.Drawing.Point(3, 88);
            this.timeGroupBox.Name = "timeGroupBox";
            this.timeGroupBox.Size = new System.Drawing.Size(211, 50);
            this.timeGroupBox.TabIndex = 4;
            this.timeGroupBox.TabStop = false;
            this.timeGroupBox.Text = "Время";
            // 
            // timeCtrl
            // 
            this.timeCtrl.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeCtrl.Location = new System.Drawing.Point(6, 19);
            this.timeCtrl.Name = "timeCtrl";
            this.timeCtrl.Size = new System.Drawing.Size(199, 20);
            this.timeCtrl.TabIndex = 0;
            // 
            // dateGroupBox
            // 
            this.dateGroupBox.Controls.Add(this.dateCtrl);
            this.dateGroupBox.Location = new System.Drawing.Point(3, 36);
            this.dateGroupBox.Name = "dateGroupBox";
            this.dateGroupBox.Size = new System.Drawing.Size(211, 51);
            this.dateGroupBox.TabIndex = 3;
            this.dateGroupBox.TabStop = false;
            this.dateGroupBox.Text = "Дата";
            // 
            // dateCtrl
            // 
            this.dateCtrl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateCtrl.Location = new System.Drawing.Point(6, 19);
            this.dateCtrl.Name = "dateCtrl";
            this.dateCtrl.Size = new System.Drawing.Size(199, 20);
            this.dateCtrl.TabIndex = 0;
            // 
            // veinsKateterInfo
            // 
            this.veinsKateterInfo.Controls.Add(this.label1);
            this.veinsKateterInfo.Controls.Add(this.value8Lbl);
            this.veinsKateterInfo.Controls.Add(this.columnTxt);
            this.veinsKateterInfo.Controls.Add(this.value7Lbl);
            this.veinsKateterInfo.Controls.Add(this.value6Lbl);
            this.veinsKateterInfo.Controls.Add(this.tryNumTxt);
            this.veinsKateterInfo.Controls.Add(this.value4Lbl);
            this.veinsKateterInfo.Controls.Add(this.veinTxt);
            this.veinsKateterInfo.Controls.Add(this.value3Lbl);
            this.veinsKateterInfo.Controls.Add(this.value2Lbl);
            this.veinsKateterInfo.Controls.Add(this.value1Lbl);
            this.veinsKateterInfo.Location = new System.Drawing.Point(220, 36);
            this.veinsKateterInfo.Name = "veinsKateterInfo";
            this.veinsKateterInfo.Size = new System.Drawing.Size(342, 195);
            this.veinsKateterInfo.TabIndex = 6;
            this.veinsKateterInfo.TabStop = false;
            this.veinsKateterInfo.Text = "Показания";
            this.veinsKateterInfo.Visible = false;
            // 
            // openInWord
            // 
            this.openInWord.Location = new System.Drawing.Point(3, 208);
            this.openInWord.Name = "openInWord";
            this.openInWord.Size = new System.Drawing.Size(211, 23);
            this.openInWord.TabIndex = 14;
            this.openInWord.Text = "MsWord";
            this.openInWord.UseVisualStyleBackColor = true;
            this.openInWord.Click += new System.EventHandler(this.openInWord_Click);
            // 
            // value8Lbl
            // 
            this.value8Lbl.AutoSize = true;
            this.value8Lbl.Location = new System.Drawing.Point(126, 162);
            this.value8Lbl.Name = "value8Lbl";
            this.value8Lbl.Size = new System.Drawing.Size(106, 13);
            this.value8Lbl.TabIndex = 12;
            this.value8Lbl.Text = "см водного столба.";
            // 
            // columnTxt
            // 
            this.columnTxt.Location = new System.Drawing.Point(47, 155);
            this.columnTxt.Name = "columnTxt";
            this.columnTxt.Size = new System.Drawing.Size(73, 20);
            this.columnTxt.TabIndex = 11;
            // 
            // value7Lbl
            // 
            this.value7Lbl.AutoSize = true;
            this.value7Lbl.Location = new System.Drawing.Point(10, 162);
            this.value7Lbl.Name = "value7Lbl";
            this.value7Lbl.Size = new System.Drawing.Size(31, 13);
            this.value7Lbl.TabIndex = 10;
            this.value7Lbl.Text = "ЦВД";
            // 
            // value6Lbl
            // 
            this.value6Lbl.AutoSize = true;
            this.value6Lbl.Location = new System.Drawing.Point(258, 133);
            this.value6Lbl.Name = "value6Lbl";
            this.value6Lbl.Size = new System.Drawing.Size(53, 13);
            this.value6Lbl.TabIndex = 9;
            this.value6Lbl.Text = "попытки.";
            // 
            // tryNumTxt
            // 
            this.tryNumTxt.Location = new System.Drawing.Point(189, 128);
            this.tryNumTxt.Name = "tryNumTxt";
            this.tryNumTxt.Size = new System.Drawing.Size(63, 20);
            this.tryNumTxt.TabIndex = 8;
            // 
            // value4Lbl
            // 
            this.value4Lbl.AutoSize = true;
            this.value4Lbl.Location = new System.Drawing.Point(7, 133);
            this.value4Lbl.Name = "value4Lbl";
            this.value4Lbl.Size = new System.Drawing.Size(179, 13);
            this.value4Lbl.TabIndex = 6;
            this.value4Lbl.Text = " вена по методике Сельдингера с";
            // 
            // veinTxt
            // 
            this.veinTxt.Location = new System.Drawing.Point(193, 99);
            this.veinTxt.Name = "veinTxt";
            this.veinTxt.Size = new System.Drawing.Size(131, 20);
            this.veinTxt.TabIndex = 4;
            // 
            // value3Lbl
            // 
            this.value3Lbl.AutoSize = true;
            this.value3Lbl.Location = new System.Drawing.Point(10, 106);
            this.value3Lbl.Name = "value3Lbl";
            this.value3Lbl.Size = new System.Drawing.Size(183, 13);
            this.value3Lbl.TabIndex = 2;
            this.value3Lbl.Text = "пунктирована и катетеризирована";
            // 
            // value2Lbl
            // 
            this.value2Lbl.AutoSize = true;
            this.value2Lbl.Location = new System.Drawing.Point(8, 80);
            this.value2Lbl.Name = "value2Lbl";
            this.value2Lbl.Size = new System.Drawing.Size(286, 13);
            this.value2Lbl.TabIndex = 1;
            this.value2Lbl.Text = " под местной анестезией Sol. Novocaini 0, 25 % - 10 ml, ";
            // 
            // value1Lbl
            // 
            this.value1Lbl.AutoSize = true;
            this.value1Lbl.Location = new System.Drawing.Point(10, 28);
            this.value1Lbl.Name = "value1Lbl";
            this.value1Lbl.Size = new System.Drawing.Size(266, 13);
            this.value1Lbl.TabIndex = 0;
            this.value1Lbl.Text = "С целью контроля ЦВД и проведения интенсивной";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = " инфузионной терапии в асептических условиях,";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Location = new System.Drawing.Point(9, 13);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(0, 13);
            this.titleLbl.TabIndex = 15;
            // 
            // ProtocolsManipulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 242);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.veinsKateterInfo);
            this.Controls.Add(this.openInWord);
            this.Controls.Add(this.doctorGroupBox);
            this.Controls.Add(this.timeGroupBox);
            this.Controls.Add(this.dateGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProtocolsManipulation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Протоколы манипуляций";
            this.doctorGroupBox.ResumeLayout(false);
            this.timeGroupBox.ResumeLayout(false);
            this.dateGroupBox.ResumeLayout(false);
            this.veinsKateterInfo.ResumeLayout(false);
            this.veinsKateterInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox doctorGroupBox;
        private System.Windows.Forms.ComboBox doctorsBox;
        private System.Windows.Forms.GroupBox timeGroupBox;
        private System.Windows.Forms.DateTimePicker timeCtrl;
        private System.Windows.Forms.GroupBox dateGroupBox;
        private System.Windows.Forms.DateTimePicker dateCtrl;
        private System.Windows.Forms.GroupBox veinsKateterInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label value8Lbl;
        private System.Windows.Forms.TextBox columnTxt;
        private System.Windows.Forms.Label value7Lbl;
        private System.Windows.Forms.Label value6Lbl;
        private System.Windows.Forms.TextBox tryNumTxt;
        private System.Windows.Forms.Label value4Lbl;
        private System.Windows.Forms.TextBox veinTxt;
        private System.Windows.Forms.Label value3Lbl;
        private System.Windows.Forms.Label value2Lbl;
        private System.Windows.Forms.Label value1Lbl;
        private System.Windows.Forms.Button openInWord;
        private System.Windows.Forms.Label titleLbl;
    }
}