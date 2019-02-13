using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtConsiliumMemberLevelService
    {
        IList<DdtConsiliumMemberLevel> GetAll();

        DdtConsiliumMemberLevel GetById(string id);
    }
}
