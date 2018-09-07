using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Cardiology.Model;
using Cardiology.Utils;

namespace Cardiology
{
    public partial class AdmissionPatient : Form
    {

        public AdmissionPatient()
        {
            InitializeComponent();
            initDutyDoctors();
        }

        private void initDutyDoctors()
        {
            DataService service = new DataService();
            CommonUtils.initDoctorsComboboxValues(service, directorCardioReanimBox, null);
            CommonUtils.initDoctorsComboboxValues(service, dutyCardioBox, null);
            CommonUtils.initDoctorsComboboxValues(service, cardioDocBox, null);
            CommonUtils.initDoctorsComboboxValues(service, subDoctorBox, null);
            CommonUtils.initDoctorsComboboxValues(service, anesthetistComboBox, null);
        }

        private void admisPatient_Click(object sender, EventArgs e)
        {
            if (!getIsValid())
            {
                MessageBox.Show("Заполните поля помеченные жирным шрифтом!", "Warning", MessageBoxButtons.OK);
                return;
            }

            DdtPatient patient = new DdtPatient();
            patient.DssAddress = addressTxt.Text.Trim();
            patient.DssInitials = patientLastName.Text.Trim() + " " + patientFirstName.Text.Substring(0, 1) + "." + " " + patientSecondName.Text.Substring(0, 1) + ".";
            patient.DssFullName = patientLastName.Text.Trim() + " " + patientFirstName.Text.Trim() + " " + patientSecondName.Text.Trim();
            patient.DssMedCode = medCodeTxt.Text.Trim();
            patient.DssPhone = phoneTxt.Text;
            patient.DssSnils = snilsTxt.Text;
            patient.DssOms = omsTxt.Text;
            patient.DssPassportDate = passportDataTxt.Value;
            patient.DssPassportIssuePlace = passportIssuePlaceTxt.Text;
            patient.DssPassportNum = passportNumTxt.Text;
            patient.DssPassportSerial = passportSerialTxt.Text;
            //todo Сделаь проверку на существующий логин
            patient.DssLogin = translit(patientLastName.Text.Trim() + patientFirstName.Text.Substring(0, 1) + patientSecondName.Text.Substring(0, 1));

            if (CommonUtils.isNotBlank(weightTxt.Text))
            {
                patient.DsdWeight = Double.Parse(weightTxt.Text.Trim());
            }
            if (CommonUtils.isNotBlank(highTxt.Text))
            {
                patient.DsdHigh = Double.Parse(highTxt.Text.Trim());
            }
            patient.DsdtBirthdate = DateTime.ParseExact(patientBirthDate.Text.Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            DataService service = new DataService();
            String patientId = service.insertObject(patient, DdtPatient.TABLENAME);

            DdtHospital hospital = new DdtHospital();
            hospital.DsbActive = true;
            hospital.DsidPatient = patientId;
            hospital.DsdtAdmissionDate = CommonUtils.constructDateWIthTime(patientReceiptDate.Value, patientReceiptTime.Value);
            DdtDoctors docDuty = (DdtDoctors)dutyCardioBox.SelectedItem;
            hospital.DsidDutyDoctor = docDuty.ObjectId;
            DdtDoctors docCuring = (DdtDoctors)cardioDocBox.SelectedItem;
            hospital.DsidCuringDoctor = docCuring.ObjectId;
            DdtDoctors docSubstitution = (DdtDoctors)subDoctorBox.SelectedItem;
            hospital.DsidSubstitutionDoctor = docSubstitution.ObjectId;
            hospital.DssRoomCell = roomTxt.Text + "/" + bedTxt.Text;
            service.insertObject(hospital, DdtHospital.TABLENAME);
            //todo перенести в статусную строку
            Close();
        }

        private bool getIsValid()
        {
            return CommonUtils.isNotBlank(patientLastName.Text) && CommonUtils.isNotBlank(patientFirstName.Text) &&
                CommonUtils.isNotBlank(patientSecondName.Text) && dutyCardioBox.SelectedIndex >= 0  &&
                cardioDocBox.SelectedIndex >= 0 && subDoctorBox.SelectedIndex >= 0 &&
                directorCardioReanimBox.SelectedIndex >= 0 && anesthetistComboBox.SelectedIndex >= 0;
        }


        private static string[] rus = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й",
          "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц",
          "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
        private static string[] eng = { "A", "B", "V", "G", "D", "E", "E", "ZH", "Z", "I", "Y",
          "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "KH", "TS",
          "CH", "SH", "SHCH", "", "Y", "", "E", "YU", "YA" };
        private string translit(string initials)
        {
            StringBuilder ret = new StringBuilder();
            for (int j = 0; j < initials.Length; j++)
                for (int i = 0; i < rus.Length; i++)
                    if (initials.Substring(j, 1) == rus[i]) ret.Append(eng[i]);
            return CommonUtils.isBlank(ret.ToString()) ? initials : ret.ToString();
        }

        private void OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       
    }
}
