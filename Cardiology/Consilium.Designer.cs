namespace Cardiology
{
    partial class Consilium
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consilium));
            this.appointmentTxt0 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.adminTxt = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addDoctor = new System.Windows.Forms.Button();
            this.allDoctorsPnl = new System.Windows.Forms.Panel();
            this.doctorsContainer = new System.Windows.Forms.TableLayoutPanel();
            this.dotorInfoPnl0 = new System.Windows.Forms.Panel();
            this.removeBtn0 = new System.Windows.Forms.Button();
            this.doctorWho0 = new System.Windows.Forms.ComboBox();
            this.objectIdLbl0 = new System.Windows.Forms.Label();
            this.consiliumMembersLbl = new System.Windows.Forms.Label();
            this.dutyAdminTodayPnl = new System.Windows.Forms.Panel();
            this.dutyAdminLbl = new System.Windows.Forms.Label();
            this.goalContainer = new System.Windows.Forms.Panel();
            this.goalTxt = new System.Windows.Forms.RichTextBox();
            this.goalLbl = new System.Windows.Forms.Label();
            this.dynamicsContainer = new System.Windows.Forms.Panel();
            this.dynamicsTxt = new System.Windows.Forms.RichTextBox();
            this.dynamicsLbl = new System.Windows.Forms.Label();
            this.diagnosisContainer = new System.Windows.Forms.Panel();
            this.diagnosisTxt1 = new System.Windows.Forms.RichTextBox();
            this.diagnosisTxt0 = new System.Windows.Forms.RichTextBox();
            this.diagnosisLbl = new System.Windows.Forms.Label();
            this.decisionContainer = new System.Windows.Forms.Panel();
            this.decisionVariantsPnl = new System.Windows.Forms.GroupBox();
            this.oksWithStBtn = new System.Windows.Forms.RadioButton();
            this.oksDeclineBtn = new System.Windows.Forms.RadioButton();
            this.oksAcceptBtn = new System.Windows.Forms.RadioButton();
            this.kagBtn = new System.Windows.Forms.RadioButton();
            this.decisionTxt = new System.Windows.Forms.RichTextBox();
            this.decisionLbl = new System.Windows.Forms.Label();
            this.operationGoalPnl = new System.Windows.Forms.GroupBox();
            this.revaskularizationGoal = new System.Windows.Forms.RadioButton();
            this.evaluationGoal = new System.Windows.Forms.RadioButton();
            this.saveBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.allDoctorsPnl.SuspendLayout();
            this.doctorsContainer.SuspendLayout();
            this.dotorInfoPnl0.SuspendLayout();
            this.dutyAdminTodayPnl.SuspendLayout();
            this.goalContainer.SuspendLayout();
            this.dynamicsContainer.SuspendLayout();
            this.diagnosisContainer.SuspendLayout();
            this.decisionContainer.SuspendLayout();
            this.decisionVariantsPnl.SuspendLayout();
            this.operationGoalPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // appointmentTxt0
            // 
            this.appointmentTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appointmentTxt0.FormattingEnabled = true;
            this.appointmentTxt0.Location = new System.Drawing.Point(3, 3);
            this.appointmentTxt0.Name = "appointmentTxt0";
            this.appointmentTxt0.Size = new System.Drawing.Size(249, 21);
            this.appointmentTxt0.TabIndex = 1;
            this.appointmentTxt0.SelectedIndexChanged += new System.EventHandler(this.appointmentTxt0_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Цель консилиума";
            // 
            // adminTxt
            // 
            this.adminTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adminTxt.FormattingEnabled = true;
            this.adminTxt.Location = new System.Drawing.Point(18, 120);
            this.adminTxt.Name = "adminTxt";
            this.adminTxt.Size = new System.Drawing.Size(302, 21);
            this.adminTxt.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cornsilk;
            this.panel1.Controls.Add(this.addDoctor);
            this.panel1.Controls.Add(this.allDoctorsPnl);
            this.panel1.Controls.Add(this.consiliumMembersLbl);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 242);
            this.panel1.TabIndex = 27;
            // 
            // addDoctor
            // 
            this.addDoctor.Image = ((System.Drawing.Image)(resources.GetObject("addDoctor.Image")));
            this.addDoctor.Location = new System.Drawing.Point(510, 12);
            this.addDoctor.Name = "addDoctor";
            this.addDoctor.Size = new System.Drawing.Size(28, 28);
            this.addDoctor.TabIndex = 28;
            this.addDoctor.UseVisualStyleBackColor = true;
            this.addDoctor.Click += new System.EventHandler(this.addDoctor_Click);
            // 
            // allDoctorsPnl
            // 
            this.allDoctorsPnl.AutoScroll = true;
            this.allDoctorsPnl.Controls.Add(this.doctorsContainer);
            this.allDoctorsPnl.Location = new System.Drawing.Point(3, 42);
            this.allDoctorsPnl.Name = "allDoctorsPnl";
            this.allDoctorsPnl.Size = new System.Drawing.Size(537, 197);
            this.allDoctorsPnl.TabIndex = 27;
            // 
            // doctorsContainer
            // 
            this.doctorsContainer.AutoSize = true;
            this.doctorsContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.doctorsContainer.ColumnCount = 1;
            this.doctorsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.doctorsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.doctorsContainer.Controls.Add(this.dotorInfoPnl0, 0, 0);
            this.doctorsContainer.Location = new System.Drawing.Point(2, 3);
            this.doctorsContainer.Name = "doctorsContainer";
            this.doctorsContainer.RowCount = 1;
            this.doctorsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.doctorsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.doctorsContainer.Size = new System.Drawing.Size(535, 33);
            this.doctorsContainer.TabIndex = 26;
            // 
            // dotorInfoPnl0
            // 
            this.dotorInfoPnl0.Controls.Add(this.removeBtn0);
            this.dotorInfoPnl0.Controls.Add(this.doctorWho0);
            this.dotorInfoPnl0.Controls.Add(this.objectIdLbl0);
            this.dotorInfoPnl0.Controls.Add(this.appointmentTxt0);
            this.dotorInfoPnl0.Location = new System.Drawing.Point(3, 3);
            this.dotorInfoPnl0.Name = "dotorInfoPnl0";
            this.dotorInfoPnl0.Size = new System.Drawing.Size(529, 27);
            this.dotorInfoPnl0.TabIndex = 25;
            // 
            // removeBtn0
            // 
            this.removeBtn0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.removeBtn0.Image = global::Cardiology.Properties.Resources.remove;
            this.removeBtn0.Location = new System.Drawing.Point(502, 2);
            this.removeBtn0.Margin = new System.Windows.Forms.Padding(0);
            this.removeBtn0.Name = "removeBtn0";
            this.removeBtn0.Size = new System.Drawing.Size(24, 23);
            this.removeBtn0.TabIndex = 37;
            this.removeBtn0.UseVisualStyleBackColor = true;
            this.removeBtn0.Visible = false;
            this.removeBtn0.Click += new System.EventHandler(this.removeBtn0_Click);
            // 
            // doctorWho0
            // 
            this.doctorWho0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doctorWho0.FormattingEnabled = true;
            this.doctorWho0.Location = new System.Drawing.Point(258, 3);
            this.doctorWho0.Name = "doctorWho0";
            this.doctorWho0.Size = new System.Drawing.Size(234, 21);
            this.doctorWho0.TabIndex = 4;
            // 
            // objectIdLbl0
            // 
            this.objectIdLbl0.AutoSize = true;
            this.objectIdLbl0.Location = new System.Drawing.Point(498, 8);
            this.objectIdLbl0.Name = "objectIdLbl0";
            this.objectIdLbl0.Size = new System.Drawing.Size(0, 13);
            this.objectIdLbl0.TabIndex = 3;
            this.objectIdLbl0.Visible = false;
            // 
            // consiliumMembersLbl
            // 
            this.consiliumMembersLbl.AutoSize = true;
            this.consiliumMembersLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.consiliumMembersLbl.Location = new System.Drawing.Point(15, 7);
            this.consiliumMembersLbl.Name = "consiliumMembersLbl";
            this.consiliumMembersLbl.Size = new System.Drawing.Size(219, 25);
            this.consiliumMembersLbl.TabIndex = 24;
            this.consiliumMembersLbl.Text = "Состав консилиума:";
            // 
            // dutyAdminTodayPnl
            // 
            this.dutyAdminTodayPnl.BackColor = System.Drawing.Color.DodgerBlue;
            this.dutyAdminTodayPnl.Controls.Add(this.dutyAdminLbl);
            this.dutyAdminTodayPnl.Controls.Add(this.adminTxt);
            this.dutyAdminTodayPnl.Location = new System.Drawing.Point(544, 1);
            this.dutyAdminTodayPnl.Name = "dutyAdminTodayPnl";
            this.dutyAdminTodayPnl.Size = new System.Drawing.Size(332, 241);
            this.dutyAdminTodayPnl.TabIndex = 28;
            // 
            // dutyAdminLbl
            // 
            this.dutyAdminLbl.AutoSize = true;
            this.dutyAdminLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dutyAdminLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dutyAdminLbl.Location = new System.Drawing.Point(20, 61);
            this.dutyAdminLbl.Name = "dutyAdminLbl";
            this.dutyAdminLbl.Size = new System.Drawing.Size(289, 50);
            this.dutyAdminLbl.TabIndex = 27;
            this.dutyAdminLbl.Text = "Дежурный администратор\r\n сегодня:";
            this.dutyAdminLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // goalContainer
            // 
            this.goalContainer.BackColor = System.Drawing.Color.PeachPuff;
            this.goalContainer.Controls.Add(this.goalTxt);
            this.goalContainer.Controls.Add(this.goalLbl);
            this.goalContainer.Location = new System.Drawing.Point(0, 242);
            this.goalContainer.Name = "goalContainer";
            this.goalContainer.Size = new System.Drawing.Size(876, 84);
            this.goalContainer.TabIndex = 30;
            // 
            // goalTxt
            // 
            this.goalTxt.Location = new System.Drawing.Point(9, 16);
            this.goalTxt.Name = "goalTxt";
            this.goalTxt.Size = new System.Drawing.Size(855, 58);
            this.goalTxt.TabIndex = 1;
            this.goalTxt.Text = "определить показания к оперативному пособию";
            // 
            // goalLbl
            // 
            this.goalLbl.AutoSize = true;
            this.goalLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.goalLbl.Location = new System.Drawing.Point(13, 0);
            this.goalLbl.Name = "goalLbl";
            this.goalLbl.Size = new System.Drawing.Size(116, 13);
            this.goalLbl.TabIndex = 0;
            this.goalLbl.Text = "Цель консилиума:";
            // 
            // dynamicsContainer
            // 
            this.dynamicsContainer.BackColor = System.Drawing.Color.LightSalmon;
            this.dynamicsContainer.Controls.Add(this.dynamicsTxt);
            this.dynamicsContainer.Controls.Add(this.dynamicsLbl);
            this.dynamicsContainer.Location = new System.Drawing.Point(0, 326);
            this.dynamicsContainer.Name = "dynamicsContainer";
            this.dynamicsContainer.Size = new System.Drawing.Size(876, 84);
            this.dynamicsContainer.TabIndex = 31;
            // 
            // dynamicsTxt
            // 
            this.dynamicsTxt.Location = new System.Drawing.Point(9, 16);
            this.dynamicsTxt.Name = "dynamicsTxt";
            this.dynamicsTxt.Size = new System.Drawing.Size(855, 58);
            this.dynamicsTxt.TabIndex = 1;
            this.dynamicsTxt.Text = resources.GetString("dynamicsTxt.Text");
            // 
            // dynamicsLbl
            // 
            this.dynamicsLbl.AutoSize = true;
            this.dynamicsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dynamicsLbl.Location = new System.Drawing.Point(13, 0);
            this.dynamicsLbl.Name = "dynamicsLbl";
            this.dynamicsLbl.Size = new System.Drawing.Size(149, 13);
            this.dynamicsLbl.TabIndex = 0;
            this.dynamicsLbl.Text = "Динамика в отделении:";
            // 
            // diagnosisContainer
            // 
            this.diagnosisContainer.BackColor = System.Drawing.Color.Salmon;
            this.diagnosisContainer.Controls.Add(this.diagnosisTxt1);
            this.diagnosisContainer.Controls.Add(this.diagnosisTxt0);
            this.diagnosisContainer.Controls.Add(this.diagnosisLbl);
            this.diagnosisContainer.Location = new System.Drawing.Point(0, 410);
            this.diagnosisContainer.Name = "diagnosisContainer";
            this.diagnosisContainer.Size = new System.Drawing.Size(876, 84);
            this.diagnosisContainer.TabIndex = 32;
            // 
            // diagnosisTxt1
            // 
            this.diagnosisTxt1.Location = new System.Drawing.Point(440, 16);
            this.diagnosisTxt1.Name = "diagnosisTxt1";
            this.diagnosisTxt1.Size = new System.Drawing.Size(424, 58);
            this.diagnosisTxt1.TabIndex = 2;
            this.diagnosisTxt1.Text = "";
            // 
            // diagnosisTxt0
            // 
            this.diagnosisTxt0.Location = new System.Drawing.Point(9, 16);
            this.diagnosisTxt0.Name = "diagnosisTxt0";
            this.diagnosisTxt0.Size = new System.Drawing.Size(425, 58);
            this.diagnosisTxt0.TabIndex = 1;
            this.diagnosisTxt0.Text = "";
            // 
            // diagnosisLbl
            // 
            this.diagnosisLbl.AutoSize = true;
            this.diagnosisLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.diagnosisLbl.Location = new System.Drawing.Point(13, 0);
            this.diagnosisLbl.Name = "diagnosisLbl";
            this.diagnosisLbl.Size = new System.Drawing.Size(62, 13);
            this.diagnosisLbl.TabIndex = 0;
            this.diagnosisLbl.Text = "Диагноз:";
            // 
            // decisionContainer
            // 
            this.decisionContainer.BackColor = System.Drawing.Color.PaleGreen;
            this.decisionContainer.Controls.Add(this.decisionVariantsPnl);
            this.decisionContainer.Controls.Add(this.decisionTxt);
            this.decisionContainer.Controls.Add(this.decisionLbl);
            this.decisionContainer.Location = new System.Drawing.Point(0, 494);
            this.decisionContainer.Name = "decisionContainer";
            this.decisionContainer.Size = new System.Drawing.Size(876, 100);
            this.decisionContainer.TabIndex = 33;
            // 
            // decisionVariantsPnl
            // 
            this.decisionVariantsPnl.Controls.Add(this.oksWithStBtn);
            this.decisionVariantsPnl.Controls.Add(this.oksDeclineBtn);
            this.decisionVariantsPnl.Controls.Add(this.oksAcceptBtn);
            this.decisionVariantsPnl.Controls.Add(this.kagBtn);
            this.decisionVariantsPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decisionVariantsPnl.Location = new System.Drawing.Point(653, 6);
            this.decisionVariantsPnl.Name = "decisionVariantsPnl";
            this.decisionVariantsPnl.Size = new System.Drawing.Size(211, 89);
            this.decisionVariantsPnl.TabIndex = 2;
            this.decisionVariantsPnl.TabStop = false;
            this.decisionVariantsPnl.Text = "Варианты решения консилиума";
            // 
            // oksWithStBtn
            // 
            this.oksWithStBtn.AutoSize = true;
            this.oksWithStBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oksWithStBtn.Location = new System.Drawing.Point(14, 69);
            this.oksWithStBtn.Name = "oksWithStBtn";
            this.oksWithStBtn.Size = new System.Drawing.Size(129, 17);
            this.oksWithStBtn.TabIndex = 3;
            this.oksWithStBtn.TabStop = true;
            this.oksWithStBtn.Text = "ОКС с подъемом ST";
            this.oksWithStBtn.UseVisualStyleBackColor = true;
            this.oksWithStBtn.CheckedChanged += new System.EventHandler(this.oksWithStBtn_CheckedChanged);
            // 
            // oksDeclineBtn
            // 
            this.oksDeclineBtn.AutoSize = true;
            this.oksDeclineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oksDeclineBtn.Location = new System.Drawing.Point(14, 51);
            this.oksDeclineBtn.Name = "oksDeclineBtn";
            this.oksDeclineBtn.Size = new System.Drawing.Size(117, 17);
            this.oksDeclineBtn.TabIndex = 2;
            this.oksDeclineBtn.TabStop = true;
            this.oksDeclineBtn.Text = "ОКС без ST отказ";
            this.oksDeclineBtn.UseVisualStyleBackColor = true;
            this.oksDeclineBtn.CheckedChanged += new System.EventHandler(this.oksDeclineBtn_CheckedChanged);
            // 
            // oksAcceptBtn
            // 
            this.oksAcceptBtn.AutoSize = true;
            this.oksAcceptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oksAcceptBtn.Location = new System.Drawing.Point(14, 33);
            this.oksAcceptBtn.Name = "oksAcceptBtn";
            this.oksAcceptBtn.Size = new System.Drawing.Size(135, 17);
            this.oksAcceptBtn.TabIndex = 1;
            this.oksAcceptBtn.TabStop = true;
            this.oksAcceptBtn.Text = "ОКС без ST согласен";
            this.oksAcceptBtn.UseVisualStyleBackColor = true;
            this.oksAcceptBtn.CheckedChanged += new System.EventHandler(this.oksAcceptBtn_CheckedChanged);
            // 
            // kagBtn
            // 
            this.kagBtn.AutoSize = true;
            this.kagBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kagBtn.Location = new System.Drawing.Point(14, 14);
            this.kagBtn.Name = "kagBtn";
            this.kagBtn.Size = new System.Drawing.Size(77, 17);
            this.kagBtn.TabIndex = 0;
            this.kagBtn.TabStop = true;
            this.kagBtn.Text = "КАГ квота";
            this.kagBtn.UseVisualStyleBackColor = true;
            this.kagBtn.CheckedChanged += new System.EventHandler(this.kagBtn_CheckedChanged);
            // 
            // decisionTxt
            // 
            this.decisionTxt.Location = new System.Drawing.Point(9, 16);
            this.decisionTxt.Name = "decisionTxt";
            this.decisionTxt.Size = new System.Drawing.Size(638, 73);
            this.decisionTxt.TabIndex = 1;
            this.decisionTxt.Text = "";
            // 
            // decisionLbl
            // 
            this.decisionLbl.AutoSize = true;
            this.decisionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decisionLbl.Location = new System.Drawing.Point(13, 0);
            this.decisionLbl.Name = "decisionLbl";
            this.decisionLbl.Size = new System.Drawing.Size(63, 13);
            this.decisionLbl.TabIndex = 0;
            this.decisionLbl.Text = "Решение:";
            // 
            // operationGoalPnl
            // 
            this.operationGoalPnl.Controls.Add(this.revaskularizationGoal);
            this.operationGoalPnl.Controls.Add(this.evaluationGoal);
            this.operationGoalPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationGoalPnl.Location = new System.Drawing.Point(0, 600);
            this.operationGoalPnl.Name = "operationGoalPnl";
            this.operationGoalPnl.Size = new System.Drawing.Size(647, 83);
            this.operationGoalPnl.TabIndex = 34;
            this.operationGoalPnl.TabStop = false;
            this.operationGoalPnl.Text = "Цель оперативного пособия";
            // 
            // revaskularizationGoal
            // 
            this.revaskularizationGoal.AutoSize = true;
            this.revaskularizationGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.revaskularizationGoal.Location = new System.Drawing.Point(13, 49);
            this.revaskularizationGoal.Name = "revaskularizationGoal";
            this.revaskularizationGoal.Size = new System.Drawing.Size(174, 17);
            this.revaskularizationGoal.TabIndex = 1;
            this.revaskularizationGoal.TabStop = true;
            this.revaskularizationGoal.Text = "Реваскуляризация миокарда";
            this.revaskularizationGoal.UseVisualStyleBackColor = true;
            this.revaskularizationGoal.CheckedChanged += new System.EventHandler(this.revaskularizationGoal_CheckedChanged);
            // 
            // evaluationGoal
            // 
            this.evaluationGoal.AutoSize = true;
            this.evaluationGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.evaluationGoal.Location = new System.Drawing.Point(13, 26);
            this.evaluationGoal.Name = "evaluationGoal";
            this.evaluationGoal.Size = new System.Drawing.Size(599, 17);
            this.evaluationGoal.TabIndex = 0;
            this.evaluationGoal.TabStop = true;
            this.evaluationGoal.Text = "Оценка коронарного кровотока с последующим решением о необходимости эндоваскулярн" +
    "ого вмешательства.";
            this.evaluationGoal.UseVisualStyleBackColor = true;
            this.evaluationGoal.CheckedChanged += new System.EventHandler(this.evaluationGoal_CheckedChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(679, 631);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(164, 23);
            this.saveBtn.TabIndex = 35;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(679, 660);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(164, 23);
            this.printBtn.TabIndex = 36;
            this.printBtn.Text = "Открыть MSWord";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // Consilium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 692);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.operationGoalPnl);
            this.Controls.Add(this.decisionContainer);
            this.Controls.Add(this.diagnosisContainer);
            this.Controls.Add(this.dynamicsContainer);
            this.Controls.Add(this.goalContainer);
            this.Controls.Add(this.dutyAdminTodayPnl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Consilium";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Консилиум";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.allDoctorsPnl.ResumeLayout(false);
            this.allDoctorsPnl.PerformLayout();
            this.doctorsContainer.ResumeLayout(false);
            this.dotorInfoPnl0.ResumeLayout(false);
            this.dotorInfoPnl0.PerformLayout();
            this.dutyAdminTodayPnl.ResumeLayout(false);
            this.dutyAdminTodayPnl.PerformLayout();
            this.goalContainer.ResumeLayout(false);
            this.goalContainer.PerformLayout();
            this.dynamicsContainer.ResumeLayout(false);
            this.dynamicsContainer.PerformLayout();
            this.diagnosisContainer.ResumeLayout(false);
            this.diagnosisContainer.PerformLayout();
            this.decisionContainer.ResumeLayout(false);
            this.decisionContainer.PerformLayout();
            this.decisionVariantsPnl.ResumeLayout(false);
            this.decisionVariantsPnl.PerformLayout();
            this.operationGoalPnl.ResumeLayout(false);
            this.operationGoalPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox appointmentTxt0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox adminTxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label consiliumMembersLbl;
        private System.Windows.Forms.Panel dutyAdminTodayPnl;
        private System.Windows.Forms.Label dutyAdminLbl;
        private System.Windows.Forms.Panel goalContainer;
        private System.Windows.Forms.RichTextBox goalTxt;
        private System.Windows.Forms.Label goalLbl;
        private System.Windows.Forms.Panel dynamicsContainer;
        private System.Windows.Forms.RichTextBox dynamicsTxt;
        private System.Windows.Forms.Label dynamicsLbl;
        private System.Windows.Forms.Panel diagnosisContainer;
        private System.Windows.Forms.RichTextBox diagnosisTxt1;
        private System.Windows.Forms.RichTextBox diagnosisTxt0;
        private System.Windows.Forms.Label diagnosisLbl;
        private System.Windows.Forms.Panel decisionContainer;
        private System.Windows.Forms.GroupBox decisionVariantsPnl;
        private System.Windows.Forms.RadioButton oksDeclineBtn;
        private System.Windows.Forms.RadioButton oksAcceptBtn;
        private System.Windows.Forms.RadioButton kagBtn;
        private System.Windows.Forms.RichTextBox decisionTxt;
        private System.Windows.Forms.Label decisionLbl;
        private System.Windows.Forms.GroupBox operationGoalPnl;
        private System.Windows.Forms.RadioButton revaskularizationGoal;
        private System.Windows.Forms.RadioButton evaluationGoal;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Panel dotorInfoPnl0;
        private System.Windows.Forms.TableLayoutPanel doctorsContainer;
        private System.Windows.Forms.Button addDoctor;
        private System.Windows.Forms.Panel allDoctorsPnl;
        private System.Windows.Forms.Label objectIdLbl0;
        private System.Windows.Forms.ComboBox doctorWho0;
        private System.Windows.Forms.RadioButton oksWithStBtn;
        private System.Windows.Forms.Button removeBtn0;
    }
}