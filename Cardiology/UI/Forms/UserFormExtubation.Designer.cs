namespace Cardiology.UI.Forms
{
    partial class UserFormExtubation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserFormExtubation));
            this.headerArea = new System.Windows.Forms.RichTextBox();
            this.bodyArea = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.doctorsBox = new System.Windows.Forms.ComboBox();
            this.printBtn = new System.Windows.Forms.Button();
            this.timeCtrl = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerArea
            // 
            this.headerArea.Location = new System.Drawing.Point(16, 47);
            this.headerArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.headerArea.Name = "headerArea";
            this.headerArea.Size = new System.Drawing.Size(635, 117);
            this.headerArea.TabIndex = 2;
            this.headerArea.Text = resources.GetString("headerArea.Text");
            // 
            // bodyArea
            // 
            this.bodyArea.Location = new System.Drawing.Point(16, 172);
            this.bodyArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bodyArea.Name = "bodyArea";
            this.bodyArea.Size = new System.Drawing.Size(635, 208);
            this.bodyArea.TabIndex = 3;
            this.bodyArea.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 390);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Врач:";
            // 
            // doctorsBox
            // 
            this.doctorsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doctorsBox.FormattingEnabled = true;
            this.doctorsBox.Location = new System.Drawing.Point(72, 390);
            this.doctorsBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.doctorsBox.Name = "doctorsBox";
            this.doctorsBox.Size = new System.Drawing.Size(272, 24);
            this.doctorsBox.TabIndex = 5;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(444, 386);
            this.printBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(207, 28);
            this.printBtn.TabIndex = 6;
            this.printBtn.Text = "MsWord";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // timeCtrl
            // 
            this.timeCtrl.CustomFormat = "HH:mm tt";
            this.timeCtrl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeCtrl.Location = new System.Drawing.Point(72, 15);
            this.timeCtrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeCtrl.Name = "timeCtrl";
            this.timeCtrl.ShowUpDown = true;
            this.timeCtrl.Size = new System.Drawing.Size(108, 22);
            this.timeCtrl.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Время:";
            // 
            // UserFormExtubation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 417);
            this.Controls.Add(this.timeCtrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.doctorsBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bodyArea);
            this.Controls.Add(this.headerArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(687, 468);
            this.Name = "UserFormExtubation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Экстубация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox headerArea;
        private System.Windows.Forms.RichTextBox bodyArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox doctorsBox;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.DateTimePicker timeCtrl;
        private System.Windows.Forms.Label label3;
    }
}