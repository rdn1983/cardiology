namespace Cardiology
{
    partial class Hospital
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
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.actionsManu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.patient_fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_in_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor_who = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 428);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(857, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip1";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsManu,
            this.reportsMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(857, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // actionsManu
            // 
            this.actionsManu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.actionsManu.Name = "actionsManu";
            this.actionsManu.Size = new System.Drawing.Size(57, 20);
            this.actionsManu.Text = "actions";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem1.Text = "accept patient";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem2.Text = "release patient";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // reportsMenu
            // 
            this.reportsMenu.Name = "reportsMenu";
            this.reportsMenu.Size = new System.Drawing.Size(56, 20);
            this.reportsMenu.Text = "reports";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patient_fio,
            this.patient_place,
            this.patient_in_date,
            this.doctor_who,
            this.patient_diagnosis});
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(833, 398);
            this.dataGridView1.TabIndex = 2;
            // 
            // patient_fio
            // 
            this.patient_fio.HeaderText = "ФИО пациента";
            this.patient_fio.Name = "patient_fio";
            this.patient_fio.ReadOnly = true;
            this.patient_fio.Width = 200;
            // 
            // patient_place
            // 
            this.patient_place.HeaderText = "Палата/Койка";
            this.patient_place.Name = "patient_place";
            this.patient_place.ReadOnly = true;
            // 
            // patient_in_date
            // 
            this.patient_in_date.HeaderText = "Дата поступления";
            this.patient_in_date.Name = "patient_in_date";
            this.patient_in_date.ReadOnly = true;
            // 
            // doctor_who
            // 
            this.doctor_who.HeaderText = "Лечащий врач";
            this.doctor_who.Name = "doctor_who";
            this.doctor_who.ReadOnly = true;
            this.doctor_who.Width = 200;
            // 
            // patient_diagnosis
            // 
            this.patient_diagnosis.HeaderText = "Диагноз";
            this.patient_diagnosis.Name = "patient_diagnosis";
            this.patient_diagnosis.ReadOnly = true;
            // 
            // Hospital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "Hospital";
            this.Text = "Hospital";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem actionsManu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem reportsMenu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_place;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_in_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor_who;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_diagnosis;
    }
}