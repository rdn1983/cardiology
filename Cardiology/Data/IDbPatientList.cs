using Cardiology.Data.Model2;
using System.Collections.Generic;

namespace Cardiology.Data
{
    public interface IDbPatientService
    {
        IList<DdtPatientV2> GetList();

        IList<DdvActiveHospitalPatientV2> GetActive();
    }
}
