using System;

namespace Cardiology.Data.Model2
{
    public class DdtIssuedMedicineList
    {
        public string ObjectId { get; set; }

        public string HasKag { get; set; }

        public string ParentId { get; set; }

        public string Pharmacologist { get; set; }

        public string Diagnosis { get; set; }

        public DateTime CreationDate { get; set; }

        public string Director { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public string HospitalitySession { get; set; }

        public string Nurse { get; set; }

        public DateTime ModifyDate { get; set; }

        public string ParentType { get; set; }

        public string TemplateName { get; set; }

        public DateTime IssuingDate { get; set; }

        public bool SkipPrint { get; set; }

    }
}
