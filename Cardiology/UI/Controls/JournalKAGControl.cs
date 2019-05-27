using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;
using Cardiology.UI.Forms;

namespace Cardiology.UI.Controls
{
    public partial class JournalKAGControl : UserControl, IComponent, IDocbaseControl
    {
        private const string GOOD_RHYTM = "синусовый ритм";
        private const string GOOD_RHYTM_LBL = "ритм правильный";
        private const string BAD_RHYTM = "трепетание предсердий";
        private const string BAD_RHYTM_LBL = "ритм неправильный";
        private const string RELEASE_JOURNAL_PREFIX = "За время наблюдения состояние пациента стабилизировалось. ";
        private const string RELEASE_JOURNAL_POSTFIX = "Пациент передан дежурному врачу. ";

        private const int CONTROL_HEIGHT = 108;
        private string objId;
        private bool hasChanges;
        private bool isNew;
        private bool isReleaseJournal;
        private PulseTableCOntainer pulseSelector;
        private IAnalysisContainer container;

        public JournalKAGControl(IAnalysisContainer container, string objId, bool isRelease)
        {
            this.objId = objId;
            this.isReleaseJournal = isRelease;
            this.container = container;
            InitializeComponent();
            initControl();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objId);
        }

        private void initControl()
        {
            CommonUtils.InitRangedItems(chssTxt, 0, 230);
            CommonUtils.InitRangedItems(chddTxt, 14, 26);


            DdtJournal obj = DbDataService.GetInstance().GetDdtJournalService().GetById(objId);
            refreshObject(obj);
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtJournal)
            {
                DdtJournal journal = (DdtJournal)obj;
                initDateTime(journal.AdmissionDate);
                journalTxt.Text = journal.Journal;
                chddTxt.Text = journal.Chdd;
                adTxt.Text = journal.Ad;
                chssTxt.Text = journal.Chss;
                goodRhytmBtn0.Checked = "синусовый ритм".Equals(journal.Rhythm, StringComparison.Ordinal);
                badRhytmBtn0.Checked = !"синусовый ритм".Equals(journal.Rhythm, StringComparison.Ordinal);
                monitorTxt0.Text = journal.Monitor;
                objId = journal.ObjectId;
                freeze.Checked = journal.Freeze;
                isNew = string.IsNullOrEmpty(objId);
                hasChanges = false;
                isReleaseJournal = journal.ReleaseJournal;
                freeze.Checked = journal.Freeze;
            }
            else
            {
                initDateTime(DateTime.Now);
                string journalText = string.Intern(JournalShuffleUtils.shuffleJournalText());
                if (isReleaseJournal)
                {
                    journalText = RELEASE_JOURNAL_PREFIX + journalText + RELEASE_JOURNAL_POSTFIX;
                }
                journalTxt.Text = journalText;
                chddTxt.SelectedIndex = chddTxt.FindString("14");
                adTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(adTxt.Items.Count - 1);
                chssTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(chssTxt.Items.Count - 1);
                goodRhytmBtn0_CheckedChanged(null, null);
            }
        }

        public object getObject()
        {
            DdtJournal result = DbDataService.GetInstance().GetDdtJournalService().GetById(objId);
            if (result == null)
            {
                result = new DdtJournal();
            }
            result.ObjectId = objId;
            result.AdmissionDate = CommonUtils.ConstructDateWIthTime(inspectionDate0.Value, inspectionTime0.Value);
            result.Journal = journalTxt.Text;
            result.Chdd = chddTxt.Text;
            result.Chss = chssTxt.Text;
            result.Ad = adTxt.Text;
            result.Monitor = monitorTxt0.Text;
            result.ReleaseJournal = isReleaseJournal;
            result.Freeze = freeze.Checked;
            result.Weight = 1;
            return result;
        }

        public void initDateTime(DateTime date)
        {
            inspectionDate0.Value = date;
            inspectionTime0.Value = date;
        }

        public DateTime getDateTime()
        {
            return CommonUtils.ConstructDateWIthTime(inspectionDate0.Value, inspectionTime0.Value);
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

        public bool getIsValid()
        {
            return true;
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            DdtJournal journal = (DdtJournal)getObject();
            journal.JournalDayId = parentId;
            journal.ReleaseJournal = isReleaseJournal;
            journal.JournalDayId = parentId;
            journal.Freeze = freeze.Checked;
            journal.Weight = 1;
            journal.Doctor = hospitalitySession.DutyDoctor;

            objId = DbDataService.GetInstance().GetDdtJournalService().Save(journal);
            isNew = false;
            hasChanges = false;
        }

        public string getObjectId()
        {
            return objId;
        }

        public bool isVisible()
        {
            return true;
        }

        public bool isFreeze()
        {
            return freeze.Checked;
        }

        #region controls_behaviour

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
            if (!string.IsNullOrEmpty(journalOld) && journalOld.IndexOf(findTxt) >= 0)
            {
                string val = journalOld.Replace(findTxt, replaceTxt);
                journalTxt.Text = val;
            }
            else if (journalOld.IndexOf(replaceTxt) < 0)
            {
                journalTxt.Text += "" + replaceTxt;
            }
            hasChanges = true;
        }

        private void chddTxt0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newValue = chddTxt.Text;
            if (!string.IsNullOrEmpty(newValue))
            {
                string oldJournal = journalTxt.Text;
                journalTxt.Text = CommonUtils.ReplaceJournalIntParameter(oldJournal, "ЧД", newValue);
            }
            hasChanges = true;
        }

        private void adText0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newValue = adTxt.Text;
            if (!string.IsNullOrEmpty(newValue))
            {
                string oldJournal = journalTxt.Text;
                journalTxt.Text = CommonUtils.ReplaceJournalIntParameter(oldJournal, "АД", newValue);
            }
            hasChanges = true;
        }

        private void chssText0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newValue = chssTxt.Text;
            if (!string.IsNullOrEmpty(newValue))
            {
                string oldJournal = journalTxt.Text;
                journalTxt.Text = CommonUtils.ReplaceJournalIntParameter(oldJournal, "ЧСС", newValue);
            }
            hasChanges = true;
        }

        private void shuffleBtn_Click(object sender, EventArgs e)
        {
            if (pulseSelector == null)
            {
                pulseSelector = new PulseTableCOntainer(RefreshPulseInfo);
            }
            Control control = (Control)sender;
            MouseEventArgs margs = (MouseEventArgs)e;
            pulseSelector.Show(control.PointToScreen(margs.Location));
        }

        private void RefreshPulseInfo(Range adRange, Range chsRange)
        {
            int nextAdValue = JournalShuffleUtils.shuffleNextValue(adRange.Start, adRange.End);
            if (nextAdValue < 40) nextAdValue = 40;
            if (nextAdValue > 150) nextAdValue = 150;
            nextAdValue = (int)Math.Round((double)nextAdValue / 10) * 10;
            adTxt.SelectedIndex = adTxt.FindString(nextAdValue + "/");
            int chssNextValue = JournalShuffleUtils.shuffleNextValue(chsRange.Start, chsRange.End);
            chssTxt.SelectedIndex = chssTxt.FindString(chssNextValue + "");
            hasChanges = true;
        }


        #endregion

        private void remove_Click(object sender, EventArgs e)
        {
            container?.RemoveControl(this, DdtJournal.NAME);
        }
    }
}
