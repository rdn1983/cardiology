namespace Cardiology.UI.Forms
{
    partial class JournalBeforeKag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JournalBeforeKag));
            this.journalAllPnl = new System.Windows.Forms.GroupBox();
            this.journalGrouppedPanel = new System.Windows.Forms.Panel();
            this.journalContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.saveBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.addJournalByMenuBtn = new System.Windows.Forms.Button();
            this.journalCreationMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createJournalMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createDefferedJournalMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.container = new System.Windows.Forms.TabControl();
            this.journalTabs = new System.Windows.Forms.TabPage();
            this.toAnalysisTab = new System.Windows.Forms.Button();
            this.analysisTab = new System.Windows.Forms.TabPage();
            this.toJournalsBtn = new System.Windows.Forms.Button();
            this.analysisTabControl1 = new Cardiology.UI.Controls.AnalysisTabControl();
            this.journalAllPnl.SuspendLayout();
            this.journalGrouppedPanel.SuspendLayout();
            this.journalCreationMenu.SuspendLayout();
            this.container.SuspendLayout();
            this.journalTabs.SuspendLayout();
            this.analysisTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // journalAllPnl
            // 
            this.journalAllPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.journalAllPnl.Controls.Add(this.journalGrouppedPanel);
            this.journalAllPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.journalAllPnl.Location = new System.Drawing.Point(6, 3);
            this.journalAllPnl.Name = "journalAllPnl";
            this.journalAllPnl.Size = new System.Drawing.Size(947, 544);
            this.journalAllPnl.TabIndex = 0;
            this.journalAllPnl.TabStop = false;
            this.journalAllPnl.Text = "Журнал";
            // 
            // journalGrouppedPanel
            // 
            this.journalGrouppedPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.journalGrouppedPanel.AutoScroll = true;
            this.journalGrouppedPanel.Controls.Add(this.journalContainer);
            this.journalGrouppedPanel.Location = new System.Drawing.Point(4, 16);
            this.journalGrouppedPanel.Name = "journalGrouppedPanel";
            this.journalGrouppedPanel.Size = new System.Drawing.Size(938, 527);
            this.journalGrouppedPanel.TabIndex = 38;
            // 
            // journalContainer
            // 
            this.journalContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.journalContainer.AutoSize = true;
            this.journalContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.journalContainer.Location = new System.Drawing.Point(6, 3);
            this.journalContainer.Name = "journalContainer";
            this.journalContainer.Size = new System.Drawing.Size(907, 517);
            this.journalContainer.TabIndex = 0;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(882, 596);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printBtn.Location = new System.Drawing.Point(801, 596);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "MsWord";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // addJournalByMenuBtn
            // 
            this.addJournalByMenuBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addJournalByMenuBtn.Image = global::Cardiology.Properties.Resources.addd1;
            this.addJournalByMenuBtn.Location = new System.Drawing.Point(955, 6);
            this.addJournalByMenuBtn.Name = "addJournalByMenuBtn";
            this.addJournalByMenuBtn.Size = new System.Drawing.Size(30, 28);
            this.addJournalByMenuBtn.TabIndex = 38;
            this.addJournalByMenuBtn.UseVisualStyleBackColor = true;
            this.addJournalByMenuBtn.Click += new System.EventHandler(this.addJournalBtn_Click);
            // 
            // journalCreationMenu
            // 
            this.journalCreationMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createJournalMenu,
            this.createDefferedJournalMenu});
            this.journalCreationMenu.Name = "journalCreationMenu";
            this.journalCreationMenu.Size = new System.Drawing.Size(359, 48);
            // 
            // createJournalMenu
            // 
            this.createJournalMenu.Name = "createJournalMenu";
            this.createJournalMenu.Size = new System.Drawing.Size(358, 22);
            this.createJournalMenu.Text = "Дневник";
            this.createJournalMenu.Click += new System.EventHandler(this.createJournalMenu_Click);
            // 
            // createDefferedJournalMenu
            // 
            this.createDefferedJournalMenu.Name = "createDefferedJournalMenu";
            this.createDefferedJournalMenu.Size = new System.Drawing.Size(358, 22);
            this.createDefferedJournalMenu.Text = "Обоснование\"отложенной коронароангиографии\"";
            this.createDefferedJournalMenu.Click += new System.EventHandler(this.createDefferedJournalMenu_Click);
            // 
            // container
            // 
            this.container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.container.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.container.Controls.Add(this.journalTabs);
            this.container.Controls.Add(this.analysisTab);
            this.container.ItemSize = new System.Drawing.Size(0, 1);
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Name = "container";
            this.container.SelectedIndex = 0;
            this.container.Size = new System.Drawing.Size(997, 590);
            this.container.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.container.TabIndex = 39;
            // 
            // journalTabs
            // 
            this.journalTabs.Controls.Add(this.toAnalysisTab);
            this.journalTabs.Controls.Add(this.journalAllPnl);
            this.journalTabs.Controls.Add(this.addJournalByMenuBtn);
            this.journalTabs.Location = new System.Drawing.Point(4, 5);
            this.journalTabs.Name = "journalTabs";
            this.journalTabs.Padding = new System.Windows.Forms.Padding(3);
            this.journalTabs.Size = new System.Drawing.Size(989, 581);
            this.journalTabs.TabIndex = 0;
            this.journalTabs.Text = "Журналы";
            this.journalTabs.UseVisualStyleBackColor = true;
            // 
            // toAnalysisTab
            // 
            this.toAnalysisTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toAnalysisTab.Location = new System.Drawing.Point(775, 551);
            this.toAnalysisTab.Name = "toAnalysisTab";
            this.toAnalysisTab.Size = new System.Drawing.Size(169, 23);
            this.toAnalysisTab.TabIndex = 39;
            this.toAnalysisTab.Text = "Привязать анализы";
            this.toAnalysisTab.UseVisualStyleBackColor = true;
            this.toAnalysisTab.Click += new System.EventHandler(this.toAnalysisTab_Click);
            // 
            // analysisTab
            // 
            this.analysisTab.Controls.Add(this.toJournalsBtn);
            this.analysisTab.Controls.Add(this.analysisTabControl1);
            this.analysisTab.Location = new System.Drawing.Point(4, 5);
            this.analysisTab.Name = "analysisTab";
            this.analysisTab.Padding = new System.Windows.Forms.Padding(3);
            this.analysisTab.Size = new System.Drawing.Size(989, 581);
            this.analysisTab.TabIndex = 1;
            this.analysisTab.Text = "Анализы";
            this.analysisTab.UseVisualStyleBackColor = true;
            // 
            // toJournalsBtn
            // 
            this.toJournalsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toJournalsBtn.Location = new System.Drawing.Point(775, 551);
            this.toJournalsBtn.Name = "toJournalsBtn";
            this.toJournalsBtn.Size = new System.Drawing.Size(169, 23);
            this.toJournalsBtn.TabIndex = 40;
            this.toJournalsBtn.Text = "Ввести дневники";
            this.toJournalsBtn.UseVisualStyleBackColor = true;
            this.toJournalsBtn.Click += new System.EventHandler(this.toJournalsBtn_Click);
            // 
            // analysisTabControl1
            // 
            this.analysisTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analysisTabControl1.AutoSize = true;
            this.analysisTabControl1.Location = new System.Drawing.Point(0, 0);
            this.analysisTabControl1.Name = "analysisTabControl1";
            this.analysisTabControl1.Size = new System.Drawing.Size(983, 548);
            this.analysisTabControl1.TabIndex = 0;
            // 
            // JournalBeforeKag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 631);
            this.Controls.Add(this.container);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JournalBeforeKag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дневники";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JournalBeforeKag_FormClosing);
            this.journalAllPnl.ResumeLayout(false);
            this.journalGrouppedPanel.ResumeLayout(false);
            this.journalGrouppedPanel.PerformLayout();
            this.journalCreationMenu.ResumeLayout(false);
            this.container.ResumeLayout(false);
            this.journalTabs.ResumeLayout(false);
            this.analysisTab.ResumeLayout(false);
            this.analysisTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox journalAllPnl;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button addJournalByMenuBtn;
        private System.Windows.Forms.Panel journalGrouppedPanel;
        private System.Windows.Forms.FlowLayoutPanel journalContainer;
        private System.Windows.Forms.ContextMenuStrip journalCreationMenu;
        private System.Windows.Forms.ToolStripMenuItem createJournalMenu;
        private System.Windows.Forms.ToolStripMenuItem createDefferedJournalMenu;
        private System.Windows.Forms.TabControl container;
        private System.Windows.Forms.TabPage journalTabs;
        private System.Windows.Forms.TabPage analysisTab;
        private System.Windows.Forms.Button toAnalysisTab;
        private Controls.AnalysisTabControl analysisTabControl1;
        private System.Windows.Forms.Button toJournalsBtn;
    }
}