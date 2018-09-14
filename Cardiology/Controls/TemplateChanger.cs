using System;
using System.Windows.Forms;

namespace Cardiology.Controls
{
    public partial class TemplateChanger : ContextMenuStrip
    {
        private string attrName;
        private Control source;

        public TemplateChanger()
        {
            InitializeComponent();
        }

        public void Show(int x, int y, Control parent, Control source, string attrName)
        {
            this.source = source;
            this.attrName = attrName;
            Show(parent, x, y);
        }

        private void pikvikItem_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            string value = service.querySingleString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='pikvik'");
            source.Text = value;
            attrName = null;
            source = null;
        }

        private void aorticItem_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            string value = service.querySingleString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='aorta'");
            source.Text = value;
            attrName = null;
            source = null;
        }

        private void deathItem_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            string value = service.querySingleString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='death'");
            source.Text = value;
            attrName = null;
            source = null;
        }

        private void depItem_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            string value = service.querySingleString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='dep'");
            source.Text = value;
            attrName = null;
            source = null;
        }

        private void gbItem_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            string value = service.querySingleString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='gb'");
            source.Text = value;
            attrName = null;
            source = null;
        }

        private void kagItem_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            string value = service.querySingleString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='kag'");
            source.Text = value;
            attrName = null;
            source = null;
        }

        private void oksDownItem_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            string value = service.querySingleString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='oksdown'");
            source.Text = value;
            attrName = null;
            source = null;
        }

        private void oksUpItem_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            string value = service.querySingleString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='oksup'");
            source.Text = value;
            attrName = null;
            source = null;
        }

        private void piksItem_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            string value = service.querySingleString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='piks'");
            source.Text = value;
            attrName = null;
            source = null;
        }
    }
}
