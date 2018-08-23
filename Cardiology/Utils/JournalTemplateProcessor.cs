using Cardiology.Model;
using System.Collections.Generic;
using System.IO;

namespace Cardiology.Utils
{
    class JournalTemplateProcessor : ITemplateProcessor
    {
        private const string TEMPLATE_FILE_NAME = "journal_template.doc";

        public bool accept(string templateType)
        {
            return DdtJournal.TABLE_NAME.Equals(templateType);
        }

        public string processTemplate(string hospitalitySession, string objectId, Dictionary<string, string> aditionalValues)
        {
            Dictionary<string, string> values = null;
            if (aditionalValues != null)
            {
                values = new Dictionary<string, string>(aditionalValues);
            }
            else
            {
                values = new Dictionary<string, string>();
            }
            DataService service = new DataService();
            DdtJournal journal = service.queryObjectById<DdtJournal>(DdtJournal.TABLE_NAME, objectId);
            values.Add("{time}", journal.DsdtAdmissionDate.ToShortTimeString());
            values.Add("{complaints}", journal.DssComplaints);
            values.Add("{journal}", journal.DssJournal);
            values.Add("{monitor}", journal.DssMonitor);

            DdtDoctors doc = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, journal.DsidDoctor);
            values.Add("{doctor.initials}", doc == null ? "" : doc.DssInitials);

            List<string> partsPaths = new List<string>();
            string mainPart = TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, values);
            partsPaths.Add(mainPart);
            List<DdtVariousSpecConcluson> cardioConclusions = service.queryObjectsCollection<DdtVariousSpecConcluson>
                       ("Select * from " + DdtVariousSpecConcluson.TABLE_NAME + " WHERE dsid_parent='" +
                       objectId + "' AND dsb_additional_bool=false order by dsdt_admission_date");
            foreach (DdtVariousSpecConcluson conclusion in cardioConclusions)
            {
                Dictionary<string, string> conclusionValues = new Dictionary<string, string>();
                conclusionValues.Add("{time}", conclusion.DsdtAdmissionDate.ToShortTimeString());
                conclusionValues.Add("{complaints}", "");
                conclusionValues.Add("{journal}", conclusion.DssSpecialistConclusion);
                conclusionValues.Add("{monitor}", conclusion.DssAdditionalInfo4);
                conclusionValues.Add("{doctor.initials}", doc == null ? "" : doc.DssInitials);

                partsPaths.Add(TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, conclusionValues));
            }

            return TemplatesUtils.mergeFiles(partsPaths.ToArray(), false);
        }


    }
}
