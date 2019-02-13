using System;

namespace Cardiology.Data.Model2
{
    public class DdtJournal
    {
        public string ObjectId { get; set; }

        public string Diagnosis { get; set; }

        public string Chss { get; set; }

        public string Chdd { get; set; }

        public DateTime CreationDate { get; set; }

        public string Complaints { get; set; }

        public string SurgeonExam { get; set; }

        public string Ekg { get; set; }

        public DateTime AdmissionDate { get; set; }

        public string Monitor { get; set; }

        public string Rhythm { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public string Ps { get; set; }

        public string Ad { get; set; }

        public string HospitalitySession { get; set; }

        public DateTime ModifyDate { get; set; }

        public string CardioExam { get; set; }

        public int JournalType { get; set; }

        public bool GoodRhythm { get; set; }

        public bool ReleaseJournal { get; set; }

        public string Journal { get; set; }

    }
}
