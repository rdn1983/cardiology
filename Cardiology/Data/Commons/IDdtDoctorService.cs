using System;
using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtDoctorService
    {
        IList<DdtDoctor> GetAll();
    }
}
