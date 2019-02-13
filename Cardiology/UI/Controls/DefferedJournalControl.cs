using System;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class DefferedJournalControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private bool hasChanges;
        private bool isNew;

        public DefferedJournalControl(string objectId)
        {
            this.objectId = objectId;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        public bool isVisible()
        {
            return !hideDefferedCb.Checked;
        }

        internal void initTime(DateTime time)
        {
            deferredStartTime.Value = time;
            deferredStartDate.Value = time;
        }

        private void initControls()
        {
            CommonUtils.InitRangedItems(deferredChssTxt, 40, 200);
            CommonUtils.InitRangedItems(defferedChddTxt, 14, 26);
            warningLbl.Visible = false;

            DataService service = new DataService();
            CommonUtils.InitDoctorsComboboxValues(service, docBox, null);
            DdtJournal journal = service.queryObjectById<DdtJournal>(objectId);
            refreshObject(journal);
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            if (string.IsNullOrEmpty(deferredJournalTxt.Text) || !(hasChanges || isNew))
            {
                return;
            }

            DataService service = new DataService();
            DdtJournal journal = (DdtJournal)getObject();
            journal.DsidHospitalitySession = hospitalitySession.ObjectId;
            journal.DsidPatient = hospitalitySession.DsidPatient;
            journal.DsidDoctor = string.IsNullOrEmpty(journal.DsidDoctor) ? hospitalitySession.DsidCuringDoctor : journal.DsidDoctor;
           
            objectId = service.updateOrCreateIfNeedObject<DdtJournal>(journal, DdtJournal.TABLE_NAME, journal.RObjectId);
            hasChanges = false;
            isNew = false;
        }

        public string getObjectId()
        {
            return objectId;
        }

        public DateTime getTime()
        {
            return CommonUtils.ConstructDateWIthTime(deferredStartDate.Value, deferredStartTime.Value);
        }

        private void badRhytmBtn_CheckedChanged(object sender, EventArgs e)
        {
            deferredMonitorTxt.Text = badRhytmBtn.Checked ? "синусовый ритм" : "трепетание предсердий";
            hasChanges = true;
        }

        public bool isGoodRhytm()
        {
            return badRhytmBtn.Checked;
        }

        public void initRhytm(bool goodRhytm)
        {
            badRhytmBtn.Checked = goodRhytm;
            goodRhytmBtn.Checked = !goodRhytm;
            badRhytmBtn_CheckedChanged(null, null);
        }

        public string getDoctorName()
        {
            return docBox.Text;
        }

        public void initDoc(string docName)
        {
            docBox.SelectedIndex = docBox.FindStringExact(docName);
        }

        private void defferedChddTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newValue = defferedChddTxt.Text;
            if (!string.IsNullOrEmpty(newValue))
            {
                string oldJournal = deferredJournalTxt.Text;
                deferredJournalTxt.Text = CommonUtils.ReplaceJournalIntParameter(oldJournal, "ЧД", newValue);
                hasChanges = true;
            }
        }

        private void deferredChssTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newValue = deferredChssTxt.Text;
            if (!string.IsNullOrEmpty(newValue))
            {
                string oldJournal = deferredJournalTxt.Text;
                deferredJournalTxt.Text = CommonUtils.ReplaceJournalIntParameter(oldJournal, "ЧСС", newValue);
                hasChanges = true;
            }
        }

        private void deferredAdTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newValue = deferredAdTxt.Text;
            if (!string.IsNullOrEmpty(newValue))
            {
                string oldJournal = deferredJournalTxt.Text;
                deferredJournalTxt.Text = CommonUtils.ReplaceJournalIntParameter(oldJournal, "АД", newValue);
                hasChanges = true;
            }
        }

        private void hideDefferedCb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            visibledPnl.Visible = !cb.Checked;
            Size = cb.Checked ? new System.Drawing.Size(800, 40) : new System.Drawing.Size(800, 176);
            cb.Location = cb.Checked ? new System.Drawing.Point(285, 20) : new System.Drawing.Point(285, 156);
        }

        public bool getIsValid()
        {
            bool result = deferredChssTxt.SelectedIndex >= 0 && defferedChddTxt.SelectedIndex >= 0 && deferredAdTxt.SelectedIndex >= 0;
            warningLbl.Visible = !result;
            return result;
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {
            DataService service = new DataService();
            DdtJournal journal = service.queryObjectById<DdtJournal>(objectId);
            if (journal == null)
            {
                journal = new DdtJournal();
                journal.DsiJournalType = (int)DdtJournalDsiType.PENDING_JUSTIFICATION;
            }

            journal.DssAd = deferredAdTxt.Text;
            journal.DssChdd = defferedChddTxt.Text;
            journal.DssChss = deferredChssTxt.Text;
            journal.DssJournal = deferredJournalTxt.Text;
            journal.DssMonitor = deferredMonitorTxt.Text;
            journal.DsdtAdmissionDate = CommonUtils.ConstructDateWIthTime(deferredStartDate.Value, deferredStartTime.Value);

            DdtDoctors selectedDoc = (DdtDoctors)docBox.SelectedItem;
            if (selectedDoc != null)
            {
                journal.DsidDoctor = selectedDoc.ObjectId;
            }

            return journal;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtJournal)
            {
                DdtJournal journal = (DdtJournal)obj;
                DataService service = new DataService();
                deferredJournalTxt.Text = journal.DssJournal;
                deferredAdTxt.Text = journal.DssAd;
                defferedChddTxt.Text = journal.DssChdd;
                deferredChssTxt.Text = journal.DssChss;
                deferredMonitorTxt.Text = journal.DssMonitor;

                deferredStartDate.Value = journal.DsdtAdmissionDate;
                deferredStartTime.Value = journal.DsdtAdmissionDate;

                DdtDoctors doc = service.queryObjectById<DdtDoctors>(journal.DsidDoctor);
                docBox.SelectedIndex = docBox.FindStringExact(doc.DssInitials);
                objectId = journal.RObjectId;
                isNew = string.IsNullOrEmpty(objectId);
                hasChanges = false;
            }
            else
            {
                deferredJournalTxt.Text = JournalShuffleUtils.shuffleJournalText();
                deferredChssTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(deferredChssTxt.Items.Count - 1);
                deferredAdTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(deferredAdTxt.Items.Count - 1);
                defferedChddTxt.SelectedIndex = defferedChddTxt.FindString("14");
            }
        }

        private void deferredJournalTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            hasChanges = true;
        }

        private void deferredStartTime_ValueChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }
    }
}
