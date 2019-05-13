namespace Cardiology.UI.Controls
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
            this.admissionDateTxt = new System.Windows.Forms.DateTimePicker();
            this.admissionDateLbl = new System.Windows.Forms.Label();
            this.ddimerTxt = new System.Windows.Forms.TextBox();
            this.mchoTxt = new System.Windows.Forms.TextBox();
            this.achtvTxt = new System.Windows.Forms.TextBox();
            this.ddimerLbl = new System.Windows.Forms.Label();
            this.mchoLbl = new System.Windows.Forms.Label();
            this.achtvLbl = new System.Windows.Forms.Label();
            this.hide = new System.Windows.Forms.Button();
            this.coagulogramPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // coagulogramPnl
            // 
            this.coagulogramPnl.Controls.Add(this.hide);
            this.coagulogramPnl.Controls.Add(this.admissionDateTxt);
            this.coagulogramPnl.Controls.Add(this.admissionDateLbl);
            this.coagulogramPnl.Controls.Add(this.ddimerTxt);
            this.coagulogramPnl.Controls.Add(this.mchoTxt);
            this.coagulogramPnl.Controls.Add(this.achtvTxt);
            this.coagulogramPnl.Controls.Add(this.ddimerLbl);
            this.coagulogramPnl.Controls.Add(this.mchoLbl);
            this.coagulogramPnl.Controls.Add(this.achtvLbl);
            this.coagulogramPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coagulogramPnl.Location = new System.Drawing.Point(3, -1);
            this.coagulogramPnl.Name = "coagulogramPnl";
            this.coagulogramPnl.Size = new System.Drawing.Size(193, 154);
            this.coagulogramPnl.TabIndex = 40;
            this.coagulogramPnl.TabStop = false;
            this.coagulogramPnl.Text = "Коагулограмма текущая";
            // 
            // admissionDateTxt
            // 
            this.admissionDateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.admissionDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.admissionDateTxt.Location = new System.Drawing.Point(69, 22);
            this.admissionDateTxt.Name = "admissionDateTxt";
            this.admissionDateTxt.Size = new System.Drawing.Size(113, 20);
            this.admissionDateTxt.TabIndex = 7;
            this.admissionDateTxt.ValueChanged += new System.EventHandler(this.admissionDateTxt_ValueChanged);
            // 
            // admissionDateLbl
            // 
            this.admissionDateLbl.AutoSize = true;
            this.admissionDateLbl.Location = new System.Drawing.Point(12, 23);
            this.admissionDateLbl.Name = "admissionDateLbl";
            this.admissionDateLbl.Size = new System.Drawing.Size(41, 13);
            this.admissionDateLbl.TabIndex = 6;
            this.admissionDateLbl.Text = "Дата:";
            // 
            // ddimerTxt
            // 
            this.ddimerTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddimerTxt.Location = new System.Drawing.Point(69, 103);
            this.ddimerTxt.Name = "ddimerTxt";
            this.ddimerTxt.Size = new System.Drawing.Size(113, 20);
            this.ddimerTxt.TabIndex = 5;
            this.ddimerTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // mchoTxt
            // 
            this.mchoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mchoTxt.Location = new System.Drawing.Point(69, 75);
            this.mchoTxt.Name = "mchoTxt";
            this.mchoTxt.Size = new System.Drawing.Size(113, 20);
            this.mchoTxt.TabIndex = 4;
            this.mchoTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // achtvTxt
            // 
            this.achtvTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.achtvTxt.Location = new System.Drawing.Point(69, 48);
            this.achtvTxt.Name = "achtvTxt";
            this.achtvTxt.Size = new System.Drawing.Size(113, 20);
            this.achtvTxt.TabIndex = 3;
            this.achtvTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // ddimerLbl
            // 
            this.ddimerLbl.AutoSize = true;
            this.ddimerLbl.Location = new System.Drawing.Point(9, 110);
            this.ddimerLbl.Name = "ddimerLbl";
            this.ddimerLbl.Size = new System.Drawing.Size(54, 13);
            this.ddimerLbl.TabIndex = 2;
            this.ddimerLbl.Text = "D-dimer:";
            // 
            // mchoLbl
            // 
            this.mchoLbl.AutoSize = true;
            this.mchoLbl.Location = new System.Drawing.Point(9, 82);
            this.mchoLbl.Name = "mchoLbl";
            this.mchoLbl.Size = new System.Drawing.Size(39, 13);
            this.mchoLbl.TabIndex = 1;
            this.mchoLbl.Text = "МНО:";
            // 
            // achtvLbl
            // 
            this.achtvLbl.AutoSize = true;
            this.achtvLbl.Location = new System.Drawing.Point(9, 51);
            this.achtvLbl.Name = "achtvLbl";
            this.achtvLbl.Size = new System.Drawing.Size(44, 13);
            this.achtvLbl.TabIndex = 0;
            this.achtvLbl.Text = "АЧТВ:";
            // 
            // hide
            // 
            this.hide.Image = global::Cardiology.Properties.Resources.remove;
            this.hide.Location = new System.Drawing.Point(156, 125);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(26, 23);
            this.hide.TabIndex = 39;
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // CoagulogrammControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.coagulogramPnl);
            this.Name = "CoagulogrammControl";
            this.Size = new System.Drawing.Size(202, 158);
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
        private System.Windows.Forms.Button hide;
    }
}
