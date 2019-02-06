namespace Cardiology.Data.Model2
{
    public class DdtDoctorV2: DmPersistent
    {
        public string Login { get; set; }
        public string FullName { get; set; }
        public string Initials { get; set; }
        public string AppointmentName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int AppointmentType { get; set; }
    }
}
