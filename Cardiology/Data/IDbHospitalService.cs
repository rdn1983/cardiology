using Cardiology.Data.Model2;

namespace Cardiology.Data
{
    public interface IDbHospitalService
    {
        DdtHospitalV2 GetById(string id);

        void update(DdtHospitalV2 obj);
    }
}
