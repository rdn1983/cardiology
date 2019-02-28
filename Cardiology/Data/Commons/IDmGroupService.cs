using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDmGroupService
    {
        IList<DmGroup> GetAll();

        DmGroup GetById(string id);

        DmGroup GetGroupByName(string groupName);
    }
}
