﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Cardiology.Data;

namespace Cardiology.UI.Forms
{
    public partial class AnalysisSelector : Form
    {
        private List<string> selectedIds;
        private List<string> selectedLabels;
        private bool success;

        private static AnalysisSelector instance;

        public static AnalysisSelector getInstance()
        {
            if (instance == null)
            {
                instance = new AnalysisSelector();
            }
            return instance;
        }

        //todo make private
        private AnalysisSelector()
        {
            selectedIds = new List<string>();
            selectedLabels = new List<string>();
            InitializeComponent();
        }

        internal void ShowDialog(string typeName, string condition, string labelAttr, string valueAttr, List<string> exceptedIds)
        {
            success = false;
            selectedIds.Clear();
            selectedLabels.Clear();
            selectionContainer.Items.Clear();
            initControls(typeName, condition, labelAttr, valueAttr, exceptedIds);
            ShowDialog();
        }

        private void initControls(string typeName, string condition, string labelAttr, string valueAttr, List<string> exceptedIds)
        {

            StringBuilder dqlBuilder = new StringBuilder();
            dqlBuilder.Append("SELECT ").Append(labelAttr).Append(",").Append(valueAttr).Append(" FROM ").Append(typeName);
            if (exceptedIds != null && exceptedIds.Count > 0)
            {
                dqlBuilder.Append(" WHERE " + valueAttr + " NOT IN (");
                foreach (string id in exceptedIds)
                {
                    dqlBuilder.Append("'").Append(id).Append("',");
                }
                dqlBuilder.Remove(dqlBuilder.ToString().LastIndexOf(","), 1);
                dqlBuilder.Append(")");
            }

            if (!string.IsNullOrEmpty(condition))
            {
                dqlBuilder.Append(exceptedIds != null && exceptedIds.Count > 0 ? " AND " : " WHERE ");
                dqlBuilder.Append(condition);
            }

            DbDataService.GetInstance().Select(dqlBuilder.ToString(), labelAttr, valueAttr, (key, value) =>
            {
                ListViewItem ll = new ListViewItem(key);
                ListViewItem.ListViewSubItem sub = new ListViewItem.ListViewSubItem(ll, value);
                ll.SubItems.Add(sub);
                selectionContainer.Items.Add(ll);
            });
        }

        internal List<string> returnLabels()
        {
            List<string> result = new List<string>(selectedLabels);
            selectedLabels.Clear();
            selectedIds.Clear();
            success = false;
            clearSelection_Click(null, null);
            return result;
        }

        internal List<string> returnValues()
        {
            List<string> result = new List<string>(selectedIds);
            selectedIds.Clear();
            selectedLabels.Clear();
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
                    selectedLabels.Add(k.Text);
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
            selectedLabels.Clear();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            selectedIds.Clear();
            selectedLabels.Clear();
            selectionContainer.Items.Clear();
            Close();
        }
    }
}
