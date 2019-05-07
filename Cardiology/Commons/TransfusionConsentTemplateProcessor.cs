using Cardiology.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cardiology.Data.Model2;

namespace Cardiology.Commons
{
    class TransfusionConsentTemplateProcessor : ITemplateProcessor
    {
        private const string TemplateFileName = "transfusion_consent.doc";
        public bool accept(string templateType)
        {
            return "transfusion_consent".Equals(templateType, StringComparison.Ordinal);
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

            values.Add(@"{date}", DateTime.Now.ToString("dd.MM.yyyy"));
            DdvPatient patient = service.GetDdvPatientService().GetById(objectId);
            values.Add(@"{patient}", patient.FullName);
            return TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TemplateFileName, values);
        }

        private string GetDoctorInString(IDbDataService service, String doctorId)
        {
            DdvDoctor doc = service.GetDdvDoctorService().GetById(doctorId);
            return doc.ShortName;
        }
    }
}
