using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtEkgService
    {
        IList<DdtEkg> GetAll();

        DdtEkg GetById(string id);

        DdtEkg GetByHospitalSessionAndParentId(string hospitalSession, string parentId);

        DdtEkg GetByHospitalSession(string hospitalSession);
    }
}
