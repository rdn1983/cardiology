using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtIssuedMedicineService
    {
        IList<DdtIssuedMedicine> GetAll();

        IList<DdtIssuedMedicine> GetListByMedicineListId(string medicineListId);

        DdtIssuedMedicine GetById(string id);

        void Save(DdtIssuedMedicine obj);

        void Delete(string id);
    }
}
