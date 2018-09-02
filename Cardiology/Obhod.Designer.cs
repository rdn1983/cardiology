namespace Cardiology
{
    partial class Obhod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Obhod));
            this.inspectionDate = new System.Windows.Forms.DateTimePicker();
            this.inspectionTime = new System.Windows.Forms.DateTimePicker();
            this.diagnosisTxt = new System.Windows.Forms.RichTextBox();
            this.complaintsTxt = new System.Windows.Forms.RichTextBox();
            this.inspectionTxt = new System.Windows.Forms.RichTextBox();
            this.kateterPlacementTxt = new System.Windows.Forms.RichTextBox();
            this.checkAnalyzesBtn = new System.Windows.Forms.Button();
            this.complaintsLbl = new System.Windows.Forms.Label();
            this.inspectionLbl = new System.Windows.Forms.Label();
            this.kateterPlacementLbl = new System.Windows.Forms.Label();
            this.previousBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.tabbedContainer = new System.Windows.Forms.TabControl();
            this.baseTab = new System.Windows.Forms.TabPage();
            this.resultTxt = new System.Windows.Forms.RichTextBox();
            this.resultLbl = new System.Windows.Forms.Label();
            this.diagnosisLbl = new System.Windows.Forms.Label();
            this.analysisTab = new System.Windows.Forms.TabPage();
            this.addAnalysis = new System.Windows.Forms.Button();
            this.ekgContainer = new System.Windows.Forms.TableLayoutPanel();
            this.isssuedMedsTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.issuedMedicineControl1 = new Cardiology.IssuedMedicineControl();
            this.addMedicineBtn = new System.Windows.Forms.Button();
            this.tabbedContainer.SuspendLayout();
            this.baseTab.SuspendLayout();
            this.analysisTab.SuspendLayout();
            this.isssuedMedsTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inspectionDate
            // 
            this.inspectionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inspectionDate.Location = new System.Drawing.Point(15, 8);
            this.inspectionDate.Name = "inspectionDate";
            this.inspectionDate.Size = new System.Drawing.Size(123, 20);
            this.inspectionDate.TabIndex = 0;
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
            // diagnosisTxt
            // 
            this.diagnosisTxt.Location = new System.Drawing.Point(15, 57);
            this.diagnosisTxt.Name = "diagnosisTxt";
            this.diagnosisTxt.Size = new System.Drawing.Size(640, 56);
            this.diagnosisTxt.TabIndex = 2;
            this.diagnosisTxt.Text = "";
            // 
            // complaintsTxt
            // 
            this.complaintsTxt.Location = new System.Drawing.Point(15, 135);
            this.complaintsTxt.Name = "complaintsTxt";
            this.complaintsTxt.Size = new System.Drawing.Size(640, 51);
            this.complaintsTxt.TabIndex = 3;
            this.complaintsTxt.Text = "";
            // 
            // inspectionTxt
            // 
            this.inspectionTxt.Location = new System.Drawing.Point(15, 205);
            this.inspectionTxt.Name = "inspectionTxt";
            this.inspectionTxt.Size = new System.Drawing.Size(640, 74);
            this.inspectionTxt.TabIndex = 4;
            this.inspectionTxt.Text = "";
            // 
            // kateterPlacementTxt
            // 
            this.kateterPlacementTxt.Location = new System.Drawing.Point(15, 300);
            this.kateterPlacementTxt.Name = "kateterPlacementTxt";
            this.kateterPlacementTxt.Size = new System.Drawing.Size(640, 49);
            this.kateterPlacementTxt.TabIndex = 5;
            this.kateterPlacementTxt.Text = "Место установки венозного катетера - без особенностей";
            // 
            // checkAnalyzesBtn
            // 
            this.checkAnalyzesBtn.Location = new System.Drawing.Point(661, 57);
            this.checkAnalyzesBtn.Name = "checkAnalyzesBtn";
            this.checkAnalyzesBtn.Size = new System.Drawing.Size(130, 96);
            this.checkAnalyzesBtn.TabIndex = 6;
            this.checkAnalyzesBtn.Text = "Проверить анализы и обследования";
            this.checkAnalyzesBtn.UseVisualStyleBackColor = true;
            this.checkAnalyzesBtn.Click += new System.EventHandler(this.checkAnalyzesBtn_Click);
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
            // inspectionLbl
            // 
            this.inspectionLbl.AutoSize = true;
            this.inspectionLbl.Location = new System.Drawing.Point(12, 189);
            this.inspectionLbl.Name = "inspectionLbl";
            this.inspectionLbl.Size = new System.Drawing.Size(72, 13);
            this.inspectionLbl.TabIndex = 8;
            this.inspectionLbl.Text = "Объективно:";
            // 
            // kateterPlacementLbl
            // 
            this.kateterPlacementLbl.AutoSize = true;
            this.kateterPlacementLbl.Location = new System.Drawing.Point(15, 284);
            this.kateterPlacementLbl.Name = "kateterPlacementLbl";
            this.kateterPlacementLbl.Size = new System.Drawing.Size(146, 13);
            this.kateterPlacementLbl.TabIndex = 9;
            this.kateterPlacementLbl.Text = "Место установки катетера:";
            // 
            // previousBtn
            // 
            this.previousBtn.Location = new System.Drawing.Point(608, 475);
            this.previousBtn.Name = "previousBtn";
            this.previousBtn.Size = new System.Drawing.Size(75, 23);
            this.previousBtn.TabIndex = 10;
            this.previousBtn.Text = "Назад";
            this.previousBtn.UseVisualStyleBackColor = true;
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(689, 475);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 11;
            this.nextBtn.Text = "Далее";
            this.nextBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(770, 475);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 12;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(608, 499);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(237, 23);
            this.printBtn.TabIndex = 13;
            this.printBtn.Text = "Вывод в MSWord";
            this.printBtn.UseVisualStyleBackColor = true;
            // 
            // tabbedContainer
            // 
            this.tabbedContainer.Controls.Add(this.baseTab);
            this.tabbedContainer.Controls.Add(this.analysisTab);
            this.tabbedContainer.Controls.Add(this.isssuedMedsTab);
            this.tabbedContainer.Location = new System.Drawing.Point(1, 3);
            this.tabbedContainer.Name = "tabbedContainer";
            this.tabbedContainer.SelectedIndex = 0;
            this.tabbedContainer.Size = new System.Drawing.Size(848, 468);
            this.tabbedContainer.TabIndex = 14;
            // 
            // baseTab
            // 
            this.baseTab.Controls.Add(this.resultTxt);
            this.baseTab.Controls.Add(this.resultLbl);
            this.baseTab.Controls.Add(this.diagnosisLbl);
            this.baseTab.Controls.Add(this.diagnosisTxt);
            this.baseTab.Controls.Add(this.inspectionDate);
            this.baseTab.Controls.Add(this.inspectionTime);
            this.baseTab.Controls.Add(this.complaintsTxt);
            this.baseTab.Controls.Add(this.inspectionTxt);
            this.baseTab.Controls.Add(this.checkAnalyzesBtn);
            this.baseTab.Controls.Add(this.kateterPlacementLbl);
            this.baseTab.Controls.Add(this.kateterPlacementTxt);
            this.baseTab.Controls.Add(this.inspectionLbl);
            this.baseTab.Controls.Add(this.complaintsLbl);
            this.baseTab.Location = new System.Drawing.Point(4, 22);
            this.baseTab.Name = "baseTab";
            this.baseTab.Padding = new System.Windows.Forms.Padding(3);
            this.baseTab.Size = new System.Drawing.Size(840, 442);
            this.baseTab.TabIndex = 0;
            this.baseTab.Text = "Общее";
            this.baseTab.UseVisualStyleBackColor = true;
            // 
            // resultTxt
            // 
            this.resultTxt.Location = new System.Drawing.Point(15, 368);
            this.resultTxt.Name = "resultTxt";
            this.resultTxt.Size = new System.Drawing.Size(640, 68);
            this.resultTxt.TabIndex = 12;
            this.resultTxt.Text = "";
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultLbl.Location = new System.Drawing.Point(15, 352);
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
            // analysisTab
            // 
            this.analysisTab.Controls.Add(this.addAnalysis);
            this.analysisTab.Controls.Add(this.ekgContainer);
            this.analysisTab.Location = new System.Drawing.Point(4, 22);
            this.analysisTab.Name = "analysisTab";
            this.analysisTab.Padding = new System.Windows.Forms.Padding(3);
            this.analysisTab.Size = new System.Drawing.Size(840, 442);
            this.analysisTab.TabIndex = 1;
            this.analysisTab.Text = "Анализы";
            this.analysisTab.UseVisualStyleBackColor = true;
            // 
            // addAnalysis
            // 
            this.addAnalysis.Image = global::Cardiology.Properties.Resources.addd1;
            this.addAnalysis.Location = new System.Drawing.Point(806, 6);
            this.addAnalysis.Name = "addAnalysis";
            this.addAnalysis.Size = new System.Drawing.Size(28, 28);
            this.addAnalysis.TabIndex = 1;
            this.addAnalysis.UseVisualStyleBackColor = true;
            // 
            // ekgContainer
            // 
            this.ekgContainer.AutoSize = true;
            this.ekgContainer.ColumnCount = 1;
            this.ekgContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ekgContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ekgContainer.Location = new System.Drawing.Point(7, 6);
            this.ekgContainer.Name = "ekgContainer";
            this.ekgContainer.RowCount = 1;
            this.ekgContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ekgContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ekgContainer.Size = new System.Drawing.Size(571, 54);
            this.ekgContainer.TabIndex = 0;
            // 
            // isssuedMedsTab
            // 
            this.isssuedMedsTab.Controls.Add(this.panel1);
            this.isssuedMedsTab.Controls.Add(this.addMedicineBtn);
            this.isssuedMedsTab.Location = new System.Drawing.Point(4, 22);
            this.isssuedMedsTab.Name = "isssuedMedsTab";
            this.isssuedMedsTab.Size = new System.Drawing.Size(840, 442);
            this.isssuedMedsTab.TabIndex = 2;
            this.isssuedMedsTab.Text = "Назначения";
            this.isssuedMedsTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.issuedMedicineControl1);
            this.panel1.Location = new System.Drawing.Point(7, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 413);
            this.panel1.TabIndex = 3;
            // 
            // issuedMedicineControl1
            // 
            this.issuedMedicineControl1.AutoSize = true;
            this.issuedMedicineControl1.Location = new System.Drawing.Point(12, 18);
            this.issuedMedicineControl1.Name = "issuedMedicineControl1";
            this.issuedMedicineControl1.Size = new System.Drawing.Size(6, 6);
            this.issuedMedicineControl1.TabIndex = 0;
            // 
            // addMedicineBtn
            // 
            this.addMedicineBtn.Image = global::Cardiology.Properties.Resources.addd1;
            this.addMedicineBtn.Location = new System.Drawing.Point(725, 15);
            this.addMedicineBtn.Name = "addMedicineBtn";
            this.addMedicineBtn.Size = new System.Drawing.Size(28, 28);
            this.addMedicineBtn.TabIndex = 2;
            this.addMedicineBtn.UseVisualStyleBackColor = true;
            this.addMedicineBtn.Click += new System.EventHandler(this.addMedicineBtn_Click);
            // 
            // Obhod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 555);
            this.Controls.Add(this.tabbedContainer);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.previousBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Obhod";
            this.Text = "Обход";
            this.tabbedContainer.ResumeLayout(false);
            this.baseTab.ResumeLayout(false);
            this.baseTab.PerformLayout();
            this.analysisTab.ResumeLayout(false);
            this.analysisTab.PerformLayout();
            this.isssuedMedsTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker inspectionDate;
        private System.Windows.Forms.DateTimePicker inspectionTime;
        private System.Windows.Forms.RichTextBox diagnosisTxt;
        private System.Windows.Forms.RichTextBox complaintsTxt;
        private System.Windows.Forms.RichTextBox inspectionTxt;
        private System.Windows.Forms.RichTextBox kateterPlacementTxt;
        private System.Windows.Forms.Button checkAnalyzesBtn;
        private System.Windows.Forms.Label complaintsLbl;
        private System.Windows.Forms.Label inspectionLbl;
        private System.Windows.Forms.Label kateterPlacementLbl;
        private System.Windows.Forms.Button previousBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.TabControl tabbedContainer;
        private System.Windows.Forms.TabPage baseTab;
        private System.Windows.Forms.TabPage analysisTab;
        private System.Windows.Forms.TableLayoutPanel ekgContainer;
        private System.Windows.Forms.RichTextBox resultTxt;
        private System.Windows.Forms.Label resultLbl;
        private System.Windows.Forms.Label diagnosisLbl;
        private System.Windows.Forms.TabPage isssuedMedsTab;
        private IssuedMedicineControl issuedMedicineControl1;
        private System.Windows.Forms.Button addAnalysis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addMedicineBtn;
    }
}