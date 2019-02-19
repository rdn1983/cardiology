using System;

namespace Cardiology.Data.Model2
{
    public class DdtConsiliumGroupMember
    {
        public static readonly string NAME = "ddt_consilium_group_member";

        public string ObjectId { get; set; }

        public DateTime ModifyDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string Name { get; set; }

        public string Doctor { get; set; }

        public string Group { get; set; }

    }
}
