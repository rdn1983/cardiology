using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Commons;
using Cardiology.Data.Model2;
using Cardiology.UI.Controls;

namespace Cardiology.UI.Forms
{
    public partial class JournalAfterKAG : Form, IAutoSaveForm
    {
        private readonly IDbDataService service;
        private DdtHospital hospitalitySession;
        private AnalysisSelector selector;
        private string journalId;
        private string kagId;

        public JournalAfterKAG(IDbDataService service, DdtHospital hospitalitySession, string journalId)
        {
            this.service = service;
            this.hospitalitySession = hospitalitySession;
            this.journalId = journalId;
            InitializeComponent();
            initControls();
            List<string> validTypes = new List<string>() { "ddt_blood_analysis", "ddt_ekg", "ddt_urine_analysis", "ddt_egds", "ddt_xray", "ddt_holter", "ddt_specialist_conclusion", "ddt_uzi" };
            analysisTabControl1.init(hospitalitySession, journalId, DdtJournal.NAME, validTypes);
            SilentSaver.setForm(this);
        }

        private void initControls()
        {
            CommonUtils.InitRangedItems(chssSurgeryTxt, 40, 200);
            CommonUtils.InitRangedItems(chddSurgeryTxt, 14, 26);

            afterKagDiagnosisTxt.Text = hospitalitySession.Diagnosis;

            CommonUtils.InitDoctorsComboboxValues(service, journalDocBox, "");
            CommonUtils.InitDoctorsByGroupComboboxValues(service, cardioVascularBox, "xray_department");

            DdvPatient patientView = service.GetDdvPatientService().GetById(hospitalitySession.Patient);
            Text += " " + patientView?.ShortName;

            if (!string.IsNullOrEmpty(journalId))
            {
                DdtJournalDay journalDay = service.GetDdtJournalDayService().GetById(journalId);
                if (journalDay != null)
                {
                    DdtVariousSpecConcluson cardioVascularConcls = service.GetDdtVariousSpecConclusonService().GetByParentId(journalId);
                    surgeryInspectationTxt.Text = cardioVascularConcls?.SpecialistConclusion;
                    chddSurgeryTxt.Text = cardioVascularConcls?.AdditionalInfo1;
                    adSurgeryTxt.Text = cardioVascularConcls?.AdditionalInfo3;
                    chssSurgeryTxt.Text = cardioVascularConcls?.AdditionalInfo2;
                    cardioDate.Value = cardioVascularConcls == null ? DateTime.Now : cardioVascularConcls.AdmissionDate;
                    cardioTime.Value = cardioVascularConcls == null ? DateTime.Now : cardioVascularConcls.AdmissionDate;

                    admissionTimeTxt.Value = journalDay.AdmissionDate;
                    admissionDateTxt.Value = journalDay.AdmissionDate;
                    afterKagDiagnosisTxt.Text = journalDay.Diagnosis;

                    DdvDoctor doctors = service.GetDdvDoctorService().GetById(journalDay.Doctor);
                    journalDocBox.SelectedIndex = journalDocBox.FindStringExact(doctors.ShortName);

                    IList<DdtKag> kags = service.GetDdtKagService().GetByParentId(journalDay.ObjectId);
                    DdtKag kag = kags.Count > 0 ? kags[0] : null;
                    if (kag != null)
                    {
                        kagDiagnosisTxt.Text = kag.KagAction;
                        kagId = kag.ObjectId;
                        analysisTabControl1.addAnalisis(DdtKag.NAME, "КАГ", kag.ObjectId);
                    }

                    initCardioConslusions(service);
                }
            }
            else
            {
                //Для нового дневника ставим время через 1 час после приема. если есть КАГ, то через 15 мин после КАГ
                DdtKag kag = service.GetDdtKagService().GetByHospitalSession(hospitalitySession.ObjectId);
                initKag(kag);

                DdvDoctor doctors = service.GetDdvDoctorService().GetById(hospitalitySession.CuringDoctor);
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
        }

        private void initCardioConslusions(IDbDataService service)
        {
            IList<DdtJournal> cardioConclusions = service.GetDdtJournalService().GetByJournalDayId(journalId);
            for (int i = 0; i < cardioConclusions.Count; i++)
            {
                if (dutyCardioContainer.Controls.Count <= i)
                {
                    JournalKAGControl control = new JournalKAGControl(cardioConclusions[i].ObjectId, false);
                    //control.Anchor = AnchorStyles.Right;
                    dutyCardioContainer.Controls.Add(control);
                }
            }
        }

        private void addCardioInspetions_Click(object sender, EventArgs e)
        {
            int lastIndx = dutyCardioContainer.Controls.Count - 1;
            DateTime lastDate = DateTime.Now;
            DateTime initDate = DateTime.Now;
            int startRecalculateIndx = -1;
            for (int i = lastIndx; i >= 0; i--)
            {
                JournalKAGControl jj = (JournalKAGControl)dutyCardioContainer.Controls[i];
                if (i == lastIndx)
                {
                    lastDate = jj.getDateTime();
                }
                if (jj.isFreeze() || i == 0)
                {
                    initDate = i == 0 ? jj.getDateTime() : DateTime.Now;
                    startRecalculateIndx = i;
                }
            }
            DateTime nextDate = lastDate.AddHours(4);
            DateTime finalTime = new DateTime(lastDate.Year, lastDate.Month, lastDate.Day, 8, 15, 0);
            if (nextDate > finalTime && startRecalculateIndx >= 0)
            {
                long excess = finalTime.Hour * 60 + finalTime.Minute - initDate.Hour * 60 + initDate.Minute;
                nextDate = finalTime;
                for (int i = startRecalculateIndx + 1; i <= lastIndx; i++)
                {
                    JournalKAGControl jj = (JournalKAGControl)dutyCardioContainer.Controls[i];
                    //weight 100% =240 minutes;
                    double weight = 1;
                    double seconds = excess / dutyCardioContainer.Controls.Count * weight * 240 / 100;
                    DateTime recalculatedDt = jj.getDateTime().AddSeconds(-seconds);
                    jj.initDateTime(recalculatedDt);
                }
            }

            JournalKAGControl control = new JournalKAGControl(null, false);
            control.Anchor = AnchorStyles.Right;
            control.initDateTime(nextDate);
            dutyCardioContainer.Controls.Add(control);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Close();
            }
        }

        public bool Save()
        {
            service.GetDdtHospitalService().Save(hospitalitySession);

            DdtJournalDay journal = null;
            if (!string.IsNullOrEmpty(journalId))
            {
                journal = service.GetDdtJournalDayService().GetById(journalId);
            }
            else
            {
                journal = new DdtJournalDay();
                journal.JournalType = 1;
                journal.Doctor = hospitalitySession.CuringDoctor;
                journal.HospitalitySession = hospitalitySession.ObjectId;
                journal.Patient = hospitalitySession.Patient;
                journal.JournalType = (int)DdtJournalDsiType.AfterKag;
                journal.AdmissionDate = CommonUtils.ConstructDateWIthTime(admissionDateTxt.Value, admissionTimeTxt.Value);
                journal.Diagnosis = afterKagDiagnosisTxt.Text;
                journalId = service.GetDdtJournalDayService().Save(journal);


                //journal.Complaints = "Жалоб на момент осмотра не предъявляет.";
            }
            DdtVariousSpecConcluson cardioVascularConc = service.GetDdtVariousSpecConclusonService().GetByParentId(journalId);
            if (cardioVascularConc == null)
            {
                cardioVascularConc = new DdtVariousSpecConcluson();
                cardioVascularConc.Parent = journalId;
            }
            cardioVascularConc.AdmissionDate = CommonUtils.ConstructDateWIthTime(cardioDate.Value, cardioTime.Value);
            cardioVascularConc.SpecialistConclusion = surgeryInspectationTxt.Text;
            cardioVascularConc.AdditionalInfo1 = chddSurgeryTxt.Text;
            cardioVascularConc.AdditionalInfo3 = adSurgeryTxt.Text;
            cardioVascularConc.AdditionalInfo2 = chssSurgeryTxt.Text;
            service.GetDdtVariousSpecConclusonService().Save(cardioVascularConc);

            if (!string.IsNullOrEmpty(kagDiagnosisTxt.Text))
            {
                DdtKag kag = service.GetDdtKagService().GetById(kagId);
                if (kag == null)
                {
                    kag = new DdtKag();
                    kag.Doctor = hospitalitySession.CuringDoctor;
                    kag.HospitalitySession = hospitalitySession.ObjectId;
                    kag.Patient = hospitalitySession.Patient;
                    DateTime admissionDateTime = CommonUtils.ConstructDateWIthTime(admissionDateTxt.Value, admissionTimeTxt.Value);
                    kag.AnalysisDate = admissionDateTime.AddMinutes(-75);
                    kag.StartTime = admissionDateTime.AddMinutes(-75);
                    kag.EndTime = admissionDateTime.AddMinutes(-15);
                    kag.KagAction = kagDiagnosisTxt.Text;
                    kagId = service.GetDdtKagService().Save(kag);

                    IDdtRelationService relationService = DbDataService.GetInstance().GetDdtRelationService();
                    if (kagId != null && relationService.GetByParentAndChildIds(journalId, kagId) == null)
                    {
                        DdtRelation relation = new DdtRelation();
                        relation.Parent = journalId;
                        relation.Child = kagId;
                        relation.ChildType = DdtJournal.NAME;
                        relationService.Save(relation);
                    }
                }
            }

            for (int i = 0; i < dutyCardioContainer.Controls.Count; i++)
            {
                JournalKAGControl journalCtrl = (JournalKAGControl)dutyCardioContainer.Controls[i];
                journalCtrl.saveObject(hospitalitySession, journalId, DdtJournal.NAME);
            }

            analysisTabControl1.save(journalId, DdtJournal.NAME);
            return true;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                DdtJournal journal = service.GetDdtJournalService().GetById(journalId);
                if (journal != null)
                {
                    ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtJournal.NAME);
                    string path = processor.processTemplate(service, hospitalitySession.ObjectId, journal.ObjectId, null);
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

                    DdtKag kag = service.GetDdtKagService().GetById(ids[0]);
                    initKag(kag);
                }
            }
        }

        private void removeKAG_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(kagId))
            {

                DdtKag kag = service.GetDdtKagService().GetById(kagId);
                if (kag != null)
                {
                    kag.Parent = null;
                    service.GetDdtKagService().Save(kag);
                }
            }
            kagId = null;
        }

        private void JournalAfterKAG_FormClosing(object sender, FormClosingEventArgs e)
        {
            SilentSaver.clearForm();
        }

        private void toAnalysisBtn_Click(object sender, EventArgs e)
        {
            int currentTabIndx = tabControl1.SelectedIndex;
            if (currentTabIndx < tabControl1.TabCount - 1)
            {
                tabControl1.SelectTab(++currentTabIndx);
            }
        }

        private void toJournalsTab_Click(object sender, EventArgs e)
        {
            int currentTabIndx = tabControl1.SelectedIndex;
            if (currentTabIndx > 0)
            {
                tabControl1.SelectTab(--currentTabIndx);
            }
        }
    }
}
