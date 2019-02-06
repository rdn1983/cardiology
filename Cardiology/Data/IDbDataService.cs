namespace Cardiology.Data
{
    public interface IDbDataService
    {
        IDbPatientService GetPatientService();

        IDbGroupService GetGroupService();

        IDbHospitalService GetHospitalService();

        IDbDoctorService GetDoctorService();
    }
}
