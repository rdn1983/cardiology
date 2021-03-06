using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtCureTypeService
    {
        IList<DdtCureType> GetAll();

        DdtCureType GetById(string id);
    }
}
