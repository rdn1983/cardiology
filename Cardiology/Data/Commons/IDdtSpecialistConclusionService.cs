using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtSpecialistConclusionService
    {
        IList<DdtSpecialistConclusion> GetAll();

        DdtSpecialistConclusion GetById(string id);

        IList<DdtSpecialistConclusion> GetByParentId(string parentId);

        List<DdtSpecialistConclusion> GetByQuery(string sql);

        string Save(DdtSpecialistConclusion obj);
    }
}
