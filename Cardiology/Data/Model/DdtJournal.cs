using System;

namespace Cardiology.Data.Model

{
    public class DdtJournal
    {
        public const string TABLE_NAME = "ddt_journal";
        
        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [Table("dsid_patient")]
        private string dsidPatient;
        [Table("dsdt_admission_date")]
        private DateTime dsdtAdmissionDate;
        [Table("dsid_doctor")]
        private string dsidDoctor;
        [Table("dss_complaints")]
        private string dssComplaints;
        [Table("dss_chdd")]
        private string dssChdd;
        [Table("dss_chss")]
        private string dssChss;
        [Table("dss_ps")]
        private string dssPs;
        [Table("dss_ad")]
        private string dssAd;
        [Table("dss_monitor")]
        private string dssMonitor;
        [Table("dss_rhythm")]
        private string dssRhythm;
        [Table("dsb_good_rhythm")]
        private bool dsbGoodRhytm;
        [Table("dss_surgeon_exam")]
        private string dssSurgeonExam;
        [Table("dss_cardio_exam")]
        private string dssCardioExam;
        [Table("dss_journal")]
        private string dssJournal;
        [Table("dss_ekg")]
        private string dssEkg;
        [Table("dsi_journal_type")]
        private int dsiJournalType;
        [Table("dsb_release_journal")]
        private bool dsbReleaseJournal;
        [Table("dss_diagnosis")]
        private string dssDiagnosis;

        public string RObjectId { get => rObjectId; }
        public DateTime RCreationDate { get => rCreationDate; }
        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public DateTime DsdtAdmissionDate { get => dsdtAdmissionDate; set => dsdtAdmissionDate = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public string DssComplaints { get => dssComplaints; set => dssComplaints = value; }
        public string DssChdd { get => dssChdd; set => dssChdd = value; }
        public string DssChss { get => dssChss; set => dssChss = value; }
        public string DssPs { get => dssPs; set => dssPs = value; }
        public string DssAd { get => dssAd; set => dssAd = value; }
        public string DssMonitor { get => dssMonitor; set => dssMonitor = value; }
        public string DssRhythm { get => dssRhythm; set => dssRhythm = value; }
        public string DssSurgeonExam { get => DssSurgeonExam1; set => DssSurgeonExam1 = value; }
        public bool DsbGoodRhytm { get => dsbGoodRhytm; set => dsbGoodRhytm = value; }
        public string DssSurgeonExam1 { get => dssSurgeonExam; set => dssSurgeonExam = value; }
        public string DssCardioExam { get => dssCardioExam; set => dssCardioExam = value; }
        public string DssJournal { get => dssJournal; set => dssJournal = value; }
        public int DsiJournalType { get => dsiJournalType; set => dsiJournalType = value; }
        public string DssEkg { get => dssEkg; set => dssEkg = value; }
        public bool DsbReleaseJournal { get => dsbReleaseJournal; set => dsbReleaseJournal = value; }
        public string DssDiagnosis { get => dssDiagnosis; set => dssDiagnosis = value; }
    }
}
