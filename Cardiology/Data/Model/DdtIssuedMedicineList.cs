using System;

namespace Cardiology.Model
{
    public class DdtIssuedMedicineList
    {
        public const string TABLE_NAME = "ddt_issued_medicine_list";

        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_doctor")]
        private string dsidDoctor;
        [TableAttribute("dsid_patient")]
        private string dsidPatient;
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dsid_parent_id")]
        private string dsidParentId;
        [TableAttribute("dss_parent_type")]
        private string dssParentType;
        [TableAttribute("dsdt_issuing_date")]
        private DateTime dsdtIssuingDate;
        [TableAttribute("dss_diagnosis")]
        private string dssDiagnosis;
        [TableAttribute("dss_has_kag")]
        private string dssHasKag;
        [TableAttribute("dsb_skip_print")]
        private bool dsbSkipPrint;
        [TableAttribute("dsid_pharmacologist")]
        private string dsidPharmacologist;
        [TableAttribute("dsid_nurse")]
        private string dsidNurse;
        [TableAttribute("dsid_director")]
        private string dsidDirector;
        [TableAttribute("dss_template_name")]
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