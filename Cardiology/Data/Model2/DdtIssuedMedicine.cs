using System;

namespace Cardiology.Data.Model2
{
    public class DdtIssuedMedicine
    {
        public static readonly string NAME = "ddt_issued_medicine";

        public string MedList { get; set; }

        public string ObjectId { get; set; }

        public string Cure { get; set; }

        public DateTime ModifyDate { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
