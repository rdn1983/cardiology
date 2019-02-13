using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdvDoctorervice
    {
        IList<DdtDoctor> GetAll();

        DdtDoctor GetById(string id);
    }
}
