namespace Cardiology.UI
{
    partial class UserFormTrombolizis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserFormTrombolizis));
            this.doctorOkrCB = new System.Windows.Forms.ComboBox();
            this.trombolizisPrintBtn = new System.Windows.Forms.Button();
            this.timeLbl = new System.Windows.Forms.Label();
            this.doctorLbl = new System.Windows.Forms.Label();
            this.dateCtrl = new System.Windows.Forms.DateTimePicker();
            this.timeCtrl = new System.Windows.Forms.DateTimePicker();
            this.dateLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // doctorOkrCB
            // 
            this.doctorOkrCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doctorOkrCB.FormattingEnabled = true;
            this.doctorOkrCB.Location = new System.Drawing.Point(117, 95);
            this.doctorOkrCB.Name = "doctorOkrCB";
            this.doctorOkrCB.Size = new System.Drawing.Size(240, 21);
            this.doctorOkrCB.TabIndex = 1;
            // 
            // trombolizisPrintBtn
            // 
            this.trombolizisPrintBtn.Location = new System.Drawing.Point(283, 25);
            this.trombolizisPrintBtn.Name = "trombolizisPrintBtn";
            this.trombolizisPrintBtn.Size = new System.Drawing.Size(75, 57);
            this.trombolizisPrintBtn.TabIndex = 2;
            this.trombolizisPrintBtn.Text = "MsWord";
            this.trombolizisPrintBtn.UseVisualStyleBackColor = true;
            this.trombolizisPrintBtn.Click += new System.EventHandler(this.trombolizisPrintBtn_Click);
            // 
            // timeLbl
            // 
            this.timeLbl.AutoSize = true;
            this.timeLbl.Location = new System.Drawing.Point(68, 69);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(43, 13);
            this.timeLbl.TabIndex = 3;
            this.timeLbl.Text = "Время:";
            // 
            // doctorLbl
            // 
            this.doctorLbl.AutoSize = true;
            this.doctorLbl.Location = new System.Drawing.Point(34, 103);
            this.doctorLbl.Name = "doctorLbl";
            this.doctorLbl.Size = new System.Drawing.Size(82, 13);
            this.doctorLbl.TabIndex = 4;
            this.doctorLbl.Text = "Лечащий врач:";
            // 
            // dateCtrl
            // 
            this.dateCtrl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateCtrl.Location = new System.Drawing.Point(117, 27);
            this.dateCtrl.Name = "dateCtrl";
            this.dateCtrl.Size = new System.Drawing.Size(159, 20);
            this.dateCtrl.TabIndex = 5;
            // 
            // timeCtrl
            // 
            this.timeCtrl.CustomFormat = "HH:mm tt";
            this.timeCtrl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeCtrl.Location = new System.Drawing.Point(117, 61);
            this.timeCtrl.Name = "timeCtrl";
            this.timeCtrl.ShowUpDown = true;
            this.timeCtrl.Size = new System.Drawing.Size(159, 20);
            this.timeCtrl.TabIndex = 6;
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Location = new System.Drawing.Point(75, 34);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(36, 13);
            this.dateLbl.TabIndex = 7;
            this.dateLbl.Text = "Дата:";
            // 
            // UserFormTrombolizis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 150);
            this.Controls.Add(this.dateLbl);
            this.Controls.Add(this.timeCtrl);
            this.Controls.Add(this.dateCtrl);
            this.Controls.Add(this.doctorLbl);
            this.Controls.Add(this.timeLbl);
            this.Controls.Add(this.trombolizisPrintBtn);
            this.Controls.Add(this.doctorOkrCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(399, 193);
            this.Name = "UserFormTrombolizis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Показания к тромболизису";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox doctorOkrCB;
        private System.Windows.Forms.Button trombolizisPrintBtn;
        private System.Windows.Forms.Label timeLbl;
        private System.Windows.Forms.Label doctorLbl;
        private System.Windows.Forms.DateTimePicker dateCtrl;
        private System.Windows.Forms.DateTimePicker timeCtrl;
        private System.Windows.Forms.Label dateLbl;
    }
}