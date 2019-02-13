using System;

namespace Cardiology.Data.Model2
{
    public class DdtUrineAnalysis
    {
        public string Ketones { get; set; }

        public string ObjectId { get; set; }

        public DateTime AnalysisDate { get; set; }

        public string SpecificGravity { get; set; }

        public string Erythrocytes { get; set; }

        public DateTime CreationDate { get; set; }

        public string Parent { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public string HospitalitySession { get; set; }

        public string Acidity { get; set; }

        public DateTime ModifyDate { get; set; }

        public string ParentType { get; set; }

        public string Leukocytes { get; set; }

        public bool AdmissionAnalysis { get; set; }

        public string Color { get; set; }

        public bool DischargeAnalysis { get; set; }

        public string Protein { get; set; }

        public string Glucose { get; set; }

    }
}
