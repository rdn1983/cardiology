using Cardiology.Model;
using System;
using System.Collections;
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
    public partial class AnalysisCabinet : Form
    {
        private DdtHospital hospitalSession;

        public AnalysisCabinet(DdtHospital hospitalSession)
        {
            this.hospitalSession = hospitalSession;
            InitializeComponent();
            initAnalysis();
        }

        private void initAnalysis()
        {
            allPatientAnalysis.Rows.Clear();
            DataService service = new DataService();
            string query = @"Select * from ddt_patient_analysis where dsid_hospitality_session='" + hospitalSession.ObjectId + "' ";
            List<DdtPatientAnalysis> allHspitalPatients = service.queryObjectsCollection<DdtPatientAnalysis>(query);
            for (int i = 0; i < allHspitalPatients.Count(); i++)
            {
                DdtPatientAnalysis h = allHspitalPatients[i];
                allPatientAnalysis.Rows.Add(h.RCreationDate, h.ObjectId, "", "");
            }
        }

        private void addAnalysis_Click(object sender, EventArgs e)
        {
            Analizi form = new Analizi(hospitalSession, null);
            form.ShowDialog();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            IEnumerator it = allPatientAnalysis.SelectedRows.GetEnumerator();
            if (it.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)it.Current;
                DataGridViewCell cell = row.Cells[1];
                string value = cell.Value.ToString();
                DataService service = new DataService();
                DdtPatientAnalysis ll = service.queryObject<DdtPatientAnalysis>(@"Select * from ddt_patient_analysis where r_object_id ='" + value + "'");
                Analizi form = new Analizi(hospitalSession, ll);
                form.ShowDialog();
            }
        }
    }
}
