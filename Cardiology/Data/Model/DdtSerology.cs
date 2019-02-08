using System;

namespace Cardiology.Data.Model
{
    public class DdtSerology
    {
        public const string TABLE_NAME = "ddt_serology";

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
        [Table("dss_blood_type")]
        private string dssBloodType;
        [Table("dss_phenotype")]
        private string dssPhenotype;
        [Table("dss_rhesus_factor")]
        private string dssRhesusFactor;
        [Table("dss_kell_ag")]
        private string dssKellAg;
        [Table("dss_rw")]
        private string dssRw;
        [Table("dss_hbs_ag")]
        private string dssHbsAg;
        [Table("dss_anti_hcv")]
        private string dssAntiHcv;
        [Table("dss_hiv")]
        private string dssHiv;
        [Table("dsdt_analysis_date")]
        private DateTime dsdtAnalysisDate;


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

        public string DssBloodType
        {
            get { return dssBloodType; }
            set { this.dssBloodType = value; }
        }

        public string DssRhesusFactor { get { return dssRhesusFactor; } set { this.dssRhesusFactor = value; } }
        public string DssKellAg { get => dssKellAg; set => dssKellAg = value; }
        public string DssRw { get => dssRw; set => dssRw = value; }
        public string DssHbsAg { get => dssHbsAg; set => dssHbsAg = value; }
        public string DssAntiHcv {
            get { return dssAntiHcv; }
            set{this.dssAntiHcv = value;} }
        public string DssHiv { get => dssHiv; set => dssHiv = value; }
        public string DssPhenotype { get => dssPhenotype; set => dssPhenotype = value; }
        public DateTime DsdtAnalysisDate { get => dsdtAnalysisDate; set => dsdtAnalysisDate = value; }
    }
}
