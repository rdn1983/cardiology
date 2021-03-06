using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtHistoryService
    {
        IList<DdtHistory> GetAll();

        DdtHistory GetById(string id);

        void DeleteHistoryById(string operationId);
    }
}
