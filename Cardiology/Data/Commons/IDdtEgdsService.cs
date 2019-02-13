using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtEgdsService
    {
        IList<DdtEgds> GetAll();

        DdtEgds GetById(string id);
    }
}
