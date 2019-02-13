using System;

namespace Cardiology.Data.Model2
{
    public class DdtConsiliumMember
    {
        public string ObjectId { get; set; }

        public DateTime ModifyDate { get; set; }

        public string DoctorName { get; set; }

        public string TemplateName { get; set; }

        public string Consilium { get; set; }

        public bool Template { get; set; }

        public DateTime CreationDate { get; set; }

        public string GroupName { get; set; }

    }
}
