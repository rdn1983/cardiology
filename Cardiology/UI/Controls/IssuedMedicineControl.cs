using System;
using System.ComponentModel;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class IssuedMedicineControl : UserControl, IComponent
    {
        private readonly IDbDataService service;
        private string objectId;
        private int index;
        private IssuedMedicineContainer parent;

        public IssuedMedicineControl(IDbDataService service, int index, IssuedMedicineContainer parent)
        {
            this.service = service;

            InitializeComponent();
            this.index = index;
            this.parent = parent;

            CommonUtils.InitCureTypeComboboxValues(service, medicineTypeTxt0);
        }

        internal int getIndex()
        {
            return index;
        }

        internal void Init(DdtIssuedMedicine med)
        {
            if (med != null)
            {
                DdtCure cure = service.GetDdtCureService().GetById(med.Cure);
                if (cure != null)
                {
                    DdtCureType type = service.GetDdtCureTypeService().GetById(cure.CureType);
                    if (type != null)
                    {
                        medicineTypeTxt0.SelectedIndex = medicineTypeTxt0.FindStringExact(type.Name);
                    }
                    issuedMedicineTxt0.SelectedIndex = issuedMedicineTxt0.FindStringExact(cure.Name);
                    objectId = med.ObjectId;
                }
            }
        }

        internal void RefreshData(IDbDataService service, DdtCure cure)
        {
            DdtCureType type = service.GetDdtCureTypeService().GetById(cure.CureType);
            if (type != null)
            {
                medicineTypeTxt0.SelectedIndex = medicineTypeTxt0.FindStringExact(type.Name);
            }
            issuedMedicineTxt0.SelectedIndex = issuedMedicineTxt0.FindStringExact(cure.Name);
        }

        internal DdtIssuedMedicine GetObject(IDbDataService service, string medListId)
        {
            DdtIssuedMedicine result = service.GetDdtIssuedMedicineService().GetById(objectId) ?? new DdtIssuedMedicine();
            DdtCure cure = (DdtCure)issuedMedicineTxt0.SelectedItem;
            if (cure != null && !string.IsNullOrEmpty(issuedMedicineTxt0.Text))
            {
                result.Cure = cure.ObjectId;
            }
            result.MedList = medListId;
            return result;
        }

        internal void removeBtn0_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(objectId))
            {
                
                service.GetDdtIssuedMedicineService().Delete(objectId);
            }
            if (parent != null)
            {
                parent.remove(index);
            }
        }

        private void medicineTypeTxt0_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            DdtCureType selectedVal = (DdtCureType)box.SelectedItem;
            CommonUtils.InitCureComboboxValuesByTypeId(service, issuedMedicineTxt0, selectedVal.ObjectId);
        }
    }
}
