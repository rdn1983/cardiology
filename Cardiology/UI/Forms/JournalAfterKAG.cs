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
    public partial class JournalAfterKAG : Form, IAutoSaveForm, IAnalysisContainer
    {
        private readonly IDbDataService service;
        private DdtHospital hospitalitySession;
        private string journalDayId;
        private string kagId;

        public JournalAfterKAG(IDbDataService service, DdtHospital hospitalitySession, string journalId)
        {
            this.service = service;
            this.hospitalitySession = hospitalitySession;
            this.journalDayId = journalId;
            InitializeComponent();
            List<string> validTypes = new List<string>() { "ddt_blood_analysis", "ddt_ekg", "ddt_urine_analysis", "ddt_egds", "ddt_xray", "ddt_holter", "ddt_specialist_conclusion", "ddt_uzi" };
            analysisTabControl1.init(hospitalitySession, journalId, DdtJournal.NAME, validTypes);
            initControls();
            SilentSaver.setForm(this);
        }

        private void initControls()
        {
            wrongDateWarning.Visible = false;
            CommonUtils.InitRangedItems(chssSurgeryTxt, 40, 200);
            CommonUtils.InitRangedItems(chddSurgeryTxt, 14, 26);

            afterKagDiagnosisTxt.Text = hospitalitySession.Diagnosis;

            CommonUtils.InitDoctorsByGroupComboboxValues(service, journalDocBox, "cardioreanimation_department");
            CommonUtils.InitDoctorsByGroupComboboxValues(service, cardioVascularBox, "xray_department");

            DdvPatient patientView = service.GetDdvPatientService().GetById(hospitalitySession.Patient);
            Text += " " + patientView?.ShortName;

            if (!string.IsNullOrEmpty(journalDayId))
            {
                DdtJournalDay journalDay = service.GetDdtJournalDayService().GetById(journalDayId);
                if (journalDay != null)
                {
                    DdtVariousSpecConcluson cardioVascularConcls = service.GetDdtVariousSpecConclusonService().GetByParentId(journalDayId);
                    surgeryInspectationTxt.Text = cardioVascularConcls?.SpecialistConclusion;
                    chddSurgeryTxt.Text = cardioVascularConcls?.AdditionalInfo1;
                    adSurgeryTxt.Text = cardioVascularConcls?.AdditionalInfo3;
                    chssSurgeryTxt.Text = cardioVascularConcls?.AdditionalInfo2;
                    cardioDate.Value = cardioVascularConcls == null ? DateTime.Now : cardioVascularConcls.AdmissionDate;
                    cardioTime.Value = cardioVascularConcls == null ? DateTime.Now : cardioVascularConcls.AdmissionDate;
                    cardioVascularBox.SelectedValue = cardioVascularConcls?.AdditionalInfo4;

                    admissionTimeTxt.Value = journalDay.AdmissionDate;
                    admissionDateTxt.Value = journalDay.AdmissionDate;
                    afterKagDiagnosisTxt.Text = journalDay.Diagnosis;
                    journalDocBox.SelectedValue = journalDay.Doctor;

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
                String sql = String.Format("SELECT r_object_id, dsdt_analysis_date, dsdt_end_time, r_creation_date, dsid_parent, dss_kag_manipulation, " +
                    "dsid_doctor, dsid_patient, dsid_hospitality_session, dsdt_start_time, r_modify_date, dss_parent_type, dss_results, dss_kag_action " +
                    "FROM ddt_kag WHERE dsid_hospitality_session = '{0}' order by dsdt_analysis_date desc", hospitalitySession.ObjectId);
                IList<DdtKag> kags = service.GetDdtKagService().GetByQuery(sql);
                initKag(kags.Count > 0 ? kags[0] : null);

                getIsValid();

                journalDocBox.SelectedValue = hospitalitySession.CuringDoctor;
                cardioVascularBox.SelectedValue = hospitalitySession.DutyDoctor;
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
            IList<DdtJournal> cardioConclusions = service.GetDdtJournalService().GetByJournalDayId(journalDayId);
            for (int i = 0; i < cardioConclusions.Count; i++)
            {
                if (dutyCardioContainer.Controls.Count <= i)
                {
                    JournalKAGControl control = new JournalKAGControl(this, cardioConclusions[i].ObjectId, false);
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
            DateTime startRecalculatedTime = DateTime.Now;
            int startRecalculateIndx = -1;
            for (int i = lastIndx; i >= 0; i--)
            {
                JournalKAGControl jj = (JournalKAGControl)dutyCardioContainer.Controls[i];
                if (i == lastIndx)
                {
                    lastDate = jj.getDateTime();
                }
                if ((jj.isFreeze() || i == 0) && startRecalculateIndx < 0)
                {
                    initDate = i == 0 ? jj.getDateTime() : DateTime.Now;
                    startRecalculateIndx = i;
                }
                if (i == 0)
                {
                    startRecalculatedTime = jj.getDateTime();
                }
            }
            DateTime nextDate = lastDate.AddHours(4).AddMinutes(JournalShuffleUtils.shuffleNextIndex(5));
            DateTime finalTime = new DateTime(nextDate.Year, nextDate.Month, nextDate.Day, 8, 5, 0);
            if ((nextDate.Day > initDate.Day || initDate.Hour < 8) && nextDate > finalTime && startRecalculateIndx >= 0)
            {
                long ticksAllDay = finalTime.Ticks - startRecalculatedTime.Ticks;
                double minutesAllDay = ticksAllDay / 10000000 / 60;
                double minutesPerJ = minutesAllDay / (dutyCardioContainer.Controls.Count);
                nextDate = finalTime;
                DateTime lastRecalculated = new DateTime(startRecalculatedTime.Ticks);
                for (int i = startRecalculateIndx + 1; i <= lastIndx; i++)
                {
                    JournalKAGControl jj = (JournalKAGControl)dutyCardioContainer.Controls[i];
                    //weight 100% = 240 minutes;

                    DateTime re = lastRecalculated.AddMinutes(minutesPerJ);
                    jj.initDateTime(re);
                    lastRecalculated = new DateTime(re.Ticks);
                }
            }

            JournalKAGControl control = new JournalKAGControl(this, null, false);
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
            if (!getIsValid())
            {
                return false;
            }

            service.GetDdtHospitalService().Save(hospitalitySession);

            DdtJournalDay journalDay = null;
            if (!string.IsNullOrEmpty(journalDayId))
            {
                journalDay = service.GetDdtJournalDayService().GetById(journalDayId);

            }
            else
            {
                journalDay = new DdtJournalDay();
                journalDay.JournalType = 1;
                journalDay.HospitalitySession = hospitalitySession.ObjectId;
                journalDay.Patient = hospitalitySession.Patient;
                journalDay.JournalType = (int)DdtJournalDsiType.AfterKag;
                //journal.Complaints = "Жалоб на момент осмотра не предъявляет.";
            }
            journalDay.AdmissionDate = CommonUtils.ConstructDateWIthTime(admissionDateTxt.Value, admissionTimeTxt.Value);
            DdvDoctor doc = (DdvDoctor)journalDocBox.SelectedItem;
            journalDay.Doctor = doc == null ? hospitalitySession.DutyDoctor : doc.ObjectId;
            journalDay.Diagnosis = afterKagDiagnosisTxt.Text;
            journalDayId = service.GetDdtJournalDayService().Save(journalDay);

            DdtVariousSpecConcluson cardioVascularConc = service.GetDdtVariousSpecConclusonService().GetByParentId(journalDayId);
            if (cardioVascularConc == null)
            {
                cardioVascularConc = new DdtVariousSpecConcluson();
                cardioVascularConc.Parent = journalDayId;
            }
            cardioVascularConc.AdmissionDate = CommonUtils.ConstructDateWIthTime(cardioDate.Value, cardioTime.Value);
            cardioVascularConc.SpecialistConclusion = surgeryInspectationTxt.Text;
            cardioVascularConc.AdditionalInfo1 = chddSurgeryTxt.Text;
            cardioVascularConc.AdditionalInfo3 = adSurgeryTxt.Text;
            cardioVascularConc.AdditionalInfo2 = chssSurgeryTxt.Text;
            cardioVascularConc.AdditionalInfo4 = (string)cardioVascularBox.SelectedValue;
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
                    if (kagId != null && relationService.GetByParentAndChildIds(journalDayId, kagId) == null)
                    {
                        DdtRelation relation = new DdtRelation();
                        relation.Parent = journalDayId;
                        relation.Child = kagId;
                        relation.ChildType = DdtJournal.NAME;
                        relationService.Save(relation);
                    }
                }
            }

            for (int i = 0; i < dutyCardioContainer.Controls.Count; i++)
            {
                JournalKAGControl journalCtrl = (JournalKAGControl)dutyCardioContainer.Controls[i];
                journalCtrl.saveObject(hospitalitySession, journalDayId, DdtJournal.NAME);
            }

            analysisTabControl1.save(journalDayId, DdtJournal.NAME);
            return true;
        }

        private bool getIsValid()
        {
            Dictionary<string, DateTime> borderDateValues = CommonUtils.FindJournalDayPeriod(CommonUtils.ConstructDateWIthTime(admissionDateTxt.Value, admissionTimeTxt.Value));
            DateTime start = new DateTime();
            borderDateValues.TryGetValue("start", out start);
            DateTime end = new DateTime();
            borderDateValues.TryGetValue("end", out end);
            IList<DdtJournalDay> daysBetween = service.GetDdtJournalDayService().GetBetween(hospitalitySession.ObjectId, start, end, (int) DdtJournalDsiType.AfterKag);
            bool isSameDate = false;
            foreach (DdtJournalDay day in daysBetween)
            {
                isSameDate |= !day.ObjectId.Equals(journalDayId, StringComparison.Ordinal);
            }
            wrongDateWarning.Visible = isSameDate;
            return !isSameDate;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(DdtJournal.NAME);
                string path = processor.processTemplate(service, hospitalitySession.ObjectId, journalDayId, null);
                TemplatesUtils.ShowDocument(path);
            }
        }

        private void selectKAGBtn_Click(object sender, EventArgs e)
        {
            AnalysisSelector.getInstance().ShowDialog(DdtKag.NAME, "dsid_hospitality_session='" + hospitalitySession.ObjectId + "'", "r_creation_date", "r_object_id", new List<string> { "" });
            if (AnalysisSelector.getInstance().isSuccess())
            {
                List<string> ids = AnalysisSelector.getInstance().returnValues();
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

        public void RemoveControl(Control control, string type)
        {
            string id = ((IDocbaseControl)control).getObjectId();
            dutyCardioContainer.Controls.Remove(control);
            if (id != null)
            {
                if (id != null)
                {
                    DbDataService.GetInstance().Delete(DdtJournal.NAME, id);
                }
            }
        }

        private void admissionDateTxt_ValueChanged(object sender, EventArgs e)
        {
            getIsValid();
        }


    }
}
