using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtHospitalService
    {
        IList<DdtHospital> GetAll();

        DdtHospital GetById(string id);

    }
}
