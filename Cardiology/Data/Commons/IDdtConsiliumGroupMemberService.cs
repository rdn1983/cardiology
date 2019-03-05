using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtConsiliumGroupMemberService
    {
        IList<DdtConsiliumGroupMember> GetAll();

        DdtConsiliumGroupMember GetById(string id);

        DdtConsiliumGroupMember GetByGroupName(string groupName);

        string Save(DdtConsiliumGroupMember obj);
    }
}
