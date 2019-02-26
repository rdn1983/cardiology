using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtInspectionService
    {
        IList<DdtInspection> GetAll();

        DdtInspection GetById(string id);

        string Save(DdtInspection obj);
    }
}
