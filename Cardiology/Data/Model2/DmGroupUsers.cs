using System;

namespace Cardiology.Data.Model2
{
    public class DmGroupUsers
    {
        public static readonly string NAME = "dm_group_users";

        public string ObjectId { get; set; }

        public DateTime ModifyDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string DoctorId { get; set; }

        public string GroupName { get; set; }

    }
}
