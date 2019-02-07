using System;

namespace Cardiology.Data.Model
{
    class DdtAnamnesis
    {
        public const string TABLE_NAME = "ddt_anamnesis";

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
        [Table("dss_complaints")]
        private string dssComplaints;
        [Table("dss_anamnesis_morbi")]
        private string dssAnamnesisMorbi;
        [Table("dss_anamnesis_vitae")]
        private string dssAnamnesisVitae;
        [Table("dss_anamnesis_allergy")]
        private string dssAnamnesisAllergy;
        [Table("dss_anamnesis_epid")]
        private string dssAnamnesisEpid;
        [Table("dss_past_surgeries")]
        private string dssPastSurgeries;
        [Table("dss_accompanying_illnesses")]
        private string dssAccompayingIll;
        [Table("dss_drugs_intoxication")]
        private string dssDrugs;
        [Table("dss_st_presens")]
        private string dssStPresens;
        [Table("dss_respiratory_system")]
        private string dssRespiratorySystem;
        [Table("dss_cardiovascular_system")]
        private string dssCardioVascular;
        [Table("dss_digestive_system")]
        private string dssDigestiveSystem;
        [Table("dss_urinary_system")]
        private string dssUrinarySystem;
        [Table("dss_nervous_system")]
        private string dssNervousSystem;
        [Table("dss_diagnosis_justification")]
        private string dssDiagnosisJustifies;
        [Table("dss_diagnosis")]
        private string dssDiagnosis;
        [Table("dss_operation_cause")]
        private string dssOperationCause;
        [Table("dss_template_name")]
        private string dssTemplateName;
        [Table("dsb_template")]
        private bool dsbTemplate;
        [Table("dsdt_inspection_date")]
        private DateTime dsdtInspectionDate;
        [Table("dss_justification")]
        private string dssJustification;

        public string ObjectId
        {
            get { return rObjectId; }
            set { this.rObjectId = value; }
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

        public string DssJustification
        {
            get { return dssJustification; }
            set { this.dssJustification = value; }
        }

        public string DssTemplateName { get => dssTemplateName; set => dssTemplateName = value; }
        public bool DsbTemplate { get => dsbTemplate; set => dsbTemplate = value; }
        public string DssDiagnosis { get => dssDiagnosis; set => dssDiagnosis = value; }
        public string DssOperationCause { get => dssOperationCause; set => dssOperationCause = value; }
        public DateTime DsdtInspectionDate { get => dsdtInspectionDate; set => dsdtInspectionDate = value; }
    }
}
