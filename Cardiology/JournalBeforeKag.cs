using Cardiology.Model;
using Cardiology.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class JournalBeforeKag : Form
    {
        private bool isWithKag = false;
        private List<string> journalIds;
        private DdtHospital hospitalitySession;

        public JournalBeforeKag(DdtHospital hospitalitySession, List<string> journalIds, bool isWithKag)
        {
            this.hospitalitySession = hospitalitySession;
            this.journalIds = journalIds;
            this.isWithKag = isWithKag;
            InitializeComponent();
            initRangedItems(chssTxt0, 40, 200);
            initRangedItems(psTxt0, 40, 200);
            initRangedItems(chddTxt0, 14, 26);
            initJournals();
            initControlVisibility();
        }

        private void initControlVisibility()
        {
            deffedredAllPnl.Visible = isWithKag;
            goodRhytmBtn0.Visible = isWithKag;
            badRhytmBtn0.Visible = isWithKag;
            addDefferedBtn.Visible = isWithKag;
            complaintsTxt0.Visible = !isWithKag;
            complaintsLbl0.Visible = !isWithKag;
            addDayCb0.Visible = isWithKag;
            if (!isWithKag)
            {
                journalAllPnl.Text = "Журнал";
                journalAllPnl.Size = new System.Drawing.Size(855, 580);
                journalGrouppedPanel.Size = new System.Drawing.Size(855, 548);
            }
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
            if (journalIds == null)
            {
                return;
            }

            DataService service = new DataService();
            DdtJournal journal = null;
            for (int i = 0; i < journalIds.Count; i++)
            {
                journal = service.queryObject<DdtJournal>("Select * FROM ddt_journal WHERE r_object_id ='" + journalIds[i] + "'");
                if (journal != null)
                {
                    Control panelCntr = null;
                    if (journalContainer.Controls.Count <= i)
                    {
                        panelCntr = CommonUtils.copyControl(journalPnl0, journalContainer.Controls.Count);
                        journalContainer.Controls.Add(panelCntr);
                    }
                    else
                    {
                        panelCntr = journalContainer.Controls[i];
                    }
                    updateControl(panelCntr, "adTxt" + i, journal.DssAd);
                    //updateControl(panelCntr, "adTxt0", journal.DssCardioExam);
                    updateControl(panelCntr, "chddTxt" + i, journal.DssChdd);
                    updateControl(panelCntr, "chssTxt" + i, journal.DssChss);
                    //updateControl(panelCntr, "adTxt0", journal.DssComplaints);
                    updateControl(panelCntr, "monitorTxt" + i, journal.DssMonitor);
                    updateControl(panelCntr, "psTxt" + i, journal.DssPs);
                    //updateControl(panelCntr, "adTxt0", journal.DssRhythm);
                    //updateControl(panelCntr, "adTxt0", journal.DssSurgeonExam);
                    //updateControl(panelCntr, "adTxt0", journal.DssSurgeonExam1);
                    updateControl(panelCntr, "objectId" + i, journal.RObjectId);
                    updateControl(panelCntr, "journalTxt" + i, journal.DssJournal);

                }
            }
        }

        private void updateControl(Control container, string ctrlName, string value)
        {
            Control c = findControl(container, ctrlName);
            if (c != null)
            {
                c.Text = value;
            }
        }

        private Control findControl(Control container, string name)
        {
            Control[] c = container.Controls.Find(name, true);
            if (c.Length > 0)
            {
                return c[0];
            }
            return null;
        }

        private void addJournalBtn_Click(object sender, EventArgs e)
        {
            Control c = CommonUtils.copyControl(journalPnl0, journalContainer.Controls.Count);
            journalContainer.Controls.Add(c);
        }

        private void addDefferedBtn_Click(object sender, EventArgs e)
        {
            Control c = CommonUtils.copyControl(deferredPnl0, deferredContainer.Controls.Count);
            deferredContainer.Controls.Add(c);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            DataService service = new DataService();
            DdtJournal journal = null;
            for (int i = 0; i < journalContainer.Controls.Count; i++)
            {
                Control panelCntr = journalContainer.Controls[i];
                Control idCtrl = findControl(panelCntr, "objectId" + i);
                if (idCtrl != null && CommonUtils.isNotBlank(idCtrl.Text))
                {
                    journal = service.queryObject<DdtJournal>(@"SELECT * FROM ddt_journal WHERE r_object_id ='" + idCtrl.Text + "'");
                }
                else
                {
                    if (CommonUtils.isBlank(getStrigControlValue(panelCntr, "journalTxt" + i)))
                    {
                        //Пропускаем все группы для оторых не указано хотя бы заключение
                        continue;
                    }
                    journal = new DdtJournal();
                    journal.DsidDoctor = hospitalitySession.DsidDutyDoctor;
                    journal.DsidHospitalitySession = hospitalitySession.ObjectId;
                    journal.DsidPatient = hospitalitySession.DsidPatient;
                    journal.DsbBeforeKag = isWithKag;
                }

                journal.DssAd = getStrigControlValue(panelCntr, "adTxt" + i);
                journal.DssChdd = getStrigControlValue(panelCntr, "chddTxt" + i);
                journal.DssChss = getStrigControlValue(panelCntr, "chssTxt" + i);
                journal.DssMonitor = getStrigControlValue(panelCntr, "monitorTxt" + i);
                journal.DssJournal = getStrigControlValue(panelCntr, "journalTxt" + i);

                service.updateOrCreateIfNeedObject<DdtJournal>(journal, DdtJournal.TABLE_NAME, journal.RObjectId);
            }
            Close();
        }

        private string getStrigControlValue(Control container, string ctrlName)
        {
            Control c = findControl(container, ctrlName);
            if (c != null)
            {
                return c.Text;
            }
            return "";

        }
    }
}
