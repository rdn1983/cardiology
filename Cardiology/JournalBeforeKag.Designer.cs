namespace Cardiology
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
            this.journalAllPnl.SuspendLayout();
            this.journalGrouppedPanel.SuspendLayout();
            this.journalCreationMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // journalAllPnl
            // 
            this.journalAllPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.journalAllPnl.Controls.Add(this.journalGrouppedPanel);
            this.journalAllPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.journalAllPnl.Location = new System.Drawing.Point(12, 12);
            this.journalAllPnl.Name = "journalAllPnl";
            this.journalAllPnl.Size = new System.Drawing.Size(973, 580);
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
            this.journalGrouppedPanel.Size = new System.Drawing.Size(940, 548);
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
            this.journalContainer.Size = new System.Drawing.Size(907, 542);
            this.journalContainer.TabIndex = 0;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(910, 598);
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
            this.printBtn.Location = new System.Drawing.Point(829, 598);
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
            this.addJournalByMenuBtn.Location = new System.Drawing.Point(991, 12);
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
            // JournalBeforeKag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 631);
            this.Controls.Add(this.addJournalByMenuBtn);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.journalAllPnl);
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
    }
}