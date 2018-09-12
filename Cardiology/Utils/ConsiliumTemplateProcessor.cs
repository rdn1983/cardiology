using Cardiology.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cardiology.Utils
{
    class ConsiliumTemplateProcessor : ITemplateProcessor
    {
        private const string TEMPLATE_FILE_NAME = "consilium_template.doc";
        public bool accept(string templateType)
        {
            return DdtConsilium.TABLE_NAME.Equals(templateType);
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
            DdtConsilium obj = service.queryObjectById<DdtConsilium>(DdtConsilium.TABLE_NAME, objectId);
            values.Add(@"{consilium.date}", DateTime.Now.ToString("dd.MM.yyyy"));
            values.Add(@"{consilium.time}", DateTime.Now.ToString("HH:mm"));
            values.Add(@"{consilium.members}", getMembersInString(service, objectId));
            values.Add(@"{consilium.goal}", obj.DssGoal);
            DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, obj.DsidPatient);
            values.Add(@"{patient.initials}", patient.DssInitials);
            values.Add(@"{patient.age}", (DateTime.Now.Year - patient.DsdtBirthdate.Year) + "");
            values.Add(@"{patient.diagnosis}", obj.DssDiagnosis);
            values.Add(@"{consilium.decision}", obj.DssDecision);
            values.Add(@"{journal}", obj.DssDynamics);

            putEkgData(values, service, hospitalitySession);
            putBloodData(values, service, hospitalitySession);

            DdtDoctors doc = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, obj.DsidDoctor);
            values.Add(@"{doctor.who}", doc.DssInitials);

            return TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, values);
        }

        private string getMembersInString(DataService service, string consiliumId)
        {
            List<DdtConsiliumMember> members = service.queryObjectsCollection<DdtConsiliumMember>(@"SELECT * FROM " + DdtConsiliumMember.TABLE_NAME +
                " WHERE dsid_consilium ='" + consiliumId + "'");
            StringBuilder str = new StringBuilder();
            foreach (DdtConsiliumMember mm in members)
            {
                DmGroup group = service.queryObjectByAttrCond<DmGroup>(DmGroup.TABLE_NAME, "dss_name", mm.DssGroupName, true);
                str.Append(group.DssDescription).Append(" ");
                str.Append(mm.DssDoctorName).Append('\n');
            }
            return str.ToString();
        }

        private void putBloodData(Dictionary<string, string> values, DataService service, string objId)
        {
            DdtBloodAnalysis bloods = service.queryObject<DdtBloodAnalysis>(@"SELECT * FROM " + DdtBloodAnalysis.TABLE_NAME +
                 " WHERE dsid_hospitality_session='" + objId + "' order by r_creation_date desc");
            StringBuilder bloodBld = new StringBuilder();
            if (bloods != null)
            {
                bloodBld.Append(bloods.DsdtAnalysisDate.ToShortDateString()).Append(" ");
                bloodBld.Append("креатинин").Append(" ").Append(bloods.DsdCreatinine).Append(" ");
                bloodBld.Append("АЛТ").Append(" ").Append(bloods.DsdAlt).Append(" ");
                bloodBld.Append("АСТ").Append(" ").Append(bloods.DsdAst).Append(" ");
                bloodBld.Append("КФК").Append(" ").Append(bloods.DsdKfk).Append(" ");
                bloodBld.Append("КФК МВ").Append(" ").Append(bloods.DsdKfkMv).Append(" ");
                bloodBld.Append("гемоглобин").Append(" ").Append(bloods.DsdProtein).Append(" ");
                bloodBld.Append("лейкоциты").Append(" ").Append(bloods.DsdLeucocytes).Append(" ");
            }
            values.Add("{analysis.blood}", bloodBld.ToString());
        }

        private void putEkgData(Dictionary<string, string> values, DataService service, string objId)
        {
            DdtEkg ekg = service.queryObject<DdtEkg>(@"Select * from " + DdtEkg.TABLE_NAME +
                " WHERE dsid_hospitality_session='" + objId + "' order by r_creation_date desc");
            StringBuilder ekgBld = new StringBuilder();
            if (ekg != null)
            {
                ekgBld.Append(ekg.DsdtAnalysisDate.ToShortDateString()).Append(" ").Append(ekg.DssEkg);
            }
            values.Add("{analysis.ekg}", ekgBld.ToString());
        }
    }
}
