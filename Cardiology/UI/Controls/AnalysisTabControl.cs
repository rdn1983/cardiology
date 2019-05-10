using Cardiology.Data;
using Cardiology.Data.Commons;
using Cardiology.Data.Model2;
using Cardiology.UI.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology.UI.Controls
{
    public partial class AnalysisTabControl : UserControl, IAnalysisContainer
    {
        private DdtHospital hospitalSession;
        private IList<string> validTypes;
        private string parentId;
        private string parentType;

        public AnalysisTabControl()
        {
            InitializeComponent();
        }

        public void init(DdtHospital hospital, string parentId, string parentType, IList<string> validTypes)
        {
            this.hospitalSession = hospital;
            this.parentId = this.parentId ?? parentId;
            this.parentType = this.parentType ?? parentType;
            this.validTypes = validTypes ?? new List<string>();

            foreach (ToolStripItem item in analysisType.Items)
            {
                item.Visible = validTypes.Contains(item.Name);
                item.Click += MenuClicked;
            }

            if (parentId != null)
            {
                IList<DdtRelation> relations = DbDataService.GetInstance().GetDdtRelationService().GetByParentId(parentId);
                foreach (DdtRelation rel in relations)
                {
                    string typeLabel = DbDataService.GetInstance().GetString(String.Format("SELECT dss_operation_name FROM  ddv_history where dsid_operation_id = '{0}'", rel.Child));
                    addAnalisis(rel.ChildType, typeLabel, rel.Child);
                }
            }
        }

        public void addAnalisis(string typeName, string Label, string objectId)
        {
            TableLayoutPanel container = getTabContainer(typeName, Label, true);
            Control control = createDocbaseControl(typeName, objectId);
            container.Controls.Add(control);
        }

        public void save(string parentId, string parentType)
        {
            this.parentId = this.parentId ?? parentId;
            this.parentType = this.parentType ?? parentType;

            foreach (TabPage tab in tabbedAnalysis.TabPages)
            {
                seeDeeper(tab, tab.Name);
            }
        }

        private void seeDeeper(Control container, string type)
        {
            if (container == null) return;
            ControlCollection coll = container.Controls;
            IEnumerator it = coll.GetEnumerator();
            while (it.MoveNext())
            {
                Control control = (Control)it.Current;
                if (control == null) { break; }
                else if (control is IDocbaseControl)
                {
                    ((IDocbaseControl)control).saveObject(hospitalSession, parentId, parentType);
                    string id = ((IDocbaseControl)control).getObjectId();
                    IDdtRelationService relationService = DbDataService.GetInstance().GetDdtRelationService();
                    if (parentId != null && parentType != null && relationService.GetByParentAndChildIds(parentId, id) == null)
                    {
                        DdtRelation relation = new DdtRelation();
                        relation.Parent = parentId;
                        relation.Child = id;
                        relation.ChildType = type;
                        relationService.Save(relation);
                    }
                }
                else
                {
                    seeDeeper(control, type);
                }
            }
        }

        private TableLayoutPanel getTabContainer(string name, string title, bool isVerticalStyle)
        {
            TableLayoutPanel result = null;
            if (!tabbedAnalysis.TabPages.ContainsKey(name))
            {
                result = createTab(name, title, isVerticalStyle);
            }
            else
            {
                int index = tabbedAnalysis.TabPages.IndexOfKey(name);
                TabPage tab = tabbedAnalysis.TabPages[index];
                result = (TableLayoutPanel)tab.Controls[0];
            }
            return result;
        }

        private TableLayoutPanel createTab(string name, string title, bool isVerticalStyle)
        {
            TabPage tab = new TabPage();
            tab.Name = name;
            tab.Text = title;
            tab.AutoScroll = true;
            TableLayoutPanel result = new TableLayoutPanel();
            result.ColumnCount = 1;
            result.RowCount = 1;
            result.GrowStyle = isVerticalStyle ? TableLayoutPanelGrowStyle.AddColumns : TableLayoutPanelGrowStyle.AddRows;
            result.AutoSize = true;
            result.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tab.Controls.Add(result);
            tabbedAnalysis.TabPages.Add(tab);
            return result;
        }

        #region controls_behavior

        private void MenuClicked(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            addAnalisis(item.Name, item.Text, null);
        }

        private void createAnalysis_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseArgs = e as MouseEventArgs;
            analysisType.Show(createAnalysis, mouseArgs.X, mouseArgs.Y);
        }

        private void selectAnalysis_Click(object sender, EventArgs e)
        {
            if (hospitalSession == null || validTypes == null || validTypes.Count == 0)
            {
                return;
            }
            IList<string> existedAnalysisIds = new List<string>();

            string queryCnd = "dsid_hospitality_session='" + hospitalSession.ObjectId + "' AND dss_operation_type IN ('" + String.Join("','", validTypes) + "')";
            AnalysisSelector.getInstance().ShowDialog("ddv_history", queryCnd, "dss_operation_name", "dsid_operation_id", getConnectedAnalysisIds());
            if (AnalysisSelector.getInstance().isSuccess())
            {
                List<string> result = AnalysisSelector.getInstance().returnValues();
                foreach (string id in result)
                {
                    DdvHistory history = DbDataService.GetInstance().GetDdvHistoryService().GetHistoryByOperationId(id);
                    addAnalisis(history.OperationType, history.OperationName, id);
                }
            }
        }

        private List<string> getConnectedAnalysisIds()
        {
            List<string> result = new List<string>();
            foreach (TabPage tab in tabbedAnalysis.TabPages)
            {
                result.AddRange(GetDeeper(tab));
            }
            return result;
        }

        private IList<string> GetDeeper(Control container)
        {
            List<string> result = new List<string>();
            if (container != null)
            {
                ControlCollection coll = container.Controls;
                IEnumerator it = coll.GetEnumerator();
                while (it.MoveNext())
                {
                    Control control = (Control)it.Current;
                    if (control is IDocbaseControl)
                    {
                        string id = ((IDocbaseControl)control).getObjectId();
                        if (id != null)
                        {
                            result.Add(id);
                        }
                    }
                    else
                    {
                        result.AddRange(GetDeeper(control));
                    }
                }
            }
            return result;
        }

        private Control createDocbaseControl(string typeName, string objId)
        {
            if (DdtBloodAnalysis.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                BloodAnalysisControl blood = new BloodAnalysisControl(objId, this, false);
                return blood;
            }
            else if (DdtEkg.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                EkgAnalysisControlcs ekg = new EkgAnalysisControlcs(objId, this, false);
                return ekg;
            }
            else if (DdtXRay.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                XRayControl xray = new XRayControl(objId, this, false);
                return xray;
            }
            else if (DdtEgds.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                EgdsAnalysisControl egds = new EgdsAnalysisControl(objId, this, false);
                return egds;
            }
            else if (DdtCoagulogram.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                CoagulogrammControl coagulogramm = new CoagulogrammControl(objId, this, false);
                return coagulogramm;
            }
            else if (DdtHolter.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                HolterControl holter = new HolterControl(objId, this, false);
                return holter;
            }
            else if (DdtHormones.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                HormonesControl hormones = new HormonesControl(objId, this, false);
                return hormones;
            }
            else if (DdtKag.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                KagAnalysisControl kag = new KagAnalysisControl(objId, this, false, hospitalSession.ObjectId);
                return kag;
            }
            else if (DdtOncologicMarkers.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                OncologicMarkersControl onko = new OncologicMarkersControl(objId, this, false, hospitalSession.ObjectId);
                return onko;
            }
            else if (DdtSpecialistConclusion.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                SpecialistConclusionControl specc = new SpecialistConclusionControl(objId, this, false);
                return specc;
            }
            else if (DdtUrineAnalysis.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                UrineAnalysisControl urine = new UrineAnalysisControl(objId, this, false);
                return urine;
            }
            else if (DdtUzi.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                UziAnalysisControl uzi = new UziAnalysisControl(objId, this, false);
                return uzi;
            }
            return null;
        }

        public void RemoveControl(Control control, string type)
        {
            string id = ((IDocbaseControl)control).getObjectId();
            TableLayoutPanel container = getTabContainer(type, control.Text, true);
            container.Controls.Remove(control);
            if (id != null)
            {
                if (id != null && parentId != null && parentType != null)
                {
                    DbDataService.GetInstance().GetDdtRelationService().RemoveConnectionByParentAndChildIds(parentId, id);
                }
            }
        }

        #endregion
    }
}
