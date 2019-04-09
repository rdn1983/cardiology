using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtConsiliumRelationService
    {
        IList<DdtConsiliumRelation> GetAll();

        List<DdtConsiliumRelation> GetByQuery(string sql);

        IList<DdtConsiliumRelation> GetConsiliumRelationsByConsiliumId(string consiliumId);

        DdtConsiliumRelation GetById(string id);

        string Save(DdtConsiliumRelation obj);
    }
}
