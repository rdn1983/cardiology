using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Cardiology.Model;
using Cardiology.Utils;

namespace Cardiology
{
    public partial class IssuedMedicineControl : UserControl, IComponent
    {
        private List<int> indexes;

        public IssuedMedicineControl()
        {
            indexes = new List<int>();
            InitializeComponent();
            DataService service = new DataService();
        }

        internal void Init(DataService service, DdtIssuedMedicineList medList)
        {
            if (medList != null)
            {
                clearMedicine();
                List<DdtIssuedMedicine> med = service.queryObjectsCollectionByAttrCond<DdtIssuedMedicine>(DdtIssuedMedicine.TABLE_NAME, "dsid_med_list", medList.ObjectId, true);
                for (int i = 0; i < med.Count; i++)
                {
                    DdtCure cure = service.queryObjectById<DdtCure>(DdtCure.TABLE_NAME, med[i].DsidCure);
                    if (cure != null)
                    {
                        int indx = addMedicineBox();

                        ComboBox box = (ComboBox)CommonUtils.findControl(medicineContainer, "medicineTypeTxt" + indx);
                        DdtCureType type = service.queryObjectByAttrCond<DdtCureType>(DdtCureType.TABLE_NAME, "dsi_type", cure.DsiType + "", false);
                        if (type != null)
                        {
                            box.SelectedIndex = box.FindStringExact(type.DssName);
                        }
                        box = (ComboBox)CommonUtils.findControl(medicineContainer, "issuedMedicineTxt" + indx);
                        box.SelectedIndex = box.FindStringExact(cure.DssName);

                        Label idLbl = (Label)CommonUtils.findControl(medicineContainer, "objectIdLbl" + indx);
                        idLbl.Text = med[i].RObjectId;
                    }

                }
            }
        }

        internal void refreshData(DataService service, List<DdtCure> cures)
        {
            clearMedicine();
            foreach (DdtCure cure in cures)
            {
                int indx = addMedicineBox();
                ComboBox box = (ComboBox)CommonUtils.findControl(medicineContainer, "medicineTypeTxt" + indx);
                DdtCureType type = service.queryObjectByAttrCond<DdtCureType>(DdtCureType.TABLE_NAME, "dsi_type", cure.DsiType + "", false);
                if (type != null)
                {
                    box.SelectedIndex = box.FindStringExact(type.DssName);
                }
                box = (ComboBox)CommonUtils.findControl(medicineContainer, "issuedMedicineTxt" + indx);
                box.SelectedIndex = box.FindStringExact(cure.DssName);
            }

        }

        internal List<DdtIssuedMedicine> getIssuedMedicines()
        {
            DataService service = new DataService();
            List<DdtIssuedMedicine> result = new List<DdtIssuedMedicine>();
            for (int i = 0; i < medicineContainer.Controls.Count; i++)
            {
                Control container = medicineContainer.Controls[i];
                Label idLbl = (Label)CommonUtils.findControl(container, "objectIdLbl" + indexes[i]);
                DdtIssuedMedicine med = null;
                if (CommonUtils.isNotBlank(idLbl.Text))
                {
                    med = service.queryObjectById<DdtIssuedMedicine>(DdtIssuedMedicine.TABLE_NAME, idLbl.Text);
                }
                else
                {
                    med = new DdtIssuedMedicine();
                }
                ComboBox box = (ComboBox)CommonUtils.findControl(container, "issuedMedicineTxt" + indexes[i]);
                DdtCure cure = (DdtCure)box.SelectedItem;
                if (cure != null && CommonUtils.isNotBlank(box.Text))
                {
                    med.DsidCure = cure.ObjectId;
                    result.Add(med);
                }
            }
            return result;
        }

        internal void clearMedicine()
        {
            medicineContainer.Controls.Clear();
            indexes.Clear();
        }

        internal int addMedicineBox()
        {
            int indx = getNextIndex();
            Control c = CommonUtils.copyControl(issuedMedPnl0, indx);
            indexes.Add(indx);
            ComboBox box = (ComboBox)CommonUtils.findControl(c, "medicineTypeTxt" + indx);
            DataService service = new DataService();
            CommonUtils.initCureTypeComboboxValues(service, box);
            box.SelectedIndexChanged += new System.EventHandler(this.medicineTypeTxt_SelectedIndexChanged);

            Button b = (Button)CommonUtils.findControl(c, "removeBtn" + indx);
            b.Click += new System.EventHandler(this.removeBtn_Clicked);
            medicineContainer.Controls.Add(c);
            return indx;
        }

        private int getNextIndex()
        {
            if (indexes.Count == 0)
            {
                return 1;
            }

            int lastIndx = indexes[indexes.Count - 1];
            return lastIndx + 1;
        }


        private void medicineTypeTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            string boxName = box.Name;
            string indexStr = String.Intern(boxName.Substring(CommonUtils.getFirstDigitIndex(boxName)));
            if (CommonUtils.isNotBlank(indexStr))
            {
                DdtCureType selectedVal = (DdtCureType)box.SelectedItem;
                ComboBox c = (ComboBox)CommonUtils.findControl(medicineContainer, "issuedMedicineTxt" + indexStr);
                if (c != null)
                {
                    CommonUtils.initCureComboboxValues(new DataService(), c, selectedVal.DsiType);
                }
            }
        }

        private void removeBtn_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonName = button.Name;
            string indexStr = String.Intern(buttonName.Substring(CommonUtils.getFirstDigitIndex(buttonName)));
            int indx = Int32.Parse(indexStr);
            remove(indx);
        }

        private void remove(int index)
        {
            int indexOfItem = indexes.IndexOf(index);
            indexes.RemoveAt(indexOfItem);
            Control container = medicineContainer.Controls[index];
            Label idLbl = (Label)CommonUtils.findControl(container, "objectIdLbl" + indexes[index]);
            if (CommonUtils.isNotBlank(idLbl.Text))
            {

            }
            medicineContainer.Controls.RemoveAt(indexOfItem);
        }


    }
}
