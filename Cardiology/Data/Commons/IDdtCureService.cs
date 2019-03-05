using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtCureService
    {
        IList<DdtCure> GetAll();

        DdtCure GetById(string id);

        IList<DdtCure> GetListByMedicineListId(string id);

        IList<DdtCure> GetListByCureTypeId(string cureTypeId);

        IList<DdtCure> GetListByTemplate(string templateName);

        List<DdtCure> GetByQuery(string sql);

        string Save(DdtCure obj);
    }
}
