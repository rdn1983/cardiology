using System;

namespace Cardiology.Model
{
    public class DdtHolter
    {
        public const string TABLE_NAME = "ddt_holter";

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
        [TableAttribute("dss_holter")]
        private string dssHolter;
        [TableAttribute("dss_monitoring_ad")]
        private string dssMonitoringAd;
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

        public string DssHolter { get => dssHolter; set => dssHolter = value; }
        public string DssMonitoringAd { get => dssMonitoringAd; set => dssMonitoringAd = value; }
        public DateTime DsdtAnalysisDate { get => dsdtAnalysisDate; set => dsdtAnalysisDate = value; }
    }
}
