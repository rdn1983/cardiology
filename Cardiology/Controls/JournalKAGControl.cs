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
        private const string GOOD_RHYTM = "синусовый ритм";
        private const string GOOD_RHYTM_LBL = "ритм правильный";
        private const string BAD_RHYTM = "трепетание предсердий";
        private const string BAD_RHYTM_LBL = "ритм неправильный";

        private const int CONTROL_HEIGHT = 108;
        private string objId;

        public JournalKAGControl()
        {
            InitializeComponent();
            initControl();
        }

        private void initControl()
        {
            CommonUtils.initRangedItems(chssTxt, 40, 200);
            CommonUtils.initRangedItems(chddTxt, 14, 26);
            journalTxt.Text = JournalShuffleUtils.shuffleJournalText();
            chddTxt.SelectedIndex = chddTxt.FindString("14");
            adTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(adTxt.Items.Count - 1);
            chssTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(chssTxt.Items.Count - 1);
        }

        public void initObject(DdtVariousSpecConcluson obj)
        {
            if (obj != null)
            {
                objId = obj.RObjectId;
                initDateTime(obj.DsdtAdmissionDate);
                journalTxt.Text = obj.DssSpecialistConclusion;
                chddTxt.Text = obj.DssAdditionalInfo1;
                adTxt.Text = obj.DssAdditionalInfo3;
                chssTxt.Text = obj.DssAdditionalInfo2;
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
            result.DssSpecialistConclusion = journalTxt.Text;
            result.DssAdditionalInfo1 = chddTxt.Text;
            result.DssAdditionalInfo2 = chssTxt.Text;
            result.DssAdditionalInfo3 = adTxt.Text;
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

        public Boolean isGoodRhytm()
        {
            return goodRhytmBtn0.Checked;
        }

        public void initRhytm(Boolean goodRhytm)
        {
            goodRhytmBtn0.Checked = goodRhytm;
            badRhytmBtn0.Checked = !goodRhytm;
            monitorTxt0.Text = goodRhytmBtn0.Checked ? GOOD_RHYTM : BAD_RHYTM;
        }

        private void hideBtn0_CheckedChanged(object sender, EventArgs e)
        {
            int width = this.Width;
            Console.WriteLine(width);
            int height = hideBtn0.Checked ? 0 : 83;
            hidingPnl0.Size = new Size(width - 9, height);
            int allHeight = hideBtn0.Checked ? 23 : CONTROL_HEIGHT;
            this.Size = new Size(width - 4, allHeight);
        }

        private void goodRhytmBtn0_CheckedChanged(object sender, EventArgs e)
        {
            string monitorValue = goodRhytmBtn0.Checked ? GOOD_RHYTM : BAD_RHYTM;
            monitorTxt0.Text = monitorValue;
            string journalOld = journalTxt.Text;
            string findTxt = isGoodRhytm() ? BAD_RHYTM_LBL : GOOD_RHYTM_LBL;
            string replaceTxt = isGoodRhytm() ? GOOD_RHYTM_LBL : BAD_RHYTM_LBL;
            if (CommonUtils.isNotBlank(journalOld) && journalOld.IndexOf(findTxt) >= 0)
            {
                string val = journalOld.Replace(findTxt, replaceTxt);
                journalTxt.Text = val;
            }
            else if (journalOld.IndexOf(replaceTxt) < 0)
            {
                journalTxt.Text += "" + replaceTxt;
            }
        }

        private void chddTxt0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newValue = chddTxt.Text;
            if (CommonUtils.isNotBlank(newValue))
            {
                string oldJournal = journalTxt.Text;
                journalTxt.Text = CommonUtils.replaceJournalIntParameter(oldJournal, "ЧД", newValue);
            }
        }

        private void adText0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newValue = adTxt.Text;
            if (CommonUtils.isNotBlank(newValue))
            {
                string oldJournal = journalTxt.Text;
                journalTxt.Text = CommonUtils.replaceJournalIntParameter(oldJournal, "АД", newValue);
            }
        }

        private void chssText0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newValue = chssTxt.Text;
            if (CommonUtils.isNotBlank(newValue))
            {
                string oldJournal = journalTxt.Text;
                journalTxt.Text = CommonUtils.replaceJournalIntParameter(oldJournal, "ЧСС", newValue);
            }
        }
    }
}
