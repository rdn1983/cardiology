using System;

namespace Cardiology.Data.Model
{
    [Obsolete("Этот класс будет удален", false)]
    public class DdvHistory
    {
        [Table("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [Table("dss_operation_type")]
        private string dssOperationType;
        [Table("dss_operation_name")]
        private string dssOperationName;
        [Table("dsdt_operation_date")]
        private DateTime dsdtOperationDate;
        [Table("dss_doctor_name")]
        private string dssDoctorName;
        [Table("dss_description")]
        private string dssDescription;
        [Table("dsid_operation_id")]
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
