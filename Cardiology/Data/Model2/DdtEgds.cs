using System;

namespace Cardiology.Data.Model2
{
    public class DdtEgds
    {
        public string HospitalitySession { get; set; }

        public string ObjectId { get; set; }

        public DateTime AnalysisDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public string Egds { get; set; }

        public string ParentType { get; set; }

        public DateTime CreationDate { get; set; }

        public bool AdmissionAnalysis { get; set; }

        public string Parent { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

    }
}
