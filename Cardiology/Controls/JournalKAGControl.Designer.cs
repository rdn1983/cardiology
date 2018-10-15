namespace Cardiology.Controls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JournalKAGControl));
            this.inspectionDate0 = new System.Windows.Forms.DateTimePicker();
            this.hidingPnl0 = new System.Windows.Forms.Panel();
            this.badRhytmBtn0 = new System.Windows.Forms.RadioButton();
            this.inspectionTxt0 = new System.Windows.Forms.RichTextBox();
            this.goodRhytmBtn0 = new System.Windows.Forms.RadioButton();
            this.chssText0 = new System.Windows.Forms.ComboBox();
            this.monitorLbl0 = new System.Windows.Forms.Label();
            this.chddTxt0 = new System.Windows.Forms.ComboBox();
            this.adLbl0 = new System.Windows.Forms.Label();
            this.adText0 = new System.Windows.Forms.ComboBox();
            this.chssLbl0 = new System.Windows.Forms.Label();
            this.monitorTxt0 = new System.Windows.Forms.TextBox();
            this.chddLbl0 = new System.Windows.Forms.Label();
            this.hideBtn0 = new System.Windows.Forms.CheckBox();
            this.inspectionTime0 = new System.Windows.Forms.DateTimePicker();
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
            this.hidingPnl0.Controls.Add(this.badRhytmBtn0);
            this.hidingPnl0.Controls.Add(this.inspectionTxt0);
            this.hidingPnl0.Controls.Add(this.goodRhytmBtn0);
            this.hidingPnl0.Controls.Add(this.chssText0);
            this.hidingPnl0.Controls.Add(this.monitorLbl0);
            this.hidingPnl0.Controls.Add(this.chddTxt0);
            this.hidingPnl0.Controls.Add(this.adLbl0);
            this.hidingPnl0.Controls.Add(this.adText0);
            this.hidingPnl0.Controls.Add(this.chssLbl0);
            this.hidingPnl0.Controls.Add(this.monitorTxt0);
            this.hidingPnl0.Controls.Add(this.chddLbl0);
            this.hidingPnl0.Location = new System.Drawing.Point(2, 26);
            this.hidingPnl0.Name = "hidingPnl0";
            this.hidingPnl0.Size = new System.Drawing.Size(720, 79);
            this.hidingPnl0.TabIndex = 13;
            // 
            // badRhytmBtn0
            // 
            this.badRhytmBtn0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.badRhytmBtn0.AutoSize = true;
            this.badRhytmBtn0.Location = new System.Drawing.Point(632, 2);
            this.badRhytmBtn0.Name = "badRhytmBtn0";
            this.badRhytmBtn0.Size = new System.Drawing.Size(85, 30);
            this.badRhytmBtn0.TabIndex = 1;
            this.badRhytmBtn0.TabStop = true;
            this.badRhytmBtn0.Text = "трепетание\r\nпредсердий";
            this.badRhytmBtn0.UseVisualStyleBackColor = true;
            this.badRhytmBtn0.CheckedChanged += new System.EventHandler(this.goodRhytmBtn0_CheckedChanged);
            // 
            // inspectionTxt0
            // 
            this.inspectionTxt0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inspectionTxt0.Location = new System.Drawing.Point(5, 7);
            this.inspectionTxt0.Name = "inspectionTxt0";
            this.inspectionTxt0.Size = new System.Drawing.Size(462, 71);
            this.inspectionTxt0.TabIndex = 1;
            this.inspectionTxt0.Text = resources.GetString("inspectionTxt0.Text");
            // 
            // goodRhytmBtn0
            // 
            this.goodRhytmBtn0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goodRhytmBtn0.AutoSize = true;
            this.goodRhytmBtn0.Location = new System.Drawing.Point(553, 2);
            this.goodRhytmBtn0.Name = "goodRhytmBtn0";
            this.goodRhytmBtn0.Size = new System.Drawing.Size(80, 30);
            this.goodRhytmBtn0.TabIndex = 0;
            this.goodRhytmBtn0.TabStop = true;
            this.goodRhytmBtn0.Text = "синусовый\r\nритм";
            this.goodRhytmBtn0.UseVisualStyleBackColor = true;
            this.goodRhytmBtn0.CheckedChanged += new System.EventHandler(this.goodRhytmBtn0_CheckedChanged);
            // 
            // chssText0
            // 
            this.chssText0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chssText0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chssText0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chssText0.FormattingEnabled = true;
            this.chssText0.Location = new System.Drawing.Point(502, 55);
            this.chssText0.Name = "chssText0";
            this.chssText0.Size = new System.Drawing.Size(44, 21);
            this.chssText0.TabIndex = 33;
            // 
            // monitorLbl0
            // 
            this.monitorLbl0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorLbl0.AutoSize = true;
            this.monitorLbl0.Location = new System.Drawing.Point(600, 32);
            this.monitorLbl0.Name = "monitorLbl0";
            this.monitorLbl0.Size = new System.Drawing.Size(54, 13);
            this.monitorLbl0.TabIndex = 30;
            this.monitorLbl0.Text = "Монитор:";
            // 
            // chddTxt0
            // 
            this.chddTxt0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chddTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chddTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chddTxt0.FormattingEnabled = true;
            this.chddTxt0.Location = new System.Drawing.Point(502, 4);
            this.chddTxt0.Name = "chddTxt0";
            this.chddTxt0.Size = new System.Drawing.Size(44, 21);
            this.chddTxt0.TabIndex = 32;
            // 
            // adLbl0
            // 
            this.adLbl0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adLbl0.AutoSize = true;
            this.adLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adLbl0.Location = new System.Drawing.Point(473, 35);
            this.adLbl0.Name = "adLbl0";
            this.adLbl0.Size = new System.Drawing.Size(26, 13);
            this.adLbl0.TabIndex = 37;
            this.adLbl0.Text = "АД:";
            // 
            // adText0
            // 
            this.adText0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adText0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adText0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adText0.FormattingEnabled = true;
            this.adText0.Items.AddRange(new object[] {
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
            this.adText0.Location = new System.Drawing.Point(502, 30);
            this.adText0.Name = "adText0";
            this.adText0.Size = new System.Drawing.Size(44, 21);
            this.adText0.TabIndex = 34;
            // 
            // chssLbl0
            // 
            this.chssLbl0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chssLbl0.AutoSize = true;
            this.chssLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chssLbl0.Location = new System.Drawing.Point(467, 60);
            this.chssLbl0.Name = "chssLbl0";
            this.chssLbl0.Size = new System.Drawing.Size(32, 13);
            this.chssLbl0.TabIndex = 36;
            this.chssLbl0.Text = "ЧСС:";
            // 
            // monitorTxt0
            // 
            this.monitorTxt0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monitorTxt0.Location = new System.Drawing.Point(553, 52);
            this.monitorTxt0.Name = "monitorTxt0";
            this.monitorTxt0.Size = new System.Drawing.Size(160, 20);
            this.monitorTxt0.TabIndex = 31;
            // 
            // chddLbl0
            // 
            this.chddLbl0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chddLbl0.AutoSize = true;
            this.chddLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chddLbl0.Location = new System.Drawing.Point(463, 9);
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
            // JournalKAGControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.hidingPnl0);
            this.Controls.Add(this.inspectionDate0);
            this.Controls.Add(this.hideBtn0);
            this.Controls.Add(this.inspectionTime0);
            this.Name = "JournalKAGControl";
            this.Size = new System.Drawing.Size(725, 108);
            this.hidingPnl0.ResumeLayout(false);
            this.hidingPnl0.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker inspectionDate0;
        private System.Windows.Forms.Panel hidingPnl0;
        private System.Windows.Forms.RadioButton badRhytmBtn0;
        private System.Windows.Forms.RichTextBox inspectionTxt0;
        private System.Windows.Forms.RadioButton goodRhytmBtn0;
        private System.Windows.Forms.ComboBox chssText0;
        private System.Windows.Forms.Label monitorLbl0;
        private System.Windows.Forms.ComboBox chddTxt0;
        private System.Windows.Forms.Label adLbl0;
        private System.Windows.Forms.ComboBox adText0;
        private System.Windows.Forms.Label chssLbl0;
        private System.Windows.Forms.TextBox monitorTxt0;
        private System.Windows.Forms.Label chddLbl0;
        private System.Windows.Forms.CheckBox hideBtn0;
        private System.Windows.Forms.DateTimePicker inspectionTime0;
    }
}
