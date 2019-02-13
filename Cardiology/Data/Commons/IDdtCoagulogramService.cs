using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtCoagulogramService
    {
        IList<DdtCoagulogram> GetAll();
    }
}
