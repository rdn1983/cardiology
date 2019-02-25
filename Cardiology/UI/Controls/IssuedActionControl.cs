using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class IssuedActionControl : UserControl
    {
        private string objectId;
        private int index;
        private IssuedActionContainer parent;

        public IssuedActionControl(int index, IssuedActionContainer obj)
        {
            this.index = index;
            this.parent = obj;
            InitializeComponent();
        }

        internal void init(DdtIssuedAction obj)
        {
            if (obj != null)
            {
                issuedActionTxt.Text = obj.Action;
                objectId = obj.ObjectId;
            }
        }

        internal int getIndex()
        {
            return index;
        }

        internal DdtIssuedAction getObject(IDbDataService service)
        {
            if (!string.IsNullOrEmpty(issuedActionTxt.Text))
            {
                DdtIssuedAction result = service.queryObjectById<DdtIssuedAction>(objectId) ?? new DdtIssuedAction();
                result.Action = issuedActionTxt.Text;
                return result;
            }
            return null;
        }

        private void removeBtn_Click(object sender, System.EventArgs e)
        {
            remove();
        }

        internal void remove()
        {
            if (!string.IsNullOrEmpty(objectId))
            {
    
                service.queryDelete(DdtIssuedAction.NAME, "r_object_id", objectId, true);
            }
            if (parent != null)
            {
                parent.remove(index);
            }
        }
    }
}
