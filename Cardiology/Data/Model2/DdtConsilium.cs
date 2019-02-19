using System;

namespace Cardiology.Data.Model2
{
    public class DdtConsilium
    {
        public static readonly string NAME = "ddt_consilium";

        public string HospitalitySession { get; set; }

        public string ObjectId { get; set; }

        public string Goal { get; set; }

        public string Dynamics { get; set; }

        public DateTime ModifyDate { get; set; }

        public string DutyAdminName { get; set; }

        public string Diagnosis { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ConsiliumDate { get; set; }

        public string Decision { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

    }
}
