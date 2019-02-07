namespace Cardiology.UI.Controls
{
    partial class SpecialistConclusionControl
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
            this.endicrinologistBox = new System.Windows.Forms.GroupBox();
            this.endocrinologistTx = new System.Windows.Forms.RichTextBox();
            this.neuroSurgeonBox = new System.Windows.Forms.GroupBox();
            this.neuroSurgeonTxt = new System.Windows.Forms.RichTextBox();
            this.surgeonBox = new System.Windows.Forms.GroupBox();
            this.surgeonTxt = new System.Windows.Forms.RichTextBox();
            this.neurologBox = new System.Windows.Forms.GroupBox();
            this.neurologTxt = new System.Windows.Forms.RichTextBox();
            this.container = new System.Windows.Forms.Panel();
            this.analysisDate = new System.Windows.Forms.DateTimePicker();
            this.title = new System.Windows.Forms.Label();
            this.endicrinologistBox.SuspendLayout();
            this.neuroSurgeonBox.SuspendLayout();
            this.surgeonBox.SuspendLayout();
            this.neurologBox.SuspendLayout();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // endicrinologistBox
            // 
            this.endicrinologistBox.Controls.Add(this.endocrinologistTx);
            this.endicrinologistBox.Location = new System.Drawing.Point(3, 360);
            this.endicrinologistBox.Name = "endicrinologistBox";
            this.endicrinologistBox.Size = new System.Drawing.Size(426, 89);
            this.endicrinologistBox.TabIndex = 12;
            this.endicrinologistBox.TabStop = false;
            this.endicrinologistBox.Text = "Эндокринолог:";
            // 
            // endocrinologistTx
            // 
            this.endocrinologistTx.Location = new System.Drawing.Point(9, 16);
            this.endocrinologistTx.Name = "endocrinologistTx";
            this.endocrinologistTx.Size = new System.Drawing.Size(408, 65);
            this.endocrinologistTx.TabIndex = 1;
            this.endocrinologistTx.Text = "";
            this.endocrinologistTx.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // neuroSurgeonBox
            // 
            this.neuroSurgeonBox.Controls.Add(this.neuroSurgeonTxt);
            this.neuroSurgeonBox.Location = new System.Drawing.Point(3, 259);
            this.neuroSurgeonBox.Name = "neuroSurgeonBox";
            this.neuroSurgeonBox.Size = new System.Drawing.Size(426, 95);
            this.neuroSurgeonBox.TabIndex = 11;
            this.neuroSurgeonBox.TabStop = false;
            this.neuroSurgeonBox.Text = "Нейрохирург:";
            // 
            // neuroSurgeonTxt
            // 
            this.neuroSurgeonTxt.Location = new System.Drawing.Point(9, 16);
            this.neuroSurgeonTxt.Name = "neuroSurgeonTxt";
            this.neuroSurgeonTxt.Size = new System.Drawing.Size(408, 69);
            this.neuroSurgeonTxt.TabIndex = 1;
            this.neuroSurgeonTxt.Text = "";
            this.neuroSurgeonTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // surgeonBox
            // 
            this.surgeonBox.Controls.Add(this.surgeonTxt);
            this.surgeonBox.Location = new System.Drawing.Point(3, 164);
            this.surgeonBox.Name = "surgeonBox";
            this.surgeonBox.Size = new System.Drawing.Size(426, 89);
            this.surgeonBox.TabIndex = 10;
            this.surgeonBox.TabStop = false;
            this.surgeonBox.Text = "Хирург:";
            // 
            // surgeonTxt
            // 
            this.surgeonTxt.Location = new System.Drawing.Point(9, 16);
            this.surgeonTxt.Name = "surgeonTxt";
            this.surgeonTxt.Size = new System.Drawing.Size(408, 63);
            this.surgeonTxt.TabIndex = 1;
            this.surgeonTxt.Text = "";
            this.surgeonTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // neurologBox
            // 
            this.neurologBox.Controls.Add(this.neurologTxt);
            this.neurologBox.Location = new System.Drawing.Point(3, 69);
            this.neurologBox.Name = "neurologBox";
            this.neurologBox.Size = new System.Drawing.Size(426, 89);
            this.neurologBox.TabIndex = 9;
            this.neurologBox.TabStop = false;
            this.neurologBox.Text = "Невролог:";
            // 
            // neurologTxt
            // 
            this.neurologTxt.Location = new System.Drawing.Point(12, 17);
            this.neurologTxt.Name = "neurologTxt";
            this.neurologTxt.Size = new System.Drawing.Size(402, 62);
            this.neurologTxt.TabIndex = 0;
            this.neurologTxt.Text = "";
            this.neurologTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // container
            // 
            this.container.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.container.Controls.Add(this.analysisDate);
            this.container.Controls.Add(this.title);
            this.container.Controls.Add(this.neurologBox);
            this.container.Controls.Add(this.endicrinologistBox);
            this.container.Controls.Add(this.surgeonBox);
            this.container.Controls.Add(this.neuroSurgeonBox);
            this.container.Location = new System.Drawing.Point(3, 3);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(436, 456);
            this.container.TabIndex = 13;
            // 
            // analysisDate
            // 
            this.analysisDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.analysisDate.Location = new System.Drawing.Point(3, 43);
            this.analysisDate.Name = "analysisDate";
            this.analysisDate.Size = new System.Drawing.Size(114, 20);
            this.analysisDate.TabIndex = 14;
            this.analysisDate.ValueChanged += new System.EventHandler(this.analysisDate_ValueChanged);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.Location = new System.Drawing.Point(4, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(220, 13);
            this.title.TabIndex = 13;
            this.title.Text = "Заключения специалистов текущие";
            // 
            // SpecialistConclusionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.container);
            this.Name = "SpecialistConclusionControl";
            this.Size = new System.Drawing.Size(444, 462);
            this.endicrinologistBox.ResumeLayout(false);
            this.neuroSurgeonBox.ResumeLayout(false);
            this.surgeonBox.ResumeLayout(false);
            this.neurologBox.ResumeLayout(false);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox endicrinologistBox;
        private System.Windows.Forms.RichTextBox endocrinologistTx;
        private System.Windows.Forms.GroupBox neuroSurgeonBox;
        private System.Windows.Forms.RichTextBox neuroSurgeonTxt;
        private System.Windows.Forms.GroupBox surgeonBox;
        private System.Windows.Forms.RichTextBox surgeonTxt;
        private System.Windows.Forms.GroupBox neurologBox;
        private System.Windows.Forms.RichTextBox neurologTxt;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.DateTimePicker analysisDate;
    }
}
