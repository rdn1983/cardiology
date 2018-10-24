using System;
using System.Windows.Forms;
using Cardiology.Model;
using Cardiology.Utils;
using Cardiology.Model.Dictionary;

namespace Cardiology.Controls
{
    public partial class DefferedJournalControl : UserControl, IDocbaseControl
    {
        private string objectId;

        public DefferedJournalControl(string objectId)
        {
            this.objectId = objectId;
            InitializeComponent();
            initControls();
        }

        internal bool isVisible()
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
            CommonUtils.initRangedItems(deferredChssTxt, 40, 200);
            CommonUtils.initRangedItems(deferredPsTxt, 40, 200);
            CommonUtils.initRangedItems(defferedChddTxt, 14, 26);

            DataService service = new DataService();
            CommonUtils.initDoctorsComboboxValues(service, docBox, null);

            DdtJournal journal = service.queryObjectById<DdtJournal>(DdtJournal.TABLE_NAME, objectId);
            if (journal != null)
            {
                deferredJournalTxt.Text = journal.DssJournal;
                deferredAdTxt.Text = journal.DssAd;
                deferredPsTxt.Text = journal.DssPs;
                defferedChddTxt.Text = journal.DssChdd;
                deferredChssTxt.Text = journal.DssChss;
                deferredMonitorTxt.Text = journal.DssMonitor;

                deferredStartDate.Value = journal.DsdtAdmissionDate;
                deferredStartTime.Value = journal.DsdtAdmissionDate;

                DdtDoctors doc = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, journal.DsidDoctor);
                docBox.SelectedIndex = docBox.FindStringExact(doc.DssInitials);
            } else
            {
                deferredJournalTxt.Text = JournalShuffleUtils.shuffleJournalText();
                deferredChssTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(deferredChssTxt.Items.Count-1);
                deferredAdTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(deferredAdTxt.Items.Count-1);
                defferedChddTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(defferedChddTxt.Items.Count-1);
            }
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {
            DataService service = new DataService();

            if (CommonUtils.isBlank(deferredJournalTxt.Text))
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
                journal.DsiJournalType = (int)DdtJournalDsiType.PENDING_JUSTIFICATION;
            }

            journal.DssAd = deferredAdTxt.Text;
            journal.DssChdd = defferedChddTxt.Text;
            journal.DssChss = deferredChssTxt.Text;
            journal.DssJournal = deferredJournalTxt.Text;
            journal.DssMonitor = deferredMonitorTxt.Text;
            journal.DssPs = deferredPsTxt.Text;
            journal.DsdtAdmissionDate = CommonUtils.constructDateWIthTime(deferredStartDate.Value, deferredStartTime.Value);

            DdtDoctors selectedDoc = (DdtDoctors) docBox.SelectedItem;
            if (selectedDoc != null)
            {
                journal.DsidDoctor = selectedDoc.ObjectId;
            }

            objectId = service.updateOrCreateIfNeedObject<DdtJournal>(journal, DdtJournal.TABLE_NAME, journal.RObjectId);
        }

        private void hideJournalBtn_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            visibledPnl.Visible = !cb.Checked;
            //this.OnResize(null);
            defferedPnl.Size = cb.Checked ? new System.Drawing.Size(900, 40) : new System.Drawing.Size(900, 180);
            cb.Location = cb.Checked ? new System.Drawing.Point(332, 19) : new System.Drawing.Point(332, 158);
        }

        public string getObjectId()
        {
            return objectId;
        }
    }
}
