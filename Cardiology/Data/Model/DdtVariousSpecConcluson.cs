using System;

namespace Cardiology.Model
{
    public class DdtVariousSpecConcluson : DdtTypedObject
    {
        public const string TABLE_NAME = "ddt_various_spec_concluson";

        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_parent")]
        private string dsidParent;
        [TableAttribute("dss_parent_type")]
        private string dssParentType;
        [TableAttribute("dsdt_admission_date")]
        private DateTime dsdtAdmissionDate;
        [TableAttribute("dss_specialist_type")]
        private string dssSpecialistType;
        [TableAttribute("dss_specialist_conclusion")]
        private string dssSpecialistConclusion;
        [TableAttribute("dss_additional_info0")]
        private string dssAdditionalInfo0;
        [TableAttribute("dss_additional_info1")]
        private string dssAdditionalInfo1;
        [TableAttribute("dss_additional_info2")]
        private string dssAdditionalInfo2;
        [TableAttribute("dss_additional_info3")]
        private string dssAdditionalInfo3;
        [TableAttribute("dss_additional_info4")]
        private string dssAdditionalInfo4;
        [TableAttribute("dsb_visible")]
        private bool dsbVisible;
        [TableAttribute("dsb_additional_bool")]
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
