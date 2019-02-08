using System;

namespace Cardiology.Data.Model
{
    public class DdtBloodAnalysis
    {
        public const string TABLE_NAME = "ddt_blood_analysis";

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
        [Table("dss_hemoglobin")]
        private string dssHemoglobin;
        [Table("dss_leucocytes")]
        private string dssLeucocytes;
        [Table("dss_platelets")]
        private string dssPlatelets;
        [Table("dss_protein")]
        private string dssProtein;
        [Table("dss_creatinine")]
        private string dssCreatinine;
        [Table("dss_cholesterol")]
        private string dssCholesterol;
        [Table("dss_bil")]
        private string dssBil;
        [Table("dss_iron")]
        private string dssIron;
        [Table("dss_alt")]
        private string dssAlt;
        [Table("dss_ast")]
        private string dssAst;
        [Table("dss_schf")]
        private string dssSchf;
        [Table("dss_amylase")]
        private string dssAmylase;
        [Table("dss_kfk")]
        private string dssKfk;
        [Table("dss_kfk_mv")]
        private string dssKfkMv;
        [Table("dss_srp")]
        private string dssSrp;
        [Table("dss_potassium")]
        private string dssPotassium;
        [Table("dss_sodium")]
        private string dssSodium;
        [Table("dss_chlorine")]
        private string dssChlorine;
        [Table("dsb_admission_analysis")]
        private bool dsbAdmissionAnalysis;
        [Table("dsb_discharge_analysis")]
        private bool dsbDischargeAnalysis;
        [Table("dsdt_analysis_date")]
        private DateTime dsdtAnalysisDate;
        [Table("dsid_parent")]
        private string dsidParent;
        [Table("dss_parent_type")]
        private string dssParentType;


        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public string DsdHemoglobin { get => dssHemoglobin; set => dssHemoglobin = value; } 
        public string DsdLeucocytes { get => dssLeucocytes; set => dssLeucocytes = value; }
        public string DsdPlatelets { get => dssPlatelets; set => dssPlatelets = value; }
        public string DsdProtein { get => dssProtein; set => dssProtein = value; }
        public string DsdCreatinine { get => dssCreatinine; set => dssCreatinine = value; }
        public string DsdCholesterolr { get => dssCholesterol; set => dssCholesterol = value; }
        public string DsdBil { get => dssBil; set => dssBil = value; }
        public string DsdIron { get => dssIron; set => dssIron = value; }
        public string DsdAlt { get => dssAlt; set => dssAlt = value; }
        public string DsdAst { get => dssAst; set => dssAst = value; }
        public string DsdSchf { get => dssSchf; set => dssSchf = value; }
        public string DsdAmylase { get => dssAmylase; set => dssAmylase = value; }
        public string DsdKfk { get => dssKfk; set => dssKfk = value; }
        public string DsdKfkMv { get => dssKfkMv; set => dssKfkMv = value; }
        public string DsdSrp { get => dssSrp; set => dssSrp = value; }
        public string DsdPotassium { get => dssPotassium; set => dssPotassium = value; }
        public string DsdSodium { get => dssSodium; set => dssSodium = value; }
        public string DsdChlorine { get => dssChlorine; set => dssChlorine = value; }
        public bool DsbAdmissionAnalysis { get => dsbAdmissionAnalysis; set => dsbAdmissionAnalysis = value; }
        public bool DsbDischargeAnalysis { get => dsbDischargeAnalysis; set => dsbDischargeAnalysis = value; }
        public DateTime DsdtAnalysisDate { get => dsdtAnalysisDate; set => dsdtAnalysisDate = value; }
        public string DsidParent { get => dsidParent; set => dsidParent = value; }
        public string DssParentType { get => dssParentType; set => dssParentType = value; }
    }
}
