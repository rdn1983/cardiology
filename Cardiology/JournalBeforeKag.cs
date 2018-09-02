using Cardiology.Controls;
using Cardiology.Model;
using Cardiology.Model.Dictionary;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class JournalBeforeKag : Form
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
            journalContainer.Controls.Add(new JournalNoKAGControl(null, journalType));
        }

        private void addDefferedBtn_Click(object sender, EventArgs e)
        {
            deferredContainer.Controls.Add(new DefferedJournalControl(null));
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            save();
            Close();
        }

        private void save()
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
}
