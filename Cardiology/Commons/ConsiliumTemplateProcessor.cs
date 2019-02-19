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
            values.Add(@"{admin}", obj?.DutyAdminName);
            values.Add(@"{doctor.who}", getDoctorInString(service, obj.Doctor));
            values.Add(@"{consilium.goal}", obj.Goal);
            DdtPatient patient = service.queryObjectById<DdtPatient>(obj.Patient);
            values.Add(@"{patient.initials}", patient.);
            values.Add(@"{patient.age}", (DateTime.Now.Year - patient.Birthdate.Year) + "");
            values.Add(@"{patient.diagnosis}", obj.Diagnosis);
            values.Add(@"{consilium.decision}", obj.Decision);
            values.Add(@"{journal}", obj.Dynamics);

            putEkgData(values, service, hospitalitySession);
            putBloodData(values, service, hospitalitySession);

            return TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TemplateFileName, values);
        }

        private string getDoctorInString(DataService service, String doctorId)
        {
            DdvDoctor doc = service.queryObjectById<DdvDoctor>(doctorId);
            return doc.ShortName;
        }

        private string getMembersInString(DataService service, string consiliumId)
        {
            List<DdtConsiliumMember> members = service.queryObjectsCollection<DdtConsiliumMember>(@"SELECT * FROM " + DdtConsiliumMember.TABLE_NAME +
                " WHERE dsid_consilium ='" + consiliumId + "'");

            Dictionary<int, String> memberToOrder = new Dictionary<int, String>();
            SortedDictionary<String, String> sortedMembers = new SortedDictionary<String, String>();

            foreach (DdtConsiliumMember mm in members)
            {
                DdtConsiliumGroupLevel

                DdtConsiliumGroupMem groupLevel = service.queryObjectByAttrCond<DdtConsiliumMemberLevel>(DdtConsiliumMemberLevel.TABLE_NAME, "dss_group_name", mm.DssGroupName, true);
                DmGroup group = service.queryObjectByAttrCond<DmGroup>(DmGroup.TABLE_NAME, "dss_name", mm.DssGroupName, true);
                if (!sortedMembers.ContainsKey(groupLevel.DsiLevel + " " + group.DssDescription + " " + mm.DssDoctorName)) {
                    sortedMembers.Add(groupLevel.DsiLevel + " " + group.DssDescription + " " + mm.DoctorName, group.Description + " " + mm.DoctorName);
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
                bloodBld.Append(bloods.AnalysisDate.ToShortDateString()).Append(" ");

                if (String.IsNullOrEmpty(bloods.Creatinine + bloods.Alt + bloods.Ast + bloods.Kfk + bloods.KfkMv + bloods.Protein + bloods.Leucocytes))
                {
                    bloodBld.Append("Анализы в работе");
                }
                else
                {
                    if (!String.IsNullOrEmpty(bloods.Creatinine))
                        bloodBld.Append("креатинин").Append(" ").Append(bloods.Creatinine).Append(" ");
                    if (!String.IsNullOrEmpty(bloods.Alt))
                        bloodBld.Append("АЛТ").Append(" ").Append(bloods.Alt).Append(" ");
                    if (!String.IsNullOrEmpty(bloods.Ast))
                        bloodBld.Append("АСТ").Append(" ").Append(bloods.Ast).Append(" ");
                    if (!String.IsNullOrEmpty(bloods.Kfk))
                        bloodBld.Append("КФК").Append(" ").Append(bloods.Kfk).Append(" ");
                    if (!String.IsNullOrEmpty(bloods.KfkMv))
                        bloodBld.Append("КФК МВ").Append(" ").Append(bloods.KfkMv).Append(" ");
                    if (!String.IsNullOrEmpty(bloods.Protein))
                        bloodBld.Append("гемоглобин").Append(" ").Append(bloods.Protein).Append(" ");
                    if (!String.IsNullOrEmpty(bloods.Leucocytes))
                        bloodBld.Append("лейкоциты").Append(" ").Append(bloods.Leucocytes).Append(" ");
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
                ekgBld.Append(ekg.AnalysisDate.ToShortDateString()).Append(" ").Append(ekg.Ekg);
            }
            values.Add("{analysis.ekg}", ekgBld.ToString());
        }
    }
}
