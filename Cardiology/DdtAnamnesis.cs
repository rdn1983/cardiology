using System;

namespace Cardiology.Model
{
    class DdtAnamnesis
    {
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
        [TableAttribute("dss_complaints")]
        private string dssComplaints;
        [TableAttribute("dss_anamnesis_morbi")]
        private string dssAnamnesisMorbi;
        [TableAttribute("dss_anamnesis_vitae")]
        private string dssAnamnesisVitae;
        [TableAttribute("dss_anamnesis_allergy")]
        private string dssAnamnesisAllergy;
        [TableAttribute("dss_anamnesis_epid")]
        private string dssAnamnesisEpid;
        [TableAttribute("dss_past_surgeries")]
        private string dssPastSurgeries;
        [TableAttribute("dss_accompanying_illnesses")]
        private string dssAccompayingIll;
        [TableAttribute("dss_drugs_intoxication")]
        private string dssDrugs;
        [TableAttribute("dss_st_presens")]
        private string dssStPresens;
        [TableAttribute("dss_respiratory_system")]
        private string dssRespiratorySystem;
        [TableAttribute("dss_cardiovascular_system")]
        private string dssCardioVascular;
        [TableAttribute("dss_digestive_system")]
        private string dssDigestiveSystem;
        [TableAttribute("dss_urinary_system")]
        private string dssUrinarySystem;
        [TableAttribute("dss_nervous_system")]
        private string dssNervousSystem;
        [TableAttribute("dss_diagnosis_justification")]
        private string dssDiagnosisJustifies;

        public string ObjectId
        {
            get { return rObjectId; }
            set {; }
        }
        public DateTime CreationDate
        {
            get { return rCreationDate; }
            set {; }
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
        public string DssComplaints
        {
            get { return dssComplaints; }
            set { this.dssComplaints = value; }
        }
        public string DssAnamnesisMorbi
        {
            get { return dssAnamnesisMorbi; }
            set { this.dssAnamnesisMorbi = value; }
        }
        public string DssAnamnesisVitae
        {
            get { return dssAnamnesisVitae; }
            set { this.dssAnamnesisVitae = value; }
        }
        public string DssAnamnesisAllergy
        {
            get { return dssAnamnesisAllergy; }
            set { this.dssAnamnesisAllergy = value; }
        }
        public string DssAnamnesisEpid
        {
            get { return dssAnamnesisEpid; }
            set { this.dssAnamnesisEpid = value; }
        }
        public string DssPastSurgeries
        {
            get { return dssPastSurgeries; }
            set { this.dssPastSurgeries = value; }
        }
        public string DssAccompayingIll
        {
            get { return dssAccompayingIll; }
            set { this.dssAccompayingIll = value; }
        }
        public string DssDrugs
        {
            get { return dssDrugs; }
            set { this.dssDrugs = value; }
        }
        public string DssStPresens
        {
            get { return dssStPresens; }
            set { this.dssStPresens = value; }
        }
        public string DssRespiratorySystem
        {
            get { return dssRespiratorySystem; }
            set { this.dssRespiratorySystem = value; }
        }
        public string DssCardioVascular
        {
            get { return dssCardioVascular; }
            set { this.dssCardioVascular = value; }
        }
        public string DssDigestiveSystem
        {
            get { return dssDigestiveSystem; }
            set { this.dssDigestiveSystem = value; }
        }
        public string DssUrinarySystem
        {
            get { return dssUrinarySystem; }
            set { this.dssUrinarySystem = value; }
        }
        public string DssNervousSystem
        {
            get { return dssNervousSystem; }
            set { this.dssNervousSystem = value; }
        }
        
        public string DssDiagnosisJustifies
        {
            get { return dssDiagnosisJustifies; }
            set { this.dssDiagnosisJustifies = value; }
        }



    }
}
