using Cardiology.Data.Model2;
using System.Collections.Generic;

namespace Cardiology.Data.Commons
{
    public interface IDdtRelationService
    {

        DdtRelation GetById(string id);

        IList<DdtRelation> GetByParentId(string parentId);

        DdtRelation GetByParentAndChildIds(string parentId, string childId);

        IList<DdtRelation> GetByParentAndChildType(string parentId, string childType);

        string Save(DdtRelation relation);

        void RemoveConnectionByParentAndChildIds(string parentId, string childId);

        void RemoveConnectionById(string id);
    }
}
