namespace Cardiology
{
    partial class UserFromVena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserFromVena));
            this.dateGroupBox = new System.Windows.Forms.GroupBox();
            this.dateCtrl = new System.Windows.Forms.DateTimePicker();
            this.timeGroupBox = new System.Windows.Forms.GroupBox();
            this.timeCtrl = new System.Windows.Forms.DateTimePicker();
            this.doctorGroupBox = new System.Windows.Forms.GroupBox();
            this.doctorsBox = new System.Windows.Forms.ComboBox();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.openInWord = new System.Windows.Forms.Button();
            this.value8Lbl = new System.Windows.Forms.Label();
            this.columnTxt = new System.Windows.Forms.TextBox();
            this.value7Lbl = new System.Windows.Forms.Label();
            this.value6Lbl = new System.Windows.Forms.Label();
            this.tryNumTxt = new System.Windows.Forms.TextBox();
            this.value5Lbl = new System.Windows.Forms.Label();
            this.value4Lbl = new System.Windows.Forms.Label();
            this.veinTxt = new System.Windows.Forms.TextBox();
            this.value3Lbl = new System.Windows.Forms.Label();
            this.value2Lbl = new System.Windows.Forms.Label();
            this.value1Lbl = new System.Windows.Forms.Label();
            this.dateGroupBox.SuspendLayout();
            this.timeGroupBox.SuspendLayout();
            this.doctorGroupBox.SuspendLayout();
            this.infoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateGroupBox
            // 
            this.dateGroupBox.Controls.Add(this.dateCtrl);
            this.dateGroupBox.Location = new System.Drawing.Point(12, 12);
            this.dateGroupBox.Name = "dateGroupBox";
            this.dateGroupBox.Size = new System.Drawing.Size(211, 59);
            this.dateGroupBox.TabIndex = 0;
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
            // timeGroupBox
            // 
            this.timeGroupBox.Controls.Add(this.timeCtrl);
            this.timeGroupBox.Location = new System.Drawing.Point(12, 77);
            this.timeGroupBox.Name = "timeGroupBox";
            this.timeGroupBox.Size = new System.Drawing.Size(211, 59);
            this.timeGroupBox.TabIndex = 1;
            this.timeGroupBox.TabStop = false;
            this.timeGroupBox.Text = "Время";
            // 
            // timeCtrl
            // 
            this.timeCtrl.CustomFormat = "HH:mm tt";
            this.timeCtrl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeCtrl.Location = new System.Drawing.Point(6, 19);
            this.timeCtrl.Name = "timeCtrl";
            this.timeCtrl.ShowUpDown = true;
            this.timeCtrl.Size = new System.Drawing.Size(199, 20);
            this.timeCtrl.TabIndex = 0;
            // 
            // doctorGroupBox
            // 
            this.doctorGroupBox.Controls.Add(this.doctorsBox);
            this.doctorGroupBox.Location = new System.Drawing.Point(12, 142);
            this.doctorGroupBox.Name = "doctorGroupBox";
            this.doctorGroupBox.Size = new System.Drawing.Size(211, 59);
            this.doctorGroupBox.TabIndex = 2;
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
            // infoBox
            // 
            this.infoBox.Controls.Add(this.openInWord);
            this.infoBox.Controls.Add(this.value8Lbl);
            this.infoBox.Controls.Add(this.columnTxt);
            this.infoBox.Controls.Add(this.value7Lbl);
            this.infoBox.Controls.Add(this.value6Lbl);
            this.infoBox.Controls.Add(this.tryNumTxt);
            this.infoBox.Controls.Add(this.value5Lbl);
            this.infoBox.Controls.Add(this.value4Lbl);
            this.infoBox.Controls.Add(this.veinTxt);
            this.infoBox.Controls.Add(this.value3Lbl);
            this.infoBox.Controls.Add(this.value2Lbl);
            this.infoBox.Controls.Add(this.value1Lbl);
            this.infoBox.Location = new System.Drawing.Point(229, 12);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(485, 189);
            this.infoBox.TabIndex = 3;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Показания";
            // 
            // openInWord
            // 
            this.openInWord.Location = new System.Drawing.Point(404, 160);
            this.openInWord.Name = "openInWord";
            this.openInWord.Size = new System.Drawing.Size(75, 23);
            this.openInWord.TabIndex = 14;
            this.openInWord.Text = "8";
            this.openInWord.UseVisualStyleBackColor = true;
            this.openInWord.Click += new System.EventHandler(this.openInWord_Click);
            // 
            // value8Lbl
            // 
            this.value8Lbl.AutoSize = true;
            this.value8Lbl.Location = new System.Drawing.Point(213, 162);
            this.value8Lbl.Name = "value8Lbl";
            this.value8Lbl.Size = new System.Drawing.Size(106, 13);
            this.value8Lbl.TabIndex = 12;
            this.value8Lbl.Text = "см водного столба.";
            // 
            // columnTxt
            // 
            this.columnTxt.Location = new System.Drawing.Point(130, 158);
            this.columnTxt.Name = "columnTxt";
            this.columnTxt.Size = new System.Drawing.Size(73, 20);
            this.columnTxt.TabIndex = 11;
            // 
            // value7Lbl
            // 
            this.value7Lbl.AutoSize = true;
            this.value7Lbl.Location = new System.Drawing.Point(88, 163);
            this.value7Lbl.Name = "value7Lbl";
            this.value7Lbl.Size = new System.Drawing.Size(31, 13);
            this.value7Lbl.TabIndex = 10;
            this.value7Lbl.Text = "ЦВД";
            // 
            // value6Lbl
            // 
            this.value6Lbl.AutoSize = true;
            this.value6Lbl.Location = new System.Drawing.Point(210, 130);
            this.value6Lbl.Name = "value6Lbl";
            this.value6Lbl.Size = new System.Drawing.Size(53, 13);
            this.value6Lbl.TabIndex = 9;
            this.value6Lbl.Text = "попытки.";
            // 
            // tryNumTxt
            // 
            this.tryNumTxt.Location = new System.Drawing.Point(130, 127);
            this.tryNumTxt.Name = "tryNumTxt";
            this.tryNumTxt.Size = new System.Drawing.Size(73, 20);
            this.tryNumTxt.TabIndex = 8;
            // 
            // value5Lbl
            // 
            this.value5Lbl.AutoSize = true;
            this.value5Lbl.Location = new System.Drawing.Point(21, 130);
            this.value5Lbl.Name = "value5Lbl";
            this.value5Lbl.Size = new System.Drawing.Size(103, 13);
            this.value5Lbl.TabIndex = 7;
            this.value5Lbl.Text = "Сельдингера      с  ";
            // 
            // value4Lbl
            // 
            this.value4Lbl.AutoSize = true;
            this.value4Lbl.Location = new System.Drawing.Point(298, 96);
            this.value4Lbl.Name = "value4Lbl";
            this.value4Lbl.Size = new System.Drawing.Size(104, 13);
            this.value4Lbl.TabIndex = 6;
            this.value4Lbl.Text = " вена по методике ";
            // 
            // veinTxt
            // 
            this.veinTxt.Location = new System.Drawing.Point(125, 93);
            this.veinTxt.Name = "veinTxt";
            this.veinTxt.Size = new System.Drawing.Size(167, 20);
            this.veinTxt.TabIndex = 4;
            // 
            // value3Lbl
            // 
            this.value3Lbl.AutoSize = true;
            this.value3Lbl.Location = new System.Drawing.Point(18, 96);
            this.value3Lbl.Name = "value3Lbl";
            this.value3Lbl.Size = new System.Drawing.Size(101, 13);
            this.value3Lbl.TabIndex = 2;
            this.value3Lbl.Text = "катетеризирована";
            // 
            // value2Lbl
            // 
            this.value2Lbl.AutoSize = true;
            this.value2Lbl.Location = new System.Drawing.Point(18, 65);
            this.value2Lbl.Name = "value2Lbl";
            this.value2Lbl.Size = new System.Drawing.Size(417, 13);
            this.value2Lbl.TabIndex = 1;
            this.value2Lbl.Text = "условиях, под местной анестезией Sol. Novocaini 0, 25 % - 10 ml, пунктирована и ";
            // 
            // value1Lbl
            // 
            this.value1Lbl.AutoSize = true;
            this.value1Lbl.Location = new System.Drawing.Point(15, 36);
            this.value1Lbl.Name = "value1Lbl";
            this.value1Lbl.Size = new System.Drawing.Size(464, 13);
            this.value1Lbl.TabIndex = 0;
            this.value1Lbl.Text = "С целью контроля ЦВД и проведения интенсивной инфузионной терапии в асептических " +
    "";
            // 
            // UserFromVena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 217);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.doctorGroupBox);
            this.Controls.Add(this.timeGroupBox);
            this.Controls.Add(this.dateGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserFromVena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Катетеризация подключичной, яремной  вены";
            this.dateGroupBox.ResumeLayout(false);
            this.timeGroupBox.ResumeLayout(false);
            this.doctorGroupBox.ResumeLayout(false);
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox dateGroupBox;
        private System.Windows.Forms.DateTimePicker dateCtrl;
        private System.Windows.Forms.GroupBox timeGroupBox;
        private System.Windows.Forms.DateTimePicker timeCtrl;
        private System.Windows.Forms.GroupBox doctorGroupBox;
        private System.Windows.Forms.ComboBox doctorsBox;
        private System.Windows.Forms.GroupBox infoBox;
        private System.Windows.Forms.Button openInWord;
        private System.Windows.Forms.Label value8Lbl;
        private System.Windows.Forms.TextBox columnTxt;
        private System.Windows.Forms.Label value7Lbl;
        private System.Windows.Forms.Label value6Lbl;
        private System.Windows.Forms.TextBox tryNumTxt;
        private System.Windows.Forms.Label value5Lbl;
        private System.Windows.Forms.Label value4Lbl;
        private System.Windows.Forms.TextBox veinTxt;
        private System.Windows.Forms.Label value3Lbl;
        private System.Windows.Forms.Label value2Lbl;
        private System.Windows.Forms.Label value1Lbl;
    }
}