namespace Cardiology
{
    partial class UserFormVEKS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserFormVEKS));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.veinTxt = new System.Windows.Forms.TextBox();
            this.bodyArea = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.doctorsBox = new System.Windows.Forms.ComboBox();
            this.printBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "В стерильных условиях под местной анестезией раствором Sol. Novocaini 0,25 % -5,0" +
    " п/к ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "произведена пункция и катетеризация";
            // 
            // veinTxt
            // 
            this.veinTxt.Location = new System.Drawing.Point(227, 27);
            this.veinTxt.Name = "veinTxt";
            this.veinTxt.Size = new System.Drawing.Size(237, 20);
            this.veinTxt.TabIndex = 2;
            this.veinTxt.Text = "правой подключичной вены.";
            // 
            // bodyArea
            // 
            this.bodyArea.Location = new System.Drawing.Point(13, 56);
            this.bodyArea.Name = "bodyArea";
            this.bodyArea.Size = new System.Drawing.Size(451, 96);
            this.bodyArea.TabIndex = 3;
            this.bodyArea.Text = resources.GetString("bodyArea.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Врач:";
            // 
            // doctorsBox
            // 
            this.doctorsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doctorsBox.FormattingEnabled = true;
            this.doctorsBox.Location = new System.Drawing.Point(52, 156);
            this.doctorsBox.Name = "doctorsBox";
            this.doctorsBox.Size = new System.Drawing.Size(168, 21);
            this.doctorsBox.TabIndex = 5;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(340, 153);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(123, 23);
            this.printBtn.TabIndex = 6;
            this.printBtn.Text = "MsWord";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // UserFormVEKS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 187);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.doctorsBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bodyArea);
            this.Controls.Add(this.veinTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(497, 230);
            this.Name = "UserFormVEKS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Протокол постановки ВЭКС";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox veinTxt;
        private System.Windows.Forms.RichTextBox bodyArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox doctorsBox;
        private System.Windows.Forms.Button printBtn;
    }
}