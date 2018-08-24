namespace Cardiology
{
    partial class UrineAnalysisControl
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
            this.regularAnalysisBox = new System.Windows.Forms.GroupBox();
            this.proteinTxt = new System.Windows.Forms.TextBox();
            this.erythrocytesTxt = new System.Windows.Forms.TextBox();
            this.leukocytesTxt = new System.Windows.Forms.TextBox();
            this.colorTxt = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.dateUrineAnalysis = new System.Windows.Forms.DateTimePicker();
            this.dateUrineAnalysisLbl = new System.Windows.Forms.Label();
            this.regularAnalysisBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // regularAnalysisBox
            // 
            this.regularAnalysisBox.Controls.Add(this.dateUrineAnalysis);
            this.regularAnalysisBox.Controls.Add(this.dateUrineAnalysisLbl);
            this.regularAnalysisBox.Controls.Add(this.proteinTxt);
            this.regularAnalysisBox.Controls.Add(this.erythrocytesTxt);
            this.regularAnalysisBox.Controls.Add(this.leukocytesTxt);
            this.regularAnalysisBox.Controls.Add(this.colorTxt);
            this.regularAnalysisBox.Controls.Add(this.label91);
            this.regularAnalysisBox.Controls.Add(this.label94);
            this.regularAnalysisBox.Controls.Add(this.label95);
            this.regularAnalysisBox.Controls.Add(this.label98);
            this.regularAnalysisBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regularAnalysisBox.Location = new System.Drawing.Point(5, 4);
            this.regularAnalysisBox.Name = "regularAnalysisBox";
            this.regularAnalysisBox.Size = new System.Drawing.Size(259, 225);
            this.regularAnalysisBox.TabIndex = 2;
            this.regularAnalysisBox.TabStop = false;
            this.regularAnalysisBox.Text = "Анализы текущие";
            // 
            // proteinTxt
            // 
            this.proteinTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.proteinTxt.Location = new System.Drawing.Point(88, 190);
            this.proteinTxt.Name = "proteinTxt";
            this.proteinTxt.Size = new System.Drawing.Size(156, 20);
            this.proteinTxt.TabIndex = 14;
            // 
            // erythrocytesTxt
            // 
            this.erythrocytesTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.erythrocytesTxt.Location = new System.Drawing.Point(88, 150);
            this.erythrocytesTxt.Name = "erythrocytesTxt";
            this.erythrocytesTxt.Size = new System.Drawing.Size(156, 20);
            this.erythrocytesTxt.TabIndex = 12;
            // 
            // leukocytesTxt
            // 
            this.leukocytesTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leukocytesTxt.Location = new System.Drawing.Point(88, 106);
            this.leukocytesTxt.Name = "leukocytesTxt";
            this.leukocytesTxt.Size = new System.Drawing.Size(156, 20);
            this.leukocytesTxt.TabIndex = 11;
            // 
            // colorTxt
            // 
            this.colorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colorTxt.Location = new System.Drawing.Point(88, 65);
            this.colorTxt.Name = "colorTxt";
            this.colorTxt.Size = new System.Drawing.Size(156, 20);
            this.colorTxt.TabIndex = 8;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label91.Location = new System.Drawing.Point(8, 197);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(41, 13);
            this.label91.TabIndex = 7;
            this.label91.Text = "Белок:";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label94.Location = new System.Drawing.Point(8, 157);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(71, 13);
            this.label94.TabIndex = 4;
            this.label94.Text = "Эритроциты:";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label95.Location = new System.Drawing.Point(8, 113);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(67, 13);
            this.label95.TabIndex = 3;
            this.label95.Text = "Лейкоциты:";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label98.Location = new System.Drawing.Point(8, 72);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(35, 13);
            this.label98.TabIndex = 0;
            this.label98.Text = "Цвет:";
            // 
            // dateUrineAnalysis
            // 
            this.dateUrineAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateUrineAnalysis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateUrineAnalysis.Location = new System.Drawing.Point(88, 27);
            this.dateUrineAnalysis.Name = "dateUrineAnalysis";
            this.dateUrineAnalysis.Size = new System.Drawing.Size(156, 20);
            this.dateUrineAnalysis.TabIndex = 43;
            // 
            // dateUrineAnalysisLbl
            // 
            this.dateUrineAnalysisLbl.AutoSize = true;
            this.dateUrineAnalysisLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateUrineAnalysisLbl.Location = new System.Drawing.Point(8, 33);
            this.dateUrineAnalysisLbl.Name = "dateUrineAnalysisLbl";
            this.dateUrineAnalysisLbl.Size = new System.Drawing.Size(36, 13);
            this.dateUrineAnalysisLbl.TabIndex = 42;
            this.dateUrineAnalysisLbl.Text = "Дата:";
            // 
            // UrineAnalysisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.regularAnalysisBox);
            this.Name = "UrineAnalysisControl";
            this.Size = new System.Drawing.Size(270, 237);
            this.regularAnalysisBox.ResumeLayout(false);
            this.regularAnalysisBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox regularAnalysisBox;
        private System.Windows.Forms.TextBox proteinTxt;
        private System.Windows.Forms.TextBox erythrocytesTxt;
        private System.Windows.Forms.TextBox leukocytesTxt;
        private System.Windows.Forms.TextBox colorTxt;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.DateTimePicker dateUrineAnalysis;
        private System.Windows.Forms.Label dateUrineAnalysisLbl;
    }
}
