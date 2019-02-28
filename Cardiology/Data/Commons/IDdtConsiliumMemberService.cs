using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtConsiliumMemberService
    {
        IList<DdtConsiliumMember> GetAll();

        IList<DdtConsiliumMember> GetMembersByConsiliumId(string consiliumId);

        DdtConsiliumMember GetById(string id);

        string Save(DdtConsiliumMember obj);
    }
}
