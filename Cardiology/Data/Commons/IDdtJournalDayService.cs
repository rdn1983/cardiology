using Cardiology.Data.Model2;
using System;

namespace Cardiology.Data.Commons
{
    public interface IDdtJournalDayService
    {
        DdtJournalDay GetForDate(string hopitalSesssionId, DateTime date);

        DdtJournalDay GetById(string id);

        string Save(DdtJournalDay obj);

        void Delete(string id);
    }
}
