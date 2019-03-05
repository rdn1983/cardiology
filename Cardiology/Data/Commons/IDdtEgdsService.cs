using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtEgdsService
    {
        IList<DdtEgds> GetAll();

        IList<DdtEgds> GetListByParentId(string parentId);

        DdtEgds GetById(string id);

        DdtEgds GetByHospitalSessionAndParentId(string hospitalSession, string parentId);

        DdtEgds GetByParentId(string parentId);

        string Save(DdtEgds obj);
    }
}
