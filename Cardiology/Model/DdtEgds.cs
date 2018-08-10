using System;

namespace Cardiology.Model
{
    public class DdtEgds
    {
        public const string TABLE_NAME = "ddt_egds";

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
        [TableAttribute("dss_egds")]
        private string dssEgds;
        [TableAttribute("dsb_admission_analysis")]
        private bool dsbAdmissionAnalysis;

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
        public string DssEgds { get => dssEgds; set => dssEgds = value; }
        public bool DsbAdmissionAnalysis { get => dsbAdmissionAnalysis; set => dsbAdmissionAnalysis = value; }
    }

    
}
