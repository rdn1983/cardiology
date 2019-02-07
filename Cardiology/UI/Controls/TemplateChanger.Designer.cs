namespace Cardiology.UI.Controls
{
    partial class TemplateChanger
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
            this.deathItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pikvikItem = new System.Windows.Forms.ToolStripMenuItem();
            this.piksItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aorticItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kagItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oksUpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oksDownItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // deathItem
            // 
            this.deathItem.Name = "deathItem";
            this.deathItem.Size = new System.Drawing.Size(188, 22);
            this.deathItem.Text = "Клиническая смерть";
            this.deathItem.Click += new System.EventHandler(this.deathItem_Click);
            // 
            // depItem
            // 
            this.depItem.Name = "depItem";
            this.depItem.Size = new System.Drawing.Size(188, 22);
            this.depItem.Text = "ДЭП";
            this.depItem.Click += new System.EventHandler(this.depItem_Click);
            // 
            // pikvikItem
            // 
            this.pikvikItem.Name = "pikvikItem";
            this.pikvikItem.Size = new System.Drawing.Size(188, 22);
            this.pikvikItem.Text = "ПИКВИК";
            this.pikvikItem.Click += new System.EventHandler(this.pikvikItem_Click);
            // 
            // piksItem
            // 
            this.piksItem.Name = "piksItem";
            this.piksItem.Size = new System.Drawing.Size(188, 22);
            this.piksItem.Text = "ПИКС НК";
            this.piksItem.Click += new System.EventHandler(this.piksItem_Click);
            // 
            // gbItem
            // 
            this.gbItem.Name = "gbItem";
            this.gbItem.Size = new System.Drawing.Size(188, 22);
            this.gbItem.Text = "ГБ криз";
            this.gbItem.Click += new System.EventHandler(this.gbItem_Click);
            // 
            // aorticItem
            // 
            this.aorticItem.Name = "aorticItem";
            this.aorticItem.Size = new System.Drawing.Size(188, 22);
            this.aorticItem.Text = "Расслоение аорты";
            this.aorticItem.Click += new System.EventHandler(this.aorticItem_Click);
            // 
            // kagItem
            // 
            this.kagItem.Name = "kagItem";
            this.kagItem.Size = new System.Drawing.Size(188, 22);
            this.kagItem.Text = "КАГ квота";
            this.kagItem.Click += new System.EventHandler(this.kagItem_Click);
            // 
            // oksUpItem
            // 
            this.oksUpItem.Name = "oksUpItem";
            this.oksUpItem.Size = new System.Drawing.Size(188, 22);
            this.oksUpItem.Text = "ОКС без подъема ST";
            this.oksUpItem.Click += new System.EventHandler(this.oksUpItem_Click);
            // 
            // oksDownItem
            // 
            this.oksDownItem.Name = "oksDownItem";
            this.oksDownItem.Size = new System.Drawing.Size(188, 22);
            this.oksDownItem.Text = "ОКС с подъемом ST";
            this.oksDownItem.Click += new System.EventHandler(this.oksDownItem_Click);
            // 
            // TemplateChanger
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oksUpItem,
            this.oksDownItem,
            this.kagItem,
            this.aorticItem,
            this.gbItem,
            this.piksItem,
            this.pikvikItem,
            this.depItem,
            this.deathItem});
            this.Size = new System.Drawing.Size(189, 180);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem deathItem;
        private System.Windows.Forms.ToolStripMenuItem depItem;
        private System.Windows.Forms.ToolStripMenuItem pikvikItem;
        private System.Windows.Forms.ToolStripMenuItem piksItem;
        private System.Windows.Forms.ToolStripMenuItem gbItem;
        private System.Windows.Forms.ToolStripMenuItem aorticItem;
        private System.Windows.Forms.ToolStripMenuItem kagItem;
        private System.Windows.Forms.ToolStripMenuItem oksUpItem;
        private System.Windows.Forms.ToolStripMenuItem oksDownItem;
    }
}
