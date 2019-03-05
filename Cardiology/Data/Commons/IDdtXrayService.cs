using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtXrayService
    {
        IList<DdtXRay> GetAll();

        IList<DdtXRay> GetListByParentId(string parentId);

        DdtXRay GetById(string id);

        DdtXRay GetByParentId(string parentId);

        string Save(DdtXRay obj);
    }
}
