using System;

namespace Cardiology.Data.Model2
{
    public class DmGroup
    {
        public static readonly string NAME = "dm_group";

        public string ObjectId { get; set; }

        public string Description { get; set; }

        public DateTime ModifyDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string Name { get; set; }

    }
}
