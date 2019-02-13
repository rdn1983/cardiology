using System;

namespace Cardiology.Data.Model2
{
    public class DdtInspection
    {
        public string HospitalitySession { get; set; }

        public string ObjectId { get; set; }

        public DateTime InspectionDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public string Diagnosis { get; set; }

        public string KateterPlacement { get; set; }

        public DateTime CreationDate { get; set; }

        public string Complaints { get; set; }

        public string Inspection { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public string InspectionResult { get; set; }

    }
}
