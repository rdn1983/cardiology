using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtJournalService
    {
        IList<DdtJournal> GetAll();

        DdtJournal GetById(string id);

        DdtJournal GetByHospitalSessionAndJournalType(string hospitalSession, int jornalType);

        string Save(DdtJournal obj);
    }
}
