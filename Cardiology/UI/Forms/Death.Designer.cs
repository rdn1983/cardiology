namespace Cardiology.UI.Forms
{
    partial class Death
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Death));
            this.deadDateLbl = new System.Windows.Forms.Label();
            this.deathDateTxt = new System.Windows.Forms.DateTimePicker();
            this.deathTimeCtrl = new System.Windows.Forms.DateTimePicker();
            this.docLbl = new System.Windows.Forms.Label();
            this.doctorsBox = new System.Windows.Forms.ComboBox();
            this.openDeathWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deadDateLbl
            // 
            this.deadDateLbl.AutoSize = true;
            this.deadDateLbl.Location = new System.Drawing.Point(12, 9);
            this.deadDateLbl.Name = "deadDateLbl";
            this.deadDateLbl.Size = new System.Drawing.Size(112, 13);
            this.deadDateLbl.TabIndex = 1;
            this.deadDateLbl.Text = "Констатация смерти";
            // 
            // deathDateTxt
            // 
            this.deathDateTxt.Location = new System.Drawing.Point(12, 25);
            this.deathDateTxt.Name = "deathDateTxt";
            this.deathDateTxt.Size = new System.Drawing.Size(119, 20);
            this.deathDateTxt.TabIndex = 7;
            // 
            // deathTimeCtrl
            // 
            this.deathTimeCtrl.CustomFormat = "HH:mm tt";
            this.deathTimeCtrl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.deathTimeCtrl.Location = new System.Drawing.Point(137, 25);
            this.deathTimeCtrl.Name = "deathTimeCtrl";
            this.deathTimeCtrl.ShowUpDown = true;
            this.deathTimeCtrl.Size = new System.Drawing.Size(113, 20);
            this.deathTimeCtrl.TabIndex = 8;
            // 
            // docLbl
            // 
            this.docLbl.AutoSize = true;
            this.docLbl.Location = new System.Drawing.Point(9, 59);
            this.docLbl.Name = "docLbl";
            this.docLbl.Size = new System.Drawing.Size(34, 13);
            this.docLbl.TabIndex = 9;
            this.docLbl.Text = "Врач:";
            // 
            // doctorsBox
            // 
            this.doctorsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doctorsBox.FormattingEnabled = true;
            this.doctorsBox.Location = new System.Drawing.Point(12, 75);
            this.doctorsBox.Name = "doctorsBox";
            this.doctorsBox.Size = new System.Drawing.Size(238, 21);
            this.doctorsBox.TabIndex = 10;
            // 
            // openDeathWord
            // 
            this.openDeathWord.Location = new System.Drawing.Point(12, 102);
            this.openDeathWord.Name = "openDeathWord";
            this.openDeathWord.Size = new System.Drawing.Size(238, 23);
            this.openDeathWord.TabIndex = 11;
            this.openDeathWord.Text = "Открыть КОНСТАТАЦИЯ в Word";
            this.openDeathWord.UseVisualStyleBackColor = true;
            this.openDeathWord.Click += new System.EventHandler(this.OpenDeathProtocol);
            // 
            // Death
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 133);
            this.Controls.Add(this.openDeathWord);
            this.Controls.Add(this.doctorsBox);
            this.Controls.Add(this.docLbl);
            this.Controls.Add(this.deathTimeCtrl);
            this.Controls.Add(this.deathDateTxt);
            this.Controls.Add(this.deadDateLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(286, 222);
            this.Name = "Death";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Констатация смерти";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deadDateLbl;
        private System.Windows.Forms.DateTimePicker deathDateTxt;
        private System.Windows.Forms.DateTimePicker deathTimeCtrl;
        private System.Windows.Forms.Label docLbl;
        private System.Windows.Forms.ComboBox doctorsBox;
        private System.Windows.Forms.Button openDeathWord;
    }
}