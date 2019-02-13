using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtHormonesService
    {
        IList<DdtHormones> GetAll();

        DdtHormones GetById(string id);
    }
}
