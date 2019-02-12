using System;

namespace Cardiology.Data.Model
{
    public class DdtConsiliumMember
    {
        public const string TABLE_NAME = "ddt_consilium_member";
        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dsid_consilium")]
        private string dsidConsilium;
        [Table("dss_group_name")]
        private string dssGroupName;
        [Table("dss_doctor_name")]
        private string dssDoctorName;
        [Table("dsb_template")]
        private bool dsbTemplate;


        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidConsilium { get => dsidConsilium; set => dsidConsilium = value; }
        public string DssDoctorName { get => dssDoctorName; set => dssDoctorName = value; }
        public string DssGroupName { get => dssGroupName; set => dssGroupName = value; }
        public bool DsbTemplate { get => dsbTemplate; set => dsbTemplate = value; }
    }
}
