namespace Cardiology
{
    partial class EgdsAnalysisControl
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
            this.regularEgdsBox = new System.Windows.Forms.GroupBox();
            this.regularEgdsTxt = new System.Windows.Forms.RichTextBox();
            this.regularEgdsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // regularEgdsBox
            // 
            this.regularEgdsBox.Controls.Add(this.regularEgdsTxt);
            this.regularEgdsBox.Location = new System.Drawing.Point(3, 3);
            this.regularEgdsBox.Name = "regularEgdsBox";
            this.regularEgdsBox.Size = new System.Drawing.Size(677, 152);
            this.regularEgdsBox.TabIndex = 6;
            this.regularEgdsBox.TabStop = false;
            this.regularEgdsBox.Text = "Контрольное исследование";
            // 
            // regularEgdsTxt
            // 
            this.regularEgdsTxt.Location = new System.Drawing.Point(7, 20);
            this.regularEgdsTxt.Name = "regularEgdsTxt";
            this.regularEgdsTxt.Size = new System.Drawing.Size(664, 126);
            this.regularEgdsTxt.TabIndex = 0;
            this.regularEgdsTxt.Text = "";
            // 
            // EgdsAnalysisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.regularEgdsBox);
            this.Name = "EgdsAnalysisControl";
            this.Size = new System.Drawing.Size(683, 158);
            this.regularEgdsBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox regularEgdsBox;
        private System.Windows.Forms.RichTextBox regularEgdsTxt;
    }
}
