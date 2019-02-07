

namespace Cardiology.Data.Model
{
    class DdtValues
    {
        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("dss_name")]
        private string dssName;
        [Table("dss_value")]
        private string dssValue;

        public string ObjectId
        {
            get { return rObjectId; }
            set {; }
        }

        public string DssName
        {
            get { return dssName; }
            set { this.dssName = value; }
        }
        public string DssValue
        {
            get { return dssValue; }
            set { this.dssValue = value; }
        }
    }
}
