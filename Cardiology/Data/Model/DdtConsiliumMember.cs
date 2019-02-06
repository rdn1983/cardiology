using System;

namespace Cardiology.Data
{
    public class DdtConsiliumMember
    {
        public const string TABLE_NAME = "ddt_consilium_member";
        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_consilium")]
        private string dsidConsilium;
        [TableAttribute("dss_group_name")]
        private string dssGroupName;
        [TableAttribute("dss_doctor_name")]
        private string dssDoctorName;
        [TableAttribute("dsb_template")]
        private bool dsbTemplate;
        [TableAttribute("dss_template_name")]
        private string dssTemplateName;


        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidConsilium { get => dsidConsilium; set => dsidConsilium = value; }
        public string DssDoctorName { get => dssDoctorName; set => dssDoctorName = value; }
        public string DssGroupName { get => dssGroupName; set => dssGroupName = value; }
        public bool DsbTemplate { get => dsbTemplate; set => dsbTemplate = value; }
        public string DssTemplateName { get => dssTemplateName; set => dssTemplateName = value; }
    }
}
