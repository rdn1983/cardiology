using Cardiology.Data.Model2;
using System.Collections.Generic;

namespace Cardiology.Data
{
    public interface IDbCureService
    {
        IList<DdtCureTypeV2> GetAllTypes();
    }
}
