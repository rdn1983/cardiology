using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{

    public partial class IssuedMedicineContainer : UserControl
    {
        private string medListId;
        private int counter = 0;

        public IssuedMedicineContainer()
        {
            InitializeComponent();
        }

        internal void Init(DdtIssuedMedicineList medList)
        {
            if (medList != null)
            {
                medListId = medList.ObjectId;
                clearMedicine();
                IList<DdtIssuedMedicine> med = DbDataService.GetService().GetDdtIssuedMedicineService().GetListByMedicineListId(medList.ObjectId);
                for (int i = 0; i < med.Count; i++)
                {
                    IssuedMedicineControl control = new IssuedMedicineControl(getNextIndex(), this);
                    control.Init(med[i]);
                    sizedContainer.Controls.Add(control);
                }
            }
        }

        internal void RefreshData(IDbDataService service, IList<DdtCure> cures)
        {
            if (cures != null)
            {

                clearMedicine();
                foreach (DdtCure cure in cures)
                {
                    IssuedMedicineControl ctrl = new IssuedMedicineControl(getNextIndex(), this);
                    ctrl.RefreshData(service, cure);
                    sizedContainer.Controls.Add(ctrl);
                }
            }

        }

        internal List<DdtIssuedMedicine> getIssuedMedicines(IDbDataService service)
        {

            List<DdtIssuedMedicine> result = new List<DdtIssuedMedicine>();
            for (int i = 0; i < sizedContainer.Controls.Count; i++)
            {
                IssuedMedicineControl control = (IssuedMedicineControl)sizedContainer.Controls[i];
                DdtIssuedMedicine medObj = control.GetObject(service, medListId);
                if (medObj != null)
                {
                    result.Add(medObj);
                }
            }
            return result;
        }

        internal void clearMedicine()
        {
            foreach (IssuedMedicineControl med in sizedContainer.Controls)
            {
                med.removeBtn0_Click(null, null);
            }
            sizedContainer.Controls.Clear();
        }

        internal void addMedicineBox(IDbDataService service)
        {
            IssuedMedicineControl ctrl = new IssuedMedicineControl(getNextIndex(), this);
            sizedContainer.Controls.Add(ctrl);
        }

        private int getNextIndex()
        {
            return counter++;
        }

        internal void remove(int index)
        {
            foreach (IssuedMedicineControl med in sizedContainer.Controls)
            {
                if (med.getIndex() == index)
                {
                    sizedContainer.Controls.Remove(med);
                }
            }
        }
    }

}
