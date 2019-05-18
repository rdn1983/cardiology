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
        private readonly IDbDataService service;
        private DdtHospital hospitalitySession;
        private string journalDayId;

        public JournalBeforeKag(IDbDataService service, DdtHospital hospitalitySession, string journalId, int journalType)
        {
            InitializeComponent();
            this.service = service;
            this.hospitalitySession = hospitalitySession;
            this.journalDayId = journalId;
            initJournals();
            List<string> validTypes = new List<string>() { "ddt_blood_analysis", "ddt_ekg", "ddt_urine_analysis", "ddt_egds", "ddt_xray", "ddt_holter", "ddt_specialist_conclusion", "ddt_uzi" };
            analysisTabControl1.init(hospitalitySession, journalDayId, DdtJournalDay.NAME, validTypes);
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
            DdvPatient patient = service.GetDdvPatientService().GetById(hospitalitySession.Patient);
            if (patient != null)
            {
                Text += " " + patient.ShortName;
            }

            List<DdtJournal> journals = service.GetDdtJournalService().GetByJournalDayId(journalDayId);
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
            if (journalContainer.Controls.Count==0)
            {
                return true;
            }
            DdtJournalDay day = service.GetDdtJournalDayService().GetById(journalDayId);
            DateTime journalDate = ((JournalNoKAGControl)journalContainer.Controls[0]).getJournalDateTime();
            //Снчала поищем, нет ли дневников за тот же день?
            if (day == null)
            {
                day = service.GetDdtJournalDayService().GetForDate(hospitalitySession.ObjectId, journalDate);
                journalDayId = day?.ObjectId;
            }
            
            if (day == null)
            {
                day = new DdtJournalDay();
                day.Doctor = hospitalitySession.DutyDoctor;
                day.Patient = hospitalitySession.Patient;
                day.HospitalitySession = hospitalitySession.ObjectId;
                day.JournalType = (int)DdtJournalDsiType.BeforeKag;
                day.AdmissionDate = journalDate;
                day.Name = "Журнал до КАГ за " + journalDate.ToShortDateString();
                journalDayId = service.GetDdtJournalDayService().Save(day);
            }
            foreach (Control c in journalContainer.Controls)
            {
                CheckBox hide = c.Controls.Find("hideJournalBtn", true).FirstOrDefault() as CheckBox;
                if (!hide.Checked)
                {
                    IDocbaseControl docbaseControl = (IDocbaseControl)c;
                    docbaseControl.saveObject(hospitalitySession, journalDayId, DdtJournalDay.NAME);
                    docbaseControl.getObjectId();
                }
            }
            analysisTabControl1.save(journalDayId, DdtJournalDay.NAME);

            return true;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                Save();

                List<string> paths = new List<string>();
                ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtJournal.NAME);
                List<DdtJournal> journals = service.GetDdtJournalService().GetByJournalDayId(journalDayId);
                foreach (DdtJournal journal in journals)
                {
                    if (journal != null)
                    {
                        string path = processor.processTemplate(service, hospitalitySession.ObjectId, journal.ObjectId, null);
                        paths.Add(path);
                    }
                }
                DdvPatient patient = service.GetDdvPatientService().GetById(hospitalitySession.Patient);
                string resultName = TemplatesUtils.getTempFileName("Журнал", patient.FullName);
                string result = TemplatesUtils.MergeFiles(paths.ToArray(), false, resultName);
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

        private void toAnalysisTab_Click(object sender, EventArgs e)
        {
            int currentTabIndx = container.SelectedIndex;
            if (currentTabIndx < container.TabCount - 1)
            {
                container.SelectTab(++currentTabIndx);
            }
        }

        private void toJournalsBtn_Click(object sender, EventArgs e)
        {
            int currentTabIndx = container.SelectedIndex;
            if (currentTabIndx > 0)
            {
                container.SelectTab(--currentTabIndx);
            }
        }
    }
}
