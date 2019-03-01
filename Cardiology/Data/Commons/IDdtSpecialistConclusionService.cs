using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtSpecialistConclusionService
    {
        IList<DdtSpecialistConclusion> GetAll();

        DdtSpecialistConclusion GetById(string id);

        IList<DdtSpecialistConclusion> GetListByParentId(string parentId);

        string Save(DdtSpecialistConclusion obj);
    }
}
