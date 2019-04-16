using System;

namespace Cardiology.Data.Model2
{
    public class DdtPatient
    {
        public static readonly string NAME = "ddt_patient";

        public string ObjectId { get; set; }

        public string Address { get; set; }

        public string MiddleName { get; set; }

        public string PassportNum { get; set; }

        public string FirstName { get; set; }

        public float Weight { get; set; }

        public DateTime CreationDate { get; set; }

        public string Snils { get; set; }

        public string LastName { get; set; }

        public DateTime PassportDate { get; set; }

        public string Phone { get; set; }

        public DateTime ModifyDate { get; set; }

        public string Oms { get; set; }

        public string PassportSerial { get; set; }

        public DateTime Birthdate { get; set; }

        public bool Sd { get; set; }

        public string MedCode { get; set; }

        public string PassportIssuePlace { get; set; }

        public float High { get; set; }

        public bool Sex { get; set; }

    }
}
