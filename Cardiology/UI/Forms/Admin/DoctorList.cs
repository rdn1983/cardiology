using Cardiology.Data.Commons;
using System;
using System.Windows.Forms;

namespace Cardiology.UI.Forms.Admin
{
    public partial class DoctorList : Form
    {
        public DoctorList(IDdvDoctorService service)
        {
            InitializeComponent();

            ddtDoctorBindingSource.DataSource = service.GetAll();
        }

        private void AddDoctor(object sender, EventArgs e)
        {

        }
    }
}
