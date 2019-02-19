using System;

namespace Cardiology.Data.Model2
{
    public class DdtSerology
    {
        public static readonly string NAME = "ddt_serology";

        public string ObjectId { get; set; }

        public DateTime AnalysisDate { get; set; }

        public string BloodType { get; set; }

        public DateTime CreationDate { get; set; }

        public string KellAg { get; set; }

        public string Phenotype { get; set; }

        public string Rw { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public string HbsAg { get; set; }

        public string AntiHcv { get; set; }

        public string HospitalitySession { get; set; }

        public DateTime ModifyDate { get; set; }

        public string Hiv { get; set; }

        public string RhesusFactor { get; set; }

    }
}
