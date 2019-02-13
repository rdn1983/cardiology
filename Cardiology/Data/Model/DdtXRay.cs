using System;

namespace Cardiology.Data.Model
{
    [Obsolete("Этот класс будет удален", false)]
    public class DdtXRay
    {
        public const string TABLE_NAME = "ddt_xray";

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
        [Table("dss_chest_xray")]
        private string dssChestXray;
        [Table("dss_control_radiography")]
        private string dssControlRadiography;
        [Table("dss_mskt")]
        private string dssMskt;
        [Table("dss_kt")]
        private string dssKt;
        [Table("dss_mrt")]
        private string dssMrt;
        [Table("dsdt_kt_date")]
        private DateTime dsdtKtDate;
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

        public string DssChestXray { get => dssChestXray; set => dssChestXray = value; }
        public string DssControlRadiography { get => dssControlRadiography; set => dssControlRadiography = value; }
        public string DssMskt { get => dssMskt; set => dssMskt = value; }
        public string DssKt { get => dssKt; set => dssKt = value; }
        public string DssMrt { get => dssMrt; set => dssMrt = value; }
        public DateTime DsdtKtDate { get => dsdtKtDate; set => dsdtKtDate = value; }
        public DateTime DsdtAnalysisDate { get => dsdtAnalysisDate; set => dsdtAnalysisDate = value; }
        public string DsidParent { get => dsidParent; set => dsidParent = value; }
        public string DssParentType { get => dssParentType; set => dssParentType = value; }
    }
}
