using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtUziService
    {
        IList<DdtUzi> GetAll();

        DdtUzi GetById(string id);

        DdtUzi GetByParentId(string parentId);

        IList<DdtUzi> GetListByParentId(string parentId);

        List<DdtUzi> GetByQuery(string sql);

        string Save(DdtUzi obj);
    }
}
