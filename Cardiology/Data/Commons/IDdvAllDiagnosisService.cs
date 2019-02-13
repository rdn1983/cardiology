using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdvAllDiagnosisService
    {
        IList<DdvAllDiagnosis> GetAll();

        DdvAllDiagnosis GetById(string id);
    }
}
