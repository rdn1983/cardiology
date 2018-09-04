using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace Cardiology
{
    public partial class AnalysisSelector : Form
    {
        private List<string> selectedIds;
        private bool success;

        public AnalysisSelector()
        {
            selectedIds = new List<string>();
            InitializeComponent();
        }

        internal void ShowDialog(string typeName, string condition, string labelAttr, string valueAttr, List<string> exceptedIds)
        {
            success = false;
            selectedIds.Clear();
            selectionContainer.Items.Clear();
            initControls(typeName, condition, labelAttr, valueAttr, exceptedIds);
            ShowDialog();
        }

        private void initControls(string typeName, string condition, string labelAttr, string valueAttr, List<string> exceptedIds)
        {
            DataService service = new DataService();
            StringBuilder dqlBuilder = new StringBuilder();
            dqlBuilder.Append("SELECT ").Append(labelAttr).Append(",").Append(valueAttr).Append(" FROM ").Append(typeName);
            if (exceptedIds != null && exceptedIds.Count > 0)
            {
                dqlBuilder.Append(" WHERE r_object_id NOT IN (");
                foreach (string id in exceptedIds)
                {
                    dqlBuilder.Append("'").Append(id).Append("',");
                }
                dqlBuilder.Remove(dqlBuilder.ToString().LastIndexOf(","), 1);
                dqlBuilder.Append(")");
            }

            if (CommonUtils.isNotBlank(condition))
            {
                dqlBuilder.Append(exceptedIds != null && exceptedIds.Count > 0 ? " AND " : " WHERE ");
                dqlBuilder.Append(condition);
            }

            Dictionary<string, string> values = service.queryMappedValues(dqlBuilder.ToString(), "r_object_id", "r_creation_date");
            foreach (KeyValuePair<string, string> entry in values)
            {
                ListViewItem ll = new ListViewItem(entry.Value);
                ListViewSubItem sub = new ListViewSubItem(ll, entry.Key);
                ll.SubItems.Add(sub);
                selectionContainer.Items.Add(ll);
            }
        }

        internal List<string> returnValues()
        {
            List<string> result = new List<string>(selectedIds);
            selectedIds.Clear();
            success = false;
            clearSelection_Click(null, null);
            return result;
        }

        internal bool isSuccess()
        {
            return success;
        }

        private void select_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem k in selectionContainer.Items)
            {
                if (k.Checked)
                {
                    selectedIds.Add(k.SubItems[1].Text);
                }
            }
            warningLbl.Visible = selectedIds.Count == 0;
            if (selectedIds.Count > 0)
            {
                success = true;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in selectionContainer.Items)
            {
                item.Checked = true;
            }
        }

        private void clearSelection_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in selectionContainer.Items)
            {
                item.Checked = false;
            }
            selectedIds.Clear();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            selectedIds.Clear();
            selectionContainer.Items.Clear();
            Close();
        }
    }
}
