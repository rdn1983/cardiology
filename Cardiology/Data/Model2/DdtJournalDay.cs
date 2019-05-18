using System;
namespace Cardiology.Data.Model2
{
    public class DdtJournalDay
    {
        public static readonly string NAME = "ddt_journal_day";

        public string ObjectId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public string Name { get; set; }

        public DateTime AdmissionDate { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public string HospitalitySession { get; set; }

        public int JournalType { get; set; }

        public string Diagnosis { get; set; }

    }
}
