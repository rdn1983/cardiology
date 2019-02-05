using System;

namespace Cardiology.Model
{
    class DdtEpicrisis
    {
        public const string TABLE_NAME = "ddt_epicrisis";

        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dsid_patient")]
        private string dsidPatient;
        [TableAttribute("dsdt_epicrisis_date")]
        private DateTime dsdtEpicrisisDate;
        [TableAttribute("dsid_doctor")]
        private string dsidDoctor;
        [TableAttribute("dss_diagnosis")]
        private string dssDiagnosis;
        [TableAttribute("dsi_epicrisis_type")]
        private int dsiEpicrisisType;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public string DssDiagnosis { get => dssDiagnosis; set => dssDiagnosis = value; }
        public DateTime DsdtEpicrisisDate { get => dsdtEpicrisisDate; set => dsdtEpicrisisDate = value; }
        public int DsiEpicrisisType { get => dsiEpicrisisType; set => dsiEpicrisisType = value; }
    }
}
