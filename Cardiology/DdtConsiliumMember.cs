using System;

namespace Cardiology.Model
{
    public class DdtConsiliumMember
    {
        public const string TABLE_NAME = "ddt_consilium_member";
        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_consilium")]
        private string dsidConsilium;
        [TableAttribute("dss_appointment_name")]
        private string dssAppointmentName;
        [TableAttribute("dss_doctor_name")]
        private string dssDoctorName;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidConsilium { get => dsidConsilium; set => dsidConsilium = value; }
        public string DssAppointmentName { get => dssAppointmentName; set => dssAppointmentName = value; }
        public string DssDoctorName { get => dssDoctorName; set => dssDoctorName = value; }
    }
}
