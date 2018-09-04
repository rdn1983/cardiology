using Cardiology.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cardiology.Utils
{
    class EpicrisisTemplateProcessor : ITemplateProcessor
    {
        private const string TEMPLATE_FILE_NAME = "epicrisis_template.doc";

        public bool accept(string templateType)
        {
            return DdtEpicrisis.TABLE_NAME.Equals(templateType);
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
            DdtEpicrisis obj = service.queryObjectById<DdtEpicrisis>(DdtEpicrisis.TABLE_NAME, objectId);
            values.Add("{diagnosis}", obj.DssDiagnosis);
            values.Add("{date}", obj.DsdtEpicrisisDate.ToShortDateString());

            DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, obj.DsidPatient);
            values.Add("{patient.initials}", patient == null ? "" : patient.DssInitials);
            values.Add("{patient.age}", patient == null ? "" : (DateTime.Now.Year - patient.DsdtBirthdate.Year) + "");

            DdtHospital hospital = service.queryObjectById<DdtHospital>(DdtHospital.TABLENAME, hospitalitySession);
            values.Add("{patient.admission_date}", hospital.DsdtAdmissionDate.ToShortDateString());

            DdtAnamnesis anamnesis = service.queryObjectByAttrCond<DdtAnamnesis>(DdtAnamnesis.TABLE_NAME, "dsid_hospitality_session", hospital.ObjectId, true);
            values.Add("{complaints}", anamnesis == null ? "" : anamnesis.DssComplaints);
            values.Add("{anamnesis}", anamnesis == null ? "" : anamnesis.DssAnamnesisVitae);
            values.Add("{inspection}", anamnesis == null ? "" : anamnesis.DssAnamnesisMorbi);

            DdtSerology serology = service.queryObjectByAttrCond<DdtSerology>(DdtSerology.TABLE_NAME, "dsid_hospitality_session", hospital.ObjectId, true);
            values.Add("{serology}", serology == null ? "" : serology.DssBloodType);

            DdtEkg ekg = service.queryObject<DdtEkg>(@"SELECT * FROM ddt_ekg where dsid_parent='" + obj.RObjectId + "'");
            values.Add("{analysis.ekg}", ekg == null ? "" : "ЭКГ:" + ekg.DssEkg);
            DdtXRay xray = service.queryObject<DdtXRay>(@"SELECT * FROM ddt_xray where dsid_parent='" + obj.RObjectId + "'");
            values.Add("{analysis.xray}", xray == null ? "" : "Рентген:" + xray.DssChestXray);
            DdtEgds egds = service.queryObject<DdtEgds>(@"SELECT * FROM ddt_egds where dsid_parent='" + obj.RObjectId + "'");
            values.Add("{analysis.egds}", egds == null ? "" : "ЭГДС:" + egds.DssEgds);
            DdtBloodAnalysis blood = service.queryObject<DdtBloodAnalysis>(@"SELECT * FROM ddt_blood_analysis where dsid_parent='" + obj.RObjectId + "'");
            StringBuilder bloodStr = new StringBuilder();
            if (blood != null)
            {
                bloodStr.Append("АЛТ ").Append(blood.DsdAlt).Append("Креатинин ").Append(blood.DsdCreatinine);
                bloodStr.Append("АСТ ").Append(blood.DsdAst).Append("Холестерин ").Append(blood.DsdCholesterolr);
                bloodStr.Append("Гемоглобин ").Append(blood.DsdHemoglobin).Append("Лейкоциты ").Append(blood.DsdLeucocytes);

            }
            values.Add("{analysis.blood}", blood == null ? "" : "Анализы крови:" + bloodStr);
            values.Add("{analysis.urine}", "");
            DdtUzi uzi = service.queryObject<DdtUzi>(@"SELECT * FROM ddt_uzi where dsid_parent='" + obj.RObjectId + "'");
            StringBuilder uziStr = new StringBuilder();
            if (uzi != null)
            {
                uziStr.Append("ЦДС ").Append(uzi.DssCds).Append("ЭХО КГ ").Append(uzi.DssEhoKg).Append("УЗИ Плевр ");
                uziStr.Append(uzi.DssPleursUzi).Append("УЗД БЦА").Append(uzi.DssUzdBca).Append("УЗи ОБП").Append(uzi.DssUziObp);
            }
            values.Add("{analysis.uzi}", uzi == null ? "" : uziStr.ToString());


            DdtDoctors doc = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, obj.DsidDoctor);
            values.Add("{doctor.who.short}", doc.DssInitials);

            return TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, values);
        }
    }
}
