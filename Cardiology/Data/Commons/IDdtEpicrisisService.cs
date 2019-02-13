using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtEpicrisisService
    {
        IList<DdtEpicrisis> GetAll();

        DdtEpicrisis GetById(string id);
    }
}
