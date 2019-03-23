﻿using System;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Controls
{
    public partial class JournalNoKAGControl : UserControl, IDocbaseControl
    {
        private string objectId;
        private string dsidCuringDoctor;
        private int journalType;
        private bool hasChanges;
        private bool isNew;

        public JournalNoKAGControl(string objectId, int journalType, string dsidCuringDoctor)
        {
            this.objectId = objectId;
            this.journalType = journalType;
            this.dsidCuringDoctor = dsidCuringDoctor;
            InitializeComponent();
            initControls();
            hasChanges = false;
            isNew = string.IsNullOrEmpty(objectId);
        }

        public bool isVisible()
        {
            return !hideJournalBtn.Checked;
        }

        internal void initTime(DateTime time)
        {
            if (time != null && time > DateTime.MinValue)
            {
                time = time.AddMinutes(JournalShuffleUtils.shuffleNextValue(-8, 8));
            }
            startDateTxt.Value = time;
            startTimeTxt.Value = time;
        }

        internal DateTime getJournalDateTime()
        {
            return CommonUtils.ConstructDateWIthTime(startDateTxt.Value, startTimeTxt.Value);
        }

        private void initControls()
        {
            CommonUtils.InitRangedItems(chssTxt, 40, 200);
            CommonUtils.InitRangedItems(chddTxt, 14, 26);
            warningLbl.Visible = false;


            CommonUtils.InitDoctorsComboboxValues(DbDataService.GetService(), docBox, " r_object_id in (select dsid_doctor_id from dm_group_users where dss_group_name = 'cardioreanimation_department') ");
            CommonUtils.SetDoctorsComboboxDefaultValue(DbDataService.GetService(), docBox, dsidCuringDoctor);

            DdtJournal journal = DbDataService.GetService().GetDdtJournalService().GetById(objectId);
            refreshObject(journal);
        }

        public void saveObject(DdtHospital hospitalitySession, string parentId, string parentType)
        {


            if (string.IsNullOrEmpty(journalTxt.Text) || !(isDirty() || isNew))
            {
                return;
            }

            DdtJournal journal = (DdtJournal)getObject();
            DdvDoctor selectedDoc = (DdvDoctor)docBox.SelectedItem;
            journal.Doctor = selectedDoc == null ? hospitalitySession.CuringDoctor : selectedDoc.ObjectId;
            journal.HospitalitySession = hospitalitySession.ObjectId;
            journal.Patient = hospitalitySession.Patient;

            objectId = DbDataService.GetService().GetDdtJournalService().Save(journal);
            hasChanges = false;
            isNew = false;
        }

        public string getObjectId()
        {
            return objectId;
        }

        public bool isGoodRhytm()
        {
            return goodRhytmBtn.Checked;
        }

        public void initRhytm(bool goodRhytm)
        {
            goodRhytmBtn.Checked = goodRhytm;
            badRhytmBtn.Checked = !goodRhytm;
            goodRhytmBtn_CheckedChanged(null, null);
        }

        public string getDocName()
        {
            return docBox.Text;
        }

        public void initDocName(string docName)
        {
            docBox.SelectedIndex = docBox.FindStringExact(docName);
        }

        public bool getIsValid()
        {
            bool result = chddTxt.SelectedIndex >= 0 && chssTxt.SelectedIndex >= 0 && adTxt.SelectedIndex >= 0 && docBox.SelectedIndex >= 0;
            warningLbl.Visible = !result;
            return result;
        }

        public bool isDirty()
        {
            return hasChanges;
        }

        public object getObject()
        {

            DdtJournal journal = DbDataService.GetService().GetDdtJournalService().GetById(objectId);
            if (journal == null)
            {
                journal = new DdtJournal();
                journal.JournalType = journalType;
            }

            journal.Ad = adTxt.Text;
            journal.Chdd = chddTxt.Text;
            journal.Chss = chssTxt.Text;
            journal.Complaints = complaintsTxt.Text;
            journal.Journal = journalTxt.Text;
            journal.Monitor = monitorTxt.Text;
            journal.GoodRhythm = goodRhytmBtn.Checked;
            journal.AdmissionDate = CommonUtils.ConstructDateWIthTime(startDateTxt.Value, startTimeTxt.Value);

            DdvDoctor selectedDoc = (DdvDoctor)docBox.SelectedItem;
            if (selectedDoc != null)
            {
                journal.Doctor = selectedDoc.ObjectId;
            }
            return journal;
        }

        public void refreshObject(object obj)
        {
            if (obj != null && obj is DdtJournal)
            {
                DdtJournal journal = (DdtJournal)obj;

                complaintsTxt.Text = journal.Complaints;
                adTxt.Text = journal.Ad;
                chddTxt.Text = journal.Chdd;
                chssTxt.Text = journal.Chss;
                monitorTxt.Text = journal.Monitor;
                journalTxt.Text = journal.Journal;

                startDateTxt.Value = journal.AdmissionDate;
                startTimeTxt.Value = journal.AdmissionDate;

                goodRhytmBtn.Checked = journal.GoodRhythm;
                badRhytmBtn.Checked = !journal.GoodRhythm;

                DdvDoctor doc = DbDataService.GetService().GetDdvDoctorService().GetById(journal.Doctor);
                docBox.SelectedIndex = docBox.FindStringExact(doc.ShortName);
                objectId = journal.ObjectId;
                isNew = string.IsNullOrEmpty(objectId);
                hasChanges = false;
            }
            else
            {
                journalTxt.Text = journalType == (int)DdtJournalDsiType.PENDING_JUSTIFICATION ? JournalShuffleUtils.shuffleBadJournalText() : JournalShuffleUtils.shuffleJournalText();
                if (journalType == (int)DdtJournalDsiType.AFTER_PENDING)
                {
                    journalTxt.Text += "Необходимо решить вопрос о проведении консилиума.";
                    this.journalType = (int)DdtJournalDsiType.BEFORE_KAG;
                }
                adTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(adTxt.Items.Count - 1);
                chddTxt.SelectedIndex = chddTxt.FindString("14");
                chssTxt.SelectedIndex = JournalShuffleUtils.shuffleNextIndex(chssTxt.Items.Count - 1);
            }
        }

        #region controls_behaviour
        private void hideJournalBtn_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            visibledPanel.Visible = !cb.Checked;
            Size = cb.Checked ? new System.Drawing.Size(900, 40) : new System.Drawing.Size(900, 181);
            cb.Location = cb.Checked ? new System.Drawing.Point(300, 19) : new System.Drawing.Point(300, 158);
        }

        private void goodRhytmBtn_CheckedChanged(object sender, EventArgs e)
        {
            monitorTxt.Text = goodRhytmBtn.Checked ? "синусовый ритм" : "трепетание предсердий";
        }

        private void chddTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newValue = chddTxt.Text;
            if (!string.IsNullOrEmpty(newValue))
            {
                string oldJournal = journalTxt.Text;
                journalTxt.Text = CommonUtils.ReplaceJournalIntParameter(oldJournal, "ЧД", newValue);
                hasChanges = true;
            }
        }

        private void chssTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newValue = chssTxt.Text;
            if (!string.IsNullOrEmpty(newValue))
            {
                string oldJournal = journalTxt.Text;
                journalTxt.Text = CommonUtils.ReplaceJournalIntParameter(oldJournal, "ЧСС", newValue);
                hasChanges = true;
            }
        }

        private void adTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newValue = adTxt.Text;
            if (!string.IsNullOrEmpty(newValue))
            {
                string oldJournal = journalTxt.Text;
                journalTxt.Text = CommonUtils.ReplaceJournalIntParameter(oldJournal, "АД", newValue);
                hasChanges = true;
            }
        }

        private void journalTxt_TextChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        private void TimeTxt_ValueChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        private void docBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }
        #endregion
    }
}
