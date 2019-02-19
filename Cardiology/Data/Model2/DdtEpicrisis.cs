using System;

namespace Cardiology.Data.Model2
{
    public class DdtEpicrisis
    {
        public static readonly string NAME = "ddt_epicrisis";

        public string HospitalitySession { get; set; }

        public string ObjectId { get; set; }

        public DateTime ModifyDate { get; set; }

        public DateTime EpicrisisDate { get; set; }

        public string Diagnosis { get; set; }

        public DateTime CreationDate { get; set; }

        public int EpicrisisType { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

    }
}
