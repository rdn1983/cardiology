using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;
using Cardiology.UI.Controls;

namespace Cardiology.UI.Forms
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
            SilentSaver.setForm(this);
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
            if (journalIds == null || journalIds.Count == 0)
            {
                return;
            }


            DdtPatient patient = service.queryObjectById<DdtPatient>(hospitalitySession.Patient);
            if (patient != null)
            {
                Text += " " + patient.ShortName;
            }

            List<DdtJournal> journals = service.queryObjectsCollection<DdtJournal>(@"Select * FROM ddt_journal WHERE r_object_id IN ('" +
                journalIds.Aggregate((a, b) => a + "','" + b) + "') ORDER BY dsdt_admission_date ASC");
            foreach (DdtJournal j in journals)
            {
                journalContainer.Controls.Add(new JournalNoKAGControl(j.ObjectId, j.DsiJournalType, null));
            }
        }

        private void addJournalBtn_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            journalCreationMenu.Show((Control)sender, mea.Location);
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

            return isValid;
        }

        public bool save()
        {
            journalIds.Clear();
            foreach (Control c in journalContainer.Controls)
            {
                CheckBox hide = c.Controls.Find("hideJournalBtn", true).FirstOrDefault() as CheckBox;
                if (!hide.Checked) {
                    IDocbaseControl docbaseControl = (IDocbaseControl)c;
                    docbaseControl.saveObject(hospitalitySession, null, null);
                    journalIds.Add(docbaseControl.getObjectId());
                }
            }

            return true;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                save();
    
                List<string> paths = new List<string>();
                ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtJournal.NAME);
                foreach (string id in journalIds)
                {
                    DdtJournal journal = service.queryObjectById<DdtJournal>(id);
                    if (journal != null)
                    {
                        string path = processor.processTemplate(hospitalitySession.ObjectId, journal.ObjectId, null);
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

        private void createJournalMenu_Click(object sender, EventArgs e)
        {
            JournalNoKAGControl nextJournal = new JournalNoKAGControl(null, (int)DdtJournalDsiType.BEFORE_KAG, hospitalitySession.DsidCuringDoctor);
            if (journalContainer.Controls.Count > 0)
            {
                JournalNoKAGControl lastJournal = (JournalNoKAGControl)journalContainer.Controls[journalContainer.Controls.Count - 1];
                nextJournal.initTime(lastJournal.getJournalDateTime().AddHours(4));
                nextJournal.initDocName(lastJournal.getDocName());
                nextJournal.initRhytm(lastJournal.isGoodRhytm());
            }
            journalContainer.Controls.Add(nextJournal);
        }

        private void createDefferedJournalMenu_Click(object sender, EventArgs e)
        {
            JournalNoKAGControl goodJournalBefore = new JournalNoKAGControl(null, (int)DdtJournalDsiType.BEFORE_KAG, hospitalitySession.DsidCuringDoctor);
            if (journalContainer.Controls.Count > 0)
            {
                JournalNoKAGControl lastJournal = (JournalNoKAGControl)journalContainer.Controls[journalContainer.Controls.Count - 1];
                goodJournalBefore.initTime(lastJournal.getJournalDateTime().AddHours(1));
                goodJournalBefore.initDocName(lastJournal.getDocName());
                goodJournalBefore.initRhytm(lastJournal.isGoodRhytm());

            }
            journalContainer.Controls.Add(goodJournalBefore);

            JournalNoKAGControl badJournal = new JournalNoKAGControl(null, (int)DdtJournalDsiType.PENDING_JUSTIFICATION, hospitalitySession.DsidCuringDoctor);
            badJournal.initTime(goodJournalBefore.getJournalDateTime().AddHours(1));
            badJournal.initDocName(goodJournalBefore.getDocName());
            badJournal.initRhytm(goodJournalBefore.isGoodRhytm());
            journalContainer.Controls.Add(badJournal);

            JournalNoKAGControl goodJournal = new JournalNoKAGControl(null, (int)DdtJournalDsiType.AFTER_PENDING, hospitalitySession.DsidCuringDoctor);
            goodJournal.initTime(badJournal.getJournalDateTime().AddMinutes(15));
            goodJournal.initDocName(badJournal.getDocName());
            goodJournal.initRhytm(badJournal.isGoodRhytm());
            journalContainer.Controls.Add(goodJournal);
        }


    }
}
