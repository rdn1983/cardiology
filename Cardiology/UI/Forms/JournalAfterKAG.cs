using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;
using Cardiology.UI.Controls;

namespace Cardiology.UI.Forms
{
    public partial class JournalAfterKAG : Form, IAutoSaveForm
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
            SilentSaver.setForm(this);
        }

        private void initControls()
        {
            CommonUtils.InitRangedItems(chssSurgeryTxt, 40, 200);
            CommonUtils.InitRangedItems(chddSurgeryTxt, 14, 26);

            afterKagDiagnosisTxt.Text = hospitalitySession.DssDiagnosis;
            DataService service = new DataService();

            CommonUtils.InitDoctorsComboboxValues(service, journalDocBox, "");
            releaseJournalCtrl.initDateTime(CommonUtils.ConstructDateWIthTime(admissionDateTxt.Value, DateTime.Parse("8:05:00")));

            DdtPatient patient = service.queryObjectById<DdtPatient>(hospitalitySession.DsidPatient);
            if (patient != null)
            {
                Text += " " + patient.DssInitials;
            }

            if (!string.IsNullOrEmpty(journalId))
            {
                DdtJournal journal = service.queryObjectById<DdtJournal>(journalId);
                if (journal != null)
                {
                    surgeryInspectationTxt.Text = journal.DssJournal;
                    chssSurgeryTxt.Text = journal.DssChss;
                    chddSurgeryTxt.Text = journal.DssChdd;
                    adSurgeryTxt.Text = journal.DssAd;
                    admissionTimeTxt.Value = journal.DsdtAdmissionDate;
                    admissionDateTxt.Value = journal.DsdtAdmissionDate;
                    ekgTxt0.Text = journal.DssEkg;
                    afterKagDiagnosisTxt.Text = journal.DssDiagnosis;

                    DdvDoctor doctors = service.queryObjectById<DdvDoctor>(journal.DsidDoctor);
                    journalDocBox.SelectedIndex = journalDocBox.FindStringExact(doctors.DssInitials);

                    DdtKag kag = service.queryObjectByAttrCond<DdtKag>(DdtKag.TABLE_NAME, "dsid_parent", journal.ObjectId, true);
                    if (kag != null)
                    {
                        kagDiagnosisTxt.Text = kag.DssKagAction;
                        kagId = kag.ObjectId;
                    }

                    initCardioConslusions(service);
                }
            }
            else
            {
                //Для нового дневника ставим время через 1 час после приема. если есть КАГ, то через 15 мин после КАГ
                DdtKag kag = service.queryObject<DdtKag>(@"SELECT * FROM ddt_kag WHERE dsid_hospitality_session='" + hospitalitySession.ObjectId + "' ORDER BY dsdt_analysis_date ASC");
                initKag(kag);

                DdvDoctor doctors = service.queryObjectById<DdvDoctor>(hospitalitySession.DsidCuringDoctor);
                journalDocBox.SelectedIndex = journalDocBox.FindStringExact(doctors.DssInitials);
            }
        }

        private void initKag(DdtKag kag)
        {
            DateTime dt = hospitalitySession.DsdtAdmissionDate.AddHours(1);
            if (kag != null)
            {
                kagDiagnosisTxt.Text = kag.DssKagAction;
                if (kag.DsdtEndTime != default(DateTime))
                {
                    dt = kag.DsdtEndTime.AddMinutes(15);
                }
                kagId = kag.ObjectId;
            }
            admissionDateTxt.Value = dt;
            admissionTimeTxt.Value = dt;

            if (dt != default(DateTime) && dt.Hour > 8)
            {
                dt = dt.AddDays(1);
            }
            releaseJournalCtrl.initDateTime(CommonUtils.ConstructDateWIthTime(dt, DateTime.Parse("8:05:00")));
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
                    JournalKAGControl control = new JournalKAGControl(cardioConclusions[i].ObjectId, false);
                    //control.Anchor = AnchorStyles.Right;
                    dutyCardioContainer.Controls.Add(control);
                }
            }

            DdtVariousSpecConcluson releaseConclusion = service.queryObject<DdtVariousSpecConcluson>("Select * from " + DdtVariousSpecConcluson.TABLE_NAME +
                " WHERE dsid_parent='" + journalId + "' AND dsb_additional_bool=true");
            if (releaseConclusion != null)
            {
                releaseJournalCtrl.refreshObject(releaseConclusion);
            }
        }

        private void addCardioInspetions_Click(object sender, EventArgs e)
        {
            JournalKAGControl control = new JournalKAGControl(null, false);
            int indx = dutyCardioContainer.Controls.Count - 1;
            DateTime lastDate = DateTime.Now;
            if (indx >= 0)
            {
                JournalKAGControl last = (JournalKAGControl)dutyCardioContainer.Controls[indx];
                lastDate = last.getDateTime();
                control.initRhytm(last.isGoodRhytm());
            }
            control.Anchor = AnchorStyles.Right;
            control.initDateTime(lastDate.AddHours(4));
            dutyCardioContainer.Controls.Add(control);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (save())
            {
                Close();
            }
        }

        public bool save()
        {
            DataService service = new DataService();
            service.updateObject<DdtHospital>(hospitalitySession, DdtHospital.TABLE_NAME, "r_object_id", hospitalitySession.ObjectId);

            DdtJournal journal = null;
            if (!string.IsNullOrEmpty(journalId))
            {
                journal = service.queryObjectById<DdtJournal>(journalId);
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
            journal.DssEkg = ekgTxt0.Text;
            journal.DsdtAdmissionDate = CommonUtils.ConstructDateWIthTime(admissionDateTxt.Value, admissionTimeTxt.Value);
            journalId = service.updateOrCreateIfNeedObject<DdtJournal>(journal, DdtJournal.TABLE_NAME, journal.ObjectId);

            if (!string.IsNullOrEmpty(kagDiagnosisTxt.Text))
            {
                DdtKag kag = service.queryObjectById<DdtKag>(kagId);
                if (kag == null)
                {
                    kag = new DdtKag();
                    kag.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                    kag.DsidHospitalitySession = hospitalitySession.ObjectId;
                    kag.DsidPatient = hospitalitySession.DsidPatient;
                    DateTime admissionDateTime = CommonUtils.ConstructDateWIthTime(admissionDateTxt.Value, admissionTimeTxt.Value);
                    kag.DsdtAnalysisDate = admissionDateTime.AddMinutes(-75);
                    kag.DsdtStartTime = admissionDateTime.AddMinutes(-75); ;
                    kag.DsdtEndTime = admissionDateTime.AddMinutes(-15); ;
                }
                kag.DsidParent = journalId;
                kag.DssKagAction = kagDiagnosisTxt.Text;
                kagId = service.updateOrCreateIfNeedObject<DdtKag>(kag, DdtKag.TABLE_NAME, kag.ObjectId);
            }

            for (int i = 0; i < dutyCardioContainer.Controls.Count; i++)
            {
                JournalKAGControl journalCtrl = (JournalKAGControl)dutyCardioContainer.Controls[i];
                journalCtrl.saveObject(hospitalitySession, journalId, DdtJournal.TABLE_NAME);
            }

            releaseJournalCtrl.saveObject(hospitalitySession, journalId, DdtJournal.TABLE_NAME);
            return true;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (save())
            {
                DataService service = new DataService();
                DdtJournal journal = service.queryObjectById<DdtJournal>(journalId);
                if (journal != null)
                {
                    ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtJournal.TABLE_NAME);
                    string path = processor.processTemplate(hospitalitySession.ObjectId, journal.ObjectId, null);
                    TemplatesUtils.showDocument(path);
                }
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
                    DdtKag kag = service.queryObjectById<DdtKag>(ids[0]);
                    initKag(kag);
                }
            }
        }

        private void removeKAG_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(kagId))
            {
                DataService service = new DataService();
                DdtKag kag = service.queryObjectById<DdtKag>(kagId);
                if (kag != null)
                {
                    kag.DsidParent = null;
                    service.updateObject<DdtKag>(kag, DdtKag.TABLE_NAME, "r_object_id", kag.ObjectId);
                }
            }
            kagId = null;
        }

        private void JournalAfterKAG_FormClosing(object sender, FormClosingEventArgs e)
        {
            SilentSaver.clearForm();
        }


    }
}
