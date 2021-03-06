﻿namespace Cardiology.UI.Controls
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
            this.visibledPanel = new System.Windows.Forms.Panel();
            this.shuffleBtn = new System.Windows.Forms.Button();
            this.warningLbl = new System.Windows.Forms.Label();
            this.docLbl = new System.Windows.Forms.Label();
            this.docBox = new System.Windows.Forms.ComboBox();
            this.complaintsTxt = new System.Windows.Forms.TextBox();
            this.monitorTxt = new System.Windows.Forms.TextBox();
            this.complaintsLbl = new System.Windows.Forms.Label();
            this.chssTxt = new System.Windows.Forms.ComboBox();
            this.startDateTxt = new System.Windows.Forms.DateTimePicker();
            this.chddTxt = new System.Windows.Forms.ComboBox();
            this.monitorLbl = new System.Windows.Forms.Label();
            this.adTxt = new System.Windows.Forms.ComboBox();
            this.journalTxt = new System.Windows.Forms.RichTextBox();
            this.adLbl = new System.Windows.Forms.Label();
            this.chddLbl = new System.Windows.Forms.Label();
            this.startTimeTxt = new System.Windows.Forms.DateTimePicker();
            this.badRhytmBtn = new System.Windows.Forms.RadioButton();
            this.chssLbl = new System.Windows.Forms.Label();
            this.goodRhytmBtn = new System.Windows.Forms.RadioButton();
            this.hideJournalBtn = new System.Windows.Forms.CheckBox();
            this.remove = new System.Windows.Forms.Button();
            this.freeze = new System.Windows.Forms.CheckBox();
            this.visibledPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // visibledPanel
            // 
            this.visibledPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visibledPanel.Controls.Add(this.shuffleBtn);
            this.visibledPanel.Controls.Add(this.warningLbl);
            this.visibledPanel.Controls.Add(this.docLbl);
            this.visibledPanel.Controls.Add(this.docBox);
            this.visibledPanel.Controls.Add(this.complaintsTxt);
            this.visibledPanel.Controls.Add(this.monitorTxt);
            this.visibledPanel.Controls.Add(this.complaintsLbl);
            this.visibledPanel.Controls.Add(this.chssTxt);
            this.visibledPanel.Controls.Add(this.startDateTxt);
            this.visibledPanel.Controls.Add(this.chddTxt);
            this.visibledPanel.Controls.Add(this.monitorLbl);
            this.visibledPanel.Controls.Add(this.adTxt);
            this.visibledPanel.Controls.Add(this.journalTxt);
            this.visibledPanel.Controls.Add(this.adLbl);
            this.visibledPanel.Controls.Add(this.chddLbl);
            this.visibledPanel.Controls.Add(this.startTimeTxt);
            this.visibledPanel.Controls.Add(this.badRhytmBtn);
            this.visibledPanel.Controls.Add(this.chssLbl);
            this.visibledPanel.Controls.Add(this.goodRhytmBtn);
            this.visibledPanel.Location = new System.Drawing.Point(3, 3);
            this.visibledPanel.Name = "visibledPanel";
            this.visibledPanel.Size = new System.Drawing.Size(678, 149);
            this.visibledPanel.TabIndex = 38;
            // 
            // shuffleBtn
            // 
            this.shuffleBtn.Image = global::Cardiology.Properties.Resources.shuffle;
            this.shuffleBtn.Location = new System.Drawing.Point(231, 28);
            this.shuffleBtn.Name = "shuffleBtn";
            this.shuffleBtn.Size = new System.Drawing.Size(25, 73);
            this.shuffleBtn.TabIndex = 48;
            this.shuffleBtn.UseVisualStyleBackColor = true;
            this.shuffleBtn.Click += new System.EventHandler(this.shuffleBtn_Click);
            // 
            // warningLbl
            // 
            this.warningLbl.AutoSize = true;
            this.warningLbl.ForeColor = System.Drawing.Color.Maroon;
            this.warningLbl.Location = new System.Drawing.Point(168, 106);
            this.warningLbl.Name = "warningLbl";
            this.warningLbl.Size = new System.Drawing.Size(233, 13);
            this.warningLbl.TabIndex = 47;
            this.warningLbl.Text = "Выберите значения для ЧСС, ЧД, АД, врача";
            // 
            // docLbl
            // 
            this.docLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.docLbl.AutoSize = true;
            this.docLbl.Location = new System.Drawing.Point(331, 125);
            this.docLbl.Name = "docLbl";
            this.docLbl.Size = new System.Drawing.Size(112, 13);
            this.docLbl.TabIndex = 46;
            this.docLbl.Text = "Ответственный врач";
            // 
            // docBox
            // 
            this.docBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.docBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docBox.FormattingEnabled = true;
            this.docBox.Location = new System.Drawing.Point(448, 121);
            this.docBox.Name = "docBox";
            this.docBox.Size = new System.Drawing.Size(220, 21);
            this.docBox.TabIndex = 45;
            this.docBox.SelectedIndexChanged += new System.EventHandler(this.docBox_SelectedIndexChanged);
            // 
            // complaintsTxt
            // 
            this.complaintsTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.complaintsTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.complaintsTxt.Location = new System.Drawing.Point(259, 1);
            this.complaintsTxt.Name = "complaintsTxt";
            this.complaintsTxt.Size = new System.Drawing.Size(410, 20);
            this.complaintsTxt.TabIndex = 44;
            this.complaintsTxt.Text = "жалобы на слабость";
            // 
            // monitorTxt
            // 
            this.monitorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monitorTxt.Location = new System.Drawing.Point(10, 122);
            this.monitorTxt.Name = "monitorTxt";
            this.monitorTxt.ReadOnly = true;
            this.monitorTxt.Size = new System.Drawing.Size(121, 20);
            this.monitorTxt.TabIndex = 7;
            this.monitorTxt.Text = "синусовый ритм";
            // 
            // complaintsLbl
            // 
            this.complaintsLbl.AutoSize = true;
            this.complaintsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.complaintsLbl.Location = new System.Drawing.Point(197, 3);
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
            this.chssTxt.Location = new System.Drawing.Point(172, 54);
            this.chssTxt.Name = "chssTxt";
            this.chssTxt.Size = new System.Drawing.Size(56, 21);
            this.chssTxt.TabIndex = 12;
            this.chssTxt.SelectedIndexChanged += new System.EventHandler(this.chssTxt_SelectedIndexChanged);
            // 
            // startDateTxt
            // 
            this.startDateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTxt.Location = new System.Drawing.Point(4, 4);
            this.startDateTxt.Name = "startDateTxt";
            this.startDateTxt.Size = new System.Drawing.Size(100, 20);
            this.startDateTxt.TabIndex = 35;
            this.startDateTxt.ValueChanged += new System.EventHandler(this.TimeTxt_ValueChanged);
            // 
            // chddTxt
            // 
            this.chddTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chddTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chddTxt.FormattingEnabled = true;
            this.chddTxt.Location = new System.Drawing.Point(172, 30);
            this.chddTxt.Name = "chddTxt";
            this.chddTxt.Size = new System.Drawing.Size(56, 21);
            this.chddTxt.TabIndex = 11;
            this.chddTxt.SelectedIndexChanged += new System.EventHandler(this.chddTxt_SelectedIndexChanged);
            // 
            // monitorLbl
            // 
            this.monitorLbl.AutoSize = true;
            this.monitorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monitorLbl.Location = new System.Drawing.Point(31, 106);
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
            this.adTxt.Location = new System.Drawing.Point(172, 78);
            this.adTxt.Name = "adTxt";
            this.adTxt.Size = new System.Drawing.Size(56, 21);
            this.adTxt.TabIndex = 14;
            this.adTxt.SelectedIndexChanged += new System.EventHandler(this.adTxt_SelectedIndexChanged);
            // 
            // journalTxt
            // 
            this.journalTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.journalTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.journalTxt.Location = new System.Drawing.Point(259, 28);
            this.journalTxt.Name = "journalTxt";
            this.journalTxt.Size = new System.Drawing.Size(411, 72);
            this.journalTxt.TabIndex = 15;
            this.journalTxt.Text = "";
            this.journalTxt.TextChanged += new System.EventHandler(this.journalTxt_TextChanged);
            // 
            // adLbl
            // 
            this.adLbl.AutoSize = true;
            this.adLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adLbl.Location = new System.Drawing.Point(143, 85);
            this.adLbl.Name = "adLbl";
            this.adLbl.Size = new System.Drawing.Size(26, 13);
            this.adLbl.TabIndex = 19;
            this.adLbl.Text = "АД:";
            // 
            // chddLbl
            // 
            this.chddLbl.AutoSize = true;
            this.chddLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chddLbl.Location = new System.Drawing.Point(139, 36);
            this.chddLbl.Name = "chddLbl";
            this.chddLbl.Size = new System.Drawing.Size(27, 13);
            this.chddLbl.TabIndex = 16;
            this.chddLbl.Text = "ЧД:";
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
            this.startTimeTxt.ValueChanged += new System.EventHandler(this.TimeTxt_ValueChanged);
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
            this.badRhytmBtn.CheckedChanged += new System.EventHandler(this.goodRhytmBtn_CheckedChanged);
            // 
            // chssLbl
            // 
            this.chssLbl.AutoSize = true;
            this.chssLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chssLbl.Location = new System.Drawing.Point(138, 60);
            this.chssLbl.Name = "chssLbl";
            this.chssLbl.Size = new System.Drawing.Size(32, 13);
            this.chssLbl.TabIndex = 17;
            this.chssLbl.Text = "ЧСС:";
            // 
            // goodRhytmBtn
            // 
            this.goodRhytmBtn.AutoSize = true;
            this.goodRhytmBtn.Checked = true;
            this.goodRhytmBtn.Location = new System.Drawing.Point(4, 53);
            this.goodRhytmBtn.Name = "goodRhytmBtn";
            this.goodRhytmBtn.Size = new System.Drawing.Size(116, 17);
            this.goodRhytmBtn.TabIndex = 3;
            this.goodRhytmBtn.TabStop = true;
            this.goodRhytmBtn.Text = "Ритм правильный";
            this.goodRhytmBtn.UseVisualStyleBackColor = true;
            this.goodRhytmBtn.CheckedChanged += new System.EventHandler(this.goodRhytmBtn_CheckedChanged);
            // 
            // hideJournalBtn
            // 
            this.hideJournalBtn.AutoSize = true;
            this.hideJournalBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hideJournalBtn.Location = new System.Drawing.Point(262, 159);
            this.hideJournalBtn.Name = "hideJournalBtn";
            this.hideJournalBtn.Size = new System.Drawing.Size(109, 17);
            this.hideJournalBtn.TabIndex = 5;
            this.hideJournalBtn.Text = "Скрыть дневник";
            this.hideJournalBtn.UseVisualStyleBackColor = true;
            this.hideJournalBtn.CheckedChanged += new System.EventHandler(this.hideJournalBtn_CheckedChanged);
            // 
            // remove
            // 
            this.remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remove.Image = global::Cardiology.Properties.Resources.remove;
            this.remove.Location = new System.Drawing.Point(680, 1);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(26, 23);
            this.remove.TabIndex = 39;
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // freeze
            // 
            this.freeze.AutoSize = true;
            this.freeze.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.freeze.Location = new System.Drawing.Point(377, 159);
            this.freeze.Name = "freeze";
            this.freeze.Size = new System.Drawing.Size(155, 17);
            this.freeze.TabIndex = 40;
            this.freeze.Text = "Не пересчитывать время";
            this.freeze.UseVisualStyleBackColor = true;
            // 
            // JournalNoKAGControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.freeze);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.hideJournalBtn);
            this.Controls.Add(this.visibledPanel);
            this.Name = "JournalNoKAGControl";
            this.Size = new System.Drawing.Size(709, 179);
            this.visibledPanel.ResumeLayout(false);
            this.visibledPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox complaintsTxt;
        private System.Windows.Forms.Label complaintsLbl;
        private System.Windows.Forms.DateTimePicker startDateTxt;
        private System.Windows.Forms.Label monitorLbl;
        private System.Windows.Forms.Label adLbl;
        private System.Windows.Forms.DateTimePicker startTimeTxt;
        private System.Windows.Forms.RadioButton goodRhytmBtn;
        private System.Windows.Forms.Label chssLbl;
        private System.Windows.Forms.RadioButton badRhytmBtn;
        private System.Windows.Forms.Label chddLbl;
        private System.Windows.Forms.CheckBox hideJournalBtn;
        private System.Windows.Forms.RichTextBox journalTxt;
        private System.Windows.Forms.TextBox monitorTxt;
        private System.Windows.Forms.ComboBox adTxt;
        private System.Windows.Forms.ComboBox chddTxt;
        private System.Windows.Forms.ComboBox chssTxt;
        private System.Windows.Forms.Panel visibledPanel;
        private System.Windows.Forms.Label docLbl;
        private System.Windows.Forms.ComboBox docBox;
        private System.Windows.Forms.Label warningLbl;
        private System.Windows.Forms.Button shuffleBtn;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.CheckBox freeze;
    }
}
