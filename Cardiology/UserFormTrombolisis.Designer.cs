namespace Cardiology
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
            this.dateBtn = new System.Windows.Forms.Button();
            this.doctorOkrCB = new System.Windows.Forms.ComboBox();
            this.trombolizisPrintBtn = new System.Windows.Forms.Button();
            this.timeLbl = new System.Windows.Forms.Label();
            this.doctorLbl = new System.Windows.Forms.Label();
            this.dateTx = new System.Windows.Forms.TextBox();
            this.timeTx = new System.Windows.Forms.TextBox();
            this.timeTx2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dateBtn
            // 
            this.dateBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dateBtn.Location = new System.Drawing.Point(36, 25);
            this.dateBtn.Name = "dateBtn";
            this.dateBtn.Size = new System.Drawing.Size(75, 23);
            this.dateBtn.TabIndex = 0;
            this.dateBtn.Text = "Дата: (Сегодня)";
            this.dateBtn.UseVisualStyleBackColor = true;
            // 
            // doctorOkrCB
            // 
            this.doctorOkrCB.FormattingEnabled = true;
            this.doctorOkrCB.Location = new System.Drawing.Point(133, 95);
            this.doctorOkrCB.Name = "doctorOkrCB";
            this.doctorOkrCB.Size = new System.Drawing.Size(240, 21);
            this.doctorOkrCB.TabIndex = 1;
            // 
            // trombolizisPrintBtn
            // 
            this.trombolizisPrintBtn.Location = new System.Drawing.Point(298, 25);
            this.trombolizisPrintBtn.Name = "trombolizisPrintBtn";
            this.trombolizisPrintBtn.Size = new System.Drawing.Size(75, 57);
            this.trombolizisPrintBtn.TabIndex = 2;
            this.trombolizisPrintBtn.Text = "в ворд";
            this.trombolizisPrintBtn.UseVisualStyleBackColor = true;
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
            // dateTx
            // 
            this.dateTx.Location = new System.Drawing.Point(133, 28);
            this.dateTx.Name = "dateTx";
            this.dateTx.Size = new System.Drawing.Size(145, 20);
            this.dateTx.TabIndex = 5;
            // 
            // timeTx
            // 
            this.timeTx.Location = new System.Drawing.Point(133, 62);
            this.timeTx.Name = "timeTx";
            this.timeTx.Size = new System.Drawing.Size(78, 20);
            this.timeTx.TabIndex = 6;
            // 
            // timeTx2
            // 
            this.timeTx2.Location = new System.Drawing.Point(217, 62);
            this.timeTx2.Name = "timeTx2";
            this.timeTx2.Size = new System.Drawing.Size(61, 20);
            this.timeTx2.TabIndex = 7;
            // 
            // UserFormTrombolizis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 165);
            this.Controls.Add(this.timeTx2);
            this.Controls.Add(this.timeTx);
            this.Controls.Add(this.dateTx);
            this.Controls.Add(this.doctorLbl);
            this.Controls.Add(this.timeLbl);
            this.Controls.Add(this.trombolizisPrintBtn);
            this.Controls.Add(this.doctorOkrCB);
            this.Controls.Add(this.dateBtn);
            this.Name = "UserFormTrombolizis";
            this.Text = "Показания к тромболизису:";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dateBtn;
        private System.Windows.Forms.ComboBox doctorOkrCB;
        private System.Windows.Forms.Button trombolizisPrintBtn;
        private System.Windows.Forms.Label timeLbl;
        private System.Windows.Forms.Label doctorLbl;
        private System.Windows.Forms.TextBox dateTx;
        private System.Windows.Forms.TextBox timeTx;
        private System.Windows.Forms.TextBox timeTx2;
    }
}