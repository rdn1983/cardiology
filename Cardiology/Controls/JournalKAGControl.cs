using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cardiology.Utils;
using Cardiology.Model;

namespace Cardiology.Controls
{
    public partial class JournalKAGControl : UserControl, IComponent
    {
        private const int CONTROL_HEIGHT = 108;
        private string objId;

        public JournalKAGControl()
        {
            InitializeComponent();
            initControl();
        }

        private void initControl()
        {
            CommonUtils.initRangedItems(chssText0, 40, 200);
            CommonUtils.initRangedItems(chddTxt0, 14, 26);
        }

        public void initObject(DdtVariousSpecConcluson obj) {
            if (obj != null)
            {
                objId = obj.RObjectId;
                initDateTime(obj.DsdtAdmissionDate);
                inspectionTxt0.Text = obj.DssSpecialistConclusion;
                chddTxt0.Text = obj.DssAdditionalInfo1;
                adText0.Text = obj.DssAdditionalInfo3;
                chssText0.Text = obj.DssAdditionalInfo2;
                goodRhytmBtn0.Checked = "синусовый ритм".Equals(obj.DssAdditionalInfo4);
                badRhytmBtn0.Checked = !"синусовый ритм".Equals(obj.DssAdditionalInfo4);
                monitorTxt0.Text = obj.DssAdditionalInfo4;
            }
        }

        public DdtVariousSpecConcluson getObject()
        {
            DdtVariousSpecConcluson result = new DdtVariousSpecConcluson();
            result.RObjectId = objId;
            result.DsdtAdmissionDate = CommonUtils.constructDateWIthTime(inspectionDate0.Value, inspectionTime0.Value);
            result.DssSpecialistConclusion = inspectionTxt0.Text;
            result.DssAdditionalInfo1 = chddTxt0.Text;
            result.DssAdditionalInfo2 = chssText0.Text;
            result.DssAdditionalInfo3 = adText0.Text;
            result.DssAdditionalInfo4 = monitorTxt0.Text;
            return result;
        }

        public void initDateTime(DateTime date)
        {
            inspectionDate0.Value = date;
            inspectionTime0.Value = date;
        }

        public DateTime getDateTime()
        {
            return CommonUtils.constructDateWIthTime(inspectionDate0.Value, inspectionTime0.Value);
        }

        private void hideBtn0_CheckedChanged(object sender, EventArgs e)
        {
            int width = this.Width;
            Console.WriteLine(width);
            int height = hideBtn0.Checked ? 0 : 83;
            hidingPnl0.Size = new Size(width - 9, height);
            int allHeight = hideBtn0.Checked ? 23 : CONTROL_HEIGHT;
            this.Size = new Size(width-4, allHeight);
        }

        private void goodRhytmBtn0_CheckedChanged(object sender, EventArgs e)
        {
            string monitorValue = goodRhytmBtn0.Checked ? "синусовый ритм" : "трепетание предсердий";
            monitorTxt0.Text = monitorValue;
        }
    }
}
