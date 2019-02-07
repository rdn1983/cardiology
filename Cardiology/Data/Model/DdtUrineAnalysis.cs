using System;

namespace Cardiology.Data.Model
{
    public class DdtUrineAnalysis : DdtTypedObject
    {
        public const string TABLE_NAME = "ddt_urine_analysis";

        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dsdt_analysis_date")]
        private DateTime dsdtAnalysisDate;
        [Table("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [Table("dsid_patient")]
        private string dsidPatient;
        [Table("dsid_doctor")]
        private string dsidDoctor;
        [Table("dss_color")]
        private string dssColor;
        [Table("dss_acidity")]
        private string dssAcidity;
        [Table("dss_specific_gravity")]
        private string dssSpecificGravity;
        [Table("dss_leukocytes")]
        private string dssLeukocytes;
        [Table("dss_erythrocytes")]
        private string dssErythrocytes;
        [Table("dss_glucose")]
        private string dssGlucose;
        [Table("dss_protein")]
        private string dssProtein;
        [Table("dss_ketones")]
        private string dssKetones;
        [Table("dsb_admission_analysis")]
        private bool dsbAdmissionAnalysis;
        [Table("dsb_discharge_analysis")]
        private bool dsbDischargeAnalysis;
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

        public string DssColor { get => dssColor; set => dssColor = value; }
        public string DssAcidity { get => dssAcidity; set => dssAcidity = value; }
        public string DssSpecificGravity { get => dssSpecificGravity; set => dssSpecificGravity = value; }
        public string DssLeukocytes { get => dssLeukocytes; set => dssLeukocytes = value; }
        public string DssErythrocytes { get => dssErythrocytes; set => dssErythrocytes = value; }
        public string DssGlucose { get => dssGlucose; set => dssGlucose = value; }
        public string DssProtein { get => dssProtein; set => dssProtein = value; }
        public string DssKetones { get => dssKetones; set => dssKetones = value; }
        public bool DsbAdmissionAnalysis { get => dsbAdmissionAnalysis; set => dsbAdmissionAnalysis = value; }
        public bool DsbDischargeAnalysis { get => dsbDischargeAnalysis; set => dsbDischargeAnalysis = value; }
        public DateTime DsdtAnalysisDate { get => dsdtAnalysisDate; set => dsdtAnalysisDate = value; }
        public string DsidParent { get => dsidParent; set => dsidParent = value; }
        public string DssParentType { get => dssParentType; set => dssParentType = value; }
    }
}
