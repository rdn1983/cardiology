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
            this.issuedMedPnl0 = new System.Windows.Forms.Panel();
            this.removeBtn0 = new System.Windows.Forms.Button();
            this.medicineTypeTxt0 = new System.Windows.Forms.ComboBox();
            this.objectIdLbl0 = new System.Windows.Forms.Label();
            this.issuedMedicineTxt0 = new System.Windows.Forms.ComboBox();
            this.issuedMedPnl0.SuspendLayout();
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
            // issuedMedPnl0
            // 
            this.issuedMedPnl0.Controls.Add(this.removeBtn0);
            this.issuedMedPnl0.Controls.Add(this.medicineTypeTxt0);
            this.issuedMedPnl0.Controls.Add(this.objectIdLbl0);
            this.issuedMedPnl0.Controls.Add(this.issuedMedicineTxt0);
            this.issuedMedPnl0.Location = new System.Drawing.Point(5, 7);
            this.issuedMedPnl0.Name = "issuedMedPnl0";
            this.issuedMedPnl0.Size = new System.Drawing.Size(472, 28);
            this.issuedMedPnl0.TabIndex = 13;
            this.issuedMedPnl0.Visible = false;
            // 
            // removeBtn0
            // 
            this.removeBtn0.Image = global::Cardiology.Properties.Resources.remove;
            this.removeBtn0.Location = new System.Drawing.Point(446, 2);
            this.removeBtn0.Name = "removeBtn0";
            this.removeBtn0.Size = new System.Drawing.Size(24, 23);
            this.removeBtn0.TabIndex = 3;
            this.removeBtn0.UseVisualStyleBackColor = true;
            // 
            // medicineTypeTxt0
            // 
            this.medicineTypeTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.medicineTypeTxt0.FormattingEnabled = true;
            this.medicineTypeTxt0.Location = new System.Drawing.Point(3, 3);
            this.medicineTypeTxt0.Name = "medicineTypeTxt0";
            this.medicineTypeTxt0.Size = new System.Drawing.Size(133, 21);
            this.medicineTypeTxt0.TabIndex = 2;
            // 
            // objectIdLbl0
            // 
            this.objectIdLbl0.AutoSize = true;
            this.objectIdLbl0.Location = new System.Drawing.Point(438, 6);
            this.objectIdLbl0.Name = "objectIdLbl0";
            this.objectIdLbl0.Size = new System.Drawing.Size(0, 13);
            this.objectIdLbl0.TabIndex = 1;
            this.objectIdLbl0.Visible = false;
            // 
            // issuedMedicineTxt0
            // 
            this.issuedMedicineTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.issuedMedicineTxt0.FormattingEnabled = true;
            this.issuedMedicineTxt0.Location = new System.Drawing.Point(139, 3);
            this.issuedMedicineTxt0.Name = "issuedMedicineTxt0";
            this.issuedMedicineTxt0.Size = new System.Drawing.Size(306, 21);
            this.issuedMedicineTxt0.TabIndex = 0;
            // 
            // IssuedMedicineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.issuedMedPnl0);
            this.Controls.Add(this.medicineContainer);
            this.Name = "IssuedMedicineControl";
            this.Size = new System.Drawing.Size(480, 38);
            this.issuedMedPnl0.ResumeLayout(false);
            this.issuedMedPnl0.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel medicineContainer;
        private System.Windows.Forms.Panel issuedMedPnl0;
        private System.Windows.Forms.ComboBox medicineTypeTxt0;
        private System.Windows.Forms.Label objectIdLbl0;
        private System.Windows.Forms.ComboBox issuedMedicineTxt0;
        private System.Windows.Forms.Button removeBtn0;
    }
}
