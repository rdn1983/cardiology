using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtAlcoProtocolService
    {
        IList<DdtAlcoProtocol> GetAll();

        DdtAlcoProtocol GetById(string id);

        DdtAlcoProtocol GetByHospitalSession(string hospitalSessionId);

        string Save(DdtAlcoProtocol obj);
    }
}
