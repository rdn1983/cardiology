using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

using Cardiology.Model;

namespace Cardiology
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();

            

            initControls();            
        }

        private void initControls()
        {
            initPatient();

        }

        private void initPatient()
        {
            DataService service = new DataService();
            Patient patient = service.GetPatient();
            patientLastName.Text = patient.lastName;
            patientFirstName.Text = patient.name;
            patientSecondName.Text = patient.secondName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void firstInspectionBtn_Click(object sender, EventArgs e)
        {
            FirstInspection inspectionForm = new FirstInspection();
            inspectionForm.ShowDialog();
        }

        private void prescribingBtn_Click(object sender, EventArgs e)
        {
            ListNaznachForm form = new ListNaznachForm();
            form.ShowDialog();
        }

        private void konsiliumBtn_Click(object sender, EventArgs e)
        {
            Konsilium form = new Konsilium();
            form.ShowDialog();
        }

        private void manipulationProtocolBtn_Click(object sender, EventArgs e)
        {
            UserFormProtocolManipulation form = new UserFormProtocolManipulation();
            form.ShowDialog();
        }

        private void analyzesBtn_Click(object sender, EventArgs e)
        {
            Analizi form = new Analizi();
            form.ShowDialog();
        }

        private void transfusionBloodBtn_Click(object sender, EventArgs e)
        {
            Perelivanie form = new Perelivanie();
            form.ShowDialog();
        }

        private void emergencyLettersBtn_Click(object sender, EventArgs e)
        {
            Pisma form = new Pisma();
            form.ShowDialog();
        }

        private void blanksBtn_Click(object sender, EventArgs e)
        {
            UserBlanks form = new UserBlanks();
            form.ShowDialog();
        }

        private void journalAfterKAGBtn_Click(object sender, EventArgs e)
        {
            JournalAfterKAG form = new JournalAfterKAG();
            form.ShowDialog();
        }

        private void jurnalWithoutKAGBtn_Click(object sender, EventArgs e)
        {
            DB3 form = new DB3();
            form.ShowDialog();
        }

        private void obhodBtn_Click(object sender, EventArgs e)
        {
            Obhod form = new Obhod();
            form.ShowDialog();
        }

        private void vypiskaBtn_Click(object sender, EventArgs e)
        {
            Vypaska form = new Vypaska();
            form.ShowDialog();
        }

        private void journalBeforeKAGBtn_Click(object sender, EventArgs e)
        {
            DB1 form = new DB1();
            form.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void patientFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void patientSecondName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
