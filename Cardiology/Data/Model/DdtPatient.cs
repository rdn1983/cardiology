using System;

namespace Cardiology.Data.Model
{
    [Obsolete("Этот класс будет удален", false)]
    public class DdtPatient
    {
        public const string TABLE_NAME= "ddt_patient";

        [Table("r_object_id", false)]
        private string rObjectId;

        [Table("r_creation_date", false)]
        private DateTime rCreationDate;

        [Table("dss_initials")]
        private string dssInitials;

        [Table("dss_full_name")]
        private string dssFullName;

        [Table("dsdt_birthdate")]
        private DateTime dsdtBirthdate;

        [Table("dss_phone")]
        private string dssPhone;

        [Table("dss_address")]
        private string dssAddress;

        [Table("dsd_weight")]
        private double dsdWeight;

        [Table("dsd_high")]
        private double dsdHigh;

        [Table("dss_med_code")]
        private string dssMedCode;

        [Table("dss_snils")]
        private string dssSnils;

        [Table("dss_oms")]
        private string dssOms;

        [Table("dss_passport_serial")]
        private string dssPassportSerial;

        [Table("dss_passport_num")]
        private string dssPassportNum;

        [Table("dss_passport_date")]
        private DateTime dssPassportDate;

        [Table("dss_passport_issue_place")]
        private string dssPassportIssuePlace;

        [Table("dsb_sd")]
        private bool dsbSd;

        //add sex

        public string ObjectId
        {
            get {return rObjectId; }
        }

        public DateTime RCreationDate
        {
            get { return rCreationDate; }
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
        public string DssPassportSerial { get => dssPassportSerial; set => dssPassportSerial = value; }
        public string DssPassportNum { get => dssPassportNum; set => dssPassportNum = value; }
        public DateTime DssPassportDate { get => dssPassportDate; set => dssPassportDate = value; }
        public string DssPassportIssuePlace { get => dssPassportIssuePlace; set => dssPassportIssuePlace = value; }
        public bool DsbSd { get => dsbSd; set => dsbSd = value; }
    }
}
