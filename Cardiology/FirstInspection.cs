using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class FirstInspection : Form
    {
        public FirstInspection()
        {
            InitializeComponent();
        }

        private void fixComplaintTeplaintBtn_Click(object sender, EventArgs e)
        {
            ComplaintTemplates templateForm = new ComplaintTemplates();
            templateForm.ShowDialog();
        }

        private void fixMorbiTemplateBtn_Click(object sender, EventArgs e)
        {
            MorbiTemplates templateForm = new MorbiTemplates();
            templateForm.ShowDialog();
        }

        private void FirstInspection_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
