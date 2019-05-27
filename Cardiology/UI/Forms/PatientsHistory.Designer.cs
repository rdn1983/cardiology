namespace Cardiology.UI.Forms
{
    partial class PatientsHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientsHistory));
            this.patientHistoryGrid = new System.Windows.Forms.DataGridView();
            this.gridContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.printTitlePage = new System.Windows.Forms.CheckBox();
            this.printBtn = new System.Windows.Forms.Button();
            this.titleLbl = new System.Windows.Forms.Label();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.actionsManu = new System.Windows.Forms.ToolStripMenuItem();
            this.firstInspectationsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inspectionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uziItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekgItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kagItem = new System.Windows.Forms.ToolStripMenuItem();
            this.egdsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialistItem = new System.Windows.Forms.ToolStripMenuItem();
            this.holterItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urineItem = new System.Windows.Forms.ToolStripMenuItem();
            this.koagulogrammItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodTypeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hormonesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oncologicMarkersItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodTrunsfusionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issuingMedicineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beforeOperationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.morningInspectationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.journalBeforeKAGMeniItem = new System.Windows.Forms.ToolStripMenuItem();
            this.journalAfterKAGMnuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.journalWithoutKAGMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.konsiliumItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedToPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hospitalSession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docExecutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.patientHistoryGrid)).BeginInit();
            this.gridContextMenu.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // patientHistoryGrid
            // 
            this.patientHistoryGrid.AllowUserToAddRows = false;
            this.patientHistoryGrid.AllowUserToDeleteRows = false;
            this.patientHistoryGrid.AllowUserToResizeColumns = false;
            this.patientHistoryGrid.AllowUserToResizeRows = false;
            this.patientHistoryGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientHistoryGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.patientHistoryGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.patientHistoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patientHistoryGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkedToPrint,
            this.hospitalSession,
            this.operationType,
            this.operationId,
            this.operationName,
            this.operationDate,
            this.docExecutor,
            this.operationDescription});
            this.patientHistoryGrid.ContextMenuStrip = this.gridContextMenu;
            this.patientHistoryGrid.Location = new System.Drawing.Point(24, 36);
            this.patientHistoryGrid.Name = "patientHistoryGrid";
            this.patientHistoryGrid.ReadOnly = true;
            this.patientHistoryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patientHistoryGrid.Size = new System.Drawing.Size(776, 319);
            this.patientHistoryGrid.TabIndex = 0;
            this.patientHistoryGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.patientHistoryGrid_CellClick);
            // 
            // gridContextMenu
            // 
            this.gridContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMenu,
            this.deleteMenu});
            this.gridContextMenu.Name = "gridContextMenu";
            this.gridContextMenu.Size = new System.Drawing.Size(155, 48);
            // 
            // editMenu
            // 
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(154, 22);
            this.editMenu.Text = "Редактировать";
            this.editMenu.Click += new System.EventHandler(this.editMenu_Click);
            // 
            // deleteMenu
            // 
            this.deleteMenu.Name = "deleteMenu";
            this.deleteMenu.Size = new System.Drawing.Size(154, 22);
            this.deleteMenu.Text = "Удалить";
            this.deleteMenu.Click += new System.EventHandler(this.deleteMenu_Click);
            // 
            // printTitlePage
            // 
            this.printTitlePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printTitlePage.AutoSize = true;
            this.printTitlePage.Location = new System.Drawing.Point(515, 421);
            this.printTitlePage.Name = "printTitlePage";
            this.printTitlePage.Size = new System.Drawing.Size(172, 17);
            this.printTitlePage.TabIndex = 1;
            this.printTitlePage.Text = "Распечатать титульный лист";
            this.printTitlePage.UseVisualStyleBackColor = true;
            // 
            // printBtn
            // 
            this.printBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printBtn.Location = new System.Drawing.Point(693, 410);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(95, 28);
            this.printBtn.TabIndex = 2;
            this.printBtn.Text = "Печать";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLbl.Location = new System.Drawing.Point(12, 20);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(0, 16);
            this.titleLbl.TabIndex = 3;
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsManu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 4;
            // 
            // actionsManu
            // 
            this.actionsManu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstInspectationsItem,
            this.inspectionsMenuItem,
            this.analysisItem,
            this.bloodTrunsfusionMenuItem,
            this.issuingMedicineMenuItem,
            this.beforeOperationItem,
            this.toolStripSeparator1,
            this.morningInspectationMenuItem,
            this.journalBeforeKAGMeniItem,
            this.journalAfterKAGMnuItem,
            this.journalWithoutKAGMenuItem,
            this.toolStripSeparator2,
            this.konsiliumItem});
            this.actionsManu.Name = "actionsManu";
            this.actionsManu.Size = new System.Drawing.Size(70, 20);
            this.actionsManu.Text = "Действия";
            // 
            // firstInspectationsItem
            // 
            this.firstInspectationsItem.Name = "firstInspectationsItem";
            this.firstInspectationsItem.Size = new System.Drawing.Size(261, 22);
            this.firstInspectationsItem.Text = "Первичный обход";
            this.firstInspectationsItem.Click += new System.EventHandler(this.firstInspectationsItem_Click);
            // 
            // inspectionsMenuItem
            // 
            this.inspectionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xrayMenuItem,
            this.uziItem,
            this.ekgItem,
            this.kagItem,
            this.egdsItem,
            this.specialistItem,
            this.holterItem});
            this.inspectionsMenuItem.Name = "inspectionsMenuItem";
            this.inspectionsMenuItem.Size = new System.Drawing.Size(261, 22);
            this.inspectionsMenuItem.Text = "Результаты обследований";
            // 
            // xrayMenuItem
            // 
            this.xrayMenuItem.Name = "xrayMenuItem";
            this.xrayMenuItem.Size = new System.Drawing.Size(223, 22);
            this.xrayMenuItem.Text = "Рентген/КТ";
            this.xrayMenuItem.Click += new System.EventHandler(this.xrayMenuItem_Click);
            // 
            // uziItem
            // 
            this.uziItem.Name = "uziItem";
            this.uziItem.Size = new System.Drawing.Size(223, 22);
            this.uziItem.Text = "УЗИ/ЭХО";
            this.uziItem.Click += new System.EventHandler(this.uziItem_Click);
            // 
            // ekgItem
            // 
            this.ekgItem.Name = "ekgItem";
            this.ekgItem.Size = new System.Drawing.Size(223, 22);
            this.ekgItem.Text = "ЭКГ";
            this.ekgItem.Click += new System.EventHandler(this.ekgItem_Click);
            // 
            // kagItem
            // 
            this.kagItem.Name = "kagItem";
            this.kagItem.Size = new System.Drawing.Size(223, 22);
            this.kagItem.Text = "КАГ";
            this.kagItem.Click += new System.EventHandler(this.kagItem_Click);
            // 
            // egdsItem
            // 
            this.egdsItem.Name = "egdsItem";
            this.egdsItem.Size = new System.Drawing.Size(223, 22);
            this.egdsItem.Text = "ЭГДС";
            this.egdsItem.Click += new System.EventHandler(this.egdsItem_Click);
            // 
            // specialistItem
            // 
            this.specialistItem.Name = "specialistItem";
            this.specialistItem.Size = new System.Drawing.Size(223, 22);
            this.specialistItem.Text = "Заключение специалистов";
            this.specialistItem.Click += new System.EventHandler(this.specialistItem_Click);
            // 
            // holterItem
            // 
            this.holterItem.Name = "holterItem";
            this.holterItem.Size = new System.Drawing.Size(223, 22);
            this.holterItem.Text = "Холтер/СМАД";
            this.holterItem.Click += new System.EventHandler(this.holterItem_Click);
            // 
            // analysisItem
            // 
            this.analysisItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bloodItem,
            this.urineItem,
            this.koagulogrammItem,
            this.bloodTypeItem,
            this.hormonesItem,
            this.oncologicMarkersItem});
            this.analysisItem.Name = "analysisItem";
            this.analysisItem.Size = new System.Drawing.Size(261, 22);
            this.analysisItem.Text = "Анализы";
            // 
            // bloodItem
            // 
            this.bloodItem.Name = "bloodItem";
            this.bloodItem.Size = new System.Drawing.Size(225, 22);
            this.bloodItem.Text = "Клинический анализ крови";
            this.bloodItem.Click += new System.EventHandler(this.bloodItem_Click);
            // 
            // urineItem
            // 
            this.urineItem.Name = "urineItem";
            this.urineItem.Size = new System.Drawing.Size(225, 22);
            this.urineItem.Text = "Анализ мочи";
            this.urineItem.Click += new System.EventHandler(this.urineItem_Click);
            // 
            // koagulogrammItem
            // 
            this.koagulogrammItem.Name = "koagulogrammItem";
            this.koagulogrammItem.Size = new System.Drawing.Size(225, 22);
            this.koagulogrammItem.Text = "Коагулограмма";
            this.koagulogrammItem.Click += new System.EventHandler(this.koagulogrammItem_Click);
            // 
            // bloodTypeItem
            // 
            this.bloodTypeItem.Name = "bloodTypeItem";
            this.bloodTypeItem.Size = new System.Drawing.Size(225, 22);
            this.bloodTypeItem.Text = "Группа крови, инфекции";
            this.bloodTypeItem.Click += new System.EventHandler(this.bloodTypeItem_Click);
            // 
            // hormonesItem
            // 
            this.hormonesItem.Name = "hormonesItem";
            this.hormonesItem.Size = new System.Drawing.Size(225, 22);
            this.hormonesItem.Text = "Гормоны";
            this.hormonesItem.Click += new System.EventHandler(this.hormonesItem_Click);
            // 
            // oncologicMarkersItem
            // 
            this.oncologicMarkersItem.Name = "oncologicMarkersItem";
            this.oncologicMarkersItem.Size = new System.Drawing.Size(225, 22);
            this.oncologicMarkersItem.Text = "Онкомаркеры";
            this.oncologicMarkersItem.Click += new System.EventHandler(this.oncologicMarkersItem_Click);
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
            this.issuingMedicineMenuItem.Text = "Лист назначений";
            this.issuingMedicineMenuItem.Click += new System.EventHandler(this.issuingMedicineMenuItem_Click);
            // 
            // beforeOperationItem
            // 
            this.beforeOperationItem.Name = "beforeOperationItem";
            this.beforeOperationItem.Size = new System.Drawing.Size(261, 22);
            this.beforeOperationItem.Text = "Предоперационный эпикриз";
            this.beforeOperationItem.Click += new System.EventHandler(this.beforeOperationItem_Click);
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
            this.journalBeforeKAGMeniItem.Click += new System.EventHandler(this.journalBeforeKAGMeniItem_Click);
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
            this.journalWithoutKAGMenuItem.Text = "Варианты дневников";
            this.journalWithoutKAGMenuItem.Visible = false;
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
            // checkedToPrint
            // 
            this.checkedToPrint.HeaderText = "";
            this.checkedToPrint.Name = "checkedToPrint";
            this.checkedToPrint.ReadOnly = true;
            this.checkedToPrint.Width = 30;
            // 
            // hospitalSession
            // 
            this.hospitalSession.HeaderText = "hospitalSession";
            this.hospitalSession.Name = "hospitalSession";
            this.hospitalSession.ReadOnly = true;
            this.hospitalSession.Visible = false;
            // 
            // operationType
            // 
            this.operationType.HeaderText = "operationType";
            this.operationType.Name = "operationType";
            this.operationType.ReadOnly = true;
            this.operationType.Visible = false;
            // 
            // operationId
            // 
            this.operationId.HeaderText = "operationId";
            this.operationId.Name = "operationId";
            this.operationId.ReadOnly = true;
            this.operationId.Visible = false;
            // 
            // operationName
            // 
            this.operationName.HeaderText = "Действие";
            this.operationName.Name = "operationName";
            this.operationName.ReadOnly = true;
            this.operationName.Width = 250;
            // 
            // operationDate
            // 
            this.operationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.operationDate.HeaderText = "Дата действия";
            this.operationDate.Name = "operationDate";
            this.operationDate.ReadOnly = true;
            // 
            // docExecutor
            // 
            this.docExecutor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.docExecutor.HeaderText = "Ответственный врач";
            this.docExecutor.Name = "docExecutor";
            this.docExecutor.ReadOnly = true;
            // 
            // operationDescription
            // 
            this.operationDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.operationDescription.HeaderText = "Подробности";
            this.operationDescription.Name = "operationDescription";
            this.operationDescription.ReadOnly = true;
            // 
            // PatientsHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.printTitlePage);
            this.Controls.Add(this.patientHistoryGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PatientsHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "История болезни";
            this.Activated += new System.EventHandler(this.PatientHistory_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.patientHistoryGrid)).EndInit();
            this.gridContextMenu.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView patientHistoryGrid;
        private System.Windows.Forms.CheckBox printTitlePage;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.ContextMenuStrip gridContextMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteMenu;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem actionsManu;
        private System.Windows.Forms.ToolStripMenuItem inspectionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloodTrunsfusionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issuingMedicineMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem morningInspectationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem journalBeforeKAGMeniItem;
        private System.Windows.Forms.ToolStripMenuItem journalAfterKAGMnuItem;
        private System.Windows.Forms.ToolStripMenuItem journalWithoutKAGMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem konsiliumItem;
        private System.Windows.Forms.ToolStripMenuItem firstInspectationsItem;
        private System.Windows.Forms.ToolStripMenuItem holterItem;
        private System.Windows.Forms.ToolStripMenuItem ekgItem;
        private System.Windows.Forms.ToolStripMenuItem kagItem;
        private System.Windows.Forms.ToolStripMenuItem egdsItem;
        private System.Windows.Forms.ToolStripMenuItem specialistItem;
        private System.Windows.Forms.ToolStripMenuItem uziItem;
        private System.Windows.Forms.ToolStripMenuItem beforeOperationItem;
        private System.Windows.Forms.ToolStripMenuItem analysisItem;
        private System.Windows.Forms.ToolStripMenuItem bloodItem;
        private System.Windows.Forms.ToolStripMenuItem urineItem;
        private System.Windows.Forms.ToolStripMenuItem koagulogrammItem;
        private System.Windows.Forms.ToolStripMenuItem bloodTypeItem;
        private System.Windows.Forms.ToolStripMenuItem hormonesItem;
        private System.Windows.Forms.ToolStripMenuItem xrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oncologicMarkersItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedToPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn hospitalSession;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn docExecutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationDescription;
    }
}