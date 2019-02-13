using System;

namespace Cardiology.Data.Model2
{
    public class DdvActiveHospitalPatients
    {
        public string PatientId { get; set; }

        public bool Active { get; set; }

        public string HospitalSession { get; set; }

        public string DocName { get; set; }

        public string Diagnosis { get; set; }

        public string PatientName { get; set; }

        public string RoomCell { get; set; }

        public string DoctorId { get; set; }

        public string MedCode { get; set; }

        public DateTime AdmissionDate { get; set; }

    }
}
