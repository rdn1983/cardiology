using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtBloodAnalysisService
    {
        IList<DdtBloodAnalysis> GetAll();

        DdtBloodAnalysis GetById(string id);
    }
}
