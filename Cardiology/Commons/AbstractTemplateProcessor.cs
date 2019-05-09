using Cardiology.Data;
using Cardiology.Data.Model2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardiology.Commons
{
    class AbstractTemplateProcessor
    {
        private static List<string> analysisTypes = new List<string>() { };

        internal void getAnalysisData(Dictionary<string, string> values, IDbDataService service, string parentId)
        {
            PutBloodData(values, service, parentId);
            PutEkgData(values, service, parentId);
        }

        private void PutBloodData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtBloodAnalysis> bloods = service.GetDdtBloodAnalysisService().GetByParentId(objId);
            StringBuilder bloodStr = new StringBuilder();
            foreach (DdtBloodAnalysis blood in bloods)
            {
                bloodStr.Append("Анализы крови от ");
                bloodStr.Append(blood.AnalysisDate.ToShortDateString()).Append(": ");

                bloodStr.Append(CompileValue("АЛТ", blood.Alt));
                bloodStr.Append(CompileValue("Креатинин", blood.Creatinine));
                bloodStr.Append(CompileValue("АСТ", blood.Ast));
                bloodStr.Append(CompileValue("Холестерин", blood.Cholesterol));
                bloodStr.Append(CompileValue("Гемоглобин", blood.Hemoglobin));
                bloodStr.Append(CompileValue("Лейкоциты", blood.Leucocytes));
                bloodStr.Append(CompileValue("Амилаза", blood.Amylase));
                bloodStr.Append(CompileValue("Бил. Общ.", blood.Bil));
                bloodStr.Append(CompileValue("Хлор", blood.Chlorine));
                bloodStr.Append(CompileValue("Железо", blood.Iron));
                bloodStr.Append(CompileValue("КФК", blood.Kfk));
                bloodStr.Append(CompileValue("КФК-МВ", blood.KfkMv));
                bloodStr.Append(CompileValue("Тромбоциты", blood.Platelets));
                bloodStr.Append(CompileValue("Калий", blood.Potassium));
                bloodStr.Append(CompileValue("Белок", blood.Protein));
                bloodStr.Append(CompileValue("ЩФ", blood.Schf));
                bloodStr.Append(CompileValue("Натрий", blood.Sodium));
                bloodStr.Append(CompileValue("СРБ", blood.Srp));
                bloodStr.Append("\n");
            }

            values.Add("{analysis.blood}", bloodStr.ToString());
        }

        private void PutEkgData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtEkg> ekgs = service.GetDdtEkgService().GetByParentId(objId);
            StringBuilder ekgBld = new StringBuilder();
            foreach (DdtEkg ekg in ekgs)
            {
                if (ekg != null)
                {
                    ekgBld.Append(ekg.AnalysisDate.ToShortDateString()).Append(" ").Append(ekg.Ekg);
                }
            }
            values.Add("{analysis.ekg}", ekgBld.ToString());
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
                    specBld.Append("Эндокринолог от ").Append(obj.Endocrinologist).Append('\n');
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
                .GetByHospitalSessionAndJournalType(sessionId, (int)DdtJournalDsiType.AfterKag);
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

        internal string CompileValue(string title, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return String.Intern(" " + title + ":" + value);
            }
            return "";
        }
    }
}

