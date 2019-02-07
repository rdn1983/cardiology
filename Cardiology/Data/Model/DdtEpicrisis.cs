using System;

namespace Cardiology.Data.Model
{
    class DdtEpicrisis
    {
        public const string TABLE_NAME = "ddt_epicrisis";

        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [Table("dsid_patient")]
        private string dsidPatient;
        [Table("dsdt_epicrisis_date")]
        private DateTime dsdtEpicrisisDate;
        [Table("dsid_doctor")]
        private string dsidDoctor;
        [Table("dss_diagnosis")]
        private string dssDiagnosis;
        [Table("dsi_epicrisis_type")]
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
