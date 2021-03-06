﻿using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class HolterControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool isEditable;
        private bool hasChanges;
        private bool isNew;
        private IAnalysisContainer container;

        public HolterControl(string objectId, bool additional) : this(objectId, null, additional) { }

        public HolterControl(string objectId, IAnalysisContainer container, bool additional)
        {
            this.objectId = objectId;
            this.isEditable = !additional;
            this.container = container;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        private void initControls()
        {
            DdtHolter holter = DbDataService.GetInstance().GetDdtHolterService().GetById(objectId);
            refreshObject(holter);
            holterTxt.Enabled = isEditable;
            monitoringAdTxt.Enabled = isEditable;
            analysisDate.Enabled = isEditable;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (isEditable && (isNew && getIsValid() || isDirty()))
            {

                DdtHolter holter = (DdtHolter)getObject();
                holter.HospitalitySession = hospitalitySession.ObjectId;
                holter.Doctor = hospitalitySession.CuringDoctor;
                holter.Patient = hospitalitySession.Patient;
                if (parentId != null)
                {
                    holter.Parent = parentId;
                }
                if (parentType != null)
                {
                    holter.ParentType = parentType;
                }

                objectId = DbDataService.GetInstance().GetDdtHolterService().Save(holter);
                hasChanges = false;
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
            return !string.IsNullOrEmpty(holterTxt.Text) || !string.IsNullOrEmpty(monitoringAdTxt.Text);
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {

            DdtHolter holter = DbDataService.GetInstance().GetDdtHolterService().GetById(objectId);
            if (holter == null)
            {
                holter = new DdtHolter();
            }
            holter.AnalysisDate = analysisDate.Value;
            holter.Holter = holterTxt.Text;
            holter.MonitoringAd = monitoringAdTxt.Text;
            return holter;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtHolter)
            {
                DdtHolter holter = (DdtHolter)obj;
                holterTxt.Text = holter.Holter;
                monitoringAdTxt.Text = holter.MonitoringAd;
                title.Text = "Анализы за " + holter.AnalysisDate.ToShortDateString();
                analysisDate.Value = holter.AnalysisDate;
                objectId = holter.ObjectId;
                isNew = string.IsNullOrEmpty(objectId);
            }
        }

        public bool isVisible()
        {
            return true;
        }

        private void holterTxt_TextChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        private void monitoringAdTxt_TextChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        private void analysisDate_ValueChanged(object sender, System.EventArgs e)
        {
            hasChanges = true;
        }

        private void hide_Click(object sender, System.EventArgs e)
        {
            container?.RemoveControl(this, DdtHolter.NAME);
        }
    }
}
