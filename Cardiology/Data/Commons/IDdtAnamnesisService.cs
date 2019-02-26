using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtAnamnesisService
    {
        IList<DdtAnamnesis> GetAll();

        DdtAnamnesis GetById(string id);

        DdtAnamnesis GetByHospitalSessionId(string hospitalSessionId);

        DdtAnamnesis GetByTemplateName(string templateName);

        string Save(DdtAnamnesis obj);

    }
}
