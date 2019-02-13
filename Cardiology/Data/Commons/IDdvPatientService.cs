using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdvPatientService
    {
        IList<DdvPatient> GetAll();

        DdvPatient GetById(string id);
    }
}
