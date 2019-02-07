namespace Cardiology.UI.Controls
{
    partial class XRayControl
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
            this.cotrolRadiographyBox = new System.Windows.Forms.GroupBox();
            this.controlRadiographyTxt = new System.Windows.Forms.RichTextBox();
            this.chestXRayBox = new System.Windows.Forms.GroupBox();
            this.chestXRayTxt = new System.Windows.Forms.RichTextBox();
            this.dateLbl = new System.Windows.Forms.Label();
            this.ktTimeTxt = new System.Windows.Forms.DateTimePicker();
            this.ktDateTxt = new System.Windows.Forms.DateTimePicker();
            this.mrtBox = new System.Windows.Forms.GroupBox();
            this.mrtTxt = new System.Windows.Forms.RichTextBox();
            this.ktBox = new System.Windows.Forms.GroupBox();
            this.ktTxt = new System.Windows.Forms.RichTextBox();
            this.cotrolRadiographyBox.SuspendLayout();
            this.chestXRayBox.SuspendLayout();
            this.mrtBox.SuspendLayout();
            this.ktBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cotrolRadiographyBox
            // 
            this.cotrolRadiographyBox.Controls.Add(this.controlRadiographyTxt);
            this.cotrolRadiographyBox.Location = new System.Drawing.Point(3, 148);
            this.cotrolRadiographyBox.Name = "cotrolRadiographyBox";
            this.cotrolRadiographyBox.Size = new System.Drawing.Size(489, 91);
            this.cotrolRadiographyBox.TabIndex = 8;
            this.cotrolRadiographyBox.TabStop = false;
            this.cotrolRadiographyBox.Text = "Контрольная рентгенография ОГК:";
            // 
            // controlRadiographyTxt
            // 
            this.controlRadiographyTxt.Location = new System.Drawing.Point(9, 16);
            this.controlRadiographyTxt.Name = "controlRadiographyTxt";
            this.controlRadiographyTxt.Size = new System.Drawing.Size(471, 66);
            this.controlRadiographyTxt.TabIndex = 1;
            this.controlRadiographyTxt.Text = "";
            this.controlRadiographyTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // chestXRayBox
            // 
            this.chestXRayBox.Controls.Add(this.chestXRayTxt);
            this.chestXRayBox.Location = new System.Drawing.Point(3, 51);
            this.chestXRayBox.Name = "chestXRayBox";
            this.chestXRayBox.Size = new System.Drawing.Size(489, 91);
            this.chestXRayBox.TabIndex = 7;
            this.chestXRayBox.TabStop = false;
            this.chestXRayBox.Text = "Рентген органов грудной клетки:";
            // 
            // chestXRayTxt
            // 
            this.chestXRayTxt.Location = new System.Drawing.Point(12, 17);
            this.chestXRayTxt.Name = "chestXRayTxt";
            this.chestXRayTxt.Size = new System.Drawing.Size(465, 66);
            this.chestXRayTxt.TabIndex = 0;
            this.chestXRayTxt.Text = "";
            this.chestXRayTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Location = new System.Drawing.Point(3, 9);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(185, 13);
            this.dateLbl.TabIndex = 20;
            this.dateLbl.Text = "Дата/Время проведения анализов";
            // 
            // ktTimeTxt
            // 
            this.ktTimeTxt.CustomFormat = "HH:mm tt";
            this.ktTimeTxt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ktTimeTxt.Location = new System.Drawing.Point(126, 28);
            this.ktTimeTxt.Name = "ktTimeTxt";
            this.ktTimeTxt.ShowUpDown = true;
            this.ktTimeTxt.Size = new System.Drawing.Size(117, 20);
            this.ktTimeTxt.TabIndex = 19;
            this.ktTimeTxt.ValueChanged += new System.EventHandler(this.ktDateTxt_ValueChanged);
            // 
            // ktDateTxt
            // 
            this.ktDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ktDateTxt.Location = new System.Drawing.Point(3, 28);
            this.ktDateTxt.Name = "ktDateTxt";
            this.ktDateTxt.Size = new System.Drawing.Size(117, 20);
            this.ktDateTxt.TabIndex = 18;
            this.ktDateTxt.ValueChanged += new System.EventHandler(this.ktDateTxt_ValueChanged);
            // 
            // mrtBox
            // 
            this.mrtBox.Controls.Add(this.mrtTxt);
            this.mrtBox.Location = new System.Drawing.Point(3, 342);
            this.mrtBox.Name = "mrtBox";
            this.mrtBox.Size = new System.Drawing.Size(489, 91);
            this.mrtBox.TabIndex = 17;
            this.mrtBox.TabStop = false;
            this.mrtBox.Text = "МРТ:";
            // 
            // mrtTxt
            // 
            this.mrtTxt.Location = new System.Drawing.Point(9, 17);
            this.mrtTxt.Name = "mrtTxt";
            this.mrtTxt.Size = new System.Drawing.Size(471, 66);
            this.mrtTxt.TabIndex = 1;
            this.mrtTxt.Text = "";
            this.mrtTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // ktBox
            // 
            this.ktBox.Controls.Add(this.ktTxt);
            this.ktBox.Location = new System.Drawing.Point(3, 245);
            this.ktBox.Name = "ktBox";
            this.ktBox.Size = new System.Drawing.Size(489, 91);
            this.ktBox.TabIndex = 16;
            this.ktBox.TabStop = false;
            this.ktBox.Text = "КТ:";
            // 
            // ktTxt
            // 
            this.ktTxt.Location = new System.Drawing.Point(9, 16);
            this.ktTxt.Name = "ktTxt";
            this.ktTxt.Size = new System.Drawing.Size(471, 66);
            this.ktTxt.TabIndex = 1;
            this.ktTxt.Text = "";
            this.ktTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // XRayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.dateLbl);
            this.Controls.Add(this.ktTimeTxt);
            this.Controls.Add(this.ktDateTxt);
            this.Controls.Add(this.mrtBox);
            this.Controls.Add(this.ktBox);
            this.Controls.Add(this.cotrolRadiographyBox);
            this.Controls.Add(this.chestXRayBox);
            this.Name = "XRayControl";
            this.Size = new System.Drawing.Size(497, 434);
            this.cotrolRadiographyBox.ResumeLayout(false);
            this.chestXRayBox.ResumeLayout(false);
            this.mrtBox.ResumeLayout(false);
            this.ktBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox cotrolRadiographyBox;
        private System.Windows.Forms.RichTextBox controlRadiographyTxt;
        private System.Windows.Forms.GroupBox chestXRayBox;
        private System.Windows.Forms.RichTextBox chestXRayTxt;
        private System.Windows.Forms.Label dateLbl;
        private System.Windows.Forms.DateTimePicker ktTimeTxt;
        private System.Windows.Forms.DateTimePicker ktDateTxt;
        private System.Windows.Forms.GroupBox mrtBox;
        private System.Windows.Forms.RichTextBox mrtTxt;
        private System.Windows.Forms.GroupBox ktBox;
        private System.Windows.Forms.RichTextBox ktTxt;
    }
}
