using Cardiology.Data.Model2;
using System;

namespace Cardiology.Data.Model2
{
    public class DdtHospitalV2: DmPersistent
    {
        public string PatientId { get; set; }
        public DdtPatientV2 Patient { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string DutyDoctorId { get; set; }
        public string CuringDoctorId { get; set; }
        public string SubstitutionDoctorId { get; set; }
        public string DirCardioReanimDoctorId { get; set; }
        public string AnesthetistDoctorId { get; set; }
        public bool Active { get; set; }
        public bool RejectCure { get; set; }
        public bool Death { get; set; }
        public string RoomCell { get; set; }
        public string Diagnosis { get; set; }
        public int ReleaseType { get; set; }
    }
}