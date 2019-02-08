using System;

namespace Cardiology.Data.Model
{
    public class DdtUzi
    {
        public const string TABLE_NAME = "ddt_uzi";

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
        [Table("dss_eho_kg")]
        private string dssEhoKg;
        [Table("dss_uzd_bca")]
        private string dssUzdBca;
        [Table("dss_cds")]
        private string dssCds;
        [Table("dss_uzi_obp")]
        private string dssUziObp;
        [Table("dss_pleurs_uzi")]
        private string dssPleursUzi;
        [Table("dsdt_analysis_date")]
        private DateTime dsdtAnalysisDate;
        [Table("dsid_parent")]
        private string dsidParent;
        [Table("dss_parent_type")]
        private string dssParentType;

        public string ObjectId
        {
            get { return rObjectId; }
        }

        public DateTime RCreationDate
        {
            get { return rCreationDate; }
        }

        public string DsidHospitalitySession
        {
            get { return dsidHospitalitySession; }
            set { this.dsidHospitalitySession = value; }
        }

        public string DsidPatient
        {
            get { return dsidPatient; }
            set { this.dsidPatient = value; }
        }

        public string DsidDoctor
        {
            get { return dsidDoctor; }
            set { this.dsidDoctor = value; }
        }

        public string DssEhoKg { get => dssEhoKg; set => dssEhoKg = value; }
        public string DssUzdBca { get => dssUzdBca; set => dssUzdBca = value; }
        public string DssCds { get => dssCds; set => dssCds = value; }
        public string DssUziObp { get => dssUziObp; set => dssUziObp = value; }
        public string DssPleursUzi { get => dssPleursUzi; set => dssPleursUzi = value; }
        public DateTime DsdtAnalysisDate { get => dsdtAnalysisDate; set => dsdtAnalysisDate = value; }
        public string DsidParent { get => dsidParent; set => dsidParent = value; }
        public string DssParentType { get => dssParentType; set => dssParentType = value; }
    }
}
