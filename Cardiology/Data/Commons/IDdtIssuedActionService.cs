using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtIssuedActionService
    {
        IList<DdtIssuedAction> GetAll();

        DdtIssuedAction GetById(string id);

        IList<DdtIssuedAction> GetListByParentId(string parentId);
    }
}
