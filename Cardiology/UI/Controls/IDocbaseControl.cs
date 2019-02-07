using Cardiology.Data.Model;

namespace Cardiology.UI.Controls
{
    interface IDocbaseControl
    {
        bool getIsValid();
        bool isDirty();
        void saveObject(DdtHospital hospitalitySession, string parentId, string parentType);
        string getObjectId();
        object getObject();
        void refreshObject(object obj);
        bool isVisible();
    }
}
