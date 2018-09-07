using System;

namespace Cardiology.Model
{
    public class DdtHospital
    {
        public const string TABLENAME = "ddt_hospital";

        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_patient")]
        private string dsidPatient;
        [TableAttribute("dsdt_admission_date")]
        private DateTime dsdtAdmissionDate;
        [TableAttribute("dsid_duty_doctor")]
        private string dsidDutyDoctor;
        [TableAttribute("dsid_curing_doctor")]
        private string dsidCuringDoctor;
        [TableAttribute("dsid_substitution_doctor")]
        private string dsidSubstitutionDoctor;
        [TableAttribute("dsb_active")]
        private bool dsbActive;
        [TableAttribute("dsb_reject_cure")]
        private bool dsbRejectCure;
        [TableAttribute("dsb_death")]
        private bool dsbDeath;
        [TableAttribute("dss_room_cell")]
        private string dssRoomCell;
        [TableAttribute("dss_diagnosis")]
        private string dssDiagnosis;
        [TableAttribute("dsi_release_type")]
        private int dsiReleaseType;

        public string ObjectId {
            get { return rObjectId;}
        }

        public string DssRoomCell
        {
            get { return dssRoomCell; }
            set { this.dssRoomCell = value; }
        }

        public string DssDiagnosis
        {
            get { return dssDiagnosis; }
            set { this.dssDiagnosis = value; }
        }

        public DateTime CreationDate
        {
            get { return rCreationDate; }
        }

        public string DsidPatient
        {
            get { return dsidPatient; }
            set { this.dsidPatient = value; }
        }

        public DateTime DsdtAdmissionDate
        {
            get { return dsdtAdmissionDate; }
            set { this.dsdtAdmissionDate = value; }
        }

        public string DsidDutyDoctor
        {
            get { return dsidDutyDoctor; }
            set { this.dsidDutyDoctor = value; }
        }

        public string DsidCuringDoctor
        {
            get { return dsidCuringDoctor; }
            set { this.dsidCuringDoctor = value; }
        }

        public string DsidSubstitutionDoctor
        {
            get { return dsidSubstitutionDoctor; }
            set { this.dsidSubstitutionDoctor = value; }
        }

        public bool DsbActive
        {
            get { return dsbActive; }
            set { this.dsbActive = value; }
        }

        public bool DsbRejectCure
        {
            get { return dsbRejectCure; }
            set { this.dsbRejectCure = value; }
        }

        public bool DsbDeath
        {
            get { return dsbDeath; }
            set { this.dsbDeath = value; }
        }

        public int DsiReleaseType { get => dsiReleaseType; set => dsiReleaseType = value; }
    }
}
