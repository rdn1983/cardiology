using System;

namespace Cardiology.Data.Model2
{
    public class DdtPatientV2: DmPersistent
    {
        public string Initials { get; set; }
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double Weight { get; set; }
        public double High { get; set; }
        public string MedCode { get; set; }
        public string Snils { get; set; }
        public string Oms { get; set; }
        public string PassportSerial { get; set; }
        public string PassportNum { get; set; }
        public DateTime PassportDate { get; set; }
        public string PassportIssuePlace { get; set; }
        public bool Sd { get; set; }
    }
}
