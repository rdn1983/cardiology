using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtEkgService
    {
        IList<DdtEkg> GetAll();

        IList<DdtEkg> GetListByParentId(string parentId);

        List<DdtEkg> GetByQuery(string sql);

        DdtEkg GetById(string id);

        DdtEkg GetByHospitalSessionAndParentId(string hospitalSession, string parentId);

        DdtEkg GetByParentId(string parentId);

        DdtEkg GetByHospitalSession(string hospitalSession);

        DdtEkg GetByHospitalSessionAndAdmission(string hospitalSession);

        string Save(DdtEkg obj);
    }
}
