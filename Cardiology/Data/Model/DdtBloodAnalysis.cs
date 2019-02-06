using System;

namespace Cardiology.Data
{
    public class DdtBloodAnalysis : DdtTypedObject
    {
        public const string TABLE_NAME = "ddt_blood_analysis";

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
        [TableAttribute("dss_hemoglobin")]
        private string dssHemoglobin;
        [TableAttribute("dss_leucocytes")]
        private string dssLeucocytes;
        [TableAttribute("dss_platelets")]
        private string dssPlatelets;
        [TableAttribute("dss_protein")]
        private string dssProtein;
        [TableAttribute("dss_creatinine")]
        private string dssCreatinine;
        [TableAttribute("dss_cholesterol")]
        private string dssCholesterol;
        [TableAttribute("dss_bil")]
        private string dssBil;
        [TableAttribute("dss_iron")]
        private string dssIron;
        [TableAttribute("dss_alt")]
        private string dssAlt;
        [TableAttribute("dss_ast")]
        private string dssAst;
        [TableAttribute("dss_schf")]
        private string dssSchf;
        [TableAttribute("dss_amylase")]
        private string dssAmylase;
        [TableAttribute("dss_kfk")]
        private string dssKfk;
        [TableAttribute("dss_kfk_mv")]
        private string dssKfkMv;
        [TableAttribute("dss_srp")]
        private string dssSrp;
        [TableAttribute("dss_potassium")]
        private string dssPotassium;
        [TableAttribute("dss_sodium")]
        private string dssSodium;
        [TableAttribute("dss_chlorine")]
        private string dssChlorine;
        [TableAttribute("dsb_admission_analysis")]
        private bool dsbAdmissionAnalysis;
        [TableAttribute("dsb_discharge_analysis")]
        private bool dsbDischargeAnalysis;
        [TableAttribute("dsdt_analysis_date")]
        private DateTime dsdtAnalysisDate;
        [TableAttribute("dsid_parent")]
        private string dsidParent;
        [TableAttribute("dss_parent_type")]
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
