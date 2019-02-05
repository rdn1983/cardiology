using System;

namespace Cardiology.Model
{
    public class DdtIssuedAction
    {
        public const string TABLE_NAME = "ddt_issued_action";

        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_doctor")]
        private string dsidDoctor;
        [TableAttribute("dsid_patient")]
        private string dsidPatient;
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dsid_parent_id")]
        private string dsidParentId;
        [TableAttribute("dss_parent_type")]
        private string dssParentType;
        [TableAttribute("dsdt_issuing_date")]
        private DateTime dsdtIssuingDate;
        [TableAttribute("dss_action")]
        private string dssAction;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidParentId { get => dsidParentId; set => dsidParentId = value; }
        public string DssParentType { get => dssParentType; set => dssParentType = value; }
        public DateTime DsdtIssuingDate { get => dsdtIssuingDate; set => dsdtIssuingDate = value; }
        public string DssAction { get => dssAction; set => dssAction = value; }
    }
}
