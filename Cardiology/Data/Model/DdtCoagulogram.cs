using System;

namespace Cardiology.Data
{
    public class DdtCoagulogram
    {
        public const string TABLE_NAME = "ddt_coagulogram";

        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsdt_analysis_date")]
        private DateTime dsdtAnalysisDate;
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dsid_patient")]
        private string dsidPatient;
        [TableAttribute("dsid_doctor")]
        private string dsidDoctor;
        [TableAttribute("dss_achtv")]
        private string dssAchtv;
        [TableAttribute("dss_mcho")]
        private string dssMcho;
        [TableAttribute("dss_ddimer")]
        private string dssDdimer;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public string DssAchtv { get => dssAchtv; set => dssAchtv = value; }
        public string DssMcho { get => dssMcho; set => dssMcho = value; }
        public string DssDdimer { get => dssDdimer; set => dssDdimer = value; }
        public DateTime DsdtAnalysisDate { get => dsdtAnalysisDate; set => dsdtAnalysisDate = value; }
    }
}
