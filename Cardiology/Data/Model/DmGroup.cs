using System;

namespace Cardiology.Data.Model
{
    [Obsolete("Этот класс будет удален", false)]
    class DmGroup
    {
        public const string TABLE_NAME = "dm_group";

        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dss_name")]
        private string dssName;
        [Table("dss_description")]
        private string dssDescription;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DssName { get => dssName; set => dssName = value; }
        public string DssDescription { get => dssDescription; set => dssDescription = value; }
    }
}
