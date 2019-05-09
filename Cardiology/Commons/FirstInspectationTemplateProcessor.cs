using Cardiology.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cardiology.Data.Model2;

namespace Cardiology.Commons
{
    class FirstInspectationTemplateProcessor : ITemplateProcessor
    {
        private const string TEMPLATE_FILE_NAME = "first_inspectation.doc";

        public bool accept(string templateType)
        {
            return "ddt_anamnesis".Equals(templateType, StringComparison.Ordinal);
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
            DdtAnamnesis anamnesis = service.GetDdtAnamnesisService().GetById(objectId);
            values.Add("{allergy}", anamnesis.AnamnesisAllergy);
            values.Add("{complaints}", anamnesis.Complaints);
            values.Add("{anamnesis}", anamnesis.AnamnesisMorbi);
            values.Add("{chronicle}", anamnesis.AccompanyingIllnesses);
            values.Add("{epid}", anamnesis.AnamnesisEpid);
            values.Add("{alco}", anamnesis.DrugsIntoxication);
            values.Add("{st_presens}", anamnesis.StPresens);
            values.Add("{respiratory_system}", anamnesis.RespiratorySystem);
            values.Add("{cardiovascular}", anamnesis.CardiovascularSystem);
            values.Add("{digestive_system}", anamnesis.DigestiveSystem);
            values.Add("{urinary_system}", anamnesis.UrinarySystem);
            values.Add("{nervous_system}", anamnesis.NervousSystem);
            values.Add("{past_surgeries}", anamnesis.PastSurgeries);
            values.Add("{operation_cause}", anamnesis.OperationCause);
            values.Add("{diagnosis}", anamnesis.Diagnosis);
            values.Add("{justification}", anamnesis.DiagnosisJustification);

            DdvDoctor doc = service.GetDdvDoctorService().GetById(anamnesis.Doctor);
            values.Add("{cardio}", doc.ShortName);

            DdtEkg ekg = service.GetDdtEkgService().GetByParentId(anamnesis?.ObjectId);

            values.Add("{analysis.ekg}", ekg == null ? "" : ekg.Ekg);

            StringBuilder builder = new StringBuilder();

            DdtIssuedMedicineList medList = service.GetDdtIssuedMedicineListService().GetListByParentId(anamnesis?.ObjectId);

            if (medList != null)
            {
                IList<DdtIssuedMedicine> med = service.GetDdtIssuedMedicineService().GetListByMedicineListId(medList.ObjectId);
                for (int i = 0; i < med.Count; i++)
                {
                    DdtCure cure = service.GetDdtCureService().GetById(med[i].Cure);
                    if (cure != null)
                    {
                        builder.Append(cure.Name).Append('\n');
                    }

                }
            }
            values.Add("{issued_medicine}", builder.ToString());

            StringBuilder actionsBuilder = new StringBuilder();
            IList<DdtIssuedAction> actions = service.GetDdtIssuedActionService().GetListByParentId(objectId);
            for (int i = 0; i < actions.Count; i++)
            {
                actionsBuilder.Append(i + 1).Append(". ");
                actionsBuilder.Append(actions[i].Action).Append('\n');
            }
            values.Add("{issued_actions}", actionsBuilder.ToString());

            DdtHospital hospital = service.GetDdtHospitalService().GetById(hospitalitySession);
            values.Add("{date}", hospital.AdmissionDate.ToShortDateString() + " " + hospital.AdmissionDate.ToShortTimeString());

            DdvPatient patient = service.GetDdvPatientService().GetById(hospital.Patient);
            string resultName = TemplatesUtils.getTempFileName("Первичный осмотр", patient.FullName);
            return TemplatesUtils.FillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, values, resultName);
        }
    }
}
