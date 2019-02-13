using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtTransferService
    {
        IList<DdtTransfer> GetAll();

        DdtTransfer GetById(string id);
    }
}
