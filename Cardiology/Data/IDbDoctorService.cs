using Cardiology.Data.Model2;
using System.Collections.Generic;

namespace Cardiology.Data
{
    public interface IDbDoctorService
    {
        IList<DdtDoctorV2> GetDoctorsByGroupName(string groupName);
        IList<DdtDoctorV2> GetAll();
    }
}
