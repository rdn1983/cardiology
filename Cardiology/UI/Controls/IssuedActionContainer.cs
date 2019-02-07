using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model;

namespace Cardiology.UI.Controls
{
    public partial class IssuedActionContainer : UserControl
    {
        private int counter = 0;

        public IssuedActionContainer()
        {
            InitializeComponent();
        }

        internal void init(DataService service, List<DdtIssuedAction> allAction)
        {
            if (allAction != null)
            {
                clearMedicine();
                foreach (DdtIssuedAction issuedAction in allAction)
                {
                    IssuedActionControl ctrl = new IssuedActionControl(getNextIndex(), this);
                    ctrl.init(issuedAction);
                    sizedContainer.Controls.Add(ctrl);
                }
            }

        }

        internal List<DdtIssuedAction> getIssuedMedicines()
        {
            DataService service = new DataService();
            List<DdtIssuedAction> result = new List<DdtIssuedAction>();
            for (int i = 0; i < sizedContainer.Controls.Count; i++)
            {
                IssuedActionControl control = (IssuedActionControl)sizedContainer.Controls[i];
                DdtIssuedAction obj = control.getObject(service);
                if (obj != null)
                {
                    result.Add(obj);
                }
            }
            return result;
        }

        internal void clearMedicine()
        {
            /*foreach (IssuedActionControl med in sizedContainer.Controls)
            {
                med.remove();
            }*/
            sizedContainer.Controls.Clear();
        }

        internal void addMedicineBox()
        {
            IssuedActionControl ctrl = new IssuedActionControl(getNextIndex(), this);
            sizedContainer.Controls.Add(ctrl);
        }

        private int getNextIndex()
        {
            return counter++;
        }

        internal void remove(int index)
        {
            foreach (IssuedActionControl med in sizedContainer.Controls)
            {
                if (med.getIndex() == index)
                {
                    sizedContainer.Controls.Remove(med);
                }
            }
        }
    }
}
