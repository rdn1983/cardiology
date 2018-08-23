using System;

namespace Cardiology.Model
{
    public class DdtUrineAnalysis
    {
        public const string TABLE_NAME = "ddt_urine_analysis";

        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsdt_analysis_date")]
        private DateTime dsdtAnalysisDate;
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dsid_patient")]
        private string dsidPatient;
        [TableAttribute("dsid_doctor")]
        private string dsidDoctor;
        [TableAttribute("dss_color")]
        private string dssColor;
        [TableAttribute("dss_acidity")]
        private string dssAcidity;
        [TableAttribute("dss_specific_gravity")]
        private string dssSpecificGravity;
        [TableAttribute("dss_leukocytes")]
        private string dssLeukocytes;
        [TableAttribute("dss_erythrocytes")]
        private string dssErythrocytes;
        [TableAttribute("dss_glucose")]
        private string dssGlucose;
        [TableAttribute("dss_protein")]
        private string dssProtein;
        [TableAttribute("dss_ketones")]
        private string dssKetones;
        [TableAttribute("dsb_admission_analysis")]
        private bool dsbAdmissionAnalysis;
        [TableAttribute("dsb_discharge_analysis")]
        private bool dsbDischargeAnalysis;


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
    }
}
