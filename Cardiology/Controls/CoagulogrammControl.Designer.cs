namespace Cardiology.Controls
{
    partial class CoagulogrammControl
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
            this.coagulogramPnl = new System.Windows.Forms.GroupBox();
            this.ddimerTxt = new System.Windows.Forms.TextBox();
            this.mchoTxt = new System.Windows.Forms.TextBox();
            this.achtvTxt = new System.Windows.Forms.TextBox();
            this.ddimerLbl = new System.Windows.Forms.Label();
            this.mchoLbl = new System.Windows.Forms.Label();
            this.achtvLbl = new System.Windows.Forms.Label();
            this.admissionDateLbl = new System.Windows.Forms.Label();
            this.admissionDateTxt = new System.Windows.Forms.DateTimePicker();
            this.coagulogramPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // coagulogramPnl
            // 
            this.coagulogramPnl.Controls.Add(this.admissionDateTxt);
            this.coagulogramPnl.Controls.Add(this.admissionDateLbl);
            this.coagulogramPnl.Controls.Add(this.ddimerTxt);
            this.coagulogramPnl.Controls.Add(this.mchoTxt);
            this.coagulogramPnl.Controls.Add(this.achtvTxt);
            this.coagulogramPnl.Controls.Add(this.ddimerLbl);
            this.coagulogramPnl.Controls.Add(this.mchoLbl);
            this.coagulogramPnl.Controls.Add(this.achtvLbl);
            this.coagulogramPnl.Location = new System.Drawing.Point(3, -1);
            this.coagulogramPnl.Name = "coagulogramPnl";
            this.coagulogramPnl.Size = new System.Drawing.Size(166, 154);
            this.coagulogramPnl.TabIndex = 40;
            this.coagulogramPnl.TabStop = false;
            // 
            // ddimerTxt
            // 
            this.ddimerTxt.Location = new System.Drawing.Point(69, 118);
            this.ddimerTxt.Name = "ddimerTxt";
            this.ddimerTxt.Size = new System.Drawing.Size(85, 20);
            this.ddimerTxt.TabIndex = 5;
            // 
            // mchoTxt
            // 
            this.mchoTxt.Location = new System.Drawing.Point(69, 88);
            this.mchoTxt.Name = "mchoTxt";
            this.mchoTxt.Size = new System.Drawing.Size(85, 20);
            this.mchoTxt.TabIndex = 4;
            // 
            // achtvTxt
            // 
            this.achtvTxt.Location = new System.Drawing.Point(69, 56);
            this.achtvTxt.Name = "achtvTxt";
            this.achtvTxt.Size = new System.Drawing.Size(85, 20);
            this.achtvTxt.TabIndex = 3;
            // 
            // ddimerLbl
            // 
            this.ddimerLbl.AutoSize = true;
            this.ddimerLbl.Location = new System.Drawing.Point(9, 125);
            this.ddimerLbl.Name = "ddimerLbl";
            this.ddimerLbl.Size = new System.Drawing.Size(46, 13);
            this.ddimerLbl.TabIndex = 2;
            this.ddimerLbl.Text = "D-dimer:";
            // 
            // mchoLbl
            // 
            this.mchoLbl.AutoSize = true;
            this.mchoLbl.Location = new System.Drawing.Point(9, 95);
            this.mchoLbl.Name = "mchoLbl";
            this.mchoLbl.Size = new System.Drawing.Size(35, 13);
            this.mchoLbl.TabIndex = 1;
            this.mchoLbl.Text = "МНО:";
            // 
            // achtvLbl
            // 
            this.achtvLbl.AutoSize = true;
            this.achtvLbl.Location = new System.Drawing.Point(9, 59);
            this.achtvLbl.Name = "achtvLbl";
            this.achtvLbl.Size = new System.Drawing.Size(39, 13);
            this.achtvLbl.TabIndex = 0;
            this.achtvLbl.Text = "АЧТВ:";
            // 
            // admissionDateLbl
            // 
            this.admissionDateLbl.AutoSize = true;
            this.admissionDateLbl.Location = new System.Drawing.Point(12, 27);
            this.admissionDateLbl.Name = "admissionDateLbl";
            this.admissionDateLbl.Size = new System.Drawing.Size(36, 13);
            this.admissionDateLbl.TabIndex = 6;
            this.admissionDateLbl.Text = "Дата:";
            // 
            // admissionDateTxt
            // 
            this.admissionDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.admissionDateTxt.Location = new System.Drawing.Point(69, 26);
            this.admissionDateTxt.Name = "admissionDateTxt";
            this.admissionDateTxt.Size = new System.Drawing.Size(85, 20);
            this.admissionDateTxt.TabIndex = 7;
            // 
            // Coagulogramm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.coagulogramPnl);
            this.Name = "Coagulogramm";
            this.Size = new System.Drawing.Size(173, 158);
            this.coagulogramPnl.ResumeLayout(false);
            this.coagulogramPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox coagulogramPnl;
        private System.Windows.Forms.DateTimePicker admissionDateTxt;
        private System.Windows.Forms.Label admissionDateLbl;
        private System.Windows.Forms.TextBox ddimerTxt;
        private System.Windows.Forms.TextBox mchoTxt;
        private System.Windows.Forms.TextBox achtvTxt;
        private System.Windows.Forms.Label ddimerLbl;
        private System.Windows.Forms.Label mchoLbl;
        private System.Windows.Forms.Label achtvLbl;
    }
}
