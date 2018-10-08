namespace Cardiology
{
    partial class ReanimDEAD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReanimDEAD));
            this.deadDateLbl = new System.Windows.Forms.Label();
            this.deathTimeCtrl = new System.Windows.Forms.DateTimePicker();
            this.reanimOperationBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.docLbl = new System.Windows.Forms.Label();
            this.doctorsBox = new System.Windows.Forms.ComboBox();
            this.deathDateTxt = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // deadDateLbl
            // 
            this.deadDateLbl.AutoSize = true;
            this.deadDateLbl.Location = new System.Drawing.Point(13, 13);
            this.deadDateLbl.Name = "deadDateLbl";
            this.deadDateLbl.Size = new System.Drawing.Size(112, 13);
            this.deadDateLbl.TabIndex = 0;
            this.deadDateLbl.Text = "Констатация смерти";
            // 
            // deathTimeCtrl
            // 
            this.deathTimeCtrl.CustomFormat = "HH:mm tt";
            this.deathTimeCtrl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.deathTimeCtrl.Location = new System.Drawing.Point(141, 29);
            this.deathTimeCtrl.Name = "deathTimeCtrl";
            this.deathTimeCtrl.ShowUpDown = true;
            this.deathTimeCtrl.Size = new System.Drawing.Size(113, 20);
            this.deathTimeCtrl.TabIndex = 1;
            // 
            // reanimOperationBtn
            // 
            this.reanimOperationBtn.Location = new System.Drawing.Point(16, 102);
            this.reanimOperationBtn.Name = "reanimOperationBtn";
            this.reanimOperationBtn.Size = new System.Drawing.Size(238, 23);
            this.reanimOperationBtn.TabIndex = 2;
            this.reanimOperationBtn.Text = "Открыть МЕРОПРИЯТИЯ в Word";
            this.reanimOperationBtn.UseVisualStyleBackColor = true;
            this.reanimOperationBtn.Click += new System.EventHandler(this.reanimOperationBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(238, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Открыть КОНСТАТАЦИЯ в Word";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // docLbl
            // 
            this.docLbl.AutoSize = true;
            this.docLbl.Location = new System.Drawing.Point(16, 56);
            this.docLbl.Name = "docLbl";
            this.docLbl.Size = new System.Drawing.Size(34, 13);
            this.docLbl.TabIndex = 4;
            this.docLbl.Text = "Врач:";
            // 
            // doctorsBox
            // 
            this.doctorsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doctorsBox.FormattingEnabled = true;
            this.doctorsBox.Location = new System.Drawing.Point(16, 75);
            this.doctorsBox.Name = "doctorsBox";
            this.doctorsBox.Size = new System.Drawing.Size(238, 21);
            this.doctorsBox.TabIndex = 5;
            // 
            // deathDateTxt
            // 
            this.deathDateTxt.Location = new System.Drawing.Point(16, 29);
            this.deathDateTxt.Name = "deathDateTxt";
            this.deathDateTxt.Size = new System.Drawing.Size(119, 20);
            this.deathDateTxt.TabIndex = 6;
            // 
            // ReanimDEAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 179);
            this.Controls.Add(this.deathDateTxt);
            this.Controls.Add(this.doctorsBox);
            this.Controls.Add(this.docLbl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.reanimOperationBtn);
            this.Controls.Add(this.deathTimeCtrl);
            this.Controls.Add(this.deadDateLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(286, 222);
            this.Name = "ReanimDEAD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Реанимационные мероприятия";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deadDateLbl;
        private System.Windows.Forms.DateTimePicker deathTimeCtrl;
        private System.Windows.Forms.Button reanimOperationBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label docLbl;
        private System.Windows.Forms.ComboBox doctorsBox;
        private System.Windows.Forms.DateTimePicker deathDateTxt;
    }
}