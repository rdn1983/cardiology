namespace Cardiology.UI.Controls
{
    partial class JournalKAGControl
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
            this.inspectionDate0 = new System.Windows.Forms.DateTimePicker();
            this.hidingPnl0 = new System.Windows.Forms.Panel();
            this.shuffleBtn = new System.Windows.Forms.Button();
            this.badRhytmBtn0 = new System.Windows.Forms.RadioButton();
            this.journalTxt = new System.Windows.Forms.RichTextBox();
            this.goodRhytmBtn0 = new System.Windows.Forms.RadioButton();
            this.chssTxt = new System.Windows.Forms.ComboBox();
            this.monitorLbl0 = new System.Windows.Forms.Label();
            this.chddTxt = new System.Windows.Forms.ComboBox();
            this.adLbl0 = new System.Windows.Forms.Label();
            this.adTxt = new System.Windows.Forms.ComboBox();
            this.chssLbl0 = new System.Windows.Forms.Label();
            this.monitorTxt0 = new System.Windows.Forms.TextBox();
            this.chddLbl0 = new System.Windows.Forms.Label();
            this.hideBtn0 = new System.Windows.Forms.CheckBox();
            this.inspectionTime0 = new System.Windows.Forms.DateTimePicker();
            this.freeze = new System.Windows.Forms.CheckBox();
            this.remove = new System.Windows.Forms.Button();
            this.hidingPnl0.SuspendLayout();
            this.SuspendLayout();
            // 
            // inspectionDate0
            // 
            this.inspectionDate0.CustomFormat = "";
            this.inspectionDate0.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inspectionDate0.Location = new System.Drawing.Point(3, 3);
            this.inspectionDate0.Name = "inspectionDate0";
            this.inspectionDate0.Size = new System.Drawing.Size(97, 20);
            this.inspectionDate0.TabIndex = 14;
            // 
            // hidingPnl0
            // 
            this.hidingPnl0.Controls.Add(this.shuffleBtn);
            this.hidingPnl0.Controls.Add(this.badRhytmBtn0);
            this.hidingPnl0.Controls.Add(this.journalTxt);
            this.hidingPnl0.Controls.Add(this.goodRhytmBtn0);
            this.hidingPnl0.Controls.Add(this.chssTxt);
            this.hidingPnl0.Controls.Add(this.monitorLbl0);
            this.hidingPnl0.Controls.Add(this.chddTxt);
            this.hidingPnl0.Controls.Add(this.adLbl0);
            this.hidingPnl0.Controls.Add(this.adTxt);
            this.hidingPnl0.Controls.Add(this.chssLbl0);
            this.hidingPnl0.Controls.Add(this.monitorTxt0);
            this.hidingPnl0.Controls.Add(this.chddLbl0);
            this.hidingPnl0.Location = new System.Drawing.Point(2, 26);
            this.hidingPnl0.Name = "hidingPnl0";
            this.hidingPnl0.Size = new System.Drawing.Size(770, 79);
            this.hidingPnl0.TabIndex = 13;
            // 
            // shuffleBtn
            // 
            this.shuffleBtn.Image = global::Cardiology.Properties.Resources.shuffle;
            this.shuffleBtn.Location = new System.Drawing.Point(577, 2);
            this.shuffleBtn.Name = "shuffleBtn";
            this.shuffleBtn.Size = new System.Drawing.Size(25, 73);
            this.shuffleBtn.TabIndex = 15;
            this.shuffleBtn.UseVisualStyleBackColor = true;
            this.shuffleBtn.Click += new System.EventHandler(this.shuffleBtn_Click);
            // 
            // badRhytmBtn0
            // 
            this.badRhytmBtn0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.badRhytmBtn0.AutoSize = true;
            this.badRhytmBtn0.Location = new System.Drawing.Point(686, 2);
            this.badRhytmBtn0.Name = "badRhytmBtn0";
            this.badRhytmBtn0.Size = new System.Drawing.Size(85, 30);
            this.badRhytmBtn0.TabIndex = 1;
            this.badRhytmBtn0.Text = "трепетание\r\nпредсердий";
            this.badRhytmBtn0.UseVisualStyleBackColor = true;
            this.badRhytmBtn0.CheckedChanged += new System.EventHandler(this.goodRhytmBtn0_CheckedChanged);
            // 
            // journalTxt
            // 
            this.journalTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.journalTxt.Location = new System.Drawing.Point(5, 7);
            this.journalTxt.Name = "journalTxt";
            this.journalTxt.Size = new System.Drawing.Size(462, 71);
            this.journalTxt.TabIndex = 1;
            this.journalTxt.Text = "";
            // 
            // goodRhytmBtn0
            // 
            this.goodRhytmBtn0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goodRhytmBtn0.AutoSize = true;
            this.goodRhytmBtn0.Checked = true;
            this.goodRhytmBtn0.Location = new System.Drawing.Point(608, 2);
            this.goodRhytmBtn0.Name = "goodRhytmBtn0";
            this.goodRhytmBtn0.Size = new System.Drawing.Size(80, 30);
            this.goodRhytmBtn0.TabIndex = 0;
            this.goodRhytmBtn0.TabStop = true;
            this.goodRhytmBtn0.Text = "синусовый\r\nритм";
            this.goodRhytmBtn0.UseVisualStyleBackColor = true;
            this.goodRhytmBtn0.CheckedChanged += new System.EventHandler(this.goodRhytmBtn0_CheckedChanged);
            // 
            // chssTxt
            // 
            this.chssTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chssTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chssTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chssTxt.FormattingEnabled = true;
            this.chssTxt.Location = new System.Drawing.Point(510, 54);
            this.chssTxt.Name = "chssTxt";
            this.chssTxt.Size = new System.Drawing.Size(66, 21);
            this.chssTxt.TabIndex = 33;
            this.chssTxt.SelectedIndexChanged += new System.EventHandler(this.chssText0_SelectedIndexChanged);
            // 
            // monitorLbl0
            // 
            this.monitorLbl0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorLbl0.AutoSize = true;
            this.monitorLbl0.Location = new System.Drawing.Point(650, 32);
            this.monitorLbl0.Name = "monitorLbl0";
            this.monitorLbl0.Size = new System.Drawing.Size(54, 13);
            this.monitorLbl0.TabIndex = 30;
            this.monitorLbl0.Text = "Монитор:";
            // 
            // chddTxt
            // 
            this.chddTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chddTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chddTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chddTxt.FormattingEnabled = true;
            this.chddTxt.Location = new System.Drawing.Point(510, 3);
            this.chddTxt.Name = "chddTxt";
            this.chddTxt.Size = new System.Drawing.Size(66, 21);
            this.chddTxt.TabIndex = 32;
            this.chddTxt.SelectedIndexChanged += new System.EventHandler(this.chddTxt0_SelectedIndexChanged);
            // 
            // adLbl0
            // 
            this.adLbl0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adLbl0.AutoSize = true;
            this.adLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adLbl0.Location = new System.Drawing.Point(478, 32);
            this.adLbl0.Name = "adLbl0";
            this.adLbl0.Size = new System.Drawing.Size(26, 13);
            this.adLbl0.TabIndex = 37;
            this.adLbl0.Text = "АД:";
            // 
            // adTxt
            // 
            this.adTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.adTxt.Location = new System.Drawing.Point(510, 29);
            this.adTxt.Name = "adTxt";
            this.adTxt.Size = new System.Drawing.Size(66, 21);
            this.adTxt.TabIndex = 34;
            this.adTxt.SelectedIndexChanged += new System.EventHandler(this.adText0_SelectedIndexChanged);
            // 
            // chssLbl0
            // 
            this.chssLbl0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chssLbl0.AutoSize = true;
            this.chssLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chssLbl0.Location = new System.Drawing.Point(472, 57);
            this.chssLbl0.Name = "chssLbl0";
            this.chssLbl0.Size = new System.Drawing.Size(32, 13);
            this.chssLbl0.TabIndex = 36;
            this.chssLbl0.Text = "ЧСС:";
            // 
            // monitorTxt0
            // 
            this.monitorTxt0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monitorTxt0.Location = new System.Drawing.Point(603, 52);
            this.monitorTxt0.Name = "monitorTxt0";
            this.monitorTxt0.ReadOnly = true;
            this.monitorTxt0.Size = new System.Drawing.Size(160, 20);
            this.monitorTxt0.TabIndex = 31;
            // 
            // chddLbl0
            // 
            this.chddLbl0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chddLbl0.AutoSize = true;
            this.chddLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chddLbl0.Location = new System.Drawing.Point(468, 6);
            this.chddLbl0.Name = "chddLbl0";
            this.chddLbl0.Size = new System.Drawing.Size(36, 13);
            this.chddLbl0.TabIndex = 35;
            this.chddLbl0.Text = "ЧДД:";
            // 
            // hideBtn0
            // 
            this.hideBtn0.AutoSize = true;
            this.hideBtn0.Location = new System.Drawing.Point(210, 8);
            this.hideBtn0.Name = "hideBtn0";
            this.hideBtn0.Size = new System.Drawing.Size(63, 17);
            this.hideBtn0.TabIndex = 10;
            this.hideBtn0.Text = "скрыть";
            this.hideBtn0.UseVisualStyleBackColor = true;
            this.hideBtn0.CheckedChanged += new System.EventHandler(this.hideBtn0_CheckedChanged);
            // 
            // inspectionTime0
            // 
            this.inspectionTime0.CustomFormat = "HH:mm tt";
            this.inspectionTime0.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inspectionTime0.Location = new System.Drawing.Point(106, 3);
            this.inspectionTime0.Name = "inspectionTime0";
            this.inspectionTime0.ShowUpDown = true;
            this.inspectionTime0.Size = new System.Drawing.Size(98, 20);
            this.inspectionTime0.TabIndex = 0;
            // 
            // freeze
            // 
            this.freeze.AutoSize = true;
            this.freeze.Location = new System.Drawing.Point(280, 8);
            this.freeze.Name = "freeze";
            this.freeze.Size = new System.Drawing.Size(155, 17);
            this.freeze.TabIndex = 15;
            this.freeze.Text = "Не пересчитывать время";
            this.freeze.UseVisualStyleBackColor = true;
            // 
            // remove
            // 
            this.remove.Image = global::Cardiology.Properties.Resources.remove;
            this.remove.Location = new System.Drawing.Point(747, 0);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(26, 23);
            this.remove.TabIndex = 16;
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // JournalKAGControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.remove);
            this.Controls.Add(this.freeze);
            this.Controls.Add(this.hidingPnl0);
            this.Controls.Add(this.inspectionDate0);
            this.Controls.Add(this.hideBtn0);
            this.Controls.Add(this.inspectionTime0);
            this.Name = "JournalKAGControl";
            this.Size = new System.Drawing.Size(776, 108);
            this.hidingPnl0.ResumeLayout(false);
            this.hidingPnl0.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker inspectionDate0;
        private System.Windows.Forms.Panel hidingPnl0;
        private System.Windows.Forms.RadioButton badRhytmBtn0;
        private System.Windows.Forms.RichTextBox journalTxt;
        private System.Windows.Forms.RadioButton goodRhytmBtn0;
        private System.Windows.Forms.ComboBox chssTxt;
        private System.Windows.Forms.Label monitorLbl0;
        private System.Windows.Forms.ComboBox chddTxt;
        private System.Windows.Forms.Label adLbl0;
        private System.Windows.Forms.ComboBox adTxt;
        private System.Windows.Forms.Label chssLbl0;
        private System.Windows.Forms.TextBox monitorTxt0;
        private System.Windows.Forms.Label chddLbl0;
        private System.Windows.Forms.CheckBox hideBtn0;
        private System.Windows.Forms.DateTimePicker inspectionTime0;
        private System.Windows.Forms.Button shuffleBtn;
        private System.Windows.Forms.CheckBox freeze;
        private System.Windows.Forms.Button remove;
    }
}
