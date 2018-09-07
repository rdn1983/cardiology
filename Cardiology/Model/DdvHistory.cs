using System;

namespace Cardiology.Model
{
    public class DdvHistory
    {
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dss_operation_type")]
        private string dssOperationType;
        [TableAttribute("dss_operation_name")]
        private string dssOperationName;
        [TableAttribute("dsdt_operation_date")]
        private DateTime dsdtOperationDate;
        [TableAttribute("dss_doctor_name")]
        private string dssDoctorName;
        [TableAttribute("dss_description")]
        private string dssDescription;
        [TableAttribute("dsid_operation_id")]
        private string dsidOperationId;

        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DssOperationType { get => dssOperationType; set => dssOperationType = value; }
        public string DssOperationName { get => dssOperationName; set => dssOperationName = value; }
        public DateTime DsdtOperationDate { get => dsdtOperationDate; set => dsdtOperationDate = value; }
        public string DssDoctorName { get => dssDoctorName; set => dssDoctorName = value; }
        public string DssDescription { get => dssDescription; set => dssDescription = value; }
        public string DsidOperationId { get => dsidOperationId; set => dsidOperationId = value; }
    }
}
