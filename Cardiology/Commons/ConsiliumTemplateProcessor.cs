using Cardiology.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cardiology.Data.Model2;

namespace Cardiology.Commons
{
    class ConsiliumTemplateProcessor : AbstractTemplateProcessor, ITemplateProcessor
    {
        private const string TemplateFileName = "consilium_template.doc";
        public bool accept(string templateType)
        {
            return DdtConsilium.NAME.Equals(templateType, StringComparison.Ordinal);
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

            PutAnalysisData(values, service, obj.ObjectId);

            return TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TemplateFileName, values, TemplatesUtils.getTempFileName("Консилиум", patient.FullName));
        }

        private string GetDoctorInString(IDbDataService service, String doctorId)
        {
            DdvDoctor doc = service.GetDdvDoctorService().GetById(doctorId);
            return doc.ShortName;
        }

        private string GetMembersInString(IDbDataService service, string consiliumId)
        {
            IList<DdtConsiliumRelation> consiluimRelations = service.GetDdtConsiliumRelationService().GetConsiliumRelationsByConsiliumId(consiliumId);

            Dictionary<int, String> memberToOrder = new Dictionary<int, String>();
            SortedDictionary<String, String> sortedMembers = new SortedDictionary<String, String>();

            foreach (DdtConsiliumRelation relation in consiluimRelations)
            {
                DdtConsiliumGroupMember groupMember = service.GetDdtConsiliumGroupMemberService().GetById(relation.Member);
                DdtConsiliumGroup group = service.GetDdtConsiliumGroupService().GetById(groupMember.Group);
                DdvDoctor doctor = service.GetDdvDoctorService().GetById(groupMember.Doctor);

                if (!sortedMembers.ContainsKey(group.Level + " " + group.Name + " " + doctor.ShortName)) {
                    sortedMembers.Add(group.Level + " " + group.Name + " " + doctor.ShortName, group.Name + " " + groupMember.Name + " " + doctor.ShortName);
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

        
    }
}
