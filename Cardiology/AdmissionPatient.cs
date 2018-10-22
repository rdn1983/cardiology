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
        private DdtPatient patient;
        private DdtHospital hospital;

        public AdmissionPatient(DdtHospital hospital, DdtPatient patient)
        {
            this.hospital = hospital;
            this.patient = patient;
            InitializeComponent();
            System.Drawing.Size halfScreenSize = new System.Drawing.Size(SystemInformation.PrimaryMonitorSize.Width / 2,
                SystemInformation.PrimaryMonitorSize.Height);
            this.patientBaseInfoBox.MaximumSize = halfScreenSize;
            this.lordOfTheCotBox.MaximumSize = halfScreenSize;
            initDutyDoctors();
            initControls();
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

        private void initControls()
        {
            if (hospital == null || patient == null)
            {
                return;
            }
            DataService service = new DataService();
            addressTxt.Text = patient.DssAddress;
            string[] fio = patient.DssFullName.Split(' ');
            patientLastName.Text = fio[0];
            patientFirstName.Text = fio[1];
            patientSecondName.Text = fio[2];
            medCodeTxt.Text = patient.DssMedCode;
            phoneTxt.Text = patient.DssPhone;
            snilsTxt.Text = patient.DssSnils;
            omsTxt.Text = patient.DssOms;
            passportDataTxt.Text = patient.DssPassportDate.ToString();
            passportIssuePlaceTxt.Text = patient.DssPassportIssuePlace;
            passportNumTxt.Text = patient.DssPassportNum;
            passportSerialTxt.Text = patient.DssPassportSerial;
            weightTxt.Text = patient.DsdWeight.ToString();
            highTxt.Text = patient.DsdHigh.ToString();
            patientBirthDate.Text = patient.DsdtBirthdate.ToString();

            patientReceiptDate.Value = hospital.DsdtAdmissionDate;
            patientReceiptTime.Text = hospital.DsdtAdmissionDate.TimeOfDay.ToString();

            DdtDoctors docDuty = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, hospital.DsidDutyDoctor);
            dutyCardioBox.SelectedIndex = dutyCardioBox.FindStringExact(docDuty.DssInitials);
            DdtDoctors docCuring = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, hospital.DsidCuringDoctor);
            cardioDocBox.SelectedIndex = cardioDocBox.FindStringExact(docCuring.DssInitials);
            DdtDoctors docSubstitution = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, hospital.DsidSubstitutionDoctor);
            subDoctorBox.SelectedIndex = subDoctorBox.FindStringExact(docSubstitution.DssInitials);

            string[] roomCell = hospital.DssRoomCell.Split('/');
            roomTxt.Text = roomCell[0];
            bedTxt.Text = roomCell[1];
        }

        private void admisPatient_Click(object sender, EventArgs e)
        {
            if (!getIsValid())
            {
                MessageBox.Show("Заполните поля помеченные жирным шрифтом!", "Warning", MessageBoxButtons.OK);
                return;
            }

            if (patient == null)
            {
                patient = new DdtPatient();
                //todo Сделаь проверку на существующий логин
                patient.DssLogin = translit(patientLastName.Text.Trim() + patientFirstName.Text.Substring(0, 1) + patientSecondName.Text.Substring(0, 1));
            }
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
            String patientId = service.updateOrCreateIfNeedObject(patient, DdtPatient.TABLENAME, patient.ObjectId);

            if (hospital == null)
            {
                hospital = new DdtHospital();
                hospital.DsidPatient = patientId;
            }
            hospital.DsbActive = true;
            hospital.DsdtAdmissionDate = CommonUtils.constructDateWIthTime(patientReceiptDate.Value, patientReceiptTime.Value);
            DdtDoctors docDuty = (DdtDoctors)dutyCardioBox.SelectedItem;
            hospital.DsidDutyDoctor = docDuty.ObjectId;
            DdtDoctors docCuring = (DdtDoctors)cardioDocBox.SelectedItem;
            hospital.DsidCuringDoctor = docCuring.ObjectId;
            DdtDoctors docSubstitution = (DdtDoctors)subDoctorBox.SelectedItem;
            hospital.DsidSubstitutionDoctor = docSubstitution.ObjectId;
            hospital.DssRoomCell = roomTxt.Text + "/" + bedTxt.Text;
            service.updateOrCreateIfNeedObject(hospital, DdtHospital.TABLENAME, hospital.ObjectId);
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

        private void AdmissionPatient_Resize(object sender, EventArgs e)
        {
            System.Drawing.Size halfScreenSize = new System.Drawing.Size(this.Size.Width / 2,
               this.Size.Height);
            this.patientBaseInfoBox.Size = halfScreenSize;
            this.lordOfTheCotBox.Size = halfScreenSize;
            System.Drawing.Point startLocation = patientBaseInfoBox.Location;
            lordOfTheCotBox.Location = new System.Drawing.Point(startLocation.X + patientBaseInfoBox.Width, startLocation.Y);
        }
    }
}
