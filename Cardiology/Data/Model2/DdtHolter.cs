using System;

namespace Cardiology.Data.Model2
{
    public class DdtHolter
    {
        public static readonly string NAME = "ddt_holter";

        public string HospitalitySession { get; set; }

        public string ObjectId { get; set; }

        public DateTime AnalysisDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public string MonitoringAd { get; set; }

        public string ParentType { get; set; }

        public DateTime CreationDate { get; set; }

        public string Parent { get; set; }

        public string Holter { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

    }
}
