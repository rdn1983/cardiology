using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtConsiliumService
    {
        IList<DdtConsilium> GetAll();

        DdtConsilium GetById(string id);

        string Save(DdtConsilium obj);
    }
}
