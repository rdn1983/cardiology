namespace Cardiology.Data
{
    public interface IDbDataService
    {
        IDbPatientService GetPatientService();

        IDmGroupService GetGroupService();
    }
}
