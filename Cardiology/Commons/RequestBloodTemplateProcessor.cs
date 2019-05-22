using Cardiology.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cardiology.Data.Model2;

namespace Cardiology.Commons
{
    class RequestBloodTemplateProcessor : ITemplateProcessor
    {
        private const string TemplateFileName = "request_blood.doc";
        public bool accept(string templateType)
        {
            return "request_blood".Equals(templateType, StringComparison.Ordinal);
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
            DdtTransfusion transfusion = service.GetDdtTransfusionService().GetById(objectId);
            DdtHospital hospital = service.GetDdtHospitalService().GetById(hospitalitySession);
            DdvPatient patient = service.GetDdvPatientService().GetById(hospital.Patient);
            DdtBloodAnalysis bloodAnalysis = service.GetDdtBloodAnalysisService().GetById(transfusion.BloodAnalysis);

            values.Add(@"{name}", patient.FullName);
            values.Add(@"{age}", (DateTime.Now.Year - patient.Birthdate.Year) + "");
            values.Add(@"{historycard}", patient.MedCode);
            values.Add(@"{diagnosis}", hospital.Diagnosis);
            values.Add(@"{blood}", patient.BloodGroup);
            values.Add(@"{rh}", patient.RHFactor);
            values.Add(@"{kell}", patient.Kell);
            values.Add(@"{phenotype}", patient.Phenotype);

            values.Add(@"{indications}", "гемическая гипоксия");
            values.Add(@"{meduim}", transfusion?.TransfusionMedium);
            values.Add(@"{doctor}", GetDoctorInString(service, transfusion?.Doctor));
            values.Add(@"{transfusionDate}", transfusion?.TransfusionDate.ToShortDateString());

            string mediumNames = "";
            string mediumCounts = "";

            String[] transfusionMediumArray = transfusion.TransfusionMedium.Split(',');
            foreach (String mediumWithCount in transfusionMediumArray)
            {
                String[] mediumArray = mediumWithCount.Split(':');

                string mediumName = mediumArray[0];
                string mediumCount = mediumArray[1];

                switch (mediumName)
                {
                    case "Blood":
                        mediumName = "Кровь";
                        break;
                    case "Plasma":
                        mediumName = "Плазма";
                        break;
                    case "Albumin":
                        continue;
                    case "Platelet":
                        mediumName = "Тромбоцит";
                        break;
                }
                
                mediumNames += string.IsNullOrEmpty(mediumNames) ? mediumName : ", " + mediumName;
                mediumCounts += string.IsNullOrEmpty(mediumCounts) ? mediumCount + " дозы" : ", " + mediumCount + " дозы";
            }
            values.Add(@"{mediumNames}", mediumNames);
            values.Add(@"{mediumCounts}", mediumCounts);

            values.Add(@"{Hemog}", bloodAnalysis.Hemoglobin);
            values.Add(@"{Hemat}", "пусто");
            values.Add(@"{aptt}", "пусто");
            values.Add(@"{inr}", "пусто");

            return TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TemplateFileName, values);
        }

        private string GetDoctorInString(IDbDataService service, String doctorId)
        {
            DdvDoctor doc = service.GetDdvDoctorService().GetById(doctorId);
            return doc?.ShortName;
        }
    }
}
