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

        internal void PutAnalysisData(Dictionary<string, string> values, IDbDataService service, string parentId)
        {
            PutBloodData(values, service, parentId);
            PutEkgData(values, service, parentId);
            PutSpecialistData(values, service, parentId);
            PutKagData(values, service, parentId);
            PutHolterData(values, service, parentId);
            PutUziData(values, service, parentId);
            PutCoagulogrammData(values, service, parentId);
            PutEgdsData(values, service, parentId);
            PutUrineData(values, service, parentId);
            PutXRayData(values, service, parentId);
        }

        private void PutBloodData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtBloodAnalysis> bloods = service.GetDdtBloodAnalysisService().GetByParentId(objId);
            StringBuilder bloodStr = new StringBuilder();
            foreach (DdtBloodAnalysis blood in bloods)
            {
                bloodStr.Append(" от ").Append(blood.AnalysisDate.ToShortDateString()).Append(": ");

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
                bloodStr.Append(".");
                bloodStr.Append("\n");
            }

            values.Add("{on_blood}", bloods.Count > 0 ? "Анализы крови " : "");
            values.Add("{blood}", bloodStr.ToString());
        }

        private void PutEkgData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtEkg> ekg = service.GetDdtEkgService().GetByParentId(objId);
            StringBuilder ekgBld = new StringBuilder();
            foreach (DdtEkg ekk in ekg)
            {
                ekgBld.Append(" от ").Append(ekk.AnalysisDate.ToShortDateString()).Append(": ").Append(ekk.Ekg).Append(".").Append('\n');
            }
            values.Add("{on_ekg}", ekg.Count > 0 ? "ЭКГ:" : "");
            values.Add("{ekg}", ekgBld.ToString() + (ekg.Count > 0 ? "\n" : ""));
        }

        private void PutSpecialistData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtSpecialistConclusion> lspecobj = service.GetDdtSpecialistConclusionService().GetByParentId(objId);
            StringBuilder specBld = new StringBuilder();
            foreach (DdtSpecialistConclusion obj in lspecobj)
            {
                specBld.Append(" от ").Append(obj.AnalysisDate.ToShortDateString()).Append(":");
                specBld.Append(CompileValue(" Эндокринолог ", obj.Endocrinologist)).Append('\n');
                specBld.Append(CompileValue(" Невролог ", obj.Neurolog)).Append('\n');
                specBld.Append(CompileValue(" Нейрохирург", obj.NeuroSurgeon)).Append('\n');
                specBld.Append(CompileValue(" Хирург ", obj.Surgeon)).Append('\n');
            }
            values.Add("{on_spec}", lspecobj.Count > 0 ? "Заключения специалистов:" : "");
            values.Add("{spec}", specBld.ToString() + (lspecobj.Count > 0 ? "\n" : ""));
        }

        private void PutKagData(Dictionary<string, string> values, IDbDataService service, string parentId)
        {
            StringBuilder bld = new StringBuilder();
            IList<DdtKag> kags = service.GetDdtKagService().GetByParentId(parentId);

            foreach (DdtKag kag in kags)
            {
                bld.Append("Коронарография от ")
                    .Append(kag.AnalysisDate.ToShortDateString())
                    .Append(":")
                    .Append(kag.KagAction);
                bld.Append("\n").Append(".");
            }
            values.Add("{kag}", bld.ToString());
        }

        private void PutHolterData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtHolter> lholterobj = service.GetDdtHolterService().GetByParentId(objId);
            StringBuilder holterBld = new StringBuilder();
            foreach (DdtHolter obj in lholterobj)
            {
                holterBld.Append(" от ").Append(obj.AnalysisDate.ToShortDateString()).Append(": ").Append(obj.Holter).Append(".").Append('\n');
            }
            values.Add("{on_holter}", lholterobj.Count > 0 ? "Холтер:" : "");
            values.Add("{holter}", holterBld.ToString());
        }

        private void PutUziData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtUzi> uzies = service.GetDdtUziService().GetByParentId(objId);
            StringBuilder uziBld = new StringBuilder();
            foreach (DdtUzi uzObj in uzies)
            {
                uziBld.Append(" от ").Append(uzObj.AnalysisDate.ToShortDateString()).Append(": ");
                uziBld.Append(CompileValue(" ЧДС ", uzObj.Cds));
                uziBld.Append(CompileValue("ЭХО КГ ", uzObj.EhoKg));
                uziBld.Append(CompileValue("УЗИ плевр ", uzObj.PleursUzi));
                uziBld.Append(CompileValue("УЗи БЦА ", uzObj.UzdBca));
                uziBld.Append(CompileValue("УЗИ ОБП ", uzObj.UziObp));
                uziBld.Append(".").Append("\n");
            }
            values.Add("{on_uzi}", uzies.Count > 0 ? "На УЗИ:" : "");
            values.Add("{uzi}", uziBld.ToString() + (uzies.Count > 0 ? "\n" : ""));
        }

        private void PutCoagulogrammData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtCoagulogram> coags = service.GetDdtCoagulogramService().getByParentId(objId);
            StringBuilder coagBld = new StringBuilder();
            foreach (DdtCoagulogram cc in coags)
            {
                coagBld.Append(" от ").Append(cc.AnalysisDate.ToShortDateString()).Append(": ");
                coagBld.Append(CompileValue(" АЧТВ ", cc.Achtv));
                coagBld.Append(CompileValue("Д-Димер ", cc.Ddimer));
                coagBld.Append(".");
            }
            values.Add("{on_coag}", coags.Count > 0 ? "На Коагулограмме:" : "");
            values.Add("{coag}", coagBld.ToString() + (coags.Count > 0 ? "\n" : ""));
        }

        private void PutEgdsData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtEgds> egdss = service.GetDdtEgdsService().GetByParentId(objId);
            StringBuilder egdsBld = new StringBuilder();
            foreach (DdtEgds egds in egdss)
            {
                egdsBld.Append(" от ").Append(egds.AnalysisDate.ToShortDateString()).Append(": ");
                egdsBld.Append(CompileValue("", egds.Egds));
                egdsBld.Append(".");
            }
            values.Add("{on_egds}", egdss.Count > 0 ? "На ЭГДС:" : "");
            values.Add("{egds}", egdsBld.ToString() + (egdss.Count > 0 ? "\n" : ""));
        }

        private void PutUrineData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtUrineAnalysis> urines = service.GetDdtUrineAnalysisService().GetByParentId(objId);
            StringBuilder uriBld = new StringBuilder();
            foreach (DdtUrineAnalysis uri in urines)
            {
                uriBld.Append(" от ").Append(uri.AnalysisDate.ToShortDateString()).Append(": ");
                uriBld.Append(CompileValue("Цвет ", uri.Color));
                uriBld.Append(CompileValue("Эритроциты ", uri.Erythrocytes));
                uriBld.Append(CompileValue("Лейкоциты ", uri.Leukocytes));
                uriBld.Append(CompileValue("Белок ", uri.Protein));
                uriBld.Append(".");
            }
            values.Add("{on_urine}", urines.Count > 0 ? "Анализы мочи:" : "");
            values.Add("{urine}", uriBld.ToString() + (urines.Count > 0 ? "\n" : ""));
        }

        private void PutXRayData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            IList<DdtXRay> xrays = service.GetDdtXrayService().GetByParentId(objId);
            StringBuilder xRayBld = new StringBuilder();
            foreach (DdtXRay xr in xrays)
            {
                xRayBld.Append(" от ").Append(xr.AnalysisDate.ToShortDateString()).Append(": ");
                xRayBld.Append(CompileValue("Рентген органов грудной клетки ", xr.ChestXray));
                xRayBld.Append(CompileValue("Контрольная рентгенография ОГК ", xr.ControlRadiography));
                xRayBld.Append(CompileValue("КТ ", xr.Kt));
                xRayBld.Append(CompileValue("МРТ ", xr.Mrt));
                xRayBld.Append(".");
            }
            values.Add("{on_xray}", xrays.Count > 0 ? "На рентгене:" : "");
            values.Add("{xray}", xRayBld.ToString() + (xrays.Count > 0 ? "\n" : ""));
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

