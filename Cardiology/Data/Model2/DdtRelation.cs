namespace Cardiology.Data.Model2
{
    public class DdtRelation
    {
        public static readonly string NAME = "ddt_relation";

        public string ObjectId { get; set; }

        public string Parent { get; set; }

        public string Child { get; set; }

        public string ChildType { get; set; }
    }
}
