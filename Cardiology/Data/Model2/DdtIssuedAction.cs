using System;

namespace Cardiology.Data.Model2
{
    public class DdtIssuedAction
    {
        public static readonly string NAME = "ddt_issued_action";

        public string HospitalitySession { get; set; }

        public string ObjectId { get; set; }

        public string ParentId { get; set; }

        public DateTime ModifyDate { get; set; }

        public string Action { get; set; }

        public string ParentType { get; set; }

        public DateTime CreationDate { get; set; }

        public string Doctor { get; set; }

        public DateTime IssuingDate { get; set; }

        public string Patient { get; set; }

    }
}
