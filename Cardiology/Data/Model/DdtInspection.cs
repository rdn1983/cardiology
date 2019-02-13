using System;

namespace Cardiology.Data.Model
{
    [Obsolete("Этот класс будет удален", false)]
    class DdtInspection
    {

        public const string TABLE_NAME = "ddt_inspection";

        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [Table("dsid_patient")]
        private string dsidPatient;
        [Table("dsdt_inspection_date")]
        private DateTime dsdtInspectionDate;
        [Table("dsid_doctor")]
        private string dsidDoctor;
        [Table("dss_complaints")]
        private string dssComplaints;
        [Table("dss_diagnosis")]
        private string dssDiagnosis;
        [Table("dss_inspection")]
        private string dssInspection;
        [Table("dss_kateter_placement")]
        private string dssKateterPlacement;
        [Table("dss_inspection_result")]
        private string dssInspectionResult;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public DateTime DsdtInspectionDate { get => dsdtInspectionDate; set => dsdtInspectionDate = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public string DssComplaints { get => dssComplaints; set => dssComplaints = value; }
        public string DssDiagnosis { get => dssDiagnosis; set => dssDiagnosis = value; }
        public string DssInspection { get => dssInspection; set => dssInspection = value; }
        public string DssKateterPlacement { get => dssKateterPlacement; set => dssKateterPlacement = value; }
        public string DssInspectionResult { get => dssInspectionResult; set => dssInspectionResult = value; }
    }
}
