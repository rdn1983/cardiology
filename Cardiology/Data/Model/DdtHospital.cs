using System;

namespace Cardiology.Data.Model
{
    [Obsolete("Этот класс будет удален", false)]
    public class DdtHospital
    {
        public const string TABLE_NAME = "ddt_hospital";

        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dsid_patient")]
        private string dsidPatient;
        [Table("dsdt_admission_date")]
        private DateTime dsdtAdmissionDate;
        [Table("dsid_duty_doctor")]
        private string dsidDutyDoctor;
        [Table("dsid_curing_doctor")]
        private string dsidCuringDoctor;
        [Table("dsid_substitution_doctor")]
        private string dsidSubstitutionDoctor;
        [Table("dsid_dir_cardio_reanim_doctor")]
        private string dsidDirCardioReanimDoctor;
        [Table("dsid_anesthetist_doctor")]
        private string dsidAnesthetistDoctor;
        [Table("dsb_active")]
        private bool dsbActive;
        [Table("dsb_reject_cure")]
        private bool dsbRejectCure;
        [Table("dsb_death")]
        private bool dsbDeath;
        [Table("dss_room_cell")]
        private string dssRoomCell;
        [Table("dss_diagnosis")]
        private string dssDiagnosis;
        [Table("dsi_release_type")]
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

        public string DsidDirCardioReanimDoctor
        {
            get { return dsidDirCardioReanimDoctor; }
            set { this.dsidDirCardioReanimDoctor = value; }
        }

        public string DsidAnesthetistDoctor
        {
            get { return dsidAnesthetistDoctor; }
            set { this.dsidAnesthetistDoctor = value; }
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
