namespace Cardiology
{
    partial class HolterControl
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
            this.monitoringAdBox = new System.Windows.Forms.GroupBox();
            this.monitoringAdTxt = new System.Windows.Forms.RichTextBox();
            this.holterBox = new System.Windows.Forms.GroupBox();
            this.holterTxt = new System.Windows.Forms.RichTextBox();
            this.title = new System.Windows.Forms.Label();
            this.cotainer = new System.Windows.Forms.Panel();
            this.monitoringAdBox.SuspendLayout();
            this.holterBox.SuspendLayout();
            this.cotainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // monitoringAdBox
            // 
            this.monitoringAdBox.Controls.Add(this.monitoringAdTxt);
            this.monitoringAdBox.Location = new System.Drawing.Point(6, 155);
            this.monitoringAdBox.Name = "monitoringAdBox";
            this.monitoringAdBox.Size = new System.Drawing.Size(702, 109);
            this.monitoringAdBox.TabIndex = 8;
            this.monitoringAdBox.TabStop = false;
            this.monitoringAdBox.Text = "АД мониторинг:";
            // 
            // monitoringAdTxt
            // 
            this.monitoringAdTxt.Location = new System.Drawing.Point(9, 16);
            this.monitoringAdTxt.Name = "monitoringAdTxt";
            this.monitoringAdTxt.Size = new System.Drawing.Size(684, 84);
            this.monitoringAdTxt.TabIndex = 1;
            this.monitoringAdTxt.Text = "";
            // 
            // holterBox
            // 
            this.holterBox.Controls.Add(this.holterTxt);
            this.holterBox.Location = new System.Drawing.Point(6, 40);
            this.holterBox.Name = "holterBox";
            this.holterBox.Size = new System.Drawing.Size(702, 109);
            this.holterBox.TabIndex = 7;
            this.holterBox.TabStop = false;
            this.holterBox.Text = "Холтер:";
            // 
            // holterTxt
            // 
            this.holterTxt.Location = new System.Drawing.Point(12, 17);
            this.holterTxt.Name = "holterTxt";
            this.holterTxt.Size = new System.Drawing.Size(678, 84);
            this.holterTxt.TabIndex = 0;
            this.holterTxt.Text = "";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.Location = new System.Drawing.Point(3, 14);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(113, 13);
            this.title.TabIndex = 9;
            this.title.Text = "Анализы текущие";
            // 
            // cotainer
            // 
            this.cotainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cotainer.Controls.Add(this.holterBox);
            this.cotainer.Controls.Add(this.title);
            this.cotainer.Controls.Add(this.monitoringAdBox);
            this.cotainer.Location = new System.Drawing.Point(3, 3);
            this.cotainer.Name = "cotainer";
            this.cotainer.Size = new System.Drawing.Size(715, 272);
            this.cotainer.TabIndex = 10;
            // 
            // HolterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cotainer);
            this.Name = "HolterControl";
            this.Size = new System.Drawing.Size(721, 279);
            this.monitoringAdBox.ResumeLayout(false);
            this.holterBox.ResumeLayout(false);
            this.cotainer.ResumeLayout(false);
            this.cotainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox monitoringAdBox;
        private System.Windows.Forms.RichTextBox monitoringAdTxt;
        private System.Windows.Forms.GroupBox holterBox;
        private System.Windows.Forms.RichTextBox holterTxt;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel cotainer;
    }
}
