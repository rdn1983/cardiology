using System;
using System.Windows.Forms;
using Cardiology.Data;

namespace Cardiology.UI.Controls
{
    public partial class TemplateChanger : ContextMenuStrip
    {
        private string attrName;
        private OnCompleteListener listener;
        private IDbDataService service;

        public delegate void OnCompleteListener(object returnValue);

        public TemplateChanger()
        {
            InitializeComponent();
        }

        public void Show(int x, int y, Control parent, string attrName, OnCompleteListener listener)
        {
            this.service = DbDataService.GetInstance();
            this.attrName = attrName;
            this.listener = listener;
            Show(parent, x, y);
        }

        private void pikvikItem_Click(object sender, EventArgs e)
        {
            string value = "dss_template_name".Equals(attrName, StringComparison.Ordinal)? "hobl" :
                service.GetString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='pikvik'");
            listener?.Invoke(value);
            attrName = null;
            listener = null;
            Close();
        }

        private void aorticItem_Click(object sender, EventArgs e)
        {

            string value = service.GetString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='aorta'");
            listener?.Invoke(value);
            attrName = null;
            listener = null;
            Close();
        }

        private void deathItem_Click(object sender, EventArgs e)
        {

            string value = service.GetString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='death'");
            listener?.Invoke(value);
            attrName = null;
            listener = null;
            Close();
        }

        private void depItem_Click(object sender, EventArgs e)
        {

            string value = service.GetString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='dep'");
            listener?.Invoke(value);
            attrName = null;
            listener = null;
            Close();
        }

        private void gbItem_Click(object sender, EventArgs e)
        {

            string value = service.GetString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='gb'");
            listener?.Invoke(value);
            attrName = null;
            listener = null;
            Close();
        }

        private void kagItem_Click(object sender, EventArgs e)
        {

            string value = service.GetString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='kag'");
            listener?.Invoke(value);
            attrName = null;
            listener = null;
            Close();
        }

        private void oksDownItem_Click(object sender, EventArgs e)
        {
            string value = "dss_template_name".Equals(attrName, StringComparison.Ordinal) ? "oks." :
                service.GetString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='oksdown'");
            listener?.Invoke(value);
            attrName = null;
            listener = null;
            Close();
        }

        private void oksUpItem_Click(object sender, EventArgs e)
        {
            string value = "dss_template_name".Equals(attrName, StringComparison.Ordinal) ? "okslongs" :
                service.GetString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='oksup'");
            listener?.Invoke(value);
            attrName = null;
            listener = null;
            Close();
        }

        private void piksItem_Click(object sender, EventArgs e)
        {
            string value = "dss_template_name".Equals(attrName, StringComparison.Ordinal) ? "nk" :
                service.GetString(@"SELECT " + attrName + " FROM ddt_anamnesis WHERE " +
                "dsb_template=true AND dss_template_name='piks'");
            listener?.Invoke(value);
            attrName = null;
            listener = null;
            Close();
        }
    }
}
