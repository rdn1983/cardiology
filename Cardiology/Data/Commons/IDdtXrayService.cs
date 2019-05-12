using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtXrayService
    {
        IList<DdtXRay> GetAll();

        IList<DdtXRay> GetByParentId(string parentId);

        DdtXRay GetById(string id);

        string Save(DdtXRay obj);
    }
}
