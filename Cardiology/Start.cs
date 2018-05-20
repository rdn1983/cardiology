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
            initPatientLastName();
            initPatientSecondName();
            initPatientFirstName(); 
        }

        private void initPatientLastName()
        {
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection();
                connection.ConnectionString = "Data Source=D:\\OPEN\\cardiology\\Database\\cardiology.sqlite";

                connection.Open();

                string sql = "SELECT dss_value FROM ddt_values WHERE dss_name = 'default.patient.lastname'";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    patientLastName.Text = (string)reader["dss_value"];
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        private void initPatientSecondName()
        {
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection();
                connection.ConnectionString = "Data Source=D:\\OPEN\\cardiology\\Database\\cardiology.sqlite";

                connection.Open();

                string sql = "SELECT dss_value FROM ddt_values WHERE dss_name = 'default.patient.secondname'";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    patientSecondName.Text = (string)reader["dss_value"];
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        private void initPatientFirstName()
        {
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection();
                connection.ConnectionString = "Data Source=D:\\OPEN\\cardiology\\Database\\cardiology.sqlite";

                connection.Open();

                string sql = "SELECT dss_value FROM ddt_values WHERE dss_name = 'default.patient.name'";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    patientFirstName.Text = (string)reader["dss_value"];
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
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
    }
}
