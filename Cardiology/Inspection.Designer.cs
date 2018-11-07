namespace Cardiology
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
            this.tabbedAnalysis = new System.Windows.Forms.TabControl();
            this.addAnalysis = new System.Windows.Forms.Button();
            this.isssuedMedsTab = new System.Windows.Forms.TabPage();
            this.skipPrintBtn = new System.Windows.Forms.CheckBox();
            this.selectMedListBtn = new System.Windows.Forms.Button();
            this.addFirstInsBtn = new System.Windows.Forms.Button();
            this.medicinesPnl = new System.Windows.Forms.Panel();
            this.issuedMedicineContainer = new Cardiology.Controls.IssuedMedicineContainer();
            this.addMedicineBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.previousBtn = new System.Windows.Forms.Button();
            this.analysisTypeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uziItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekgItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xRayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.holterItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialistItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabbedContainer.SuspendLayout();
            this.baseTab.SuspendLayout();
            this.kagContainer.SuspendLayout();
            this.analysisTab.SuspendLayout();
            this.isssuedMedsTab.SuspendLayout();
            this.medicinesPnl.SuspendLayout();
            this.analysisTypeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabbedContainer
            // 
            this.tabbedContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabbedContainer.Controls.Add(this.baseTab);
            this.tabbedContainer.Controls.Add(this.analysisTab);
            this.tabbedContainer.Controls.Add(this.isssuedMedsTab);
            this.tabbedContainer.Location = new System.Drawing.Point(2, 1);
            this.tabbedContainer.Name = "tabbedContainer";
            this.tabbedContainer.SelectedIndex = 0;
            this.tabbedContainer.ShowToolTips = true;
            this.tabbedContainer.Size = new System.Drawing.Size(835, 533);
            this.tabbedContainer.TabIndex = 19;
            // 
            // baseTab
            // 
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
            this.baseTab.Location = new System.Drawing.Point(4, 22);
            this.baseTab.Name = "baseTab";
            this.baseTab.Padding = new System.Windows.Forms.Padding(3);
            this.baseTab.Size = new System.Drawing.Size(827, 507);
            this.baseTab.TabIndex = 0;
            this.baseTab.Text = "Общее";
            this.baseTab.ToolTipText = "14452";
            this.baseTab.UseVisualStyleBackColor = true;
            // 
            // analysisBtn
            // 
            this.analysisBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.analysisBtn.Location = new System.Drawing.Point(594, 9);
            this.analysisBtn.Name = "analysisBtn";
            this.analysisBtn.Size = new System.Drawing.Size(213, 23);
            this.analysisBtn.TabIndex = 16;
            this.analysisBtn.Text = "Проверить анализы и обследования";
            this.analysisBtn.UseVisualStyleBackColor = true;
            this.analysisBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // kagContainer
            // 
            this.kagContainer.Controls.Add(this.kagInfo);
            this.kagContainer.Location = new System.Drawing.Point(15, 360);
            this.kagContainer.Name = "kagContainer";
            this.kagContainer.Size = new System.Drawing.Size(792, 27);
            this.kagContainer.TabIndex = 15;
            // 
            // kagInfo
            // 
            this.kagInfo.AutoSize = true;
            this.kagInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kagInfo.Location = new System.Drawing.Point(3, 5);
            this.kagInfo.Name = "kagInfo";
            this.kagInfo.Size = new System.Drawing.Size(700, 13);
            this.kagInfo.TabIndex = 13;
            this.kagInfo.Text = "Пациенту в экстренном порядке была проведена КАГ. Данные КАГ можно просмотреть на" +
    " вкладке  Анализы/КАГ.";
            // 
            // resultTxt
            // 
            this.resultTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTxt.Location = new System.Drawing.Point(15, 433);
            this.resultTxt.Name = "resultTxt";
            this.resultTxt.Size = new System.Drawing.Size(792, 68);
            this.resultTxt.TabIndex = 12;
            this.resultTxt.Text = "необходимо продолжить лечение в отделение кардиореанимации";
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultLbl.Location = new System.Drawing.Point(15, 417);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(128, 13);
            this.resultLbl.TabIndex = 11;
            this.resultLbl.Text = "Заключение обхода:";
            // 
            // diagnosisLbl
            // 
            this.diagnosisLbl.AutoSize = true;
            this.diagnosisLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.diagnosisLbl.Location = new System.Drawing.Point(16, 41);
            this.diagnosisLbl.Name = "diagnosisLbl";
            this.diagnosisLbl.Size = new System.Drawing.Size(62, 13);
            this.diagnosisLbl.TabIndex = 10;
            this.diagnosisLbl.Text = "Диагноз:";
            // 
            // diagnosisTxt
            // 
            this.diagnosisTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diagnosisTxt.Location = new System.Drawing.Point(15, 57);
            this.diagnosisTxt.Name = "diagnosisTxt";
            this.diagnosisTxt.Size = new System.Drawing.Size(792, 56);
            this.diagnosisTxt.TabIndex = 2;
            this.diagnosisTxt.Text = "";
            // 
            // inspectionDate
            // 
            this.inspectionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inspectionDate.Location = new System.Drawing.Point(15, 8);
            this.inspectionDate.Name = "inspectionDate";
            this.inspectionDate.Size = new System.Drawing.Size(123, 20);
            this.inspectionDate.TabIndex = 0;
            this.inspectionDate.ValueChanged += new System.EventHandler(this.inspectionDate_ValueChanged);
            // 
            // inspectionTime
            // 
            this.inspectionTime.CustomFormat = "HH:mm tt";
            this.inspectionTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inspectionTime.Location = new System.Drawing.Point(144, 8);
            this.inspectionTime.Name = "inspectionTime";
            this.inspectionTime.ShowUpDown = true;
            this.inspectionTime.Size = new System.Drawing.Size(117, 20);
            this.inspectionTime.TabIndex = 1;
            // 
            // complaintsTxt
            // 
            this.complaintsTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.complaintsTxt.Location = new System.Drawing.Point(15, 135);
            this.complaintsTxt.Name = "complaintsTxt";
            this.complaintsTxt.Size = new System.Drawing.Size(792, 51);
            this.complaintsTxt.TabIndex = 3;
            this.complaintsTxt.Text = "жалобы на слабость";
            // 
            // inspectionTxt
            // 
            this.inspectionTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inspectionTxt.Location = new System.Drawing.Point(15, 205);
            this.inspectionTxt.Name = "inspectionTxt";
            this.inspectionTxt.Size = new System.Drawing.Size(792, 74);
            this.inspectionTxt.TabIndex = 4;
            this.inspectionTxt.Text = resources.GetString("inspectionTxt.Text");
            // 
            // kateterPlacementLbl
            // 
            this.kateterPlacementLbl.AutoSize = true;
            this.kateterPlacementLbl.Location = new System.Drawing.Point(15, 289);
            this.kateterPlacementLbl.Name = "kateterPlacementLbl";
            this.kateterPlacementLbl.Size = new System.Drawing.Size(146, 13);
            this.kateterPlacementLbl.TabIndex = 9;
            this.kateterPlacementLbl.Text = "Место установки катетера:";
            // 
            // kateterPlacementTxt
            // 
            this.kateterPlacementTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kateterPlacementTxt.Location = new System.Drawing.Point(15, 305);
            this.kateterPlacementTxt.Name = "kateterPlacementTxt";
            this.kateterPlacementTxt.Size = new System.Drawing.Size(792, 49);
            this.kateterPlacementTxt.TabIndex = 5;
            this.kateterPlacementTxt.Text = "Место установки венозного катетера - без особенностей";
            // 
            // inspectionLbl
            // 
            this.inspectionLbl.AutoSize = true;
            this.inspectionLbl.Location = new System.Drawing.Point(12, 189);
            this.inspectionLbl.Name = "inspectionLbl";
            this.inspectionLbl.Size = new System.Drawing.Size(72, 13);
            this.inspectionLbl.TabIndex = 8;
            this.inspectionLbl.Text = "Объективно:";
            // 
            // complaintsLbl
            // 
            this.complaintsLbl.AutoSize = true;
            this.complaintsLbl.Location = new System.Drawing.Point(12, 119);
            this.complaintsLbl.Name = "complaintsLbl";
            this.complaintsLbl.Size = new System.Drawing.Size(98, 13);
            this.complaintsLbl.TabIndex = 7;
            this.complaintsLbl.Text = "Динамика жалоб:";
            // 
            // analysisTab
            // 
            this.analysisTab.Controls.Add(this.tabbedAnalysis);
            this.analysisTab.Controls.Add(this.addAnalysis);
            this.analysisTab.Location = new System.Drawing.Point(4, 22);
            this.analysisTab.Name = "analysisTab";
            this.analysisTab.Padding = new System.Windows.Forms.Padding(3);
            this.analysisTab.Size = new System.Drawing.Size(827, 507);
            this.analysisTab.TabIndex = 1;
            this.analysisTab.Text = "Анализы";
            this.analysisTab.UseVisualStyleBackColor = true;
            // 
            // tabbedAnalysis
            // 
            this.tabbedAnalysis.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabbedAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabbedAnalysis.Location = new System.Drawing.Point(6, 3);
            this.tabbedAnalysis.Multiline = true;
            this.tabbedAnalysis.Name = "tabbedAnalysis";
            this.tabbedAnalysis.SelectedIndex = 0;
            this.tabbedAnalysis.Size = new System.Drawing.Size(781, 500);
            this.tabbedAnalysis.TabIndex = 8;
            // 
            // addAnalysis
            // 
            this.addAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addAnalysis.Image = global::Cardiology.Properties.Resources.addd1;
            this.addAnalysis.Location = new System.Drawing.Point(793, 6);
            this.addAnalysis.Name = "addAnalysis";
            this.addAnalysis.Size = new System.Drawing.Size(28, 28);
            this.addAnalysis.TabIndex = 1;
            this.addAnalysis.UseVisualStyleBackColor = true;
            this.addAnalysis.Click += new System.EventHandler(this.addAnalysisBtn_Click);
            // 
            // isssuedMedsTab
            // 
            this.isssuedMedsTab.Controls.Add(this.skipPrintBtn);
            this.isssuedMedsTab.Controls.Add(this.selectMedListBtn);
            this.isssuedMedsTab.Controls.Add(this.addFirstInsBtn);
            this.isssuedMedsTab.Controls.Add(this.medicinesPnl);
            this.isssuedMedsTab.Controls.Add(this.addMedicineBtn);
            this.isssuedMedsTab.Location = new System.Drawing.Point(4, 22);
            this.isssuedMedsTab.Name = "isssuedMedsTab";
            this.isssuedMedsTab.Size = new System.Drawing.Size(827, 507);
            this.isssuedMedsTab.TabIndex = 2;
            this.isssuedMedsTab.Text = "Назначения";
            this.isssuedMedsTab.UseVisualStyleBackColor = true;
            // 
            // skipPrintBtn
            // 
            this.skipPrintBtn.AutoSize = true;
            this.skipPrintBtn.Location = new System.Drawing.Point(689, 110);
            this.skipPrintBtn.Name = "skipPrintBtn";
            this.skipPrintBtn.Size = new System.Drawing.Size(142, 17);
            this.skipPrintBtn.TabIndex = 6;
            this.skipPrintBtn.Text = "не выводить на печать";
            this.skipPrintBtn.UseVisualStyleBackColor = true;
            // 
            // selectMedListBtn
            // 
            this.selectMedListBtn.Location = new System.Drawing.Point(689, 66);
            this.selectMedListBtn.Name = "selectMedListBtn";
            this.selectMedListBtn.Size = new System.Drawing.Size(132, 38);
            this.selectMedListBtn.TabIndex = 5;
            this.selectMedListBtn.Text = "Добавить из листа назначений";
            this.selectMedListBtn.UseVisualStyleBackColor = true;
            this.selectMedListBtn.Click += new System.EventHandler(this.selectMedListBtn_Click);
            // 
            // addFirstInsBtn
            // 
            this.addFirstInsBtn.Location = new System.Drawing.Point(689, 18);
            this.addFirstInsBtn.Name = "addFirstInsBtn";
            this.addFirstInsBtn.Size = new System.Drawing.Size(132, 42);
            this.addFirstInsBtn.TabIndex = 4;
            this.addFirstInsBtn.Text = "Добавить из первички";
            this.addFirstInsBtn.UseVisualStyleBackColor = true;
            this.addFirstInsBtn.Click += new System.EventHandler(this.addFirstInsBtn_Click);
            // 
            // medicinesPnl
            // 
            this.medicinesPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.medicinesPnl.Controls.Add(this.issuedMedicineContainer);
            this.medicinesPnl.Location = new System.Drawing.Point(3, 15);
            this.medicinesPnl.Name = "medicinesPnl";
            this.medicinesPnl.Size = new System.Drawing.Size(630, 489);
            this.medicinesPnl.TabIndex = 3;
            // 
            // issuedMedicineContainer
            // 
            this.issuedMedicineContainer.AutoSize = true;
            this.issuedMedicineContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.issuedMedicineContainer.Location = new System.Drawing.Point(13, 12);
            this.issuedMedicineContainer.Name = "issuedMedicineContainer";
            this.issuedMedicineContainer.Size = new System.Drawing.Size(6, 6);
            this.issuedMedicineContainer.TabIndex = 0;
            // 
            // addMedicineBtn
            // 
            this.addMedicineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addMedicineBtn.Image = global::Cardiology.Properties.Resources.addd1;
            this.addMedicineBtn.Location = new System.Drawing.Point(641, 15);
            this.addMedicineBtn.Name = "addMedicineBtn";
            this.addMedicineBtn.Size = new System.Drawing.Size(28, 28);
            this.addMedicineBtn.TabIndex = 2;
            this.addMedicineBtn.UseVisualStyleBackColor = true;
            this.addMedicineBtn.Click += new System.EventHandler(this.addMedicineBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printBtn.Location = new System.Drawing.Point(600, 561);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(237, 23);
            this.printBtn.TabIndex = 18;
            this.printBtn.Text = "Вывод в MSWord";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(762, 537);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 17;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.Location = new System.Drawing.Point(681, 537);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 16;
            this.nextBtn.Text = "Далее";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // previousBtn
            // 
            this.previousBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previousBtn.Location = new System.Drawing.Point(600, 537);
            this.previousBtn.Name = "previousBtn";
            this.previousBtn.Size = new System.Drawing.Size(75, 23);
            this.previousBtn.TabIndex = 15;
            this.previousBtn.Text = "Назад";
            this.previousBtn.UseVisualStyleBackColor = true;
            this.previousBtn.Click += new System.EventHandler(this.previousBtn_Click);
            // 
            // analysisTypeMenu
            // 
            this.analysisTypeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uziItem,
            this.bloodItem,
            this.ekgItem,
            this.xRayItem,
            this.holterItem,
            this.specialistItem});
            this.analysisTypeMenu.Name = "analysisTypeMenu";
            this.analysisTypeMenu.Size = new System.Drawing.Size(224, 136);
            // 
            // uziItem
            // 
            this.uziItem.Name = "uziItem";
            this.uziItem.Size = new System.Drawing.Size(223, 22);
            this.uziItem.Text = "УЗИ";
            this.uziItem.Click += new System.EventHandler(this.uziItem_Click);
            // 
            // bloodItem
            // 
            this.bloodItem.Name = "bloodItem";
            this.bloodItem.Size = new System.Drawing.Size(223, 22);
            this.bloodItem.Text = "Анализы крови";
            this.bloodItem.Click += new System.EventHandler(this.bloodItem_Click);
            // 
            // ekgItem
            // 
            this.ekgItem.Name = "ekgItem";
            this.ekgItem.Size = new System.Drawing.Size(223, 22);
            this.ekgItem.Text = "ЭКГ";
            this.ekgItem.Click += new System.EventHandler(this.ekgItem_Click);
            // 
            // xRayItem
            // 
            this.xRayItem.Name = "xRayItem";
            this.xRayItem.Size = new System.Drawing.Size(223, 22);
            this.xRayItem.Text = "Рентген";
            this.xRayItem.Click += new System.EventHandler(this.xRayItem_Click);
            // 
            // holterItem
            // 
            this.holterItem.Name = "holterItem";
            this.holterItem.Size = new System.Drawing.Size(223, 22);
            this.holterItem.Text = "Холтер";
            this.holterItem.Click += new System.EventHandler(this.holterItem_Click);
            // 
            // specialistItem
            // 
            this.specialistItem.Name = "specialistItem";
            this.specialistItem.Size = new System.Drawing.Size(223, 22);
            this.specialistItem.Text = "Заключения специалистов";
            this.specialistItem.Click += new System.EventHandler(this.specialistItem_Click);
            // 
            // Inspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 585);
            this.Controls.Add(this.tabbedContainer);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.previousBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inspection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обход";
            this.tabbedContainer.ResumeLayout(false);
            this.baseTab.ResumeLayout(false);
            this.baseTab.PerformLayout();
            this.kagContainer.ResumeLayout(false);
            this.kagContainer.PerformLayout();
            this.analysisTab.ResumeLayout(false);
            this.isssuedMedsTab.ResumeLayout(false);
            this.isssuedMedsTab.PerformLayout();
            this.medicinesPnl.ResumeLayout(false);
            this.medicinesPnl.PerformLayout();
            this.analysisTypeMenu.ResumeLayout(false);
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
        private System.Windows.Forms.Button addAnalysis;
        private System.Windows.Forms.TabPage isssuedMedsTab;
        private System.Windows.Forms.Button addMedicineBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button previousBtn;
        private System.Windows.Forms.ContextMenuStrip analysisTypeMenu;
        private System.Windows.Forms.ToolStripMenuItem uziItem;
        private System.Windows.Forms.ToolStripMenuItem bloodItem;
        private System.Windows.Forms.ToolStripMenuItem ekgItem;
        private System.Windows.Forms.ToolStripMenuItem xRayItem;
        private System.Windows.Forms.ToolStripMenuItem holterItem;
        private System.Windows.Forms.ToolStripMenuItem specialistItem;
        private System.Windows.Forms.TabControl tabbedAnalysis;
        private System.Windows.Forms.Panel medicinesPnl;
        private System.Windows.Forms.Label kagInfo;
        private System.Windows.Forms.Panel kagContainer;
        private Controls.IssuedMedicineContainer issuedMedicineContainer;
        private System.Windows.Forms.Button analysisBtn;
        private System.Windows.Forms.Button selectMedListBtn;
        private System.Windows.Forms.Button addFirstInsBtn;
        private System.Windows.Forms.CheckBox skipPrintBtn;
    }
}