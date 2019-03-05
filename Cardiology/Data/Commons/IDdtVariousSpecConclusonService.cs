using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtVariousSpecConclusonService
    {
        IList<DdtVariousSpecConcluson> GetAll();

        IList<DdtVariousSpecConcluson> GetListByParentId(string parentId);

        List<DdtVariousSpecConcluson> GetByQuery(string sql);

        DdtVariousSpecConcluson GetById(string id);

        DdtVariousSpecConcluson GetByParentId(string id);

        string Save(DdtVariousSpecConcluson obj);
    }
}
