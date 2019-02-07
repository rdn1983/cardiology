using System;

namespace Cardiology.Data.Model
{
    public class DdtVariousSpecConcluson : DdtTypedObject
    {
        public const string TABLE_NAME = "ddt_various_spec_concluson";

        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dsid_parent")]
        private string dsidParent;
        [Table("dss_parent_type")]
        private string dssParentType;
        [Table("dsdt_admission_date")]
        private DateTime dsdtAdmissionDate;
        [Table("dss_specialist_type")]
        private string dssSpecialistType;
        [Table("dss_specialist_conclusion")]
        private string dssSpecialistConclusion;
        [Table("dss_additional_info0")]
        private string dssAdditionalInfo0;
        [Table("dss_additional_info1")]
        private string dssAdditionalInfo1;
        [Table("dss_additional_info2")]
        private string dssAdditionalInfo2;
        [Table("dss_additional_info3")]
        private string dssAdditionalInfo3;
        [Table("dss_additional_info4")]
        private string dssAdditionalInfo4;
        [Table("dsb_visible")]
        private bool dsbVisible;
        [Table("dsb_additional_bool")]
        private bool dsbAdditionalBool;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidParent { get => dsidParent; set => dsidParent = value; }
        public string DssParentType { get => dssParentType; set => dssParentType = value; }
        public DateTime DsdtAdmissionDate { get => dsdtAdmissionDate; set => dsdtAdmissionDate = value; }
        public string DssSpecialistType { get => dssSpecialistType; set => dssSpecialistType = value; }
        public string DssSpecialistConclusion { get => dssSpecialistConclusion; set => dssSpecialistConclusion = value; }
        public string DssAdditionalInfo0 { get => dssAdditionalInfo0; set => dssAdditionalInfo0 = value; }
        public string DssAdditionalInfo1 { get => dssAdditionalInfo1; set => dssAdditionalInfo1 = value; }
        public string DssAdditionalInfo2 { get => dssAdditionalInfo2; set => dssAdditionalInfo2 = value; }
        public string DssAdditionalInfo3 { get => dssAdditionalInfo3; set => dssAdditionalInfo3 = value; }
        public string DssAdditionalInfo4 { get => dssAdditionalInfo4; set => dssAdditionalInfo4 = value; }
        public bool DsbVisible { get => dsbVisible; set => dsbVisible = value; }
        public bool DsbAdditionalBool { get => dsbAdditionalBool; set => dsbAdditionalBool = value; }
    }
}
