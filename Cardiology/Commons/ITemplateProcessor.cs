using System.Collections.Generic;

namespace Cardiology.Utils
{
    interface ITemplateProcessor
    {

        bool accept(string templateType);

        /*return path to filled template*/
        string processTemplate(string hospitalitySession, string objectId, Dictionary<string, string> aditionalValues);
    }
}
