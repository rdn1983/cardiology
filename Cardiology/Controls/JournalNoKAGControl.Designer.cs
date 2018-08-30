namespace Cardiology.Controls
{
    partial class JournalNoKAGControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JournalNoKAGControl));
            this.journalPnl = new System.Windows.Forms.Panel();
            this.visibledPanel = new System.Windows.Forms.Panel();
            this.docLbl = new System.Windows.Forms.Label();
            this.docBox = new System.Windows.Forms.ComboBox();
            this.complaintsTxt = new System.Windows.Forms.TextBox();
            this.monitorTxt = new System.Windows.Forms.TextBox();
            this.complaintsLbl = new System.Windows.Forms.Label();
            this.chssTxt = new System.Windows.Forms.ComboBox();
            this.psTxt = new System.Windows.Forms.ComboBox();
            this.startDateTxt = new System.Windows.Forms.DateTimePicker();
            this.chddTxt = new System.Windows.Forms.ComboBox();
            this.monitorLbl = new System.Windows.Forms.Label();
            this.adTxt = new System.Windows.Forms.ComboBox();
            this.addDayCb = new System.Windows.Forms.CheckBox();
            this.journalTxt = new System.Windows.Forms.RichTextBox();
            this.adLbl = new System.Windows.Forms.Label();
            this.chddLbl = new System.Windows.Forms.Label();
            this.startTimeTxt = new System.Windows.Forms.DateTimePicker();
            this.badRhytmBtn = new System.Windows.Forms.RadioButton();
            this.psLbl = new System.Windows.Forms.Label();
            this.chssLbl = new System.Windows.Forms.Label();
            this.goodRhytmBtn = new System.Windows.Forms.RadioButton();
            this.hideJournalBtn = new System.Windows.Forms.CheckBox();
            this.objectId0 = new System.Windows.Forms.Label();
            this.journalPnl.SuspendLayout();
            this.visibledPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // journalPnl
            // 
            this.journalPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.journalPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.journalPnl.Controls.Add(this.visibledPanel);
            this.journalPnl.Controls.Add(this.hideJournalBtn);
            this.journalPnl.Controls.Add(this.objectId0);
            this.journalPnl.Location = new System.Drawing.Point(3, 3);
            this.journalPnl.Name = "journalPnl";
            this.journalPnl.Size = new System.Drawing.Size(771, 211);
            this.journalPnl.TabIndex = 37;
            // 
            // visibledPanel
            // 
            this.visibledPanel.Controls.Add(this.docLbl);
            this.visibledPanel.Controls.Add(this.docBox);
            this.visibledPanel.Controls.Add(this.complaintsTxt);
            this.visibledPanel.Controls.Add(this.monitorTxt);
            this.visibledPanel.Controls.Add(this.complaintsLbl);
            this.visibledPanel.Controls.Add(this.chssTxt);
            this.visibledPanel.Controls.Add(this.psTxt);
            this.visibledPanel.Controls.Add(this.startDateTxt);
            this.visibledPanel.Controls.Add(this.chddTxt);
            this.visibledPanel.Controls.Add(this.monitorLbl);
            this.visibledPanel.Controls.Add(this.adTxt);
            this.visibledPanel.Controls.Add(this.addDayCb);
            this.visibledPanel.Controls.Add(this.journalTxt);
            this.visibledPanel.Controls.Add(this.adLbl);
            this.visibledPanel.Controls.Add(this.chddLbl);
            this.visibledPanel.Controls.Add(this.startTimeTxt);
            this.visibledPanel.Controls.Add(this.badRhytmBtn);
            this.visibledPanel.Controls.Add(this.psLbl);
            this.visibledPanel.Controls.Add(this.chssLbl);
            this.visibledPanel.Controls.Add(this.goodRhytmBtn);
            this.visibledPanel.Location = new System.Drawing.Point(3, 3);
            this.visibledPanel.Name = "visibledPanel";
            this.visibledPanel.Size = new System.Drawing.Size(761, 180);
            this.visibledPanel.TabIndex = 38;
            // 
            // docLbl
            // 
            this.docLbl.AutoSize = true;
            this.docLbl.Location = new System.Drawing.Point(415, 159);
            this.docLbl.Name = "docLbl";
            this.docLbl.Size = new System.Drawing.Size(112, 13);
            this.docLbl.TabIndex = 46;
            this.docLbl.Text = "Ответственный врач";
            // 
            // docBox
            // 
            this.docBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docBox.FormattingEnabled = true;
            this.docBox.Location = new System.Drawing.Point(532, 155);
            this.docBox.Name = "docBox";
            this.docBox.Size = new System.Drawing.Size(220, 21);
            this.docBox.TabIndex = 45;
            // 
            // complaintsTxt
            // 
            this.complaintsTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.complaintsTxt.Location = new System.Drawing.Point(324, 1);
            this.complaintsTxt.Name = "complaintsTxt";
            this.complaintsTxt.Size = new System.Drawing.Size(428, 20);
            this.complaintsTxt.TabIndex = 44;
            // 
            // monitorTxt
            // 
            this.monitorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monitorTxt.Location = new System.Drawing.Point(197, 129);
            this.monitorTxt.Name = "monitorTxt";
            this.monitorTxt.Size = new System.Drawing.Size(121, 20);
            this.monitorTxt.TabIndex = 7;
            // 
            // complaintsLbl
            // 
            this.complaintsLbl.AutoSize = true;
            this.complaintsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.complaintsLbl.Location = new System.Drawing.Point(262, 4);
            this.complaintsLbl.Name = "complaintsLbl";
            this.complaintsLbl.Size = new System.Drawing.Size(60, 13);
            this.complaintsLbl.TabIndex = 43;
            this.complaintsLbl.Text = "Жалобы:";
            // 
            // chssTxt
            // 
            this.chssTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chssTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chssTxt.FormattingEnabled = true;
            this.chssTxt.Location = new System.Drawing.Point(197, 54);
            this.chssTxt.Name = "chssTxt";
            this.chssTxt.Size = new System.Drawing.Size(121, 21);
            this.chssTxt.TabIndex = 12;
            // 
            // psTxt
            // 
            this.psTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.psTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.psTxt.FormattingEnabled = true;
            this.psTxt.Location = new System.Drawing.Point(197, 78);
            this.psTxt.Name = "psTxt";
            this.psTxt.Size = new System.Drawing.Size(121, 21);
            this.psTxt.TabIndex = 13;
            // 
            // startDateTxt
            // 
            this.startDateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTxt.Location = new System.Drawing.Point(4, 4);
            this.startDateTxt.Name = "startDateTxt";
            this.startDateTxt.Size = new System.Drawing.Size(100, 20);
            this.startDateTxt.TabIndex = 35;
            // 
            // chddTxt
            // 
            this.chddTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chddTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chddTxt.FormattingEnabled = true;
            this.chddTxt.Location = new System.Drawing.Point(197, 30);
            this.chddTxt.Name = "chddTxt";
            this.chddTxt.Size = new System.Drawing.Size(121, 21);
            this.chddTxt.TabIndex = 11;
            // 
            // monitorLbl
            // 
            this.monitorLbl.AutoSize = true;
            this.monitorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monitorLbl.Location = new System.Drawing.Point(131, 132);
            this.monitorLbl.Name = "monitorLbl";
            this.monitorLbl.Size = new System.Drawing.Size(62, 13);
            this.monitorLbl.TabIndex = 6;
            this.monitorLbl.Text = "Монитор:";
            // 
            // adTxt
            // 
            this.adTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adTxt.FormattingEnabled = true;
            this.adTxt.Items.AddRange(new object[] {
            "40/0",
            "50/10",
            "60/20",
            "70/30",
            "80/40",
            "90/50",
            "100/60",
            "110/70",
            "120/80",
            "130/90",
            "140/100",
            "150/110"});
            this.adTxt.Location = new System.Drawing.Point(197, 102);
            this.adTxt.Name = "adTxt";
            this.adTxt.Size = new System.Drawing.Size(121, 21);
            this.adTxt.TabIndex = 14;
            // 
            // addDayCb
            // 
            this.addDayCb.AutoSize = true;
            this.addDayCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addDayCb.Location = new System.Drawing.Point(107, 7);
            this.addDayCb.Name = "addDayCb";
            this.addDayCb.Size = new System.Drawing.Size(59, 17);
            this.addDayCb.TabIndex = 1;
            this.addDayCb.Text = "+ день";
            this.addDayCb.UseVisualStyleBackColor = true;
            // 
            // journalTxt
            // 
            this.journalTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.journalTxt.Location = new System.Drawing.Point(324, 30);
            this.journalTxt.Name = "journalTxt";
            this.journalTxt.Size = new System.Drawing.Size(428, 119);
            this.journalTxt.TabIndex = 15;
            this.journalTxt.Text = resources.GetString("journalTxt.Text");
            // 
            // adLbl
            // 
            this.adLbl.AutoSize = true;
            this.adLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adLbl.Location = new System.Drawing.Point(165, 110);
            this.adLbl.Name = "adLbl";
            this.adLbl.Size = new System.Drawing.Size(26, 13);
            this.adLbl.TabIndex = 19;
            this.adLbl.Text = "АД:";
            // 
            // chddLbl
            // 
            this.chddLbl.AutoSize = true;
            this.chddLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chddLbl.Location = new System.Drawing.Point(159, 36);
            this.chddLbl.Name = "chddLbl";
            this.chddLbl.Size = new System.Drawing.Size(36, 13);
            this.chddLbl.TabIndex = 16;
            this.chddLbl.Text = "ЧДД:";
            // 
            // startTimeTxt
            // 
            this.startTimeTxt.CustomFormat = "HH:mm tt";
            this.startTimeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startTimeTxt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimeTxt.Location = new System.Drawing.Point(4, 27);
            this.startTimeTxt.Name = "startTimeTxt";
            this.startTimeTxt.ShowUpDown = true;
            this.startTimeTxt.Size = new System.Drawing.Size(100, 20);
            this.startTimeTxt.TabIndex = 2;
            // 
            // badRhytmBtn
            // 
            this.badRhytmBtn.AutoSize = true;
            this.badRhytmBtn.Location = new System.Drawing.Point(3, 77);
            this.badRhytmBtn.Name = "badRhytmBtn";
            this.badRhytmBtn.Size = new System.Drawing.Size(128, 17);
            this.badRhytmBtn.TabIndex = 4;
            this.badRhytmBtn.TabStop = true;
            this.badRhytmBtn.Text = "Ритм неправильный";
            this.badRhytmBtn.UseVisualStyleBackColor = true;
            // 
            // psLbl
            // 
            this.psLbl.AutoSize = true;
            this.psLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.psLbl.Location = new System.Drawing.Point(169, 84);
            this.psLbl.Name = "psLbl";
            this.psLbl.Size = new System.Drawing.Size(22, 13);
            this.psLbl.TabIndex = 18;
            this.psLbl.Text = "Ps:";
            // 
            // chssLbl
            // 
            this.chssLbl.AutoSize = true;
            this.chssLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chssLbl.Location = new System.Drawing.Point(163, 60);
            this.chssLbl.Name = "chssLbl";
            this.chssLbl.Size = new System.Drawing.Size(32, 13);
            this.chssLbl.TabIndex = 17;
            this.chssLbl.Text = "ЧСС:";
            // 
            // goodRhytmBtn
            // 
            this.goodRhytmBtn.AutoSize = true;
            this.goodRhytmBtn.Location = new System.Drawing.Point(4, 53);
            this.goodRhytmBtn.Name = "goodRhytmBtn";
            this.goodRhytmBtn.Size = new System.Drawing.Size(116, 17);
            this.goodRhytmBtn.TabIndex = 3;
            this.goodRhytmBtn.TabStop = true;
            this.goodRhytmBtn.Text = "Ритм правильный";
            this.goodRhytmBtn.UseVisualStyleBackColor = true;
            // 
            // hideJournalBtn
            // 
            this.hideJournalBtn.AutoSize = true;
            this.hideJournalBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hideJournalBtn.Location = new System.Drawing.Point(327, 189);
            this.hideJournalBtn.Name = "hideJournalBtn";
            this.hideJournalBtn.Size = new System.Drawing.Size(109, 17);
            this.hideJournalBtn.TabIndex = 5;
            this.hideJournalBtn.Text = "Скрыть дневник";
            this.hideJournalBtn.UseVisualStyleBackColor = true;
            this.hideJournalBtn.CheckedChanged += new System.EventHandler(this.hideJournalBtn_CheckedChanged);
            // 
            // objectId0
            // 
            this.objectId0.AutoSize = true;
            this.objectId0.Location = new System.Drawing.Point(755, 112);
            this.objectId0.Name = "objectId0";
            this.objectId0.Size = new System.Drawing.Size(0, 13);
            this.objectId0.TabIndex = 36;
            this.objectId0.Visible = false;
            // 
            // JournalNoKAGControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.journalPnl);
            this.Name = "JournalNoKAGControl";
            this.Size = new System.Drawing.Size(777, 217);
            this.journalPnl.ResumeLayout(false);
            this.journalPnl.PerformLayout();
            this.visibledPanel.ResumeLayout(false);
            this.visibledPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel journalPnl;
        private System.Windows.Forms.TextBox complaintsTxt;
        private System.Windows.Forms.Label complaintsLbl;
        private System.Windows.Forms.Label objectId0;
        private System.Windows.Forms.DateTimePicker startDateTxt;
        private System.Windows.Forms.Label monitorLbl;
        private System.Windows.Forms.CheckBox addDayCb;
        private System.Windows.Forms.Label adLbl;
        private System.Windows.Forms.DateTimePicker startTimeTxt;
        private System.Windows.Forms.Label psLbl;
        private System.Windows.Forms.RadioButton goodRhytmBtn;
        private System.Windows.Forms.Label chssLbl;
        private System.Windows.Forms.RadioButton badRhytmBtn;
        private System.Windows.Forms.Label chddLbl;
        private System.Windows.Forms.CheckBox hideJournalBtn;
        private System.Windows.Forms.RichTextBox journalTxt;
        private System.Windows.Forms.TextBox monitorTxt;
        private System.Windows.Forms.ComboBox adTxt;
        private System.Windows.Forms.ComboBox chddTxt;
        private System.Windows.Forms.ComboBox psTxt;
        private System.Windows.Forms.ComboBox chssTxt;
        private System.Windows.Forms.Panel visibledPanel;
        private System.Windows.Forms.Label docLbl;
        private System.Windows.Forms.ComboBox docBox;
    }
}
