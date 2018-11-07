using Cardiology.Controls;
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
        private AnalysisSelector selector;
        private string journalId;
        private string kagId;

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

            afterKagDiagnosisTxt.Text = hospitalitySession.DssDiagnosis;
            DataService service = new DataService();

            CommonUtils.initDoctorsComboboxValues(service, journalDocBox, "");
            releaseJournalCtrl.initDateTime(CommonUtils.constructDateWIthTime(admissionDateTxt.Value, DateTime.Parse("8:05:00")));

            DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, hospitalitySession.DsidPatient);
            if (patient != null)
            {
                Text += " " + patient.DssInitials;
            }

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

                    DdtKag kag = service.queryObjectByAttrCond<DdtKag>(DdtKag.TABLE_NAME, "dsid_parent", journal.RObjectId, true);
                    if (kag != null)
                    {
                        kagDiagnosisTxt.Text = kag.DssKagAction;
                    }

                    initCardioConslusions(service);
                }
            }
            else
            {
                //Для нового дневника ставим время через 1 час после приема. если есть КАГ, то через 15 мин после КАГ
                admissionDateTxt.Value = hospitalitySession.DsdtAdmissionDate.AddHours(1);
                admissionTimeTxt.Value = hospitalitySession.DsdtAdmissionDate.AddHours(1);
                DdtKag kag = service.queryObject<DdtKag>(@"SELECT * FROM ddt_kag WHERE dsid_hospitality_session='" + hospitalitySession.ObjectId + "' ORDER BY dsdt_analysis_date DESC");
                initKag(kag);

                DdtDoctors doctors = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, hospitalitySession.DsidCuringDoctor);
                journalDocBox.SelectedIndex = journalDocBox.FindStringExact(doctors.DssInitials);
            }
        }

        private void initKag(DdtKag kag)
        {
            if (kag != null)
            {
                kagDiagnosisTxt.Text = kag.DssKagAction;
                DateTime kagEndTime = kag.DsdtEndTime == default(DateTime) ? DateTime.Now : kag.DsdtEndTime;
                admissionDateTxt.Value = kagEndTime.AddMinutes(15);
                admissionTimeTxt.Value = kagEndTime.AddMinutes(15);
                kagId = kag.ObjectId;
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
                    JournalKAGControl control = new JournalKAGControl();
                    control.Anchor = AnchorStyles.Right;
                    control.initObject(cardioConclusions[i]);
                    dutyCardioContainer.Controls.Add(control);
                }
            }

            DdtVariousSpecConcluson releaseConclusion = service.queryObject<DdtVariousSpecConcluson>("Select * from " + DdtVariousSpecConcluson.TABLE_NAME +
                " WHERE dsid_parent='" + journalId + "' AND dsb_additional_bool=true");
            if (releaseConclusion != null)
            {
                releaseJournalCtrl.initObject(releaseConclusion);
            } 
        }

        private void addCardioInspetions_Click(object sender, EventArgs e)
        {
            JournalKAGControl control = new JournalKAGControl();
            int indx = dutyCardioContainer.Controls.Count - 1;
            DateTime lastDate = DateTime.Now;
            if (indx >= 0)
            {
                JournalKAGControl last = (JournalKAGControl)dutyCardioContainer.Controls[indx];
                lastDate = last.getDateTime();
                control.initRhytm(last.isGoodRhytm());
            }
            control.Anchor = AnchorStyles.Right;
            control.initDateTime(lastDate.AddHours(1));
            dutyCardioContainer.Controls.Add(control);
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
                journal = new DdtJournal();
                journal.DsiJournalType = 1;
                journal.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                journal.DsidHospitalitySession = hospitalitySession.ObjectId;
                journal.DsidPatient = hospitalitySession.DsidPatient;
                journal.DsiJournalType = (int)DdtJournalDsiType.AFTER_KAG;
                journal.DssComplaints = "Жалоб на момент осмотра не предъявляет.";
            }
            journal.DssDiagnosis = afterKagDiagnosisTxt.Text;
            journal.DssJournal = surgeryInspectationTxt.Text;
            journal.DssChdd = chddSurgeryTxt.Text;
            journal.DssChss = chssSurgeryTxt.Text;
            journal.DssAd = adSurgeryTxt.Text;
            journal.DssPs = surgeryPsTxt.Text;
            journal.DssEkg = ekgTxt0.Text;
            journal.DsdtAdmissionDate = CommonUtils.constructDateWIthTime(admissionDateTxt.Value, admissionTimeTxt.Value);
            journalId = service.updateOrCreateIfNeedObject<DdtJournal>(journal, DdtJournal.TABLE_NAME, journal.RObjectId);

            if (CommonUtils.isNotBlank(kagDiagnosisTxt.Text))
            {
                DdtKag kag = service.queryObjectById<DdtKag>(DdtKag.TABLE_NAME, kagId);
                if (kag == null)
                {
                    kag = new DdtKag();
                    kag.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    kag.DsidHospitalitySession = hospitalitySession.ObjectId;
                    kag.DsidPatient = hospitalitySession.DsidPatient;
                    DateTime admissionDateTime = CommonUtils.constructDateWIthTime(admissionDateTxt.Value, admissionTimeTxt.Value);
                    kag.DsdtAnalysisDate = admissionDateTime.AddMinutes(-75);
                    kag.DsdtStartTime = admissionDateTime.AddMinutes(-75); ;
                    kag.DsdtEndTime = admissionDateTime.AddMinutes(-15); ;
                }
                kag.DsidParent = journalId;
                kag.DssKagAction = kagDiagnosisTxt.Text;
                service.updateOrCreateIfNeedObject<DdtKag>(kag, DdtKag.TABLE_NAME, kag.ObjectId);
            }

            for (int i = 0; i < dutyCardioContainer.Controls.Count; i++)
            {
                JournalKAGControl journalCtrl = (JournalKAGControl)dutyCardioContainer.Controls[i];
                DdtVariousSpecConcluson conclusion = journalCtrl.getObject();
                if (conclusion == null)
                {
                    conclusion = new DdtVariousSpecConcluson();
                }
                conclusion.DssParentType = DdtJournal.TABLE_NAME;
                conclusion.DsidParent = journalId;
                conclusion.DssSpecialistType = "Дежурный кардиореаниматолог";
                conclusion.DsbAdditionalBool = false;
                service.updateOrCreateIfNeedObject<DdtVariousSpecConcluson>(conclusion, DdtVariousSpecConcluson.TABLE_NAME, conclusion.RObjectId);
            }

            DdtVariousSpecConcluson releaseConclusion = releaseJournalCtrl.getObject();
            if (releaseConclusion == null)
            {
                releaseConclusion = new DdtVariousSpecConcluson();
            }
            releaseConclusion.DssParentType = DdtJournal.TABLE_NAME;
            releaseConclusion.DsidParent = journalId;
            releaseConclusion.DssSpecialistType = "Дежурный кардиореаниматолог";
            releaseConclusion.DsbAdditionalBool = true;
            service.updateOrCreateIfNeedObject<DdtVariousSpecConcluson>(releaseConclusion, DdtVariousSpecConcluson.TABLE_NAME, releaseConclusion.RObjectId);
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            save();
            DataService service = new DataService();
            DdtJournal journal = service.queryObjectById<DdtJournal>(DdtJournal.TABLE_NAME, journalId);
            if (journal != null)
            {
                ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtJournal.TABLE_NAME);
                string path = processor.processTemplate(hospitalitySession.ObjectId, journal.RObjectId, null);
                TemplatesUtils.showDocument(path);
            }
        }

        private void selectKAGBtn_Click(object sender, EventArgs e)
        {
            if (selector == null)
            {
                selector = new AnalysisSelector();
            }
            selector.ShowDialog(DdtKag.TABLE_NAME, "dsid_hospitality_session='" + hospitalitySession.ObjectId + "'", "r_creation_date", "r_object_id", new List<string> { "" });
            if (selector.isSuccess())
            {
                List<string> ids = selector.returnValues();
                if (ids.Count > 0)
                {
                    DataService service = new DataService();
                    DdtKag kag = service.queryObjectById<DdtKag>(DdtKag.TABLE_NAME, ids[0]);
                    initKag(kag);
                }
            }
        }

        private void removeKAG_Click(object sender, EventArgs e)
        {
            if (CommonUtils.isNotBlank(kagId))
            {
                DataService service = new DataService();
                DdtKag kag = service.queryObjectById<DdtKag>(DdtKag.TABLE_NAME, kagId);
                if (kag != null)
                {
                    kag.DsidParent = null;
                    service.updateObject<DdtKag>(kag, DdtKag.TABLE_NAME, "r_object_id", kag.ObjectId);
                }
            }
            kagId = null;
        }
    }
}
