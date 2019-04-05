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
        private readonly IDbDataService service;
        private DdtHospital hospitalitySession;

        public JournalBeforeKag(IDbDataService service, DdtHospital hospitalitySession, List<string> journalIds, int journalType)
        {
            this.service = service;
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


            DdvPatient patient = service.GetDdvPatientService().GetById(hospitalitySession.Patient);
            if (patient != null)
            {
                Text += " " + patient.ShortName;
            }

            List<DdtJournal> journals = service.GetDdtJournalService().GetByQuery(@"Select r_object_id, dss_diagnosis, dss_chss, dss_chdd, r_creation_date, "+
                "dss_complaints, dss_surgeon_exam, dss_ekg, dsdt_admission_date, dss_monitor, dss_rhythm, dsid_doctor, dsid_patient, dss_ps, dss_ad,"+
                " dsid_hospitality_session, r_modify_date, dss_cardio_exam, dsi_journal_type, dsb_good_rhythm, dsb_release_journal, dss_journal "+
                "FROM ddt_journal WHERE r_object_id IN ('" +
                journalIds.Aggregate((a, b) => a + "','" + b) + "') ORDER BY dsdt_admission_date ASC");
            foreach (DdtJournal j in journals)
            {
                journalContainer.Controls.Add(new JournalNoKAGControl(j.ObjectId, j.JournalType, null));
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
                Save();
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

        public bool Save()
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
                Save();
    
                List<string> paths = new List<string>();
                ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtJournal.NAME);
                foreach (string id in journalIds)
                {
                    DdtJournal journal = service.GetDdtJournalService().GetById(id);
                    if (journal != null)
                    {
                        string path = processor.processTemplate(service, hospitalitySession.ObjectId, journal.ObjectId, null);
                        paths.Add(path);
                    }
                }
                string result = TemplatesUtils.MergeFiles(paths.ToArray(), false);
                TemplatesUtils.ShowDocument(result);
            }
        }

        private void JournalBeforeKag_FormClosing(object sender, FormClosingEventArgs e)
        {
            SilentSaver.clearForm();
        }

        private void createJournalMenu_Click(object sender, EventArgs e)
        {
            JournalNoKAGControl nextJournal = new JournalNoKAGControl(null, (int)DdtJournalDsiType.BeforeKag, hospitalitySession.CuringDoctor);
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
            JournalNoKAGControl goodJournalBefore = new JournalNoKAGControl(null, (int)DdtJournalDsiType.BeforeKag, hospitalitySession.CuringDoctor);
            if (journalContainer.Controls.Count > 0)
            {
                JournalNoKAGControl lastJournal = (JournalNoKAGControl)journalContainer.Controls[journalContainer.Controls.Count - 1];
                goodJournalBefore.initTime(lastJournal.getJournalDateTime().AddHours(1));
                goodJournalBefore.initDocName(lastJournal.getDocName());
                goodJournalBefore.initRhytm(lastJournal.isGoodRhytm());

            }
            journalContainer.Controls.Add(goodJournalBefore);

            JournalNoKAGControl badJournal = new JournalNoKAGControl(null, (int)DdtJournalDsiType.PendingJustification, hospitalitySession.CuringDoctor);
            badJournal.initTime(goodJournalBefore.getJournalDateTime().AddHours(1));
            badJournal.initDocName(goodJournalBefore.getDocName());
            badJournal.initRhytm(goodJournalBefore.isGoodRhytm());
            journalContainer.Controls.Add(badJournal);

            JournalNoKAGControl goodJournal = new JournalNoKAGControl(null, (int)DdtJournalDsiType.AfterPending, hospitalitySession.CuringDoctor);
            goodJournal.initTime(badJournal.getJournalDateTime().AddMinutes(15));
            goodJournal.initDocName(badJournal.getDocName());
            goodJournal.initRhytm(badJournal.isGoodRhytm());
            journalContainer.Controls.Add(goodJournal);
        }


    }
}
