﻿using Cardiology.Data;
using System;
using System.Collections.Generic;
using System.IO;
using Cardiology.Data.Model2;

namespace Cardiology.Commons
{
    class JournalTemplateProcessor : AbstractTemplateProcessor, ITemplateProcessor
    {
        private const string TEMPLATE_FILE_NAME = "journal_template.doc";

        public bool accept(string templateType)
        {
            return DdtJournal.NAME.Equals(templateType, StringComparison.Ordinal) || DdtJournalDay.NAME.Equals(templateType, StringComparison.Ordinal);
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
            DdtJournalDay day = service.GetDdtJournalDayService().GetById(objectId);
            PutAnalysisData(values, service, objectId);
            DdvDoctor doc = service.GetDdvDoctorService().GetById(day.Doctor);
            values.Add("{doctor.initials}", doc == null ? "" : doc.ShortName);

            IList<DdtKag> kags = service.GetDdtKagService().GetByParentId(day.ObjectId);
            DdtKag kag = kags.Count > 0 ? kags[0] : null;
            string kagValue = "";
            if (kag != null)
            {
                kagValue += kag.Results == null ? "" : "У пациента по данным КАГ выявлено:" + kag.Results + "\n";
                kagValue += kag.KagManipulation == null ? "" : "Пациенту выполнено:" + kag.KagManipulation + "\n";
                kagValue += kag.KagAction == null ? "" : "Таким образом, у пациента:" + kag.KagAction + "\n";
            }

            List<string> partsPaths = new List<string>();
            if (day.JournalType == (int)DdtJournalDsiType.AfterKag)
            {
                Dictionary<string, string> first = new Dictionary<string, string>();
                DdtVariousSpecConcluson cardiovascular = service.GetDdtVariousSpecConclusonService().GetByParentId(objectId);
                DdvDoctor surgeryDoc = service.GetDdvDoctorService().GetById(cardiovascular?.AdditionalInfo4);
                first.Add("{time}", day.AdmissionDate.ToShortTimeString());
                first.Add("{title}", "Осмотр дежурного кардиореаниматолога " + (doc == null ? "" : doc.ShortName) +
                    " совместно с ангиохирургом " + surgeryDoc?.ShortName + ". \n Пациента доставили из рентгеноперационной.");
                first.Add("{complaints}", "Жалоб на момент осмотра не предъявляет.");
                first.Add("{journal}", JournalShuffleUtils.shuffleJournalText());
                first.Add("{on_monitor}", "");
                first.Add("{monitor}", "");
                first.Add("{doctor.initials}", doc == null ? "" : doc.ShortName);

                first.Add("{kag_diagnosis}", kagValue);
                first.Add("{diagnosis}", kag == null ? "Таким образом, у пациента:" + day.Diagnosis : "");
                PutAnalysisData(first, service, null);
                partsPaths.Add(TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, first));

                Dictionary<string, string> surgeryValues = new Dictionary<string, string>();
                surgeryValues.Add("{time}", cardiovascular.AdmissionDate.ToShortTimeString());
                surgeryValues.Add("{title}", "Осмотр ренгеноваскулярного хирурга " + surgeryDoc?.ShortName + ". \n");
                surgeryValues.Add("{complaints}", "Жалоб на момент осмотра не предъявляет.");
                surgeryValues.Add("{journal}", cardiovascular?.SpecialistConclusion);
                surgeryValues.Add("{on_monitor}", "");
                surgeryValues.Add("{monitor}", " ");
                surgeryValues.Add("{kag_diagnosis}", " ");
                surgeryValues.Add("{diagnosis}", " ");
                surgeryValues.Add("{doctor.initials}", surgeryDoc == null ? "" : surgeryDoc.ShortName);
                PutAnalysisData(surgeryValues, service, null);
                partsPaths.Add(TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, surgeryValues));
            }

            List<DdtJournal> journals = service.GetDdtJournalService().GetByJournalDayId(objectId);
            for (int i = 0; i < journals.Count; i++)
            {
                Dictionary<string, string> jrnlValues = new Dictionary<string, string>();
                DdtJournal journal = journals[i];
                jrnlValues.Add("{time}", journal.AdmissionDate.ToShortTimeString());
                jrnlValues.Add("{title}", " ");
                jrnlValues.Add("{complaints}", journal.Complaints);
                jrnlValues.Add("{on_monitor}", string.IsNullOrEmpty(journal.Monitor) ? string.Empty : "По монитору: ");
                jrnlValues.Add("{journal}", journal.Journal);
                jrnlValues.Add("{monitor}", string.IsNullOrEmpty(journal.Monitor) ? string.Empty : journal.Monitor);
                DdvDoctor jrnlDoc = service.GetDdvDoctorService().GetById(journal.Doctor);
                jrnlValues.Add("{doctor.initials}", day.JournalType == (int)DdtJournalDsiType.AfterKag || jrnlDoc == null ? doc?.ShortName : jrnlDoc.ShortName);
                if (i == journals.Count - 1)
                {
                    jrnlValues.Add("{kag_diagnosis}", kagValue);
                    jrnlValues.Add("{diagnosis}", String.IsNullOrEmpty(day.Diagnosis) ? "" : "Таким образом, у пациента:" + day.Diagnosis);
                    PutAnalysisData(jrnlValues, service, objectId);
                }
                else
                {
                    jrnlValues.Add("{kag_diagnosis}", " ");
                    jrnlValues.Add("{diagnosis}", " ");
                    PutAnalysisData(jrnlValues, service, null);
                }
                string mainPart = TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, jrnlValues);
                partsPaths.Add(mainPart);
            }

            DdvPatient patient = service.GetDdvPatientService().GetById(day.Patient);
            string resultName = TemplatesUtils.getTempFileName("Журнал", patient.FullName);
            return TemplatesUtils.MergeFiles(partsPaths.ToArray(), false, resultName);
        }

    }
}
