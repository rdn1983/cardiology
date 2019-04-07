using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class PatientAdmission : Form
    {
        private readonly IDbDataService service;
        private DdtHospital hospital;

        public PatientAdmission(IDbDataService service, DdtHospital hospital)
        {
            this.service = service;
            this.hospital = hospital;
            InitializeComponent();
            System.Drawing.Size halfScreenSize = new System.Drawing.Size(SystemInformation.PrimaryMonitorSize.Width / 2,
                SystemInformation.PrimaryMonitorSize.Height);
            this.patientBaseInfoBox.MaximumSize = halfScreenSize;
            this.lordOfTheCotBox.MaximumSize = halfScreenSize;
            InitDutyDoctors();
            InitControls();
        }

        private void InitDutyDoctors()
        {

            ControlUtils.InitDoctorsByGroupName(service.GetDdvDoctorService(), dutyCardioBox, "cardioreanimation_department");
            ControlUtils.InitDoctorsByGroupNameAndOrder(service.GetDdvDoctorService(), directorCardioReanimBox, "cardioreanimation_department", "admission.cardioreanimation_department_head");           
            ControlUtils.InitDoctorsByGroupName(service.GetDdvDoctorService(), cardioDocBox, "xray_department");
            ControlUtils.InitDoctorsByGroupNameAndOrder(service.GetDdvDoctorService(), subDoctorBox, "xray_department", "admission.xray_department");
            ControlUtils.InitDoctorsByGroupName(service.GetDdvDoctorService(), anesthetistComboBox, "anesthesiology_department");
        }

        private void InitControls()
        {
            if (hospital == null)
            {
                return;
            }

            DdvPatient patient = service.GetDdvPatientService().GetById(hospital.Patient);
            addressTxt.Text = patient.Address;
            patientLastName.Text = patient.LastName;
            patientFirstName.Text = patient.FirstName;
            patientSecondName.Text = patient.MiddleName;
            medCodeTxt.Text = patient.MedCode;
            phoneTxt.Text = patient.Phone;
            snilsTxt.Text = patient.Snils;
            omsTxt.Text = patient.Oms;
            passportDataTxt.Value = patient.PassportDate;
            passportIssuePlaceTxt.Text = patient.PassportIssuePlace;
            passportNumTxt.Text = patient.PassportNum;
            passportSerialTxt.Text = patient.PassportSerial;
            weightTxt.Text = patient.Weight.ToString(CultureInfo.InvariantCulture);
            highTxt.Text = patient.High.ToString(CultureInfo.InvariantCulture);
            patientBirthDate.Value = patient.Birthdate;
            sdBtn.Checked = patient.Sd;
            maleChb.Checked = patient.Sex == 0;
            femaleChb.Checked = patient.Sex == 1;

            patientReceiptDate.Value = hospital.AdmissionDate;
            patientReceiptTime.Text = hospital.AdmissionDate.TimeOfDay.ToString();

            DdvDoctor docDuty = service.GetDdvDoctorService().GetById(hospital.DutyDoctor);
            dutyCardioBox.SelectedIndex = dutyCardioBox.FindStringExact(docDuty.ShortName);

            DdvDoctor docCuring = service.GetDdvDoctorService().GetById(hospital.CuringDoctor);
            cardioDocBox.SelectedIndex = cardioDocBox.FindStringExact(docCuring.ShortName);

            DdvDoctor docSubstitution = service.GetDdvDoctorService().GetById(hospital.SubstitutionDoctor);
            subDoctorBox.SelectedIndex = subDoctorBox.FindStringExact(docSubstitution.ShortName);

            DdvDoctor directorCardioReanim = service.GetDdvDoctorService().GetById(hospital.DirCardioReanimDoctor);
            directorCardioReanimBox.SelectedIndex = directorCardioReanimBox.FindStringExact(directorCardioReanim.ShortName);

            DdvDoctor anesthetistDoctor = service.GetDdvDoctorService().GetById(hospital.AnesthetistDoctor);
            anesthetistComboBox.SelectedIndex = anesthetistComboBox.FindStringExact(anesthetistDoctor.ShortName);

            roomTxt.Text = hospital.RoomCell;
        }

        private void admisPatient_Click(object sender, EventArgs e)
        {
            if (!GetIsValid())
            {
                MessageBox.Show("Заполните поля помеченные жирным шрифтом!", "Warning", MessageBoxButtons.OK);
                return;
            }

            DdvPatient patient = service.GetDdvPatientService().GetById(hospital?.Patient);
            if (patient == null)
            {
                patient = new DdvPatient();
            }
            patient.Address = addressTxt.Text.Trim();
            patient.LastName = patientLastName.Text.Trim();
            patient.MiddleName = patientSecondName .Text.Trim();
            patient.FirstName = patientFirstName.Text.Trim();
            patient.MedCode = medCodeTxt.Text.Trim();
            patient.Phone = phoneTxt.Text;
            patient.Snils = snilsTxt.Text;
            patient.Oms = omsTxt.Text;
            patient.PassportDate = passportDataTxt.Value;
            patient.PassportIssuePlace = passportIssuePlaceTxt.Text;
            patient.PassportNum = passportNumTxt.Text;
            patient.PassportSerial = passportSerialTxt.Text;
            patient.Sd = sdBtn.Checked;
            patient.Sex = maleChb.Checked ? 0 : 1;

            if (!string.IsNullOrEmpty(weightTxt.Text))
            {
                patient.Weight = (float) Double.Parse(weightTxt.Text.Trim());
            }
            if (!string.IsNullOrEmpty(highTxt.Text))
            {
                patient.High = (float) Double.Parse(highTxt.Text.Trim());
            }
            patient.Birthdate = DateTime.ParseExact(patientBirthDate.Text.Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            String patientId = service.GetDdtPatientService().Save(patient);

            if (hospital == null)
            {
                hospital = new DdtHospital();
                hospital.Patient = patientId;
            }
            hospital.Active = true;
            hospital.AdmissionDate = CommonUtils.ConstructDateWIthTime(patientReceiptDate.Value, patientReceiptTime.Value);
            DdvDoctor docDuty = (DdvDoctor)dutyCardioBox.SelectedItem;
            hospital.DutyDoctor = docDuty.ObjectId;
            DdvDoctor docCuring = (DdvDoctor)cardioDocBox.SelectedItem;
            hospital.CuringDoctor = docCuring.ObjectId;
            DdvDoctor docSubstitution = (DdvDoctor)subDoctorBox.SelectedItem;
            hospital.SubstitutionDoctor = docSubstitution.ObjectId;
            DdvDoctor directorCardioReanim = (DdvDoctor)directorCardioReanimBox.SelectedItem;
            hospital.DirCardioReanimDoctor = directorCardioReanim.ObjectId;
            DdvDoctor anesthetistDoctor = (DdvDoctor)anesthetistComboBox.SelectedItem;
            hospital.AnesthetistDoctor = anesthetistDoctor.ObjectId;

            hospital.RoomCell = roomTxt.Text?? roomTxt.Text.Trim();
            service.GetDdtHospitalService().Save(hospital);
            //todo перенести в статусную строку
            Close();
        }

        private bool GetIsValid()
        {
            return !string.IsNullOrEmpty(patientLastName.Text) && !string.IsNullOrEmpty(patientFirstName.Text) &&
                !string.IsNullOrEmpty(patientSecondName.Text) && dutyCardioBox.SelectedIndex >= 0 &&
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
            return string.IsNullOrEmpty(ret.ToString()) ? initials : ret.ToString();
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
