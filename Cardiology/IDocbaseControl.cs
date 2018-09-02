using Cardiology.Model;

namespace Cardiology
{
    interface IDocbaseControl
    {
        void saveObject(DdtHospital hospitalitySession, string parentId, string parentType);
        string getObjectId();
    }
}
