using System;

namespace Cardiology.Data.Model
{
    [Obsolete("Этот класс будет удален", false)]
    public class DdtKag
    {
        public const string TABLE_NAME = "ddt_kag";

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
        [Table("dss_results")]
        private string dssResults;
        [Table("dss_kag_manipulation")]
        private string dssKagManipulation;
        [Table("dss_kag_action")]
        private string dssKagAction;
        [Table("dsdt_start_time")]
        private DateTime dsdtStartTime;
        [Table("dsdt_end_time")]
        private DateTime dsdtEndTime;
        [Table("dsdt_analysis_date")]
        private DateTime dsdtAnalysisDate;
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

        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public string DssResults { get => dssResults; set => dssResults = value; }
        public string DssKagManipulation { get => dssKagManipulation; set => dssKagManipulation = value; }
        public DateTime DsdtStartTime { get => dsdtStartTime; set => dsdtStartTime = value; }
        public DateTime DsdtEndTime { get => dsdtEndTime; set => dsdtEndTime = value; }
        public string DssKagAction { get => dssKagAction; set => dssKagAction = value; }
        public DateTime DsdtAnalysisDate { get => dsdtAnalysisDate; set => dsdtAnalysisDate = value; }
        public string DsidParent { get => dsidParent; set => dsidParent = value; }
        public string DssParentType { get => dssParentType; set => dssParentType = value; }
    }
}