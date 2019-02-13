using System;

namespace Cardiology.Data.Model
{
    [Obsolete("Этот класс будет удален", false)]
    class DdtTransfer
    {
        public const string TABLE_NAME = "ddt_transfer";

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
        [Table("dsdt_start_date")]
        private DateTime dsdtStartDate;
        [Table("dsdt_end_date")]
        private DateTime dsdtEndDate;
        [Table("dss_destination")]
        private string dssDestination;
        [Table("dss_contacts")]
        private string dssContacts;
        [Table("dss_transfer_justification")]
        private string dssTransferJustification;
        [Table("dsi_type")]
        private int dsiType;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public DateTime DsdtStartDate { get => dsdtStartDate; set => dsdtStartDate = value; }
        public DateTime DsdtEndDate { get => dsdtEndDate; set => dsdtEndDate = value; }
        public string DssDestination { get => dssDestination; set => dssDestination = value; }
        public string DssContacts { get => dssContacts; set => dssContacts = value; }
        public string DssTransferJustification { get => dssTransferJustification; set => dssTransferJustification = value; }
        public int DsiType { get => dsiType; set => dsiType = value; }
    }
}
