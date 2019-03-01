using System;
using System.Collections.Generic;
using Cardiology.Data.Model2;

namespace Cardiology.Data.Commons
{
    public interface IDdtValuesService
    {
        IList<DdtValues> GetAll();

        DdtValues GetById(string id);

        DdtValues GetByNameLike(String name);

        IList<DdtValues> GetListByNameLike(string name);

        string Save(DdtValues obj);
    }
}
