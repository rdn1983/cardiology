using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtPatientService
    {
        IList<DdtPatient> GetAll();
    }
}
