﻿namespace Cardiology.UI.Forms
{
    partial class PreoperativeEpicrisiscs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreoperativeEpicrisiscs));
            this.diagnosisLbl = new System.Windows.Forms.Label();
            this.diagnosisTxt = new System.Windows.Forms.RichTextBox();
            this.chooseDiagnosisBtn = new System.Windows.Forms.Button();
            this.analysisLbl = new System.Windows.Forms.Label();
            this.analysisGrid = new System.Windows.Forms.DataGridView();
            this.chooseAnalysisBtn = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.Button();
            this.epicrisisDateTxt = new System.Windows.Forms.DateTimePicker();
            this.epicrisisDateLbl = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.r_object_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analysisType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analysisTypeLbl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analysis_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteBtn = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.analysisGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // diagnosisLbl
            // 
            this.diagnosisLbl.AutoSize = true;
            this.diagnosisLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.diagnosisLbl.Location = new System.Drawing.Point(13, 44);
            this.diagnosisLbl.Name = "diagnosisLbl";
            this.diagnosisLbl.Size = new System.Drawing.Size(62, 13);
            this.diagnosisLbl.TabIndex = 0;
            this.diagnosisLbl.Text = "Диагноз:";
            // 
            // diagnosisTxt
            // 
            this.diagnosisTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diagnosisTxt.Location = new System.Drawing.Point(81, 41);
            this.diagnosisTxt.Name = "diagnosisTxt";
            this.diagnosisTxt.Size = new System.Drawing.Size(458, 66);
            this.diagnosisTxt.TabIndex = 1;
            this.diagnosisTxt.Text = "";
            // 
            // chooseDiagnosisBtn
            // 
            this.chooseDiagnosisBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseDiagnosisBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chooseDiagnosisBtn.Location = new System.Drawing.Point(545, 41);
            this.chooseDiagnosisBtn.Name = "chooseDiagnosisBtn";
            this.chooseDiagnosisBtn.Size = new System.Drawing.Size(36, 29);
            this.chooseDiagnosisBtn.TabIndex = 2;
            this.chooseDiagnosisBtn.Text = "...";
            this.chooseDiagnosisBtn.UseVisualStyleBackColor = true;
            this.chooseDiagnosisBtn.Click += new System.EventHandler(this.chooseDiagnosisBtn_Click);
            // 
            // analysisLbl
            // 
            this.analysisLbl.AutoSize = true;
            this.analysisLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.analysisLbl.Location = new System.Drawing.Point(13, 119);
            this.analysisLbl.Name = "analysisLbl";
            this.analysisLbl.Size = new System.Drawing.Size(171, 13);
            this.analysisLbl.TabIndex = 3;
            this.analysisLbl.Text = "Данные доп исследований:";
            // 
            // analysisGrid
            // 
            this.analysisGrid.AllowUserToAddRows = false;
            this.analysisGrid.AllowUserToDeleteRows = false;
            this.analysisGrid.AllowUserToResizeColumns = false;
            this.analysisGrid.AllowUserToResizeRows = false;
            this.analysisGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.analysisGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.analysisGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.analysisGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.r_object_id,
            this.analysisType,
            this.analysisTypeLbl,
            this.analysis_data,
            this.deleteBtn});
            this.analysisGrid.Location = new System.Drawing.Point(16, 144);
            this.analysisGrid.Name = "analysisGrid";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.analysisGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.analysisGrid.Size = new System.Drawing.Size(523, 197);
            this.analysisGrid.TabIndex = 4;
            this.analysisGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.analysisGrid_CellContentClick);
            // 
            // chooseAnalysisBtn
            // 
            this.chooseAnalysisBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseAnalysisBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chooseAnalysisBtn.Location = new System.Drawing.Point(545, 144);
            this.chooseAnalysisBtn.Name = "chooseAnalysisBtn";
            this.chooseAnalysisBtn.Size = new System.Drawing.Size(36, 29);
            this.chooseAnalysisBtn.TabIndex = 5;
            this.chooseAnalysisBtn.Text = "...";
            this.chooseAnalysisBtn.UseVisualStyleBackColor = true;
            this.chooseAnalysisBtn.Click += new System.EventHandler(this.chooseAnalysisBtn_Click);
            // 
            // print
            // 
            this.print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.print.Location = new System.Drawing.Point(388, 348);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(75, 23);
            this.print.TabIndex = 6;
            this.print.Text = "MsWord";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // epicrisisDateTxt
            // 
            this.epicrisisDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.epicrisisDateTxt.Location = new System.Drawing.Point(81, 13);
            this.epicrisisDateTxt.Name = "epicrisisDateTxt";
            this.epicrisisDateTxt.Size = new System.Drawing.Size(118, 20);
            this.epicrisisDateTxt.TabIndex = 7;
            // 
            // epicrisisDateLbl
            // 
            this.epicrisisDateLbl.AutoSize = true;
            this.epicrisisDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.epicrisisDateLbl.Location = new System.Drawing.Point(34, 17);
            this.epicrisisDateLbl.Name = "epicrisisDateLbl";
            this.epicrisisDateLbl.Size = new System.Drawing.Size(41, 13);
            this.epicrisisDateLbl.TabIndex = 8;
            this.epicrisisDateLbl.Text = "Дата:";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(465, 348);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(74, 23);
            this.closeBtn.TabIndex = 9;
            this.closeBtn.Text = "Сохранить";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // r_object_id
            // 
            this.r_object_id.HeaderText = "object_id";
            this.r_object_id.Name = "r_object_id";
            this.r_object_id.Visible = false;
            // 
            // analysisType
            // 
            this.analysisType.HeaderText = "object_type";
            this.analysisType.Name = "analysisType";
            this.analysisType.Visible = false;
            // 
            // analysisTypeLbl
            // 
            this.analysisTypeLbl.HeaderText = "Тип";
            this.analysisTypeLbl.Name = "analysisTypeLbl";
            // 
            // analysis_data
            // 
            this.analysis_data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.analysis_data.HeaderText = "Данные анализов";
            this.analysis_data.Name = "analysis_data";
            // 
            // deleteBtn
            // 
            this.deleteBtn.HeaderText = "";
            this.deleteBtn.Image = global::Cardiology.Properties.Resources.trash;
            this.deleteBtn.Name = "deleteBtn";
            // 
            // PreoperativeEpicrisiscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 384);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.epicrisisDateLbl);
            this.Controls.Add(this.epicrisisDateTxt);
            this.Controls.Add(this.print);
            this.Controls.Add(this.chooseAnalysisBtn);
            this.Controls.Add(this.analysisGrid);
            this.Controls.Add(this.analysisLbl);
            this.Controls.Add(this.chooseDiagnosisBtn);
            this.Controls.Add(this.diagnosisTxt);
            this.Controls.Add(this.diagnosisLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreoperativeEpicrisiscs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Предоперационный эпикриз";
            ((System.ComponentModel.ISupportInitialize)(this.analysisGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label diagnosisLbl;
        private System.Windows.Forms.RichTextBox diagnosisTxt;
        private System.Windows.Forms.Button chooseDiagnosisBtn;
        private System.Windows.Forms.Label analysisLbl;
        private System.Windows.Forms.DataGridView analysisGrid;
        private System.Windows.Forms.Button chooseAnalysisBtn;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.DateTimePicker epicrisisDateTxt;
        private System.Windows.Forms.Label epicrisisDateLbl;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_object_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn analysisType;
        private System.Windows.Forms.DataGridViewTextBoxColumn analysisTypeLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn analysis_data;
        private System.Windows.Forms.DataGridViewImageColumn deleteBtn;
    }
}