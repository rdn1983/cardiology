using System;

namespace Cardiology.Data.Model2
{
    public class DdtHistory
    {
        public static readonly string NAME = "ddt_history";

        public string ObjectId { get; set; }

        public string OperationId { get; set; }

        public DateTime OperationDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public string OperationName { get; set; }

        public string HospitalitySession { get; set; }

        public bool Deleted { get; set; }

        public string Description { get; set; }

        public DateTime ModifyDate { get; set; }

        public DateTime DeleteDate { get; set; }

        public string OperationType { get; set; }

    }
}
