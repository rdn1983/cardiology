using Cardiology.Data.Model2;

namespace Cardiology.Data
{
    public interface IDdtTransfusionService
    {
        DdtTransfusion GetById(string id);

        string Save(DdtTransfusion obj);
    }
}