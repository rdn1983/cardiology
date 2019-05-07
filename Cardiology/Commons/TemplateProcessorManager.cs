using System.Collections.Generic;

namespace Cardiology.Commons
{
    class TemplateProcessorManager
    {
        private static List<ITemplateProcessor> processors = new List<ITemplateProcessor> { new FirstInspectationTemplateProcessor(),
            new JournalTemplateProcessor(), new ConsiliumTemplateProcessor(),
            new InspectionTemplateProcessor(), new EpicrisisTemplateProcessor(),
            new TransfusionConsentTemplateProcessor(), new RequestBloodTemplateProcessor()};

        public static ITemplateProcessor getProcessorByObjectType(string type)
        {
            foreach(ITemplateProcessor proc in processors)
            {
                if (proc.accept(type))
                {
                    return proc;
                }
            }
            return null;
        }
    }
}
