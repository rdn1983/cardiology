using System;

namespace Cardiology.Data.Model
{
    public class DdtIssuedMedicineList
    {
        public const string TABLE_NAME = "ddt_issued_medicine_list";

        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dsid_doctor")]
        private string dsidDoctor;
        [Table("dsid_patient")]
        private string dsidPatient;
        [Table("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [Table("dsid_parent_id")]
        private string dsidParentId;
        [Table("dss_parent_type")]
        private string dssParentType;
        [Table("dsdt_issuing_date")]
        private DateTime dsdtIssuingDate;
        [Table("dss_diagnosis")]
        private string dssDiagnosis;
        [Table("dss_has_kag")]
        private string dssHasKag;
        [Table("dsb_skip_print")]
        private bool dsbSkipPrint;
        [Table("dsid_pharmacologist")]
        private string dsidPharmacologist;
        [Table("dsid_nurse")]
        private string dsidNurse;
        [Table("dsid_director")]
        private string dsidDirector;
        [Table("dss_template_name")]
        private string dssTemplateName;


        public string ObjectId
        {
            get { return rObjectId; }
            set { this.rObjectId = value; }
        }
        public string DsidDoctor
        {
            get { return dsidDoctor; }
            set { this.dsidDoctor = value; }

        }
        public string DsidPatient
        {
            get { return dsidPatient; }
            set { this.dsidPatient = value; }

        }
        public string DsidHospitalitySession
        {
            get { return dsidHospitalitySession; }
            set { this.dsidHospitalitySession = value; }

        }
        public DateTime CreationDate
        {
            get { return rCreationDate; }
            set {; }
        }

        public string DsidParentId { get => dsidParentId; set => dsidParentId = value; }
        public string DssParentType { get => dssParentType; set => dssParentType = value; }
        public DateTime DsdtIssuingDate { get => dsdtIssuingDate; set => dsdtIssuingDate = value; }
        public string DssDiagnosis { get => dssDiagnosis; set => dssDiagnosis = value; }
        public string DssHasKag { get => dssHasKag; set => dssHasKag = value; }
        public bool DsbSkipPrint { get => dsbSkipPrint; set => dsbSkipPrint = value; }
        public string DsidPharmacologist { get => dsidPharmacologist; set => dsidPharmacologist = value; }
        public string DsidNurse { get => dsidNurse; set => dsidNurse = value; }
        public string DsidDirector { get => dsidDirector; set => dsidDirector = value; }
        public string DssTemplateName { get => dssTemplateName; set => dssTemplateName = value; }
    }
}