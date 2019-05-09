namespace Cardiology.UI.Controls
{
    partial class AnalysisTabControl
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
            this.tabbedAnalysis = new System.Windows.Forms.TabControl();
            this.selectAnalysis = new System.Windows.Forms.Button();
            this.createAnalysis = new System.Windows.Forms.Button();
            this.analysisType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ddt_blood_analysis = new System.Windows.Forms.ToolStripMenuItem();
            this.ddt_urine_analysis = new System.Windows.Forms.ToolStripMenuItem();
            this.ddt_uzi = new System.Windows.Forms.ToolStripMenuItem();
            this.ddt_ekg = new System.Windows.Forms.ToolStripMenuItem();
            this.ddt_xray = new System.Windows.Forms.ToolStripMenuItem();
            this.ddt_holter = new System.Windows.Forms.ToolStripMenuItem();
            this.ddt_specialist_conclusion = new System.Windows.Forms.ToolStripMenuItem();
            this.ddt_egds = new System.Windows.Forms.ToolStripMenuItem();
            this.ddt_coagulogram = new System.Windows.Forms.ToolStripMenuItem();
            this.ddt_hormones = new System.Windows.Forms.ToolStripMenuItem();
            this.ddt_onko = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisType.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabbedAnalysis
            // 
            this.tabbedAnalysis.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabbedAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabbedAnalysis.Location = new System.Drawing.Point(3, 3);
            this.tabbedAnalysis.Multiline = true;
            this.tabbedAnalysis.Name = "tabbedAnalysis";
            this.tabbedAnalysis.SelectedIndex = 0;
            this.tabbedAnalysis.Size = new System.Drawing.Size(918, 505);
            this.tabbedAnalysis.TabIndex = 10;
            // 
            // selectAnalysis
            // 
            this.selectAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAnalysis.Location = new System.Drawing.Point(927, 37);
            this.selectAnalysis.Name = "selectAnalysis";
            this.selectAnalysis.Size = new System.Drawing.Size(29, 28);
            this.selectAnalysis.TabIndex = 12;
            this.selectAnalysis.Text = "...";
            this.selectAnalysis.UseVisualStyleBackColor = true;
            this.selectAnalysis.Click += new System.EventHandler(this.selectAnalysis_Click);
            // 
            // createAnalysis
            // 
            this.createAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createAnalysis.Image = global::Cardiology.Properties.Resources.addd1;
            this.createAnalysis.Location = new System.Drawing.Point(927, 3);
            this.createAnalysis.Name = "createAnalysis";
            this.createAnalysis.Size = new System.Drawing.Size(29, 28);
            this.createAnalysis.TabIndex = 11;
            this.createAnalysis.UseVisualStyleBackColor = true;
            this.createAnalysis.Click += new System.EventHandler(this.createAnalysis_Click);
            // 
            // analysisType
            // 
            this.analysisType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddt_blood_analysis,
            this.ddt_urine_analysis,
            this.ddt_uzi,
            this.ddt_ekg,
            this.ddt_xray,
            this.ddt_holter,
            this.ddt_specialist_conclusion,
            this.ddt_egds,
            this.ddt_coagulogram,
            this.ddt_hormones,
            this.ddt_onko});
            this.analysisType.Name = "analysisTypeMenu";
            this.analysisType.Size = new System.Drawing.Size(224, 246);
            // 
            // ddt_blood_analysis
            // 
            this.ddt_blood_analysis.Name = "ddt_blood_analysis";
            this.ddt_blood_analysis.Size = new System.Drawing.Size(223, 22);
            this.ddt_blood_analysis.Text = "Анализы крови";
            // 
            // ddt_urine_analysis
            // 
            this.ddt_urine_analysis.Name = "ddt_urine_analysis";
            this.ddt_urine_analysis.Size = new System.Drawing.Size(223, 22);
            this.ddt_urine_analysis.Text = "Анализы мочи";
            // 
            // ddt_uzi
            // 
            this.ddt_uzi.Name = "ddt_uzi";
            this.ddt_uzi.Size = new System.Drawing.Size(223, 22);
            this.ddt_uzi.Text = "УЗИ/ЭХО";
            // 
            // ddt_ekg
            // 
            this.ddt_ekg.Name = "ddt_ekg";
            this.ddt_ekg.Size = new System.Drawing.Size(223, 22);
            this.ddt_ekg.Text = "ЭКГ";
            // 
            // ddt_xray
            // 
            this.ddt_xray.Name = "ddt_xray";
            this.ddt_xray.Size = new System.Drawing.Size(223, 22);
            this.ddt_xray.Text = "Рентген/КТ";
            // 
            // ddt_holter
            // 
            this.ddt_holter.Name = "ddt_holter";
            this.ddt_holter.Size = new System.Drawing.Size(223, 22);
            this.ddt_holter.Text = "Холтер";
            // 
            // ddt_specialist_conclusion
            // 
            this.ddt_specialist_conclusion.Name = "ddt_specialist_conclusion";
            this.ddt_specialist_conclusion.Size = new System.Drawing.Size(223, 22);
            this.ddt_specialist_conclusion.Text = "Заключения специалистов";
            // 
            // ddt_egds
            // 
            this.ddt_egds.Name = "ddt_egds";
            this.ddt_egds.Size = new System.Drawing.Size(223, 22);
            this.ddt_egds.Text = "ЭГДС";
            // 
            // ddt_coagulogram
            // 
            this.ddt_coagulogram.Name = "ddt_coagulogram";
            this.ddt_coagulogram.Size = new System.Drawing.Size(223, 22);
            this.ddt_coagulogram.Text = "Коагулограмма";
            // 
            // ddt_hormones
            // 
            this.ddt_hormones.Name = "ddt_hormones";
            this.ddt_hormones.Size = new System.Drawing.Size(223, 22);
            this.ddt_hormones.Text = "Гормоны";
            // 
            // ddt_onko
            // 
            this.ddt_onko.Name = "ddt_onko";
            this.ddt_onko.Size = new System.Drawing.Size(223, 22);
            this.ddt_onko.Text = "Онкомаркеры";
            // 
            // AnalysisTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.selectAnalysis);
            this.Controls.Add(this.createAnalysis);
            this.Controls.Add(this.tabbedAnalysis);
            this.Name = "AnalysisTabControl";
            this.Size = new System.Drawing.Size(962, 511);
            this.analysisType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabbedAnalysis;
        private System.Windows.Forms.Button selectAnalysis;
        private System.Windows.Forms.Button createAnalysis;
        private System.Windows.Forms.ContextMenuStrip analysisType;
        private System.Windows.Forms.ToolStripMenuItem ddt_uzi;
        private System.Windows.Forms.ToolStripMenuItem ddt_blood_analysis;
        private System.Windows.Forms.ToolStripMenuItem ddt_ekg;
        private System.Windows.Forms.ToolStripMenuItem ddt_xray;
        private System.Windows.Forms.ToolStripMenuItem ddt_holter;
        private System.Windows.Forms.ToolStripMenuItem ddt_specialist_conclusion;
        private System.Windows.Forms.ToolStripMenuItem ddt_urine_analysis;
        private System.Windows.Forms.ToolStripMenuItem ddt_egds;
        private System.Windows.Forms.ToolStripMenuItem ddt_coagulogram;
        private System.Windows.Forms.ToolStripMenuItem ddt_hormones;
        private System.Windows.Forms.ToolStripMenuItem ddt_onko;
    }
}
