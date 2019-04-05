using Cardiology.Data;
using System;
using System.Collections.Generic;
using System.IO;
using Cardiology.Data.Model2;

namespace Cardiology.Commons
{
    class JournalTemplateProcessor : ITemplateProcessor
    {
        private const string TEMPLATE_FILE_NAME = "journal_template.doc";

        public bool accept(string templateType)
        {
            return DdtJournal.NAME.Equals(templateType, StringComparison.Ordinal);
        }

        public string processTemplate(IDbDataService service, string hospitalitySession, string objectId, Dictionary<string, string> aditionalValues)
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
            DdtJournal journal = service.GetDdtJournalService().GetById(objectId);
            DdvDoctor doc = service.GetDdvDoctorService().GetById(journal.Doctor);
            values.Add("{doctor.initials}", doc == null ? "" : doc.ShortName);

            List<string> partsPaths = new List<string>();
            if (journal.JournalType == (int)DdtJournalDsiType.AFTER_KAG)
            {
                partsPaths.AddRange(collectKagJournalPaths(service, journal, doc, values));
            }
            else
            {
                values.Add("{time}", journal.AdmissionDate.ToShortTimeString());
                values.Add("{title}", " ");
                values.Add("{complaints}", journal.Complaints);
                values.Add("{journal}", journal.Journal);
                values.Add("{monitor}", journal.Monitor);
                values.Add("{kag_diagnosis}", " ");
                values.Add("{diagnosis}", " ");
                string mainPart = TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, values);
                partsPaths.Add(mainPart);
            }
            return TemplatesUtils.MergeFiles(partsPaths.ToArray(), false);
        }


        private List<string> collectKagJournalPaths(IDbDataService service, DdtJournal journal, DdvDoctor doc, Dictionary<string, string> values)
        {
            List<string> partsPaths = new List<string>();

            IList<DdtVariousSpecConcluson> cardioConclusions = service.GetDdtVariousSpecConclusonService().GetListByParentId(journal.ObjectId);

            DdtKag kag = service.GetDdtKagService().GetByParentId(journal.ObjectId);

            DateTime journalDate = journal.AdmissionDate;
            if (cardioConclusions.Count > 0)
            {
                DdtVariousSpecConcluson kagMainPart = cardioConclusions[0];
                values.Add("{time}", journalDate.ToShortTimeString());
                values.Add("{title}", "Осмотр дежурного кардиореаниматолога " + (doc == null ? "" : doc.ShortName) + 
                    " совместно с ангиохирургом Потехиным Д.А. \n Пациента доставили из рентгеноперационной.");
                values.Add("{complaints}", " ");
                values.Add("{journal}", kagMainPart.SpecialistConclusion);
                values.Add("{monitor}", kagMainPart.AdditionalInfo4);
                values.Add("{kag_diagnosis}", kag == null ? " " : "У пациента по данным КАГ выявлено:" + kag.KagAction + "\n");
                values.Add("{diagnosis}", "Таким образом, у пациента:" + journal.Diagnosis);
                partsPaths.Add(TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, values));
                cardioConclusions.Remove(kagMainPart);
            }

            Dictionary<string, string> surgeryValues = new Dictionary<string, string>();
            surgeryValues.Add("{time}", journalDate.AddHours(1).ToShortTimeString());
            surgeryValues.Add("{title}", "Осмотр ренгеноваскулярного хирурга Потехина Д.А. \n");
            surgeryValues.Add("{complaints}", journal.Complaints);
            surgeryValues.Add("{journal}", journal.Journal);
            surgeryValues.Add("{monitor}", " ");
            surgeryValues.Add("{kag_diagnosis}", " ");
            surgeryValues.Add("{diagnosis}", " ");
            surgeryValues.Add("{doctor.initials}", doc == null ? "" : doc.ShortName);
            partsPaths.Add(TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, surgeryValues));

            foreach (DdtVariousSpecConcluson conclusion in cardioConclusions)
            {
                Dictionary<string, string> conclusionValues = new Dictionary<string, string>();
                conclusionValues.Add("{time}", conclusion.AdmissionDate.ToShortTimeString());
                conclusionValues.Add("{complaints}", " ");
                conclusionValues.Add("{title}", " ");
                conclusionValues.Add("{journal}", conclusion.SpecialistConclusion);
                conclusionValues.Add("{monitor}", conclusion.AdditionalInfo4);
                conclusionValues.Add("{doctor.initials}", doc == null ? "" : doc.ShortName);
                conclusionValues.Add("{kag_diagnosis}", " ");
                conclusionValues.Add("{diagnosis}", " ");

                partsPaths.Add(TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, conclusionValues));
            }

            DdtVariousSpecConcluson releaseConclusion = service.GetDdtVariousSpecConclusonService().GetByParentId(journal.ObjectId);
            if (releaseConclusion != null)
            {
                Dictionary<string, string> conclusionValues = new Dictionary<string, string>();
                conclusionValues.Add("{time}", releaseConclusion.AdmissionDate.ToShortTimeString());
                conclusionValues.Add("{complaints}", " ");
                conclusionValues.Add("{title}", " ");
                conclusionValues.Add("{journal}", releaseConclusion.SpecialistConclusion);
                conclusionValues.Add("{monitor}", releaseConclusion.AdditionalInfo4);
                conclusionValues.Add("{doctor.initials}", doc == null ? "" : doc.ShortName);
                conclusionValues.Add("{kag_diagnosis}", kag == null ? " " : "У пациента по данным КАГ выявлено:" + kag.KagAction + "\n");
                conclusionValues.Add("{diagnosis}", "Таким образом, у пациента:" + journal.Diagnosis);
                partsPaths.Add(TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, conclusionValues));
            }
            return partsPaths;
        }

    }
}
