using System;

namespace Cardiology.Model
{
    public class DdtKag
    {
        public const string TABLE_NAME = "ddt_kag";

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
        [TableAttribute("dss_results")]
        private string dssResults;
        [TableAttribute("dss_kag_manipulation")]
        private string dssKagManipulation;
        [TableAttribute("dss_kag_action")]
        private string dssKagAction;
        [TableAttribute("dsdt_start_time")]
        private DateTime dsdtStartTime;
        [TableAttribute("dsdt_end_time")]
        private DateTime dsdtEndTime;
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

        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public string DssResults { get => dssResults; set => dssResults = value; }
        public string DssKagManipulation { get => dssKagManipulation; set => dssKagManipulation = value; }
        public DateTime DsdtStartTime { get => dsdtStartTime; set => dsdtStartTime = value; }
        public DateTime DsdtEndTime { get => dsdtEndTime; set => dsdtEndTime = value; }
        public string DssKagAction { get => dssKagAction; set => dssKagAction = value; }
        public DateTime DsdtAnalysisDate { get => dsdtAnalysisDate; set => dsdtAnalysisDate = value; }
    }
}