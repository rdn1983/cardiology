using System;

namespace Cardiology.Model
{
    public class DdtConsiliumMemberLevel
    {
        public const string TABLE_NAME = "ddt_consilium_member_level";
        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("dss_group_name")]
        private string dssGroupName;
        [TableAttribute("dsi_level")]
        private int dsiLevel;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public string DssGroupName { get => dssGroupName; set => dssGroupName = value; }
        public int DsiLevel { get => dsiLevel; set => dsiLevel = value; }
    }
}
