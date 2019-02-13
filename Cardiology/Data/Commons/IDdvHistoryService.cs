using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdvHistoryService
    {
        IList<DdvHistory> GetAll();

        DdvHistory GetById(string id);
    }
}
