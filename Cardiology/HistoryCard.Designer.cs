namespace Cardiology
{
    partial class HistoryCard
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
            this.historyGrid = new System.Windows.Forms.DataGridView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.historyGrid)).BeginInit();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // historyGrid
            // 
            this.historyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3});
            this.historyGrid.Location = new System.Drawing.Point(12, 46);
            this.historyGrid.Name = "historyGrid";
            this.historyGrid.Size = new System.Drawing.Size(776, 352);
            this.historyGrid.TabIndex = 0;
            this.historyGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(535, 421);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(172, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Распечатать титульный лист";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Печать";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.Width = 20;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Дата проведения";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Наименование манипуляции";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ответственный врач";
            this.Column3.Name = "Column3";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsManu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 3;
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
            this.toolStripSeparator2});
            this.actionsManu.Name = "actionsManu";
            this.actionsManu.Size = new System.Drawing.Size(70, 20);
            this.actionsManu.Text = "Действия";
            // 
            // analysisMenuItem
            // 
            this.analysisMenuItem.Name = "analysisMenuItem";
            this.analysisMenuItem.Size = new System.Drawing.Size(261, 22);
            this.analysisMenuItem.Text = "Ввести анализы, исследования";
            // 
            // bloodTrunsfusionMenuItem
            // 
            this.bloodTrunsfusionMenuItem.Name = "bloodTrunsfusionMenuItem";
            this.bloodTrunsfusionMenuItem.Size = new System.Drawing.Size(261, 22);
            this.bloodTrunsfusionMenuItem.Text = "Переливание компонентов крови";
            // 
            // issuingMedicineMenuItem
            // 
            this.issuingMedicineMenuItem.Name = "issuingMedicineMenuItem";
            this.issuingMedicineMenuItem.Size = new System.Drawing.Size(261, 22);
            this.issuingMedicineMenuItem.Text = "Ввести назначения";
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
            // 
            // journalBeforeKAGMeniItem
            // 
            this.journalBeforeKAGMeniItem.Name = "journalBeforeKAGMeniItem";
            this.journalBeforeKAGMeniItem.Size = new System.Drawing.Size(261, 22);
            this.journalBeforeKAGMeniItem.Text = "Дневник до КАГ";
            // 
            // journalAfterKAGMnuItem
            // 
            this.journalAfterKAGMnuItem.Name = "journalAfterKAGMnuItem";
            this.journalAfterKAGMnuItem.Size = new System.Drawing.Size(261, 22);
            this.journalAfterKAGMnuItem.Text = "Дневник после КАГ";
            // 
            // journalWithoutKAGMenuItem
            // 
            this.journalWithoutKAGMenuItem.Name = "journalWithoutKAGMenuItem";
            this.journalWithoutKAGMenuItem.Size = new System.Drawing.Size(261, 22);
            this.journalWithoutKAGMenuItem.Text = "Дневник без КАГ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(258, 6);
            // 
            // HistoryCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.historyGrid);
            this.Name = "HistoryCard";
            this.Text = "История болезни";
            ((System.ComponentModel.ISupportInitialize)(this.historyGrid)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView historyGrid;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
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
    }
}