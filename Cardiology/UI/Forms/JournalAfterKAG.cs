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

            afterKagDiagnosisTxt.Text = hospitalitySession.Diagnosis;


            CommonUtils.InitDoctorsComboboxValues(service, journalDocBox, "");
            releaseJournalCtrl.initDateTime(CommonUtils.ConstructDateWIthTime(admissionDateTxt.Value, DateTime.Parse("8:05:00")));

            DdtPatient patient = service.queryObjectById<DdtPatient>(hospitalitySession.Patient);
            if (patient != null)
            {
                Text += " " + patient.ShortName;
            }

            if (!string.IsNullOrEmpty(journalId))
            {
                DdtJournal journal = service.queryObjectById<DdtJournal>(journalId);
                if (journal != null)
                {
                    surgeryInspectationTxt.Text = journal.Journal;
                    chssSurgeryTxt.Text = journal.Chss;
                    chddSurgeryTxt.Text = journal.Chdd;
                    adSurgeryTxt.Text = journal.Ad;
                    admissionTimeTxt.Value = journal.AdmissionDate;
                    admissionDateTxt.Value = journal.AdmissionDate;
                    ekgTxt0.Text = journal.Ekg;
                    afterKagDiagnosisTxt.Text = journal.Diagnosis;

                    DdvDoctor doctors = service.queryObjectById<DdvDoctor>(journal.Doctor);
                    journalDocBox.SelectedIndex = journalDocBox.FindStringExact(doctors.ShortName);

                    DdtKag kag = service.queryObjectByAttrCond<DdtKag>(DdtKag.NAME, "dsid_parent", journal.ObjectId, true);
                    if (kag != null)
                    {
                        kagDiagnosisTxt.Text = kag.KagAction;
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

                DdvDoctor doctors = service.queryObjectById<DdvDoctor>(hospitalitySession.CuringDoctor);
                journalDocBox.SelectedIndex = journalDocBox.FindStringExact(doctors.ShortName);
            }
        }

        private void initKag(DdtKag kag)
        {
            DateTime dt = hospitalitySession.AdmissionDate.AddHours(1);
            if (kag != null)
            {
                kagDiagnosisTxt.Text = kag.KagAction;
                if (kag.EndTime != default(DateTime))
                {
                    dt = kag.EndTime.AddMinutes(15);
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

        private void initCardioConslusions(IDbDataService service)
        {
            List<DdtVariousSpecConcluson> cardioConclusions = service.queryObjectsCollection<DdtVariousSpecConcluson>
                        ("Select * from " + DdtVariousSpecConcluson.NAME + " WHERE dsid_parent='" + journalId +
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

            DdtVariousSpecConcluson releaseConclusion = service.queryObject<DdtVariousSpecConcluson>("Select * from " + DdtVariousSpecConcluson.NAME +
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

            service.updateObject<DdtHospital>(hospitalitySession, DdtHospital.NAME, "r_object_id", hospitalitySession.ObjectId);

            DdtJournal journal = null;
            if (!string.IsNullOrEmpty(journalId))
            {
                journal = service.queryObjectById<DdtJournal>(journalId);
            }
            else
            {
                journal = new DdtJournal();
                journal.JournalType = 1;
                journal.Doctor = hospitalitySession.CuringDoctor;
                journal.HospitalitySession = hospitalitySession.ObjectId;
                journal.Patient = hospitalitySession.Patient;
                journal.JournalType = (int)DdtJournalDsiType.AFTER_KAG;
                journal.Complaints = "Жалоб на момент осмотра не предъявляет.";
            }
            journal.Diagnosis = afterKagDiagnosisTxt.Text;
            journal.Journal = surgeryInspectationTxt.Text;
            journal.Chdd = chddSurgeryTxt.Text;
            journal.Chss = chssSurgeryTxt.Text;
            journal.Ad = adSurgeryTxt.Text;
            journal.Ekg = ekgTxt0.Text;
            journal.AdmissionDate = CommonUtils.ConstructDateWIthTime(admissionDateTxt.Value, admissionTimeTxt.Value);
            journalId = service.updateOrCreateIfNeedObject<DdtJournal>(journal, DdtJournal.NAME, journal.ObjectId);

            if (!string.IsNullOrEmpty(kagDiagnosisTxt.Text))
            {
                DdtKag kag = service.queryObjectById<DdtKag>(kagId);
                if (kag == null)
                {
                    kag = new DdtKag();
                    kag.Doctor = hospitalitySession.CuringDoctor;
                    kag.HospitalitySession = hospitalitySession.ObjectId;
                    kag.Patient = hospitalitySession.Patient;
                    DateTime admissionDateTime = CommonUtils.ConstructDateWIthTime(admissionDateTxt.Value, admissionTimeTxt.Value);
                    kag.AnalysisDate = admissionDateTime.AddMinutes(-75);
                    kag.StartTime = admissionDateTime.AddMinutes(-75); ;
                    kag.EndTime = admissionDateTime.AddMinutes(-15); ;
                }
                kag.Parent = journalId;
                kag.KagAction = kagDiagnosisTxt.Text;
                kagId = service.updateOrCreateIfNeedObject<DdtKag>(kag, DdtKag.NAME, kag.ObjectId);
            }

            for (int i = 0; i < dutyCardioContainer.Controls.Count; i++)
            {
                JournalKAGControl journalCtrl = (JournalKAGControl)dutyCardioContainer.Controls[i];
                journalCtrl.saveObject(hospitalitySession, journalId, DdtJournal.NAME);
            }

            releaseJournalCtrl.saveObject(hospitalitySession, journalId, DdtJournal.NAME);
            return true;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (save())
            {
    
                DdtJournal journal = service.queryObjectById<DdtJournal>(journalId);
                if (journal != null)
                {
                    ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtJournal.NAME);
                    string path = processor.processTemplate(hospitalitySession.ObjectId, journal.ObjectId, null);
                    TemplatesUtils.ShowDocument(path);
                }
            }
        }

        private void selectKAGBtn_Click(object sender, EventArgs e)
        {
            if (selector == null)
            {
                selector = new AnalysisSelector();
            }
            selector.ShowDialog(DdtKag.NAME, "dsid_hospitality_session='" + hospitalitySession.ObjectId + "'", "r_creation_date", "r_object_id", new List<string> { "" });
            if (selector.isSuccess())
            {
                List<string> ids = selector.returnValues();
                if (ids.Count > 0)
                {
        
                    DdtKag kag = service.queryObjectById<DdtKag>(ids[0]);
                    initKag(kag);
                }
            }
        }

        private void removeKAG_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(kagId))
            {
    
                DdtKag kag = service.queryObjectById<DdtKag>(kagId);
                if (kag != null)
                {
                    kag.Parent = null;
                    service.updateObject<DdtKag>(kag, DdtKag.NAME, "r_object_id", kag.ObjectId);
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
