﻿using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class EgdsAnalysisControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;
        private IAnalysisContainer container;

        public EgdsAnalysisControl(string objectId, bool additional) : this(objectId, null, additional) { }

        public EgdsAnalysisControl(string objectId, IAnalysisContainer container, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            this.container = container;
            InitializeComponent();
            InitControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        private void InitControls()
        {
            DdtEgds egds = DbDataService.GetInstance().GetDdtEgdsService().GetById(objectId);
            refreshObject(egds);
            regularEgdsTxt.Enabled = isEditable;
            analysisDate.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isDirty() || isNew && getIsValid()))
            {
   
                DdtEgds egds = (DdtEgds)getObject();
                egds.HospitalitySession= hospitalitySession.ObjectId;
                egds.Doctor = hospitalitySession.CuringDoctor;
                egds.Patient = hospitalitySession.Patient;
                if (parentId != null)
                {
                    egds.Parent = parentId;
                }
                if (parentType != null)
                {
                    egds.ParentType = parentType;
                }

                objectId = DbDataService.GetInstance().GetDdtEgdsService().Save(egds);
                hasChanges = false;
                isNew = false;
            }
        }

        public string getObjectId()
        {
            return objectId;
        }

        public bool getIsValid()
        {
            return !string.IsNullOrEmpty(regularEgdsTxt.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {
            DdtEgds egds = DbDataService.GetInstance().GetDdtEgdsService().GetById(objectId);
            if (egds == null)
            {
                egds = new DdtEgds();
            }
            egds.AnalysisDate = analysisDate.Value;
            egds.Egds = regularEgdsTxt.Text;
            return egds;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtEgds)
            {
                DdtEgds egds = (DdtEgds)obj;
                regularEgdsTxt.Text = egds.Egds;
                analysisTitleLbl.Text = "ЭГДС за " + egds.AnalysisDate.ToShortDateString();
                analysisDate.Value = egds.AnalysisDate;
                objectId = egds.ObjectId;
                isNew = string.IsNullOrEmpty(objectId);
                hasChanges = false;
            }
        }

        public bool isVisible()
        {
            return true;
        }

        private void regularEgdsTxt_TextChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        private void analysisDate_ValueChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        private void hide_Click(object sender, System.EventArgs e)
        {
            container?.RemoveControl(this, DdtEgds.NAME);
        }
    }
}
