namespace Cardiology.Controls
{
    partial class OncologicMarkersControl
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
            this.cntr = new System.Windows.Forms.GroupBox();
            this.admissionDateTxt = new System.Windows.Forms.DateTimePicker();
            this.afrTxt = new System.Windows.Forms.TextBox();
            this.hgchTxt = new System.Windows.Forms.TextBox();
            this.ceaTxt = new System.Windows.Forms.TextBox();
            this.ca153Txt = new System.Windows.Forms.TextBox();
            this.ca125Txt = new System.Windows.Forms.TextBox();
            this.ca199Txt = new System.Windows.Forms.TextBox();
            this.psaFreeTxt = new System.Windows.Forms.TextBox();
            this.psaCommonTxt = new System.Windows.Forms.TextBox();
            this.afrLbl = new System.Windows.Forms.Label();
            this.hgchLbl = new System.Windows.Forms.Label();
            this.ceaLbl = new System.Windows.Forms.Label();
            this.ca153Lbl = new System.Windows.Forms.Label();
            this.ca125Lbl = new System.Windows.Forms.Label();
            this.ca199Lbl = new System.Windows.Forms.Label();
            this.pdsFreeLbl = new System.Windows.Forms.Label();
            this.psaCommonLbl = new System.Windows.Forms.Label();
            this.admissionTimeTxt = new System.Windows.Forms.DateTimePicker();
            this.cntr.SuspendLayout();
            this.SuspendLayout();
            // 
            // cntr
            // 
            this.cntr.Controls.Add(this.admissionDateTxt);
            this.cntr.Controls.Add(this.afrTxt);
            this.cntr.Controls.Add(this.hgchTxt);
            this.cntr.Controls.Add(this.ceaTxt);
            this.cntr.Controls.Add(this.ca153Txt);
            this.cntr.Controls.Add(this.ca125Txt);
            this.cntr.Controls.Add(this.ca199Txt);
            this.cntr.Controls.Add(this.psaFreeTxt);
            this.cntr.Controls.Add(this.psaCommonTxt);
            this.cntr.Controls.Add(this.afrLbl);
            this.cntr.Controls.Add(this.hgchLbl);
            this.cntr.Controls.Add(this.ceaLbl);
            this.cntr.Controls.Add(this.ca153Lbl);
            this.cntr.Controls.Add(this.ca125Lbl);
            this.cntr.Controls.Add(this.ca199Lbl);
            this.cntr.Controls.Add(this.pdsFreeLbl);
            this.cntr.Controls.Add(this.psaCommonLbl);
            this.cntr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cntr.Location = new System.Drawing.Point(3, 3);
            this.cntr.Name = "cntr";
            this.cntr.Size = new System.Drawing.Size(188, 286);
            this.cntr.TabIndex = 0;
            this.cntr.TabStop = false;
            this.cntr.Text = "Онкомаркеры";
            // 
            // admissionDateTxt
            // 
            this.admissionDateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.admissionDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.admissionDateTxt.Location = new System.Drawing.Point(9, 29);
            this.admissionDateTxt.Name = "admissionDateTxt";
            this.admissionDateTxt.Size = new System.Drawing.Size(96, 20);
            this.admissionDateTxt.TabIndex = 16;
            this.admissionDateTxt.ValueChanged += new System.EventHandler(this.admissionDateTxt_ValueChanged);
            // 
            // afrTxt
            // 
            this.afrTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.afrTxt.Location = new System.Drawing.Point(71, 237);
            this.afrTxt.Name = "afrTxt";
            this.afrTxt.Size = new System.Drawing.Size(100, 20);
            this.afrTxt.TabIndex = 15;
            this.afrTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // hgchTxt
            // 
            this.hgchTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hgchTxt.Location = new System.Drawing.Point(71, 211);
            this.hgchTxt.Name = "hgchTxt";
            this.hgchTxt.Size = new System.Drawing.Size(100, 20);
            this.hgchTxt.TabIndex = 14;
            this.hgchTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // ceaTxt
            // 
            this.ceaTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ceaTxt.Location = new System.Drawing.Point(71, 185);
            this.ceaTxt.Name = "ceaTxt";
            this.ceaTxt.Size = new System.Drawing.Size(100, 20);
            this.ceaTxt.TabIndex = 13;
            this.ceaTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // ca153Txt
            // 
            this.ca153Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ca153Txt.Location = new System.Drawing.Point(71, 159);
            this.ca153Txt.Name = "ca153Txt";
            this.ca153Txt.Size = new System.Drawing.Size(100, 20);
            this.ca153Txt.TabIndex = 12;
            this.ca153Txt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // ca125Txt
            // 
            this.ca125Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ca125Txt.Location = new System.Drawing.Point(71, 133);
            this.ca125Txt.Name = "ca125Txt";
            this.ca125Txt.Size = new System.Drawing.Size(100, 20);
            this.ca125Txt.TabIndex = 11;
            this.ca125Txt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // ca199Txt
            // 
            this.ca199Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ca199Txt.Location = new System.Drawing.Point(71, 107);
            this.ca199Txt.Name = "ca199Txt";
            this.ca199Txt.Size = new System.Drawing.Size(100, 20);
            this.ca199Txt.TabIndex = 10;
            this.ca199Txt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // psaFreeTxt
            // 
            this.psaFreeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.psaFreeTxt.Location = new System.Drawing.Point(71, 81);
            this.psaFreeTxt.Name = "psaFreeTxt";
            this.psaFreeTxt.Size = new System.Drawing.Size(100, 20);
            this.psaFreeTxt.TabIndex = 9;
            this.psaFreeTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // psaCommonTxt
            // 
            this.psaCommonTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.psaCommonTxt.Location = new System.Drawing.Point(71, 55);
            this.psaCommonTxt.Name = "psaCommonTxt";
            this.psaCommonTxt.Size = new System.Drawing.Size(100, 20);
            this.psaCommonTxt.TabIndex = 8;
            this.psaCommonTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // afrLbl
            // 
            this.afrLbl.AutoSize = true;
            this.afrLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.afrLbl.Location = new System.Drawing.Point(6, 244);
            this.afrLbl.Name = "afrLbl";
            this.afrLbl.Size = new System.Drawing.Size(28, 13);
            this.afrLbl.TabIndex = 7;
            this.afrLbl.Text = "AFR";
            // 
            // hgchLbl
            // 
            this.hgchLbl.AutoSize = true;
            this.hgchLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hgchLbl.Location = new System.Drawing.Point(6, 218);
            this.hgchLbl.Name = "hgchLbl";
            this.hgchLbl.Size = new System.Drawing.Size(28, 13);
            this.hgchLbl.TabIndex = 6;
            this.hgchLbl.Text = "ХГЧ";
            // 
            // ceaLbl
            // 
            this.ceaLbl.AutoSize = true;
            this.ceaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ceaLbl.Location = new System.Drawing.Point(6, 192);
            this.ceaLbl.Name = "ceaLbl";
            this.ceaLbl.Size = new System.Drawing.Size(28, 13);
            this.ceaLbl.TabIndex = 5;
            this.ceaLbl.Text = "CEA";
            // 
            // ca153Lbl
            // 
            this.ca153Lbl.AutoSize = true;
            this.ca153Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ca153Lbl.Location = new System.Drawing.Point(6, 166);
            this.ca153Lbl.Name = "ca153Lbl";
            this.ca153Lbl.Size = new System.Drawing.Size(45, 13);
            this.ca153Lbl.TabIndex = 4;
            this.ca153Lbl.Text = "CA 15-3";
            // 
            // ca125Lbl
            // 
            this.ca125Lbl.AutoSize = true;
            this.ca125Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ca125Lbl.Location = new System.Drawing.Point(6, 140);
            this.ca125Lbl.Name = "ca125Lbl";
            this.ca125Lbl.Size = new System.Drawing.Size(42, 13);
            this.ca125Lbl.TabIndex = 3;
            this.ca125Lbl.Text = "CA 125";
            // 
            // ca199Lbl
            // 
            this.ca199Lbl.AutoSize = true;
            this.ca199Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ca199Lbl.Location = new System.Drawing.Point(6, 114);
            this.ca199Lbl.Name = "ca199Lbl";
            this.ca199Lbl.Size = new System.Drawing.Size(45, 13);
            this.ca199Lbl.TabIndex = 2;
            this.ca199Lbl.Text = "CA 19-9";
            // 
            // pdsFreeLbl
            // 
            this.pdsFreeLbl.AutoSize = true;
            this.pdsFreeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pdsFreeLbl.Location = new System.Drawing.Point(6, 88);
            this.pdsFreeLbl.Name = "pdsFreeLbl";
            this.pdsFreeLbl.Size = new System.Drawing.Size(58, 13);
            this.pdsFreeLbl.TabIndex = 1;
            this.pdsFreeLbl.Text = "PSA своб.";
            // 
            // psaCommonLbl
            // 
            this.psaCommonLbl.AutoSize = true;
            this.psaCommonLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.psaCommonLbl.Location = new System.Drawing.Point(6, 62);
            this.psaCommonLbl.Name = "psaCommonLbl";
            this.psaCommonLbl.Size = new System.Drawing.Size(64, 13);
            this.psaCommonLbl.TabIndex = 0;
            this.psaCommonLbl.Text = "PSA общий";
            // 
            // admissionTimeTxt
            // 
            this.admissionTimeTxt.CustomFormat = "HH:mm";
            this.admissionTimeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.admissionTimeTxt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.admissionTimeTxt.Location = new System.Drawing.Point(114, 32);
            this.admissionTimeTxt.Name = "admissionTimeTxt";
            this.admissionTimeTxt.ShowUpDown = true;
            this.admissionTimeTxt.Size = new System.Drawing.Size(60, 20);
            this.admissionTimeTxt.TabIndex = 17;
            // 
            // OncologicMarkersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.admissionTimeTxt);
            this.Controls.Add(this.cntr);
            this.Name = "OncologicMarkersControl";
            this.Size = new System.Drawing.Size(197, 292);
            this.cntr.ResumeLayout(false);
            this.cntr.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox cntr;
        private System.Windows.Forms.Label pdsFreeLbl;
        private System.Windows.Forms.Label psaCommonLbl;
        private System.Windows.Forms.TextBox afrTxt;
        private System.Windows.Forms.TextBox hgchTxt;
        private System.Windows.Forms.TextBox ceaTxt;
        private System.Windows.Forms.TextBox ca153Txt;
        private System.Windows.Forms.TextBox ca125Txt;
        private System.Windows.Forms.TextBox ca199Txt;
        private System.Windows.Forms.TextBox psaFreeTxt;
        private System.Windows.Forms.TextBox psaCommonTxt;
        private System.Windows.Forms.Label afrLbl;
        private System.Windows.Forms.Label hgchLbl;
        private System.Windows.Forms.Label ceaLbl;
        private System.Windows.Forms.Label ca153Lbl;
        private System.Windows.Forms.Label ca125Lbl;
        private System.Windows.Forms.Label ca199Lbl;
        private System.Windows.Forms.DateTimePicker admissionDateTxt;
        private System.Windows.Forms.DateTimePicker admissionTimeTxt;
    }
}
