using System;

namespace Cardiology.Data.Model2
{
    public class DdtConsiliumGroupLevel
    {
        public static readonly string NAME = "ddt_consilium_group_level";

        public string ObjectId { get; set; }

        public int Level { get; set; }

        public string Group { get; set; }

    }
}
