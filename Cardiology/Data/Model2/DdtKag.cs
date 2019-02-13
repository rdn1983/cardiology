using System;

namespace Cardiology.Data.Model2
{
    public class DdtKag
    {
        public string ObjectId { get; set; }

        public DateTime AnalysisDate { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime CreationDate { get; set; }

        public string Parent { get; set; }

        public string KagManipulation { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public string HospitalitySession { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime ModifyDate { get; set; }

        public string ParentType { get; set; }

        public string Results { get; set; }

        public string KagAction { get; set; }

    }
}
