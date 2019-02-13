using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdvActiveHospitalPatientsService
    {
        IList<DdvActiveHospitalPatients> GetAll();

        IList<DdvActiveHospitalPatients> GetList(bool onlyActive);
    }
}
