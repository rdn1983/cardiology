using System.Windows.Forms;
using Cardiology.Model;

namespace Cardiology
{
    public partial class SpecialistConclusionControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;

        public SpecialistConclusionControl(string objectId, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtSpecialistConclusion specConclusion = service.queryObjectById<DdtSpecialistConclusion>(DdtSpecialistConclusion.TABLE_NAME, objectId);
            if (specConclusion != null)
            {
                neurologTxt.Text = specConclusion.DssNeurolog ;
                surgeonTxt.Text = specConclusion.DssSurgeon;
                neuroSurgeonTxt.Text = specConclusion.DssNeuroSurgeon;
                endocrinologistTx.Text = specConclusion.DssEndocrinologist;
                title.Text = "Анализы за " + specConclusion.RCreationDate.ToShortDateString();
            }
            neurologTxt.Enabled = isEditable;
            surgeonTxt.Enabled = isEditable;
            neuroSurgeonTxt.Enabled = isEditable;
            endocrinologistTx.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable)
            {
                DataService service = new DataService();
                DdtSpecialistConclusion specConslusion = service.queryObjectById<DdtSpecialistConclusion>(DdtSpecialistConclusion.TABLE_NAME, objectId);
                if (specConslusion == null)
                {
                    specConslusion = new DdtSpecialistConclusion();
                    specConslusion.DsidHospitalitySession = hospitalitySession.ObjectId;
                    specConslusion.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    specConslusion.DsidPatient = hospitalitySession.DsidPatient;
                }
                specConslusion.DssNeurolog = neurologTxt.Text;
                specConslusion.DssSurgeon = surgeonTxt.Text;
                specConslusion.DssNeuroSurgeon = neuroSurgeonTxt.Text;
                specConslusion.DssEndocrinologist = endocrinologistTx.Text;
                specConslusion.DssParentType = parentType;
                specConslusion.DsidParent = parentId;
                objectId = service.updateOrCreateIfNeedObject<DdtSpecialistConclusion>(specConslusion, DdtSpecialistConclusion.TABLE_NAME, specConslusion.ObjectId);
            }
        }

        public string getObjectId()
        {
            return objectId;
        }
    }
}
