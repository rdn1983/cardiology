﻿using System.Windows.Forms;
using Cardiology.Model;
using Cardiology.Utils;

namespace Cardiology.Controls
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
                issuedActionTxt.Text = obj.DssAction;
                objectId = obj.RObjectId;
            }
        }

        internal int getIndex()
        {
            return index;
        }

        internal DdtIssuedAction getObject(DataService service)
        {
            if (CommonUtils.isNotBlank(issuedActionTxt.Text))
            {
                DdtIssuedAction result = service.queryObjectById<DdtIssuedAction>(objectId) ?? new DdtIssuedAction();
                result.DssAction = issuedActionTxt.Text;
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
            if (CommonUtils.isNotBlank(objectId))
            {
                DataService service = new DataService();
                service.queryDelete(DdtIssuedAction.TABLE_NAME, "r_object_id", objectId, true);
            }
            if (parent != null)
            {
                parent.remove(index);
            }
        }
    }
}