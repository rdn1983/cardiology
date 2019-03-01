using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class SpecialistConclusionControl : UserControl, IDocbaseControl
    {
        private readonly IDbDataService service;
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;

        public SpecialistConclusionControl(IDbDataService service, string objectId, bool additional)
        {
            this.service = service;
            this.objectId = objectId;
            this.isEditable = !additional;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        private void initControls()
        {

            DdtSpecialistConclusion specConclusion = service.GetDdtSpecialistConclusionService().GetById(objectId);
            refreshObject(specConclusion);
            neurologTxt.ReadOnly = !isEditable;
            surgeonTxt.ReadOnly = !isEditable;
            neuroSurgeonTxt.ReadOnly = !isEditable;
            endocrinologistTx.ReadOnly = !isEditable;
            analysisDate.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isNew && getIsValid()|| isDirty()))
            {
    
                DdtSpecialistConclusion specConslusion = (DdtSpecialistConclusion) getObject();
                specConslusion.HospitalitySession = hospitalitySession.ObjectId;
                specConslusion.Doctor = hospitalitySession.CuringDoctor;
                specConslusion.Patient = hospitalitySession.Patient;
                if (parentId != null)
                {
                    specConslusion.Parent = parentId;
                }
                if (parentType != null)
                {
                    specConslusion.ParentType = parentType;
                }

                objectId = service.GetDdtSpecialistConclusionService().Save(specConslusion);
                isNew = false;
                hasChanges = false;
            }
        }

        public string getObjectId()
        {
            return objectId;
        }

        public bool getIsValid()
        {
            return !string.IsNullOrEmpty(neurologTxt.Text) ||!string.IsNullOrEmpty(surgeonTxt.Text) 
                ||!string.IsNullOrEmpty(neuroSurgeonTxt.Text) ||!string.IsNullOrEmpty(endocrinologistTx.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {

            DdtSpecialistConclusion specConslusion = service.GetDdtSpecialistConclusionService().GetById(objectId);
            if (specConslusion == null)
            {
                specConslusion = new DdtSpecialistConclusion();
            }
            specConslusion.Neurolog = neurologTxt.Text;
            specConslusion.Surgeon = surgeonTxt.Text;
            specConslusion.NeuroSurgeon = neuroSurgeonTxt.Text;
            specConslusion.Endocrinologist = endocrinologistTx.Text;
            specConslusion.AnalysisDate = analysisDate.Value;
            return specConslusion;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtSpecialistConclusion)
            {
                DdtSpecialistConclusion specConclusion = (DdtSpecialistConclusion)obj;
                neurologTxt.Text = specConclusion.Neurolog;
                surgeonTxt.Text = specConclusion.Surgeon;
                neuroSurgeonTxt.Text = specConclusion.NeuroSurgeon;
                endocrinologistTx.Text = specConclusion.Endocrinologist;
                title.Text = "Заключения специалистов за " + specConclusion.AnalysisDate.ToShortDateString();
                analysisDate.Value = specConclusion.AnalysisDate;
                objectId = specConclusion.ObjectId;
                isNew = string.IsNullOrEmpty(objectId);
                hasChanges = false;
            }
        }

        public bool isVisible()
        {
            return true;
        }

        private void analysisDate_ValueChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        private void ControlTxt_TextChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }
    }
}
