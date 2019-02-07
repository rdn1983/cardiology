using System;
using System.ComponentModel;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model;

namespace Cardiology.UI.Controls
{
    public partial class IssuedMedicineControl : UserControl, IComponent
    {
        private string objectId;
        private int index;
        private IssuedMedicineContainer parent;

        public IssuedMedicineControl(int index, IssuedMedicineContainer parent)
        {
            InitializeComponent();
            this.index = index;
            this.parent = parent;
            DataService service = new DataService();
            CommonUtils.InitCureTypeComboboxValues(service, medicineTypeTxt0);
        }

        internal int getIndex()
        {
            return index;
        }

        internal void Init(DataService service, DdtIssuedMedicine med)
        {
            if (med != null)
            {
                DdtCure cure = service.queryObjectById<DdtCure>(med.DsidCure);
                if (cure != null)
                {
                    DdtCureType type = service.queryObjectByAttrCond<DdtCureType>(DdtCureType.TABLE_NAME, "r_object_id", cure.CureTypeId + "", true);
                    if (type != null)
                    {
                        medicineTypeTxt0.SelectedIndex = medicineTypeTxt0.FindStringExact(type.DssName);
                    }
                    issuedMedicineTxt0.SelectedIndex = issuedMedicineTxt0.FindStringExact(cure.DssName);
                    objectId = med.RObjectId;
                }
            }
        }

        internal void refreshData(DataService service, DdtCure cure)
        {
            DdtCureType type = service.queryObjectByAttrCond<DdtCureType>(DdtCureType.TABLE_NAME, "r_object_id", cure.CureTypeId + "", true);
            if (type != null)
            {
                medicineTypeTxt0.SelectedIndex = medicineTypeTxt0.FindStringExact(type.DssName);
            }
            issuedMedicineTxt0.SelectedIndex = issuedMedicineTxt0.FindStringExact(cure.DssName);
        }

        internal DdtIssuedMedicine getObject(DataService service, string medListId)
        {
            DdtIssuedMedicine result = service.queryObjectById<DdtIssuedMedicine>(objectId) ?? new DdtIssuedMedicine();
            DdtCure cure = (DdtCure)issuedMedicineTxt0.SelectedItem;
            if (cure != null && !string.IsNullOrEmpty(issuedMedicineTxt0.Text))
            {
                result.DsidCure = cure.ObjectId;
            }
            result.DsidMedList = medListId;
            return result;
        }

        internal void removeBtn0_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(objectId))
            {
                DataService service = new DataService();
                service.queryDelete(DdtIssuedMedicine.TABLE_NAME, "r_object_id", objectId, true);
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
            CommonUtils.InitCureComboboxValuesByTypeId(new DataService(), issuedMedicineTxt0, selectedVal.ObjectId);
        }
    }
}
