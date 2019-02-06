using System;

namespace Cardiology.Data
{
    public class DdtConsilium
    {
        public const string TABLE_NAME = "ddt_consilium";
        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dsid_doctor")]
        private string dsidDoctor;
        [TableAttribute("dsid_patient")]
        private string dsidPatient;
        [TableAttribute("dss_goal")]
        private string dssGoal;
        [TableAttribute("dss_dynamics")]
        private string dssDynamics;
        [TableAttribute("dss_diagnosis")]
        private string dssDiagnosis;
        [TableAttribute("dss_decision")]
        private string dssDecision;
        [TableAttribute("dss_duty_admin_name")]
        private string dssDutyAdminName;
        [TableAttribute("dsdt_consilium_date")]
        private DateTime dsdtConsiliumDate;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public string DssGoal { get => dssGoal; set => dssGoal = value; }
        public string DssDynamics { get => dssDynamics; set => dssDynamics = value; }
        public string DssDiagnosis { get => dssDiagnosis; set => dssDiagnosis = value; }
        public string DssDecision { get => dssDecision; set => dssDecision = value; }
        public string DssDutyAdminName { get => dssDutyAdminName; set => dssDutyAdminName = value; }
        public DateTime DsdtConsiliumDate { get => dsdtConsiliumDate; set => dsdtConsiliumDate = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
    }
}
