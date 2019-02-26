using Cardiology.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cardiology.Data.Model2;
using Cardiology.Data.PostgreSQL;

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
            DdtEpicrisis obj = service.GetDdtEpicrisisService().GetById(objectId);
            values.Add("{diagnosis}", obj.Diagnosis);
            values.Add("{date}", obj.EpicrisisDate.ToShortDateString());

            DdvPatient patient = service.GetDdvPatientService().GetById(obj.Patient);
            values.Add("{patient.initials}", patient == null ? "" : patient.ShortName);
            values.Add("{patient.age}", patient == null ? "" : (DateTime.Now.Year - patient.Birthdate.Year) + "");

            DdtHospital hospital = service.GetDdtHospitalService().GetById(hospitalitySession);
            values.Add("{patient.admission_date}", hospital.AdmissionDate.ToShortDateString());

            DdtAnamnesis anamnesis = service.queryObjectByAttrCond<DdtAnamnesis>(DdtAnamnesis.NAME, "dsid_hospitality_session", hospital.ObjectId, true);
            values.Add("{complaints}", anamnesis == null ? " " : anamnesis.Complaints);
            values.Add("{anamnesis}", anamnesis == null ? " " : anamnesis.AnamnesisMorbi);

            StringBuilder inspectonBld = new StringBuilder();
            inspectonBld.Append(CompileValue("St.Presens", anamnesis?.StPresens));
            inspectonBld.Append(CompileValue("Органы дыхания", anamnesis?.RespiratorySystem));
            inspectonBld.Append(CompileValue("Сердечно-сосудистая система", anamnesis?.CardiovascularSystem));
            inspectonBld.Append(CompileValue("Органы пищеварения", anamnesis?.DigestiveSystem));
            values.Add("{inspection}", anamnesis == null ? " " : inspectonBld.ToString());

            DdtSerology serology = service.queryObjectByAttrCond<DdtSerology>(DdtSerology.NAME, "dsid_hospitality_session", hospital.ObjectId, true);
            StringBuilder serologyBld = new StringBuilder();
            if (serology != null)
            {
                serologyBld.Append(CompileValue("Группа крови", serology.BloodType));
                serologyBld.Append(CompileValue("Резус-фактор", serology.RhesusFactor));
                serologyBld.Append(CompileValue("RW", serology.Rw));
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
            }
            if (serology != null)
            {
                bloodStr.Append(CompileValue("KELL-ag", serology.KellAg));
                bloodStr.Append(CompileValue("HBs ag", serology.HbsAg));
                bloodStr.Append(CompileValue("Anti HCV крови", serology.AntiHcv));
                bloodStr.Append(CompileValue("HIV", serology.Hiv));
            }
                values.Add("{analysis.blood}", blood == null ? " " : "Анализы крови:" + bloodStr);
            values.Add("{analysis.urine}", " ");
            DdtUzi uzi = service.queryObject<DdtUzi>(@"SELECT * FROM ddt_uzi where dsid_parent='" + obj.ObjectId + "'");
            StringBuilder uziStr = new StringBuilder();
            if (uzi != null)
            {
                uziStr.Append(CompileValue("ЦДС", uzi.Cds));
                uziStr.Append(CompileValue(" ЭХО КГ", uzi.EhoKg));
                uziStr.Append(CompileValue(" УЗИ Плевр", uzi.PleursUzi));
                uziStr.Append(CompileValue(" УЗД БЦА", uzi.UzdBca));
                uziStr.Append(CompileValue(" УЗи ОБП", uzi.UziObp));
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

            DdvDoctor doc = service.GetDdvDoctorService().GetById(obj.Doctor);
            values.Add("{doctor.who.short}", doc.ShortName);

            return TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + getTemplateName(obj), values);
        }

        private string CompileValue(string title, string value)
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
