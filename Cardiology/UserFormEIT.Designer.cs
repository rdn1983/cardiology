namespace Cardiology
{
    partial class UserFormEIT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserFormEIT));
            this.bodyArea = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.doctorsBox = new System.Windows.Forms.ComboBox();
            this.printBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bodyArea
            // 
            this.bodyArea.Location = new System.Drawing.Point(12, 12);
            this.bodyArea.Name = "bodyArea";
            this.bodyArea.Size = new System.Drawing.Size(532, 96);
            this.bodyArea.TabIndex = 0;
            this.bodyArea.Text = resources.GetString("bodyArea.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Лечащий врач:";
            // 
            // doctorsBox
            // 
            this.doctorsBox.FormattingEnabled = true;
            this.doctorsBox.Location = new System.Drawing.Point(102, 115);
            this.doctorsBox.Name = "doctorsBox";
            this.doctorsBox.Size = new System.Drawing.Size(220, 21);
            this.doctorsBox.TabIndex = 2;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(415, 113);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(129, 23);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "MsWord";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // UserFormEIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 146);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.doctorsBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bodyArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserFormEIT";
            this.Text = "Протокол ЭИТ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox bodyArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox doctorsBox;
        private System.Windows.Forms.Button printBtn;
    }
}