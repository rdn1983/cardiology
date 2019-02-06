using Cardiology.Data.Model2;
using System.Collections.Generic;

namespace Cardiology.Data
{
    public interface IDmGroupService
    {
        IList<DmGroupV2> GetList();
    }
}
