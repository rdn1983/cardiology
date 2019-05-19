namespace Cardiology.UI.Controls
{
    partial class IssuedActionControl
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
            this.removeBtn = new System.Windows.Forms.Button();
            this.issuedActionTxt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // removeBtn
            // 
            this.removeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeBtn.Image = global::Cardiology.Properties.Resources.remove;
            this.removeBtn.Location = new System.Drawing.Point(182, 3);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(45, 44);
            this.removeBtn.TabIndex = 1;
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // issuedActionTxt
            // 
            this.issuedActionTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.issuedActionTxt.Location = new System.Drawing.Point(3, 3);
            this.issuedActionTxt.Name = "issuedActionTxt";
            this.issuedActionTxt.Size = new System.Drawing.Size(178, 44);
            this.issuedActionTxt.TabIndex = 2;
            this.issuedActionTxt.Text = "";
            // 
            // IssuedActionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.issuedActionTxt);
            this.Controls.Add(this.removeBtn);
            this.Name = "IssuedActionControl";
            this.Size = new System.Drawing.Size(230, 49);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.RichTextBox issuedActionTxt;
    }
}
