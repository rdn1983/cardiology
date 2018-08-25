using Cardiology.Model;

namespace Cardiology
{
    interface IDocbaseControl
    {
        void saveObject(DdtHospital hospitalitySession);
        string getObjectId();
    }
}
