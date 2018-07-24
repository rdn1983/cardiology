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
            CommonUtils.initRangedItems(chssSurgeryTxt, 40, 200);
            CommonUtils.initRangedItems(chddSurgeryTxt, 14, 26);
            CommonUtils.initRangedItems(surgeryPsTxt, 40, 200);

            CommonUtils.initRangedItems(releaseChssTxt, 40, 200);
            CommonUtils.initRangedItems(releaseChddTxt, 14, 26);
            CommonUtils.initRangedItems(releasePsTxt, 40, 200);

            CommonUtils.initRangedItems(chssText0, 40, 200);
            CommonUtils.initRangedItems(chddTxt0, 14, 26);

            afterKagDiagnosisTxt.Text = hospitalitySession.DssDiagnosis;
            DataService service = new DataService();
            if (CommonUtils.isNotBlank(journalId))
            {
                DdtJournal journal = service.queryObjectById<DdtJournal>(DdtJournal.TABLE_NAME, journalId);
                if (journal != null)
                {
                    surgeryInspectationTxt.Text = journal.DssSurgeonExam;
                    chssSurgeryTxt.Text = journal.DssChss;
                    chddSurgeryTxt.Text = journal.DssChdd;
                    adSurgeryTxt.Text = journal.DssAd;
                    surgeryPsTxt.Text = journal.DssPs;
                    admissionDateTxt.Value = journal.DsdtAdmissionDate;
                    ekgTxt0.Text = journal.DssEkg;
                    List<DdtVariousSpecConcluson> cardioConclusions = service.queryObjectsCollection<DdtVariousSpecConcluson>
                        ("Select * from " + DdtVariousSpecConcluson.TABLE_NAME + " WHERE dsid_parent='" + journalId + "' AND dsb_additional_bool=false");
                    for (int i = 0; i < cardioConclusions.Count; i++)
                    {
                        if (dutyCardioContainer.Controls.Count <= i)
                        {
                            dutyCardioContainer.Controls.Add(CommonUtils.copyControl(inspectionPnl0, dutyCardioContainer.Controls.Count));
                        }
                        Control c = CommonUtils.findControl(dutyCardioContainer, "inspectionTxt" + i);
                        c.Text = cardioConclusions[i].DssSpecialistConclusion;
                        c = CommonUtils.findControl(dutyCardioContainer, "objectIdLbl" + i);
                        c.Text = cardioConclusions[i].RObjectId;
                        c = CommonUtils.findControl(dutyCardioContainer, "chddTxt" + i);
                        c.Text = cardioConclusions[i].DssAdditionalInfo1;
                        c = CommonUtils.findControl(dutyCardioContainer, "chssText" + i);
                        c.Text = cardioConclusions[i].DssAdditionalInfo2;
                        c = CommonUtils.findControl(dutyCardioContainer, "adText" + i);
                        c.Text = cardioConclusions[i].DssAdditionalInfo3;
                        c = CommonUtils.findControl(dutyCardioContainer, "monitorTxt" + i);
                        c.Text = cardioConclusions[i].DssAdditionalInfo4;
                        CheckBox boolCtrl = (CheckBox)CommonUtils.findControl(dutyCardioContainer, "hideBtn" + i);
                        boolCtrl.Checked = cardioConclusions[i].DsbVisible;
                    }

                    DdtVariousSpecConcluson releaseConclusion = service.queryObject<DdtVariousSpecConcluson>("Select * from " + DdtVariousSpecConcluson.TABLE_NAME +
                " WHERE dsid_parent='" + journalId + "' AND dsb_additional_bool=true");
                    releaseInspectionTxt.Text = releaseConclusion.DssSpecialistConclusion;
                    releasePsTxt.Text = releaseConclusion.DssAdditionalInfo0;
                    releaseChddTxt.Text = releaseConclusion.DssAdditionalInfo1;
                    releaseChssTxt.Text = releaseConclusion.DssAdditionalInfo2;
                    releaseAdTxt.Text = releaseConclusion.DssAdditionalInfo3;
                    releaseMonitorTxt.Text = releaseConclusion.DssAdditionalInfo4;

                }
            }
            else
            {
                admissionDateTxt.Value = hospitalitySession.DsdtAdmissionDate.AddHours(1);
            }
        }

        private void addCardioInspetions_Click(object sender, EventArgs e)
        {
            dutyCardioContainer.Controls.Add(CommonUtils.copyControl(inspectionPnl0, dutyCardioContainer.Controls.Count));
            int currentIndex = dutyCardioContainer.Controls.Count - 1;
            CheckBox cb = (CheckBox)CommonUtils.findControl(dutyCardioContainer, ("hideBtn" + currentIndex));
            cb.CheckedChanged += new System.EventHandler(this.hideBtn0_CheckedChanged);
            RadioButton good = (RadioButton)CommonUtils.findControl(dutyCardioContainer, ("goodRhytmBtn" + currentIndex));
            good.CheckedChanged += new System.EventHandler(this.goodRhytmBtn_CheckedChanged);
            RadioButton bad = (RadioButton)CommonUtils.findControl(dutyCardioContainer, ("badRhytmBtn" + currentIndex));
            bad.CheckedChanged += new System.EventHandler(this.goodRhytmBtn_CheckedChanged);
            DateTimePicker dtPick = (DateTimePicker)CommonUtils.findControl(dutyCardioContainer, ("inspectionTime" + currentIndex));
            dtPick.Value = (inspectionTime0.Value.AddHours(currentIndex));
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
                journal.DsiJournalType = (int)DdtJournalDsiType.AFTER_KAG;
            }
            journal.DssSurgeonExam = surgeryInspectationTxt.Text;
            journal.DsbGoodRhytm = goodRhytmBtn0.Checked;
            journal.DssChdd = chddSurgeryTxt.Text;
            journal.DssChss = chssSurgeryTxt.Text;
            journal.DssAd = adSurgeryTxt.Text;
            journal.DssPs = surgeryPsTxt.Text;
            journal.DssEkg = ekgTxt0.Text;
            journal.DsdtAdmissionDate = admissionDateTxt.Value;
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
                c = CommonUtils.findControl(dutyCardioContainer, "chddTxt" + i);
                conclusion.DssAdditionalInfo1 = c.Text;
                c = CommonUtils.findControl(dutyCardioContainer, "chssText" + i);
                conclusion.DssAdditionalInfo2 = c.Text;
                c = CommonUtils.findControl(dutyCardioContainer, "adText" + i);
                conclusion.DssAdditionalInfo3 = c.Text;
                c = CommonUtils.findControl(dutyCardioContainer, "monitorTxt" + i);
                conclusion.DssAdditionalInfo4 = c.Text;
                CheckBox boolCtrl = (CheckBox)CommonUtils.findControl(dutyCardioContainer, "hideBtn" + i);
                conclusion.DsbVisible = boolCtrl.Checked;
                conclusion.DsbAdditionalBool = false;
                boolCtrl = null;
                c = null;

                service.updateOrCreateIfNeedObject<DdtVariousSpecConcluson>(conclusion, DdtVariousSpecConcluson.TABLE_NAME, conclusion.RObjectId);
            }

            DdtVariousSpecConcluson releaseConclusion = service.queryObject<DdtVariousSpecConcluson>("Select * from " + DdtVariousSpecConcluson.TABLE_NAME +
                " WHERE dsid_parent='" + journalId + "' AND dsb_additional_bool=true");
            if (releaseConclusion == null)
            {
                releaseConclusion = new DdtVariousSpecConcluson();
                releaseConclusion.DssParentType = DdtJournal.TABLE_NAME;
                releaseConclusion.DsidParent = journalId;
                releaseConclusion.DssSpecialistType = "Дежурный кардиореаниматолог";

            }

            releaseConclusion.DssSpecialistConclusion = releaseInspectionTxt.Text;
            releaseConclusion.DssAdditionalInfo0 = releasePsTxt.Text;
            releaseConclusion.DssAdditionalInfo1 = releaseChddTxt.Text;
            releaseConclusion.DssAdditionalInfo2 = releaseChssTxt.Text;
            releaseConclusion.DssAdditionalInfo3 = releaseAdTxt.Text;
            releaseConclusion.DssAdditionalInfo4 = releaseMonitorTxt.Text;
            releaseConclusion.DsbVisible = false;
            releaseConclusion.DsbAdditionalBool = true;

            service.updateOrCreateIfNeedObject<DdtVariousSpecConcluson>(releaseConclusion, DdtVariousSpecConcluson.TABLE_NAME, releaseConclusion.RObjectId);


            Close();
        }

        private void goodRhytmBtn_CheckedChanged(object sender, EventArgs e)
        {
            string ctrlName = ((Control)sender).Name;
            string indxStr = String.Intern(ctrlName.Substring(CommonUtils.getFirstDigitIndex(ctrlName)));
            Control c = CommonUtils.findControl(dutyCardioContainer, "monitorTxt" + indxStr);
            RadioButton cb = (RadioButton)CommonUtils.findControl(dutyCardioContainer, "goodRhytmBtn" + indxStr);
            c.Text = cb.Checked ? "синусовый ритм" : "трепетание предсердий";
        }

        private void hideBtn0_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            string ctrlName = cb.Name;
            string indxStr = String.Intern(ctrlName.Substring(CommonUtils.getFirstDigitIndex(ctrlName)));
            Control c = CommonUtils.findControl(dutyCardioContainer, "hidingPnl" + indxStr);
            c.Visible = !cb.Checked;
        }
    }
}
