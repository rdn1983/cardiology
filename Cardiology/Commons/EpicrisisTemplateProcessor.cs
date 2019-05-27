using Cardiology.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cardiology.Data.Model2;
using Cardiology.Data.PostgreSQL;

namespace Cardiology.Commons
{
    class EpicrisisTemplateProcessor : AbstractTemplateProcessor, ITemplateProcessor
    {
        private const string TEMPLATE_FILE_NAME = "epicrisis_template.doc";
        private const string TEMPLATE_FILE_NAME_DEATH = "death_epicrisis_template.doc";
        private const string TEMPLATE_FILE_NAME_TRANSFER = "transfer_epicrisis_template.doc";

        public bool accept(string templateType)
        {
            return DdtEpicrisis.NAME.Equals(templateType, StringComparison.Ordinal);
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

            DdtAnamnesis anamnesis = service.GetDdtAnamnesisService().GetByHospitalSessionId(hospital.ObjectId);
            values.Add("{complaints}", anamnesis == null ? " " : anamnesis.Complaints);
            values.Add("{anamnesis}", anamnesis == null ? " " : anamnesis.AnamnesisMorbi);

            StringBuilder inspectonBld = new StringBuilder();
            inspectonBld.Append(CompileValue("St.Presens", anamnesis?.StPresens));
            inspectonBld.Append(CompileValue("Органы дыхания", anamnesis?.RespiratorySystem));
            inspectonBld.Append(CompileValue("Сердечно-сосудистая система", anamnesis?.CardiovascularSystem));
            inspectonBld.Append(CompileValue("Органы пищеварения", anamnesis?.DigestiveSystem));
            values.Add("{inspection}", anamnesis == null ? " " : inspectonBld.ToString());

            DdtSerology serology = service.GetDdtSerologyService().GetByHospitalSession(hospital.ObjectId);
            StringBuilder serologyBld = new StringBuilder();
            if (serology != null)
            {
                serologyBld.Append(CompileValue("Группа крови", serology.BloodType));
                serologyBld.Append(CompileValue("Резус-фактор", serology.RhesusFactor));
                serologyBld.Append(CompileValue("RW", serology.Rw));
            }
            values.Add("{serology}", serology == null ? " " : serologyBld.ToString());
            PutAnalysisData(values, service, obj.ObjectId);
            StringBuilder bloodStr = new StringBuilder();
            if (serology != null)
            {
                bloodStr.Append(CompileValue("KELL-ag", serology.KellAg));
                bloodStr.Append(CompileValue("HBs ag", serology.HbsAg));
                bloodStr.Append(CompileValue("Anti HCV крови", serology.AntiHcv));
                bloodStr.Append(CompileValue("HIV", serology.Hiv));
            }
            if (obj.EpicrisisType == (int)DdtEpicrisisDsiType.TRANSFER)
            {
                DdtTransfer transfer = service.GetDdtTransferService().GetByHospitalSession(hospitalitySession);
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
            DdvDoctor surgery = service.GetDdvDoctorService().GetById(hospital.DutyDoctor);
            values.Add("{surgery}",surgery?.ShortName+ "\n");
            DdvDoctor anest = service.GetDdvDoctorService().GetById(hospital.AnesthetistDoctor);
            values.Add("{anestesiolog}",anest?.ShortName);

            string resultFileName = TemplatesUtils.getTempFileName("Эпикриз", patient.FullName);
            return TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + getTemplateName(obj), values, resultFileName);
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
