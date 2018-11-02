namespace Cardiology
{
    partial class IssuedMedicineControl
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
            this.medicineContainer = new System.Windows.Forms.TableLayoutPanel();
            this.removeBtn0 = new System.Windows.Forms.Button();
            this.medicineTypeTxt0 = new System.Windows.Forms.ComboBox();
            this.issuedMedicineTxt0 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // medicineContainer
            // 
            this.medicineContainer.AutoSize = true;
            this.medicineContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.medicineContainer.ColumnCount = 1;
            this.medicineContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.medicineContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.medicineContainer.Location = new System.Drawing.Point(3, 3);
            this.medicineContainer.Name = "medicineContainer";
            this.medicineContainer.RowCount = 1;
            this.medicineContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.medicineContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.medicineContainer.Size = new System.Drawing.Size(0, 0);
            this.medicineContainer.TabIndex = 2;
            // 
            // removeBtn0
            // 
            this.removeBtn0.Image = global::Cardiology.Properties.Resources.remove;
            this.removeBtn0.Location = new System.Drawing.Point(447, 2);
            this.removeBtn0.Name = "removeBtn0";
            this.removeBtn0.Size = new System.Drawing.Size(24, 23);
            this.removeBtn0.TabIndex = 3;
            this.removeBtn0.UseVisualStyleBackColor = true;
            this.removeBtn0.Click += new System.EventHandler(this.removeBtn0_Click);
            // 
            // medicineTypeTxt0
            // 
            this.medicineTypeTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.medicineTypeTxt0.FormattingEnabled = true;
            this.medicineTypeTxt0.Location = new System.Drawing.Point(4, 3);
            this.medicineTypeTxt0.Name = "medicineTypeTxt0";
            this.medicineTypeTxt0.Size = new System.Drawing.Size(133, 21);
            this.medicineTypeTxt0.TabIndex = 2;
            this.medicineTypeTxt0.SelectedIndexChanged += new System.EventHandler(this.medicineTypeTxt0_SelectedIndexChanged);
            // 
            // issuedMedicineTxt0
            // 
            this.issuedMedicineTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.issuedMedicineTxt0.FormattingEnabled = true;
            this.issuedMedicineTxt0.Location = new System.Drawing.Point(140, 3);
            this.issuedMedicineTxt0.Name = "issuedMedicineTxt0";
            this.issuedMedicineTxt0.Size = new System.Drawing.Size(306, 21);
            this.issuedMedicineTxt0.TabIndex = 0;
            // 
            // IssuedMedicineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.removeBtn0);
            this.Controls.Add(this.medicineTypeTxt0);
            this.Controls.Add(this.medicineContainer);
            this.Controls.Add(this.issuedMedicineTxt0);
            this.Name = "IssuedMedicineControl";
            this.Size = new System.Drawing.Size(474, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel medicineContainer;
        private System.Windows.Forms.ComboBox medicineTypeTxt0;
        private System.Windows.Forms.ComboBox issuedMedicineTxt0;
        private System.Windows.Forms.Button removeBtn0;
    }
}
