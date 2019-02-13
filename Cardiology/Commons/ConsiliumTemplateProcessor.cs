using Cardiology.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cardiology.Data.Model2;

namespace Cardiology.Commons
{
    class ConsiliumTemplateProcessor : ITemplateProcessor
    {
        private const string TemplateFileName = "consilium_template.doc";
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
            DdtConsilium obj = service.queryObjectById<DdtConsilium>(objectId);
            values.Add(@"{consilium.date}", DateTime.Now.ToString("dd.MM.yyyy"));
            values.Add(@"{consilium.time}", DateTime.Now.ToString("HH:mm"));
            values.Add(@"{consilium.members}", getMembersInString(service, objectId));
            values.Add(@"{admin}", obj?.DssDutyAdminName);
            values.Add(@"{doctor.who}", getDoctorInString(service, obj.DsidDoctor));
            values.Add(@"{consilium.goal}", obj.DssGoal);
            DdtPatient patient = service.queryObjectById<DdtPatient>(obj.DsidPatient);
            values.Add(@"{patient.initials}", patient.DssInitials);
            values.Add(@"{patient.age}", (DateTime.Now.Year - patient.DsdtBirthdate.Year) + "");
            values.Add(@"{patient.diagnosis}", obj.DssDiagnosis);
            values.Add(@"{consilium.decision}", obj.DssDecision);
            values.Add(@"{journal}", obj.DssDynamics);

            putEkgData(values, service, hospitalitySession);
            putBloodData(values, service, hospitalitySession);

            return TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TemplateFileName, values);
        }

        private string getDoctorInString(DataService service, String doctorId)
        {
            DdtDoctors doc = service.queryObjectById<DdtDoctors>(doctorId);
            return doc.DssInitials;
        }

        private string getMembersInString(DataService service, string consiliumId)
        {
            List<DdtConsiliumMember> members = service.queryObjectsCollection<DdtConsiliumMember>(@"SELECT * FROM " + DdtConsiliumMember.TABLE_NAME +
                " WHERE dsid_consilium ='" + consiliumId + "'");

            Dictionary<int, String> memberToOrder = new Dictionary<int, String>();
            SortedDictionary<String, String> sortedMembers = new SortedDictionary<String, String>();

            foreach (DdtConsiliumMember mm in members)
            {
                DdtConsiliumMemberLevel groupLevel = service.queryObjectByAttrCond<DdtConsiliumMemberLevel>(DdtConsiliumMemberLevel.TABLE_NAME, "dss_group_name", mm.DssGroupName, true);
                DmGroup group = service.queryObjectByAttrCond<DmGroup>(DmGroup.TABLE_NAME, "dss_name", mm.DssGroupName, true);
                if (!sortedMembers.ContainsKey(groupLevel.DsiLevel + " " + group.DssDescription + " " + mm.DssDoctorName)) {
                    sortedMembers.Add(groupLevel.DsiLevel + " " + group.DssDescription + " " + mm.DssDoctorName, group.DssDescription + " " + mm.DssDoctorName);
                }
            }

            StringBuilder str = new StringBuilder();
            foreach (KeyValuePair<String, String> kvp in sortedMembers) {
                if (str.Length > 0)
                {
                    str.Append('\n');
                }
                str.Append(kvp.Value);
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

                if (String.IsNullOrEmpty(bloods.DsdCreatinine + bloods.DsdAlt + bloods.DsdAst + bloods.DsdKfk + bloods.DsdKfkMv + bloods.DsdProtein + bloods.DsdLeucocytes))
                {
                    bloodBld.Append("Анализы в работе");
                }
                else
                {
                    if (!String.IsNullOrEmpty(bloods.DsdCreatinine))
                        bloodBld.Append("креатинин").Append(" ").Append(bloods.DsdCreatinine).Append(" ");
                    if (!String.IsNullOrEmpty(bloods.DsdAlt))
                        bloodBld.Append("АЛТ").Append(" ").Append(bloods.DsdAlt).Append(" ");
                    if (!String.IsNullOrEmpty(bloods.DsdAst))
                        bloodBld.Append("АСТ").Append(" ").Append(bloods.DsdAst).Append(" ");
                    if (!String.IsNullOrEmpty(bloods.DsdKfk))
                        bloodBld.Append("КФК").Append(" ").Append(bloods.DsdKfk).Append(" ");
                    if (!String.IsNullOrEmpty(bloods.DsdKfkMv))
                        bloodBld.Append("КФК МВ").Append(" ").Append(bloods.DsdKfkMv).Append(" ");
                    if (!String.IsNullOrEmpty(bloods.DsdProtein))
                        bloodBld.Append("гемоглобин").Append(" ").Append(bloods.DsdProtein).Append(" ");
                    if (!String.IsNullOrEmpty(bloods.DsdLeucocytes))
                        bloodBld.Append("лейкоциты").Append(" ").Append(bloods.DsdLeucocytes).Append(" ");
                }
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
