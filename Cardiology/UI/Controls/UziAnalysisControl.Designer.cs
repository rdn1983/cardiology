namespace Cardiology.UI.Controls
{
    partial class UziAnalysisControl
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
            this.pleursUziBox = new System.Windows.Forms.GroupBox();
            this.pleursUziTxt = new System.Windows.Forms.RichTextBox();
            this.uziObpBox = new System.Windows.Forms.GroupBox();
            this.uziObpTxt = new System.Windows.Forms.RichTextBox();
            this.cdsBox = new System.Windows.Forms.GroupBox();
            this.cdsTxt = new System.Windows.Forms.RichTextBox();
            this.uzdBox = new System.Windows.Forms.GroupBox();
            this.uzdTxt = new System.Windows.Forms.RichTextBox();
            this.ehoKgBox = new System.Windows.Forms.GroupBox();
            this.ehoKgTxt = new System.Windows.Forms.RichTextBox();
            this.container = new System.Windows.Forms.Panel();
            this.hide = new System.Windows.Forms.Button();
            this.analysisDate = new System.Windows.Forms.DateTimePicker();
            this.title = new System.Windows.Forms.Label();
            this.pleursUziBox.SuspendLayout();
            this.uziObpBox.SuspendLayout();
            this.cdsBox.SuspendLayout();
            this.uzdBox.SuspendLayout();
            this.ehoKgBox.SuspendLayout();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // pleursUziBox
            // 
            this.pleursUziBox.Controls.Add(this.pleursUziTxt);
            this.pleursUziBox.Location = new System.Drawing.Point(4, 456);
            this.pleursUziBox.Name = "pleursUziBox";
            this.pleursUziBox.Size = new System.Drawing.Size(489, 93);
            this.pleursUziBox.TabIndex = 9;
            this.pleursUziBox.TabStop = false;
            this.pleursUziBox.Text = "УЗИ плевр:";
            // 
            // pleursUziTxt
            // 
            this.pleursUziTxt.Location = new System.Drawing.Point(9, 17);
            this.pleursUziTxt.Name = "pleursUziTxt";
            this.pleursUziTxt.Size = new System.Drawing.Size(471, 73);
            this.pleursUziTxt.TabIndex = 1;
            this.pleursUziTxt.Text = "";
            this.pleursUziTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // uziObpBox
            // 
            this.uziObpBox.Controls.Add(this.uziObpTxt);
            this.uziObpBox.Location = new System.Drawing.Point(4, 357);
            this.uziObpBox.Name = "uziObpBox";
            this.uziObpBox.Size = new System.Drawing.Size(489, 93);
            this.uziObpBox.TabIndex = 8;
            this.uziObpBox.TabStop = false;
            this.uziObpBox.Text = "УЗИ ОБП:";
            // 
            // uziObpTxt
            // 
            this.uziObpTxt.Location = new System.Drawing.Point(9, 16);
            this.uziObpTxt.Name = "uziObpTxt";
            this.uziObpTxt.Size = new System.Drawing.Size(471, 73);
            this.uziObpTxt.TabIndex = 1;
            this.uziObpTxt.Text = "";
            this.uziObpTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // cdsBox
            // 
            this.cdsBox.Controls.Add(this.cdsTxt);
            this.cdsBox.Location = new System.Drawing.Point(4, 258);
            this.cdsBox.Name = "cdsBox";
            this.cdsBox.Size = new System.Drawing.Size(489, 93);
            this.cdsBox.TabIndex = 7;
            this.cdsBox.TabStop = false;
            this.cdsBox.Text = "ЦДС:";
            // 
            // cdsTxt
            // 
            this.cdsTxt.Location = new System.Drawing.Point(9, 16);
            this.cdsTxt.Name = "cdsTxt";
            this.cdsTxt.Size = new System.Drawing.Size(471, 73);
            this.cdsTxt.TabIndex = 1;
            this.cdsTxt.Text = "";
            this.cdsTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // uzdBox
            // 
            this.uzdBox.Controls.Add(this.uzdTxt);
            this.uzdBox.Location = new System.Drawing.Point(4, 159);
            this.uzdBox.Name = "uzdBox";
            this.uzdBox.Size = new System.Drawing.Size(489, 93);
            this.uzdBox.TabIndex = 6;
            this.uzdBox.TabStop = false;
            this.uzdBox.Text = "УЗД БЦА:";
            // 
            // uzdTxt
            // 
            this.uzdTxt.Location = new System.Drawing.Point(9, 16);
            this.uzdTxt.Name = "uzdTxt";
            this.uzdTxt.Size = new System.Drawing.Size(471, 73);
            this.uzdTxt.TabIndex = 1;
            this.uzdTxt.Text = "";
            this.uzdTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // ehoKgBox
            // 
            this.ehoKgBox.Controls.Add(this.ehoKgTxt);
            this.ehoKgBox.Location = new System.Drawing.Point(4, 60);
            this.ehoKgBox.Name = "ehoKgBox";
            this.ehoKgBox.Size = new System.Drawing.Size(489, 93);
            this.ehoKgBox.TabIndex = 5;
            this.ehoKgBox.TabStop = false;
            this.ehoKgBox.Text = "Эхо КГ:";
            // 
            // ehoKgTxt
            // 
            this.ehoKgTxt.Location = new System.Drawing.Point(12, 17);
            this.ehoKgTxt.Name = "ehoKgTxt";
            this.ehoKgTxt.Size = new System.Drawing.Size(465, 73);
            this.ehoKgTxt.TabIndex = 0;
            this.ehoKgTxt.Text = "";
            this.ehoKgTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // container
            // 
            this.container.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.container.Controls.Add(this.hide);
            this.container.Controls.Add(this.analysisDate);
            this.container.Controls.Add(this.title);
            this.container.Controls.Add(this.ehoKgBox);
            this.container.Controls.Add(this.pleursUziBox);
            this.container.Controls.Add(this.uzdBox);
            this.container.Controls.Add(this.uziObpBox);
            this.container.Controls.Add(this.cdsBox);
            this.container.Location = new System.Drawing.Point(3, 3);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(500, 559);
            this.container.TabIndex = 10;
            // 
            // hide
            // 
            this.hide.Image = global::Cardiology.Properties.Resources.remove;
            this.hide.Location = new System.Drawing.Point(467, 4);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(26, 23);
            this.hide.TabIndex = 40;
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // analysisDate
            // 
            this.analysisDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.analysisDate.Location = new System.Drawing.Point(4, 34);
            this.analysisDate.Name = "analysisDate";
            this.analysisDate.Size = new System.Drawing.Size(112, 20);
            this.analysisDate.TabIndex = 11;
            this.analysisDate.ValueChanged += new System.EventHandler(this.analysisDate_ValueChanged);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.Location = new System.Drawing.Point(3, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(87, 13);
            this.title.TabIndex = 10;
            this.title.Text = "УЗИ текущие";
            // 
            // UziAnalysisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.container);
            this.Name = "UziAnalysisControl";
            this.Size = new System.Drawing.Size(510, 566);
            this.pleursUziBox.ResumeLayout(false);
            this.uziObpBox.ResumeLayout(false);
            this.cdsBox.ResumeLayout(false);
            this.uzdBox.ResumeLayout(false);
            this.ehoKgBox.ResumeLayout(false);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox pleursUziBox;
        private System.Windows.Forms.RichTextBox pleursUziTxt;
        private System.Windows.Forms.GroupBox uziObpBox;
        private System.Windows.Forms.RichTextBox uziObpTxt;
        private System.Windows.Forms.GroupBox cdsBox;
        private System.Windows.Forms.RichTextBox cdsTxt;
        private System.Windows.Forms.GroupBox uzdBox;
        private System.Windows.Forms.RichTextBox uzdTxt;
        private System.Windows.Forms.GroupBox ehoKgBox;
        private System.Windows.Forms.RichTextBox ehoKgTxt;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.DateTimePicker analysisDate;
        private System.Windows.Forms.Button hide;
    }
}
