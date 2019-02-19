using System;

namespace Cardiology.Data.Model2
{
    public class DdtSpecialistConclusion
    {
        public static readonly string NAME = "ddt_specialist_conclusion";

        public string ObjectId { get; set; }

        public DateTime AnalysisDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string Parent { get; set; }

        public string NeuroSurgeon { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public string Endocrinologist { get; set; }

        public string HospitalitySession { get; set; }

        public DateTime ModifyDate { get; set; }

        public string ParentType { get; set; }

        public string Neurolog { get; set; }

        public string Surgeon { get; set; }

    }
}
