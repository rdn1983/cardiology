using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDmGroupUsersService
    {
        IList<DmGroupUsers> GetAll();

        DmGroupUsers GetById(string id);
    }
}
