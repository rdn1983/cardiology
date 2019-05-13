using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtOncologicMarkersService
    {
        IList<DdtOncologicMarkers> GetAll();

        IList<DdtOncologicMarkers> GetByParentId(string parentId);

        DdtOncologicMarkers GetById(string id);

        string Save(DdtOncologicMarkers obj);
    }
}
