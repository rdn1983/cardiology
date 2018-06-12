using System;

namespace Cardiology.Model
{
    class DdtCure
    {
        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dss_name")]
        private string dssName;
        [TableAttribute("dsi_type")]
        private int dsiType;

        public string ObjectId
        {
            get{ return rObjectId; }
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
        public int DsiType
        {
            get { return dsiType; }
            set { this.dsiType = value; }
        }

    }
}
