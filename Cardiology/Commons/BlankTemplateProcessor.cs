using Cardiology.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Cardiology.Commons
{
    class BlankTemplateProcessor : ITemplateProcessor
    {
        public bool accept(string templateType)
        {
            return "blank".Equals(templateType);
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
            DdtHospital hospitalSession = service.queryObjectById<DdtHospital>(DdtHospital.TABLENAME, hospitalitySession);
            DdtDoctors doc = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, hospitalSession.DsidCuringDoctor);
            DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, hospitalSession.DsidPatient);
            values.Add(@"{doctor.who.short}", doc.DssInitials);
            values.Add(@"{patient.initials}", patient.DssInitials);
            values.Add(@"{patient.birthdate}", patient.DsdtBirthdate.ToShortDateString());
            values.Add(@"{patient.diagnosis}", hospitalSession.DssDiagnosis);
            values.Add(@"{patient.age}", DateTime.Now.Year - patient.DsdtBirthdate.Year + "");
            values.Add(@"{admission.date}", hospitalSession.DsdtAdmissionDate.ToShortDateString());
            values.Add(@"{patient.historycard}", patient.DssMedCode);
            values.Add(@"{doctor.who}", doc.DssFullName);
            values.Add(@"{patient.fullname}", patient.DssFullName);
            values.Add(@"{date}", DateTime.Now.ToShortDateString());
            string templateFileName = "";
            return TemplatesUtils.fillTemplateAndShow(Directory.GetCurrentDirectory() + "\\Templates\\" + templateFileName, values);
        }
    }
}
