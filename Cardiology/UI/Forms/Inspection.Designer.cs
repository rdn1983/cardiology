namespace Cardiology.UI.Forms
{
    partial class Inspection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inspection));
            this.tabbedContainer = new System.Windows.Forms.TabControl();
            this.baseTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.analysisBtn = new System.Windows.Forms.Button();
            this.kagContainer = new System.Windows.Forms.Panel();
            this.kagInfo = new System.Windows.Forms.Label();
            this.resultTxt = new System.Windows.Forms.RichTextBox();
            this.resultLbl = new System.Windows.Forms.Label();
            this.diagnosisLbl = new System.Windows.Forms.Label();
            this.diagnosisTxt = new System.Windows.Forms.RichTextBox();
            this.inspectionDate = new System.Windows.Forms.DateTimePicker();
            this.inspectionTime = new System.Windows.Forms.DateTimePicker();
            this.complaintsTxt = new System.Windows.Forms.RichTextBox();
            this.inspectionTxt = new System.Windows.Forms.RichTextBox();
            this.kateterPlacementLbl = new System.Windows.Forms.Label();
            this.kateterPlacementTxt = new System.Windows.Forms.RichTextBox();
            this.inspectionLbl = new System.Windows.Forms.Label();
            this.complaintsLbl = new System.Windows.Forms.Label();
            this.analysisTab = new System.Windows.Forms.TabPage();
            this.analysisTabControl1 = new Cardiology.UI.Controls.AnalysisTabControl();
            this.printBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.previousBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cardioDoctorBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabbedContainer.SuspendLayout();
            this.baseTab.SuspendLayout();
            this.kagContainer.SuspendLayout();
            this.analysisTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabbedContainer
            // 
            this.tabbedContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabbedContainer.Controls.Add(this.baseTab);
            this.tabbedContainer.Controls.Add(this.analysisTab);
            this.tabbedContainer.Location = new System.Drawing.Point(3, 1);
            this.tabbedContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabbedContainer.Name = "tabbedContainer";
            this.tabbedContainer.SelectedIndex = 0;
            this.tabbedContainer.ShowToolTips = true;
            this.tabbedContainer.Size = new System.Drawing.Size(1113, 656);
            this.tabbedContainer.TabIndex = 19;
            // 
            // baseTab
            // 
            this.baseTab.Controls.Add(this.label2);
            this.baseTab.Controls.Add(this.cardioDoctorBox);
            this.baseTab.Controls.Add(this.label1);
            this.baseTab.Controls.Add(this.analysisBtn);
            this.baseTab.Controls.Add(this.kagContainer);
            this.baseTab.Controls.Add(this.resultTxt);
            this.baseTab.Controls.Add(this.resultLbl);
            this.baseTab.Controls.Add(this.diagnosisLbl);
            this.baseTab.Controls.Add(this.diagnosisTxt);
            this.baseTab.Controls.Add(this.inspectionDate);
            this.baseTab.Controls.Add(this.inspectionTime);
            this.baseTab.Controls.Add(this.complaintsTxt);
            this.baseTab.Controls.Add(this.inspectionTxt);
            this.baseTab.Controls.Add(this.kateterPlacementLbl);
            this.baseTab.Controls.Add(this.kateterPlacementTxt);
            this.baseTab.Controls.Add(this.inspectionLbl);
            this.baseTab.Controls.Add(this.complaintsLbl);
            this.baseTab.Location = new System.Drawing.Point(4, 25);
            this.baseTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.baseTab.Name = "baseTab";
            this.baseTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.baseTab.Size = new System.Drawing.Size(1105, 627);
            this.baseTab.TabIndex = 0;
            this.baseTab.Text = "Общее";
            this.baseTab.ToolTipText = "14452";
            this.baseTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(1027, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 28);
            this.label1.TabIndex = 18;
            this.toolTip1.SetToolTip(this.label1, "ДЭП 3ст., последствия перенесенного ОНМК, субкомпенсация.\r\nСахарный диабет 2 типа" +
        ", среднетяжелого течения, субкомпенсация.");
            // 
            // analysisBtn
            // 
            this.analysisBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.analysisBtn.Location = new System.Drawing.Point(792, 11);
            this.analysisBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.analysisBtn.Name = "analysisBtn";
            this.analysisBtn.Size = new System.Drawing.Size(284, 28);
            this.analysisBtn.TabIndex = 16;
            this.analysisBtn.Text = "Проверить анализы и обследования";
            this.analysisBtn.UseVisualStyleBackColor = true;
            this.analysisBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // kagContainer
            // 
            this.kagContainer.Controls.Add(this.kagInfo);
            this.kagContainer.Location = new System.Drawing.Point(20, 443);
            this.kagContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kagContainer.Name = "kagContainer";
            this.kagContainer.Size = new System.Drawing.Size(1056, 33);
            this.kagContainer.TabIndex = 15;
            // 
            // kagInfo
            // 
            this.kagInfo.AutoSize = true;
            this.kagInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kagInfo.Location = new System.Drawing.Point(4, 6);
            this.kagInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kagInfo.Name = "kagInfo";
            this.kagInfo.Size = new System.Drawing.Size(872, 17);
            this.kagInfo.TabIndex = 13;
            this.kagInfo.Text = "Пациенту в экстренном порядке была проведена КАГ. Данные КАГ можно просмотреть на" +
    " вкладке  Анализы/КАГ.";
            // 
            // resultTxt
            // 
            this.resultTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTxt.Location = new System.Drawing.Point(20, 533);
            this.resultTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resultTxt.Name = "resultTxt";
            this.resultTxt.Size = new System.Drawing.Size(1055, 83);
            this.resultTxt.TabIndex = 12;
            this.resultTxt.Text = "необходимо продолжить лечение в отделение кардиореанимации";
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultLbl.Location = new System.Drawing.Point(20, 513);
            this.resultLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(162, 17);
            this.resultLbl.TabIndex = 11;
            this.resultLbl.Text = "Заключение обхода:";
            // 
            // diagnosisLbl
            // 
            this.diagnosisLbl.AutoSize = true;
            this.diagnosisLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.diagnosisLbl.Location = new System.Drawing.Point(21, 50);
            this.diagnosisLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.diagnosisLbl.Name = "diagnosisLbl";
            this.diagnosisLbl.Size = new System.Drawing.Size(75, 17);
            this.diagnosisLbl.TabIndex = 10;
            this.diagnosisLbl.Text = "Диагноз:";
            // 
            // diagnosisTxt
            // 
            this.diagnosisTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diagnosisTxt.Location = new System.Drawing.Point(20, 70);
            this.diagnosisTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.diagnosisTxt.Name = "diagnosisTxt";
            this.diagnosisTxt.Size = new System.Drawing.Size(1055, 68);
            this.diagnosisTxt.TabIndex = 2;
            this.diagnosisTxt.Text = "";
            // 
            // inspectionDate
            // 
            this.inspectionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inspectionDate.Location = new System.Drawing.Point(20, 10);
            this.inspectionDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inspectionDate.Name = "inspectionDate";
            this.inspectionDate.Size = new System.Drawing.Size(163, 22);
            this.inspectionDate.TabIndex = 0;
            this.inspectionDate.ValueChanged += new System.EventHandler(this.inspectionDate_ValueChanged);
            // 
            // inspectionTime
            // 
            this.inspectionTime.CustomFormat = "HH:mm tt";
            this.inspectionTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inspectionTime.Location = new System.Drawing.Point(192, 10);
            this.inspectionTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inspectionTime.Name = "inspectionTime";
            this.inspectionTime.ShowUpDown = true;
            this.inspectionTime.Size = new System.Drawing.Size(155, 22);
            this.inspectionTime.TabIndex = 1;
            // 
            // complaintsTxt
            // 
            this.complaintsTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.complaintsTxt.Location = new System.Drawing.Point(20, 166);
            this.complaintsTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.complaintsTxt.Name = "complaintsTxt";
            this.complaintsTxt.Size = new System.Drawing.Size(1055, 62);
            this.complaintsTxt.TabIndex = 3;
            this.complaintsTxt.Text = "жалобы на слабость";
            // 
            // inspectionTxt
            // 
            this.inspectionTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inspectionTxt.Location = new System.Drawing.Point(20, 252);
            this.inspectionTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inspectionTxt.Name = "inspectionTxt";
            this.inspectionTxt.Size = new System.Drawing.Size(1055, 90);
            this.inspectionTxt.TabIndex = 4;
            this.inspectionTxt.Text = resources.GetString("inspectionTxt.Text");
            // 
            // kateterPlacementLbl
            // 
            this.kateterPlacementLbl.AutoSize = true;
            this.kateterPlacementLbl.Location = new System.Drawing.Point(20, 356);
            this.kateterPlacementLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kateterPlacementLbl.Name = "kateterPlacementLbl";
            this.kateterPlacementLbl.Size = new System.Drawing.Size(189, 17);
            this.kateterPlacementLbl.TabIndex = 9;
            this.kateterPlacementLbl.Text = "Место установки катетера:";
            // 
            // kateterPlacementTxt
            // 
            this.kateterPlacementTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kateterPlacementTxt.Location = new System.Drawing.Point(20, 375);
            this.kateterPlacementTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kateterPlacementTxt.Name = "kateterPlacementTxt";
            this.kateterPlacementTxt.Size = new System.Drawing.Size(1055, 59);
            this.kateterPlacementTxt.TabIndex = 5;
            this.kateterPlacementTxt.Text = "Место установки венозного катетера - без особенностей";
            // 
            // inspectionLbl
            // 
            this.inspectionLbl.AutoSize = true;
            this.inspectionLbl.Location = new System.Drawing.Point(16, 233);
            this.inspectionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inspectionLbl.Name = "inspectionLbl";
            this.inspectionLbl.Size = new System.Drawing.Size(93, 17);
            this.inspectionLbl.TabIndex = 8;
            this.inspectionLbl.Text = "Объективно:";
            // 
            // complaintsLbl
            // 
            this.complaintsLbl.AutoSize = true;
            this.complaintsLbl.Location = new System.Drawing.Point(16, 146);
            this.complaintsLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.complaintsLbl.Name = "complaintsLbl";
            this.complaintsLbl.Size = new System.Drawing.Size(124, 17);
            this.complaintsLbl.TabIndex = 7;
            this.complaintsLbl.Text = "Динамика жалоб:";
            // 
            // analysisTab
            // 
            this.analysisTab.Controls.Add(this.analysisTabControl1);
            this.analysisTab.Location = new System.Drawing.Point(4, 25);
            this.analysisTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.analysisTab.Name = "analysisTab";
            this.analysisTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.analysisTab.Size = new System.Drawing.Size(1105, 627);
            this.analysisTab.TabIndex = 1;
            this.analysisTab.Text = "Анализы";
            this.analysisTab.UseVisualStyleBackColor = true;
            // 
            // analysisTabControl1
            // 
            this.analysisTabControl1.AutoSize = true;
            this.analysisTabControl1.Location = new System.Drawing.Point(4, 7);
            this.analysisTabControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.analysisTabControl1.Name = "analysisTabControl1";
            this.analysisTabControl1.Size = new System.Drawing.Size(1091, 609);
            this.analysisTabControl1.TabIndex = 2;
            // 
            // printBtn
            // 
            this.printBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printBtn.Location = new System.Drawing.Point(800, 690);
            this.printBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(316, 28);
            this.printBtn.TabIndex = 18;
            this.printBtn.Text = "Вывод в MSWord";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(1016, 661);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(100, 28);
            this.saveBtn.TabIndex = 17;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.Location = new System.Drawing.Point(908, 661);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(100, 28);
            this.nextBtn.TabIndex = 16;
            this.nextBtn.Text = "Далее";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // previousBtn
            // 
            this.previousBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previousBtn.Location = new System.Drawing.Point(800, 661);
            this.previousBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.previousBtn.Name = "previousBtn";
            this.previousBtn.Size = new System.Drawing.Size(100, 28);
            this.previousBtn.TabIndex = 15;
            this.previousBtn.Text = "Назад";
            this.previousBtn.UseVisualStyleBackColor = true;
            this.previousBtn.Click += new System.EventHandler(this.previousBtn_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            // 
            // cardioDoctorBox
            // 
            this.cardioDoctorBox.FormattingEnabled = true;
            this.cardioDoctorBox.Location = new System.Drawing.Point(538, 12);
            this.cardioDoctorBox.Name = "cardioDoctorBox";
            this.cardioDoctorBox.Size = new System.Drawing.Size(201, 24);
            this.cardioDoctorBox.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Лечащий врач:";
            // 
            // Inspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 720);
            this.Controls.Add(this.tabbedContainer);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.previousBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Inspection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обход";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inspection_FormClosing);
            this.tabbedContainer.ResumeLayout(false);
            this.baseTab.ResumeLayout(false);
            this.baseTab.PerformLayout();
            this.kagContainer.ResumeLayout(false);
            this.kagContainer.PerformLayout();
            this.analysisTab.ResumeLayout(false);
            this.analysisTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabbedContainer;
        private System.Windows.Forms.TabPage baseTab;
        private System.Windows.Forms.RichTextBox resultTxt;
        private System.Windows.Forms.Label resultLbl;
        private System.Windows.Forms.Label diagnosisLbl;
        private System.Windows.Forms.RichTextBox diagnosisTxt;
        private System.Windows.Forms.DateTimePicker inspectionDate;
        private System.Windows.Forms.DateTimePicker inspectionTime;
        private System.Windows.Forms.RichTextBox complaintsTxt;
        private System.Windows.Forms.RichTextBox inspectionTxt;
        private System.Windows.Forms.Label kateterPlacementLbl;
        private System.Windows.Forms.RichTextBox kateterPlacementTxt;
        private System.Windows.Forms.Label inspectionLbl;
        private System.Windows.Forms.Label complaintsLbl;
        private System.Windows.Forms.TabPage analysisTab;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button previousBtn;
        private System.Windows.Forms.Label kagInfo;
        private System.Windows.Forms.Panel kagContainer;
        private System.Windows.Forms.Button analysisBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private Controls.AnalysisTabControl analysisTabControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cardioDoctorBox;
    }
}