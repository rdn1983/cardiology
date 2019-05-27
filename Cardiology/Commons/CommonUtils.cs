using Cardiology.Data;
using Cardiology.Data.Model2;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.ComboBox;

namespace Cardiology.Commons
{
    static class CommonUtils
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        internal static void InitDoctorsComboboxValues(IDbDataService service, ComboBox cb, string whereCnd)
        {
            cb.Items.Clear();
            string query = @"SELECT r_object_id, dss_full_name, dss_middle_name, dss_first_name, r_modify_date, dss_short_name, r_creation_date, dss_last_name FROM ddv_doctor " + (string.IsNullOrEmpty(whereCnd) ? "" : (" WHERE " + whereCnd));
            IList<DdvDoctor> doctors = service.GetDdvDoctorService().GetByQuery(query);
            cb.DataSource = doctors;
            cb.ValueMember = "ObjectId";
            cb.DisplayMember = "ShortName";
        }

        internal static void InitDoctorsByGroupComboboxValues(IDbDataService service, ComboBox cb, string groupName)
        {
            string query = @"SELECT d.r_object_id, d.dss_full_name, d.dss_middle_name, d.dss_first_name, d.r_modify_date, d.dss_short_name, d.r_creation_date, d.dss_last_name FROM ddv_doctor d, dm_group_users gr WHERE gr.dss_group_name='" + groupName + "' AND gr.dsid_doctor_id=d.r_object_id";
            cb.DataSource = service.GetDdvDoctorService().GetByQuery(query);
            cb.ValueMember = "ObjectId";
            cb.DisplayMember = "ShortName";
        }

        internal static void InitCureComboboxValuesByTypeId(IDbDataService service, ComboBox cb, string cureTypeId)
        {
            cb.SelectedIndex = -1;
            cb.Items.Clear();
            IList<DdtCure> cureList = service.GetDdtCureService().GetListByCureTypeId(cureTypeId);
            cb.Items.AddRange(cureList.ToArray());
            cb.ValueMember = "ObjectId";
            cb.DisplayMember = "Name";
        }

        internal static void InitCureTypeComboboxValues(IDbDataService service, ComboBox cb)
        {
            cb.Items.Clear();
            IList<DdtCureType> cureList = service.GetDdtCureTypeService().GetAll();
            foreach(DdtCureType obj in cureList)
            {
                cb.Items.Add(obj);
            }
            cb.ValueMember = "ObjectId";
            cb.DisplayMember = "Name";
        }

        internal static void SetDoctorsComboboxDefaultValue(IDbDataService service, ComboBox cb, string dsidCuringDoctor)
        {
            if (!string.IsNullOrEmpty(dsidCuringDoctor))
            {
                DdvDoctor doctor = service.GetDdvDoctorService().GetById(dsidCuringDoctor);
                cb.SelectedIndex = cb.FindStringExact(doctor.ShortName);
            }
        }


        internal static void InitRangedItems(ComboBox c, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                c.Items.Add(i);
            }
        }

        internal static DateTime ConstructDateWIthTime(DateTime dateSource, DateTime timeSource)
        {
            return new DateTime(dateSource.Year, dateSource.Month, dateSource.Day, timeSource.Hour, timeSource.Minute, 0);
        }


        internal static Control CopyControl(Control srcContainer, int index)
        {
            Control c = CreateControl(srcContainer, index);
            if (c != null)
            {
                for (int i = 0; i < srcContainer.Controls.Count; i++)
                {
                    Control sourceCtrl = srcContainer.Controls[i];
                    Control child;
                    if (sourceCtrl.Controls.Count > 0)
                    {
                        child = CopyControl(sourceCtrl, index);
                    }
                    else
                    {
                        child = CreateControl(sourceCtrl, index);
                    }
                    if (child != null)
                    {
                        child.Bounds = sourceCtrl.Bounds;
                        c.Controls.Add(child);
                    }
                }
            }
            return c;
        }

        private static Control CreateControl(Control sourceCtrl, int index)
        {
            Control result = null;
            if (sourceCtrl.GetType() == typeof(Label))
            {
                result = new Label {Visible = sourceCtrl.Visible};
                if (sourceCtrl.Visible)
                {
                    result.Text = sourceCtrl.Text;
                }
            }
            if (sourceCtrl.GetType() == typeof(TextBox))
            {
                result = new TextBox {Visible = sourceCtrl.Visible};
            }
            if (sourceCtrl.GetType() == typeof(CheckBox))
            {
                result = new CheckBox {Visible = sourceCtrl.Visible, Text = sourceCtrl.Text};
            }
            if (sourceCtrl.GetType() == typeof(Panel))
            {
                result = new Panel();
            }
            if (sourceCtrl.GetType() == typeof(DateTimePicker))
            {
                result = new DateTimePicker();
                ((DateTimePicker)result).Format = ((DateTimePicker)sourceCtrl).Format;
                ((DateTimePicker)result).CustomFormat = ((DateTimePicker)sourceCtrl).CustomFormat;
                ((DateTimePicker)result).ShowUpDown = ((DateTimePicker)sourceCtrl).ShowUpDown;

            }
            if (sourceCtrl.GetType() == typeof(ComboBox))
            {
                result = new ComboBox();
                ObjectCollection items = ((ComboBox)sourceCtrl).Items;
                for (int i = 0; i < items.Count; i++)
                {
                    ((ComboBox)result).Items.Add(items[i]);
                }
                ((ComboBox)result).ValueMember = ((ComboBox)sourceCtrl).ValueMember;
                ((ComboBox)result).DisplayMember = ((ComboBox)sourceCtrl).DisplayMember;
                ((ComboBox)result).DropDownStyle = ((ComboBox)sourceCtrl).DropDownStyle;
            }
            if (sourceCtrl.GetType() == typeof(RichTextBox))
            {
                result = new RichTextBox();
            }
            if (sourceCtrl.GetType() == typeof(RadioButton))
            {
                result = new RadioButton {Text = sourceCtrl.Text};
            }
            if (sourceCtrl.GetType() == typeof(Button))
            {
                result = new Button {Text = sourceCtrl.Text, Visible = sourceCtrl.Visible};
                ((Button)result).UseVisualStyleBackColor = ((Button)sourceCtrl).UseVisualStyleBackColor;
                ((Button)result).Image = ((Button)sourceCtrl).Image;
            }
            if (result != null)
            {
                result.Size = sourceCtrl.Size;
                result.Font = sourceCtrl.Font;
                string controlName = sourceCtrl.Name;
                int firstDigitIndx = GetFirstDigitIndex(controlName);
                result.Name = String.Intern(controlName.Substring(0, firstDigitIndx)) + index;
            }

            return result;
        }

        internal static int GetFirstDigitIndex(string str)
        {
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (!Char.IsDigit(str[i]))
                {
                    return i + 1;
                }
            }
            return -1;
        }

        public static Control FindControl(Control container, string name)
        {
            Control[] c = container.Controls.Find(name, true);
            if (c.Length > 0)
            {
                return c[0];
            }
            return null;
        }

        internal static DdtJournal ResolveKagJournal(IDbDataService service, DateTime incpectionDate, string sessionId)
        {
            string startDateQuery = @"SELECT dsdt_inspection_date FROM " + DdtInspection.NAME + " WHERE dsid_hospitality_session='" + sessionId + "'" +
                " AND dsdt_inspection_date<to_timestamp('" + incpectionDate.ToShortDateString() + " " + incpectionDate.ToLongTimeString() + "', 'DD.MM.YYYY HH24:MI:SS') ORDER BY dsdt_inspection_date DESC";
            DateTime startDate = service.GetTime(startDateQuery);

            return service.GetDdtJournalService().GetObject(@"SELECT r_object_id, dss_diagnosis, dss_chss, dss_chdd, r_creation_date, dss_complaints, "+
                "dss_surgeon_exam, dss_ekg, dsdt_admission_date, dss_monitor, dss_rhythm, dsid_doctor, dsid_patient, dss_ps, dss_ad, dsid_hospitality_session,"+
                " r_modify_date, dss_cardio_exam, dsi_journal_type, dsb_good_rhythm, dsb_release_journal, dss_journal FROM " + DdtJournal.NAME +
                " WHERE dsid_hospitality_session='" + sessionId + "'" +
                    " AND dsi_journal_type=" + (int)DdtJournalDsiType.AfterKag +
                    (startDate != default(DateTime) ? (" AND dsdt_admission_date>=to_timestamp('" + startDate.ToShortDateString() + " " + startDate.ToLongTimeString() + "', 'dd.mm.yyyy HH24:mi:ss')") : "") +
                    " AND dsdt_admission_date<=to_timestamp('" + incpectionDate.ToShortDateString() + " " + incpectionDate.ToLongTimeString() + "', 'dd.mm.yyyy HH24:mi:ss')");

        }

        internal static string ReplaceJournalIntParameter(string journal, string mask, string newValue)
        {
            try
            {
                if (!string.IsNullOrEmpty(journal))
                {

                    int index = -1;
                    StringBuilder resultBuilder = new StringBuilder();
                    if ((index = journal.IndexOf(mask, StringComparison.Ordinal)) >= 0)
                    {
                        int startIndex = index + mask.Length - 1;
                        int counter = 0;
                        int replaceStartIndex = -1;
                        int replaceEndIndex = -1;
                        while (replaceStartIndex < 0 && counter < 5)
                        {
                            char c = journal[startIndex + counter];
                            if (Char.IsDigit(c))
                            {
                                replaceStartIndex = startIndex + counter;
                            }
                            counter++;
                        }
                        while (replaceEndIndex < 0)
                        {
                            char c = journal[startIndex + counter];
                            bool isLastChar = startIndex + counter == journal.Length - 1;
                            if ((!Char.IsDigit(c) && '/' != c) || isLastChar)
                            {
                                replaceEndIndex = startIndex + counter;
                            }
                            counter++;
                        }

                        if (replaceStartIndex >= 0 && replaceEndIndex >= 0)
                        {
                            bool inserted = false;
                            for (int i = 0; i < journal.Length; i++)
                            {
                                if (i < replaceStartIndex || i >= replaceEndIndex)
                                {
                                    resultBuilder.Append(journal[i]);
                                }
                                else
                                {
                                    if (!inserted)
                                    {
                                        inserted = true;
                                        resultBuilder.Append(newValue);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        resultBuilder.Append(journal).Append(mask).Append(" ").Append(newValue).Append(" ");

                    }
                    return resultBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.Message);
                throw;
            }
            return journal;

        }

        public static Dictionary<string, DateTime> FindJournalDayPeriod(DateTime firstDate)
        {
            Dictionary<string, DateTime> result = new Dictionary<string, DateTime>();
            DateTime startDay = new DateTime(firstDate.Year, firstDate.Month, firstDate.Day, 8, 10, 0);
            DateTime endDay = new DateTime(firstDate.Year, firstDate.Month, firstDate.Day, 8, 09 ,0);
            if (firstDate.Hour>8)
            {
                endDay = endDay.AddDays(1);
            } else
            {
                startDay = new DateTime(firstDate.Year, firstDate.Month, firstDate.Day, firstDate.Hour, firstDate.Minute, 0);
            }
            result.Add("start", startDay);
            result.Add("end", endDay);
            return result;
        }

    }
}


