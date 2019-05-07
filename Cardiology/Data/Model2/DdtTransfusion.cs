using System;

namespace Cardiology.Data.Model2
{
    public class DdtTransfusion
    {
        public static readonly string NAME = "ddt_transfusion";

        public string ObjectId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string HospitalitySession { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public DateTime TransfusionDate { get; set; }
        public string TransfusionMedium { get; set; }
        public string Consilium { get; set; }
        public string BloodAnalysis { get; set; }
        public string Consent { get; set; }
        public string RequestBlood { get; set; }
        public string Indications { get; set; }
      
    }
}
