namespace Cardiology.Data.PostgreSQL
{
    class PgDataService : IDbDataService
    {
        private readonly IDbConnectionFactory connectionFactory;
        private readonly IDbDoctorService doctorService;
        private readonly IDbGroupService groupService;
        private readonly IDbHospitalService hospitalService;
        private readonly IDbPatientService patientService;

        public PgDataService(IDbConnectionFactory connectionFactory) {
            this.connectionFactory = connectionFactory;

            doctorService = new PgDoctorService(connectionFactory);
            groupService = new PgGroupService(connectionFactory);
            hospitalService = new PgHospitalService(connectionFactory);
            patientService = new PgPatientService(connectionFactory);
        }

        public IDbDoctorService GetDoctorService()
        {
            return doctorService;
        }

        public IDbGroupService GetGroupService()
        {
            return groupService;
        }

        public IDbHospitalService GetHospitalService()
        {
            return hospitalService;
        }

        public IDbPatientService GetPatientService()
        {
            return patientService;
        }
    }
}
