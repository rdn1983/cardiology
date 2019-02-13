using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtReleasePatientService
    {
        IList<DdtReleasePatient> GetAll();

        DdtReleasePatient GetById(string id);
    }
}
