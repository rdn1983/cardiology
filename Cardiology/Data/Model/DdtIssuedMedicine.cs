using System;

namespace Cardiology.Data.Model
{
    public class DdtIssuedMedicine
    {
        public const string TABLE_NAME = "ddt_issued_medicine";

        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dsid_cure")]
        private string dsidCure;
        [Table("dsid_med_list")]
        private string dsidMedList;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidCure { get => dsidCure; set => dsidCure = value; }
        public string DsidMedList { get => dsidMedList; set => dsidMedList = value; }
    }
}
