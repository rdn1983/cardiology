using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtHolterService
    {
        IList<DdtHolter> GetAll();

        DdtHolter GetById(string id);

        IList<DdtHolter> GetListByParentId(string parentId);

        string Save(DdtHolter obj);
    }
}
