namespace Cardiology
{
    partial class Serology
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Serology));
            this.bloodTypeLbl = new System.Windows.Forms.Label();
            this.bloodTypeBox = new System.Windows.Forms.ComboBox();
            this.rhesusFactorBox = new System.Windows.Forms.ComboBox();
            this.rhesusFactorLbl = new System.Windows.Forms.Label();
            this.kellAgBox = new System.Windows.Forms.ComboBox();
            this.kellAgLbl = new System.Windows.Forms.Label();
            this.phenotypeLbl = new System.Windows.Forms.Label();
            this.phenotypeTxt = new System.Windows.Forms.RichTextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.serologyBox = new System.Windows.Forms.GroupBox();
            this.hivBox = new System.Windows.Forms.ComboBox();
            this.hivLbl = new System.Windows.Forms.Label();
            this.antiHcvBox = new System.Windows.Forms.ComboBox();
            this.antiHsvLbl = new System.Windows.Forms.Label();
            this.hbsAgBox = new System.Windows.Forms.ComboBox();
            this.hbsAgLbl = new System.Windows.Forms.Label();
            this.rwBox = new System.Windows.Forms.ComboBox();
            this.rwLbl = new System.Windows.Forms.Label();
            this.serologyBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // bloodTypeLbl
            // 
            this.bloodTypeLbl.AutoSize = true;
            this.bloodTypeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bloodTypeLbl.Location = new System.Drawing.Point(13, 11);
            this.bloodTypeLbl.Name = "bloodTypeLbl";
            this.bloodTypeLbl.Size = new System.Drawing.Size(114, 17);
            this.bloodTypeLbl.TabIndex = 0;
            this.bloodTypeLbl.Text = "Группа крови:";
            // 
            // bloodTypeBox
            // 
            this.bloodTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bloodTypeBox.Location = new System.Drawing.Point(15, 28);
            this.bloodTypeBox.Name = "bloodTypeBox";
            this.bloodTypeBox.Size = new System.Drawing.Size(164, 21);
            this.bloodTypeBox.TabIndex = 1;
            // 
            // rhesusFactorBox
            // 
            this.rhesusFactorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rhesusFactorBox.FormattingEnabled = true;
            this.rhesusFactorBox.Location = new System.Drawing.Point(15, 75);
            this.rhesusFactorBox.Name = "rhesusFactorBox";
            this.rhesusFactorBox.Size = new System.Drawing.Size(164, 21);
            this.rhesusFactorBox.TabIndex = 3;
            // 
            // rhesusFactorLbl
            // 
            this.rhesusFactorLbl.AutoSize = true;
            this.rhesusFactorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rhesusFactorLbl.Location = new System.Drawing.Point(13, 55);
            this.rhesusFactorLbl.Name = "rhesusFactorLbl";
            this.rhesusFactorLbl.Size = new System.Drawing.Size(116, 17);
            this.rhesusFactorLbl.TabIndex = 2;
            this.rhesusFactorLbl.Text = "Резус фактор:";
            // 
            // kellAgBox
            // 
            this.kellAgBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kellAgBox.FormattingEnabled = true;
            this.kellAgBox.Location = new System.Drawing.Point(15, 126);
            this.kellAgBox.Name = "kellAgBox";
            this.kellAgBox.Size = new System.Drawing.Size(164, 21);
            this.kellAgBox.TabIndex = 5;
            // 
            // kellAgLbl
            // 
            this.kellAgLbl.AutoSize = true;
            this.kellAgLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kellAgLbl.Location = new System.Drawing.Point(13, 106);
            this.kellAgLbl.Name = "kellAgLbl";
            this.kellAgLbl.Size = new System.Drawing.Size(75, 17);
            this.kellAgLbl.TabIndex = 4;
            this.kellAgLbl.Text = "KELL-ag:";
            // 
            // phenotypeLbl
            // 
            this.phenotypeLbl.AutoSize = true;
            this.phenotypeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phenotypeLbl.Location = new System.Drawing.Point(191, 11);
            this.phenotypeLbl.Name = "phenotypeLbl";
            this.phenotypeLbl.Size = new System.Drawing.Size(80, 17);
            this.phenotypeLbl.TabIndex = 6;
            this.phenotypeLbl.Text = "Фенотип:";
            // 
            // phenotypeTxt
            // 
            this.phenotypeTxt.Location = new System.Drawing.Point(194, 31);
            this.phenotypeTxt.Name = "phenotypeTxt";
            this.phenotypeTxt.Size = new System.Drawing.Size(163, 116);
            this.phenotypeTxt.TabIndex = 7;
            this.phenotypeTxt.Text = "";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(250, 324);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(107, 27);
            this.saveBtn.TabIndex = 9;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // serologyBox
            // 
            this.serologyBox.Controls.Add(this.hivBox);
            this.serologyBox.Controls.Add(this.hivLbl);
            this.serologyBox.Controls.Add(this.antiHcvBox);
            this.serologyBox.Controls.Add(this.antiHsvLbl);
            this.serologyBox.Controls.Add(this.hbsAgBox);
            this.serologyBox.Controls.Add(this.hbsAgLbl);
            this.serologyBox.Controls.Add(this.rwBox);
            this.serologyBox.Controls.Add(this.rwLbl);
            this.serologyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serologyBox.Location = new System.Drawing.Point(15, 163);
            this.serologyBox.Name = "serologyBox";
            this.serologyBox.Size = new System.Drawing.Size(342, 155);
            this.serologyBox.TabIndex = 10;
            this.serologyBox.TabStop = false;
            this.serologyBox.Text = "Серология";
            // 
            // hivBox
            // 
            this.hivBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hivBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hivBox.FormattingEnabled = true;
            this.hivBox.Location = new System.Drawing.Point(72, 113);
            this.hivBox.Name = "hivBox";
            this.hivBox.Size = new System.Drawing.Size(228, 21);
            this.hivBox.TabIndex = 7;
            // 
            // hivLbl
            // 
            this.hivLbl.AutoSize = true;
            this.hivLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hivLbl.Location = new System.Drawing.Point(10, 118);
            this.hivLbl.Name = "hivLbl";
            this.hivLbl.Size = new System.Drawing.Size(25, 13);
            this.hivLbl.TabIndex = 6;
            this.hivLbl.Text = "HIV";
            // 
            // antiHcvBox
            // 
            this.antiHcvBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.antiHcvBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.antiHcvBox.FormattingEnabled = true;
            this.antiHcvBox.Location = new System.Drawing.Point(72, 83);
            this.antiHcvBox.Name = "antiHcvBox";
            this.antiHcvBox.Size = new System.Drawing.Size(228, 21);
            this.antiHcvBox.TabIndex = 5;
            // 
            // antiHsvLbl
            // 
            this.antiHsvLbl.AutoSize = true;
            this.antiHsvLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.antiHsvLbl.Location = new System.Drawing.Point(6, 88);
            this.antiHsvLbl.Name = "antiHsvLbl";
            this.antiHsvLbl.Size = new System.Drawing.Size(56, 13);
            this.antiHsvLbl.TabIndex = 4;
            this.antiHsvLbl.Text = "Анти HCV";
            // 
            // hbsAgBox
            // 
            this.hbsAgBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hbsAgBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hbsAgBox.FormattingEnabled = true;
            this.hbsAgBox.Location = new System.Drawing.Point(72, 53);
            this.hbsAgBox.Name = "hbsAgBox";
            this.hbsAgBox.Size = new System.Drawing.Size(228, 21);
            this.hbsAgBox.TabIndex = 3;
            // 
            // hbsAgLbl
            // 
            this.hbsAgLbl.AutoSize = true;
            this.hbsAgLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hbsAgLbl.Location = new System.Drawing.Point(6, 58);
            this.hbsAgLbl.Name = "hbsAgLbl";
            this.hbsAgLbl.Size = new System.Drawing.Size(43, 13);
            this.hbsAgLbl.TabIndex = 2;
            this.hbsAgLbl.Text = "HBs Ag";
            // 
            // rwBox
            // 
            this.rwBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rwBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rwBox.FormattingEnabled = true;
            this.rwBox.Location = new System.Drawing.Point(72, 23);
            this.rwBox.Name = "rwBox";
            this.rwBox.Size = new System.Drawing.Size(228, 21);
            this.rwBox.TabIndex = 1;
            // 
            // rwLbl
            // 
            this.rwLbl.AutoSize = true;
            this.rwLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rwLbl.Location = new System.Drawing.Point(7, 28);
            this.rwLbl.Name = "rwLbl";
            this.rwLbl.Size = new System.Drawing.Size(26, 13);
            this.rwLbl.TabIndex = 0;
            this.rwLbl.Text = "RW";
            // 
            // Serology
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 361);
            this.Controls.Add(this.serologyBox);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.phenotypeTxt);
            this.Controls.Add(this.phenotypeLbl);
            this.Controls.Add(this.kellAgBox);
            this.Controls.Add(this.kellAgLbl);
            this.Controls.Add(this.rhesusFactorBox);
            this.Controls.Add(this.rhesusFactorLbl);
            this.Controls.Add(this.bloodTypeBox);
            this.Controls.Add(this.bloodTypeLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(388, 404);
            this.Name = "Serology";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кровь";
            this.serologyBox.ResumeLayout(false);
            this.serologyBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bloodTypeLbl;
        private System.Windows.Forms.ComboBox bloodTypeBox;
        private System.Windows.Forms.ComboBox rhesusFactorBox;
        private System.Windows.Forms.Label rhesusFactorLbl;
        private System.Windows.Forms.ComboBox kellAgBox;
        private System.Windows.Forms.Label kellAgLbl;
        private System.Windows.Forms.Label phenotypeLbl;
        private System.Windows.Forms.RichTextBox phenotypeTxt;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.GroupBox serologyBox;
        private System.Windows.Forms.ComboBox hivBox;
        private System.Windows.Forms.Label hivLbl;
        private System.Windows.Forms.ComboBox antiHcvBox;
        private System.Windows.Forms.Label antiHsvLbl;
        private System.Windows.Forms.ComboBox hbsAgBox;
        private System.Windows.Forms.Label hbsAgLbl;
        private System.Windows.Forms.ComboBox rwBox;
        private System.Windows.Forms.Label rwLbl;
    }
}