using System;

namespace Cardiology.Data.Model2
{
    public class DdvActiveHospitalPatientV2
    {
        public string SessionId { get; set; }
        public string PatientId { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string DoctorId { get; set; }
        public string Diagnosis { get; set; }
        public string RoomCell { get; set; }
        public string PatientName { get; set; }
        public string DocName { get; set; }
        public string MedCode { get; set; }
    }
}
