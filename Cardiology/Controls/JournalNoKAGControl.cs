using System;
using System.Windows.Forms;
using Cardiology.Model;
using Cardiology.Model.Dictionary;
using Cardiology.Utils;

namespace Cardiology.Controls
{
    public partial class JournalNoKAGControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private int journalType;

        public JournalNoKAGControl(string objectId, int journalType)
        {
            this.objectId = objectId;
            this.journalType = journalType;
            InitializeComponent();
            initControls();
        }

        internal bool isVisible()
        {
            return !hideJournalBtn.Checked;
        }

        internal void initTime(DateTime time)
        {
            startDateTxt.Value = time;
            startTimeTxt.Value = time;
        }

        internal DateTime getJournalDateTime()
        {
            return CommonUtils.constructDateWIthTime(startDateTxt.Value, startTimeTxt.Value);
        }

        private void initControls()
        {
            CommonUtils.initRangedItems(chssTxt, 40, 200);
            CommonUtils.initRangedItems(psTxt, 40, 200);
            CommonUtils.initRangedItems(chddTxt, 14, 26);

            initControlVisibility();

            DataService service = new DataService();
            CommonUtils.initDoctorsComboboxValues(service, docBox, null);

            DdtJournal journal = service.queryObjectById<DdtJournal>(DdtJournal.TABLE_NAME, objectId);
            if (journal != null)
            {
                complaintsTxt.Text = journal.DssComplaints;
                adTxt.Text = journal.DssAd;
                psTxt.Text = journal.DssPs;
                chddTxt.Text = journal.DssChdd;
                chssTxt.Text = journal.DssChss;
                monitorTxt.Text = journal.DssMonitor;
                journalTxt.Text = journal.DssJournal;

                startDateTxt.Value = journal.DsdtAdmissionDate;
                startTimeTxt.Value = journal.DsdtAdmissionDate;

                goodRhytmBtn.Checked = journal.DsbGoodRhytm;
                badRhytmBtn.Checked = !journal.DsbGoodRhytm;

                DdtDoctors doc = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, journal.DsidDoctor);
                docBox.SelectedIndex = docBox.FindStringExact(doc.DssInitials);
            } else
            {
                journalTxt.Text = JournalShuffleUtils.shuffleJournalText();
                adTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(adTxt.Items.Count-1);
                chddTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(chddTxt.Items.Count-1);
                chssTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(chssTxt.Items.Count-1);
            }
        }

        private void initControlVisibility()
        {
            bool isWithKag = (int)DdtJournalDsiType.BEFORE_KAG == journalType;
            goodRhytmBtn.Visible = isWithKag;
            badRhytmBtn.Visible = isWithKag;
            complaintsTxt.Visible = !isWithKag;
            complaintsLbl.Visible = !isWithKag;
            addDayCb.Visible = isWithKag;
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            DataService service = new DataService();

            if (CommonUtils.isBlank(journalTxt.Text))
            {
                return;
            }

            DdtJournal journal = service.queryObjectById<DdtJournal>(DdtJournal.TABLE_NAME, objectId);
            if (journal == null)
            {
                journal = new DdtJournal();
                journal.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                journal.DsidHospitalitySession = hospitalitySession.ObjectId;
                journal.DsidPatient = hospitalitySession.DsidPatient;
                journal.DsiJournalType = journalType;
            }

            journal.DssAd = adTxt.Text;
            journal.DssChdd = chddTxt.Text;
            journal.DssChss = chssTxt.Text;
            journal.DssComplaints = complaintsTxt.Text;
            journal.DssJournal = journalTxt.Text;
            journal.DssMonitor = monitorTxt.Text;
            journal.DssPs = psTxt.Text;
            journal.DsbGoodRhytm = goodRhytmBtn.Checked;
            journal.DsdtAdmissionDate = CommonUtils.constructDateWIthTime(startDateTxt.Value, startTimeTxt.Value);

            DdtDoctors selectedDoc = (DdtDoctors)docBox.SelectedItem;
            if (selectedDoc != null)
            {
                journal.DsidDoctor = selectedDoc.ObjectId;
            }

            objectId = service.updateOrCreateIfNeedObject<DdtJournal>(journal, DdtJournal.TABLE_NAME, journal.RObjectId);
        }

        private void hideJournalBtn_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            visibledPanel.Visible = !cb.Checked;
            //this.OnResize(null);
            journalPnl.Size = cb.Checked ? new System.Drawing.Size(900, 40) : new System.Drawing.Size(900, 180);
            cb.Location = cb.Checked ? new System.Drawing.Point(332, 19) : new System.Drawing.Point(332, 158);
        }

        public string getObjectId()
        {
            return objectId;
        }
    }
}
