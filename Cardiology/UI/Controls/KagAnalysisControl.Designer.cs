namespace Cardiology.UI.Controls
{
    partial class KagAnalysisControl
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
            this.components = new System.ComponentModel.Container();
            this.kagActionsBox = new System.Windows.Forms.GroupBox();
            this.kagActionsTxt = new System.Windows.Forms.RichTextBox();
            this.manipulationBox = new System.Windows.Forms.GroupBox();
            this.kagManipulationTxt = new System.Windows.Forms.RichTextBox();
            this.resultsBox = new System.Windows.Forms.GroupBox();
            this.kagResultsTxt = new System.Windows.Forms.RichTextBox();
            this.kagTimeBox = new System.Windows.Forms.GroupBox();
            this.kagStartTime = new System.Windows.Forms.DateTimePicker();
            this.kagEndTime = new System.Windows.Forms.DateTimePicker();
            this.endTimeLbl = new System.Windows.Forms.Label();
            this.startTimeLbl = new System.Windows.Forms.Label();
            this.kagDateBox = new System.Windows.Forms.GroupBox();
            this.kagDate = new System.Windows.Forms.DateTimePicker();
            this.container = new System.Windows.Forms.Panel();
            this.showBlanksBtn = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.blanksMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.procedureConsentBlank = new System.Windows.Forms.ToolStripMenuItem();
            this.dataProcessingBlank = new System.Windows.Forms.ToolStripMenuItem();
            this.anesthesiaBlank = new System.Windows.Forms.ToolStripMenuItem();
            this.kagActionsBox.SuspendLayout();
            this.manipulationBox.SuspendLayout();
            this.resultsBox.SuspendLayout();
            this.kagTimeBox.SuspendLayout();
            this.kagDateBox.SuspendLayout();
            this.container.SuspendLayout();
            this.blanksMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // kagActionsBox
            // 
            this.kagActionsBox.Controls.Add(this.kagActionsTxt);
            this.kagActionsBox.Location = new System.Drawing.Point(3, 329);
            this.kagActionsBox.Name = "kagActionsBox";
            this.kagActionsBox.Size = new System.Drawing.Size(468, 110);
            this.kagActionsBox.TabIndex = 13;
            this.kagActionsBox.TabStop = false;
            this.kagActionsBox.Text = "Таким образом у пациента";
            // 
            // kagActionsTxt
            // 
            this.kagActionsTxt.Location = new System.Drawing.Point(5, 17);
            this.kagActionsTxt.Name = "kagActionsTxt";
            this.kagActionsTxt.Size = new System.Drawing.Size(456, 86);
            this.kagActionsTxt.TabIndex = 0;
            this.kagActionsTxt.Text = "";
            this.kagActionsTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // manipulationBox
            // 
            this.manipulationBox.Controls.Add(this.kagManipulationTxt);
            this.manipulationBox.Location = new System.Drawing.Point(3, 219);
            this.manipulationBox.Name = "manipulationBox";
            this.manipulationBox.Size = new System.Drawing.Size(468, 104);
            this.manipulationBox.TabIndex = 12;
            this.manipulationBox.TabStop = false;
            this.manipulationBox.Text = "Пациенту выполнено";
            // 
            // kagManipulationTxt
            // 
            this.kagManipulationTxt.Location = new System.Drawing.Point(6, 16);
            this.kagManipulationTxt.Name = "kagManipulationTxt";
            this.kagManipulationTxt.Size = new System.Drawing.Size(456, 81);
            this.kagManipulationTxt.TabIndex = 0;
            this.kagManipulationTxt.Text = "";
            this.kagManipulationTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // resultsBox
            // 
            this.resultsBox.Controls.Add(this.kagResultsTxt);
            this.resultsBox.Location = new System.Drawing.Point(1, 108);
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.Size = new System.Drawing.Size(470, 105);
            this.resultsBox.TabIndex = 11;
            this.resultsBox.TabStop = false;
            this.resultsBox.Text = "По данным КГ выявлено";
            // 
            // kagResultsTxt
            // 
            this.kagResultsTxt.Location = new System.Drawing.Point(7, 19);
            this.kagResultsTxt.Name = "kagResultsTxt";
            this.kagResultsTxt.Size = new System.Drawing.Size(457, 78);
            this.kagResultsTxt.TabIndex = 0;
            this.kagResultsTxt.Text = "";
            this.kagResultsTxt.TextChanged += new System.EventHandler(this.ControlTxt_TextChanged);
            // 
            // kagTimeBox
            // 
            this.kagTimeBox.Controls.Add(this.kagStartTime);
            this.kagTimeBox.Controls.Add(this.kagEndTime);
            this.kagTimeBox.Controls.Add(this.endTimeLbl);
            this.kagTimeBox.Controls.Add(this.startTimeLbl);
            this.kagTimeBox.Location = new System.Drawing.Point(243, 30);
            this.kagTimeBox.Name = "kagTimeBox";
            this.kagTimeBox.Size = new System.Drawing.Size(228, 72);
            this.kagTimeBox.TabIndex = 10;
            this.kagTimeBox.TabStop = false;
            this.kagTimeBox.Text = "Время";
            // 
            // kagStartTime
            // 
            this.kagStartTime.CustomFormat = "HH:mm tt";
            this.kagStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kagStartTime.Location = new System.Drawing.Point(51, 14);
            this.kagStartTime.Name = "kagStartTime";
            this.kagStartTime.ShowUpDown = true;
            this.kagStartTime.Size = new System.Drawing.Size(171, 20);
            this.kagStartTime.TabIndex = 2;
            this.kagStartTime.ValueChanged += new System.EventHandler(this.kagStartTime_ValueChanged);
            // 
            // kagEndTime
            // 
            this.kagEndTime.CustomFormat = "HH:mm tt";
            this.kagEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kagEndTime.Location = new System.Drawing.Point(51, 41);
            this.kagEndTime.Name = "kagEndTime";
            this.kagEndTime.ShowUpDown = true;
            this.kagEndTime.Size = new System.Drawing.Size(171, 20);
            this.kagEndTime.TabIndex = 2;
            this.kagEndTime.ValueChanged += new System.EventHandler(this.kagDate_ValueChanged);
            // 
            // endTimeLbl
            // 
            this.endTimeLbl.AutoSize = true;
            this.endTimeLbl.Location = new System.Drawing.Point(10, 41);
            this.endTimeLbl.Name = "endTimeLbl";
            this.endTimeLbl.Size = new System.Drawing.Size(41, 13);
            this.endTimeLbl.TabIndex = 1;
            this.endTimeLbl.Text = "Конец:";
            // 
            // startTimeLbl
            // 
            this.startTimeLbl.AutoSize = true;
            this.startTimeLbl.Location = new System.Drawing.Point(7, 20);
            this.startTimeLbl.Name = "startTimeLbl";
            this.startTimeLbl.Size = new System.Drawing.Size(47, 13);
            this.startTimeLbl.TabIndex = 0;
            this.startTimeLbl.Text = "Начало:";
            // 
            // kagDateBox
            // 
            this.kagDateBox.Controls.Add(this.kagDate);
            this.kagDateBox.Location = new System.Drawing.Point(3, 30);
            this.kagDateBox.Name = "kagDateBox";
            this.kagDateBox.Size = new System.Drawing.Size(215, 72);
            this.kagDateBox.TabIndex = 9;
            this.kagDateBox.TabStop = false;
            this.kagDateBox.Text = "Дата";
            // 
            // kagDate
            // 
            this.kagDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.kagDate.Location = new System.Drawing.Point(9, 25);
            this.kagDate.Name = "kagDate";
            this.kagDate.Size = new System.Drawing.Size(167, 20);
            this.kagDate.TabIndex = 0;
            this.kagDate.ValueChanged += new System.EventHandler(this.kagDate_ValueChanged);
            // 
            // container
            // 
            this.container.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.container.Controls.Add(this.showBlanksBtn);
            this.container.Controls.Add(this.title);
            this.container.Controls.Add(this.kagDateBox);
            this.container.Controls.Add(this.kagActionsBox);
            this.container.Controls.Add(this.kagTimeBox);
            this.container.Controls.Add(this.manipulationBox);
            this.container.Controls.Add(this.resultsBox);
            this.container.Location = new System.Drawing.Point(3, 3);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(479, 495);
            this.container.TabIndex = 14;
            // 
            // showBlanksBtn
            // 
            this.showBlanksBtn.Location = new System.Drawing.Point(8, 455);
            this.showBlanksBtn.Name = "showBlanksBtn";
            this.showBlanksBtn.Size = new System.Drawing.Size(75, 23);
            this.showBlanksBtn.TabIndex = 15;
            this.showBlanksBtn.Text = "Бланки";
            this.showBlanksBtn.UseVisualStyleBackColor = true;
            this.showBlanksBtn.Click += new System.EventHandler(this.showBlanksBtn_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.Location = new System.Drawing.Point(3, 12);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(113, 13);
            this.title.TabIndex = 14;
            this.title.Text = "Анализы текущие";
            // 
            // blanksMenu
            // 
            this.blanksMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.procedureConsentBlank,
            this.dataProcessingBlank,
            this.anesthesiaBlank});
            this.blanksMenu.Name = "blanksMenu";
            this.blanksMenu.Size = new System.Drawing.Size(247, 70);
            // 
            // procedureConsentBlank
            // 
            this.procedureConsentBlank.Name = "procedureConsentBlank";
            this.procedureConsentBlank.Size = new System.Drawing.Size(246, 22);
            this.procedureConsentBlank.Text = "Согласие на процедуру";
            this.procedureConsentBlank.Click += new System.EventHandler(this.procedureConsentBlank_Click);
            // 
            // dataProcessingBlank
            // 
            this.dataProcessingBlank.Name = "dataProcessingBlank";
            this.dataProcessingBlank.Size = new System.Drawing.Size(246, 22);
            this.dataProcessingBlank.Text = "Согласие на обработку данных";
            this.dataProcessingBlank.Click += new System.EventHandler(this.dataProcessingBlank_Click);
            // 
            // anesthesiaBlank
            // 
            this.anesthesiaBlank.Name = "anesthesiaBlank";
            this.anesthesiaBlank.Size = new System.Drawing.Size(246, 22);
            this.anesthesiaBlank.Text = "Согласие на анастезию";
            this.anesthesiaBlank.Click += new System.EventHandler(this.anesthesiaBlank_Click);
            // 
            // KagAnalysisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.container);
            this.Name = "KagAnalysisControl";
            this.Size = new System.Drawing.Size(487, 500);
            this.kagActionsBox.ResumeLayout(false);
            this.manipulationBox.ResumeLayout(false);
            this.resultsBox.ResumeLayout(false);
            this.kagTimeBox.ResumeLayout(false);
            this.kagTimeBox.PerformLayout();
            this.kagDateBox.ResumeLayout(false);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.blanksMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox kagActionsBox;
        private System.Windows.Forms.RichTextBox kagActionsTxt;
        private System.Windows.Forms.GroupBox manipulationBox;
        private System.Windows.Forms.RichTextBox kagManipulationTxt;
        private System.Windows.Forms.GroupBox resultsBox;
        private System.Windows.Forms.RichTextBox kagResultsTxt;
        private System.Windows.Forms.GroupBox kagTimeBox;
        private System.Windows.Forms.DateTimePicker kagStartTime;
        private System.Windows.Forms.DateTimePicker kagEndTime;
        private System.Windows.Forms.Label endTimeLbl;
        private System.Windows.Forms.Label startTimeLbl;
        private System.Windows.Forms.GroupBox kagDateBox;
        private System.Windows.Forms.DateTimePicker kagDate;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button showBlanksBtn;
        private System.Windows.Forms.ContextMenuStrip blanksMenu;
        private System.Windows.Forms.ToolStripMenuItem procedureConsentBlank;
        private System.Windows.Forms.ToolStripMenuItem dataProcessingBlank;
        private System.Windows.Forms.ToolStripMenuItem anesthesiaBlank;
    }
}
