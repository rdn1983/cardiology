using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtConsiliumGroupService
    {
        IList<DdtConsiliumGroup> GetAll();

        DdtConsiliumGroup GetById(string id);
    }
}
