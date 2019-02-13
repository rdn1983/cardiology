using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtJournalService
    {
        IList<DdtJournal> GetAll();
    }
}
