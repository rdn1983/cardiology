using System;


namespace Cardiology.Model

{
    public class DdvActiveHospitalPatients
    {
        [TableAttribute("dsid_hospital_session")]
        private string patientSessionId;
        [TableAttribute("dsid_patient_id")]
        private string dsidPatientId;
        [TableAttribute("dsdt_admission_date")]
        private DateTime dsdtAdmissionDate;
        [TableAttribute("dsid_doctor_id")]
        private string dsidDoctorId;
        [TableAttribute("dss_diagnosis")]
        private string dssDiagnosis;
        [TableAttribute("dss_room_cell")]
        private string dssRoomCell;
        [TableAttribute("dss_patient_name")]
        private string dssPatientName;
        [TableAttribute("dss_doc_name")]
        private string dssDocName;
        [TableAttribute("dss_med_code")]
        private string dssMedCode;

        public string PatientSessionId
        {
            get { return patientSessionId; }
        }

        public string DssMedCode
        {
            get { return dssMedCode; }
        }
        public string DssRoomCell
        {
            get { return dssRoomCell; }
        }

        public string DssDiagnosis
        {
            get { return dssDiagnosis; }
        }

        public DateTime DsdtAdmissionDate
        {
            get { return dsdtAdmissionDate; }
        }

        public string DsidDoctorId
        {
            get { return dsidDoctorId; }
        }

        public string DsidPatientId
        {
            get { return dsidPatientId; }
        }
        public string DssPatientName
        {
            get { return dssPatientName; }
        }
        public string DssDocName
        {
            get { return dssDocName; }
        }

    }
}
