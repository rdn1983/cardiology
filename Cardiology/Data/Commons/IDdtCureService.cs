using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtCureService
    {
        IList<DdtCure> GetAll();

        DdtCure GetById(string id);
    }
}
