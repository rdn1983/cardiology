using System;

namespace Cardiology.Data.Model2
{
    public class DdtTransfer
    {
        public static readonly string NAME = "ddt_transfer";

        public string HospitalitySession { get; set; }

        public string ObjectId { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public string Destination { get; set; }

        public DateTime CreationDate { get; set; }

        public string TransferJustification { get; set; }

        public DateTime StartDate { get; set; }

        public string Doctor { get; set; }

        public int Type { get; set; }

        public string Contacts { get; set; }

        public string Patient { get; set; }

    }
}
