using System;
using System.Windows.Forms;

namespace Cardiology.UI.Forms
{
    public partial class UserFormProtocolManipulation : Form
    {
        public UserFormProtocolManipulation()
        {
            InitializeComponent();
        }

        private void kateterBtn_Click(object sender, EventArgs e)
        {
            UserFromVena form = new UserFromVena();
            form.ShowDialog();
        }

        private void trombolizisBtn_Click(object sender, EventArgs e)
        {
            UserFormTrombolizis form = new UserFormTrombolizis(null);
            form.ShowDialog();
        }

        private void veksBtn_Click(object sender, EventArgs e)
        {
            UserFormVEKS form = new UserFormVEKS();
            form.ShowDialog();
        }

        private void toraketosBtn_Click(object sender, EventArgs e)
        {
            UserFormTorCent form = new UserFormTorCent();
            form.ShowDialog();
        }

        private void eitBtn_Click(object sender, EventArgs e)
        {
            UserFormEIT form = new UserFormEIT();
            form.ShowDialog();
        }

        private void intubationBtn_Click(object sender, EventArgs e)
        {
            UserFormIntubation form = new UserFormIntubation();
            form.ShowDialog();
        }

        private void ekstubationBtn_Click(object sender, EventArgs e)
        {
            UserFormExtubation form = new UserFormExtubation();
            form.ShowDialog();
        }

        private void reanimBtn_Click(object sender, EventArgs e)
        {
            ReanimDEAD form = new ReanimDEAD(null);
            form.ShowDialog();
        }
    }
}
