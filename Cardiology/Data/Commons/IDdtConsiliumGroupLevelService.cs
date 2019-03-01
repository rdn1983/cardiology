using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtConsiliumGroupLevelService
    {
        IList<DdtConsiliumGroupLevel> GetAll();

        DdtConsiliumGroupLevel GetById(string id);

        string Save(DdtConsiliumGroupLevel obj);
    }
}
