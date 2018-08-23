namespace Cardiology
{
    partial class JournalBeforeKag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JournalBeforeKag));
            this.journalAllPnl = new System.Windows.Forms.GroupBox();
            this.journalGrouppedPanel = new System.Windows.Forms.Panel();
            this.journalContainer = new System.Windows.Forms.TableLayoutPanel();
            this.journalPnl0 = new System.Windows.Forms.Panel();
            this.complaintsTxt0 = new System.Windows.Forms.TextBox();
            this.complaintsLbl0 = new System.Windows.Forms.Label();
            this.objectId0 = new System.Windows.Forms.Label();
            this.startDateTxt0 = new System.Windows.Forms.DateTimePicker();
            this.monitorLbl0 = new System.Windows.Forms.Label();
            this.addDayCb0 = new System.Windows.Forms.CheckBox();
            this.adLbl0 = new System.Windows.Forms.Label();
            this.startTimeTxt0 = new System.Windows.Forms.DateTimePicker();
            this.psLbl0 = new System.Windows.Forms.Label();
            this.goodRhytmBtn0 = new System.Windows.Forms.RadioButton();
            this.chssLbl0 = new System.Windows.Forms.Label();
            this.badRhytmBtn0 = new System.Windows.Forms.RadioButton();
            this.chddLbl0 = new System.Windows.Forms.Label();
            this.hideJournalBtn0 = new System.Windows.Forms.CheckBox();
            this.journalTxt0 = new System.Windows.Forms.RichTextBox();
            this.monitorTxt0 = new System.Windows.Forms.TextBox();
            this.adTxt0 = new System.Windows.Forms.ComboBox();
            this.chddTxt0 = new System.Windows.Forms.ComboBox();
            this.psTxt0 = new System.Windows.Forms.ComboBox();
            this.chssTxt0 = new System.Windows.Forms.ComboBox();
            this.deffedredAllPnl = new System.Windows.Forms.GroupBox();
            this.defferedGrouppedPanel = new System.Windows.Forms.Panel();
            this.deferredContainer = new System.Windows.Forms.TableLayoutPanel();
            this.deferredPnl0 = new System.Windows.Forms.Panel();
            this.deferredStartTime0 = new System.Windows.Forms.DateTimePicker();
            this.hideDefferedCb0 = new System.Windows.Forms.CheckBox();
            this.deferredAdLbl0 = new System.Windows.Forms.Label();
            this.deferredMonitorLbl0 = new System.Windows.Forms.Label();
            this.deferredPsLbl0 = new System.Windows.Forms.Label();
            this.deferredMonitorTxt0 = new System.Windows.Forms.TextBox();
            this.deferredChssLbl0 = new System.Windows.Forms.Label();
            this.defferedChddTxt0 = new System.Windows.Forms.ComboBox();
            this.deferredChddLbl0 = new System.Windows.Forms.Label();
            this.deferredChssTxt0 = new System.Windows.Forms.ComboBox();
            this.deferredJournalTxt0 = new System.Windows.Forms.RichTextBox();
            this.deferredPsTxt0 = new System.Windows.Forms.ComboBox();
            this.deferredAdTxt0 = new System.Windows.Forms.ComboBox();
            this.deferredStartDateTxt = new System.Windows.Forms.DateTimePicker();
            this.addDefferedDayCb = new System.Windows.Forms.CheckBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.addJournalBtn = new System.Windows.Forms.Button();
            this.addDefferedBtn = new System.Windows.Forms.Button();
            this.journalAllPnl.SuspendLayout();
            this.journalGrouppedPanel.SuspendLayout();
            this.journalContainer.SuspendLayout();
            this.journalPnl0.SuspendLayout();
            this.deffedredAllPnl.SuspendLayout();
            this.defferedGrouppedPanel.SuspendLayout();
            this.deferredContainer.SuspendLayout();
            this.deferredPnl0.SuspendLayout();
            this.SuspendLayout();
            // 
            // journalAllPnl
            // 
            this.journalAllPnl.Controls.Add(this.journalGrouppedPanel);
            this.journalAllPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.journalAllPnl.Location = new System.Drawing.Point(12, 12);
            this.journalAllPnl.Name = "journalAllPnl";
            this.journalAllPnl.Size = new System.Drawing.Size(855, 285);
            this.journalAllPnl.TabIndex = 0;
            this.journalAllPnl.TabStop = false;
            this.journalAllPnl.Text = "Дневник (через 1 час с момента поступления пациента)";
            // 
            // journalGrouppedPanel
            // 
            this.journalGrouppedPanel.AutoScroll = true;
            this.journalGrouppedPanel.Controls.Add(this.journalContainer);
            this.journalGrouppedPanel.Location = new System.Drawing.Point(4, 16);
            this.journalGrouppedPanel.Name = "journalGrouppedPanel";
            this.journalGrouppedPanel.Size = new System.Drawing.Size(835, 264);
            this.journalGrouppedPanel.TabIndex = 38;
            // 
            // journalContainer
            // 
            this.journalContainer.AutoSize = true;
            this.journalContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.journalContainer.ColumnCount = 1;
            this.journalContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.journalContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.journalContainer.Controls.Add(this.journalPnl0, 0, 0);
            this.journalContainer.Location = new System.Drawing.Point(6, 6);
            this.journalContainer.Name = "journalContainer";
            this.journalContainer.RowCount = 1;
            this.journalContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.journalContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.journalContainer.Size = new System.Drawing.Size(805, 189);
            this.journalContainer.TabIndex = 37;
            // 
            // journalPnl0
            // 
            this.journalPnl0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.journalPnl0.Controls.Add(this.complaintsTxt0);
            this.journalPnl0.Controls.Add(this.complaintsLbl0);
            this.journalPnl0.Controls.Add(this.objectId0);
            this.journalPnl0.Controls.Add(this.startDateTxt0);
            this.journalPnl0.Controls.Add(this.monitorLbl0);
            this.journalPnl0.Controls.Add(this.addDayCb0);
            this.journalPnl0.Controls.Add(this.adLbl0);
            this.journalPnl0.Controls.Add(this.startTimeTxt0);
            this.journalPnl0.Controls.Add(this.psLbl0);
            this.journalPnl0.Controls.Add(this.goodRhytmBtn0);
            this.journalPnl0.Controls.Add(this.chssLbl0);
            this.journalPnl0.Controls.Add(this.badRhytmBtn0);
            this.journalPnl0.Controls.Add(this.chddLbl0);
            this.journalPnl0.Controls.Add(this.hideJournalBtn0);
            this.journalPnl0.Controls.Add(this.journalTxt0);
            this.journalPnl0.Controls.Add(this.monitorTxt0);
            this.journalPnl0.Controls.Add(this.adTxt0);
            this.journalPnl0.Controls.Add(this.chddTxt0);
            this.journalPnl0.Controls.Add(this.psTxt0);
            this.journalPnl0.Controls.Add(this.chssTxt0);
            this.journalPnl0.Location = new System.Drawing.Point(3, 3);
            this.journalPnl0.Name = "journalPnl0";
            this.journalPnl0.Size = new System.Drawing.Size(799, 183);
            this.journalPnl0.TabIndex = 36;
            // 
            // complaintsTxt0
            // 
            this.complaintsTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.complaintsTxt0.Location = new System.Drawing.Point(324, 3);
            this.complaintsTxt0.Name = "complaintsTxt0";
            this.complaintsTxt0.Size = new System.Drawing.Size(464, 20);
            this.complaintsTxt0.TabIndex = 44;
            // 
            // complaintsLbl0
            // 
            this.complaintsLbl0.AutoSize = true;
            this.complaintsLbl0.Location = new System.Drawing.Point(262, 6);
            this.complaintsLbl0.Name = "complaintsLbl0";
            this.complaintsLbl0.Size = new System.Drawing.Size(60, 13);
            this.complaintsLbl0.TabIndex = 43;
            this.complaintsLbl0.Text = "Жалобы:";
            // 
            // objectId0
            // 
            this.objectId0.AutoSize = true;
            this.objectId0.Location = new System.Drawing.Point(755, 112);
            this.objectId0.Name = "objectId0";
            this.objectId0.Size = new System.Drawing.Size(0, 13);
            this.objectId0.TabIndex = 36;
            this.objectId0.Visible = false;
            // 
            // startDateTxt0
            // 
            this.startDateTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startDateTxt0.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTxt0.Location = new System.Drawing.Point(4, 6);
            this.startDateTxt0.Name = "startDateTxt0";
            this.startDateTxt0.Size = new System.Drawing.Size(100, 20);
            this.startDateTxt0.TabIndex = 35;
            // 
            // monitorLbl0
            // 
            this.monitorLbl0.AutoSize = true;
            this.monitorLbl0.Location = new System.Drawing.Point(131, 134);
            this.monitorLbl0.Name = "monitorLbl0";
            this.monitorLbl0.Size = new System.Drawing.Size(62, 13);
            this.monitorLbl0.TabIndex = 6;
            this.monitorLbl0.Text = "Монитор:";
            // 
            // addDayCb0
            // 
            this.addDayCb0.AutoSize = true;
            this.addDayCb0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addDayCb0.Location = new System.Drawing.Point(107, 9);
            this.addDayCb0.Name = "addDayCb0";
            this.addDayCb0.Size = new System.Drawing.Size(59, 17);
            this.addDayCb0.TabIndex = 1;
            this.addDayCb0.Text = "+ день";
            this.addDayCb0.UseVisualStyleBackColor = true;
            // 
            // adLbl0
            // 
            this.adLbl0.AutoSize = true;
            this.adLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adLbl0.Location = new System.Drawing.Point(165, 112);
            this.adLbl0.Name = "adLbl0";
            this.adLbl0.Size = new System.Drawing.Size(26, 13);
            this.adLbl0.TabIndex = 19;
            this.adLbl0.Text = "АД:";
            // 
            // startTimeTxt0
            // 
            this.startTimeTxt0.CustomFormat = "HH:mm tt";
            this.startTimeTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startTimeTxt0.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimeTxt0.Location = new System.Drawing.Point(4, 29);
            this.startTimeTxt0.Name = "startTimeTxt0";
            this.startTimeTxt0.ShowUpDown = true;
            this.startTimeTxt0.Size = new System.Drawing.Size(100, 20);
            this.startTimeTxt0.TabIndex = 2;
            // 
            // psLbl0
            // 
            this.psLbl0.AutoSize = true;
            this.psLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.psLbl0.Location = new System.Drawing.Point(169, 86);
            this.psLbl0.Name = "psLbl0";
            this.psLbl0.Size = new System.Drawing.Size(22, 13);
            this.psLbl0.TabIndex = 18;
            this.psLbl0.Text = "Ps:";
            // 
            // goodRhytmBtn0
            // 
            this.goodRhytmBtn0.AutoSize = true;
            this.goodRhytmBtn0.Location = new System.Drawing.Point(4, 55);
            this.goodRhytmBtn0.Name = "goodRhytmBtn0";
            this.goodRhytmBtn0.Size = new System.Drawing.Size(131, 17);
            this.goodRhytmBtn0.TabIndex = 3;
            this.goodRhytmBtn0.TabStop = true;
            this.goodRhytmBtn0.Text = "Ритм правильный";
            this.goodRhytmBtn0.UseVisualStyleBackColor = true;
            // 
            // chssLbl0
            // 
            this.chssLbl0.AutoSize = true;
            this.chssLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chssLbl0.Location = new System.Drawing.Point(163, 62);
            this.chssLbl0.Name = "chssLbl0";
            this.chssLbl0.Size = new System.Drawing.Size(32, 13);
            this.chssLbl0.TabIndex = 17;
            this.chssLbl0.Text = "ЧСС:";
            // 
            // badRhytmBtn0
            // 
            this.badRhytmBtn0.AutoSize = true;
            this.badRhytmBtn0.Location = new System.Drawing.Point(3, 79);
            this.badRhytmBtn0.Name = "badRhytmBtn0";
            this.badRhytmBtn0.Size = new System.Drawing.Size(145, 17);
            this.badRhytmBtn0.TabIndex = 4;
            this.badRhytmBtn0.TabStop = true;
            this.badRhytmBtn0.Text = "Ритм неправильный";
            this.badRhytmBtn0.UseVisualStyleBackColor = true;
            // 
            // chddLbl0
            // 
            this.chddLbl0.AutoSize = true;
            this.chddLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chddLbl0.Location = new System.Drawing.Point(159, 38);
            this.chddLbl0.Name = "chddLbl0";
            this.chddLbl0.Size = new System.Drawing.Size(36, 13);
            this.chddLbl0.TabIndex = 16;
            this.chddLbl0.Text = "ЧДД:";
            // 
            // hideJournalBtn0
            // 
            this.hideJournalBtn0.AutoSize = true;
            this.hideJournalBtn0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hideJournalBtn0.Location = new System.Drawing.Point(324, 157);
            this.hideJournalBtn0.Name = "hideJournalBtn0";
            this.hideJournalBtn0.Size = new System.Drawing.Size(109, 17);
            this.hideJournalBtn0.TabIndex = 5;
            this.hideJournalBtn0.Text = "Скрыть дневник";
            this.hideJournalBtn0.UseVisualStyleBackColor = true;
            // 
            // journalTxt0
            // 
            this.journalTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.journalTxt0.Location = new System.Drawing.Point(324, 32);
            this.journalTxt0.Name = "journalTxt0";
            this.journalTxt0.Size = new System.Drawing.Size(464, 119);
            this.journalTxt0.TabIndex = 15;
            this.journalTxt0.Text = "";
            // 
            // monitorTxt0
            // 
            this.monitorTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monitorTxt0.Location = new System.Drawing.Point(197, 131);
            this.monitorTxt0.Name = "monitorTxt0";
            this.monitorTxt0.Size = new System.Drawing.Size(121, 20);
            this.monitorTxt0.TabIndex = 7;
            // 
            // adTxt0
            // 
            this.adTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adTxt0.FormattingEnabled = true;
            this.adTxt0.Items.AddRange(new object[] {
            "40/0",
            "50/10",
            "60/20",
            "70/30",
            "80/40",
            "90/50",
            "100/60",
            "110/70",
            "120/80",
            "130/90",
            "140/100",
            "150/110"});
            this.adTxt0.Location = new System.Drawing.Point(197, 104);
            this.adTxt0.Name = "adTxt0";
            this.adTxt0.Size = new System.Drawing.Size(121, 21);
            this.adTxt0.TabIndex = 14;
            // 
            // chddTxt0
            // 
            this.chddTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chddTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chddTxt0.FormattingEnabled = true;
            this.chddTxt0.Location = new System.Drawing.Point(197, 32);
            this.chddTxt0.Name = "chddTxt0";
            this.chddTxt0.Size = new System.Drawing.Size(121, 21);
            this.chddTxt0.TabIndex = 11;
            // 
            // psTxt0
            // 
            this.psTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.psTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.psTxt0.FormattingEnabled = true;
            this.psTxt0.Location = new System.Drawing.Point(197, 80);
            this.psTxt0.Name = "psTxt0";
            this.psTxt0.Size = new System.Drawing.Size(121, 21);
            this.psTxt0.TabIndex = 13;
            // 
            // chssTxt0
            // 
            this.chssTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chssTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chssTxt0.FormattingEnabled = true;
            this.chssTxt0.Location = new System.Drawing.Point(197, 56);
            this.chssTxt0.Name = "chssTxt0";
            this.chssTxt0.Size = new System.Drawing.Size(121, 21);
            this.chssTxt0.TabIndex = 12;
            // 
            // deffedredAllPnl
            // 
            this.deffedredAllPnl.Controls.Add(this.defferedGrouppedPanel);
            this.deffedredAllPnl.Controls.Add(this.deferredStartDateTxt);
            this.deffedredAllPnl.Controls.Add(this.addDefferedDayCb);
            this.deffedredAllPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deffedredAllPnl.Location = new System.Drawing.Point(12, 303);
            this.deffedredAllPnl.Name = "deffedredAllPnl";
            this.deffedredAllPnl.Size = new System.Drawing.Size(855, 289);
            this.deffedredAllPnl.TabIndex = 1;
            this.deffedredAllPnl.TabStop = false;
            this.deffedredAllPnl.Text = "Обоснование\"отложенной коронароангиографии\"";
            // 
            // defferedGrouppedPanel
            // 
            this.defferedGrouppedPanel.AutoScroll = true;
            this.defferedGrouppedPanel.Controls.Add(this.deferredContainer);
            this.defferedGrouppedPanel.Location = new System.Drawing.Point(147, 21);
            this.defferedGrouppedPanel.Name = "defferedGrouppedPanel";
            this.defferedGrouppedPanel.Size = new System.Drawing.Size(692, 260);
            this.defferedGrouppedPanel.TabIndex = 42;
            // 
            // deferredContainer
            // 
            this.deferredContainer.AutoSize = true;
            this.deferredContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deferredContainer.ColumnCount = 1;
            this.deferredContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.deferredContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.deferredContainer.Controls.Add(this.deferredPnl0, 0, 0);
            this.deferredContainer.Location = new System.Drawing.Point(4, 3);
            this.deferredContainer.Name = "deferredContainer";
            this.deferredContainer.RowCount = 1;
            this.deferredContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.deferredContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.deferredContainer.Size = new System.Drawing.Size(671, 152);
            this.deferredContainer.TabIndex = 41;
            // 
            // deferredPnl0
            // 
            this.deferredPnl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deferredPnl0.Controls.Add(this.deferredStartTime0);
            this.deferredPnl0.Controls.Add(this.hideDefferedCb0);
            this.deferredPnl0.Controls.Add(this.deferredAdLbl0);
            this.deferredPnl0.Controls.Add(this.deferredMonitorLbl0);
            this.deferredPnl0.Controls.Add(this.deferredPsLbl0);
            this.deferredPnl0.Controls.Add(this.deferredMonitorTxt0);
            this.deferredPnl0.Controls.Add(this.deferredChssLbl0);
            this.deferredPnl0.Controls.Add(this.defferedChddTxt0);
            this.deferredPnl0.Controls.Add(this.deferredChddLbl0);
            this.deferredPnl0.Controls.Add(this.deferredChssTxt0);
            this.deferredPnl0.Controls.Add(this.deferredJournalTxt0);
            this.deferredPnl0.Controls.Add(this.deferredPsTxt0);
            this.deferredPnl0.Controls.Add(this.deferredAdTxt0);
            this.deferredPnl0.Location = new System.Drawing.Point(3, 3);
            this.deferredPnl0.Name = "deferredPnl0";
            this.deferredPnl0.Size = new System.Drawing.Size(665, 146);
            this.deferredPnl0.TabIndex = 21;
            // 
            // deferredStartTime0
            // 
            this.deferredStartTime0.CustomFormat = "HH:mm tt";
            this.deferredStartTime0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredStartTime0.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.deferredStartTime0.Location = new System.Drawing.Point(91, 3);
            this.deferredStartTime0.Name = "deferredStartTime0";
            this.deferredStartTime0.ShowUpDown = true;
            this.deferredStartTime0.Size = new System.Drawing.Size(121, 20);
            this.deferredStartTime0.TabIndex = 2;
            // 
            // hideDefferedCb0
            // 
            this.hideDefferedCb0.AutoSize = true;
            this.hideDefferedCb0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hideDefferedCb0.Location = new System.Drawing.Point(218, 124);
            this.hideDefferedCb0.Name = "hideDefferedCb0";
            this.hideDefferedCb0.Size = new System.Drawing.Size(109, 17);
            this.hideDefferedCb0.TabIndex = 5;
            this.hideDefferedCb0.Text = "Скрыть дневник";
            this.hideDefferedCb0.UseVisualStyleBackColor = true;
            // 
            // deferredAdLbl0
            // 
            this.deferredAdLbl0.AutoSize = true;
            this.deferredAdLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredAdLbl0.Location = new System.Drawing.Point(59, 105);
            this.deferredAdLbl0.Name = "deferredAdLbl0";
            this.deferredAdLbl0.Size = new System.Drawing.Size(26, 13);
            this.deferredAdLbl0.TabIndex = 19;
            this.deferredAdLbl0.Text = "АД:";
            // 
            // deferredMonitorLbl0
            // 
            this.deferredMonitorLbl0.AutoSize = true;
            this.deferredMonitorLbl0.Location = new System.Drawing.Point(23, 125);
            this.deferredMonitorLbl0.Name = "deferredMonitorLbl0";
            this.deferredMonitorLbl0.Size = new System.Drawing.Size(62, 13);
            this.deferredMonitorLbl0.TabIndex = 6;
            this.deferredMonitorLbl0.Text = "Монитор:";
            // 
            // deferredPsLbl0
            // 
            this.deferredPsLbl0.AutoSize = true;
            this.deferredPsLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredPsLbl0.Location = new System.Drawing.Point(63, 79);
            this.deferredPsLbl0.Name = "deferredPsLbl0";
            this.deferredPsLbl0.Size = new System.Drawing.Size(22, 13);
            this.deferredPsLbl0.TabIndex = 18;
            this.deferredPsLbl0.Text = "Ps:";
            // 
            // deferredMonitorTxt0
            // 
            this.deferredMonitorTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredMonitorTxt0.Location = new System.Drawing.Point(91, 121);
            this.deferredMonitorTxt0.Name = "deferredMonitorTxt0";
            this.deferredMonitorTxt0.Size = new System.Drawing.Size(121, 20);
            this.deferredMonitorTxt0.TabIndex = 7;
            // 
            // deferredChssLbl0
            // 
            this.deferredChssLbl0.AutoSize = true;
            this.deferredChssLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredChssLbl0.Location = new System.Drawing.Point(57, 55);
            this.deferredChssLbl0.Name = "deferredChssLbl0";
            this.deferredChssLbl0.Size = new System.Drawing.Size(32, 13);
            this.deferredChssLbl0.TabIndex = 17;
            this.deferredChssLbl0.Text = "ЧСС:";
            // 
            // defferedChddTxt0
            // 
            this.defferedChddTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defferedChddTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.defferedChddTxt0.FormattingEnabled = true;
            this.defferedChddTxt0.Location = new System.Drawing.Point(91, 25);
            this.defferedChddTxt0.Name = "defferedChddTxt0";
            this.defferedChddTxt0.Size = new System.Drawing.Size(121, 21);
            this.defferedChddTxt0.TabIndex = 11;
            // 
            // deferredChddLbl0
            // 
            this.deferredChddLbl0.AutoSize = true;
            this.deferredChddLbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredChddLbl0.Location = new System.Drawing.Point(53, 31);
            this.deferredChddLbl0.Name = "deferredChddLbl0";
            this.deferredChddLbl0.Size = new System.Drawing.Size(36, 13);
            this.deferredChddLbl0.TabIndex = 16;
            this.deferredChddLbl0.Text = "ЧДД:";
            // 
            // deferredChssTxt0
            // 
            this.deferredChssTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deferredChssTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredChssTxt0.FormattingEnabled = true;
            this.deferredChssTxt0.Location = new System.Drawing.Point(91, 49);
            this.deferredChssTxt0.Name = "deferredChssTxt0";
            this.deferredChssTxt0.Size = new System.Drawing.Size(121, 21);
            this.deferredChssTxt0.TabIndex = 12;
            // 
            // deferredJournalTxt0
            // 
            this.deferredJournalTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredJournalTxt0.Location = new System.Drawing.Point(218, 3);
            this.deferredJournalTxt0.Name = "deferredJournalTxt0";
            this.deferredJournalTxt0.Size = new System.Drawing.Size(442, 112);
            this.deferredJournalTxt0.TabIndex = 15;
            this.deferredJournalTxt0.Text = "";
            // 
            // deferredPsTxt0
            // 
            this.deferredPsTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deferredPsTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredPsTxt0.FormattingEnabled = true;
            this.deferredPsTxt0.Location = new System.Drawing.Point(91, 73);
            this.deferredPsTxt0.Name = "deferredPsTxt0";
            this.deferredPsTxt0.Size = new System.Drawing.Size(121, 21);
            this.deferredPsTxt0.TabIndex = 13;
            // 
            // deferredAdTxt0
            // 
            this.deferredAdTxt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deferredAdTxt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredAdTxt0.FormattingEnabled = true;
            this.deferredAdTxt0.Items.AddRange(new object[] {
            "40/0",
            "50/10",
            "60/20",
            "70/30",
            "80/40",
            "90/50",
            "100/60",
            "110/70",
            "120/80",
            "130/90",
            "140/100",
            "150/110"});
            this.deferredAdTxt0.Location = new System.Drawing.Point(91, 97);
            this.deferredAdTxt0.Name = "deferredAdTxt0";
            this.deferredAdTxt0.Size = new System.Drawing.Size(121, 21);
            this.deferredAdTxt0.TabIndex = 14;
            // 
            // deferredStartDateTxt
            // 
            this.deferredStartDateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deferredStartDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.deferredStartDateTxt.Location = new System.Drawing.Point(10, 21);
            this.deferredStartDateTxt.Name = "deferredStartDateTxt";
            this.deferredStartDateTxt.Size = new System.Drawing.Size(131, 20);
            this.deferredStartDateTxt.TabIndex = 20;
            // 
            // addDefferedDayCb
            // 
            this.addDefferedDayCb.AutoSize = true;
            this.addDefferedDayCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addDefferedDayCb.Location = new System.Drawing.Point(82, 47);
            this.addDefferedDayCb.Name = "addDefferedDayCb";
            this.addDefferedDayCb.Size = new System.Drawing.Size(59, 17);
            this.addDefferedDayCb.TabIndex = 1;
            this.addDefferedDayCb.Text = "+ день";
            this.addDefferedDayCb.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(792, 598);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(711, 598);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "MsWord";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // addJournalBtn
            // 
            this.addJournalBtn.Image = global::Cardiology.Properties.Resources.addd1;
            this.addJournalBtn.Location = new System.Drawing.Point(873, 35);
            this.addJournalBtn.Name = "addJournalBtn";
            this.addJournalBtn.Size = new System.Drawing.Size(30, 28);
            this.addJournalBtn.TabIndex = 38;
            this.addJournalBtn.UseVisualStyleBackColor = true;
            this.addJournalBtn.Click += new System.EventHandler(this.addJournalBtn_Click);
            // 
            // addDefferedBtn
            // 
            this.addDefferedBtn.Image = global::Cardiology.Properties.Resources.addd1;
            this.addDefferedBtn.Location = new System.Drawing.Point(873, 312);
            this.addDefferedBtn.Name = "addDefferedBtn";
            this.addDefferedBtn.Size = new System.Drawing.Size(30, 28);
            this.addDefferedBtn.TabIndex = 39;
            this.addDefferedBtn.UseVisualStyleBackColor = true;
            this.addDefferedBtn.Click += new System.EventHandler(this.addDefferedBtn_Click);
            // 
            // JournalBeforeKag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 631);
            this.Controls.Add(this.addDefferedBtn);
            this.Controls.Add(this.addJournalBtn);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.deffedredAllPnl);
            this.Controls.Add(this.journalAllPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JournalBeforeKag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дневники";
            this.journalAllPnl.ResumeLayout(false);
            this.journalGrouppedPanel.ResumeLayout(false);
            this.journalGrouppedPanel.PerformLayout();
            this.journalContainer.ResumeLayout(false);
            this.journalPnl0.ResumeLayout(false);
            this.journalPnl0.PerformLayout();
            this.deffedredAllPnl.ResumeLayout(false);
            this.deffedredAllPnl.PerformLayout();
            this.defferedGrouppedPanel.ResumeLayout(false);
            this.defferedGrouppedPanel.PerformLayout();
            this.deferredContainer.ResumeLayout(false);
            this.deferredPnl0.ResumeLayout(false);
            this.deferredPnl0.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox journalAllPnl;
        private System.Windows.Forms.Label adLbl0;
        private System.Windows.Forms.Label psLbl0;
        private System.Windows.Forms.Label chssLbl0;
        private System.Windows.Forms.Label chddLbl0;
        private System.Windows.Forms.RichTextBox journalTxt0;
        private System.Windows.Forms.ComboBox adTxt0;
        private System.Windows.Forms.ComboBox psTxt0;
        private System.Windows.Forms.ComboBox chssTxt0;
        private System.Windows.Forms.ComboBox chddTxt0;
        private System.Windows.Forms.TextBox monitorTxt0;
        private System.Windows.Forms.Label monitorLbl0;
        private System.Windows.Forms.CheckBox hideJournalBtn0;
        private System.Windows.Forms.RadioButton badRhytmBtn0;
        private System.Windows.Forms.RadioButton goodRhytmBtn0;
        private System.Windows.Forms.DateTimePicker startTimeTxt0;
        private System.Windows.Forms.CheckBox addDayCb0;
        private System.Windows.Forms.GroupBox deffedredAllPnl;
        private System.Windows.Forms.Label deferredAdLbl0;
        private System.Windows.Forms.Label deferredPsLbl0;
        private System.Windows.Forms.Label deferredChssLbl0;
        private System.Windows.Forms.Label deferredChddLbl0;
        private System.Windows.Forms.RichTextBox deferredJournalTxt0;
        private System.Windows.Forms.ComboBox deferredAdTxt0;
        private System.Windows.Forms.ComboBox deferredPsTxt0;
        private System.Windows.Forms.ComboBox deferredChssTxt0;
        private System.Windows.Forms.ComboBox defferedChddTxt0;
        private System.Windows.Forms.TextBox deferredMonitorTxt0;
        private System.Windows.Forms.Label deferredMonitorLbl0;
        private System.Windows.Forms.CheckBox hideDefferedCb0;
        private System.Windows.Forms.DateTimePicker deferredStartTime0;
        private System.Windows.Forms.CheckBox addDefferedDayCb;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.TableLayoutPanel journalContainer;
        private System.Windows.Forms.Panel journalPnl0;
        private System.Windows.Forms.DateTimePicker startDateTxt0;
        private System.Windows.Forms.TableLayoutPanel deferredContainer;
        private System.Windows.Forms.Panel deferredPnl0;
        private System.Windows.Forms.DateTimePicker deferredStartDateTxt;
        private System.Windows.Forms.Button addJournalBtn;
        private System.Windows.Forms.Button addDefferedBtn;
        private System.Windows.Forms.Panel journalGrouppedPanel;
        private System.Windows.Forms.Panel defferedGrouppedPanel;
        private System.Windows.Forms.Label objectId0;
        private System.Windows.Forms.TextBox complaintsTxt0;
        private System.Windows.Forms.Label complaintsLbl0;
    }
}