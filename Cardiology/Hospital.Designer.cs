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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hospital));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.actionsManu = new System.Windows.Forms.ToolStripMenuItem();
            this.patientAdmission = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodTrunsfusionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issuingMedicineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.morningInspectationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.journalBeforeKAGMeniItem = new System.Windows.Forms.ToolStripMenuItem();
            this.journalAfterKAGMnuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.journalWithoutKAGMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.konsiliumItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freePatient = new System.Windows.Forms.ToolStripMenuItem();
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
            this.aidBlansMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blanksMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hospitalPatientsTbl = new System.Windows.Forms.DataGridView();
            this.patientsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.firstInspectationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issuingMedicineItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodTransfusionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.manipulationProtocolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blanksItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hospitalSession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_in_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor_who = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hospitalPatientsTbl)).BeginInit();
            this.patientsContextMenu.SuspendLayout();
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
            this.analysisMenuItem,
            this.bloodTrunsfusionMenuItem,
            this.issuingMedicineMenuItem,
            this.toolStripSeparator1,
            this.morningInspectationMenuItem,
            this.journalBeforeKAGMeniItem,
            this.journalAfterKAGMnuItem,
            this.journalWithoutKAGMenuItem,
            this.toolStripSeparator2,
            this.konsiliumItem,
            this.freePatient});
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
            // analysisMenuItem
            // 
            this.analysisMenuItem.Name = "analysisMenuItem";
            this.analysisMenuItem.Size = new System.Drawing.Size(261, 22);
            this.analysisMenuItem.Text = "Анализы, Исследования";
            this.analysisMenuItem.Click += new System.EventHandler(this.analysisItem_Click);
            // 
            // bloodTrunsfusionMenuItem
            // 
            this.bloodTrunsfusionMenuItem.Name = "bloodTrunsfusionMenuItem";
            this.bloodTrunsfusionMenuItem.Size = new System.Drawing.Size(261, 22);
            this.bloodTrunsfusionMenuItem.Text = "Переливание компонентов крови";
            this.bloodTrunsfusionMenuItem.Click += new System.EventHandler(this.bloodTrunsfusionMenuItem_Click);
            // 
            // issuingMedicineMenuItem
            // 
            this.issuingMedicineMenuItem.Name = "issuingMedicineMenuItem";
            this.issuingMedicineMenuItem.Size = new System.Drawing.Size(261, 22);
            this.issuingMedicineMenuItem.Text = "Назначения";
            this.issuingMedicineMenuItem.Click += new System.EventHandler(this.issuingMedicineItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(258, 6);
            // 
            // morningInspectationMenuItem
            // 
            this.morningInspectationMenuItem.Name = "morningInspectationMenuItem";
            this.morningInspectationMenuItem.Size = new System.Drawing.Size(261, 22);
            this.morningInspectationMenuItem.Text = "Утренний совместный обход";
            this.morningInspectationMenuItem.Click += new System.EventHandler(this.morningInspectationMenuItem_Click);
            // 
            // journalBeforeKAGMeniItem
            // 
            this.journalBeforeKAGMeniItem.Name = "journalBeforeKAGMeniItem";
            this.journalBeforeKAGMeniItem.Size = new System.Drawing.Size(261, 22);
            this.journalBeforeKAGMeniItem.Text = "Дневник до КАГ";
            this.journalBeforeKAGMeniItem.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // journalAfterKAGMnuItem
            // 
            this.journalAfterKAGMnuItem.Name = "journalAfterKAGMnuItem";
            this.journalAfterKAGMnuItem.Size = new System.Drawing.Size(261, 22);
            this.journalAfterKAGMnuItem.Text = "Дневник после КАГ";
            this.journalAfterKAGMnuItem.Click += new System.EventHandler(this.journalAfterKAGMnuItem_Click);
            // 
            // journalWithoutKAGMenuItem
            // 
            this.journalWithoutKAGMenuItem.Name = "journalWithoutKAGMenuItem";
            this.journalWithoutKAGMenuItem.Size = new System.Drawing.Size(261, 22);
            this.journalWithoutKAGMenuItem.Text = "Дневник без КАГ";
            this.journalWithoutKAGMenuItem.Click += new System.EventHandler(this.journalWithoutKAGMenuItem_Click);
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
            // freePatient
            // 
            this.freePatient.Name = "freePatient";
            this.freePatient.Size = new System.Drawing.Size(261, 22);
            this.freePatient.Text = "Выписка пациента";
            this.freePatient.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // reportsMenu
            // 
            this.reportsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.aidBlansMenuItem,
            this.blanksMenuItem});
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
            // aidBlansMenuItem
            // 
            this.aidBlansMenuItem.Name = "aidBlansMenuItem";
            this.aidBlansMenuItem.Size = new System.Drawing.Size(217, 22);
            this.aidBlansMenuItem.Text = "Письма для скорой";
            this.aidBlansMenuItem.Click += new System.EventHandler(this.aidBlansMenuItem_Click);
            // 
            // blanksMenuItem
            // 
            this.blanksMenuItem.Name = "blanksMenuItem";
            this.blanksMenuItem.Size = new System.Drawing.Size(217, 22);
            this.blanksMenuItem.Text = "Бланки";
            // 
            // hospitalPatientsTbl
            // 
            this.hospitalPatientsTbl.AllowUserToAddRows = false;
            this.hospitalPatientsTbl.AllowUserToDeleteRows = false;
            this.hospitalPatientsTbl.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.hospitalPatientsTbl.BackgroundColor = System.Drawing.SystemColors.Window;
            this.hospitalPatientsTbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hospitalPatientsTbl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.hospitalPatientsTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.hospitalPatientsTbl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hospitalSession,
            this.patient_fio,
            this.patient_place,
            this.patient_in_date,
            this.doctor_who,
            this.patient_diagnosis});
            this.hospitalPatientsTbl.Location = new System.Drawing.Point(12, 27);
            this.hospitalPatientsTbl.Name = "hospitalPatientsTbl";
            this.hospitalPatientsTbl.ReadOnly = true;
            this.hospitalPatientsTbl.RowTemplate.ContextMenuStrip = this.patientsContextMenu;
            this.hospitalPatientsTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hospitalPatientsTbl.Size = new System.Drawing.Size(833, 398);
            this.hospitalPatientsTbl.TabIndex = 2;
            // 
            // patientsContextMenu
            // 
            this.patientsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstInspectationItem,
            this.analysisItem,
            this.issuingMedicineItem,
            this.bloodTransfusionItem,
            this.toolStripSeparator3,
            this.manipulationProtocolItem,
            this.blanksItem});
            this.patientsContextMenu.Name = "contextMenuStrip1";
            this.patientsContextMenu.Size = new System.Drawing.Size(262, 142);
            // 
            // firstInspectationItem
            // 
            this.firstInspectationItem.Name = "firstInspectationItem";
            this.firstInspectationItem.Size = new System.Drawing.Size(261, 22);
            this.firstInspectationItem.Text = "Первичный осмотр";
            this.firstInspectationItem.Click += new System.EventHandler(this.firstInspectationItem_Click);
            // 
            // analysisItem
            // 
            this.analysisItem.Name = "analysisItem";
            this.analysisItem.Size = new System.Drawing.Size(261, 22);
            this.analysisItem.Text = "Анализы, Исследования";
            this.analysisItem.Click += new System.EventHandler(this.analysisItem_Click);
            // 
            // issuingMedicineItem
            // 
            this.issuingMedicineItem.Name = "issuingMedicineItem";
            this.issuingMedicineItem.Size = new System.Drawing.Size(261, 22);
            this.issuingMedicineItem.Text = "Назначения";
            this.issuingMedicineItem.Click += new System.EventHandler(this.issuingMedicineItem_Click);
            // 
            // bloodTransfusionItem
            // 
            this.bloodTransfusionItem.Name = "bloodTransfusionItem";
            this.bloodTransfusionItem.Size = new System.Drawing.Size(261, 22);
            this.bloodTransfusionItem.Text = "Переливание компонентов крови";
            this.bloodTransfusionItem.Click += new System.EventHandler(this.bloodTrunsfusionMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(258, 6);
            // 
            // manipulationProtocolItem
            // 
            this.manipulationProtocolItem.Name = "manipulationProtocolItem";
            this.manipulationProtocolItem.Size = new System.Drawing.Size(261, 22);
            this.manipulationProtocolItem.Text = "Протоколы манипуляций";
            // 
            // blanksItem
            // 
            this.blanksItem.Name = "blanksItem";
            this.blanksItem.Size = new System.Drawing.Size(261, 22);
            this.blanksItem.Text = "Бланки";
            // 
            // hospitalSession
            // 
            this.hospitalSession.HeaderText = "sessionId";
            this.hospitalSession.Name = "hospitalSession";
            this.hospitalSession.ReadOnly = true;
            this.hospitalSession.Visible = false;
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
            this.patient_diagnosis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.patient_diagnosis.HeaderText = "Диагноз";
            this.patient_diagnosis.Name = "patient_diagnosis";
            this.patient_diagnosis.ReadOnly = true;
            // 
            // Hospital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 450);
            this.Controls.Add(this.hospitalPatientsTbl);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "Hospital";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hospitalPatientsTbl)).EndInit();
            this.patientsContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem actionsManu;
        private System.Windows.Forms.ToolStripMenuItem patientAdmission;
        private System.Windows.Forms.ToolStripMenuItem freePatient;
        private System.Windows.Forms.ToolStripMenuItem reportsMenu;
        private System.Windows.Forms.DataGridView hospitalPatientsTbl;
        private System.Windows.Forms.ToolStripMenuItem morningInspectationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem journalBeforeKAGMeniItem;
        private System.Windows.Forms.ToolStripMenuItem analysisMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloodTrunsfusionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issuingMedicineMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem journalAfterKAGMnuItem;
        private System.Windows.Forms.ToolStripMenuItem journalWithoutKAGMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem konsiliumItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem aidBlansMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blanksMenuItem;
        private System.Windows.Forms.ContextMenuStrip patientsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem analysisItem;
        private System.Windows.Forms.ToolStripMenuItem bloodTransfusionItem;
        private System.Windows.Forms.ToolStripMenuItem issuingMedicineItem;
        private System.Windows.Forms.ToolStripMenuItem manipulationProtocolItem;
        private System.Windows.Forms.ToolStripMenuItem blanksItem;
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
        private System.Windows.Forms.ToolStripMenuItem firstInspectationItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn hospitalSession;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_place;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_in_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor_who;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_diagnosis;
    }
}