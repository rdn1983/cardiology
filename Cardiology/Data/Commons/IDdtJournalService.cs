using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtJournalService
    {
        IList<DdtJournal> GetAll();

        List<DdtJournal> GetByQuery(string sql);

        DdtJournal GetObject(string sql);

        DdtJournal GetById(string id);

        DdtJournal GetByHospitalSessionAndJournalType(string hospitalSession, int jornalType);

        List<DdtJournal> GetByJournalDayId(string id);

        string Save(DdtJournal obj);
    }
}
