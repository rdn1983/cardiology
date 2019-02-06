using Cardiology.Data;
using Cardiology.Data.Dictionary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cardiology.Commons
{
    class InspectionTemplateProcessor : ITemplateProcessor
    {
        private const string TEMPLATE_FILE_NAME = "inspectation_template.doc";


        public bool accept(string templateType)
        {
            return DdtInspection.TABLE_NAME.Equals(templateType);
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
            DdtInspection obj = service.queryObjectById<DdtInspection>(objectId);
            values.Add("{date}", obj.DsdtInspectionDate.ToShortDateString());
            values.Add("{time}", obj.DsdtInspectionDate.ToShortTimeString());
            values.Add("{patient.diagnosis}", obj.DssDiagnosis);
            values.Add("{complaints}", obj.DssComplaints);
            values.Add("{inspection}", obj.DssInspection);
            values.Add("{kateter}", obj.DssKateterPlacement);
            values.Add("{result}", obj.DssInspectionResult);

            DdtPatient patient = service.queryObjectById<DdtPatient>(obj.DsidPatient);
            values.Add("{patient.initials}", patient == null ? "" : patient.DssInitials);
            values.Add("{patient.age}", patient == null ? "" : (DateTime.Now.Year - patient.DsdtBirthdate.Year) + "");

            DdtDoctors doc = service.queryObjectById<DdtDoctors>(obj.DsidDoctor);
            values.Add("{doctor.who.short}", doc == null ? "" : doc.DssInitials);

            putBloodData(values, service, obj.RObjectId);
            putEkgData(values, service, obj.RObjectId);
            putHolterData(values, service, obj.RObjectId);
            putSpecialistData(values, service, obj.RObjectId);
            putUziData(values, service, obj.RObjectId);
            putKagData(values, service, obj.DsidHospitalitySession);

            return TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, values);
        }


        private void putSpecialistData(Dictionary<string, string> values, DataService service, string objId)
        {
            List<DdtSpecialistConclusion> lspecobj = service.queryObjectsCollection<DdtSpecialistConclusion>(@"SELECT * FROM " + DdtSpecialistConclusion.TABLE_NAME +
                " WHERE dsid_parent='" + objId + "'");
            StringBuilder specBld = new StringBuilder();
            foreach (DdtSpecialistConclusion obj in lspecobj)
            {
                specBld.Append(obj.DsdtAnalysisDate.ToShortDateString());
                if (CommonUtils.isNotBlank(obj.DssEndocrinologist))
                {
                    specBld.Append("Эндокринолог ").Append(obj.DssEndocrinologist).Append('\n');
                }
                if (CommonUtils.isNotBlank(obj.DssNeurolog))
                {
                    specBld.Append("Невролог ").Append(obj.DssNeurolog).Append('\n');
                }
                if (CommonUtils.isNotBlank(obj.DssNeuroSurgeon))
                {
                    specBld.Append("Нейрохирург ").Append(obj.DssNeuroSurgeon).Append('\n');
                }
                if (CommonUtils.isNotBlank(obj.DssSurgeon))
                {
                    specBld.Append("Хирург ").Append(obj.DssSurgeon).Append('\n');
                }

                specBld.Append('\n');
            }
            values.Add("{on_spec}", lspecobj.Count > 0 ? "Заключения специалистов:" : "");
            values.Add("{spec}", specBld.ToString() + (lspecobj.Count > 0 ? "\n" : ""));
        }

        private void putKagData(Dictionary<string, string> values, DataService service, string sessionId)
        {
            StringBuilder bld = new StringBuilder();
            DdtJournal kagJournal = service.queryObject<DdtJournal>(@"SELECT * FROM " + DdtJournal.TABLE_NAME +
                   " WHERE dsid_hospitality_session='" + sessionId + "' AND dsi_journal_type=" + (int)DdtJournalDsiType.AFTER_KAG +
                   " ORDER BY dsdt_admission_date desc");
            if (kagJournal != null)
            {
                DdtKag kag = service.queryObjectByAttrCond<DdtKag>(DdtKag.TABLE_NAME, "dsid_parent", kagJournal.RObjectId, true);
                if (kag != null)
                {
                    bld.Append("Пациент в экстренном порядке проведена КАГ. Коронарография от ")
                        .Append(kag.DsdtAnalysisDate.ToShortDateString())
                        .Append(":")
                        .Append(kag.DssKagAction);
                }
            }
            values.Add("{kag}", bld.ToString());
        }

        private void putHolterData(Dictionary<string, string> values, DataService service, string objId)
        {
            List<DdtHolter> lholterobj = service.queryObjectsCollection<DdtHolter>(@"SELECT * FROM " + DdtHolter.TABLE_NAME + " WHERE dsid_parent='" + objId + "'");
            StringBuilder holterBld = new StringBuilder();
            foreach (DdtHolter obj in lholterobj)
            {
                holterBld.Append(obj.DsdtAnalysisDate.ToShortDateString()).Append(" ").Append(obj.DssHolter).Append('\n');
            }
            values.Add("{on_holter}", lholterobj.Count > 0 ? "Холтер:" : "");
            values.Add("{holter}", holterBld.ToString() + (lholterobj.Count > 0 ? "\n" : ""));
        }

        private void putEkgData(Dictionary<string, string> values, DataService service, string objId)
        {
            List<DdtEkg> ekg = service.queryObjectsCollection<DdtEkg>(@"SELECT * from ddt_ekg WHERE dsid_parent='" + objId + "'");
            StringBuilder ekgBld = new StringBuilder();
            foreach (DdtEkg ekk in ekg)
            {
                ekgBld.Append(ekk.DsdtAnalysisDate.ToShortDateString()).Append(" ").Append(ekk.DssEkg).Append('\n');
            }
            values.Add("{on_ekg}", ekg.Count > 0 ? "ЭКГ:" : "");
            values.Add("{ekg}", ekgBld.ToString() + (ekg.Count > 0 ? "\n" : ""));
        }

        private void putUziData(Dictionary<string, string> values, DataService service, string objId)
        {
            List<DdtUzi> uzies = service.queryObjectsCollection<DdtUzi>(@"SELECT * from " + DdtUzi.TABLE_NAME + " WHERE dsid_parent='" + objId + "'");
            StringBuilder uziBld = new StringBuilder();
            foreach (DdtUzi uzObj in uzies)
            {
                uziBld.Append(uzObj.DsdtAnalysisDate.ToShortDateString()).Append(" ");
                if (CommonUtils.isNotBlank(uzObj.DssCds))
                {
                    uziBld.Append("ЧДС ").Append(uzObj.DssCds).Append('\n');
                }
                if (CommonUtils.isNotBlank(uzObj.DssEhoKg))
                {
                    uziBld.Append("ЭХО КГ ").Append(uzObj.DssEhoKg).Append('\n');
                }
                if (CommonUtils.isNotBlank(uzObj.DssPleursUzi))
                {
                    uziBld.Append("УЗИ плевр ").Append(uzObj.DssPleursUzi).Append('\n');
                }
                if (CommonUtils.isNotBlank(uzObj.DssUzdBca))
                {
                    uziBld.Append("УЗи БЦА ").Append(uzObj.DssUzdBca).Append('\n');
                }
                if (CommonUtils.isNotBlank(uzObj.DssUziObp))
                {
                    uziBld.Append("УЗИ ОБП ").Append(uzObj.DssUziObp).Append('\n');
                }
            }
            values.Add("{on_uzi}", uzies.Count > 0 ? "На УЗИ:" : "");
            values.Add("{uzi}", uziBld.ToString() + (uzies.Count > 0 ? "\n" : ""));
        }

        private void putBloodData(Dictionary<string, string> values, DataService service, string objId)
        {
            List<DdtBloodAnalysis> bloods = service.queryObjectsCollection<DdtBloodAnalysis>(@"SELECT * FROM " + DdtBloodAnalysis.TABLE_NAME +
                " WHERE dsid_parent='" + objId + "'");
            StringBuilder bloodBld = new StringBuilder();
            foreach (DdtBloodAnalysis drop in bloods)
            {
                bloodBld.Append(drop.DsdtAnalysisDate.ToShortDateString()).Append(" ");
                bloodBld.Append("креатинин").Append(" ").Append(drop.DsdCreatinine).Append(" ");
                bloodBld.Append("АЛТ").Append(" ").Append(drop.DsdAlt).Append(" ");
                bloodBld.Append("АСТ").Append(" ").Append(drop.DsdAst).Append(" ");
                bloodBld.Append("КФК").Append(" ").Append(drop.DsdKfk).Append(" ");
                bloodBld.Append("КФК МВ").Append(" ").Append(drop.DsdKfkMv).Append(" ");
                bloodBld.Append("гемоглобин").Append(" ").Append(drop.DsdProtein).Append(" ");
                bloodBld.Append("лейкоциты").Append(" ").Append(drop.DsdLeucocytes).Append(" ");
                bloodBld.Append('\n');
            }
            values.Add("{on_blood}", bloods.Count > 0 ? "В анализах крови:" : "");
            values.Add("{blood}", bloodBld.ToString() + (bloods.Count > 0 ? "\n" : ""));
        }

    }
}
