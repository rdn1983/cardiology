using Cardiology.Model;
using Cardiology.Model.Dictionary;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class JournalAfterKAG : Form
    {
        private DdtHospital hospitalitySession;
        private string journalId;

        public JournalAfterKAG(DdtHospital hospitalitySession, string journalId)
        {
            this.hospitalitySession = hospitalitySession;
            this.journalId = journalId;
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            afterKagDiagnosisTxt.Text = hospitalitySession.DssDiagnosis;
            DataService service = new DataService();
            if (CommonUtils.isNotBlank(journalId))
            {
                DdtJournal journal = service.queryObjectById<DdtJournal>(DdtJournal.TABLE_NAME, journalId);
                if (journal != null)
                {
                    surgeryInspectationTxt.Text = journal.DssSurgeonExam;
                    List<DdtVariousSpecConcluson> cardioConclusions = service.queryObjectsCollectionByAttrCond<DdtVariousSpecConcluson>
                        (DdtVariousSpecConcluson.TABLE_NAME, "dsid_parent", journal.RObjectId, true);
                    for (int i = 0; i < cardioConclusions.Count; i++)
                    {
                        if (dutyCardioContainer.Controls.Count <= i)
                        {
                            dutyCardioContainer.Controls.Add(CommonUtils.copyControl(inspectionPnl0, dutyCardioContainer.Controls.Count));
                        }
                        Control c = CommonUtils.findControl(dutyCardioContainer, "inspectionTxt" + i);
                        c.Text = cardioConclusions[i].DssSpecialistConclusion;
                        c = CommonUtils.findControl(dutyCardioContainer, "ekgTxt" + i);
                        c.Text = cardioConclusions[i].DssSpecialistConclusion;
                        c = CommonUtils.findControl(dutyCardioContainer, "objectIdLbl" + i);
                        c.Text = cardioConclusions[i].RObjectId;
                    }
                }

            }
        }

        private void addCardioInspetions_Click(object sender, EventArgs e)
        {
            dutyCardioContainer.Controls.Add(CommonUtils.copyControl(inspectionPnl0, dutyCardioContainer.Controls.Count));
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            hospitalitySession.DssDiagnosis = afterKagDiagnosisTxt.Text;
            service.updateObject<DdtHospital>(hospitalitySession, DdtHospital.TABLENAME, "r_object_id", hospitalitySession.ObjectId);

            DdtJournal journal = null;
            if (CommonUtils.isNotBlank(journalId))
            {
                journal = service.queryObjectById<DdtJournal>(DdtJournal.TABLE_NAME, journalId);
            }
            else
            {
                journal = new DdtJournal();
                journal.DsiJournalType = 1;
                journal.DsidDoctor = hospitalitySession.DsidDutyDoctor;
                journal.DsidHospitalitySession = hospitalitySession.ObjectId;
                journal.DsidPatient = hospitalitySession.DsidPatient;
                journal.DsiJournalType = (int) DdtJournalDsiType.AFTER_KAG;
            }
            journal.DssSurgeonExam = surgeryInspectationTxt.Text;
            journalId = service.updateOrCreateIfNeedObject<DdtJournal>(journal, DdtJournal.TABLE_NAME, journal.RObjectId);

            for (int i = 0; i < dutyCardioContainer.Controls.Count; i++)
            {
                DdtVariousSpecConcluson conclusion = null;
                Control c = CommonUtils.findControl(dutyCardioContainer, "objectIdLbl" + i);
                if (CommonUtils.isNotBlank(c.Text))
                {
                    conclusion = service.queryObjectById<DdtVariousSpecConcluson>(DdtVariousSpecConcluson.TABLE_NAME, c.Text);
                }
                else
                {
                    conclusion = new DdtVariousSpecConcluson();
                    conclusion.DssParentType = DdtJournal.TABLE_NAME;
                    conclusion.DsidParent = journalId;
                    conclusion.DssSpecialistType = "Дежурный кардиореаниматолог";
                }

                c = CommonUtils.findControl(dutyCardioContainer, "inspectionTxt" + i);
                conclusion.DssSpecialistConclusion = c.Text;
                c = CommonUtils.findControl(dutyCardioContainer, "ekgTxt" + i);
                conclusion.DssAdditionalInfo0 = c.Text;
                service.updateOrCreateIfNeedObject<DdtVariousSpecConcluson>(conclusion, DdtVariousSpecConcluson.TABLE_NAME, conclusion.RObjectId);
            }
            Close();
        }
    }
}
