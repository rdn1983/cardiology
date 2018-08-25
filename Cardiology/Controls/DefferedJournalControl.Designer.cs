namespace Cardiology.Controls
{
    partial class DefferedJournalControl
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
            this.visibledPnl = new System.Windows.Forms.Panel();
            this.deferredStartDate = new System.Windows.Forms.DateTimePicker();
            this.deferredStartTime = new System.Windows.Forms.DateTimePicker();
            this.deferredAdLbl = new System.Windows.Forms.Label();
            this.deferredMonitorLbl = new System.Windows.Forms.Label();
            this.deferredPsLbl = new System.Windows.Forms.Label();
            this.deferredMonitorTxt = new System.Windows.Forms.TextBox();
            this.deferredChssLbl = new System.Windows.Forms.Label();
            this.defferedChddTxt = new System.Windows.Forms.ComboBox();
            this.deferredChddLbl = new System.Windows.Forms.Label();
            this.deferredChssTxt = new System.Windows.Forms.ComboBox();
            this.deferredJournalTxt = new System.Windows.Forms.RichTextBox();
            this.deferredPsTxt = new System.Windows.Forms.ComboBox();
            this.deferredAdTxt = new System.Windows.Forms.ComboBox();
            this.hideDefferedCb = new System.Windows.Forms.CheckBox();
            this.defferedPnl = new System.Windows.Forms.Panel();
            this.docBox = new System.Windows.Forms.ComboBox();
            this.docLbl = new System.Windows.Forms.Label();
            this.visibledPnl.SuspendLayout();
            this.defferedPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // visibledPnl
            // 
            this.visibledPnl.Controls.Add(this.docLbl);
            this.visibledPnl.Controls.Add(this.docBox);
            this.visibledPnl.Controls.Add(this.deferredStartDate);
            this.visibledPnl.Controls.Add(this.deferredStartTime);
            this.visibledPnl.Controls.Add(this.deferredAdLbl);
            this.visibledPnl.Controls.Add(this.deferredMonitorLbl);
            this.visibledPnl.Controls.Add(this.deferredPsLbl);
            this.visibledPnl.Controls.Add(this.deferredMonitorTxt);
            this.visibledPnl.Controls.Add(this.deferredChssLbl);
            this.visibledPnl.Controls.Add(this.defferedChddTxt);
            this.visibledPnl.Controls.Add(this.deferredChddLbl);
            this.visibledPnl.Controls.Add(this.deferredChssTxt);
            this.visibledPnl.Controls.Add(this.deferredJournalTxt);
            this.visibledPnl.Controls.Add(this.deferredPsTxt);
            this.visibledPnl.Controls.Add(this.deferredAdTxt);
            this.visibledPnl.Location = new System.Drawing.Point(3, 4);
            this.visibledPnl.Name = "visibledPnl";
            this.visibledPnl.Size = new System.Drawing.Size(665, 147);
            this.visibledPnl.TabIndex = 22;
            // 
            // deferredStartDate
            // 
            this.deferredStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.deferredStartDate.Location = new System.Drawing.Point(6, 4);
            this.deferredStartDate.Name = "deferredStartDate";
            this.deferredStartDate.Size = new System.Drawing.Size(93, 20);
            this.deferredStartDate.TabIndex = 20;
            // 
            // deferredStartTime
            // 
            this.deferredStartTime.CustomFormat = "HH:mm tt";
            this.deferredStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.deferredStartTime.Location = new System.Drawing.Point(128, 4);
            this.deferredStartTime.Name = "deferredStartTime";
            this.deferredStartTime.ShowUpDown = true;
            this.deferredStartTime.Size = new System.Drawing.Size(84, 20);
            this.deferredStartTime.TabIndex = 2;
            // 
            // deferredAdLbl
            // 
            this.deferredAdLbl.AutoSize = true;
            this.deferredAdLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredAdLbl.Location = new System.Drawing.Point(121, 62);
            this.deferredAdLbl.Name = "deferredAdLbl";
            this.deferredAdLbl.Size = new System.Drawing.Size(26, 13);
            this.deferredAdLbl.TabIndex = 19;
            this.deferredAdLbl.Text = "АД:";
            // 
            // deferredMonitorLbl
            // 
            this.deferredMonitorLbl.AutoSize = true;
            this.deferredMonitorLbl.Location = new System.Drawing.Point(32, 100);
            this.deferredMonitorLbl.Name = "deferredMonitorLbl";
            this.deferredMonitorLbl.Size = new System.Drawing.Size(54, 13);
            this.deferredMonitorLbl.TabIndex = 6;
            this.deferredMonitorLbl.Text = "Монитор:";
            // 
            // deferredPsLbl
            // 
            this.deferredPsLbl.AutoSize = true;
            this.deferredPsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredPsLbl.Location = new System.Drawing.Point(125, 36);
            this.deferredPsLbl.Name = "deferredPsLbl";
            this.deferredPsLbl.Size = new System.Drawing.Size(22, 13);
            this.deferredPsLbl.TabIndex = 18;
            this.deferredPsLbl.Text = "Ps:";
            // 
            // deferredMonitorTxt
            // 
            this.deferredMonitorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredMonitorTxt.Location = new System.Drawing.Point(90, 96);
            this.deferredMonitorTxt.Name = "deferredMonitorTxt";
            this.deferredMonitorTxt.Size = new System.Drawing.Size(121, 20);
            this.deferredMonitorTxt.TabIndex = 7;
            // 
            // deferredChssLbl
            // 
            this.deferredChssLbl.AutoSize = true;
            this.deferredChssLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredChssLbl.Location = new System.Drawing.Point(7, 60);
            this.deferredChssLbl.Name = "deferredChssLbl";
            this.deferredChssLbl.Size = new System.Drawing.Size(32, 13);
            this.deferredChssLbl.TabIndex = 17;
            this.deferredChssLbl.Text = "ЧСС:";
            // 
            // defferedChddTxt
            // 
            this.defferedChddTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defferedChddTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.defferedChddTxt.FormattingEnabled = true;
            this.defferedChddTxt.Location = new System.Drawing.Point(41, 30);
            this.defferedChddTxt.Name = "defferedChddTxt";
            this.defferedChddTxt.Size = new System.Drawing.Size(58, 21);
            this.defferedChddTxt.TabIndex = 11;
            // 
            // deferredChddLbl
            // 
            this.deferredChddLbl.AutoSize = true;
            this.deferredChddLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredChddLbl.Location = new System.Drawing.Point(3, 36);
            this.deferredChddLbl.Name = "deferredChddLbl";
            this.deferredChddLbl.Size = new System.Drawing.Size(36, 13);
            this.deferredChddLbl.TabIndex = 16;
            this.deferredChddLbl.Text = "ЧДД:";
            // 
            // deferredChssTxt
            // 
            this.deferredChssTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deferredChssTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredChssTxt.FormattingEnabled = true;
            this.deferredChssTxt.Location = new System.Drawing.Point(41, 54);
            this.deferredChssTxt.Name = "deferredChssTxt";
            this.deferredChssTxt.Size = new System.Drawing.Size(58, 21);
            this.deferredChssTxt.TabIndex = 12;
            // 
            // deferredJournalTxt
            // 
            this.deferredJournalTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredJournalTxt.Location = new System.Drawing.Point(218, 4);
            this.deferredJournalTxt.Name = "deferredJournalTxt";
            this.deferredJournalTxt.Size = new System.Drawing.Size(442, 112);
            this.deferredJournalTxt.TabIndex = 15;
            this.deferredJournalTxt.Text = "";
            // 
            // deferredPsTxt
            // 
            this.deferredPsTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deferredPsTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredPsTxt.FormattingEnabled = true;
            this.deferredPsTxt.Location = new System.Drawing.Point(153, 30);
            this.deferredPsTxt.Name = "deferredPsTxt";
            this.deferredPsTxt.Size = new System.Drawing.Size(58, 21);
            this.deferredPsTxt.TabIndex = 13;
            // 
            // deferredAdTxt
            // 
            this.deferredAdTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deferredAdTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredAdTxt.FormattingEnabled = true;
            this.deferredAdTxt.Items.AddRange(new object[] {
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
            this.deferredAdTxt.Location = new System.Drawing.Point(153, 54);
            this.deferredAdTxt.Name = "deferredAdTxt";
            this.deferredAdTxt.Size = new System.Drawing.Size(58, 21);
            this.deferredAdTxt.TabIndex = 14;
            // 
            // hideDefferedCb
            // 
            this.hideDefferedCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hideDefferedCb.Location = new System.Drawing.Point(221, 156);
            this.hideDefferedCb.Name = "hideDefferedCb";
            this.hideDefferedCb.Size = new System.Drawing.Size(109, 17);
            this.hideDefferedCb.TabIndex = 5;
            this.hideDefferedCb.Text = "Скрыть дневник";
            this.hideDefferedCb.UseVisualStyleBackColor = true;
            // 
            // defferedPnl
            // 
            this.defferedPnl.AutoSize = true;
            this.defferedPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.defferedPnl.Controls.Add(this.visibledPnl);
            this.defferedPnl.Controls.Add(this.hideDefferedCb);
            this.defferedPnl.Location = new System.Drawing.Point(3, 3);
            this.defferedPnl.Name = "defferedPnl";
            this.defferedPnl.Size = new System.Drawing.Size(671, 176);
            this.defferedPnl.TabIndex = 23;
            // 
            // docBox
            // 
            this.docBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docBox.FormattingEnabled = true;
            this.docBox.Location = new System.Drawing.Point(440, 122);
            this.docBox.Name = "docBox";
            this.docBox.Size = new System.Drawing.Size(220, 21);
            this.docBox.TabIndex = 21;
            // 
            // docLbl
            // 
            this.docLbl.AutoSize = true;
            this.docLbl.Location = new System.Drawing.Point(323, 127);
            this.docLbl.Name = "docLbl";
            this.docLbl.Size = new System.Drawing.Size(112, 13);
            this.docLbl.TabIndex = 22;
            this.docLbl.Text = "Ответственный врач";
            // 
            // DefferedJournalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.defferedPnl);
            this.Name = "DefferedJournalControl";
            this.Size = new System.Drawing.Size(677, 182);
            this.visibledPnl.ResumeLayout(false);
            this.visibledPnl.PerformLayout();
            this.defferedPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel visibledPnl;
        private System.Windows.Forms.DateTimePicker deferredStartTime;
        private System.Windows.Forms.CheckBox hideDefferedCb;
        private System.Windows.Forms.Label deferredAdLbl;
        private System.Windows.Forms.Label deferredMonitorLbl;
        private System.Windows.Forms.Label deferredPsLbl;
        private System.Windows.Forms.TextBox deferredMonitorTxt;
        private System.Windows.Forms.Label deferredChssLbl;
        private System.Windows.Forms.ComboBox defferedChddTxt;
        private System.Windows.Forms.Label deferredChddLbl;
        private System.Windows.Forms.ComboBox deferredChssTxt;
        private System.Windows.Forms.RichTextBox deferredJournalTxt;
        private System.Windows.Forms.ComboBox deferredPsTxt;
        private System.Windows.Forms.ComboBox deferredAdTxt;
        private System.Windows.Forms.Panel defferedPnl;
        private System.Windows.Forms.DateTimePicker deferredStartDate;
        private System.Windows.Forms.Label docLbl;
        private System.Windows.Forms.ComboBox docBox;
    }
}
