﻿namespace Cardiology
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
            this.pleursUziBox.Location = new System.Drawing.Point(3, 507);
            this.pleursUziBox.Name = "pleursUziBox";
            this.pleursUziBox.Size = new System.Drawing.Size(489, 109);
            this.pleursUziBox.TabIndex = 9;
            this.pleursUziBox.TabStop = false;
            this.pleursUziBox.Text = "УЗИ плевр:";
            // 
            // pleursUziTxt
            // 
            this.pleursUziTxt.Location = new System.Drawing.Point(9, 17);
            this.pleursUziTxt.Name = "pleursUziTxt";
            this.pleursUziTxt.Size = new System.Drawing.Size(471, 84);
            this.pleursUziTxt.TabIndex = 1;
            this.pleursUziTxt.Text = "";
            // 
            // uziObpBox
            // 
            this.uziObpBox.Controls.Add(this.uziObpTxt);
            this.uziObpBox.Location = new System.Drawing.Point(3, 385);
            this.uziObpBox.Name = "uziObpBox";
            this.uziObpBox.Size = new System.Drawing.Size(489, 109);
            this.uziObpBox.TabIndex = 8;
            this.uziObpBox.TabStop = false;
            this.uziObpBox.Text = "УЗИ ОБП:";
            // 
            // uziObpTxt
            // 
            this.uziObpTxt.Location = new System.Drawing.Point(9, 16);
            this.uziObpTxt.Name = "uziObpTxt";
            this.uziObpTxt.Size = new System.Drawing.Size(471, 84);
            this.uziObpTxt.TabIndex = 1;
            this.uziObpTxt.Text = "";
            // 
            // cdsBox
            // 
            this.cdsBox.Controls.Add(this.cdsTxt);
            this.cdsBox.Location = new System.Drawing.Point(3, 266);
            this.cdsBox.Name = "cdsBox";
            this.cdsBox.Size = new System.Drawing.Size(489, 109);
            this.cdsBox.TabIndex = 7;
            this.cdsBox.TabStop = false;
            this.cdsBox.Text = "ЦДС:";
            // 
            // cdsTxt
            // 
            this.cdsTxt.Location = new System.Drawing.Point(9, 16);
            this.cdsTxt.Name = "cdsTxt";
            this.cdsTxt.Size = new System.Drawing.Size(471, 84);
            this.cdsTxt.TabIndex = 1;
            this.cdsTxt.Text = "";
            // 
            // uzdBox
            // 
            this.uzdBox.Controls.Add(this.uzdTxt);
            this.uzdBox.Location = new System.Drawing.Point(3, 149);
            this.uzdBox.Name = "uzdBox";
            this.uzdBox.Size = new System.Drawing.Size(489, 109);
            this.uzdBox.TabIndex = 6;
            this.uzdBox.TabStop = false;
            this.uzdBox.Text = "УЗД БЦА:";
            // 
            // uzdTxt
            // 
            this.uzdTxt.Location = new System.Drawing.Point(9, 16);
            this.uzdTxt.Name = "uzdTxt";
            this.uzdTxt.Size = new System.Drawing.Size(471, 84);
            this.uzdTxt.TabIndex = 1;
            this.uzdTxt.Text = "";
            // 
            // ehoKgBox
            // 
            this.ehoKgBox.Controls.Add(this.ehoKgTxt);
            this.ehoKgBox.Location = new System.Drawing.Point(3, 34);
            this.ehoKgBox.Name = "ehoKgBox";
            this.ehoKgBox.Size = new System.Drawing.Size(489, 109);
            this.ehoKgBox.TabIndex = 5;
            this.ehoKgBox.TabStop = false;
            this.ehoKgBox.Text = "Эхо КГ:";
            // 
            // ehoKgTxt
            // 
            this.ehoKgTxt.Location = new System.Drawing.Point(12, 17);
            this.ehoKgTxt.Name = "ehoKgTxt";
            this.ehoKgTxt.Size = new System.Drawing.Size(465, 84);
            this.ehoKgTxt.TabIndex = 0;
            this.ehoKgTxt.Text = "";
            // 
            // container
            // 
            this.container.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.container.Controls.Add(this.title);
            this.container.Controls.Add(this.ehoKgBox);
            this.container.Controls.Add(this.pleursUziBox);
            this.container.Controls.Add(this.uzdBox);
            this.container.Controls.Add(this.uziObpBox);
            this.container.Controls.Add(this.cdsBox);
            this.container.Location = new System.Drawing.Point(3, 3);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(500, 620);
            this.container.TabIndex = 10;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.Location = new System.Drawing.Point(3, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(113, 13);
            this.title.TabIndex = 10;
            this.title.Text = "Анализы текущие";
            // 
            // UziAnalysisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.container);
            this.Name = "UziAnalysisControl";
            this.Size = new System.Drawing.Size(826, 628);
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
    }
}