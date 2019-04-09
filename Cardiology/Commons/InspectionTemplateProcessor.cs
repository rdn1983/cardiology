using Cardiology.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cardiology.Data.Model2;

namespace Cardiology.Commons
{
    class InspectionTemplateProcessor : ITemplateProcessor
    {
        private const string TEMPLATE_FILE_NAME = "inspectation_template.doc";


        public bool accept(string templateType)
        {
            return DdtInspection.NAME.Equals(templateType, StringComparison.Ordinal);
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
            DdtInspection obj = service.GetDdtInspectionService().GetById(objectId);
            values.Add("{date}", obj.InspectionDate.ToShortDateString());
            values.Add("{time}", obj.InspectionDate.ToShortTimeString());
            values.Add("{patient.diagnosis}", obj.Diagnosis);
            values.Add("{complaints}", obj.Complaints);
            values.Add("{inspection}", obj.Inspection);
            values.Add("{kateter}", obj.KateterPlacement);
            values.Add("{result}", obj.InspectionResult);

            DdvPatient patient = service.GetDdvPatientService().GetById(obj.Patient);
            values.Add("{patient.initials}", patient == null ? "" : patient.ShortName);
            values.Add("{patient.age}", patient == null ? "" : (DateTime.Now.Year - patient.Birthdate.Year) + "");

            DdvDoctor doc = service.GetDdvDoctorService().GetById(obj.Doctor);
            values.Add("{doctor.who.short}", doc == null ? "" : doc.ShortName);

            putBloodData(values, service, obj.ObjectId);
            putEkgData(values, service, obj.ObjectId);
            putHolterData(values, service, obj.ObjectId);
            putSpecialistData(values, service, obj.ObjectId);
            putUziData(values, service, obj.ObjectId);
            putKagData(values, service, obj.HospitalitySession);

            return TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, values);
        }


        private void putSpecialistData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtSpecialistConclusion> lspecobj = service.GetDdtSpecialistConclusionService().GetListByParentId(objId);
            StringBuilder specBld = new StringBuilder();
            foreach (DdtSpecialistConclusion obj in lspecobj)
            {
                specBld.Append(obj.AnalysisDate.ToShortDateString());
                if (!string.IsNullOrEmpty(obj.Endocrinologist))
                {
                    specBld.Append("Эндокринолог ").Append(obj.Endocrinologist).Append('\n');
                }
                if (!string.IsNullOrEmpty(obj.Neurolog))
                {
                    specBld.Append("Невролог ").Append(obj.Neurolog).Append('\n');
                }
                if (!string.IsNullOrEmpty(obj.NeuroSurgeon))
                {
                    specBld.Append("Нейрохирург ").Append(obj.NeuroSurgeon).Append('\n');
                }
                if (!string.IsNullOrEmpty(obj.Surgeon))
                {
                    specBld.Append("Хирург ").Append(obj.Surgeon).Append('\n');
                }

                specBld.Append('\n');
            }
            values.Add("{on_spec}", lspecobj.Count > 0 ? "Заключения специалистов:" : "");
            values.Add("{spec}", specBld.ToString() + (lspecobj.Count > 0 ? "\n" : ""));
        }

        private void putKagData(Dictionary<string, string> values, IDbDataService service, string sessionId)
        {
            StringBuilder bld = new StringBuilder();
            DdtJournal kagJournal = service.GetDdtJournalService()
                .GetByHospitalSessionAndJournalType(sessionId, (int) DdtJournalDsiType.AfterKag);
            if (kagJournal != null)
            {
                DdtKag kag = service.GetDdtKagService().GetByParentId(kagJournal.ObjectId);
                if (kag != null)
                {
                    bld.Append("Пациент в экстренном порядке проведена КАГ. Коронарография от ")
                        .Append(kag.AnalysisDate.ToShortDateString())
                        .Append(":")
                        .Append(kag.KagAction);
                }
            }
            values.Add("{kag}", bld.ToString());
        }

        private void putHolterData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtHolter> lholterobj = service.GetDdtHolterService().GetListByParentId(objId);
            StringBuilder holterBld = new StringBuilder();
            foreach (DdtHolter obj in lholterobj)
            {
                holterBld.Append(obj.AnalysisDate.ToShortDateString()).Append(" ").Append(obj.Holter).Append('\n');
            }
            values.Add("{on_holter}", lholterobj.Count > 0 ? "Холтер:" : "");
            values.Add("{holter}", holterBld.ToString() + (lholterobj.Count > 0 ? "\n" : ""));
        }

        private void putEkgData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtEkg> ekg = service.GetDdtEkgService().GetListByParentId(objId);
            StringBuilder ekgBld = new StringBuilder();
            foreach (DdtEkg ekk in ekg)
            {
                ekgBld.Append(ekk.AnalysisDate.ToShortDateString()).Append(" ").Append(ekk.Ekg).Append('\n');
            }
            values.Add("{on_ekg}", ekg.Count > 0 ? "ЭКГ:" : "");
            values.Add("{ekg}", ekgBld.ToString() + (ekg.Count > 0 ? "\n" : ""));
        }

        private void putUziData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtUzi> uzies = service.GetDdtUziService().GetListByParentId(objId);
            StringBuilder uziBld = new StringBuilder();
            foreach (DdtUzi uzObj in uzies)
            {
                uziBld.Append(uzObj.AnalysisDate.ToShortDateString()).Append(" ");
                if (!string.IsNullOrEmpty(uzObj.Cds))
                {
                    uziBld.Append("ЧДС ").Append(uzObj.Cds).Append('\n');
                }
                if (!string.IsNullOrEmpty(uzObj.EhoKg))
                {
                    uziBld.Append("ЭХО КГ ").Append(uzObj.EhoKg).Append('\n');
                }
                if (!string.IsNullOrEmpty(uzObj.PleursUzi))
                {
                    uziBld.Append("УЗИ плевр ").Append(uzObj.PleursUzi).Append('\n');
                }
                if (!string.IsNullOrEmpty(uzObj.UzdBca))
                {
                    uziBld.Append("УЗи БЦА ").Append(uzObj.UzdBca).Append('\n');
                }
                if (!string.IsNullOrEmpty(uzObj.UziObp))
                {
                    uziBld.Append("УЗИ ОБП ").Append(uzObj.UziObp).Append('\n');
                }
            }
            values.Add("{on_uzi}", uzies.Count > 0 ? "На УЗИ:" : "");
            values.Add("{uzi}", uziBld.ToString() + (uzies.Count > 0 ? "\n" : ""));
        }

        private void putBloodData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtBloodAnalysis> bloods = service.GetDdtBloodAnalysisService().GetListByParenId(objId);
            StringBuilder bloodBld = new StringBuilder();
            foreach (DdtBloodAnalysis drop in bloods)
            {
                bloodBld.Append(drop.AnalysisDate.ToShortDateString()).Append(" ");
                bloodBld.Append("креатинин").Append(" ").Append(drop.Creatinine).Append(" ");
                bloodBld.Append("АЛТ").Append(" ").Append(drop.Alt).Append(" ");
                bloodBld.Append("АСТ").Append(" ").Append(drop.Ast).Append(" ");
                bloodBld.Append("КФК").Append(" ").Append(drop.Kfk).Append(" ");
                bloodBld.Append("КФК МВ").Append(" ").Append(drop.KfkMv).Append(" ");
                bloodBld.Append("гемоглобин").Append(" ").Append(drop.Protein).Append(" ");
                bloodBld.Append("лейкоциты").Append(" ").Append(drop.Leucocytes).Append(" ");
                bloodBld.Append('\n');
            }
            values.Add("{on_blood}", bloods.Count > 0 ? "В анализах крови:" : "");
            values.Add("{blood}", bloodBld.ToString() + (bloods.Count > 0 ? "\n" : ""));
        }

    }
}
