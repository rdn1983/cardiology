using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtKagService
    {
        IList<DdtKag> GetAll();

        DdtKag GetById(string id);

        IList<DdtKag> GetByParentId(string parentId);

        IList<DdtKag> GetByQuery(string query);

        //DdtKag GetByHospitalSession(string hospitalSession);

        string Save(DdtKag obj);
    }
}
