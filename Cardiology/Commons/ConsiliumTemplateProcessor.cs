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
            return DdtConsilium.NAME.Equals(templateType);
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

            DdtConsilium obj = service.GetDdtConsiliumService().GetById(objectId);
            values.Add(@"{consilium.date}", DateTime.Now.ToString("dd.MM.yyyy"));
            values.Add(@"{consilium.time}", DateTime.Now.ToString("HH:mm"));
            values.Add(@"{consilium.members}", GetMembersInString(service, objectId));
            values.Add(@"{admin}", obj?.DutyAdminName);
            values.Add(@"{doctor.who}", GetDoctorInString(service, obj.Doctor));
            values.Add(@"{consilium.goal}", obj.Goal);

            DdvPatient patient = service.GetDdvPatientService().GetById(obj.Patient);
            values.Add(@"{patient.initials}", patient.ShortName);
            values.Add(@"{patient.age}", (DateTime.Now.Year - patient.Birthdate.Year) + "");
            values.Add(@"{patient.diagnosis}", obj.Diagnosis);
            values.Add(@"{consilium.decision}", obj.Decision);
            values.Add(@"{journal}", obj.Dynamics);

            PutEkgData(values, service, hospitalitySession);
            PutBloodData(values, service, hospitalitySession);

            return TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TemplateFileName, values);
        }

        private string GetDoctorInString(IDbDataService service, String doctorId)
        {
            DdvDoctor doc = service.GetDdvDoctorService().GetById(doctorId);
            return doc.ShortName;
        }

        private string GetMembersInString(IDbDataService service, string consiliumId)
        {
            IList<DdtConsiliumMember> members = service.GetDdtConsiliumMemberService().GetMembersByConsiliumId(consiliumId);

            Dictionary<int, String> memberToOrder = new Dictionary<int, String>();
            SortedDictionary<String, String> sortedMembers = new SortedDictionary<String, String>();

            foreach (DdtConsiliumMember mm in members)
            {
                DdvDoctor doctor = service.GetDdvDoctorService().GetById(mm.ObjectId);
                DdtConsiliumGroupMember groupMember =
                    service.GetDdtConsiliumGroupMemberService().GetByDoctorId(mm.Doctor);
                DdtConsiliumGroup group = service.GetDdtConsiliumGroupService().GetById(groupMember.Group);

                if (!sortedMembers.ContainsKey(group.Level + " " + group.Name + " " + doctor.ShortName)) {
                    sortedMembers.Add(group.Level + " " + group.Name + " " + doctor.ShortName, group.Name + " " + doctor.ShortName);
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

        private void PutBloodData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            DdtBloodAnalysis bloods = service.GetDdtBloodAnalysisService().GetByHospitalSession(objId);
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

        private void PutEkgData(Dictionary<string, string> values, IDbDataService service, string objId)
        {
            DdtEkg ekg = service.GetDdtEkgService().GetByHospitalSession(objId);
            StringBuilder ekgBld = new StringBuilder();
            if (ekg != null)
            {
                ekgBld.Append(ekg.AnalysisDate.ToShortDateString()).Append(" ").Append(ekg.Ekg);
            }
            values.Add("{analysis.ekg}", ekgBld.ToString());
        }
    }
}
