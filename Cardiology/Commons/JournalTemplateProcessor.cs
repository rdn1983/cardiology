using Cardiology.Data;
using Cardiology.Data.Dictionary;
using System;
using System.Collections.Generic;
using System.IO;

namespace Cardiology.Commons
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
            DdtJournal journal = service.queryObjectById<DdtJournal>(objectId);
            DdtDoctors doc = service.queryObjectById<DdtDoctors>(journal.DsidDoctor);
            values.Add("{doctor.initials}", doc == null ? "" : doc.DssInitials);

            List<string> partsPaths = new List<string>();
            if (journal.DsiJournalType == (int)DdtJournalDsiType.AFTER_KAG)
            {
                partsPaths.AddRange(collectKagJournalPaths(service, journal, doc, values));
            }
            else
            {
                values.Add("{time}", journal.DsdtAdmissionDate.ToShortTimeString());
                values.Add("{title}", " ");
                values.Add("{complaints}", journal.DssComplaints);
                values.Add("{journal}", journal.DssJournal);
                values.Add("{monitor}", journal.DssMonitor);
                values.Add("{kag_diagnosis}", " ");
                values.Add("{diagnosis}", " ");
                string mainPart = TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, values);
                partsPaths.Add(mainPart);
            }
            return TemplatesUtils.mergeFiles(partsPaths.ToArray(), false);
        }


        private List<string> collectKagJournalPaths(DataService service, DdtJournal journal, DdtDoctors doc, Dictionary<string, string> values)
        {
            List<string> partsPaths = new List<string>();

            List<DdtVariousSpecConcluson> cardioConclusions = service.queryObjectsCollection<DdtVariousSpecConcluson>("Select * from " +
                DdtVariousSpecConcluson.TABLE_NAME + " WHERE dsid_parent='" + journal.RObjectId + "' AND dsb_additional_bool=false order by dsdt_admission_date");
            DdtKag kag = service.queryObjectByAttrCond<DdtKag>(DdtKag.TABLE_NAME, "dsid_parent", journal.RObjectId, true);

            DateTime journalDate = journal.DsdtAdmissionDate;
            if (cardioConclusions.Count > 0)
            {
                DdtVariousSpecConcluson kagMainPart = cardioConclusions[0];
                values.Add("{time}", journalDate.ToShortTimeString());
                values.Add("{title}", "Осмотр дежурного кардиореаниматолога " + (doc == null ? "" : doc.DssInitials) + 
                    " совместно с ангиохирургом Потехиным Д.А. \n Пациента доставили из рентгеноперационной.");
                values.Add("{complaints}", " ");
                values.Add("{journal}", kagMainPart.DssSpecialistConclusion);
                values.Add("{monitor}", kagMainPart.DssAdditionalInfo4);
                values.Add("{kag_diagnosis}", kag == null ? " " : "У пациента по данным КАГ выявлено:" + kag.DssKagAction + "\n");
                values.Add("{diagnosis}", "Таким образом, у пациента:" + journal.DssDiagnosis);
                partsPaths.Add(TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, values));
                cardioConclusions.Remove(kagMainPart);
            }

            Dictionary<string, string> surgeryValues = new Dictionary<string, string>();
            surgeryValues.Add("{time}", journalDate.AddHours(1).ToShortTimeString());
            surgeryValues.Add("{title}", "Осмотр ренгеноваскулярного хирурга Потехина Д.А. \n");
            surgeryValues.Add("{complaints}", journal.DssComplaints);
            surgeryValues.Add("{journal}", journal.DssJournal);
            surgeryValues.Add("{monitor}", " ");
            surgeryValues.Add("{kag_diagnosis}", " ");
            surgeryValues.Add("{diagnosis}", " ");
            surgeryValues.Add("{doctor.initials}", doc == null ? "" : doc.DssInitials);
            partsPaths.Add(TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, surgeryValues));

            foreach (DdtVariousSpecConcluson conclusion in cardioConclusions)
            {
                Dictionary<string, string> conclusionValues = new Dictionary<string, string>();
                conclusionValues.Add("{time}", conclusion.DsdtAdmissionDate.ToShortTimeString());
                conclusionValues.Add("{complaints}", " ");
                conclusionValues.Add("{title}", " ");
                conclusionValues.Add("{journal}", conclusion.DssSpecialistConclusion);
                conclusionValues.Add("{monitor}", conclusion.DssAdditionalInfo4);
                conclusionValues.Add("{doctor.initials}", doc == null ? "" : doc.DssInitials);
                conclusionValues.Add("{kag_diagnosis}", " ");
                conclusionValues.Add("{diagnosis}", " ");

                partsPaths.Add(TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, conclusionValues));
            }

            DdtVariousSpecConcluson releaseConclusion = service.queryObject<DdtVariousSpecConcluson>("Select * from " + DdtVariousSpecConcluson.TABLE_NAME +
                " WHERE dsid_parent='" + journal.RObjectId + "' AND dsb_additional_bool=true");
            if (releaseConclusion != null)
            {
                Dictionary<string, string> conclusionValues = new Dictionary<string, string>();
                conclusionValues.Add("{time}", releaseConclusion.DsdtAdmissionDate.ToShortTimeString());
                conclusionValues.Add("{complaints}", " ");
                conclusionValues.Add("{title}", " ");
                conclusionValues.Add("{journal}", releaseConclusion.DssSpecialistConclusion);
                conclusionValues.Add("{monitor}", releaseConclusion.DssAdditionalInfo4);
                conclusionValues.Add("{doctor.initials}", doc == null ? "" : doc.DssInitials);
                conclusionValues.Add("{kag_diagnosis}", kag == null ? " " : "У пациента по данным КАГ выявлено:" + kag.DssKagAction + "\n");
                conclusionValues.Add("{diagnosis}", "Таким образом, у пациента:" + journal.DssDiagnosis);
                partsPaths.Add(TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, conclusionValues));
            }
            return partsPaths;
        }

    }
}
