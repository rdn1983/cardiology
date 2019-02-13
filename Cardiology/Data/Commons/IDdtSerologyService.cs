using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtSerologyService
    {
        IList<DdtSerology> GetAll();

        DdtSerology GetById(string id);
    }
}
