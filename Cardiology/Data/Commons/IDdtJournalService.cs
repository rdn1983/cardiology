using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtJournalService
    {
        IList<DdtJournal> GetAll();

        List<DdtJournal> GetByQuery(string sql);

        DdtJournal GetById(string id);

        string Save(DdtJournal obj);
    }
}
