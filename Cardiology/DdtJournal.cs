using System;

namespace Cardiology.Model

{
    public class DdtJournal
    {
        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dsid_patient")]
        private string dsidPatient;
        [TableAttribute("dsdt_admission_date")]
        private DateTime dsdtAdmissionDate;
        [TableAttribute("dsid_doctor")]
        private string dsidDoctor;
        [TableAttribute("dss_complaints")]
        private string dssComplaints;
        [TableAttribute("dss_chdd")]
        private string dssChdd;
        [TableAttribute("dss_chss")]
        private string dssChss;
        [TableAttribute("dss_ps")]
        private string dssPs;
        [TableAttribute("dss_ad")]
        private string dssAd;
        [TableAttribute("dss_monitor")]
        private string dssMonitor;
        [TableAttribute("dss_rhythm")]
        private string dssRhythm;
        [TableAttribute("dsb_good_rhythm")]
        private bool dsdGoodRhytm;
        [TableAttribute("dss_surgeon_exam")]
        private string dssSurgeonExam;
        [TableAttribute("dss_cardio_exam")]
        private string dssCardioExam;
    }
}
