using System.Collections.Generic;
using Cardiology.Data;

namespace Cardiology.Commons
{
    interface ITemplateProcessor
    {

        bool accept(string templateType);

        /*return path to filled template*/
        string processTemplate(IDbDataService service, string hospitalitySession, string objectId, Dictionary<string, string> aditionalValues);
    }
}
