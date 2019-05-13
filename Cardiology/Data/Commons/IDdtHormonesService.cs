using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtHormonesService
    {
        IList<DdtHormones> GetAll();

        IList<DdtHormones> GetByParentId(string parentId);

        DdtHormones GetById(string id);

        string Save(DdtHormones obj);
    }
}
