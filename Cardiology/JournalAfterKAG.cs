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

            CommonUtils.initDoctorsComboboxValues(service, journalDocBox, "");
            CommonUtils.initDoctorsComboboxValues(service, releaseDocBox, "");

            if (CommonUtils.isNotBlank(journalId))
            {
                DdtJournal journal = service.queryObjectById<DdtJournal>(DdtJournal.TABLE_NAME, journalId);
                if (journal != null)
                {
                    surgeryInspectationTxt.Text = journal.DssJournal;
                    chssSurgeryTxt.Text = journal.DssChss;
                    chddSurgeryTxt.Text = journal.DssChdd;
                    adSurgeryTxt.Text = journal.DssAd;
                    surgeryPsTxt.Text = journal.DssPs;
                    admissionTimeTxt.Value = journal.DsdtAdmissionDate;
                    admissionDateTxt.Value = journal.DsdtAdmissionDate;
                    ekgTxt0.Text = journal.DssEkg;
                    afterKagDiagnosisTxt.Text = journal.DssDiagnosis;

                    DdtDoctors doctors = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, journal.DsidDoctor);
                    journalDocBox.SelectedIndex = journalDocBox.FindStringExact(doctors.DssInitials);
                    releaseDocBox.SelectedIndex = releaseDocBox.FindStringExact(doctors.DssInitials);

                    initCardioConslusions(service);
                }
            }
            else
            {
                admissionTimeTxt.Value = hospitalitySession.DsdtAdmissionDate.AddHours(1);
                DdtDoctors doctors = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, hospitalitySession.DsidCuringDoctor);
                journalDocBox.SelectedIndex = journalDocBox.FindStringExact(doctors.DssInitials);
            }

            DdtJournal releaseJournal = service.queryObject<DdtJournal>(@"Select * from ddt_journal where dsid_hospitality_session='" +
                        hospitalitySession.ObjectId + "' AND dsb_release_journal=true");
            if (releaseJournal!=null)
            {
                releaseInspectionTxt.Text = releaseJournal.DssJournal;
                releasePsTxt.Text = releaseJournal.DssPs;
                releaseChddTxt.Text = releaseJournal.DssChdd;
                releaseChssTxt.Text = releaseJournal.DssChss;
                releaseAdTxt.Text = releaseJournal.DssAd;
                releaseMonitorTxt.Text = releaseJournal.DssMonitor;
                releaseDate.Value = releaseJournal.DsdtAdmissionDate;
                releaseTime.Value = releaseJournal.DsdtAdmissionDate;

                DdtDoctors doctors = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, releaseJournal.DsidDoctor);
                releaseDocBox.SelectedIndex = releaseDocBox.FindStringExact(doctors.DssInitials);
            } else
            {
                DdtDoctors doctors = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, hospitalitySession.DsidCuringDoctor);
                releaseDocBox.SelectedIndex = releaseDocBox.FindStringExact(doctors.DssInitials);
            }
            
        }

        private void initCardioConslusions(DataService service)
        {
            List<DdtVariousSpecConcluson> cardioConclusions = service.queryObjectsCollection<DdtVariousSpecConcluson>
                        ("Select * from " + DdtVariousSpecConcluson.TABLE_NAME + " WHERE dsid_parent='" + journalId +
                        "' AND dsb_additional_bool=false order by dsdt_admission_date");
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
                c.Visible = true;
                DateTimePicker dateCtrl = (DateTimePicker)CommonUtils.findControl(dutyCardioContainer, "inspectionDate" + i);
                DateTimePicker timeCtrl = (DateTimePicker)CommonUtils.findControl(dutyCardioContainer, "inspectionTime" + i);
                dateCtrl.Value = cardioConclusions[i].DsdtAdmissionDate;
                timeCtrl.Value = cardioConclusions[i].DsdtAdmissionDate;
                CheckBox boolCtrl = (CheckBox)CommonUtils.findControl(dutyCardioContainer, "hideBtn" + i);
                boolCtrl.Checked = cardioConclusions[i].DsbVisible;
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
            save();
            Close();
        }

        private void save()
        {
            DataService service = new DataService();
            service.updateObject<DdtHospital>(hospitalitySession, DdtHospital.TABLENAME, "r_object_id", hospitalitySession.ObjectId);

            DdtJournal journal = null;
            if (CommonUtils.isNotBlank(journalId))
            {
                journal = service.queryObjectById<DdtJournal>(DdtJournal.TABLE_NAME, journalId);
            }
            else
            {
                hospitalitySession.DssDiagnosis = afterKagDiagnosisTxt.Text;
                journal = new DdtJournal();
                journal.DsiJournalType = 1;
                journal.DsidDoctor = hospitalitySession.DsidDutyDoctor;
                journal.DsidHospitalitySession = hospitalitySession.ObjectId;
                journal.DsidPatient = hospitalitySession.DsidPatient;
                journal.DsiJournalType = (int)DdtJournalDsiType.AFTER_KAG;
            }
            journal.DssDiagnosis = afterKagDiagnosisTxt.Text;
            journal.DssJournal = surgeryInspectationTxt.Text;
            journal.DsbGoodRhytm = goodRhytmBtn0.Checked;
            journal.DssChdd = chddSurgeryTxt.Text;
            journal.DssChss = chssSurgeryTxt.Text;
            journal.DssAd = adSurgeryTxt.Text;
            journal.DssPs = surgeryPsTxt.Text;
            journal.DssEkg = ekgTxt0.Text;
            journal.DsdtAdmissionDate = CommonUtils.constructDateWIthTime(admissionDateTxt.Value, admissionTimeTxt.Value);
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
                DateTimePicker dateCtrl = (DateTimePicker)CommonUtils.findControl(dutyCardioContainer, "inspectionDate" + i);
                DateTimePicker timeCtrl = (DateTimePicker)CommonUtils.findControl(dutyCardioContainer, "inspectionTime" + i);
                conclusion.DsdtAdmissionDate = CommonUtils.constructDateWIthTime(dateCtrl.Value, timeCtrl.Value);
                conclusion.DsbAdditionalBool = false;
                boolCtrl = null;
                c = null;

                service.updateOrCreateIfNeedObject<DdtVariousSpecConcluson>(conclusion, DdtVariousSpecConcluson.TABLE_NAME, conclusion.RObjectId);
            }

            DdtJournal releaseJournal = service.queryObject<DdtJournal>(@"Select * from ddt_journal where dsid_hospitality_session='" + hospitalitySession.ObjectId + "' AND dsb_release_journal=true");
            if (releaseJournal == null)
            {
                releaseJournal = new DdtJournal();
                releaseJournal.DsbReleaseJournal = true;
                releaseJournal.DsidPatient = hospitalitySession.DsidPatient;
                releaseJournal.DsidHospitalitySession = hospitalitySession.ObjectId;
            }

            DdtDoctors releaseDoc = (DdtDoctors)releaseDocBox.SelectedItem;
            releaseJournal.DsidDoctor = releaseDoc.ObjectId;
            releaseJournal.DssJournal = releaseInspectionTxt.Text;
            releaseJournal.DssPs = releasePsTxt.Text;
            releaseJournal.DssChdd = releaseChddTxt.Text;
            releaseJournal.DssChss = releaseChssTxt.Text;
            releaseJournal.DssAd = releaseAdTxt.Text;
            releaseJournal.DssMonitor = releaseMonitorTxt.Text;
            releaseJournal.DsdtAdmissionDate = CommonUtils.constructDateWIthTime(releaseDate.Value, releaseTime.Value);

            service.updateOrCreateIfNeedObject<DdtJournal>(releaseJournal, DdtJournal.TABLE_NAME, releaseJournal.RObjectId);

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

        private void printBtn_Click(object sender, EventArgs e)
        {
            save();
            DataService service = new DataService();
            DdtJournal journal = service.queryObjectById<DdtJournal>(DdtJournal.TABLE_NAME, journalId);
            List<string> paths = new List<string>();
            if (journal != null)
            {
                ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtJournal.TABLE_NAME);
                paths.Add(processor.processTemplate(hospitalitySession.ObjectId, journal.RObjectId, null));
            }
            DdtJournal releaseJournal = service.queryObject<DdtJournal>(@"Select * from ddt_journal where dsid_hospitality_session='" +
                        hospitalitySession.ObjectId + "' AND dsb_release_journal=true");
            if (releaseJournal != null)
            {
                ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtJournal.TABLE_NAME);
                paths.Add(processor.processTemplate(hospitalitySession.ObjectId, releaseJournal.RObjectId, null));
            }

            string result = TemplatesUtils.mergeFiles(paths.ToArray(), false);
            TemplatesUtils.showDocument(result);
        }
    }
}
