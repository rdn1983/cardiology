namespace Cardiology.Data.Model
{
    public class DdtConsiliumMemberLevel
    {
        public const string TABLE_NAME = "ddt_consilium_member_level";
        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("dss_group_name")]
        private string dssGroupName;
        [Table("dsi_level")]
        private int dsiLevel;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public string DssGroupName { get => dssGroupName; set => dssGroupName = value; }
        public int DsiLevel { get => dsiLevel; set => dsiLevel = value; }
    }
}
