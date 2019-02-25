using System;
using System.Windows.Forms;
using Cardiology.Data;

namespace Cardiology.UI.Forms
{
    public partial class UserFormProtocolManipulation : Form
    {
        private readonly IDbDataService service;

        public UserFormProtocolManipulation(IDbDataService service)
        {
            this.service = service;
            InitializeComponent();
        }

        private void kateterBtn_Click(object sender, EventArgs e)
        {
            UserFromVena form = new UserFromVena(service);
            form.ShowDialog();
        }

        private void trombolizisBtn_Click(object sender, EventArgs e)
        {
            UserFormTrombolizis form = new UserFormTrombolizis(service, null);
            form.ShowDialog();
        }

        private void veksBtn_Click(object sender, EventArgs e)
        {
            UserFormVEKS form = new UserFormVEKS(service);
            form.ShowDialog();
        }

        private void toraketosBtn_Click(object sender, EventArgs e)
        {
            UserFormTorCent form = new UserFormTorCent(service);
            form.ShowDialog();
        }

        private void eitBtn_Click(object sender, EventArgs e)
        {
            UserFormEIT form = new UserFormEIT(service);
            form.ShowDialog();
        }

        private void intubationBtn_Click(object sender, EventArgs e)
        {
            UserFormIntubation form = new UserFormIntubation(service);
            form.ShowDialog();
        }

        private void ekstubationBtn_Click(object sender, EventArgs e)
        {
            UserFormExtubation form = new UserFormExtubation(service);
            form.ShowDialog();
        }

        private void reanimBtn_Click(object sender, EventArgs e)
        {
            ReanimDEAD form = new ReanimDEAD(service, null);
            form.ShowDialog();
        }
    }
}
