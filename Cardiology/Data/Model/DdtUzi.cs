using System;

namespace Cardiology.Data
{
    public class DdtUzi : DdtTypedObject
    {
        public const string TABLE_NAME = "ddt_uzi";

        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dsid_patient")]
        private string dsidPatient;
        [TableAttribute("dsid_doctor")]
        private string dsidDoctor;
        [TableAttribute("dss_eho_kg")]
        private string dssEhoKg;
        [TableAttribute("dss_uzd_bca")]
        private string dssUzdBca;
        [TableAttribute("dss_cds")]
        private string dssCds;
        [TableAttribute("dss_uzi_obp")]
        private string dssUziObp;
        [TableAttribute("dss_pleurs_uzi")]
        private string dssPleursUzi;
        [TableAttribute("dsdt_analysis_date")]
        private DateTime dsdtAnalysisDate;
        [TableAttribute("dsid_parent")]
        private string dsidParent;
        [TableAttribute("dss_parent_type")]
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
