using Cardiology.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cardiology.Data.Model2;

namespace Cardiology.Commons
{
    class EpicrisisTemplateProcessor : ITemplateProcessor
    {
        private const string TEMPLATE_FILE_NAME = "epicrisis_template.doc";
        private const string TEMPLATE_FILE_NAME_DEATH = "death_epicrisis_template.doc";
        private const string TEMPLATE_FILE_NAME_TRANSFER = "transfer_epicrisis_template.doc";

        public bool accept(string templateType)
        {
            return DdtEpicrisis.NAME.Equals(templateType);
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
            DdtEpicrisis obj = service.queryObjectById<DdtEpicrisis>(objectId);
            values.Add("{diagnosis}", obj.Diagnosis);
            values.Add("{date}", obj.EpicrisisDate.ToShortDateString());

            DdtPatient patient = service.queryObjectById<DdtPatient>(obj.Pa);
            values.Add("{patient.initials}", patient == null ? "" : patient.DssInitials);
            values.Add("{patient.age}", patient == null ? "" : (DateTime.Now.Year - patient.DsdtBirthdate.Year) + "");

            DdtHospital hospital = service.queryObjectById<DdtHospital>(hospitalitySession);
            values.Add("{patient.admission_date}", hospital.DsdtAdmissionDate.ToShortDateString());

            DdtAnamnesis anamnesis = service.queryObjectByAttrCond<DdtAnamnesis>(DdtAnamnesis.NAME, "dsid_hospitality_session", hospital.ObjectId, true);
            values.Add("{complaints}", anamnesis == null ? " " : anamnesis.DssComplaints);
            values.Add("{anamnesis}", anamnesis == null ? " " : anamnesis.DssAnamnesisMorbi);

            StringBuilder inspectonBld = new StringBuilder();
            inspectonBld.Append(compileValue("St.Presens", anamnesis?.DssStPresens));
            inspectonBld.Append(compileValue("Органы дыхания", anamnesis?.DssRespiratorySystem));
            inspectonBld.Append(compileValue("Сердечно-сосудистая система", anamnesis?.DssCardioVascular));
            inspectonBld.Append(compileValue("Органы пищеварения", anamnesis?.DssDigestiveSystem));
            values.Add("{inspection}", anamnesis == null ? " " : inspectonBld.ToString());

            DdtSerology serology = service.queryObjectByAttrCond<DdtSerology>(DdtSerology.NAME, "dsid_hospitality_session", hospital.ObjectId, true);
            StringBuilder serologyBld = new StringBuilder();
            if (serology != null)
            {
                serologyBld.Append(compileValue("Группа крови", serology.BloodType));
                serologyBld.Append(compileValue("Резус-фактор", serology.RhesusFactor));
                serologyBld.Append(compileValue("RW", serology.Rw));
            }
            values.Add("{serology}", serology == null ? " " : serologyBld.ToString());

            DdtEkg ekg = service.queryObject<DdtEkg>(@"SELECT * FROM ddt_ekg where dsid_parent='" + obj.ObjectId + "'");
            values.Add("{analysis.ekg}", ekg == null ? " " : "ЭКГ:" + ekg.Ekg);
            DdtXRay xray = service.queryObject<DdtXRay>(@"SELECT * FROM ddt_xray where dsid_parent='" + obj.ObjectId + "'");
            values.Add("{analysis.xray}", xray == null ? " " : "Рентген:" + xray.ChestXray);
            DdtEgds egds = service.queryObject<DdtEgds>(@"SELECT * FROM ddt_egds where dsid_parent='" + obj.ObjectId + "'");
            values.Add("{analysis.egds}", egds == null ? " " : "ЭГДС:" + egds.Egds);
            DdtBloodAnalysis blood = service.queryObject<DdtBloodAnalysis>(@"SELECT * FROM ddt_blood_analysis where dsid_parent='" + obj.ObjectId + "'");
            StringBuilder bloodStr = new StringBuilder();
            if (blood != null)
            {
                bloodStr.Append(compileValue("АЛТ", blood.Alt));
                bloodStr.Append(compileValue("Креатинин", blood.Creatinine));
                bloodStr.Append(compileValue("АСТ", blood.Ast));
                bloodStr.Append(compileValue("Холестерин", blood.Cholesterol));
                bloodStr.Append(compileValue("Гемоглобин", blood.Hemoglobin));
                bloodStr.Append(compileValue("Лейкоциты", blood.Leucocytes));
                bloodStr.Append(compileValue("Амилаза", blood.Amylase));
                bloodStr.Append(compileValue("Бил. Общ.", blood.Bil));
                bloodStr.Append(compileValue("Хлор", blood.Chlorine));
                bloodStr.Append(compileValue("Железо", blood.DsdIron));
                bloodStr.Append(compileValue("КФК", blood.DsdKfk));
                bloodStr.Append(compileValue("КФК-МВ", blood.DsdKfkMv));
                bloodStr.Append(compileValue("Тромбоциты", blood.DsdPlatelets));
                bloodStr.Append(compileValue("Калий", blood.DsdPotassium));
                bloodStr.Append(compileValue("Белок", blood.DsdProtein));
                bloodStr.Append(compileValue("ЩФ", blood.DsdSchf));
                bloodStr.Append(compileValue("Натрий", blood.DsdSodium));
                bloodStr.Append(compileValue("СРБ", blood.DsdSrp));
            }
            if (serology != null)
            {
                bloodStr.Append(compileValue("KELL-ag", serology.DssKellAg));
                bloodStr.Append(compileValue("HBs ag", serology.DssHbsAg));
                bloodStr.Append(compileValue("Anti HCV крови", serology.DssAntiHcv));
                bloodStr.Append(compileValue("HIV", serology.DssHiv));
            }
                values.Add("{analysis.blood}", blood == null ? " " : "Анализы крови:" + bloodStr);
            values.Add("{analysis.urine}", " ");
            DdtUzi uzi = service.queryObject<DdtUzi>(@"SELECT * FROM ddt_uzi where dsid_parent='" + obj.ObjectId + "'");
            StringBuilder uziStr = new StringBuilder();
            if (uzi != null)
            {
                uziStr.Append(compileValue("ЦДС", uzi.Cds));
                uziStr.Append(compileValue(" ЭХО КГ", uzi.EhoKg));
                uziStr.Append(compileValue(" УЗИ Плевр", uzi.PleursUzi));
                uziStr.Append(compileValue(" УЗД БЦА", uzi.UzdBca));
                uziStr.Append(compileValue(" УЗи ОБП", uzi.UziObp));
            }
            values.Add("{analysis.uzi}", uzi == null ? " " : uziStr.ToString());

            if (obj.EpicrisisType == (int)DdtEpicrisisDsiType.TRANSFER)
            {
                DdtTransfer transfer = service.queryObject<DdtTransfer>(@"Select * from " + DdtTransfer.NAME +
                    " WHERE dsid_hospitality_session='" + hospitalitySession + "'");
                if (transfer != null)
                {
                    values.Add("{destination}", transfer.Destination);
                    values.Add("{contact}", transfer.Contacts);
                    values.Add("{transport_justification}", transfer.TransferJustification);
                    values.Add("{patient.release_date}", transfer.StartDate.ToShortDateString());
                }
            }
            else if (obj.EpicrisisType == (int)DdtEpicrisisDsiType.DEATH)
            {
                values.Add("{conclusion}", " ");
            }

            DdvDoctor doc = service.queryObjectById<DdvDoctor>(obj.Doctor);
            values.Add("{doctor.who.short}", doc.ShortName);

            return TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + getTemplateName(obj), values);
        }

        private string compileValue(string title, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return String.Intern(" " + title + ":" + value);
            }
            return "";
        }

        private string getTemplateName(DdtEpicrisis obj)
        {
            if (obj.EpicrisisType == (int)DdtEpicrisisDsiType.TRANSFER)
            {
                return TEMPLATE_FILE_NAME_TRANSFER;
            }
            else if (obj.EpicrisisType == (int)DdtEpicrisisDsiType.DEATH)
            {
                return TEMPLATE_FILE_NAME_DEATH;
            }
            else
            {
                return TEMPLATE_FILE_NAME;
            }
        }
    }
}
