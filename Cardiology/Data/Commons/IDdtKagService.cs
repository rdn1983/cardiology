using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtKagService
    {
        IList<DdtKag> GetAll();

        DdtKag GetById(string id);

        DdtKag GetByParentId(string parentId);

        DdtKag GetByHospitalSession(string hospitalSession);

        string Save(DdtKag obj);
    }
}
