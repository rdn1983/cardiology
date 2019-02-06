using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardiology.Data
{
    class DdtTransfer
    {
        public const string TABLE_NAME = "ddt_transfer";

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
        [TableAttribute("dsdt_start_date")]
        private DateTime dsdtStartDate;
        [TableAttribute("dsdt_end_date")]
        private DateTime dsdtEndDate;
        [TableAttribute("dss_destination")]
        private string dssDestination;
        [TableAttribute("dss_contacts")]
        private string dssContacts;
        [TableAttribute("dss_transfer_justification")]
        private string dssTransferJustification;
        [TableAttribute("dsi_type")]
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
