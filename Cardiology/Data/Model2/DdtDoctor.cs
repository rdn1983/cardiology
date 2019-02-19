using System;

namespace Cardiology.Data.Model2
{
    public class DdtDoctor
    {
        public static readonly string NAME = "ddt_cure_type";

        public string ObjectId { get; set; }

        public string MiddleName { get; set; }

        public string FirstName { get; set; }

        public DateTime ModifyDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string LastName { get; set; }

    }
}
