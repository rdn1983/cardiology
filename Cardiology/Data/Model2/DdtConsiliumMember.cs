using System;

namespace Cardiology.Data.Model2
{
    public class DdtConsiliumMember
    {
        public static readonly string NAME = "ddt_consilium_member";

        public string ObjectId { get; set; }

        public DateTime ModifyDate { get; set; }

        public string Consilium { get; set; }

        public DateTime CreationDate { get; set; }

        public string Doctor { get; set; }

    }
}
