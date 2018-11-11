using Cardiology.Controls;
using Cardiology.Model;
using Cardiology.Model.Dictionary;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class JournalBeforeKag : Form, IAutoSaveForm
    {
        private int journalType;
        private List<string> journalIds;
        private DdtHospital hospitalitySession;

        public JournalBeforeKag(DdtHospital hospitalitySession, List<string> journalIds, int journalType)
        {
            this.hospitalitySession = hospitalitySession;
            this.journalIds = journalIds == null ? new List<string>() : journalIds;
            this.journalType = journalType;
            InitializeComponent();
            initJournals();
            initControlVisibility();
            SilentSaver.setForm(this);
        }



        private void initControlVisibility()
        {
            bool isWithKag = (int)DdtJournalDsiType.BEFORE_KAG == journalType || (int)DdtJournalDsiType.PENDING_JUSTIFICATION == journalType;
            deffedredAllPnl.Visible = isWithKag;
            addDefferedBtn.Visible = isWithKag;
            if (!isWithKag)
            {
                journalAllPnl.Text = "Журнал";
                journalAllPnl.Size = new System.Drawing.Size(940, 580);
                journalGrouppedPanel.Size = new System.Drawing.Size(940, 548);
            }
        }

        private void initRangedItems(ComboBox c, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                c.Items.Add(i);
            }
        }

        private void initJournals()
        {
            if (journalIds == null)
            {
                return;
            }

            DataService service = new DataService();
            DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, hospitalitySession.DsidPatient);
            if (patient != null)
            {
                Text += " " + patient.DssInitials;
            }
            DdtJournal journal = null;
            for (int i = 0; i < journalIds.Count; i++)
            {
                journal = service.queryObject<DdtJournal>("Select * FROM ddt_journal WHERE r_object_id ='" + journalIds[i] + "'");
                if (journal != null)
                {
                    journalType = journal.DsiJournalType;
                    if ((int)DdtJournalDsiType.BEFORE_KAG == journalType || (int)DdtJournalDsiType.WITHOUT_KAG == journalType)
                    {
                        journalContainer.Controls.Add(new JournalNoKAGControl(journal.RObjectId, journalType));
                    }
                    else if ((int)DdtJournalDsiType.PENDING_JUSTIFICATION == journalType)
                    {
                        deferredContainer.Controls.Add(new DefferedJournalControl(journal.RObjectId));
                    }
                }
            }
        }



        private void addJournalBtn_Click(object sender, EventArgs e)
        {
            JournalNoKAGControl nextJournal = new JournalNoKAGControl(null, journalType);
            if (journalContainer.Controls.Count > 0)
            {
                JournalNoKAGControl lastJournal = (JournalNoKAGControl)journalContainer.Controls[journalContainer.Controls.Count - 1];
                nextJournal.initTime(lastJournal.getJournalDateTime().AddHours(4));
                nextJournal.initDocName(lastJournal.getDocName());
                nextJournal.initRhytm(lastJournal.isGoodRhytm());
            }
            journalContainer.Controls.Add(nextJournal);
        }

        private void addDefferedBtn_Click(object sender, EventArgs e)
        {
            DefferedJournalControl newCtrl = new DefferedJournalControl(null);
            if (deferredContainer.Controls.Count > 0)
            {
                DefferedJournalControl oldCtrl = (DefferedJournalControl)deferredContainer.Controls[deferredContainer.Controls.Count - 1];
                newCtrl.initDoc(oldCtrl.getDoctorName());
                newCtrl.initRhytm(oldCtrl.isGoodRhytm());
                newCtrl.initTime(oldCtrl.getTime().AddHours(4));
            }
            deferredContainer.Controls.Add(newCtrl);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                save();
                Close();
            }
        }

        private bool validate()
        {
            bool isValid = true;
            foreach (Control c in journalContainer.Controls)
            {
                IDocbaseControl docbaseControl = (IDocbaseControl)c;
                isValid |= !docbaseControl.getIsValid();
            }

            foreach (Control c in deferredContainer.Controls)
            {
                IDocbaseControl docbaseControl = (IDocbaseControl)c;
                isValid |= !docbaseControl.getIsValid();
            }
            return isValid;
        }

        public void save()
        {
            journalIds.Clear();
            foreach (Control c in journalContainer.Controls)
            {
                IDocbaseControl docbaseControl = (IDocbaseControl)c;
                docbaseControl.saveObject(hospitalitySession, null, null);
                journalIds.Add(docbaseControl.getObjectId());
            }

            foreach (Control c in deferredContainer.Controls)
            {
                IDocbaseControl docbaseControl = (IDocbaseControl)c;
                docbaseControl.saveObject(hospitalitySession, null, null);
                journalIds.Add(docbaseControl.getObjectId());
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                save();
                DataService service = new DataService();
                List<string> paths = new List<string>();
                ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtJournal.TABLE_NAME);
                foreach (string id in journalIds)
                {
                    DdtJournal journal = service.queryObjectById<DdtJournal>(DdtJournal.TABLE_NAME, id);
                    if (journal != null)
                    {
                        string path = processor.processTemplate(hospitalitySession.ObjectId, journal.RObjectId, null);
                        paths.Add(path);
                    }
                }
                string result = TemplatesUtils.mergeFiles(paths.ToArray(), false);
                TemplatesUtils.showDocument(result);
            }
        }

        private void JournalBeforeKag_FormClosing(object sender, FormClosingEventArgs e)
        {
            SilentSaver.clearForm();
        }
    }
}
