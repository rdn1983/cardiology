using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtBloodAnalysisService
    {
        IList<DdtBloodAnalysis> GetAll();

        DdtBloodAnalysis GetById(string id);

        IList<DdtBloodAnalysis> GetByParentId(string parentId);

        DdtBloodAnalysis GetByHospitalSession(string hospitalSession);

        List<DdtBloodAnalysis> GetByQuery(string sql);

        string Save(DdtBloodAnalysis obj);
    }
}
