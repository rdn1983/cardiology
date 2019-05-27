using Cardiology.UI.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace Cardiology.UI.Forms
{
    partial class JournalAfterKAG
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JournalAfterKAG));
            this.afterKagDiagnosisPnl = new System.Windows.Forms.GroupBox();
            this.wrongDateWarning = new System.Windows.Forms.Label();
            this.removeKAG = new System.Windows.Forms.Button();
            this.selectKAGBtn = new System.Windows.Forms.Button();
            this.kagDianosisLbl = new System.Windows.Forms.Label();
            this.kagDiagnosisTxt = new System.Windows.Forms.RichTextBox();
            this.admissionDateTxt = new System.Windows.Forms.DateTimePicker();
            this.admissionTimeTxt = new System.Windows.Forms.DateTimePicker();
            this.afterKagDiagnosisTxt = new System.Windows.Forms.RichTextBox();
            this.journalDocLbl = new System.Windows.Forms.Label();
            this.journalDocBox = new System.Windows.Forms.ComboBox();
            this.surgeryInspectationPnl = new System.Windows.Forms.GroupBox();
            this.cardioVascularBox = new System.Windows.Forms.ComboBox();
            this.cardioDate = new System.Windows.Forms.DateTimePicker();
            this.cardioTime = new System.Windows.Forms.DateTimePicker();
            this.adSurgeryLbl = new System.Windows.Forms.Label();
            this.chssSurgeryLbl = new System.Windows.Forms.Label();
            this.chddSurgeryLbl = new System.Windows.Forms.Label();
            this.adSurgeryTxt = new System.Windows.Forms.ComboBox();
            this.chddSurgeryTxt = new System.Windows.Forms.ComboBox();
            this.chssSurgeryTxt = new System.Windows.Forms.ComboBox();
            this.surgeryInspectationTxt = new System.Windows.Forms.RichTextBox();
            this.dutyCardioInspectationPnl = new System.Windows.Forms.GroupBox();
            this.toAnalysisBtn = new System.Windows.Forms.Button();
            this.dutyCardioContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.addCardioInspetions = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.journalTab = new System.Windows.Forms.TabPage();
            this.analysisTab = new System.Windows.Forms.TabPage();
            this.toJournalsTab = new System.Windows.Forms.Button();
            this.analysisTabControl1 = new Cardiology.UI.Controls.AnalysisTabControl();
            this.afterKagDiagnosisPnl.SuspendLayout();
            this.surgeryInspectationPnl.SuspendLayout();
            this.dutyCardioInspectationPnl.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.journalTab.SuspendLayout();
            this.analysisTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // afterKagDiagnosisPnl
            // 
            this.afterKagDiagnosisPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.afterKagDiagnosisPnl.Controls.Add(this.wrongDateWarning);
            this.afterKagDiagnosisPnl.Controls.Add(this.removeKAG);
            this.afterKagDiagnosisPnl.Controls.Add(this.selectKAGBtn);
            this.afterKagDiagnosisPnl.Controls.Add(this.kagDianosisLbl);
            this.afterKagDiagnosisPnl.Controls.Add(this.kagDiagnosisTxt);
            this.afterKagDiagnosisPnl.Controls.Add(this.admissionDateTxt);
            this.afterKagDiagnosisPnl.Controls.Add(this.admissionTimeTxt);
            this.afterKagDiagnosisPnl.Controls.Add(this.afterKagDiagnosisTxt);
            this.afterKagDiagnosisPnl.Location = new System.Drawing.Point(3, 3);
            this.afterKagDiagnosisPnl.Name = "afterKagDiagnosisPnl";
            this.afterKagDiagnosisPnl.Size = new System.Drawing.Size(959, 107);
            this.afterKagDiagnosisPnl.TabIndex = 0;
            this.afterKagDiagnosisPnl.TabStop = false;
            this.afterKagDiagnosisPnl.Text = "После КАГ. Выставлен диагноз:";
            // 
            // wrongDateWarning
            // 
            this.wrongDateWarning.AutoSize = true;
            this.wrongDateWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wrongDateWarning.ForeColor = System.Drawing.Color.DarkRed;
            this.wrongDateWarning.Location = new System.Drawing.Point(211, 15);
            this.wrongDateWarning.Name = "wrongDateWarning";
            this.wrongDateWarning.Size = new System.Drawing.Size(622, 13);
            this.wrongDateWarning.TabIndex = 14;
            this.wrongDateWarning.Text = "В истории болезни уже есть дневники после КАГ за данную дату. Укажите другую дату" +
    " для создания.";
            // 
            // removeKAG
            // 
            this.removeKAG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeKAG.Image = global::Cardiology.Properties.Resources.trash;
            this.removeKAG.Location = new System.Drawing.Point(921, 73);
            this.removeKAG.Name = "removeKAG";
            this.removeKAG.Size = new System.Drawing.Size(33, 28);
            this.removeKAG.TabIndex = 13;
            this.removeKAG.UseVisualStyleBackColor = true;
            this.removeKAG.Click += new System.EventHandler(this.removeKAG_Click);
            // 
            // selectKAGBtn
            // 
            this.selectKAGBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectKAGBtn.Location = new System.Drawing.Point(921, 39);
            this.selectKAGBtn.Name = "selectKAGBtn";
            this.selectKAGBtn.Size = new System.Drawing.Size(33, 27);
            this.selectKAGBtn.TabIndex = 12;
            this.selectKAGBtn.Text = "...";
            this.selectKAGBtn.UseVisualStyleBackColor = true;
            this.selectKAGBtn.Click += new System.EventHandler(this.selectKAGBtn_Click);
            // 
            // kagDianosisLbl
            // 
            this.kagDianosisLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kagDianosisLbl.AutoSize = true;
            this.kagDianosisLbl.Location = new System.Drawing.Point(656, 32);
            this.kagDianosisLbl.Name = "kagDianosisLbl";
            this.kagDianosisLbl.Size = new System.Drawing.Size(82, 13);
            this.kagDianosisLbl.TabIndex = 11;
            this.kagDianosisLbl.Text = "Результат КАГ";
            // 
            // kagDiagnosisTxt
            // 
            this.kagDiagnosisTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kagDiagnosisTxt.Location = new System.Drawing.Point(484, 48);
            this.kagDiagnosisTxt.Name = "kagDiagnosisTxt";
            this.kagDiagnosisTxt.Size = new System.Drawing.Size(431, 51);
            this.kagDiagnosisTxt.TabIndex = 10;
            this.kagDiagnosisTxt.Text = "";
            // 
            // admissionDateTxt
            // 
            this.admissionDateTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.admissionDateTxt.Location = new System.Drawing.Point(8, 15);
            this.admissionDateTxt.Name = "admissionDateTxt";
            this.admissionDateTxt.Size = new System.Drawing.Size(98, 20);
            this.admissionDateTxt.TabIndex = 7;
            this.admissionDateTxt.ValueChanged += new System.EventHandler(this.admissionDateTxt_ValueChanged);
            // 
            // admissionTimeTxt
            // 
            this.admissionTimeTxt.CustomFormat = "HH:mm tt";
            this.admissionTimeTxt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.admissionTimeTxt.Location = new System.Drawing.Point(112, 15);
            this.admissionTimeTxt.Name = "admissionTimeTxt";
            this.admissionTimeTxt.ShowUpDown = true;
            this.admissionTimeTxt.Size = new System.Drawing.Size(98, 20);
            this.admissionTimeTxt.TabIndex = 6;
            this.admissionTimeTxt.ValueChanged += new System.EventHandler(this.admissionDateTxt_ValueChanged);
            // 
            // afterKagDiagnosisTxt
            // 
            this.afterKagDiagnosisTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.afterKagDiagnosisTxt.Location = new System.Drawing.Point(6, 49);
            this.afterKagDiagnosisTxt.Name = "afterKagDiagnosisTxt";
            this.afterKagDiagnosisTxt.Size = new System.Drawing.Size(472, 51);
            this.afterKagDiagnosisTxt.TabIndex = 0;
            this.afterKagDiagnosisTxt.Text = "ИБС: Острый нижний инфаркт миокарда от 07.08.2016. Атеросклероз коронарных артери" +
    "й. Состояние после ТЛАП и стентирования пр/3 ПКА(стентом xience V 3,0 x18мм с ле" +
    "карственным покрытием) от 07.08.2016";
            // 
            // journalDocLbl
            // 
            this.journalDocLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.journalDocLbl.AutoSize = true;
            this.journalDocLbl.Location = new System.Drawing.Point(627, 670);
            this.journalDocLbl.Name = "journalDocLbl";
            this.journalDocLbl.Size = new System.Drawing.Size(115, 13);
            this.journalDocLbl.TabIndex = 9;
            this.journalDocLbl.Text = "Ответственный врач:";
            // 
            // journalDocBox
            // 
            this.journalDocBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.journalDocBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.journalDocBox.FormattingEnabled = true;
            this.journalDocBox.Location = new System.Drawing.Point(745, 665);
            this.journalDocBox.Name = "journalDocBox";
            this.journalDocBox.Size = new System.Drawing.Size(220, 21);
            this.journalDocBox.TabIndex = 8;
            // 
            // surgeryInspectationPnl
            // 
            this.surgeryInspectationPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.surgeryInspectationPnl.Controls.Add(this.cardioVascularBox);
            this.surgeryInspectationPnl.Controls.Add(this.cardioDate);
            this.surgeryInspectationPnl.Controls.Add(this.cardioTime);
            this.surgeryInspectationPnl.Controls.Add(this.adSurgeryLbl);
            this.surgeryInspectationPnl.Controls.Add(this.chssSurgeryLbl);
            this.surgeryInspectationPnl.Controls.Add(this.chddSurgeryLbl);
            this.surgeryInspectationPnl.Controls.Add(this.adSurgeryTxt);
            this.surgeryInspectationPnl.Controls.Add(this.chddSurgeryTxt);
            this.surgeryInspectationPnl.Controls.Add(this.chssSurgeryTxt);
            this.surgeryInspectationPnl.Controls.Add(this.surgeryInspectationTxt);
            this.surgeryInspectationPnl.Location = new System.Drawing.Point(3, 116);
            this.surgeryInspectationPnl.Name = "surgeryInspectationPnl";
            this.surgeryInspectationPnl.Size = new System.Drawing.Size(959, 98);
            this.surgeryInspectationPnl.TabIndex = 1;
            this.surgeryInspectationPnl.TabStop = false;
            this.surgeryInspectationPnl.Text = "Осмотр ренгеноваскулярного хирурга.";
            // 
            // cardioVascularBox
            // 
            this.cardioVascularBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardioVascularBox.FormattingEnabled = true;
            this.cardioVascularBox.Location = new System.Drawing.Point(214, 19);
            this.cardioVascularBox.Name = "cardioVascularBox";
            this.cardioVascularBox.Size = new System.Drawing.Size(264, 21);
            this.cardioVascularBox.TabIndex = 30;
            // 
            // cardioDate
            // 
            this.cardioDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cardioDate.Location = new System.Drawing.Point(6, 19);
            this.cardioDate.Name = "cardioDate";
            this.cardioDate.Size = new System.Drawing.Size(98, 20);
            this.cardioDate.TabIndex = 15;
            // 
            // cardioTime
            // 
            this.cardioTime.CustomFormat = "HH:mm tt";
            this.cardioTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cardioTime.Location = new System.Drawing.Point(110, 19);
            this.cardioTime.Name = "cardioTime";
            this.cardioTime.ShowUpDown = true;
            this.cardioTime.Size = new System.Drawing.Size(98, 20);
            this.cardioTime.TabIndex = 14;
            // 
            // adSurgeryLbl
            // 
            this.adSurgeryLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adSurgeryLbl.AutoSize = true;
            this.adSurgeryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adSurgeryLbl.Location = new System.Drawing.Point(878, 52);
            this.adSurgeryLbl.Name = "adSurgeryLbl";
            this.adSurgeryLbl.Size = new System.Drawing.Size(26, 13);
            this.adSurgeryLbl.TabIndex = 29;
            this.adSurgeryLbl.Text = "АД:";
            // 
            // chssSurgeryLbl
            // 
            this.chssSurgeryLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chssSurgeryLbl.AutoSize = true;
            this.chssSurgeryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chssSurgeryLbl.Location = new System.Drawing.Point(792, 77);
            this.chssSurgeryLbl.Name = "chssSurgeryLbl";
            this.chssSurgeryLbl.Size = new System.Drawing.Size(32, 13);
            this.chssSurgeryLbl.TabIndex = 27;
            this.chssSurgeryLbl.Text = "ЧСС:";
            // 
            // chddSurgeryLbl
            // 
            this.chddSurgeryLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chddSurgeryLbl.AutoSize = true;
            this.chddSurgeryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chddSurgeryLbl.Location = new System.Drawing.Point(788, 53);
            this.chddSurgeryLbl.Name = "chddSurgeryLbl";
            this.chddSurgeryLbl.Size = new System.Drawing.Size(36, 13);
            this.chddSurgeryLbl.TabIndex = 26;
            this.chddSurgeryLbl.Text = "ЧДД:";
            // 
            // adSurgeryTxt
            // 
            this.adSurgeryTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adSurgeryTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adSurgeryTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adSurgeryTxt.FormattingEnabled = true;
            this.adSurgeryTxt.Items.AddRange(new object[] {
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
            this.adSurgeryTxt.Location = new System.Drawing.Point(904, 47);
            this.adSurgeryTxt.Name = "adSurgeryTxt";
            this.adSurgeryTxt.Size = new System.Drawing.Size(49, 21);
            this.adSurgeryTxt.TabIndex = 25;
            // 
            // chddSurgeryTxt
            // 
            this.chddSurgeryTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chddSurgeryTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chddSurgeryTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chddSurgeryTxt.FormattingEnabled = true;
            this.chddSurgeryTxt.Location = new System.Drawing.Point(826, 47);
            this.chddSurgeryTxt.Name = "chddSurgeryTxt";
            this.chddSurgeryTxt.Size = new System.Drawing.Size(49, 21);
            this.chddSurgeryTxt.TabIndex = 22;
            // 
            // chssSurgeryTxt
            // 
            this.chssSurgeryTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chssSurgeryTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chssSurgeryTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chssSurgeryTxt.FormattingEnabled = true;
            this.chssSurgeryTxt.Location = new System.Drawing.Point(826, 71);
            this.chssSurgeryTxt.Name = "chssSurgeryTxt";
            this.chssSurgeryTxt.Size = new System.Drawing.Size(49, 21);
            this.chssSurgeryTxt.TabIndex = 23;
            // 
            // surgeryInspectationTxt
            // 
            this.surgeryInspectationTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.surgeryInspectationTxt.Location = new System.Drawing.Point(5, 44);
            this.surgeryInspectationTxt.Name = "surgeryInspectationTxt";
            this.surgeryInspectationTxt.Size = new System.Drawing.Size(777, 46);
            this.surgeryInspectationTxt.TabIndex = 0;
            this.surgeryInspectationTxt.Text = "Над легкими аускультативно: дыхание жесткое, ЧД 19 уд в мин. Тоны сердца приглуше" +
    "ны, ритм неправильный. ЧСС 60 в мин. PS 60 в мин. АД 120/70 мм рт ст. Живот обыч" +
    "ной формы; безболезненный.";
            // 
            // dutyCardioInspectationPnl
            // 
            this.dutyCardioInspectationPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dutyCardioInspectationPnl.Controls.Add(this.toAnalysisBtn);
            this.dutyCardioInspectationPnl.Controls.Add(this.dutyCardioContainer);
            this.dutyCardioInspectationPnl.Controls.Add(this.addCardioInspetions);
            this.dutyCardioInspectationPnl.Location = new System.Drawing.Point(3, 216);
            this.dutyCardioInspectationPnl.Name = "dutyCardioInspectationPnl";
            this.dutyCardioInspectationPnl.Size = new System.Drawing.Size(959, 424);
            this.dutyCardioInspectationPnl.TabIndex = 2;
            this.dutyCardioInspectationPnl.TabStop = false;
            this.dutyCardioInspectationPnl.Text = "Осмотр дежурного кардиореаниматолога:";
            // 
            // toAnalysisBtn
            // 
            this.toAnalysisBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toAnalysisBtn.Location = new System.Drawing.Point(762, 396);
            this.toAnalysisBtn.Name = "toAnalysisBtn";
            this.toAnalysisBtn.Size = new System.Drawing.Size(156, 23);
            this.toAnalysisBtn.TabIndex = 10;
            this.toAnalysisBtn.Text = "Привязать анализы";
            this.toAnalysisBtn.UseVisualStyleBackColor = true;
            this.toAnalysisBtn.Click += new System.EventHandler(this.toAnalysisBtn_Click);
            // 
            // dutyCardioContainer
            // 
            this.dutyCardioContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dutyCardioContainer.AutoScroll = true;
            this.dutyCardioContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dutyCardioContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.dutyCardioContainer.Location = new System.Drawing.Point(8, 19);
            this.dutyCardioContainer.Name = "dutyCardioContainer";
            this.dutyCardioContainer.Size = new System.Drawing.Size(907, 371);
            this.dutyCardioContainer.TabIndex = 7;
            this.dutyCardioContainer.WrapContents = false;
            // 
            // addCardioInspetions
            // 
            this.addCardioInspetions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addCardioInspetions.Image = global::Cardiology.Properties.Resources.addd1;
            this.addCardioInspetions.Location = new System.Drawing.Point(925, 22);
            this.addCardioInspetions.Name = "addCardioInspetions";
            this.addCardioInspetions.Size = new System.Drawing.Size(29, 28);
            this.addCardioInspetions.TabIndex = 5;
            this.addCardioInspetions.UseVisualStyleBackColor = true;
            this.addCardioInspetions.Click += new System.EventHandler(this.addCardioInspetions_Click);
            // 
            // printBtn
            // 
            this.printBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.printBtn.Location = new System.Drawing.Point(12, 663);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(115, 23);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "MsWord";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveBtn.Location = new System.Drawing.Point(133, 663);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.journalTab);
            this.tabControl1.Controls.Add(this.analysisTab);
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(975, 655);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // journalTab
            // 
            this.journalTab.Controls.Add(this.afterKagDiagnosisPnl);
            this.journalTab.Controls.Add(this.surgeryInspectationPnl);
            this.journalTab.Controls.Add(this.dutyCardioInspectationPnl);
            this.journalTab.Location = new System.Drawing.Point(4, 5);
            this.journalTab.Name = "journalTab";
            this.journalTab.Padding = new System.Windows.Forms.Padding(3);
            this.journalTab.Size = new System.Drawing.Size(967, 646);
            this.journalTab.TabIndex = 0;
            this.journalTab.Text = "Дневники";
            this.journalTab.UseVisualStyleBackColor = true;
            // 
            // analysisTab
            // 
            this.analysisTab.Controls.Add(this.toJournalsTab);
            this.analysisTab.Controls.Add(this.analysisTabControl1);
            this.analysisTab.Location = new System.Drawing.Point(4, 5);
            this.analysisTab.Name = "analysisTab";
            this.analysisTab.Padding = new System.Windows.Forms.Padding(3);
            this.analysisTab.Size = new System.Drawing.Size(967, 646);
            this.analysisTab.TabIndex = 1;
            this.analysisTab.Text = "Анализы";
            this.analysisTab.UseVisualStyleBackColor = true;
            // 
            // toJournalsTab
            // 
            this.toJournalsTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toJournalsTab.Location = new System.Drawing.Point(765, 613);
            this.toJournalsTab.Name = "toJournalsTab";
            this.toJournalsTab.Size = new System.Drawing.Size(156, 23);
            this.toJournalsTab.TabIndex = 1;
            this.toJournalsTab.Text = "Ввести дневники";
            this.toJournalsTab.UseVisualStyleBackColor = true;
            this.toJournalsTab.Click += new System.EventHandler(this.toJournalsTab_Click);
            // 
            // analysisTabControl1
            // 
            this.analysisTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analysisTabControl1.AutoSize = true;
            this.analysisTabControl1.Location = new System.Drawing.Point(-1, 0);
            this.analysisTabControl1.Name = "analysisTabControl1";
            this.analysisTabControl1.Size = new System.Drawing.Size(962, 607);
            this.analysisTabControl1.TabIndex = 0;
            // 
            // JournalAfterKAG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 689);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.journalDocLbl);
            this.Controls.Add(this.journalDocBox);
            this.Controls.Add(this.printBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JournalAfterKAG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дневник после КАГ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JournalAfterKAG_FormClosing);
            this.afterKagDiagnosisPnl.ResumeLayout(false);
            this.afterKagDiagnosisPnl.PerformLayout();
            this.surgeryInspectationPnl.ResumeLayout(false);
            this.surgeryInspectationPnl.PerformLayout();
            this.dutyCardioInspectationPnl.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.journalTab.ResumeLayout(false);
            this.analysisTab.ResumeLayout(false);
            this.analysisTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox afterKagDiagnosisPnl;
        private System.Windows.Forms.RichTextBox afterKagDiagnosisTxt;
        private System.Windows.Forms.GroupBox surgeryInspectationPnl;
        private System.Windows.Forms.RichTextBox surgeryInspectationTxt;
        private System.Windows.Forms.GroupBox dutyCardioInspectationPnl;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button addCardioInspetions;
        private System.Windows.Forms.Label adSurgeryLbl;
        private System.Windows.Forms.Label chssSurgeryLbl;
        private System.Windows.Forms.Label chddSurgeryLbl;
        private System.Windows.Forms.ComboBox adSurgeryTxt;
        private System.Windows.Forms.ComboBox chddSurgeryTxt;
        private System.Windows.Forms.ComboBox chssSurgeryTxt;
        private System.Windows.Forms.DateTimePicker admissionTimeTxt;
        private System.Windows.Forms.DateTimePicker admissionDateTxt;
        private System.Windows.Forms.ComboBox journalDocBox;
        private System.Windows.Forms.Label journalDocLbl;
        private System.Windows.Forms.RichTextBox kagDiagnosisTxt;
        private System.Windows.Forms.Label kagDianosisLbl;
        private System.Windows.Forms.Button removeKAG;
        private System.Windows.Forms.Button selectKAGBtn;
        private System.Windows.Forms.FlowLayoutPanel dutyCardioContainer;
        private JournalKAGControl releaseJournalCtrl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage journalTab;
        private System.Windows.Forms.TabPage analysisTab;
        private AnalysisTabControl analysisTabControl1;
        private Button toAnalysisBtn;
        private Button toJournalsTab;
        private ComboBox cardioVascularBox;
        private DateTimePicker cardioDate;
        private DateTimePicker cardioTime;
        private Label wrongDateWarning;
    }
}