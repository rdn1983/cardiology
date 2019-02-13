using System;

namespace Cardiology.Data.Model
{
    [Obsolete("Этот класс будет удален", false)]
    class DdtOncologicMarkers
    {
        public const string TABLE_NAME = "ddt_oncologic_markers";

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
        [Table("dsdt_analysis_date")]
        private DateTime dsdtAnalysisDate;
        [Table("dsid_parent")]
        private string dsidParent;
        [Table("dss_parent_type")]
        private string dssParentType;
        [Table("dss_psa_common")]
        private string dssPsaCommon;
        [Table("dss_psa_free")]
        private string dssPsaFree;
        [Table("dss_ca_199")]
        private string dssCa199;
        [Table("dss_ca_125")]
        private string dssCa125;
        [Table("dss_ca_153")]
        private string dssCa153;
        [Table("dss_cea")]
        private string dssCea;
        [Table("dss_hgch")]
        private string dssHgch;
        [Table("dss_afr")]
        private string dssAfr;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public DateTime DsdtAnalysisDate { get => dsdtAnalysisDate; set => dsdtAnalysisDate = value; }
        public string DsidParent { get => dsidParent; set => dsidParent = value; }
        public string DssParentType { get => dssParentType; set => dssParentType = value; }
        public string DssPsaCommon { get => dssPsaCommon; set => dssPsaCommon = value; }
        public string DssPsaFree { get => dssPsaFree; set => dssPsaFree = value; }
        public string DssCa199 { get => dssCa199; set => dssCa199 = value; }
        public string DssCa125 { get => dssCa125; set => dssCa125 = value; }
        public string DssCa153 { get => dssCa153; set => dssCa153 = value; }
        public string DssCea { get => dssCea; set => dssCea = value; }
        public string DssHgch { get => dssHgch; set => dssHgch = value; }
        public string DssAfr { get => dssAfr; set => dssAfr = value; }
    }
}
