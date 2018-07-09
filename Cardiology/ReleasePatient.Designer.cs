namespace Cardiology
{
    partial class ReleasePatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReleasePatient));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.releaseData = new System.Windows.Forms.TabPage();
            this.releasePatientBtn = new System.Windows.Forms.Button();
            this.sickListBox = new System.Windows.Forms.GroupBox();
            this.longEndDateTxt = new System.Windows.Forms.DateTimePicker();
            this.longEndDateLbl = new System.Windows.Forms.Label();
            this.longStartDateTxt = new System.Windows.Forms.DateTimePicker();
            this.longStartDateLnl = new System.Windows.Forms.Label();
            this.longSicklistNumTxt = new System.Windows.Forms.TextBox();
            this.longSicklistNumLbl = new System.Windows.Forms.Label();
            this.sickListEndDateTxt = new System.Windows.Forms.DateTimePicker();
            this.sickListStartDateTxt = new System.Windows.Forms.DateTimePicker();
            this.sickListEndDateLbl = new System.Windows.Forms.Label();
            this.sickListStartDateLbl = new System.Windows.Forms.Label();
            this.sickListNumTxt = new System.Windows.Forms.TextBox();
            this.sickListNumLbl = new System.Windows.Forms.Label();
            this.getWorkInfoBtn = new System.Windows.Forms.Button();
            this.releaseDateBox = new System.Windows.Forms.GroupBox();
            this.releaseDateTxt = new System.Windows.Forms.DateTimePicker();
            this.releaseOkrDateBox = new System.Windows.Forms.GroupBox();
            this.releaseOkrDateTxt = new System.Windows.Forms.DateTimePicker();
            this.sickListDataPnl = new System.Windows.Forms.GroupBox();
            this.sickListNeedBtn = new System.Windows.Forms.RadioButton();
            this.sickListNotNeedBtn = new System.Windows.Forms.RadioButton();
            this.releaseVariants = new System.Windows.Forms.GroupBox();
            this.refusedBtn = new System.Windows.Forms.RadioButton();
            this.movedToCardioBtn = new System.Windows.Forms.RadioButton();
            this.releaseBtn = new System.Windows.Forms.RadioButton();
            this.addIssuedMedicineBtn = new System.Windows.Forms.Button();
            this.issuedMedicine0 = new System.Windows.Forms.TextBox();
            this.issuedMedicineTab = new System.Windows.Forms.TabPage();
            this.issuedMedicineBox = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.releaseData.SuspendLayout();
            this.sickListBox.SuspendLayout();
            this.releaseDateBox.SuspendLayout();
            this.releaseOkrDateBox.SuspendLayout();
            this.sickListDataPnl.SuspendLayout();
            this.releaseVariants.SuspendLayout();
            this.issuedMedicineTab.SuspendLayout();
            this.issuedMedicineBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.releaseData);
            this.tabControl1.Controls.Add(this.issuedMedicineTab);
            this.tabControl1.Location = new System.Drawing.Point(4, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(377, 465);
            this.tabControl1.TabIndex = 0;
            // 
            // releaseData
            // 
            this.releaseData.Controls.Add(this.releaseVariants);
            this.releaseData.Controls.Add(this.releasePatientBtn);
            this.releaseData.Controls.Add(this.sickListBox);
            this.releaseData.Controls.Add(this.releaseDateBox);
            this.releaseData.Controls.Add(this.releaseOkrDateBox);
            this.releaseData.Location = new System.Drawing.Point(4, 22);
            this.releaseData.Name = "releaseData";
            this.releaseData.Padding = new System.Windows.Forms.Padding(3);
            this.releaseData.Size = new System.Drawing.Size(369, 439);
            this.releaseData.TabIndex = 0;
            this.releaseData.Text = "Данные";
            this.releaseData.UseVisualStyleBackColor = true;
            // 
            // releasePatientBtn
            // 
            this.releasePatientBtn.Location = new System.Drawing.Point(226, 393);
            this.releasePatientBtn.Name = "releasePatientBtn";
            this.releasePatientBtn.Size = new System.Drawing.Size(131, 34);
            this.releasePatientBtn.TabIndex = 3;
            this.releasePatientBtn.Text = "Сохранить";
            this.releasePatientBtn.UseVisualStyleBackColor = true;
            this.releasePatientBtn.Click += new System.EventHandler(this.releasePatientBtn_Click);
            // 
            // sickListBox
            // 
            this.sickListBox.Controls.Add(this.sickListDataPnl);
            this.sickListBox.Controls.Add(this.sickListNotNeedBtn);
            this.sickListBox.Controls.Add(this.sickListNeedBtn);
            this.sickListBox.Controls.Add(this.getWorkInfoBtn);
            this.sickListBox.Location = new System.Drawing.Point(6, 77);
            this.sickListBox.Name = "sickListBox";
            this.sickListBox.Size = new System.Drawing.Size(351, 204);
            this.sickListBox.TabIndex = 2;
            this.sickListBox.TabStop = false;
            this.sickListBox.Text = "Лист нетрудоспособности";
            // 
            // longEndDateTxt
            // 
            this.longEndDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.longEndDateTxt.Location = new System.Drawing.Point(197, 92);
            this.longEndDateTxt.Name = "longEndDateTxt";
            this.longEndDateTxt.Size = new System.Drawing.Size(130, 20);
            this.longEndDateTxt.TabIndex = 15;
            // 
            // longEndDateLbl
            // 
            this.longEndDateLbl.AutoSize = true;
            this.longEndDateLbl.Location = new System.Drawing.Point(170, 94);
            this.longEndDateLbl.Name = "longEndDateLbl";
            this.longEndDateLbl.Size = new System.Drawing.Size(19, 13);
            this.longEndDateLbl.TabIndex = 14;
            this.longEndDateLbl.Text = "по";
            // 
            // longStartDateTxt
            // 
            this.longStartDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.longStartDateTxt.Location = new System.Drawing.Point(30, 94);
            this.longStartDateTxt.Name = "longStartDateTxt";
            this.longStartDateTxt.Size = new System.Drawing.Size(134, 20);
            this.longStartDateTxt.TabIndex = 13;
            // 
            // longStartDateLnl
            // 
            this.longStartDateLnl.AutoSize = true;
            this.longStartDateLnl.Location = new System.Drawing.Point(11, 98);
            this.longStartDateLnl.Name = "longStartDateLnl";
            this.longStartDateLnl.Size = new System.Drawing.Size(13, 13);
            this.longStartDateLnl.TabIndex = 12;
            this.longStartDateLnl.Text = "с";
            // 
            // longSicklistNumTxt
            // 
            this.longSicklistNumTxt.Location = new System.Drawing.Point(30, 69);
            this.longSicklistNumTxt.Name = "longSicklistNumTxt";
            this.longSicklistNumTxt.Size = new System.Drawing.Size(297, 20);
            this.longSicklistNumTxt.TabIndex = 11;
            // 
            // longSicklistNumLbl
            // 
            this.longSicklistNumLbl.AutoSize = true;
            this.longSicklistNumLbl.Location = new System.Drawing.Point(6, 72);
            this.longSicklistNumLbl.Name = "longSicklistNumLbl";
            this.longSicklistNumLbl.Size = new System.Drawing.Size(18, 13);
            this.longSicklistNumLbl.TabIndex = 10;
            this.longSicklistNumLbl.Text = "№";
            // 
            // sickListEndDateTxt
            // 
            this.sickListEndDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.sickListEndDateTxt.Location = new System.Drawing.Point(197, 37);
            this.sickListEndDateTxt.Name = "sickListEndDateTxt";
            this.sickListEndDateTxt.Size = new System.Drawing.Size(130, 20);
            this.sickListEndDateTxt.TabIndex = 9;
            // 
            // sickListStartDateTxt
            // 
            this.sickListStartDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.sickListStartDateTxt.Location = new System.Drawing.Point(31, 37);
            this.sickListStartDateTxt.Name = "sickListStartDateTxt";
            this.sickListStartDateTxt.Size = new System.Drawing.Size(134, 20);
            this.sickListStartDateTxt.TabIndex = 8;
            // 
            // sickListEndDateLbl
            // 
            this.sickListEndDateLbl.AutoSize = true;
            this.sickListEndDateLbl.Location = new System.Drawing.Point(171, 37);
            this.sickListEndDateLbl.Name = "sickListEndDateLbl";
            this.sickListEndDateLbl.Size = new System.Drawing.Size(19, 13);
            this.sickListEndDateLbl.TabIndex = 7;
            this.sickListEndDateLbl.Text = "по";
            // 
            // sickListStartDateLbl
            // 
            this.sickListStartDateLbl.AutoSize = true;
            this.sickListStartDateLbl.Location = new System.Drawing.Point(12, 37);
            this.sickListStartDateLbl.Name = "sickListStartDateLbl";
            this.sickListStartDateLbl.Size = new System.Drawing.Size(13, 13);
            this.sickListStartDateLbl.TabIndex = 5;
            this.sickListStartDateLbl.Text = "с";
            // 
            // sickListNumTxt
            // 
            this.sickListNumTxt.Location = new System.Drawing.Point(30, 14);
            this.sickListNumTxt.Name = "sickListNumTxt";
            this.sickListNumTxt.Size = new System.Drawing.Size(297, 20);
            this.sickListNumTxt.TabIndex = 4;
            // 
            // sickListNumLbl
            // 
            this.sickListNumLbl.AutoSize = true;
            this.sickListNumLbl.Location = new System.Drawing.Point(6, 17);
            this.sickListNumLbl.Name = "sickListNumLbl";
            this.sickListNumLbl.Size = new System.Drawing.Size(18, 13);
            this.sickListNumLbl.TabIndex = 3;
            this.sickListNumLbl.Text = "№";
            // 
            // getWorkInfoBtn
            // 
            this.getWorkInfoBtn.Location = new System.Drawing.Point(7, 19);
            this.getWorkInfoBtn.Name = "getWorkInfoBtn";
            this.getWorkInfoBtn.Size = new System.Drawing.Size(338, 23);
            this.getWorkInfoBtn.TabIndex = 0;
            this.getWorkInfoBtn.Text = "Л/Н данные";
            this.getWorkInfoBtn.UseVisualStyleBackColor = true;
            this.getWorkInfoBtn.Click += new System.EventHandler(this.formTrudBtn_Click);
            // 
            // releaseDateBox
            // 
            this.releaseDateBox.Controls.Add(this.releaseDateTxt);
            this.releaseDateBox.Location = new System.Drawing.Point(187, 7);
            this.releaseDateBox.Name = "releaseDateBox";
            this.releaseDateBox.Size = new System.Drawing.Size(170, 64);
            this.releaseDateBox.TabIndex = 1;
            this.releaseDateBox.TabStop = false;
            this.releaseDateBox.Text = "Дата выписки из стационара";
            // 
            // releaseDateTxt
            // 
            this.releaseDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.releaseDateTxt.Location = new System.Drawing.Point(6, 33);
            this.releaseDateTxt.Name = "releaseDateTxt";
            this.releaseDateTxt.Size = new System.Drawing.Size(141, 20);
            this.releaseDateTxt.TabIndex = 0;
            // 
            // releaseOkrDateBox
            // 
            this.releaseOkrDateBox.Controls.Add(this.releaseOkrDateTxt);
            this.releaseOkrDateBox.Location = new System.Drawing.Point(6, 7);
            this.releaseOkrDateBox.Name = "releaseOkrDateBox";
            this.releaseOkrDateBox.Size = new System.Drawing.Size(175, 64);
            this.releaseOkrDateBox.TabIndex = 0;
            this.releaseOkrDateBox.TabStop = false;
            this.releaseOkrDateBox.Text = "Дата выписки из ОКР/перевода в кардиологию";
            // 
            // releaseOkrDateTxt
            // 
            this.releaseOkrDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.releaseOkrDateTxt.Location = new System.Drawing.Point(6, 33);
            this.releaseOkrDateTxt.Name = "releaseOkrDateTxt";
            this.releaseOkrDateTxt.Size = new System.Drawing.Size(141, 20);
            this.releaseOkrDateTxt.TabIndex = 0;
            // 
            // sickListDataPnl
            // 
            this.sickListDataPnl.Controls.Add(this.sickListNumTxt);
            this.sickListDataPnl.Controls.Add(this.sickListNumLbl);
            this.sickListDataPnl.Controls.Add(this.longEndDateTxt);
            this.sickListDataPnl.Controls.Add(this.sickListStartDateLbl);
            this.sickListDataPnl.Controls.Add(this.longEndDateLbl);
            this.sickListDataPnl.Controls.Add(this.sickListEndDateLbl);
            this.sickListDataPnl.Controls.Add(this.longStartDateTxt);
            this.sickListDataPnl.Controls.Add(this.sickListStartDateTxt);
            this.sickListDataPnl.Controls.Add(this.longStartDateLnl);
            this.sickListDataPnl.Controls.Add(this.sickListEndDateTxt);
            this.sickListDataPnl.Controls.Add(this.longSicklistNumTxt);
            this.sickListDataPnl.Controls.Add(this.longSicklistNumLbl);
            this.sickListDataPnl.Location = new System.Drawing.Point(8, 71);
            this.sickListDataPnl.Name = "sickListDataPnl";
            this.sickListDataPnl.Size = new System.Drawing.Size(337, 122);
            this.sickListDataPnl.TabIndex = 4;
            this.sickListDataPnl.TabStop = false;
            // 
            // sickListNeedBtn
            // 
            this.sickListNeedBtn.AutoSize = true;
            this.sickListNeedBtn.Checked = true;
            this.sickListNeedBtn.Location = new System.Drawing.Point(72, 48);
            this.sickListNeedBtn.Name = "sickListNeedBtn";
            this.sickListNeedBtn.Size = new System.Drawing.Size(75, 17);
            this.sickListNeedBtn.TabIndex = 16;
            this.sickListNeedBtn.TabStop = true;
            this.sickListNeedBtn.Text = "ЛН нужен";
            this.sickListNeedBtn.UseVisualStyleBackColor = true;
            // 
            // sickListNotNeedBtn
            // 
            this.sickListNotNeedBtn.AutoSize = true;
            this.sickListNotNeedBtn.Location = new System.Drawing.Point(175, 48);
            this.sickListNotNeedBtn.Name = "sickListNotNeedBtn";
            this.sickListNotNeedBtn.Size = new System.Drawing.Size(90, 17);
            this.sickListNotNeedBtn.TabIndex = 17;
            this.sickListNotNeedBtn.Text = "ЛН не нужен";
            this.sickListNotNeedBtn.UseVisualStyleBackColor = true;
            // 
            // releaseVariants
            // 
            this.releaseVariants.Controls.Add(this.releaseBtn);
            this.releaseVariants.Controls.Add(this.movedToCardioBtn);
            this.releaseVariants.Controls.Add(this.refusedBtn);
            this.releaseVariants.Location = new System.Drawing.Point(6, 287);
            this.releaseVariants.Name = "releaseVariants";
            this.releaseVariants.Size = new System.Drawing.Size(351, 100);
            this.releaseVariants.TabIndex = 4;
            this.releaseVariants.TabStop = false;
            this.releaseVariants.Text = "Варианты выписки";
            // 
            // refusedBtn
            // 
            this.refusedBtn.AutoSize = true;
            this.refusedBtn.Location = new System.Drawing.Point(8, 20);
            this.refusedBtn.Name = "refusedBtn";
            this.refusedBtn.Size = new System.Drawing.Size(210, 17);
            this.refusedBtn.TabIndex = 0;
            this.refusedBtn.Text = "Выписан под отказ от стац. лечения";
            this.refusedBtn.UseVisualStyleBackColor = true;
            // 
            // movedToCardioBtn
            // 
            this.movedToCardioBtn.AutoSize = true;
            this.movedToCardioBtn.Location = new System.Drawing.Point(8, 44);
            this.movedToCardioBtn.Name = "movedToCardioBtn";
            this.movedToCardioBtn.Size = new System.Drawing.Size(243, 17);
            this.movedToCardioBtn.TabIndex = 1;
            this.movedToCardioBtn.Text = "Переведен в кардиологическое отделение";
            this.movedToCardioBtn.UseVisualStyleBackColor = true;
            // 
            // releaseBtn
            // 
            this.releaseBtn.AutoSize = true;
            this.releaseBtn.Checked = true;
            this.releaseBtn.Location = new System.Drawing.Point(8, 68);
            this.releaseBtn.Name = "releaseBtn";
            this.releaseBtn.Size = new System.Drawing.Size(176, 17);
            this.releaseBtn.TabIndex = 2;
            this.releaseBtn.TabStop = true;
            this.releaseBtn.Text = "Выписан из отд. кардиологии";
            this.releaseBtn.UseVisualStyleBackColor = true;
            // 
            // addIssuedMedicineBtn
            // 
            this.addIssuedMedicineBtn.Location = new System.Drawing.Point(203, 6);
            this.addIssuedMedicineBtn.Name = "addIssuedMedicineBtn";
            this.addIssuedMedicineBtn.Size = new System.Drawing.Size(160, 33);
            this.addIssuedMedicineBtn.TabIndex = 6;
            this.addIssuedMedicineBtn.Text = "Добавить рекомендации";
            this.addIssuedMedicineBtn.UseVisualStyleBackColor = true;
            this.addIssuedMedicineBtn.Click += new System.EventHandler(this.addIssuedMedicineBtn_Click);
            // 
            // issuedMedicine0
            // 
            this.issuedMedicine0.Location = new System.Drawing.Point(3, 3);
            this.issuedMedicine0.Name = "issuedMedicine0";
            this.issuedMedicine0.Size = new System.Drawing.Size(354, 20);
            this.issuedMedicine0.TabIndex = 7;
            // 
            // issuedMedicineTab
            // 
            this.issuedMedicineTab.Controls.Add(this.issuedMedicineBox);
            this.issuedMedicineTab.Controls.Add(this.addIssuedMedicineBtn);
            this.issuedMedicineTab.Location = new System.Drawing.Point(4, 22);
            this.issuedMedicineTab.Name = "issuedMedicineTab";
            this.issuedMedicineTab.Padding = new System.Windows.Forms.Padding(3);
            this.issuedMedicineTab.Size = new System.Drawing.Size(369, 439);
            this.issuedMedicineTab.TabIndex = 1;
            this.issuedMedicineTab.Text = "Лекарственные рекомендации";
            this.issuedMedicineTab.UseVisualStyleBackColor = true;
            // 
            // issuedMedicineBox
            // 
            this.issuedMedicineBox.AutoSize = true;
            this.issuedMedicineBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.issuedMedicineBox.ColumnCount = 1;
            this.issuedMedicineBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.issuedMedicineBox.Controls.Add(this.issuedMedicine0, 0, 0);
            this.issuedMedicineBox.Location = new System.Drawing.Point(9, 45);
            this.issuedMedicineBox.Name = "issuedMedicineBox";
            this.issuedMedicineBox.RowCount = 1;
            this.issuedMedicineBox.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.issuedMedicineBox.Size = new System.Drawing.Size(360, 26);
            this.issuedMedicineBox.TabIndex = 0;
            // 
            // ReleasePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 472);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReleasePatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выписка";
            this.tabControl1.ResumeLayout(false);
            this.releaseData.ResumeLayout(false);
            this.sickListBox.ResumeLayout(false);
            this.sickListBox.PerformLayout();
            this.releaseDateBox.ResumeLayout(false);
            this.releaseOkrDateBox.ResumeLayout(false);
            this.sickListDataPnl.ResumeLayout(false);
            this.sickListDataPnl.PerformLayout();
            this.releaseVariants.ResumeLayout(false);
            this.releaseVariants.PerformLayout();
            this.issuedMedicineTab.ResumeLayout(false);
            this.issuedMedicineTab.PerformLayout();
            this.issuedMedicineBox.ResumeLayout(false);
            this.issuedMedicineBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage releaseData;
        private System.Windows.Forms.GroupBox releaseDateBox;
        private System.Windows.Forms.GroupBox releaseOkrDateBox;
        private System.Windows.Forms.Button releasePatientBtn;
        private System.Windows.Forms.GroupBox sickListBox;
        private System.Windows.Forms.DateTimePicker longEndDateTxt;
        private System.Windows.Forms.Label longEndDateLbl;
        private System.Windows.Forms.DateTimePicker longStartDateTxt;
        private System.Windows.Forms.Label longStartDateLnl;
        private System.Windows.Forms.TextBox longSicklistNumTxt;
        private System.Windows.Forms.Label longSicklistNumLbl;
        private System.Windows.Forms.DateTimePicker sickListEndDateTxt;
        private System.Windows.Forms.DateTimePicker sickListStartDateTxt;
        private System.Windows.Forms.Label sickListEndDateLbl;
        private System.Windows.Forms.Label sickListStartDateLbl;
        private System.Windows.Forms.TextBox sickListNumTxt;
        private System.Windows.Forms.Label sickListNumLbl;
        private System.Windows.Forms.Button getWorkInfoBtn;
        private System.Windows.Forms.DateTimePicker releaseDateTxt;
        private System.Windows.Forms.DateTimePicker releaseOkrDateTxt;
        private System.Windows.Forms.GroupBox sickListDataPnl;
        private System.Windows.Forms.RadioButton sickListNotNeedBtn;
        private System.Windows.Forms.RadioButton sickListNeedBtn;
        private System.Windows.Forms.GroupBox releaseVariants;
        private System.Windows.Forms.RadioButton releaseBtn;
        private System.Windows.Forms.RadioButton movedToCardioBtn;
        private System.Windows.Forms.RadioButton refusedBtn;
        private System.Windows.Forms.TextBox issuedMedicine0;
        private System.Windows.Forms.Button addIssuedMedicineBtn;
        private System.Windows.Forms.TabPage issuedMedicineTab;
        private System.Windows.Forms.TableLayoutPanel issuedMedicineBox;
    }
}