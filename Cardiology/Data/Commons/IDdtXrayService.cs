using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtXrayService
    {
        IList<DdtXray> GetAll();
    }
}
