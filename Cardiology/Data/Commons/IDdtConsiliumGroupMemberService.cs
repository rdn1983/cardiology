using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtConsiliumGroupMemberService
    {
        IList<DdtConsiliumGroupMember> GetAll();

        IList<DdtConsiliumGroupMember> GetDefault();

        DdtConsiliumGroupMember GetById(string id);

        DdtConsiliumGroupMember GetByGroupName(string groupName);

        DdtConsiliumGroupMember GetByDoctorAndGroupId(string doctorId, string groupId);

        string Save(DdtConsiliumGroupMember obj);
    }
}
