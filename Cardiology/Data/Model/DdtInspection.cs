using System;

namespace Cardiology.Data
{
    class DdtInspection
    {

        public const string TABLE_NAME = "ddt_inspection";

        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dsid_patient")]
        private string dsidPatient;
        [TableAttribute("dsdt_inspection_date")]
        private DateTime dsdtInspectionDate;
        [TableAttribute("dsid_doctor")]
        private string dsidDoctor;
        [TableAttribute("dss_complaints")]
        private string dssComplaints;
        [TableAttribute("dss_diagnosis")]
        private string dssDiagnosis;
        [TableAttribute("dss_inspection")]
        private string dssInspection;
        [TableAttribute("dss_kateter_placement")]
        private string dssKateterPlacement;
        [TableAttribute("dss_inspection_result")]
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
