namespace Cardiology
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
            // 
            // gridContextMenu
            // 
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
            // 
            // deleteMenu
            // 
            this.deleteMenu.Name = "deleteMenu";
            this.deleteMenu.Size = new System.Drawing.Size(154, 22);
            this.deleteMenu.Text = "Удалить";
            // 
            // printTitlePage
            // 
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
            this.printBtn.Location = new System.Drawing.Point(693, 410);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(95, 28);
            this.printBtn.TabIndex = 2;
            this.printBtn.Text = "Печать";
            this.printBtn.UseVisualStyleBackColor = true;
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
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsManu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 4;
            this.mainMenu.Text = "menuStrip1";
            // 
            // actionsManu
            // 
            this.actionsManu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analysisMenuItem,
            this.bloodTrunsfusionMenuItem,
            this.issuingMedicineMenuItem,
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
            // analysisMenuItem
            // 
            this.analysisMenuItem.Name = "analysisMenuItem";
            this.analysisMenuItem.Size = new System.Drawing.Size(261, 22);
            this.analysisMenuItem.Text = "Анализы, Исследования";
            this.analysisMenuItem.Click += new System.EventHandler(this.analysisMenuItem_Click);
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
            this.issuingMedicineMenuItem.Click += new System.EventHandler(this.issuingMedicineMenuItem_Click);
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
            this.operationName.HeaderText = "Название операции";
            this.operationName.Name = "operationName";
            this.operationName.ReadOnly = true;
            this.operationName.Width = 250;
            // 
            // operationDate
            // 
            this.operationDate.HeaderText = "Дата операции";
            this.operationDate.Name = "operationDate";
            this.operationDate.ReadOnly = true;
            // 
            // docExecutor
            // 
            this.docExecutor.HeaderText = "Ответственный врач";
            this.docExecutor.Name = "docExecutor";
            this.docExecutor.ReadOnly = true;
            this.docExecutor.Width = 250;
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
            this.Activated += new System.EventHandler(this.PatientHistory_Activated);
            this.Name = "PatientsHistory";
            this.Text = "История болезни";
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
        private System.Windows.Forms.ToolStripMenuItem analysisMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloodTrunsfusionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issuingMedicineMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem morningInspectationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem journalBeforeKAGMeniItem;
        private System.Windows.Forms.ToolStripMenuItem journalAfterKAGMnuItem;
        private System.Windows.Forms.ToolStripMenuItem journalWithoutKAGMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem konsiliumItem;
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