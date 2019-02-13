using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtIssuedMedicineListService
    {
        IList<DdtIssuedMedicineList> GetAll();

        DdtIssuedMedicineList GetById(string id);
    }
}
