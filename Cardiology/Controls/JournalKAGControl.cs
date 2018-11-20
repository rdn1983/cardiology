using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cardiology.Utils;
using Cardiology.Model;

namespace Cardiology.Controls
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

        public JournalKAGControl(string objId, bool isRelease)
        {
            this.objId = objId;
            this.isReleaseJournal = isRelease;
            InitializeComponent();
            initControl();
            hasChanges = false;
            isNew = CommonUtils.isBlank(objId);
        }

        private void initControl()
        {
            CommonUtils.initRangedItems(chssTxt, 0, 230);
            CommonUtils.initRangedItems(chddTxt, 14, 26);

            DataService service = new DataService();
            DdtVariousSpecConcluson obj = service.queryObjectById<DdtVariousSpecConcluson>(DdtVariousSpecConcluson.TABLE_NAME, objId);
            refreshObject(obj);
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtVariousSpecConcluson)
            {
                DdtVariousSpecConcluson journal = (DdtVariousSpecConcluson)obj;
                initDateTime(journal.DsdtAdmissionDate);
                journalTxt.Text = journal.DssSpecialistConclusion;
                chddTxt.Text = journal.DssAdditionalInfo1;
                adTxt.Text = journal.DssAdditionalInfo3;
                chssTxt.Text = journal.DssAdditionalInfo2;
                goodRhytmBtn0.Checked = "синусовый ритм".Equals(journal.DssAdditionalInfo4);
                badRhytmBtn0.Checked = !"синусовый ритм".Equals(journal.DssAdditionalInfo4);
                monitorTxt0.Text = journal.DssAdditionalInfo4;
                objId = journal.RObjectId;
                isNew = CommonUtils.isBlank(objId);
                hasChanges = false;
                isReleaseJournal = journal.DsbAdditionalBool;
            } else
            {
                string journalText = string.Intern(JournalShuffleUtils.shuffleJournalText());
                if (isReleaseJournal)
                {
                    journalText = RELEASE_JOURNAL_PREFIX + journalText + RELEASE_JOURNAL_POSTFIX;
                }
                journalTxt.Text = journalText;
                chddTxt.SelectedIndex = chddTxt.FindString("14");
                adTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(adTxt.Items.Count - 1);
                chssTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(chssTxt.Items.Count - 1);
            }
        }

        public object getObject()
        {
            DataService service = new DataService();
            DdtVariousSpecConcluson result = service.queryObjectById<DdtVariousSpecConcluson>(DdtVariousSpecConcluson.TABLE_NAME, objId);
            if (result == null)
            {
                result = new DdtVariousSpecConcluson();
            }
            result.RObjectId = objId;
            result.DsdtAdmissionDate = CommonUtils.constructDateWIthTime(inspectionDate0.Value, inspectionTime0.Value);
            result.DssSpecialistConclusion = journalTxt.Text;
            result.DssAdditionalInfo1 = chddTxt.Text;
            result.DssAdditionalInfo2 = chssTxt.Text;
            result.DssAdditionalInfo3 = adTxt.Text;
            result.DssAdditionalInfo4 = monitorTxt0.Text;
            result.DsbAdditionalBool = isReleaseJournal;
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
            DdtVariousSpecConcluson conclusion = (DdtVariousSpecConcluson)getObject();
            conclusion.DssParentType = parentType;
            conclusion.DsidParent = parentId;
            conclusion.DssSpecialistType = "Дежурный кардиореаниматолог";
            conclusion.DsbAdditionalBool = isReleaseJournal;
            DataService service = new DataService();
            objId = service.updateOrCreateIfNeedObject<DdtVariousSpecConcluson>(conclusion, DdtVariousSpecConcluson.TABLE_NAME, conclusion.RObjectId);
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

        private void shuffleBtn_Click(object sender, EventArgs e)
        {
            if (pulseSelector == null)
            {
                pulseSelector = new PulseTableCOntainer(RefreshPulseInfo);
            }
            pulseSelector.Show();
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
        }

        #endregion


    }
}
