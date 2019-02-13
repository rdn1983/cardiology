using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtHistoryService
    {
        IList<DdtHistory> GetAll();
    }
}
