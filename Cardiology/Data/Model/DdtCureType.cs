using System;

namespace Cardiology.Model
{
    public class DdtCureType
    {
        public const string TABLE_NAME = "ddt_cure_type";
        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dss_name")]
        private string dssName;

        public string ObjectId
        {
            get { return rObjectId; }
            set {; }
        }
        public DateTime CreationDate
        {
            get { return rCreationDate; }
            set {; }
        }
        public string DssName
        {
            get { return dssName; }
            set { this.dssName = value; }
        }

    }
}
