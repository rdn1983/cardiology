using System;

namespace Cardiology.Data.Model
{
    public class DdtDoctors
    {
        public const string TABLE_NAME = "ddt_doctors";

        [Table("r_object_id", false)]
        private string rObjecId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dss_login")]
        private string dssLogin;
        [Table("dss_full_name")]
        private string dssFullName;
        [Table("dss_initials")]
        private string dssInitials;
        [Table("dss_appointment_name")]
        private string dssAppointmentName;
        [Table("dss_phone")]
        private string dssPhone;
        [Table("dss_email")]
        private string dssEmail;
        [Table("dsi_appointment_type")]
        private int dsiAppointmentType;

        public string ObjectId {
            get { return rObjecId; }
            set {; }
        }
        public string DssLogin {
            get { return dssLogin; }
            set { this.dssLogin = value; }
        }
        public string DssFullName {
            get { return dssFullName; }
            set { this.dssFullName = value; }
        }
        public string DssInitials {
            get { return dssInitials; }
            set { this.dssInitials = value; }
        }
        public string DssAppointmentName {
            get { return dssAppointmentName; }
            set { this.dssAppointmentName = value; }
        }
        public string DssPhone {
            get { return dssPhone; }
            set { this.dssPhone = value; }
        }
        public string DssEmail {
            get { return dssEmail; }
            set { this.dssEmail = value; }
        }
        public int DsiAppointmentType {
            get { return dsiAppointmentType; }
            set { this.dsiAppointmentType = value; }
        }
        public DateTime CreationDate {
            get { return rCreationDate; }
            set {; }
        }
        
            
    }
}
