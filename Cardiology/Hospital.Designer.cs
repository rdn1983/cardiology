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
            this.components = new System.ComponentModel.Container();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.actionsManu = new System.Windows.Forms.ToolStripMenuItem();
            this.patientAdmission = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.konsiliumItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.kateterItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trombolisisItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veksItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toracatezosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intubationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekstubationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reanimItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.hospitalPatient = new System.Windows.Forms.DataGridView();
            this.patient_fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_in_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor_who = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hospitalPatient)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.patientAdmission,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem6,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripSeparator2,
            this.konsiliumItem,
            this.toolStripMenuItem2});
            this.actionsManu.Name = "actionsManu";
            this.actionsManu.Size = new System.Drawing.Size(70, 20);
            this.actionsManu.Text = "Действия";
            // 
            // patientAdmission
            // 
            this.patientAdmission.Name = "patientAdmission";
            this.patientAdmission.Size = new System.Drawing.Size(261, 22);
            this.patientAdmission.Text = "Поступление пациента";
            this.patientAdmission.Click += new System.EventHandler(this.patientAdmission_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem8.Text = "Анализы, Исследования";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem9.Text = "Переливание компонентов крови";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem6.Text = "Назначения";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(258, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem1.Text = "Утренний совместный обход";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem3.Text = "Дневник до КАГ";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem4.Text = "Дневник после КАГ";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem5.Text = "Дневник без КАГ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(258, 6);
            // 
            // konsiliumItem
            // 
            this.konsiliumItem.Name = "konsiliumItem";
            this.konsiliumItem.Size = new System.Drawing.Size(261, 22);
            this.konsiliumItem.Text = "Консилиум";
            this.konsiliumItem.Click += new System.EventHandler(this.konsiliumItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem2.Text = "Выписка пациента";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // reportsMenu
            // 
            this.reportsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12});
            this.reportsMenu.Name = "reportsMenu";
            this.reportsMenu.Size = new System.Drawing.Size(99, 20);
            this.reportsMenu.Text = "Документация";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kateterItem,
            this.trombolisisItem,
            this.veksItem,
            this.toracatezosItem,
            this.eitItem,
            this.intubationItem,
            this.ekstubationItem,
            this.reanimItem,
            this.deadItem});
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem10.Text = "Протоколы манипуляций";
            // 
            // kateterItem
            // 
            this.kateterItem.Name = "kateterItem";
            this.kateterItem.Size = new System.Drawing.Size(328, 22);
            this.kateterItem.Text = "Катетеризация яремной, подключичной вены";
            this.kateterItem.Click += new System.EventHandler(this.kateterItem_Click);
            // 
            // trombolisisItem
            // 
            this.trombolisisItem.Name = "trombolisisItem";
            this.trombolisisItem.Size = new System.Drawing.Size(328, 22);
            this.trombolisisItem.Text = "Показания к тромболизису";
            this.trombolisisItem.Click += new System.EventHandler(this.trombolisisItem_Click);
            // 
            // veksItem
            // 
            this.veksItem.Name = "veksItem";
            this.veksItem.Size = new System.Drawing.Size(328, 22);
            this.veksItem.Text = "Протокол постановки ВЭКС";
            this.veksItem.Click += new System.EventHandler(this.veksItem_Click);
            // 
            // toracatezosItem
            // 
            this.toracatezosItem.Name = "toracatezosItem";
            this.toracatezosItem.Size = new System.Drawing.Size(328, 22);
            this.toracatezosItem.Text = "Протокол торакацентоза";
            this.toracatezosItem.Click += new System.EventHandler(this.toracatezosItem_Click);
            // 
            // eitItem
            // 
            this.eitItem.Name = "eitItem";
            this.eitItem.Size = new System.Drawing.Size(328, 22);
            this.eitItem.Text = "Протокол ЭИТ";
            this.eitItem.Click += new System.EventHandler(this.eitItem_Click);
            // 
            // intubationItem
            // 
            this.intubationItem.Name = "intubationItem";
            this.intubationItem.Size = new System.Drawing.Size(328, 22);
            this.intubationItem.Text = "Интубация";
            this.intubationItem.Click += new System.EventHandler(this.intubationItem_Click);
            // 
            // ekstubationItem
            // 
            this.ekstubationItem.Name = "ekstubationItem";
            this.ekstubationItem.Size = new System.Drawing.Size(328, 22);
            this.ekstubationItem.Text = "Экстубация";
            this.ekstubationItem.Click += new System.EventHandler(this.ekstubationItem_Click);
            // 
            // reanimItem
            // 
            this.reanimItem.Name = "reanimItem";
            this.reanimItem.Size = new System.Drawing.Size(328, 22);
            this.reanimItem.Text = "Реанимационные предприятия+ констатация";
            this.reanimItem.Click += new System.EventHandler(this.reanimItem_Click);
            // 
            // deadItem
            // 
            this.deadItem.Name = "deadItem";
            this.deadItem.Size = new System.Drawing.Size(328, 22);
            this.deadItem.Text = "Констатация";
            this.deadItem.Click += new System.EventHandler(this.deadItem_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem11.Text = "Письма для скорой";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem12.Text = "Бланки";
            // 
            // hospitalPatient
            // 
            this.hospitalPatient.BackgroundColor = System.Drawing.SystemColors.Window;
            this.hospitalPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.hospitalPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patient_fio,
            this.patient_place,
            this.patient_in_date,
            this.doctor_who,
            this.patient_diagnosis});
            this.hospitalPatient.ContextMenuStrip = this.contextMenuStrip1;
            this.hospitalPatient.Location = new System.Drawing.Point(12, 27);
            this.hospitalPatient.Name = "hospitalPatient";
            this.hospitalPatient.ReadOnly = true;
            this.hospitalPatient.Size = new System.Drawing.Size(833, 398);
            this.hospitalPatient.TabIndex = 2;
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem13,
            this.toolStripMenuItem15,
            this.toolStripMenuItem14,
            this.toolStripSeparator3,
            this.toolStripMenuItem16,
            this.toolStripMenuItem17});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(262, 120);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem13.Text = "Анализы, Исследования";
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem15.Text = "Назначения";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem14.Text = "Переливание компонентов крови";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(258, 6);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem16.Text = "Протоколы манипуляций";
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem17.Text = "Бланки";
            // 
            // Hospital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 450);
            this.Controls.Add(this.hospitalPatient);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "Hospital";
            this.Text = "Hospital";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hospitalPatient)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem actionsManu;
        private System.Windows.Forms.ToolStripMenuItem patientAdmission;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem reportsMenu;
        private System.Windows.Forms.DataGridView hospitalPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_place;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_in_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor_who;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_diagnosis;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem konsiliumItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem kateterItem;
        private System.Windows.Forms.ToolStripMenuItem trombolisisItem;
        private System.Windows.Forms.ToolStripMenuItem veksItem;
        private System.Windows.Forms.ToolStripMenuItem toracatezosItem;
        private System.Windows.Forms.ToolStripMenuItem eitItem;
        private System.Windows.Forms.ToolStripMenuItem intubationItem;
        private System.Windows.Forms.ToolStripMenuItem ekstubationItem;
        private System.Windows.Forms.ToolStripMenuItem reanimItem;
        private System.Windows.Forms.ToolStripMenuItem deadItem;
    }
}