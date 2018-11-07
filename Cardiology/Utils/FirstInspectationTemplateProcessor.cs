using Cardiology.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cardiology.Utils
{
    class FirstInspectationTemplateProcessor : ITemplateProcessor
    {
        private const string TEMPLATE_FILE_NAME = "first_inspectation.doc";

        public bool accept(string templateType)
        {
            return "ddt_anamnesis".Equals(templateType);
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
            DdtAnamnesis anamnesis = service.queryObjectById<DdtAnamnesis>(DdtAnamnesis.TABLE_NAME, objectId);
            values.Add("{allergy}", anamnesis.DssAnamnesisAllergy);
            values.Add("{complaints}", anamnesis.DssComplaints);
            values.Add("{anamnesis}", anamnesis.DssAnamnesisMorbi);
            values.Add("{chronicle}", anamnesis.DssAccompayingIll);
            values.Add("{epid}", anamnesis.DssAnamnesisEpid);
            values.Add("{alco}", anamnesis.DssDrugs);
            values.Add("{st_presens}", anamnesis.DssStPresens);
            values.Add("{respiratory_system}", anamnesis.DssRespiratorySystem);
            values.Add("{cardiovascular}", anamnesis.DssCardioVascular);
            values.Add("{digestive_system}", anamnesis.DssDigestiveSystem);
            values.Add("{urinary_system}", anamnesis.DssUrinarySystem);
            values.Add("{nervous_system}", anamnesis.DssNervousSystem);
            values.Add("{past_surgeries}", anamnesis.DssPastSurgeries);
            values.Add("{operation_cause}", anamnesis.DssOperationCause);
            values.Add("{diagnosis}", anamnesis.DssDiagnosis);

            DdtDoctors doc = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, anamnesis.DsidDoctor);
            values.Add("{cardio}", doc.DssInitials);

            DdtEkg ekg = service.queryObject<DdtEkg>(@"SELECT * from ddt_ekg WHERE dsid_hospitality_session='' and dsb_admission_analysis=true");
            values.Add("{analysis.ekg}", ekg == null ? "" : ekg.DssEkg);

            StringBuilder builder = new StringBuilder();

            DdtIssuedMedicineList medList = service.queryObject<DdtIssuedMedicineList>(@"SELECT * FROM ddt_issued_medicine_list WHERE dsid_hospitality_session='" +
                hospitalitySession + "' AND dss_parent_type='ddt_anamnesis'");
            if (medList != null)
            {
                List<DdtIssuedMedicine> med = service.queryObjectsCollectionByAttrCond<DdtIssuedMedicine>(DdtIssuedMedicine.TABLE_NAME, "dsid_med_list", medList.ObjectId, true);
                for (int i = 0; i < med.Count; i++)
                {
                    DdtCure cure = service.queryObjectById<DdtCure>(DdtCure.TABLE_NAME, med[i].DsidCure);
                    if (cure != null)
                    {
                        builder.Append(cure.DssName).Append('\n');
                    }

                }
            }
            values.Add("{issued_medicine}", builder.ToString());

            StringBuilder actionsBuilder = new StringBuilder();
            List<DdtIssuedAction> actions = service.queryObjectsCollectionByAttrCond<DdtIssuedAction>(DdtIssuedAction.TABLE_NAME, "dsid_parent_id", objectId, true);
            for (int i = 0; i < actions.Count; i++)
            {
                actionsBuilder.Append(i + 1).Append(". ");
                actionsBuilder.Append(actions[i].DssAction).Append('\n');
            }
            values.Add("{issued_actions}", actionsBuilder.ToString());

            values.Add("{date}", DateTime.Now.ToShortDateString());

            return TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + TEMPLATE_FILE_NAME, values);
        }
    }
}
