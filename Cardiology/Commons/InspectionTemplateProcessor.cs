using Cardiology.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cardiology.Data.Model2;

namespace Cardiology.Commons
{
    class InspectionTemplateProcessor : AbstractTemplateProcessor, ITemplateProcessor
    {
        private const string TEMPLATE_FILE_NAME = "inspectation_template.doc";


        public bool accept(string templateType)
        {
            return DdtInspection.NAME.Equals(templateType, StringComparison.Ordinal);
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
            DdtInspection obj = service.GetDdtInspectionService().GetById(objectId);
            values.Add("{date}", obj.InspectionDate.ToShortDateString());
            values.Add("{time}", obj.InspectionDate.ToShortTimeString());
            values.Add("{patient.diagnosis}", obj.Diagnosis);
            values.Add("{complaints}", obj.Complaints);
            values.Add("{inspection}", obj.Inspection);
            values.Add("{kateter}", obj.KateterPlacement);
            values.Add("{result}", obj.InspectionResult);

            DdvPatient patient = service.GetDdvPatientService().GetById(obj.Patient);
            values.Add("{patient.initials}", patient == null ? "" : patient.ShortName);
            values.Add("{patient.age}", patient == null ? "" : (DateTime.Now.Year - patient.Birthdate.Year) + "");

            DdvDoctor doc = service.GetDdvDoctorService().GetById(obj.Doctor);
            values.Add("{doctor.who.short}", doc == null ? "" : doc.ShortName);

            PutAnalysisData(values, service, obj.ObjectId);

            string resultFileName = TemplatesUtils.getTempFileName("Ежедневный осмотр", patient.FullName);
            return TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, values, resultFileName);
        }

    }
}
