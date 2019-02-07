namespace Cardiology.UI.Controls
{
    partial class IssuedActionContainer
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
            this.sizedContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // sizedContainer
            // 
            this.sizedContainer.AutoSize = true;
            this.sizedContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sizedContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sizedContainer.Location = new System.Drawing.Point(3, 3);
            this.sizedContainer.Name = "sizedContainer";
            this.sizedContainer.Size = new System.Drawing.Size(0, 0);
            this.sizedContainer.TabIndex = 0;
            // 
            // IssuedActionContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.sizedContainer);
            this.Name = "IssuedActionContainer";
            this.Size = new System.Drawing.Size(6, 6);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel sizedContainer;
    }
}
