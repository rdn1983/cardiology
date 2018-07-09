using System;

namespace Cardiology.Model
{
    public class DdtPatient
    {
        public const string TABLENAME= "ddt_patient";
        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dss_login")]
        private string dssLogin;
        [TableAttribute("dss_initials")]
        private string dssInitials;
        [TableAttribute("dss_full_name")]
        private string dssFullName;
        [TableAttribute("dsdt_birthdate")]
        private DateTime dsdtBirthdate;
        [TableAttribute("dss_phone")]
        private string dssPhone;
        [TableAttribute("dss_address")]
        private string dssAddress;
        [TableAttribute("dsd_weight")]
        private double dsdWeight;
        [TableAttribute("dsd_high")]
        private double dsdHigh;
        [TableAttribute("dss_med_code")]
        private string dssMedCode;
        [TableAttribute("dss_snils")]
        private string dssSnils;
        [TableAttribute("dss_oms")]
        private string dssOms;

        //add sex

        public string ObjectId
        {
            get {return rObjectId; }
        }
        public DateTime RCreationDate
        {
            get { return rCreationDate; }
        }
        public string DssLogin
        {
            get { return dssLogin; }
            set {this.dssLogin = value; }
        }
        public string DssInitials
        {
            get { return dssInitials; }
            set { this.dssInitials = value; }
        }
        public string DssFullName
        {
            get { return dssFullName; }
            set { this.dssFullName = value; }
        }
        public DateTime DsdtBirthdate
        {
            get { return dsdtBirthdate; }
            set { this.dsdtBirthdate = value; }
        }
        public string DssPhone
        {
            get { return dssPhone; }
            set { this.dssPhone = value; }
        }
        public string DssAddress
        {
            get { return dssAddress; }
            set { this.dssAddress = value; }
        }
        public double DsdWeight
        {
            get { return dsdWeight; }
            set { this.dsdWeight = value; }
        }
        public double DsdHigh
        {
            get { return dsdHigh; }
            set { this.dsdHigh = value; }
        }
        public string DssMedCode
        {
            get { return dssMedCode; }
            set { this.dssMedCode = value; }
        }

        public string DssSnils { get => dssSnils; set => dssSnils = value; }
        public string DssOms { get => dssOms; set => dssOms = value; }
    }
}
