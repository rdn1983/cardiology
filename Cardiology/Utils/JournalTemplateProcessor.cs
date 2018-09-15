using Cardiology.Model;
using Cardiology.Model.Dictionary;
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
            if (journal.DsiJournalType == (int)DdtJournalDsiType.AFTER_KAG)
            {
                values.Add("{time}", journal.DsdtAdmissionDate.ToShortTimeString());
                values.Add("{title}", "Осмотр ренгеноваскулярного хирурга Потехина Д.А. \n");
                values.Add("{complaints}", journal.DssComplaints);
                values.Add("{journal}", journal.DssJournal);
                values.Add("{monitor}", " ");
            }
            else
            {
                values.Add("{time}", journal.DsdtAdmissionDate.ToShortTimeString());
                values.Add("{title}", " ");
                values.Add("{complaints}", journal.DssComplaints);
                values.Add("{journal}", journal.DssJournal);
                values.Add("{monitor}", journal.DssMonitor);
            }
            values.Add("{kag_diagnosis}", " ");
            values.Add("{diagnosis}", " ");



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
            if (releaseConclusion!=null)
            {
                Dictionary<string, string> conclusionValues = new Dictionary<string, string>();
                conclusionValues.Add("{time}", releaseConclusion.DsdtAdmissionDate.ToShortTimeString());
                conclusionValues.Add("{complaints}", " ");
                conclusionValues.Add("{title}", " ");
                conclusionValues.Add("{journal}", releaseConclusion.DssSpecialistConclusion);
                conclusionValues.Add("{monitor}", releaseConclusion.DssAdditionalInfo4);
                conclusionValues.Add("{doctor.initials}", doc == null ? "" : doc.DssInitials);
                DdtKag kag = service.queryObjectByAttrCond<DdtKag>(DdtKag.TABLE_NAME, "dsid_parent", journal.RObjectId, true);
                conclusionValues.Add("{kag_diagnosis}", kag == null ? " " : "У больного  по данным КАГ выявлено:" + kag.DssResults + "\n");
                conclusionValues.Add("{diagnosis}", "Таким образом, у пациента:" + journal.DssDiagnosis);
                partsPaths.Add(TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, conclusionValues));
            }

            return TemplatesUtils.mergeFiles(partsPaths.ToArray(), false);
        }


    }
}
