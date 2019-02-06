using System;

namespace Cardiology.Data
{
    public class DdtSerology : DdtTypedObject
    {
        public const string TABLE_NAME = "ddt_serology";

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
        [TableAttribute("dss_blood_type")]
        private string dssBloodType;
        [TableAttribute("dss_phenotype")]
        private string dssPhenotype;
        [TableAttribute("dss_rhesus_factor")]
        private string dssRhesusFactor;
        [TableAttribute("dss_kell_ag")]
        private string dssKellAg;
        [TableAttribute("dss_rw")]
        private string dssRw;
        [TableAttribute("dss_hbs_ag")]
        private string dssHbsAg;
        [TableAttribute("dss_anti_hcv")]
        private string dssAntiHcv;
        [TableAttribute("dss_hiv")]
        private string dssHiv;
        [TableAttribute("dsdt_analysis_date")]
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
