using System;

namespace Cardiology.Data.Model2
{
    public class DdtValues
    {
        public static readonly string NAME = "ddt_values";

        public string ObjectId { get; set; }

        public DateTime ModifyDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

    }
}
