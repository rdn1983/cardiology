using System;

namespace Cardiology.Data.Model2
{
    public class DdtConsiliumRelation
    {
        public static readonly string NAME = "ddt_consilium_relation";

        public string ObjectId { get; set; }

        public DateTime ModifyDate { get; set; }

        public string Consilium { get; set; }

        public DateTime CreationDate { get; set; }

        public string Member { get; set; }

    }
}
