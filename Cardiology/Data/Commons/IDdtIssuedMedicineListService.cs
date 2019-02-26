using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtIssuedMedicineListService
    {
        IList<DdtIssuedMedicineList> GetAll();

        DdtIssuedMedicineList GetById(string id);

        string Save(DdtIssuedMedicineList obj);

        DdtIssuedMedicineList GetListByHospitalId(string parentType, string id);

        DdtIssuedMedicineList GetListByHospitalId(string id);
    }
}
