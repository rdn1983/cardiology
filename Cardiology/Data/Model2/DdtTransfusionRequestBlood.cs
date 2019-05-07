using System;

namespace Cardiology.Data.Model2
{
    public class DdtTransfusionRequestBlood
    {
        public static readonly string NAME = "ddt_request_blood";

        public string HospitalitySession { get; set; }

        public string ObjectId { get; set; }

        public DateTime ModifyDate { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
