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
    public partial class Analizi : Form
    {
        public Analizi()
        {
            InitializeComponent();
        }

        private void Analizi_Load(object sender, EventArgs e)
        {

        }

        private void showABOFormBtn_Click(object sender, EventArgs e)
        {
            UserFormABO aboForm = new UserFormABO();
            aboForm.ShowDialog();

        }
    }
}
