
using System;

namespace Cardiology.Data.Model
{
    public class DdtHormones : DdtTypedObject
    {
        public const string TABLE_NAME = "ddt_hormones";

        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [Table("dsid_patient")]
        private string dsidPatient;
        [Table("dsid_doctor")]
        private string dsidDoctor;
        [Table("dss_t3")]
        private string dssT3;
        [Table("dss_t4")]
        private string dssT4;
        [Table("dss_ttg")]
        private string dssTtg;
        [Table("dsdt_analysis_date")]
        private DateTime dsdtAnalysisDate;


        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public string DssT3 { get => dssT3; set => dssT3 = value; }
        public string DssT4 { get => dssT4; set => dssT4 = value; }
        public string DssTtg { get => dssTtg; set => dssTtg = value; }
        public DateTime DsdtAnalysisDate { get => dsdtAnalysisDate; set => dsdtAnalysisDate = value; }
    }
}