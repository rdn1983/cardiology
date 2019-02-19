using System;

namespace Cardiology.Data.Model2
{
    public class DdtHormones
    {
        public static readonly string NAME = "ddt_hormones";

        public string HospitalitySession { get; set; }

        public string ObjectId { get; set; }

        public string Ttg { get; set; }

        public DateTime AnalysisDate { get; set; }

        public string T3 { get; set; }

        public DateTime ModifyDate { get; set; }

        public string T4 { get; set; }

        public DateTime CreationDate { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

    }
}
