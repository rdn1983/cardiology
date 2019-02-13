using System;

namespace Cardiology.Data.Model2
{
    public class DdtXray
    {
        public string ObjectId { get; set; }

        public DateTime AnalysisDate { get; set; }

        public string Mskt { get; set; }

        public DateTime CreationDate { get; set; }

        public string Kt { get; set; }

        public string Parent { get; set; }

        public string ChestXray { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public string HospitalitySession { get; set; }

        public DateTime ModifyDate { get; set; }

        public string ParentType { get; set; }

        public string Mrt { get; set; }

        public string ControlRadiography { get; set; }

        public DateTime KtDate { get; set; }

    }
}
