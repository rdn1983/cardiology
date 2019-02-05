namespace Cardiology
{
    partial class AnalysisSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalysisSelector));
            this.selectionContainer = new System.Windows.Forms.ListView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.select = new System.Windows.Forms.Button();
            this.checkAll = new System.Windows.Forms.Button();
            this.clearSelection = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.warningLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectionContainer
            // 
            this.selectionContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectionContainer.CausesValidation = false;
            this.selectionContainer.CheckBoxes = true;
            this.selectionContainer.FullRowSelect = true;
            this.selectionContainer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.selectionContainer.Location = new System.Drawing.Point(3, 1);
            this.selectionContainer.Name = "selectionContainer";
            this.selectionContainer.Size = new System.Drawing.Size(481, 309);
            this.selectionContainer.TabIndex = 0;
            this.selectionContainer.UseCompatibleStateImageBehavior = false;
            this.selectionContainer.View = System.Windows.Forms.View.List;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 333);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(487, 36);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // select
            // 
            this.select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.select.Location = new System.Drawing.Point(3, 341);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(75, 23);
            this.select.TabIndex = 2;
            this.select.Text = "Выбрать";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // checkAll
            // 
            this.checkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkAll.Location = new System.Drawing.Point(84, 341);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(112, 23);
            this.checkAll.TabIndex = 3;
            this.checkAll.Text = "Выделить все";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.Click += new System.EventHandler(this.button2_Click);
            // 
            // clearSelection
            // 
            this.clearSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearSelection.Location = new System.Drawing.Point(202, 341);
            this.clearSelection.Name = "clearSelection";
            this.clearSelection.Size = new System.Drawing.Size(117, 23);
            this.clearSelection.TabIndex = 4;
            this.clearSelection.Text = "Снять выделение";
            this.clearSelection.UseVisualStyleBackColor = true;
            this.clearSelection.Click += new System.EventHandler(this.clearSelection_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.Location = new System.Drawing.Point(409, 341);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.warningLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 311);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(487, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // warningLbl
            // 
            this.warningLbl.Name = "warningLbl";
            this.warningLbl.Size = new System.Drawing.Size(457, 17);
            this.warningLbl.Text = "Выберите 1 или более объектов. Для закрытия окна без выбора нажмите Отмена";
            // 
            // AnalysisSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 369);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.clearSelection);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.select);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.selectionContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnalysisSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите объекты";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView selectionContainer;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.Button checkAll;
        private System.Windows.Forms.Button clearSelection;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel warningLbl;
    }
}