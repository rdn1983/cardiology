using System;

namespace Cardiology.Data.Model
{
    [Obsolete("Этот класс будет удален", false)]
    public class DdtConsilium
    {
        public const string TABLE_NAME = "ddt_consilium";
        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [Table("dsid_doctor")]
        private string dsidDoctor;
        [Table("dsid_patient")]
        private string dsidPatient;
        [Table("dss_goal")]
        private string dssGoal;
        [Table("dss_dynamics")]
        private string dssDynamics;
        [Table("dss_diagnosis")]
        private string dssDiagnosis;
        [Table("dss_decision")]
        private string dssDecision;
        [Table("dss_duty_admin_name")]
        private string dssDutyAdminName;
        [Table("dsdt_consilium_date")]
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
