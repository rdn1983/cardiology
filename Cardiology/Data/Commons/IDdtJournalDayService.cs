using Cardiology.Data.Model2;
using System;
using System.Collections.Generic;

namespace Cardiology.Data.Commons
{
    public interface IDdtJournalDayService
    {
        DdtJournalDay GetForDate(string hopitalSesssionId, DateTime date);

        IList<DdtJournalDay> GetBetween(string hopitalSesssionId, DateTime start, DateTime end, int journalType);

        DdtJournalDay GetById(string id);

        string Save(DdtJournalDay obj);

        void Delete(string id);
    }
}
