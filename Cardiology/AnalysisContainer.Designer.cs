namespace Cardiology
{
    partial class AnalysisContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalysisContainer));
            this.scrolledContainer = new System.Windows.Forms.Panel();
            this.combainingContainer = new System.Windows.Forms.TableLayoutPanel();
            this.selectToContainer = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.scrolledContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrolledContainer
            // 
            this.scrolledContainer.AutoScroll = true;
            this.scrolledContainer.Controls.Add(this.combainingContainer);
            this.scrolledContainer.Location = new System.Drawing.Point(3, 5);
            this.scrolledContainer.Name = "scrolledContainer";
            this.scrolledContainer.Size = new System.Drawing.Size(832, 530);
            this.scrolledContainer.TabIndex = 0;
            // 
            // combainingContainer
            // 
            this.combainingContainer.AutoSize = true;
            this.combainingContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.combainingContainer.ColumnCount = 1;
            this.combainingContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.combainingContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.combainingContainer.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.combainingContainer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.combainingContainer.Location = new System.Drawing.Point(3, 7);
            this.combainingContainer.Name = "combainingContainer";
            this.combainingContainer.RowCount = 1;
            this.combainingContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.combainingContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.combainingContainer.Size = new System.Drawing.Size(0, 0);
            this.combainingContainer.TabIndex = 0;
            // 
            // selectToContainer
            // 
            this.selectToContainer.Image = global::Cardiology.Properties.Resources.addd1;
            this.selectToContainer.Location = new System.Drawing.Point(841, 5);
            this.selectToContainer.Name = "selectToContainer";
            this.selectToContainer.Size = new System.Drawing.Size(31, 28);
            this.selectToContainer.TabIndex = 1;
            this.selectToContainer.UseVisualStyleBackColor = true;
            this.selectToContainer.Click += new System.EventHandler(this.selectToContainer_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(680, 541);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Отменить";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(760, 541);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // AnalysisContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 567);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.selectToContainer);
            this.Controls.Add(this.scrolledContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnalysisContainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.scrolledContainer.ResumeLayout(false);
            this.scrolledContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel scrolledContainer;
        private System.Windows.Forms.Button selectToContainer;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TableLayoutPanel combainingContainer;
    }
}