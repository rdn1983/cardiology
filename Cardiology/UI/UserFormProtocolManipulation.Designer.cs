namespace Cardiology.UI
{
    partial class UserFormProtocolManipulation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserFormProtocolManipulation));
            this.kateterBtn = new System.Windows.Forms.Button();
            this.trombolizisBtn = new System.Windows.Forms.Button();
            this.veksBtn = new System.Windows.Forms.Button();
            this.toraketosBtn = new System.Windows.Forms.Button();
            this.eitBtn = new System.Windows.Forms.Button();
            this.intubationBtn = new System.Windows.Forms.Button();
            this.ekstubationBtn = new System.Windows.Forms.Button();
            this.reanimBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kateterBtn
            // 
            this.kateterBtn.Location = new System.Drawing.Point(12, 12);
            this.kateterBtn.Name = "kateterBtn";
            this.kateterBtn.Size = new System.Drawing.Size(250, 23);
            this.kateterBtn.TabIndex = 0;
            this.kateterBtn.Text = "катетеризация подключичной, яремной  вены";
            this.kateterBtn.UseVisualStyleBackColor = true;
            this.kateterBtn.Click += new System.EventHandler(this.kateterBtn_Click);
            // 
            // trombolizisBtn
            // 
            this.trombolizisBtn.Location = new System.Drawing.Point(12, 42);
            this.trombolizisBtn.Name = "trombolizisBtn";
            this.trombolizisBtn.Size = new System.Drawing.Size(250, 23);
            this.trombolizisBtn.TabIndex = 1;
            this.trombolizisBtn.Text = "Показания к тромболизису";
            this.trombolizisBtn.UseVisualStyleBackColor = true;
            this.trombolizisBtn.Click += new System.EventHandler(this.trombolizisBtn_Click);
            // 
            // veksBtn
            // 
            this.veksBtn.Location = new System.Drawing.Point(12, 71);
            this.veksBtn.Name = "veksBtn";
            this.veksBtn.Size = new System.Drawing.Size(250, 23);
            this.veksBtn.TabIndex = 2;
            this.veksBtn.Text = "Протокол постановки ВЭКС";
            this.veksBtn.UseVisualStyleBackColor = true;
            this.veksBtn.Click += new System.EventHandler(this.veksBtn_Click);
            // 
            // toraketosBtn
            // 
            this.toraketosBtn.Location = new System.Drawing.Point(12, 100);
            this.toraketosBtn.Name = "toraketosBtn";
            this.toraketosBtn.Size = new System.Drawing.Size(250, 23);
            this.toraketosBtn.TabIndex = 3;
            this.toraketosBtn.Text = "Протокол торакоцентеза";
            this.toraketosBtn.UseVisualStyleBackColor = true;
            this.toraketosBtn.Click += new System.EventHandler(this.toraketosBtn_Click);
            // 
            // eitBtn
            // 
            this.eitBtn.Location = new System.Drawing.Point(12, 129);
            this.eitBtn.Name = "eitBtn";
            this.eitBtn.Size = new System.Drawing.Size(250, 23);
            this.eitBtn.TabIndex = 4;
            this.eitBtn.Text = "Протокол ЭИТ";
            this.eitBtn.UseVisualStyleBackColor = true;
            this.eitBtn.Click += new System.EventHandler(this.eitBtn_Click);
            // 
            // intubationBtn
            // 
            this.intubationBtn.Location = new System.Drawing.Point(12, 158);
            this.intubationBtn.Name = "intubationBtn";
            this.intubationBtn.Size = new System.Drawing.Size(250, 23);
            this.intubationBtn.TabIndex = 5;
            this.intubationBtn.Text = "интубация";
            this.intubationBtn.UseVisualStyleBackColor = true;
            this.intubationBtn.Click += new System.EventHandler(this.intubationBtn_Click);
            // 
            // ekstubationBtn
            // 
            this.ekstubationBtn.Location = new System.Drawing.Point(12, 187);
            this.ekstubationBtn.Name = "ekstubationBtn";
            this.ekstubationBtn.Size = new System.Drawing.Size(250, 23);
            this.ekstubationBtn.TabIndex = 6;
            this.ekstubationBtn.Text = "экстубация";
            this.ekstubationBtn.UseVisualStyleBackColor = true;
            this.ekstubationBtn.Click += new System.EventHandler(this.ekstubationBtn_Click);
            // 
            // reanimBtn
            // 
            this.reanimBtn.Location = new System.Drawing.Point(12, 216);
            this.reanimBtn.Name = "reanimBtn";
            this.reanimBtn.Size = new System.Drawing.Size(250, 23);
            this.reanimBtn.TabIndex = 7;
            this.reanimBtn.Text = "Реанимационные мероприятия+констатация";
            this.reanimBtn.UseVisualStyleBackColor = true;
            this.reanimBtn.Click += new System.EventHandler(this.reanimBtn_Click);
            // 
            // UserFormProtocolManipulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 408);
            this.Controls.Add(this.reanimBtn);
            this.Controls.Add(this.ekstubationBtn);
            this.Controls.Add(this.intubationBtn);
            this.Controls.Add(this.eitBtn);
            this.Controls.Add(this.toraketosBtn);
            this.Controls.Add(this.veksBtn);
            this.Controls.Add(this.trombolizisBtn);
            this.Controls.Add(this.kateterBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(294, 451);
            this.Name = "UserFormProtocolManipulation";
            this.Text = "Протоколы манипуляций";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button kateterBtn;
        private System.Windows.Forms.Button trombolizisBtn;
        private System.Windows.Forms.Button veksBtn;
        private System.Windows.Forms.Button toraketosBtn;
        private System.Windows.Forms.Button eitBtn;
        private System.Windows.Forms.Button intubationBtn;
        private System.Windows.Forms.Button ekstubationBtn;
        private System.Windows.Forms.Button reanimBtn;
    }
}