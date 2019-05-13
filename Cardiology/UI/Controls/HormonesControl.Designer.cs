namespace Cardiology.UI.Controls
{
    partial class HormonesControl
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
            this.hormonesPnl = new System.Windows.Forms.GroupBox();
            this.hide = new System.Windows.Forms.Button();
            this.admissionDateTxt = new System.Windows.Forms.DateTimePicker();
            this.admissionDateLbl = new System.Windows.Forms.Label();
            this.ttgTxt = new System.Windows.Forms.TextBox();
            this.t4Txt = new System.Windows.Forms.TextBox();
            this.t3Txt = new System.Windows.Forms.TextBox();
            this.ttgLbl = new System.Windows.Forms.Label();
            this.t4Lbl = new System.Windows.Forms.Label();
            this.t3Lbl = new System.Windows.Forms.Label();
            this.hormonesPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // hormonesPnl
            // 
            this.hormonesPnl.Controls.Add(this.hide);
            this.hormonesPnl.Controls.Add(this.admissionDateTxt);
            this.hormonesPnl.Controls.Add(this.admissionDateLbl);
            this.hormonesPnl.Controls.Add(this.ttgTxt);
            this.hormonesPnl.Controls.Add(this.t4Txt);
            this.hormonesPnl.Controls.Add(this.t3Txt);
            this.hormonesPnl.Controls.Add(this.ttgLbl);
            this.hormonesPnl.Controls.Add(this.t4Lbl);
            this.hormonesPnl.Controls.Add(this.t3Lbl);
            this.hormonesPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hormonesPnl.Location = new System.Drawing.Point(3, 3);
            this.hormonesPnl.Name = "hormonesPnl";
            this.hormonesPnl.Size = new System.Drawing.Size(166, 147);
            this.hormonesPnl.TabIndex = 41;
            this.hormonesPnl.TabStop = false;
            this.hormonesPnl.Text = "Гормоны текущие";
            // 
            // hide
            // 
            this.hide.Image = global::Cardiology.Properties.Resources.remove;
            this.hide.Location = new System.Drawing.Point(129, 118);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(26, 23);
            this.hide.TabIndex = 39;
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // admissionDateTxt
            // 
            this.admissionDateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.admissionDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.admissionDateTxt.Location = new System.Drawing.Point(54, 23);
            this.admissionDateTxt.Name = "admissionDateTxt";
            this.admissionDateTxt.Size = new System.Drawing.Size(100, 20);
            this.admissionDateTxt.TabIndex = 7;
            this.admissionDateTxt.ValueChanged += new System.EventHandler(this.admissionDateTxt_ValueChanged);
            // 
            // admissionDateLbl
            // 
            this.admissionDateLbl.AutoSize = true;
            this.admissionDateLbl.Location = new System.Drawing.Point(12, 27);
            this.admissionDateLbl.Name = "admissionDateLbl";
            this.admissionDateLbl.Size = new System.Drawing.Size(41, 13);
            this.admissionDateLbl.TabIndex = 6;
            this.admissionDateLbl.Text = "Дата:";
            // 
            // ttgTxt
            // 
            this.ttgTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ttgTxt.Location = new System.Drawing.Point(54, 96);
            this.ttgTxt.Name = "ttgTxt";
            this.ttgTxt.Size = new System.Drawing.Size(100, 20);
            this.ttgTxt.TabIndex = 5;
            this.ttgTxt.TextChanged += new System.EventHandler(this.controlTxt_TextChanged);
            // 
            // t4Txt
            // 
            this.t4Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.t4Txt.Location = new System.Drawing.Point(54, 72);
            this.t4Txt.Name = "t4Txt";
            this.t4Txt.Size = new System.Drawing.Size(100, 20);
            this.t4Txt.TabIndex = 4;
            this.t4Txt.TextChanged += new System.EventHandler(this.controlTxt_TextChanged);
            // 
            // t3Txt
            // 
            this.t3Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.t3Txt.Location = new System.Drawing.Point(54, 49);
            this.t3Txt.Name = "t3Txt";
            this.t3Txt.Size = new System.Drawing.Size(100, 20);
            this.t3Txt.TabIndex = 3;
            this.t3Txt.TextChanged += new System.EventHandler(this.controlTxt_TextChanged);
            // 
            // ttgLbl
            // 
            this.ttgLbl.AutoSize = true;
            this.ttgLbl.Location = new System.Drawing.Point(15, 101);
            this.ttgLbl.Name = "ttgLbl";
            this.ttgLbl.Size = new System.Drawing.Size(34, 13);
            this.ttgLbl.TabIndex = 2;
            this.ttgLbl.Text = "ТТГ:";
            // 
            // t4Lbl
            // 
            this.t4Lbl.AutoSize = true;
            this.t4Lbl.Location = new System.Drawing.Point(18, 76);
            this.t4Lbl.Name = "t4Lbl";
            this.t4Lbl.Size = new System.Drawing.Size(30, 13);
            this.t4Lbl.TabIndex = 1;
            this.t4Lbl.Text = "Т-4:";
            // 
            // t3Lbl
            // 
            this.t3Lbl.AutoSize = true;
            this.t3Lbl.Location = new System.Drawing.Point(18, 53);
            this.t3Lbl.Name = "t3Lbl";
            this.t3Lbl.Size = new System.Drawing.Size(30, 13);
            this.t3Lbl.TabIndex = 0;
            this.t3Lbl.Text = "Т-3:";
            // 
            // HormonesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hormonesPnl);
            this.Name = "HormonesControl";
            this.Size = new System.Drawing.Size(174, 153);
            this.hormonesPnl.ResumeLayout(false);
            this.hormonesPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox hormonesPnl;
        private System.Windows.Forms.TextBox ttgTxt;
        private System.Windows.Forms.TextBox t4Txt;
        private System.Windows.Forms.TextBox t3Txt;
        private System.Windows.Forms.Label ttgLbl;
        private System.Windows.Forms.Label t4Lbl;
        private System.Windows.Forms.Label t3Lbl;
        private System.Windows.Forms.DateTimePicker admissionDateTxt;
        private System.Windows.Forms.Label admissionDateLbl;
        private System.Windows.Forms.Button hide;
    }
}
