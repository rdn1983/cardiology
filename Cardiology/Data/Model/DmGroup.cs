using System;

namespace Cardiology.Data
{
    class DmGroup
    {
        public const string TABLE_NAME = "dm_group";

        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dss_name")]
        private string dssName;
        [TableAttribute("dss_description")]
        private string dssDescription;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DssName { get => dssName; set => dssName = value; }
        public string DssDescription { get => dssDescription; set => dssDescription = value; }
    }
}
