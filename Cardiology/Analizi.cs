using Cardiology.Model;
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
        private DdtHospital hospitalitySession;

        public Analizi(DdtHospital hospitalitySession)
        {
            this.hospitalitySession = hospitalitySession;
            InitializeComponent();
        }

        private void Analizi_Load(object sender, EventArgs e)
        {

        }

        private void showABOFormBtn_Click(object sender, EventArgs e)
        {
            Serology aboForm = new Serology(hospitalitySession);
            aboForm.ShowDialog();

        }
    }
}
