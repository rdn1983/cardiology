namespace Cardiology
{
    partial class IssuedMedicine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssuedMedicine));
            this.shortlyDiagnosisPnl = new System.Windows.Forms.GroupBox();
            this.sdBtn = new System.Windows.Forms.Button();
            this.anemiaBtn = new System.Windows.Forms.Button();
            this.telaBtn = new System.Windows.Forms.Button();
            this.pmaBtn = new System.Windows.Forms.Button();
            this.depBtn = new System.Windows.Forms.Button();
            this.edemaPulmonaryBtn = new System.Windows.Forms.Button();
            this.nkBtn = new System.Windows.Forms.Button();
            this.gbBtn = new System.Windows.Forms.Button();
            this.piksBtn = new System.Windows.Forms.Button();
            this.oksBtn = new System.Windows.Forms.Button();
            this.diagnosisTxt = new System.Windows.Forms.RichTextBox();
            this.shortlyOperationPnl = new System.Windows.Forms.GroupBox();
            this.noKagBtn = new System.Windows.Forms.RadioButton();
            this.kagBtn = new System.Windows.Forms.RadioButton();
            this.shortlyOperationTxt = new System.Windows.Forms.RichTextBox();
            this.insertIssuedMedPnl = new System.Windows.Forms.GroupBox();
            this.clearMedBtn = new System.Windows.Forms.Button();
            this.copyYesterdayMedBtn = new System.Windows.Forms.Button();
            this.copyJournalMedBtn = new System.Windows.Forms.Button();
            this.copyFirstMedicineBtn = new System.Windows.Forms.Button();
            this.medTemplatesPnl = new System.Windows.Forms.GroupBox();
            this.gbMedBtn = new System.Windows.Forms.Button();
            this.nkMedBtn = new System.Windows.Forms.Button();
            this.hoblMedBtn = new System.Windows.Forms.Button();
            this.oksLongsMedBtn = new System.Windows.Forms.Button();
            this.oksTemplateMed = new System.Windows.Forms.Button();
            this.createDatePnl = new System.Windows.Forms.GroupBox();
            this.createDateTxt = new System.Windows.Forms.DateTimePicker();
            this.clinicalPharmacologistPnl = new System.Windows.Forms.GroupBox();
            this.clinicalPharmacologistBox = new System.Windows.Forms.ComboBox();
            this.issuedMedicinePnl = new System.Windows.Forms.GroupBox();
            this.addCureBtn = new System.Windows.Forms.Button();
            this.medicineContainer = new System.Windows.Forms.TableLayoutPanel();
            this.issuedMedPnl0 = new System.Windows.Forms.Panel();
            this.objectIdLbl0 = new System.Windows.Forms.Label();
            this.issuedMedicineTxt0 = new System.Windows.Forms.ComboBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.nursePnl = new System.Windows.Forms.GroupBox();
            this.nurseBox = new System.Windows.Forms.ComboBox();
            this.directorPnl = new System.Windows.Forms.GroupBox();
            this.directorBox = new System.Windows.Forms.ComboBox();
            this.cardioReanimPnl = new System.Windows.Forms.GroupBox();
            this.cardioReanimBox = new System.Windows.Forms.ComboBox();
            this.shortlyDiagnosisPnl.SuspendLayout();
            this.shortlyOperationPnl.SuspendLayout();
            this.insertIssuedMedPnl.SuspendLayout();
            this.medTemplatesPnl.SuspendLayout();
            this.createDatePnl.SuspendLayout();
            this.clinicalPharmacologistPnl.SuspendLayout();
            this.issuedMedicinePnl.SuspendLayout();
            this.medicineContainer.SuspendLayout();
            this.issuedMedPnl0.SuspendLayout();
            this.nursePnl.SuspendLayout();
            this.directorPnl.SuspendLayout();
            this.cardioReanimPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // shortlyDiagnosisPnl
            // 
            this.shortlyDiagnosisPnl.Controls.Add(this.sdBtn);
            this.shortlyDiagnosisPnl.Controls.Add(this.anemiaBtn);
            this.shortlyDiagnosisPnl.Controls.Add(this.telaBtn);
            this.shortlyDiagnosisPnl.Controls.Add(this.pmaBtn);
            this.shortlyDiagnosisPnl.Controls.Add(this.depBtn);
            this.shortlyDiagnosisPnl.Controls.Add(this.edemaPulmonaryBtn);
            this.shortlyDiagnosisPnl.Controls.Add(this.nkBtn);
            this.shortlyDiagnosisPnl.Controls.Add(this.gbBtn);
            this.shortlyDiagnosisPnl.Controls.Add(this.piksBtn);
            this.shortlyDiagnosisPnl.Controls.Add(this.oksBtn);
            this.shortlyDiagnosisPnl.Controls.Add(this.diagnosisTxt);
            this.shortlyDiagnosisPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shortlyDiagnosisPnl.Location = new System.Drawing.Point(12, 12);
            this.shortlyDiagnosisPnl.Name = "shortlyDiagnosisPnl";
            this.shortlyDiagnosisPnl.Size = new System.Drawing.Size(261, 154);
            this.shortlyDiagnosisPnl.TabIndex = 0;
            this.shortlyDiagnosisPnl.TabStop = false;
            this.shortlyDiagnosisPnl.Text = "Сокращенный диагноз для листа назначений";
            // 
            // sdBtn
            // 
            this.sdBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sdBtn.Location = new System.Drawing.Point(200, 121);
            this.sdBtn.Name = "sdBtn";
            this.sdBtn.Size = new System.Drawing.Size(57, 23);
            this.sdBtn.TabIndex = 10;
            this.sdBtn.Text = "СД";
            this.sdBtn.UseVisualStyleBackColor = true;
            this.sdBtn.Click += new System.EventHandler(this.sdBtn_Click);
            // 
            // anemiaBtn
            // 
            this.anemiaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.anemiaBtn.Location = new System.Drawing.Point(136, 121);
            this.anemiaBtn.Name = "anemiaBtn";
            this.anemiaBtn.Size = new System.Drawing.Size(65, 23);
            this.anemiaBtn.TabIndex = 9;
            this.anemiaBtn.Text = "Анемия";
            this.anemiaBtn.UseVisualStyleBackColor = true;
            this.anemiaBtn.Click += new System.EventHandler(this.anemiaBtn_Click);
            // 
            // telaBtn
            // 
            this.telaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.telaBtn.Location = new System.Drawing.Point(92, 121);
            this.telaBtn.Name = "telaBtn";
            this.telaBtn.Size = new System.Drawing.Size(45, 23);
            this.telaBtn.TabIndex = 8;
            this.telaBtn.Text = "ТЭЛА";
            this.telaBtn.UseVisualStyleBackColor = true;
            this.telaBtn.Click += new System.EventHandler(this.telaBtn_Click);
            // 
            // pmaBtn
            // 
            this.pmaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pmaBtn.Location = new System.Drawing.Point(48, 121);
            this.pmaBtn.Name = "pmaBtn";
            this.pmaBtn.Size = new System.Drawing.Size(45, 23);
            this.pmaBtn.TabIndex = 7;
            this.pmaBtn.Text = "ПМА";
            this.pmaBtn.UseVisualStyleBackColor = true;
            this.pmaBtn.Click += new System.EventHandler(this.pmaBtn_Click);
            // 
            // depBtn
            // 
            this.depBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.depBtn.Location = new System.Drawing.Point(4, 121);
            this.depBtn.Name = "depBtn";
            this.depBtn.Size = new System.Drawing.Size(45, 23);
            this.depBtn.TabIndex = 6;
            this.depBtn.Text = "ДЭП";
            this.depBtn.UseVisualStyleBackColor = true;
            this.depBtn.Click += new System.EventHandler(this.depBtn_Click);
            // 
            // edemaPulmonaryBtn
            // 
            this.edemaPulmonaryBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edemaPulmonaryBtn.Location = new System.Drawing.Point(180, 99);
            this.edemaPulmonaryBtn.Name = "edemaPulmonaryBtn";
            this.edemaPulmonaryBtn.Size = new System.Drawing.Size(77, 23);
            this.edemaPulmonaryBtn.TabIndex = 5;
            this.edemaPulmonaryBtn.Text = "Отек легких";
            this.edemaPulmonaryBtn.UseVisualStyleBackColor = true;
            this.edemaPulmonaryBtn.Click += new System.EventHandler(this.edemaPulmonaryBtn_Click);
            // 
            // nkBtn
            // 
            this.nkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nkBtn.Location = new System.Drawing.Point(136, 99);
            this.nkBtn.Name = "nkBtn";
            this.nkBtn.Size = new System.Drawing.Size(45, 23);
            this.nkBtn.TabIndex = 4;
            this.nkBtn.Text = "НК";
            this.nkBtn.UseVisualStyleBackColor = true;
            this.nkBtn.Click += new System.EventHandler(this.nkBtn_Click);
            // 
            // gbBtn
            // 
            this.gbBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbBtn.Location = new System.Drawing.Point(92, 99);
            this.gbBtn.Name = "gbBtn";
            this.gbBtn.Size = new System.Drawing.Size(45, 23);
            this.gbBtn.TabIndex = 3;
            this.gbBtn.Text = "ГБ";
            this.gbBtn.UseVisualStyleBackColor = true;
            this.gbBtn.Click += new System.EventHandler(this.gbBtn_Click);
            // 
            // piksBtn
            // 
            this.piksBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.piksBtn.Location = new System.Drawing.Point(48, 99);
            this.piksBtn.Name = "piksBtn";
            this.piksBtn.Size = new System.Drawing.Size(45, 23);
            this.piksBtn.TabIndex = 2;
            this.piksBtn.Text = "ПИКС";
            this.piksBtn.UseVisualStyleBackColor = true;
            this.piksBtn.Click += new System.EventHandler(this.piksBtn_Click);
            // 
            // oksBtn
            // 
            this.oksBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oksBtn.Location = new System.Drawing.Point(4, 99);
            this.oksBtn.Name = "oksBtn";
            this.oksBtn.Size = new System.Drawing.Size(45, 23);
            this.oksBtn.TabIndex = 1;
            this.oksBtn.Text = "ОКС";
            this.oksBtn.UseVisualStyleBackColor = true;
            this.oksBtn.Click += new System.EventHandler(this.oksBtn_Click);
            // 
            // diagnosisTxt
            // 
            this.diagnosisTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.diagnosisTxt.Location = new System.Drawing.Point(4, 31);
            this.diagnosisTxt.Name = "diagnosisTxt";
            this.diagnosisTxt.Size = new System.Drawing.Size(249, 62);
            this.diagnosisTxt.TabIndex = 0;
            this.diagnosisTxt.Text = "";
            // 
            // shortlyOperationPnl
            // 
            this.shortlyOperationPnl.Controls.Add(this.noKagBtn);
            this.shortlyOperationPnl.Controls.Add(this.kagBtn);
            this.shortlyOperationPnl.Controls.Add(this.shortlyOperationTxt);
            this.shortlyOperationPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shortlyOperationPnl.Location = new System.Drawing.Point(11, 173);
            this.shortlyOperationPnl.Name = "shortlyOperationPnl";
            this.shortlyOperationPnl.Size = new System.Drawing.Size(262, 122);
            this.shortlyOperationPnl.TabIndex = 1;
            this.shortlyOperationPnl.TabStop = false;
            this.shortlyOperationPnl.Text = "Операция сокращенно для листа назначений";
            // 
            // noKagBtn
            // 
            this.noKagBtn.AutoSize = true;
            this.noKagBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.noKagBtn.Location = new System.Drawing.Point(163, 81);
            this.noKagBtn.Name = "noKagBtn";
            this.noKagBtn.Size = new System.Drawing.Size(60, 17);
            this.noKagBtn.TabIndex = 2;
            this.noKagBtn.Text = "Без КГ";
            this.noKagBtn.UseVisualStyleBackColor = true;
            this.noKagBtn.CheckedChanged += new System.EventHandler(this.noKagBtn_CheckedChanged);
            // 
            // kagBtn
            // 
            this.kagBtn.AutoSize = true;
            this.kagBtn.Checked = true;
            this.kagBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kagBtn.Location = new System.Drawing.Point(163, 48);
            this.kagBtn.Name = "kagBtn";
            this.kagBtn.Size = new System.Drawing.Size(45, 17);
            this.kagBtn.TabIndex = 1;
            this.kagBtn.TabStop = true;
            this.kagBtn.Text = "КАГ";
            this.kagBtn.UseVisualStyleBackColor = true;
            this.kagBtn.CheckedChanged += new System.EventHandler(this.kagBtn_CheckedChanged);
            // 
            // shortlyOperationTxt
            // 
            this.shortlyOperationTxt.Location = new System.Drawing.Point(6, 35);
            this.shortlyOperationTxt.Name = "shortlyOperationTxt";
            this.shortlyOperationTxt.Size = new System.Drawing.Size(151, 75);
            this.shortlyOperationTxt.TabIndex = 0;
            this.shortlyOperationTxt.Text = "";
            // 
            // insertIssuedMedPnl
            // 
            this.insertIssuedMedPnl.Controls.Add(this.clearMedBtn);
            this.insertIssuedMedPnl.Controls.Add(this.copyYesterdayMedBtn);
            this.insertIssuedMedPnl.Controls.Add(this.copyJournalMedBtn);
            this.insertIssuedMedPnl.Controls.Add(this.copyFirstMedicineBtn);
            this.insertIssuedMedPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.insertIssuedMedPnl.Location = new System.Drawing.Point(11, 407);
            this.insertIssuedMedPnl.Name = "insertIssuedMedPnl";
            this.insertIssuedMedPnl.Size = new System.Drawing.Size(262, 112);
            this.insertIssuedMedPnl.TabIndex = 2;
            this.insertIssuedMedPnl.TabStop = false;
            this.insertIssuedMedPnl.Text = "Вставить назначения";
            // 
            // clearMedBtn
            // 
            this.clearMedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearMedBtn.Location = new System.Drawing.Point(126, 19);
            this.clearMedBtn.Name = "clearMedBtn";
            this.clearMedBtn.Size = new System.Drawing.Size(114, 28);
            this.clearMedBtn.TabIndex = 3;
            this.clearMedBtn.Text = "Очистить";
            this.clearMedBtn.UseVisualStyleBackColor = true;
            this.clearMedBtn.Click += new System.EventHandler(this.clearMedBtn_Click);
            // 
            // copyYesterdayMedBtn
            // 
            this.copyYesterdayMedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyYesterdayMedBtn.Location = new System.Drawing.Point(126, 53);
            this.copyYesterdayMedBtn.Name = "copyYesterdayMedBtn";
            this.copyYesterdayMedBtn.Size = new System.Drawing.Size(114, 43);
            this.copyYesterdayMedBtn.TabIndex = 2;
            this.copyYesterdayMedBtn.Text = "Из вчерашнего листа";
            this.copyYesterdayMedBtn.UseVisualStyleBackColor = true;
            // 
            // copyJournalMedBtn
            // 
            this.copyJournalMedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyJournalMedBtn.Location = new System.Drawing.Point(6, 53);
            this.copyJournalMedBtn.Name = "copyJournalMedBtn";
            this.copyJournalMedBtn.Size = new System.Drawing.Size(114, 43);
            this.copyJournalMedBtn.TabIndex = 1;
            this.copyJournalMedBtn.Text = "Из ежедневки";
            this.copyJournalMedBtn.UseVisualStyleBackColor = true;
            // 
            // copyFirstMedicineBtn
            // 
            this.copyFirstMedicineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyFirstMedicineBtn.Location = new System.Drawing.Point(6, 19);
            this.copyFirstMedicineBtn.Name = "copyFirstMedicineBtn";
            this.copyFirstMedicineBtn.Size = new System.Drawing.Size(114, 28);
            this.copyFirstMedicineBtn.TabIndex = 0;
            this.copyFirstMedicineBtn.Text = "Из первички";
            this.copyFirstMedicineBtn.UseVisualStyleBackColor = true;
            this.copyFirstMedicineBtn.Click += new System.EventHandler(this.copyFirstMedicineBtn_Click);
            // 
            // medTemplatesPnl
            // 
            this.medTemplatesPnl.Controls.Add(this.gbMedBtn);
            this.medTemplatesPnl.Controls.Add(this.nkMedBtn);
            this.medTemplatesPnl.Controls.Add(this.hoblMedBtn);
            this.medTemplatesPnl.Controls.Add(this.oksLongsMedBtn);
            this.medTemplatesPnl.Controls.Add(this.oksTemplateMed);
            this.medTemplatesPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.medTemplatesPnl.Location = new System.Drawing.Point(11, 301);
            this.medTemplatesPnl.Name = "medTemplatesPnl";
            this.medTemplatesPnl.Size = new System.Drawing.Size(262, 100);
            this.medTemplatesPnl.TabIndex = 3;
            this.medTemplatesPnl.TabStop = false;
            this.medTemplatesPnl.Text = "Шаблоны";
            // 
            // gbMedBtn
            // 
            this.gbMedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbMedBtn.Location = new System.Drawing.Point(6, 60);
            this.gbMedBtn.Name = "gbMedBtn";
            this.gbMedBtn.Size = new System.Drawing.Size(78, 34);
            this.gbMedBtn.TabIndex = 4;
            this.gbMedBtn.Text = "ГБ";
            this.gbMedBtn.UseVisualStyleBackColor = true;
            this.gbMedBtn.Click += new System.EventHandler(this.gbMedBtn_Click);
            // 
            // nkMedBtn
            // 
            this.nkMedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nkMedBtn.Location = new System.Drawing.Point(164, 60);
            this.nkMedBtn.Name = "nkMedBtn";
            this.nkMedBtn.Size = new System.Drawing.Size(84, 34);
            this.nkMedBtn.TabIndex = 3;
            this.nkMedBtn.Text = "НК";
            this.nkMedBtn.UseVisualStyleBackColor = true;
            this.nkMedBtn.Click += new System.EventHandler(this.nkMedBtn_Click);
            // 
            // hoblMedBtn
            // 
            this.hoblMedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hoblMedBtn.Location = new System.Drawing.Point(83, 60);
            this.hoblMedBtn.Name = "hoblMedBtn";
            this.hoblMedBtn.Size = new System.Drawing.Size(82, 34);
            this.hoblMedBtn.TabIndex = 2;
            this.hoblMedBtn.Text = "ХОБЛ";
            this.hoblMedBtn.UseVisualStyleBackColor = true;
            this.hoblMedBtn.Click += new System.EventHandler(this.hoblMedBtn_Click);
            // 
            // oksLongsMedBtn
            // 
            this.oksLongsMedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oksLongsMedBtn.Location = new System.Drawing.Point(164, 21);
            this.oksLongsMedBtn.Name = "oksLongsMedBtn";
            this.oksLongsMedBtn.Size = new System.Drawing.Size(84, 40);
            this.oksLongsMedBtn.TabIndex = 1;
            this.oksLongsMedBtn.Text = "ОКС \r\nпродолжение";
            this.oksLongsMedBtn.UseVisualStyleBackColor = true;
            this.oksLongsMedBtn.Click += new System.EventHandler(this.oksLongsMedBtn_Click);
            // 
            // oksTemplateMed
            // 
            this.oksTemplateMed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oksTemplateMed.Location = new System.Drawing.Point(6, 21);
            this.oksTemplateMed.Name = "oksTemplateMed";
            this.oksTemplateMed.Size = new System.Drawing.Size(159, 40);
            this.oksTemplateMed.TabIndex = 0;
            this.oksTemplateMed.Text = "ОКС при поступлении, \r\nнитраты, тройная терапия";
            this.oksTemplateMed.UseVisualStyleBackColor = true;
            this.oksTemplateMed.Click += new System.EventHandler(this.oksTemplateMed_Click);
            // 
            // createDatePnl
            // 
            this.createDatePnl.Controls.Add(this.createDateTxt);
            this.createDatePnl.Location = new System.Drawing.Point(285, 101);
            this.createDatePnl.Name = "createDatePnl";
            this.createDatePnl.Size = new System.Drawing.Size(123, 39);
            this.createDatePnl.TabIndex = 4;
            this.createDatePnl.TabStop = false;
            this.createDatePnl.Text = "Дата заполнения";
            // 
            // createDateTxt
            // 
            this.createDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.createDateTxt.Location = new System.Drawing.Point(6, 16);
            this.createDateTxt.Name = "createDateTxt";
            this.createDateTxt.Size = new System.Drawing.Size(97, 20);
            this.createDateTxt.TabIndex = 0;
            // 
            // clinicalPharmacologistPnl
            // 
            this.clinicalPharmacologistPnl.Controls.Add(this.clinicalPharmacologistBox);
            this.clinicalPharmacologistPnl.Location = new System.Drawing.Point(285, 12);
            this.clinicalPharmacologistPnl.Name = "clinicalPharmacologistPnl";
            this.clinicalPharmacologistPnl.Size = new System.Drawing.Size(231, 45);
            this.clinicalPharmacologistPnl.TabIndex = 5;
            this.clinicalPharmacologistPnl.TabStop = false;
            this.clinicalPharmacologistPnl.Text = "Клинфармаколог";
            // 
            // clinicalPharmacologistBox
            // 
            this.clinicalPharmacologistBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clinicalPharmacologistBox.FormattingEnabled = true;
            this.clinicalPharmacologistBox.Location = new System.Drawing.Point(6, 16);
            this.clinicalPharmacologistBox.Name = "clinicalPharmacologistBox";
            this.clinicalPharmacologistBox.Size = new System.Drawing.Size(216, 21);
            this.clinicalPharmacologistBox.TabIndex = 0;
            // 
            // issuedMedicinePnl
            // 
            this.issuedMedicinePnl.Controls.Add(this.addCureBtn);
            this.issuedMedicinePnl.Controls.Add(this.medicineContainer);
            this.issuedMedicinePnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.issuedMedicinePnl.Location = new System.Drawing.Point(285, 143);
            this.issuedMedicinePnl.Name = "issuedMedicinePnl";
            this.issuedMedicinePnl.Size = new System.Drawing.Size(486, 334);
            this.issuedMedicinePnl.TabIndex = 7;
            this.issuedMedicinePnl.TabStop = false;
            this.issuedMedicinePnl.Text = "Лекарства";
            // 
            // addCureBtn
            // 
            this.addCureBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addCureBtn.Image = global::Cardiology.Properties.Resources.addd1;
            this.addCureBtn.Location = new System.Drawing.Point(450, 22);
            this.addCureBtn.Name = "addCureBtn";
            this.addCureBtn.Size = new System.Drawing.Size(29, 29);
            this.addCureBtn.TabIndex = 12;
            this.addCureBtn.UseVisualStyleBackColor = true;
            this.addCureBtn.Click += new System.EventHandler(this.addCureBtn_Click);
            // 
            // medicineContainer
            // 
            this.medicineContainer.AutoSize = true;
            this.medicineContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.medicineContainer.ColumnCount = 1;
            this.medicineContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.medicineContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.medicineContainer.Controls.Add(this.issuedMedPnl0, 0, 0);
            this.medicineContainer.Location = new System.Drawing.Point(6, 22);
            this.medicineContainer.Name = "medicineContainer";
            this.medicineContainer.RowCount = 1;
            this.medicineContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.medicineContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.medicineContainer.Size = new System.Drawing.Size(441, 34);
            this.medicineContainer.TabIndex = 1;
            // 
            // issuedMedPnl0
            // 
            this.issuedMedPnl0.Controls.Add(this.objectIdLbl0);
            this.issuedMedPnl0.Controls.Add(this.issuedMedicineTxt0);
            this.issuedMedPnl0.Location = new System.Drawing.Point(3, 3);
            this.issuedMedPnl0.Name = "issuedMedPnl0";
            this.issuedMedPnl0.Size = new System.Drawing.Size(435, 28);
            this.issuedMedPnl0.TabIndex = 13;
            // 
            // objectIdLbl0
            // 
            this.objectIdLbl0.AutoSize = true;
            this.objectIdLbl0.Location = new System.Drawing.Point(438, 6);
            this.objectIdLbl0.Name = "objectIdLbl0";
            this.objectIdLbl0.Size = new System.Drawing.Size(0, 13);
            this.objectIdLbl0.TabIndex = 1;
            this.objectIdLbl0.Visible = false;
            // 
            // issuedMedicineTxt0
            // 
            this.issuedMedicineTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.issuedMedicineTxt0.FormattingEnabled = true;
            this.issuedMedicineTxt0.Location = new System.Drawing.Point(3, 4);
            this.issuedMedicineTxt0.Name = "issuedMedicineTxt0";
            this.issuedMedicineTxt0.Size = new System.Drawing.Size(420, 21);
            this.issuedMedicineTxt0.TabIndex = 0;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(650, 495);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(121, 23);
            this.saveBtn.TabIndex = 9;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(521, 495);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(121, 23);
            this.printBtn.TabIndex = 11;
            this.printBtn.Text = "MsWord";
            this.printBtn.UseVisualStyleBackColor = true;
            // 
            // nursePnl
            // 
            this.nursePnl.Controls.Add(this.nurseBox);
            this.nursePnl.Location = new System.Drawing.Point(527, 12);
            this.nursePnl.Name = "nursePnl";
            this.nursePnl.Size = new System.Drawing.Size(231, 45);
            this.nursePnl.TabIndex = 12;
            this.nursePnl.TabStop = false;
            this.nursePnl.Text = "Дежурная мед.сестра";
            // 
            // nurseBox
            // 
            this.nurseBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nurseBox.FormattingEnabled = true;
            this.nurseBox.Location = new System.Drawing.Point(6, 16);
            this.nurseBox.Name = "nurseBox";
            this.nurseBox.Size = new System.Drawing.Size(216, 21);
            this.nurseBox.TabIndex = 0;
            // 
            // directorPnl
            // 
            this.directorPnl.Controls.Add(this.directorBox);
            this.directorPnl.Location = new System.Drawing.Point(527, 57);
            this.directorPnl.Name = "directorPnl";
            this.directorPnl.Size = new System.Drawing.Size(231, 44);
            this.directorPnl.TabIndex = 14;
            this.directorPnl.TabStop = false;
            this.directorPnl.Text = "Зав. отделением";
            // 
            // directorBox
            // 
            this.directorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directorBox.FormattingEnabled = true;
            this.directorBox.Location = new System.Drawing.Point(6, 16);
            this.directorBox.Name = "directorBox";
            this.directorBox.Size = new System.Drawing.Size(216, 21);
            this.directorBox.TabIndex = 0;
            // 
            // cardioReanimPnl
            // 
            this.cardioReanimPnl.Controls.Add(this.cardioReanimBox);
            this.cardioReanimPnl.Location = new System.Drawing.Point(285, 58);
            this.cardioReanimPnl.Name = "cardioReanimPnl";
            this.cardioReanimPnl.Size = new System.Drawing.Size(231, 43);
            this.cardioReanimPnl.TabIndex = 13;
            this.cardioReanimPnl.TabStop = false;
            this.cardioReanimPnl.Text = "Деж. кардиореаниматолог";
            // 
            // cardioReanimBox
            // 
            this.cardioReanimBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardioReanimBox.FormattingEnabled = true;
            this.cardioReanimBox.Location = new System.Drawing.Point(6, 16);
            this.cardioReanimBox.Name = "cardioReanimBox";
            this.cardioReanimBox.Size = new System.Drawing.Size(216, 21);
            this.cardioReanimBox.TabIndex = 0;
            // 
            // IssuedMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 524);
            this.Controls.Add(this.directorPnl);
            this.Controls.Add(this.cardioReanimPnl);
            this.Controls.Add(this.nursePnl);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.insertIssuedMedPnl);
            this.Controls.Add(this.issuedMedicinePnl);
            this.Controls.Add(this.medTemplatesPnl);
            this.Controls.Add(this.clinicalPharmacologistPnl);
            this.Controls.Add(this.createDatePnl);
            this.Controls.Add(this.shortlyOperationPnl);
            this.Controls.Add(this.shortlyDiagnosisPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IssuedMedicine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Назначения";
            this.shortlyDiagnosisPnl.ResumeLayout(false);
            this.shortlyOperationPnl.ResumeLayout(false);
            this.shortlyOperationPnl.PerformLayout();
            this.insertIssuedMedPnl.ResumeLayout(false);
            this.medTemplatesPnl.ResumeLayout(false);
            this.createDatePnl.ResumeLayout(false);
            this.clinicalPharmacologistPnl.ResumeLayout(false);
            this.issuedMedicinePnl.ResumeLayout(false);
            this.issuedMedicinePnl.PerformLayout();
            this.medicineContainer.ResumeLayout(false);
            this.issuedMedPnl0.ResumeLayout(false);
            this.issuedMedPnl0.PerformLayout();
            this.nursePnl.ResumeLayout(false);
            this.directorPnl.ResumeLayout(false);
            this.cardioReanimPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox shortlyDiagnosisPnl;
        private System.Windows.Forms.Button gbBtn;
        private System.Windows.Forms.Button piksBtn;
        private System.Windows.Forms.Button oksBtn;
        private System.Windows.Forms.RichTextBox diagnosisTxt;
        private System.Windows.Forms.Button sdBtn;
        private System.Windows.Forms.Button anemiaBtn;
        private System.Windows.Forms.Button telaBtn;
        private System.Windows.Forms.Button pmaBtn;
        private System.Windows.Forms.Button depBtn;
        private System.Windows.Forms.Button edemaPulmonaryBtn;
        private System.Windows.Forms.Button nkBtn;
        private System.Windows.Forms.GroupBox shortlyOperationPnl;
        private System.Windows.Forms.RadioButton noKagBtn;
        private System.Windows.Forms.RadioButton kagBtn;
        private System.Windows.Forms.RichTextBox shortlyOperationTxt;
        private System.Windows.Forms.GroupBox insertIssuedMedPnl;
        private System.Windows.Forms.Button clearMedBtn;
        private System.Windows.Forms.Button copyYesterdayMedBtn;
        private System.Windows.Forms.Button copyJournalMedBtn;
        private System.Windows.Forms.Button copyFirstMedicineBtn;
        private System.Windows.Forms.GroupBox medTemplatesPnl;
        private System.Windows.Forms.Button gbMedBtn;
        private System.Windows.Forms.Button nkMedBtn;
        private System.Windows.Forms.Button hoblMedBtn;
        private System.Windows.Forms.Button oksLongsMedBtn;
        private System.Windows.Forms.Button oksTemplateMed;
        private System.Windows.Forms.GroupBox createDatePnl;
        private System.Windows.Forms.DateTimePicker createDateTxt;
        private System.Windows.Forms.GroupBox clinicalPharmacologistPnl;
        private System.Windows.Forms.ComboBox clinicalPharmacologistBox;
        private System.Windows.Forms.GroupBox issuedMedicinePnl;
        private System.Windows.Forms.ComboBox issuedMedicineTxt0;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.TableLayoutPanel medicineContainer;
        private System.Windows.Forms.Button addCureBtn;
        private System.Windows.Forms.GroupBox nursePnl;
        private System.Windows.Forms.ComboBox nurseBox;
        private System.Windows.Forms.GroupBox directorPnl;
        private System.Windows.Forms.ComboBox directorBox;
        private System.Windows.Forms.GroupBox cardioReanimPnl;
        private System.Windows.Forms.ComboBox cardioReanimBox;
        private System.Windows.Forms.Panel issuedMedPnl0;
        private System.Windows.Forms.Label objectIdLbl0;
    }
}